namespace JYM.AutoSystem
{
    partial class UserTransactionFrom
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btn_Transfer = new System.Windows.Forms.Button();
            this.txb_UserId = new System.Windows.Forms.TextBox();
            this.btn_batchGet = new System.Windows.Forms.Button();
            this.lbl_showMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 111);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(893, 633);
            this.webBrowser1.TabIndex = 0;
            // 
            // btn_Transfer
            // 
            this.btn_Transfer.Location = new System.Drawing.Point(392, 19);
            this.btn_Transfer.Name = "btn_Transfer";
            this.btn_Transfer.Size = new System.Drawing.Size(75, 23);
            this.btn_Transfer.TabIndex = 1;
            this.btn_Transfer.Text = "开始跳转";
            this.btn_Transfer.UseVisualStyleBackColor = true;
            this.btn_Transfer.Click += new System.EventHandler(this.btn_Transfer_Click);
            // 
            // txb_UserId
            // 
            this.txb_UserId.Location = new System.Drawing.Point(27, 21);
            this.txb_UserId.Name = "txb_UserId";
            this.txb_UserId.Size = new System.Drawing.Size(345, 20);
            this.txb_UserId.TabIndex = 2;
            // 
            // btn_batchGet
            // 
            this.btn_batchGet.Location = new System.Drawing.Point(473, 19);
            this.btn_batchGet.Name = "btn_batchGet";
            this.btn_batchGet.Size = new System.Drawing.Size(75, 23);
            this.btn_batchGet.TabIndex = 1;
            this.btn_batchGet.Text = "批量获取";
            this.btn_batchGet.UseVisualStyleBackColor = true;
            this.btn_batchGet.Click += new System.EventHandler(this.btn_batchGet_Click);
            // 
            // lbl_showMsg
            // 
            this.lbl_showMsg.AutoSize = true;
            this.lbl_showMsg.Location = new System.Drawing.Point(27, 69);
            this.lbl_showMsg.Name = "lbl_showMsg";
            this.lbl_showMsg.Size = new System.Drawing.Size(34, 13);
            this.lbl_showMsg.TabIndex = 3;
            this.lbl_showMsg.Text = "提示:";
            // 
            // UserTransactionFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(910, 750);
            this.Controls.Add(this.lbl_showMsg);
            this.Controls.Add(this.txb_UserId);
            this.Controls.Add(this.btn_batchGet);
            this.Controls.Add(this.btn_Transfer);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserTransactionFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserTransactionFrom";
            this.Load += new System.EventHandler(this.UserTransactionFrom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btn_Transfer;
        private System.Windows.Forms.TextBox txb_UserId;
        private System.Windows.Forms.Button btn_batchGet;
        private System.Windows.Forms.Label lbl_showMsg;
    }
}