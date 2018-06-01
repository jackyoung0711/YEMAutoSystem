namespace JYM.AutoSystem
{
    partial class BatchInvestForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchInvestForm));
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.txb_InvestCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.AllowUserToDeleteRows = false;
            this.dgv_Data.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column3,
            this.Column5,
            this.Column8});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Data.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Data.Location = new System.Drawing.Point(0, 0);
            this.dgv_Data.MultiSelect = false;
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.RowHeadersVisible = false;
            this.dgv_Data.RowTemplate.Height = 23;
            this.dgv_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Data.Size = new System.Drawing.Size(1059, 510);
            this.dgv_Data.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "productCatorgary";
            this.Column1.HeaderText = "产品类别";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ProductId";
            this.Column2.HeaderText = "产品Id";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "FinancingSumAmount";
            this.Column4.HeaderText = "总金额";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "paidAmount";
            this.Column6.HeaderText = "已购买金额";
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "UnitPrise";
            this.Column7.HeaderText = "单价";
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "yield";
            this.Column3.HeaderText = "利率";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "period";
            this.Column5.HeaderText = "周期";
            this.Column5.Name = "Column5";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "leftCount";
            this.Column8.HeaderText = "剩余份额";
            this.Column8.Name = "Column8";
            // 
            // picShow
            // 
            this.picShow.BackColor = System.Drawing.Color.Transparent;
            this.picShow.Image = ((System.Drawing.Image)(resources.GetObject("picShow.Image")));
            this.picShow.Location = new System.Drawing.Point(410, 169);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(193, 197);
            this.picShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picShow.TabIndex = 60;
            this.picShow.TabStop = false;
            // 
            // txb_InvestCount
            // 
            this.txb_InvestCount.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_InvestCount.Location = new System.Drawing.Point(112, 526);
            this.txb_InvestCount.Name = "txb_InvestCount";
            this.txb_InvestCount.Size = new System.Drawing.Size(314, 27);
            this.txb_InvestCount.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 61;
            this.label1.Text = "每人投资粉数：";
            // 
            // BatchInvestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1062, 583);
            this.Controls.Add(this.txb_InvestCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picShow);
            this.Controls.Add(this.dgv_Data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BatchInvestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量投资窗口";
            this.Load += new System.EventHandler(this.BatchInvestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.TextBox txb_InvestCount;
        private System.Windows.Forms.Label label1;
    }
}