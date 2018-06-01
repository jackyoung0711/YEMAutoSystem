namespace JYM.AutoSystem
{
    partial class UserInfoManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfoManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cloum9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsBankAuth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb_data = new System.Windows.Forms.GroupBox();
            this.ck_IsSelectedAll = new System.Windows.Forms.CheckBox();
            this.lbl_showOperate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Select = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_IsRecharge = new System.Windows.Forms.ComboBox();
            this.cbx_IsAuth = new System.Windows.Forms.ComboBox();
            this.cb_SortType = new System.Windows.Forms.ComboBox();
            this.txb_Name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_cellPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_UserIdentifier = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.gb_data.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picShow
            // 
            this.picShow.BackColor = System.Drawing.Color.Transparent;
            this.picShow.Image = ((System.Drawing.Image)(resources.GetObject("picShow.Image")));
            this.picShow.Location = new System.Drawing.Point(572, 184);
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
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column2,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column1,
            this.Column3,
            this.Column5,
            this.cloum9,
            this.Column10,
            this.IsBankAuth});
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
            this.dgv_Data.Size = new System.Drawing.Size(1450, 507);
            this.dgv_Data.TabIndex = 1;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "选项";
            this.Column9.Name = "Column9";
            this.Column9.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UserIdentifier";
            this.Column2.HeaderText = "编号";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "CellPhone";
            this.Column4.HeaderText = "手机号";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Pwd";
            this.Column6.HeaderText = "登录密码";
            this.Column6.Name = "Column6";
            this.Column6.Width = 90;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "RealName";
            this.Column7.HeaderText = "姓名";
            this.Column7.Name = "Column7";
            this.Column7.Width = 70;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CredentialNo";
            this.Column1.HeaderText = "身份证号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "BankCardNo";
            this.Column3.HeaderText = "银行卡号";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CgCellPhone";
            this.Column5.HeaderText = "预留手机号";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // cloum9
            // 
            this.cloum9.DataPropertyName = "RechargeAmount";
            this.cloum9.HeaderText = "充值总金额";
            this.cloum9.Name = "cloum9";
            this.cloum9.Width = 90;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "RigisterTime";
            this.Column10.HeaderText = "注册时间";
            this.Column10.Name = "Column10";
            this.Column10.Width = 150;
            // 
            // IsBankAuth
            // 
            this.IsBankAuth.DataPropertyName = "IsBankAuth";
            this.IsBankAuth.HeaderText = "是否授权";
            this.IsBankAuth.Name = "IsBankAuth";
            this.IsBankAuth.Width = 115;
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
            this.gb_data.Location = new System.Drawing.Point(9, 157);
            this.gb_data.Name = "gb_data";
            this.gb_data.Size = new System.Drawing.Size(1465, 577);
            this.gb_data.TabIndex = 4;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbx_IsRecharge);
            this.groupBox1.Controls.Add(this.cbx_IsAuth);
            this.groupBox1.Controls.Add(this.cb_SortType);
            this.groupBox1.Controls.Add(this.txb_Name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txb_cellPhone);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txb_UserIdentifier);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1465, 126);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件设置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(6, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(540, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "注：能在列表中查看到的用户都已经激活开户，并且所有开户用户交易密码都为111111,未授权的为0";
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(1321, 34);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(118, 26);
            this.btn_Select.TabIndex = 6;
            this.btn_Select.Text = "查询";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(354, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "是否充值：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "是否授权：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(987, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "排序方式：";
            // 
            // cbx_IsRecharge
            // 
            this.cbx_IsRecharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_IsRecharge.FormattingEnabled = true;
            this.cbx_IsRecharge.Items.AddRange(new object[] {
            "所有类别",
            "未充值",
            "已经充值"});
            this.cbx_IsRecharge.Location = new System.Drawing.Point(444, 78);
            this.cbx_IsRecharge.Name = "cbx_IsRecharge";
            this.cbx_IsRecharge.Size = new System.Drawing.Size(213, 28);
            this.cbx_IsRecharge.TabIndex = 4;
            // 
            // cbx_IsAuth
            // 
            this.cbx_IsAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_IsAuth.FormattingEnabled = true;
            this.cbx_IsAuth.Items.AddRange(new object[] {
            "所有类别",
            "未授权",
            "已经授权"});
            this.cbx_IsAuth.Location = new System.Drawing.Point(126, 78);
            this.cbx_IsAuth.Name = "cbx_IsAuth";
            this.cbx_IsAuth.Size = new System.Drawing.Size(213, 28);
            this.cbx_IsAuth.TabIndex = 4;
            // 
            // cb_SortType
            // 
            this.cb_SortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SortType.FormattingEnabled = true;
            this.cb_SortType.Items.AddRange(new object[] {
            "Sort By Id Desc",
            "Sort By Id Asc"});
            this.cb_SortType.Location = new System.Drawing.Point(1077, 34);
            this.cb_SortType.Name = "cb_SortType";
            this.cb_SortType.Size = new System.Drawing.Size(213, 28);
            this.cb_SortType.TabIndex = 4;
            // 
            // txb_Name
            // 
            this.txb_Name.Location = new System.Drawing.Point(744, 35);
            this.txb_Name.Name = "txb_Name";
            this.txb_Name.Size = new System.Drawing.Size(221, 27);
            this.txb_Name.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(684, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "姓名：";
            // 
            // txb_cellPhone
            // 
            this.txb_cellPhone.Location = new System.Drawing.Point(444, 34);
            this.txb_cellPhone.Name = "txb_cellPhone";
            this.txb_cellPhone.Size = new System.Drawing.Size(221, 27);
            this.txb_cellPhone.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "CellPhone：";
            // 
            // txb_UserIdentifier
            // 
            this.txb_UserIdentifier.Location = new System.Drawing.Point(126, 34);
            this.txb_UserIdentifier.Name = "txb_UserIdentifier";
            this.txb_UserIdentifier.Size = new System.Drawing.Size(223, 27);
            this.txb_UserIdentifier.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserIdentifier：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripSeparator4,
            this.toolStripButton5,
            this.toolStripSeparator5,
            this.toolStripButton6,
            this.toolStripSeparator6,
            this.toolStripButton7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1502, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton1.Text = "批量充值";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton3.Text = "批量投资";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton4.Text = "其它";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton5.Text = "批量授权";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(84, 22);
            this.toolStripButton6.Text = "批量申购订单";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(116, 22);
            this.toolStripButton7.Text = "批量赎回(无需选择)";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // UserInfoManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1502, 745);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserInfoManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开户信息管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserInfoManage_FormClosed);
            this.Load += new System.EventHandler(this.UserInfoManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.gb_data.ResumeLayout(false);
            this.gb_data.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.ComboBox cbx_pageSize;
        private System.Windows.Forms.Label lbl_pageinfo2;
        private System.Windows.Forms.Label lbl_pageinfo1;
        private System.Windows.Forms.TextBox txt_pageIndex;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button btn_SearchStatistics;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.Button btn_LastPage;
        private System.Windows.Forms.Button btn_FirstPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.GroupBox gb_data;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_SortType;
        private System.Windows.Forms.TextBox txb_cellPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_UserIdentifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_showOperate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.CheckBox ck_IsSelectedAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cloum9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsBankAuth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.TextBox txb_Name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbx_IsAuth;
        private System.Windows.Forms.ComboBox cbx_IsRecharge;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
    }
}