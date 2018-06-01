namespace JYM.AutoSystem
{
    partial class BatchRechargeForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webBrowser_batchRecharge = new System.Windows.Forms.WebBrowser();
            this.lbl_showRechrge = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webBrowser_batchRecharge);
            this.groupBox1.Location = new System.Drawing.Point(4, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1147, 795);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "充值界面";
            // 
            // webBrowser_batchRecharge
            // 
            this.webBrowser_batchRecharge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_batchRecharge.Location = new System.Drawing.Point(4, 25);
            this.webBrowser_batchRecharge.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_batchRecharge.Name = "webBrowser_batchRecharge";
            this.webBrowser_batchRecharge.Size = new System.Drawing.Size(1139, 765);
            this.webBrowser_batchRecharge.TabIndex = 0;
            // 
            // lbl_showRechrge
            // 
            this.lbl_showRechrge.AutoSize = true;
            this.lbl_showRechrge.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_showRechrge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_showRechrge.Location = new System.Drawing.Point(13, 13);
            this.lbl_showRechrge.Name = "lbl_showRechrge";
            this.lbl_showRechrge.Size = new System.Drawing.Size(224, 19);
            this.lbl_showRechrge.TabIndex = 1;
            this.lbl_showRechrge.Text = "提示(默认充值金额为88888888)：：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(956, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BatchRechargeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1154, 846);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_showRechrge);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "BatchRechargeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量充值窗口";
            this.Load += new System.EventHandler(this.BatchRechargeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_showRechrge;
        private System.Windows.Forms.WebBrowser webBrowser_batchRecharge;
        private System.Windows.Forms.Button button1;
    }
}