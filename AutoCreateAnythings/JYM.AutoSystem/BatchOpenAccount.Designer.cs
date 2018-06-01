namespace JYM.AutoSystem
{
    partial class BatchOpenAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.txb_BatchOpenAccounts = new System.Windows.Forms.TextBox();
            this.btn_batchOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "批量开户数量：";
            // 
            // txb_BatchOpenAccounts
            // 
            this.txb_BatchOpenAccounts.Location = new System.Drawing.Point(126, 21);
            this.txb_BatchOpenAccounts.Name = "txb_BatchOpenAccounts";
            this.txb_BatchOpenAccounts.Size = new System.Drawing.Size(232, 23);
            this.txb_BatchOpenAccounts.TabIndex = 1;
            // 
            // btn_batchOpen
            // 
            this.btn_batchOpen.Location = new System.Drawing.Point(380, 21);
            this.btn_batchOpen.Name = "btn_batchOpen";
            this.btn_batchOpen.Size = new System.Drawing.Size(75, 23);
            this.btn_batchOpen.TabIndex = 2;
            this.btn_batchOpen.Text = "批量开户";
            this.btn_batchOpen.UseVisualStyleBackColor = true;
            this.btn_batchOpen.Click += new System.EventHandler(this.btn_batchOpen_Click);
            // 
            // BatchOpenAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(503, 71);
            this.Controls.Add(this.btn_batchOpen);
            this.Controls.Add(this.txb_BatchOpenAccounts);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "BatchOpenAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量开户参数设置";
            this.Load += new System.EventHandler(this.BatchOpenAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_BatchOpenAccounts;
        private System.Windows.Forms.Button btn_batchOpen;
    }
}