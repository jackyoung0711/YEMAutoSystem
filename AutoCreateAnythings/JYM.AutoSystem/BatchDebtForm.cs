using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using JYM.Lib;
using JYM.Model;
using JYM.Service;
using MigrationData.DAL;

namespace JYM.AutoSystem
{
    public partial class BatchDebtForm : Form
    {
        public BatchDebtForm()
        {
            this.InitializeComponent();
            this.LoadData = new LoadPageData(this.btn_FirstPage, this.btn_left, this.btn_right, this.btn_LastPage, this.btn_Go, this.lbl_pageinfo1
                , this.lbl_pageinfo2, this.txt_pageIndex, 30, this.dgv_Data, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            CheckForIllegalCrossThreadCalls = false;
            this.picShow.Hide();
        }

        public LoadPageData LoadData { get; }
        public string WhereExpression { get; set; } = string.Empty;
        private JymService jymService { get; } = new JymService();

        private void BatchDebtForm_Load(object sender, EventArgs e)
        {
            this.cbx_pageSize.SelectedIndex = 0;
            //this.ReloadData();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cbType.SelectedIndex < 0)
            {
                MessageBox.Show("类型为必选项");
                return;
            }

            string userId = this.txtUserId.Text.Trim();
            string userAssetRatioId = this.txtUserAssetRatioId.Text.Trim();

            this.LoadPageData(0, this.cbType.SelectedIndex, userId, userAssetRatioId);
        }

        private void ck_IsSelectedAll_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell checkCell;
            if (this.ck_IsSelectedAll.Checked)
            {
                for (int i = 0; i < this.dgv_Data.Rows.Count; i++)
                {
                    checkCell = (DataGridViewCheckBoxCell)this.dgv_Data.Rows[i].Cells[0];
                    checkCell.Value = true;
                }
            }
            else
            {
                for (int i = 0; i < this.dgv_Data.Rows.Count; i++)
                {
                    checkCell = (DataGridViewCheckBoxCell)this.dgv_Data.Rows[i].Cells[0];
                    if (Convert.ToBoolean(checkCell.Value))
                    {
                        checkCell.Value = false;
                    }
                }
            }
        }

        private void CopyUserAssetRatioId_Click(object sender, EventArgs e)
        {
            if (this.dgv_Data.SelectedRows.Count > 0)
            {
                Clipboard.SetDataObject(this.dgv_Data.SelectedRows[0].Cells[2].Value.ToString());
                MessageBox.Show("复制成功");
            }
        }

        private void CopyUserId_Click(object sender, EventArgs e)
        {
            if (this.dgv_Data.SelectedRows.Count > 0)
            {
                Clipboard.SetDataObject(this.dgv_Data.SelectedRows[0].Cells[1].Value.ToString());
                MessageBox.Show("复制成功");
            }
        }

        private void dgv_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgv_Data.Rows[e.RowIndex].Cells[e.ColumnIndex];
                checkCell.Value = !Convert.ToBoolean(checkCell.Value);
            }
        }

        /// <summary>
        ///     加载数据
        /// </summary>
        private void LoadPageData(int pageIndex, int type, string userId = "", string userAssetRatioId = "")
        {
            SqlParameter pageIndexParam = new SqlParameter("@pageIndex", pageIndex);
            SqlParameter pageSizeParam = new SqlParameter("@pageSize", Convert.ToInt32(this.cbx_pageSize.Text));
            SqlParameter userIdParam = new SqlParameter("@userId", userId);
            SqlParameter userAssetRatioIdParam = new SqlParameter("@UserAssetRatioId", userAssetRatioId);
            SqlParameter totalCountParam = new SqlParameter("@totalCount", SqlDbType.Int) { Direction = ParameterDirection.Output };

            SqlParameter[] sqlparams = { pageIndexParam, pageSizeParam, userIdParam, userAssetRatioIdParam, totalCountParam };

            this.LoadData.Func = () => SqlHelperByYem.Query(type == 0 ? "[Core].PROC_UserRedeemableSubOrderForDev" : "[Core].PROC_UserRedeemableUserAssetRatioForDev", sqlparams, true);

            this.LoadData.FuncNums = () => Convert.ToInt32(totalCountParam.Value);

            this.LoadData.LoadOneTablePageData();
            this.LoadData.Action = () => this.LoadData.Lbl_infos1.Text = "每页";
        }

        private void RedeemSelectedRecord_Click(object sender, EventArgs e)
        {
            int SuccessCount = 0;
            this.picShow.Show();
            Task.Factory.StartNew(async () =>
            {
                List<RedeemInput> redeemInputRequests = new List<RedeemInput>();
                List<RedeemInput> redeemInputs = new List<RedeemInput>();
                for (int i = 0; i < this.dgv_Data.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)this.dgv_Data.Rows[i].Cells[0];
                    if (Convert.ToBoolean(checkCell.Value))
                    {
                        List<UserRedeemableAssetRatio> assets = new List<UserRedeemableAssetRatio>();
                        UserRedeemableAssetRatio asset = new UserRedeemableAssetRatio
                        {
                            AssetRatioType = Convert.ToInt32(this.dgv_Data.Rows[i].Cells[3].Value.ToString()),
                            UserAssetRatioId = this.dgv_Data.Rows[i].Cells[2].Value.ToString()
                        };
                        assets.Add(asset);

                        RedeemInput input = new RedeemInput();
                        input.UserId = this.dgv_Data.Rows[i].Cells[1].Value.ToString();
                        input.UserAssetRatios = assets;
                        redeemInputs.Add(input);
                    }
                }

                List<IGrouping<string, RedeemInput>> groupResult = redeemInputs.GroupBy(it => it.UserId).ToList();
                foreach (IGrouping<string, RedeemInput> item in groupResult)
                {
                    RedeemInput input = new RedeemInput
                    {
                        UserId = item.Key,
                        UserAssetRatios = new List<UserRedeemableAssetRatio>()
                    };
                    foreach (RedeemInput redeemInput in item)
                    {
                        input.UserAssetRatios.AddRange(redeemInput.UserAssetRatios);
                    }

                    redeemInputRequests.Add(input);
                    if (await this.jymService.RedeemAsync(input))
                    {
                        SuccessCount++;
                    }
                    else
                    {
                        JYMNLogger.Logger.Info($"用户[ {item.Key} ] 申请赎回失败");
                    }
                }

                this.picShow.Hide();
                MessageBox.Show($"赎回结束:申请了[ {groupResult.Count} ]个用户的赎回,成功[ {SuccessCount} ]条");

                this.ReloadData();
            });
        }

        private void RedeemThisRecord_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(async () =>
            {
                if (this.dgv_Data.SelectedRows.Count > 0)
                {
                    List<UserRedeemableAssetRatio> assets = new List<UserRedeemableAssetRatio>();
                    UserRedeemableAssetRatio asset = new UserRedeemableAssetRatio
                    {
                        AssetRatioType = Convert.ToInt32(this.dgv_Data.SelectedRows[0].Cells[3].Value.ToString()),
                        UserAssetRatioId = this.dgv_Data.SelectedRows[0].Cells[2].Value.ToString()
                    };
                    assets.Add(asset);

                    RedeemInput input = new RedeemInput
                    {
                        UserAssetRatios = assets,
                        UserId = this.dgv_Data.SelectedRows[0].Cells[1].Value.ToString()
                    };

                    bool result = await this.jymService.RedeemAsync(input);
                    if (result)
                    {
                        MessageBox.Show("赎回成功");
                        this.ReloadData();
                    }
                    else
                    {
                        MessageBox.Show("赎回失败");
                    }
                }
            });
        }

        private void ReloadData()
        {
            this.LoadData.PicShow = this.picShow;
            this.LoadPageData(0, this.cbType.SelectedIndex, this.txtUserId.Text.Trim(), this.txtUserAssetRatioId.Text.Trim());
            this.LoadData.Lbl_infos1.Text = "每页";
            //为页面容量设置改变事件
            this.cbx_pageSize.SelectedValueChanged += (objP, exP) =>
            {
                //获取此时的页码
                int pageSize = Convert.ToInt32(this.cbx_pageSize.Text);
                this.LoadData.PageSize = pageSize;
                this.LoadPageData(0, this.cbType.SelectedIndex, this.txtUserId.Text.Trim(), this.txtUserAssetRatioId.Text.Trim());
                this.LoadData.Lbl_infos1.Text = "每页";
            };
        }
    }
}