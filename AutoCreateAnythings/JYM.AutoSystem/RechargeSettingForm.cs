using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JYM.AutoSystem
{
    public partial class RechargeSettingForm : Form
    {
        private static RechargeSettingForm rechargeSettingForm;

        private RechargeSettingForm()
        {
            this.InitializeComponent();
        }

        private static Action<long> Action1 { get; set; }

        public static RechargeSettingForm GetRechargeSettingForm(Action<long> action)
        {
            if (rechargeSettingForm == null)
            {
                Action1 = action;
                rechargeSettingForm = new RechargeSettingForm();
            }
            return rechargeSettingForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[1-9]{1}[0-9]{0,14}$");
            string nums = this.txb_Amount.Text.Trim();
            if (!regex.IsMatch(nums))
            {
                MessageBox.Show("充值金额格式不对");
                return;
            }
            Action1(Convert.ToInt64(nums));
            this.Close();
        }

        private void RechargeSettingForm_Load(object sender, EventArgs e)
        {
        }
    }
}