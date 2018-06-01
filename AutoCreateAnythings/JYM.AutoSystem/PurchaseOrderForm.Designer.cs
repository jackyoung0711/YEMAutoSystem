namespace JYM.AutoSystem
{
    partial class PurchaseOrderForm
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
            this.txb_Nums = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_userid = new System.Windows.Forms.TextBox();
            this.btn_purchase = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txb_Nums
            // 
            this.txb_Nums.Location = new System.Drawing.Point(139, 60);
            this.txb_Nums.Margin = new System.Windows.Forms.Padding(4);
            this.txb_Nums.Name = "txb_Nums";
            this.txb_Nums.Size = new System.Drawing.Size(296, 25);
            this.txb_Nums.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "申购份数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "UserIdentifier：";
            // 
            // txb_userid
            // 
            this.txb_userid.Enabled = false;
            this.txb_userid.Location = new System.Drawing.Point(139, 10);
            this.txb_userid.Margin = new System.Windows.Forms.Padding(4);
            this.txb_userid.Name = "txb_userid";
            this.txb_userid.Size = new System.Drawing.Size(296, 25);
            this.txb_userid.TabIndex = 3;
            // 
            // btn_purchase
            // 
            this.btn_purchase.Location = new System.Drawing.Point(467, 27);
            this.btn_purchase.Name = "btn_purchase";
            this.btn_purchase.Size = new System.Drawing.Size(86, 41);
            this.btn_purchase.TabIndex = 4;
            this.btn_purchase.Text = "Purchase";
            this.btn_purchase.UseVisualStyleBackColor = true;
            this.btn_purchase.Click += new System.EventHandler(this.btn_purchase_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(26, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "注：每份金额为100元,最多购买10000份";
            // 
            // PurchaseOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(581, 126);
            this.Controls.Add(this.btn_purchase);
            this.Controls.Add(this.txb_userid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_Nums);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "PurchaseOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "申购订单";
            this.Load += new System.EventHandler(this.PurchaseOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_Nums;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_userid;
        private System.Windows.Forms.Button btn_purchase;
        private System.Windows.Forms.Label label3;
    }
}