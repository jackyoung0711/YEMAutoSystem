using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace JYM.AutoSystem
{
    public class LoadPageData
    {
        public LoadPageData(Button _btn_FisrtPage, Button _btn_Left, Button _btn_Right, Button _btn_LastPage, Button _btn_Go
            , Label _lbl_PageInfos1, Label _lbl_PageInfos2, TextBox _txbPageIndex, int pageSize, DataGridView _dgv, List<int> _indexColumns, PictureBox _picShow = null)
        {
            this.Btn_FirstPage = _btn_FisrtPage;
            this.Btn_FirstPage.Tag = 0;
            this.Btn_Left = _btn_Left;
            this.Btn_Left.Tag = 1;
            this.Btn_Right = _btn_Right;
            this.Btn_Right.Tag = 2;
            this.Btn_LastPage = _btn_LastPage;
            this.Btn_LastPage.Tag = 3;
            this.Btn_Go = _btn_Go;
            this.Btn_Go.Tag = 4;
            this.Lbl_infos1 = _lbl_PageInfos1;
            this.Lbl_infos2 = _lbl_PageInfos2;
            this.Txb_pageIndex = _txbPageIndex;
            this.PageSize = pageSize;
            this.Dgv = _dgv;
            this.IndexColumn = _indexColumns;
            if (this.PicShow != null)
            {
                this.PicShow = _picShow;
            }
            //this.FiledOutPut = _filedoutPut;
            //this.filedWhere = _filedWhere;
            //this.FiledOrder = _filedOrder;
            //this.order = _order;
            //添加点击事件
            this.Btn_FirstPage.Click += this.LoadPage_Click;
            this.Btn_Left.Click += this.LoadPage_Click;
            this.Btn_Right.Click += this.LoadPage_Click;
            this.Btn_LastPage.Click += this.LoadPage_Click;
            this.Btn_Go.Click += this.LoadPage_Click;
        }

        public Action Action { get; set; }

        public Action Atcion1 { get; set; }

        public Button Btn_FirstPage { get; set; }

        public Button Btn_Go { get; set; }

        public Button Btn_LastPage { get; set; }

        public Button Btn_Left { get; set; }

        public Button Btn_Right { get; set; }

        public DataGridView Dgv { get; set; }

        public Func<DataTable> Func { get; set; }

        public Func<int> FuncNums { get; set; }

        public List<int> IndexColumn { get; set; }

        public Label Lbl_infos1 { get; set; }

        public Label Lbl_infos2 { get; set; }

        public int PageCount { get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; }

        public PictureBox PicShow { get; set; }

        //获取datatable
        //获取总数
        public Thread Thread { get; set; }

        public int TotalRecords { get; set; }

        public TextBox Txb_pageIndex { get; set; }

        public void HidePic()
        {
            if (this.PicShow.InvokeRequired)
            {
                //在执行此对象的主线程上执行委托。
                //System.IAsyncResult BeginInvoke(System.Delegate method, object[] args) args: 作为给定方法的参数传递的 System.Object 类型数组。如果不需要参数，则可以为 null。
                //method: 对方法的 System.Delegate，采用 args 中包含的相同数字和类型的参数。
                this.PicShow.BeginInvoke(new UpdatePic(this.HidePic), null);
                return;
            }
            //执行完毕后图片消失
            this.PicShow.Hide();
        }

        //单表数据分页
        public void LoadOneTablePageData()
        {
            if (this.PicShow != null)
            {
                DataTable dtData;
                //显示gif图片
                this.Dgv.Rows.Clear();
                this.PicShow.Show();
                this.Thread = new Thread(() =>
                {
                    try
                    {
                        //模态
                        Thread.Sleep(1500);
                        dtData = this.Func();
                        this.TotalRecords = this.FuncNums();
                        this.Dgv.BeginInvoke(new SetDgv(dtinfo => DataGridViewHelper.InsertDataToDgv(dtData, this.Dgv, this.IndexColumn)), dtData);
                        //展示分页信息
                        this.Txb_pageIndex.Text = this.PageIndex.ToString();
                        this.PageCount = (this.TotalRecords % this.PageSize) > 0 ? ((this.TotalRecords / this.PageSize) + 1) : (this.TotalRecords / this.PageSize);
                        this.Lbl_infos1.Text = "每页" + this.PageSize + "个";
                        this.Lbl_infos2.Text = this.PageIndex + "/" + this.PageCount + " " + "共" + this.TotalRecords + "个记录";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        this.Action();
                        this.HidePic();
                        if (this.Thread != null)
                        {
                            if (this.Thread.IsAlive)
                            {
                                //this.Thread.Abort();
                            }
                        }
                    }
                });
                this.Thread.Start();
                this.Thread.IsBackground = true;
            }
            else
            {
                DataTable dtData = this.Func(); //tbll.GetAllTSources(filedOutPut, filedWhere, filedOrder, order, ((_pageIndex - 1) * _pageSize) + "," + _pageSize);
                //dtData = _func();
                //插入到dgv中
                DataGridViewHelper.InsertDataToDgv(dtData, this.Dgv, this.IndexColumn);
                //展示分页信息
                this.Txb_pageIndex.Text = this.PageIndex.ToString();
                this.TotalRecords = this.FuncNums();
                this.PageCount = (this.TotalRecords % this.PageSize) > 0 ? ((this.TotalRecords / this.PageSize) + 1) : (this.TotalRecords / this.PageSize);
                this.Lbl_infos1.Text = "每页" + this.PageSize + "个";
                this.Lbl_infos2.Text = this.PageIndex + "/" + this.PageCount + " " + "共" + this.TotalRecords + "个记录";
            }
        }

        //多表数据
        private void LoadPage_Click(object sender, EventArgs e)
        {
            if (this.Dgv.Rows.Count == 0)
            {
                MessageBox.Show("数据表中没有数据,不能进行此次操作", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Button btn = sender as Button;
            int tagIndex = Convert.ToInt32(btn.Tag);
            switch (tagIndex)
            {
                case 0:
                    this.PageIndex = 1;
                    break;

                case 1:
                    if (this.PageIndex > 1)
                    {
                        this.PageIndex = this.PageIndex - 1;
                    }
                    break;

                case 2:
                    if (this.PageIndex < this.PageCount)
                    {
                        this.PageIndex = this.PageIndex + 1;
                    }
                    break;

                case 3:
                    if (this.PageCount > 0)
                    {
                        this.PageIndex = this.PageCount;
                    }
                    break;

                case 4:
                    Regex r = new Regex(@"^\d+$");
                    if (!r.IsMatch(this.Txb_pageIndex.Text))
                    {
                        MessageBox.Show("您所输入的不是正整数", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int page = Convert.ToInt32(this.Txb_pageIndex.Text);
                    if (page == 0)
                    {
                        MessageBox.Show("输入的数字不能为0", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (page > this.PageCount)
                    {
                        MessageBox.Show("输入的数字不能比总页数大", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (this.PageCount > 0)
                    {
                        this.PageIndex = Convert.ToInt32(this.Txb_pageIndex.Text);
                    }
                    //}
                    break;
            }
            //加载dataTable的方法
            this.LoadOneTablePageData();
            //还能做其它事情
            if (this.PicShow == null)
            {
                this.Action();
            }
            else
            {
                this.Atcion1();
            }
        }

        #region Nested type: SetDgv

        private delegate void SetDgv(DataTable dt);

        #endregion Nested type: SetDgv

        #region Nested type: UpdatePic

        private delegate void UpdatePic();

        #endregion Nested type: UpdatePic
    }
}