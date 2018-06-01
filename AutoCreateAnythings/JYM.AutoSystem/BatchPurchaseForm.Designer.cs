namespace JYM.AutoSystem
{
    partial class BatchPurchaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_purchase = new System.Windows.Forms.Button();
            this.txb_SAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_NumsTotal = new System.Windows.Forms.TextBox();
            this.lbl_showMSg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_AmountRange = new System.Windows.Forms.ComboBox();
            this.txb_EAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_Type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_purchase
            // 
            this.btn_purchase.Location = new System.Drawing.Point(146, 231);
            this.btn_purchase.Name = "btn_purchase";
            this.btn_purchase.Size = new System.Drawing.Size(128, 41);
            this.btn_purchase.TabIndex = 10;
            this.btn_purchase.Text = "开始批量申购";
            this.btn_purchase.UseVisualStyleBackColor = true;
            this.btn_purchase.Click += new System.EventHandler(this.btn_purchase_Click);
            // 
            // txb_SAmount
            // 
            this.txb_SAmount.Enabled = false;
            this.txb_SAmount.Location = new System.Drawing.Point(336, 34);
            this.txb_SAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txb_SAmount.Name = "txb_SAmount";
            this.txb_SAmount.Size = new System.Drawing.Size(97, 29);
            this.txb_SAmount.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "金额份数范围：";
            // 
            // txb_NumsTotal
            // 
            this.txb_NumsTotal.Location = new System.Drawing.Point(146, 102);
            this.txb_NumsTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txb_NumsTotal.Name = "txb_NumsTotal";
            this.txb_NumsTotal.Size = new System.Drawing.Size(418, 29);
            this.txb_NumsTotal.TabIndex = 9;
            // 
            // lbl_showMSg
            // 
            this.lbl_showMSg.AutoSize = true;
            this.lbl_showMSg.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_showMSg.ForeColor = System.Drawing.Color.Red;
            this.lbl_showMSg.Location = new System.Drawing.Point(74, 298);
            this.lbl_showMSg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_showMSg.Name = "lbl_showMSg";
            this.lbl_showMSg.Size = new System.Drawing.Size(65, 19);
            this.lbl_showMSg.TabIndex = 6;
            this.lbl_showMSg.Text = "执行提示:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "预申购订单总数：";
            // 
            // cbx_AmountRange
            // 
            this.cbx_AmountRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_AmountRange.FormattingEnabled = true;
            this.cbx_AmountRange.Items.AddRange(new object[] {
            "随机",
            "自定义"});
            this.cbx_AmountRange.Location = new System.Drawing.Point(146, 34);
            this.cbx_AmountRange.Name = "cbx_AmountRange";
            this.cbx_AmountRange.Size = new System.Drawing.Size(165, 29);
            this.cbx_AmountRange.TabIndex = 11;
            // 
            // txb_EAmount
            // 
            this.txb_EAmount.Enabled = false;
            this.txb_EAmount.Location = new System.Drawing.Point(467, 34);
            this.txb_EAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txb_EAmount.Name = "txb_EAmount";
            this.txb_EAmount.Size = new System.Drawing.Size(97, 29);
            this.txb_EAmount.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "至";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 177);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "申购方式选择：";
            // 
            // cbx_Type
            // 
            this.cbx_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Type.FormattingEnabled = true;
            this.cbx_Type.Items.AddRange(new object[] {
            "选中用户随机挑选(每个用户可能会预申购多次)",
            "选中用户每人只能申购一笔订单",
            "选中用户只能申购一笔订单且该用户不在订单表"});
            this.cbx_Type.Location = new System.Drawing.Point(146, 174);
            this.cbx_Type.Name = "cbx_Type";
            this.cbx_Type.Size = new System.Drawing.Size(418, 29);
            this.cbx_Type.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "注:所选下订单的用户必须授权且余额充足";
            // 
            // BatchPurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 330);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbx_Type);
            this.Controls.Add(this.cbx_AmountRange);
            this.Controls.Add(this.btn_purchase);
            this.Controls.Add(this.txb_EAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_SAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_NumsTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_showMSg);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "BatchPurchaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量预申购";
            this.Load += new System.EventHandler(this.BatchPurchaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_purchase;
        private System.Windows.Forms.TextBox txb_SAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_NumsTotal;
        private System.Windows.Forms.Label lbl_showMSg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_AmountRange;
        private System.Windows.Forms.TextBox txb_EAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_Type;
        private System.Windows.Forms.Label label3;
    }
}