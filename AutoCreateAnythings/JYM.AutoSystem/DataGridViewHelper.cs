using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using JYM.Model;

namespace JYM.AutoSystem
{
    public class DataGridViewHelper
    {
        //添加点击事件
        public static void AddCellMouseDownClick(DataGridView dgv, ContextMenuStrip cst)
        {
            dgv.CellMouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    //////权限过滤
                    //if (GlobalParams.GetUserInfoAndQxInfo.User_role > 0)
                    //{
                    //    foreach (ToolStripItem item in cst.Items)
                    //    {
                    //        if (!string.IsNullOrEmpty(item.Name))
                    //        {
                    //            if (!GlobalParams.GetUserInfoAndQxInfo.ListInfos.Contains(item.Name))
                    //            {
                    //                item.Enabled = false;
                    //            }
                    //        }
                    //    }
                    //}
                    dgv.Rows[e.RowIndex].Selected = true;
                    //弹出菜单
                    //cst.Show(
                    Point _Point = dgv.PointToClient(Cursor.Position);
                    //MousePosition
                    cst.Show(dgv, _Point);
                    //
                    dgv.EndEdit();
                }
            };
        }

        // 全选和非全选
        public static void AsAndCs(DataGridView dgv, int indexCheckbox, int flag)
        {
            bool result = flag == 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgv.Rows[i].Cells[indexCheckbox];
                checkCell.Value = result;
            }
        }

        //赋值
        public static void ChangeValue(DataGridViewRow dataRow, List<string> listValue)
        {
            foreach (string t in listValue)
            {
                //分割
                string[] infos = t.Split('&');
                int index = Convert.ToInt32(infos[0]);
                dataRow.Cells[index].Value = infos[1];
            }
        }

        //获取选中checbox行的某一列List数据
        public static List<string> GetCheckdCloumnsData(DataGridView dgv, int indexCheckbox, int column)
        {
            List<string> listStrs = new List<string>();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv[0, i].EditedFormattedValue.ToString()))
                {
                    listStrs.Add(dgv.Rows[i].Cells[column].Value.ToString());
                }
            }
            return listStrs;
        }

        //获取选中checbox行的某一列List数据
        public static List<DataGridViewModel> GetCheckdCloumnsDatasModels(DataGridView dgv, int indexCheckbox, int column)
        {
            List<DataGridViewModel> datas = new List<DataGridViewModel>();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv[0, i].EditedFormattedValue.ToString()))
                {
                    datas.Add(new DataGridViewModel { CellPhone = dgv.Rows[i].Cells[2].Value.ToString(), Password = dgv.Rows[i].Cells[3].Value.ToString(), UserIdentifer = dgv.Rows[i].Cells[1].Value.ToString(), IsBankAuth = dgv.Rows[i].Cells[10].Value.ToString() == "" ? "0" : dgv.Rows[i].Cells[10].Value.ToString(), RechargeAmount = string.IsNullOrEmpty(dgv.Rows[i].Cells[8].Value.ToString()) ? 0 : Convert.ToInt64(dgv.Rows[i].Cells[8].Value) });
                }
            }
            return datas;
        }

        //获取选中checkbox行的数据行
        public static List<DataGridViewRow> GetCheckedRows(DataGridView dgv, int indexCheckbox)
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv[0, i].EditedFormattedValue.ToString()))
                {
                    list.Add(dgv.Rows[i]);
                }
            }
            return list;
        }

        //根据条件获取datagridviewRow
        public static List<DataGridViewRow> GetDrsBySettings(DataGridView dgv, int index, string value)
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[index].Value.ToString() == value)
                {
                    //string strid = dgv.Rows[i].Cells[2].Value.ToString();
                    list.Add(dgv.Rows[i]);
                }
            }
            return list;
        }

        public static List<DataGridViewRow> GetDrsBySettings1(DataGridView dgv, List<string> listData)
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow dr = dgv.Rows[i];
                foreach (string t in listData)
                {
                    int index = Convert.ToInt32(t.Split(';')[0]);
                    string data = t.Split(',')[1];
                    if (dr.Cells[index].Value.ToString() != data)
                    {
                        break;
                    }
                }
                list.Add(dr);
            }
            return list;
        }

        //改datagridview填充数据并设置相关参数及右键菜单选项
        public static void HandleDatagridview(DataTable dt, DataGridView dgv, List<int> listColunmindex, bool flag, ContextMenuStrip cst)
        {
            //先找到dgv中所有的列名
            try
            {
                dgv.AllowUserToResizeRows = false;
                dgv.AllowUserToResizeColumns = false;
                //dgv.AllowUserToOrderColumns = false;
                dgv.Rows.Clear();
                List<string> columnNames = new List<string>();
                for (int n = 0; n < dgv.Columns.Count; n++)
                {
                    columnNames.Add(dgv.Columns[n].DataPropertyName);
                    dgv.Columns[n].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (listColunmindex.Count > 0)
                    {
                        if (listColunmindex.Contains(n))
                        {
                            //设置只读列
                            dgv.Columns[n].ReadOnly = true; //
                        }
                    }
                }
                List<int> indexList = new List<int>();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string cName = dt.Columns[j].ColumnName;
                    int index = columnNames.IndexOf(cName);
                    indexList.Add(index);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    int indexDgv = dgv.Rows.Add();
                    DataGridViewRow drDgv = dgv.Rows[indexDgv];
                    //赋值
                    for (int m = 0; m < indexList.Count; m++)
                    {
                        if (indexList[m] < 0)
                        {
                            continue;
                        }
                        drDgv.Cells[indexList[m]].Value = dr[m]; //
                    }
                }
                //添加右键菜单
                if (flag)
                {
                    // AddCellMouseDownClick(dgv, cst);
                }
            }
            catch (Exception ex)
            {
            }
        }

        //给datagridview填充数据
        public static void InsertDataToDgv(DataTable dt, DataGridView dgv, List<int> listColunmindex)
        {
            //先找到dgv中所有的列名
            try
            {
                dgv.AllowUserToResizeRows = false;
                dgv.AllowUserToResizeColumns = false;
                dgv.Rows.Clear();
                List<string> columnNames = new List<string>();
                for (int n = 0; n < dgv.Columns.Count; n++)
                {
                    columnNames.Add(dgv.Columns[n].DataPropertyName);
                    dgv.Columns[n].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (listColunmindex.Count > 0)
                    {
                        if (listColunmindex.Contains(n))
                        {
                            //设置只读列
                            dgv.Columns[n].ReadOnly = true; //
                        }
                    }
                }
                List<int> indexList = new List<int>();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string cName = dt.Columns[j].ColumnName;
                    int index = columnNames.IndexOf(cName);
                    indexList.Add(index);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    int indexDgv = dgv.Rows.Add();
                    DataGridViewRow drDgv = dgv.Rows[indexDgv];
                    //赋值
                    for (int m = 0; m < indexList.Count; m++)
                    {
                        if (indexList[m] < 0)
                        {
                            continue;
                        }
                        drDgv.Cells[indexList[m]].Value = dr[m]; //
                    }
                }
            }
            catch (Exception ex)
            {
            }
            dgv.EndEdit();
        }

        //设置给定dgv的
        public static void SetDgv(DataGridView dgv, List<int> listColunmindex)
        {
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            Parallel.For(0, dgv.Columns.Count, i =>
            {
                if (listColunmindex.Contains(i))
                {
                    dgv.Columns[i].ReadOnly = true; //
                }
            });
        }

        //给datagridview中的某一行修改数据
        public static void UpdateColumValue(DataGridViewRow dr, Dictionary<int, string> dics)
        {
            //DataGridView dgv=dr.get
            foreach (int key in dics.Keys)
            {
                dr.Cells[key].Value = dics[key];
            }
        }

        //string tName = t.Name;

        //Type t = pt.GetType();
        ////PropertyInfo ptttt=
        //pt.Product_name = "cables for hv";
        //Product pt = new Product();
        ////PropertyInfo pinfo=
        //// string reg = @"^\w+@\w+(\.\w+){0,3}$";/ readonly=true
        ////
        //product.Remark = "bbbb";
        //product.Product_name = "aaaa";

        //product.Create_time = DateTime.Now.ToString();

        //Product product = new Product();
        //List<PropertyInfo> listps = new List<PropertyInfo>();
        //PropertyInfo[] infos = t.GetProperties();

        //for (int i = 0; i < infos.Length; i++)
        //{
        //    //listps.Add(infos[i]);

        //    string name = infos[i].Name;
        //    object value = infos[i].GetValue(product);
        //    Type tee = infos[i].PropertyType;
        //    //what are  you doing now namestrin
        //    string nnn = tee.Name;

        //}

        ////Type type = Type.GetType("Product");
        ////var assembly = Assembly.Load("HuaidingSoft.Model");
        ////object a = assembly.CreateInstance("HuaidingSoft.Model.Product");

        ////Type type1 = a.GetType();

        ////PropertyInfo[] pts = type1.GetProperties();
        ////for (int i = 0; i < pts.Length; i++)
        ////{
        ////}
        ////string name = type1.GetProperties()[0].Name;
        ////FieldInfo[] fs = type1.GetFields();//8876655444
        ////string name1 = type1.GetFields()[0].Name;
        ////Type t = type.GetProperties()[0].;

        ////string name = type.GetProperties()[0].Name;
    }
}