namespace JYM.AutoSystem
{
    partial class UserBankAuthForm
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
            this.webBrowser_batchAuth = new System.Windows.Forms.WebBrowser();
            this.lbl_showRechrge = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webBrowser_batchAuth
            // 
            this.webBrowser_batchAuth.Location = new System.Drawing.Point(8, 61);
            this.webBrowser_batchAuth.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_batchAuth.Name = "webBrowser_batchAuth";
            this.webBrowser_batchAuth.Size = new System.Drawing.Size(1238, 712);
            this.webBrowser_batchAuth.TabIndex = 1;
            // 
            // lbl_showRechrge
            // 
            this.lbl_showRechrge.AutoSize = true;
            this.lbl_showRechrge.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_showRechrge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_showRechrge.Location = new System.Drawing.Point(12, 21);
            this.lbl_showRechrge.Name = "lbl_showRechrge";
            this.lbl_showRechrge.Size = new System.Drawing.Size(90, 19);
            this.lbl_showRechrge.TabIndex = 2;
            this.lbl_showRechrge.Text = "用户授权提示:";
            // 
            // UserBankAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1258, 785);
            this.Controls.Add(this.lbl_showRechrge);
            this.Controls.Add(this.webBrowser_batchAuth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserBankAuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserBankAuthForm";
            this.Load += new System.EventHandler(this.UserBankAuthForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser_batchAuth;
        private System.Windows.Forms.Label lbl_showRechrge;
    }
}