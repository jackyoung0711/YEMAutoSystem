namespace JYM.AutoSystem
{
    partial class BatchDebtForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchDebtForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_data = new System.Windows.Forms.GroupBox();
            this.ck_IsSelectedAll = new System.Windows.Forms.CheckBox();
            this.lbl_showOperate = new System.Windows.Forms.Label();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.cbx_pageSize = new System.Windows.Forms.ComboBox();
            this.lbl_pageinfo2 = new System.Windows.Forms.Label();
            this.lbl_pageinfo1 = new System.Windows.Forms.Label();
            this.txt_pageIndex = new System.Windows.Forms.TextBox();
            this.btn_right = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.btn_Go = new System.Windows.Forms.Button();
            this.btn_LastPage = new System.Windows.Forms.Button();
            this.btn_FirstPage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cloum9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyUserId = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyUserAssetRatioId = new System.Windows.Forms.ToolStripMenuItem();
            this.RedeemThisRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.RedeemSelectedRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserAssetRatioId = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.gb_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_data
            // 
            this.gb_data.Controls.Add(this.ck_IsSelectedAll);
            this.gb_data.Controls.Add(this.lbl_showOperate);
            this.gb_data.Controls.Add(this.picShow);
            this.gb_data.Controls.Add(this.cbx_pageSize);
            this.gb_data.Controls.Add(this.lbl_pageinfo2);
            this.gb_data.Controls.Add(this.lbl_pageinfo1);
            this.gb_data.Controls.Add(this.txt_pageIndex);
            this.gb_data.Controls.Add(this.btn_right);
            this.gb_data.Controls.Add(this.btn_left);
            this.gb_data.Controls.Add(this.btn_Go);
            this.gb_data.Controls.Add(this.btn_LastPage);
            this.gb_data.Controls.Add(this.btn_FirstPage);
            this.gb_data.Controls.Add(this.label3);
            this.gb_data.Controls.Add(this.dgv_Data);
            this.gb_data.Location = new System.Drawing.Point(1, 104);
            this.gb_data.Name = "gb_data";
            this.gb_data.Size = new System.Drawing.Size(1339, 585);
            this.gb_data.TabIndex = 5;
            this.gb_data.TabStop = false;
            this.gb_data.Text = "查询结果";
            // 
            // ck_IsSelectedAll
            // 
            this.ck_IsSelectedAll.AutoSize = true;
            this.ck_IsSelectedAll.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_IsSelectedAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ck_IsSelectedAll.Location = new System.Drawing.Point(25, 13);
            this.ck_IsSelectedAll.Name = "ck_IsSelectedAll";
            this.ck_IsSelectedAll.Size = new System.Drawing.Size(132, 23);
            this.ck_IsSelectedAll.TabIndex = 61;
            this.ck_IsSelectedAll.Text = "选中该页所有数据";
            this.ck_IsSelectedAll.UseVisualStyleBackColor = true;
            this.ck_IsSelectedAll.CheckedChanged += new System.EventHandler(this.ck_IsSelectedAll_CheckedChanged);
            // 
            // lbl_showOperate
            // 
            this.lbl_showOperate.AutoSize = true;
            this.lbl_showOperate.Font = new System.Drawing.Font("微软雅黑", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_showOperate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_showOperate.Location = new System.Drawing.Point(870, 554);
            this.lbl_showOperate.Name = "lbl_showOperate";
            this.lbl_showOperate.Size = new System.Drawing.Size(0, 19);
            this.lbl_showOperate.TabIndex = 60;
            // 
            // picShow
            // 
            this.picShow.BackColor = System.Drawing.Color.Transparent;
            this.picShow.Image = ((System.Drawing.Image)(resources.GetObject("picShow.Image")));
            this.picShow.Location = new System.Drawing.Point(502, 171);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(274, 221);
            this.picShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picShow.TabIndex = 59;
            this.picShow.TabStop = false;
            // 
            // cbx_pageSize
            // 
            this.cbx_pageSize.FormattingEnabled = true;
            this.cbx_pageSize.Items.AddRange(new object[] {
            "30",
            "50",
            "100",
            "200",
            "500",
            "1000",
            "5000",
            "10000"});
            this.cbx_pageSize.Location = new System.Drawing.Point(607, 555);
            this.cbx_pageSize.Name = "cbx_pageSize";
            this.cbx_pageSize.Size = new System.Drawing.Size(58, 20);
            this.cbx_pageSize.TabIndex = 56;
            // 
            // lbl_pageinfo2
            // 
            this.lbl_pageinfo2.AutoSize = true;
            this.lbl_pageinfo2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_pageinfo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_pageinfo2.Location = new System.Drawing.Point(671, 555);
            this.lbl_pageinfo2.Name = "lbl_pageinfo2";
            this.lbl_pageinfo2.Size = new System.Drawing.Size(156, 19);
            this.lbl_pageinfo2.TabIndex = 54;
            this.lbl_pageinfo2.Text = "1/25   总共12345条记录";
            // 
            // lbl_pageinfo1
            // 
            this.lbl_pageinfo1.AutoSize = true;
            this.lbl_pageinfo1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_pageinfo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_pageinfo1.Location = new System.Drawing.Point(568, 552);
            this.lbl_pageinfo1.Name = "lbl_pageinfo1";
            this.lbl_pageinfo1.Size = new System.Drawing.Size(35, 19);
            this.lbl_pageinfo1.TabIndex = 55;
            this.lbl_pageinfo1.Text = "每页";
            // 
            // txt_pageIndex
            // 
            this.txt_pageIndex.Location = new System.Drawing.Point(390, 555);
            this.txt_pageIndex.Name = "txt_pageIndex";
            this.txt_pageIndex.Size = new System.Drawing.Size(89, 21);
            this.txt_pageIndex.TabIndex = 53;
            // 
            // btn_right
            // 
            this.btn_right.Location = new System.Drawing.Point(241, 552);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(63, 23);
            this.btn_right.TabIndex = 48;
            this.btn_right.Text = ">|";
            this.btn_right.UseVisualStyleBackColor = true;
            // 
            // btn_left
            // 
            this.btn_left.Location = new System.Drawing.Point(165, 552);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(61, 23);
            this.btn_left.TabIndex = 49;
            this.btn_left.Text = "|<";
            this.btn_left.UseVisualStyleBackColor = true;
            // 
            // btn_Go
            // 
            this.btn_Go.Location = new System.Drawing.Point(485, 552);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(77, 23);
            this.btn_Go.TabIndex = 50;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            // 
            // btn_LastPage
            // 
            this.btn_LastPage.Location = new System.Drawing.Point(310, 552);
            this.btn_LastPage.Name = "btn_LastPage";
            this.btn_LastPage.Size = new System.Drawing.Size(70, 23);
            this.btn_LastPage.TabIndex = 51;
            this.btn_LastPage.Text = "末页";
            this.btn_LastPage.UseVisualStyleBackColor = true;
            // 
            // btn_FirstPage
            // 
            this.btn_FirstPage.Location = new System.Drawing.Point(92, 552);
            this.btn_FirstPage.Name = "btn_FirstPage";
            this.btn_FirstPage.Size = new System.Drawing.Size(67, 23);
            this.btn_FirstPage.TabIndex = 52;
            this.btn_FirstPage.Text = "首页";
            this.btn_FirstPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 558);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "翻页浏览:";
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.AllowUserToDeleteRows = false;
            this.dgv_Data.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column2,
            this.Column4,
            this.AssetType,
            this.Column6,
            this.Column7,
            this.Column1,
            this.Column3,
            this.Column5,
            this.cloum9});
            this.dgv_Data.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Data.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Data.Location = new System.Drawing.Point(9, 40);
            this.dgv_Data.MultiSelect = false;
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.RowHeadersVisible = false;
            this.dgv_Data.RowTemplate.Height = 23;
            this.dgv_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Data.Size = new System.Drawing.Size(1318, 507);
            this.dgv_Data.TabIndex = 1;
            this.dgv_Data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Data_CellContentClick);
            // 
            // Column9
            // 
            this.Column9.Frozen = true;
            this.Column9.HeaderText = "选项";
            this.Column9.Name = "Column9";
            this.Column9.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UserId";
            this.Column2.HeaderText = "UserId";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "UserAssetRatioId";
            this.Column4.HeaderText = "UserAssetRatioId";
            this.Column4.Name = "Column4";
            this.Column4.Width = 170;
            // 
            // AssetType
            // 
            this.AssetType.DataPropertyName = "AssetType";
            this.AssetType.HeaderText = "AssetType";
            this.AssetType.Name = "AssetType";
            this.AssetType.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "OriginalUserAssetRatioId";
            this.Column6.HeaderText = "OriginalUserAssetRatioId";
            this.Column6.Name = "Column6";
            this.Column6.Width = 170;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "AssetId";
            this.Column7.HeaderText = "AssetId";
            this.Column7.Name = "Column7";
            this.Column7.Width = 170;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Principal";
            this.Column1.HeaderText = "Principal";
            this.Column1.Name = "Column1";
            this.Column1.Width = 90;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "PrincipalInterest";
            this.Column3.HeaderText = "PrincipalInterest";
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "OrderId";
            this.Column5.HeaderText = "OrderId";
            this.Column5.Name = "Column5";
            this.Column5.Width = 170;
            // 
            // cloum9
            // 
            this.cloum9.DataPropertyName = "ChildOrderId";
            this.cloum9.HeaderText = "ChildOrderId";
            this.cloum9.Name = "cloum9";
            this.cloum9.Width = 170;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyUserId,
            this.CopyUserAssetRatioId,
            this.RedeemThisRecord,
            this.RedeemSelectedRecord});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(237, 92);
            // 
            // CopyUserId
            // 
            this.CopyUserId.Name = "CopyUserId";
            this.CopyUserId.Size = new System.Drawing.Size(236, 22);
            this.CopyUserId.Text = "复制当前行UserId";
            this.CopyUserId.Click += new System.EventHandler(this.CopyUserId_Click);
            // 
            // CopyUserAssetRatioId
            // 
            this.CopyUserAssetRatioId.Name = "CopyUserAssetRatioId";
            this.CopyUserAssetRatioId.Size = new System.Drawing.Size(236, 22);
            this.CopyUserAssetRatioId.Text = "复制当前行UserAssetRatioId";
            this.CopyUserAssetRatioId.Click += new System.EventHandler(this.CopyUserAssetRatioId_Click);
            // 
            // RedeemThisRecord
            // 
            this.RedeemThisRecord.Name = "RedeemThisRecord";
            this.RedeemThisRecord.Size = new System.Drawing.Size(236, 22);
            this.RedeemThisRecord.Text = "赎回该条记录";
            this.RedeemThisRecord.Click += new System.EventHandler(this.RedeemThisRecord_Click);
            // 
            // RedeemSelectedRecord
            // 
            this.RedeemSelectedRecord.Name = "RedeemSelectedRecord";
            this.RedeemSelectedRecord.Size = new System.Drawing.Size(236, 22);
            this.RedeemSelectedRecord.Text = "赎回选择的记录";
            this.RedeemSelectedRecord.Click += new System.EventHandler(this.RedeemSelectedRecord_Click);
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(74, 55);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(267, 21);
            this.txtUserId.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "UserId:";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(1253, 75);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "UserAssetRatioId:";
            // 
            // txtUserAssetRatioId
            // 
            this.txtUserAssetRatioId.Location = new System.Drawing.Point(488, 55);
            this.txtUserAssetRatioId.Name = "txtUserAssetRatioId";
            this.txtUserAssetRatioId.Size = new System.Drawing.Size(267, 21);
            this.txtUserAssetRatioId.TabIndex = 10;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(764, 58);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 12);
            this.lblType.TabIndex = 12;
            this.lblType.Text = "类型:";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "子订单",
            "债权"});
            this.cbType.Location = new System.Drawing.Point(806, 55);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 20);
            this.cbType.TabIndex = 13;
            // 
            // BatchDebtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1352, 701);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserAssetRatioId);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.gb_data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BatchDebtForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量赎回";
            this.Load += new System.EventHandler(this.BatchDebtForm_Load);
            this.gb_data.ResumeLayout(false);
            this.gb_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_data;
        private System.Windows.Forms.CheckBox ck_IsSelectedAll;
        private System.Windows.Forms.Label lbl_showOperate;
        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.ComboBox cbx_pageSize;
        private System.Windows.Forms.Label lbl_pageinfo2;
        private System.Windows.Forms.Label lbl_pageinfo1;
        private System.Windows.Forms.TextBox txt_pageIndex;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.Button btn_LastPage;
        private System.Windows.Forms.Button btn_FirstPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CopyUserId;
        private System.Windows.Forms.ToolStripMenuItem CopyUserAssetRatioId;
        private System.Windows.Forms.ToolStripMenuItem RedeemThisRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserAssetRatioId;
        private System.Windows.Forms.ToolStripMenuItem RedeemSelectedRecord;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cloum9;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cbType;
    }
}