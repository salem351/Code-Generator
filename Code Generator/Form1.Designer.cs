namespace Code_Generator
{
    partial class frmCodeGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodeGenerator));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTableSingleName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbAddColumn = new System.Windows.Forms.GroupBox();
            this.chkPK = new System.Windows.Forms.CheckBox();
            this.chkNull = new System.Windows.Forms.CheckBox();
            this.btnAddColumn = new System.Windows.Forms.Button();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvTableInfo = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmsCodeGnerator = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDeletePatient = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbCodeAsOutput = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBusinessLayer = new System.Windows.Forms.Button();
            this.tbnDataAccessLayer = new System.Windows.Forms.Button();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDataAcsessLayerName = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBusinessLayerName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbAddColumn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableInfo)).BeginInit();
            this.cmsCodeGnerator.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 120);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(0, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1280, 60);
            this.label1.TabIndex = 77;
            this.label1.Text = "Generate Business and Data Access Layers";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1280, 60);
            this.lblTitle.TabIndex = 76;
            this.lblTitle.Text = " 🧩 Code Generator ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(12, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 39);
            this.label2.TabIndex = 77;
            this.label2.Text = "📦 Table Info:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(59, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 29);
            this.label3.TabIndex = 78;
            this.label3.Text = "Table Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(318, 222);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(146, 20);
            this.txtTableName.TabIndex = 1;
            this.txtTableName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTableName_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(466, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 29);
            this.label4.TabIndex = 80;
            this.label4.Text = "e.g. Contacts, People";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(464, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 29);
            this.label5.TabIndex = 83;
            this.label5.Text = "e.g. Contact, Person";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTableSingleName
            // 
            this.txtTableSingleName.Location = new System.Drawing.Point(318, 254);
            this.txtTableSingleName.Name = "txtTableSingleName";
            this.txtTableSingleName.Size = new System.Drawing.Size(146, 20);
            this.txtTableSingleName.TabIndex = 2;
            this.txtTableSingleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTableSingleName_KeyDown);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(71, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 29);
            this.label6.TabIndex = 81;
            this.label6.Text = "Table Single Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbAddColumn
            // 
            this.gbAddColumn.Controls.Add(this.chkPK);
            this.gbAddColumn.Controls.Add(this.chkNull);
            this.gbAddColumn.Controls.Add(this.btnAddColumn);
            this.gbAddColumn.Controls.Add(this.cmbDataType);
            this.gbAddColumn.Controls.Add(this.label8);
            this.gbAddColumn.Controls.Add(this.txtColumnName);
            this.gbAddColumn.Controls.Add(this.label7);
            this.gbAddColumn.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAddColumn.ForeColor = System.Drawing.Color.DimGray;
            this.gbAddColumn.Location = new System.Drawing.Point(9, 367);
            this.gbAddColumn.Name = "gbAddColumn";
            this.gbAddColumn.Size = new System.Drawing.Size(339, 366);
            this.gbAddColumn.TabIndex = 84;
            this.gbAddColumn.TabStop = false;
            this.gbAddColumn.Text = "➕ Add Column";
            // 
            // chkPK
            // 
            this.chkPK.AutoSize = true;
            this.chkPK.Location = new System.Drawing.Point(129, 191);
            this.chkPK.Name = "chkPK";
            this.chkPK.Size = new System.Drawing.Size(65, 33);
            this.chkPK.TabIndex = 98;
            this.chkPK.Text = "PK";
            this.chkPK.UseVisualStyleBackColor = true;
            // 
            // chkNull
            // 
            this.chkNull.AutoSize = true;
            this.chkNull.Location = new System.Drawing.Point(11, 191);
            this.chkNull.Name = "chkNull";
            this.chkNull.Size = new System.Drawing.Size(80, 33);
            this.chkNull.TabIndex = 97;
            this.chkNull.Text = "Null";
            this.chkNull.UseVisualStyleBackColor = true;
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddColumn.Location = new System.Drawing.Point(76, 266);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.Size = new System.Drawing.Size(176, 45);
            this.btnAddColumn.TabIndex = 93;
            this.btnAddColumn.Text = "➕ Add";
            this.btnAddColumn.UseVisualStyleBackColor = true;
            this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
            // 
            // cmbDataType
            // 
            this.cmbDataType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(129, 114);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(204, 27);
            this.cmbDataType.TabIndex = 89;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(6, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 29);
            this.label8.TabIndex = 88;
            this.label8.Text = "Data Type";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtColumnName
            // 
            this.txtColumnName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnName.Location = new System.Drawing.Point(129, 56);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(204, 27);
            this.txtColumnName.TabIndex = 87;
            this.txtColumnName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtColumnName_KeyDown);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(3, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 29);
            this.label7.TabIndex = 86;
            this.label7.Text = "Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTableInfo
            // 
            this.dgvTableInfo.AllowUserToAddRows = false;
            this.dgvTableInfo.AllowUserToDeleteRows = false;
            this.dgvTableInfo.AllowUserToOrderColumns = true;
            this.dgvTableInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvTableInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colType,
            this.colIsNull,
            this.colPK});
            this.dgvTableInfo.ContextMenuStrip = this.cmsCodeGnerator;
            this.dgvTableInfo.Location = new System.Drawing.Point(354, 374);
            this.dgvTableInfo.Name = "dgvTableInfo";
            this.dgvTableInfo.ReadOnly = true;
            this.dgvTableInfo.Size = new System.Drawing.Size(544, 359);
            this.dgvTableInfo.TabIndex = 85;
            // 
            // colName
            // 
            this.colName.HeaderText = "Column Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colType
            // 
            this.colType.HeaderText = "Data Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 150;
            // 
            // colIsNull
            // 
            this.colIsNull.HeaderText = "Allow Null";
            this.colIsNull.Name = "colIsNull";
            this.colIsNull.ReadOnly = true;
            // 
            // colPK
            // 
            this.colPK.HeaderText = "PK";
            this.colPK.Name = "colPK";
            this.colPK.ReadOnly = true;
            // 
            // cmsCodeGnerator
            // 
            this.cmsCodeGnerator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cmsCodeGnerator.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsCodeGnerator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDeletePatient});
            this.cmsCodeGnerator.Name = "contextMenuStrip1";
            this.cmsCodeGnerator.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsCodeGnerator.Size = new System.Drawing.Size(151, 30);
            // 
            // tsmDeletePatient
            // 
            this.tsmDeletePatient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmDeletePatient.Name = "tsmDeletePatient";
            this.tsmDeletePatient.Size = new System.Drawing.Size(150, 26);
            this.tsmDeletePatient.Text = "🗑️ Delete";
            this.tsmDeletePatient.Click += new System.EventHandler(this.tsmDeletePatient_Click);
            // 
            // rtbCodeAsOutput
            // 
            this.rtbCodeAsOutput.Location = new System.Drawing.Point(939, 165);
            this.rtbCodeAsOutput.Name = "rtbCodeAsOutput";
            this.rtbCodeAsOutput.Size = new System.Drawing.Size(317, 473);
            this.rtbCodeAsOutput.TabIndex = 86;
            this.rtbCodeAsOutput.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1174, 745);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 32);
            this.btnClose.TabIndex = 95;
            this.btnClose.Text = "✖ Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateCode.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateCode.ForeColor = System.Drawing.Color.DimGray;
            this.btnGenerateCode.Location = new System.Drawing.Point(968, 644);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(255, 45);
            this.btnGenerateCode.TabIndex = 96;
            this.btnGenerateCode.Text = "[ Generate Code ] 🚀 ";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(554, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(384, 39);
            this.label9.TabIndex = 97;
            this.label9.Text = "📄 Generated Code Output:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBusinessLayer
            // 
            this.btnBusinessLayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBusinessLayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBusinessLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusinessLayer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusinessLayer.ForeColor = System.Drawing.Color.DimGray;
            this.btnBusinessLayer.Location = new System.Drawing.Point(939, 130);
            this.btnBusinessLayer.Name = "btnBusinessLayer";
            this.btnBusinessLayer.Size = new System.Drawing.Size(157, 32);
            this.btnBusinessLayer.TabIndex = 98;
            this.btnBusinessLayer.Text = "Business Layer";
            this.btnBusinessLayer.UseVisualStyleBackColor = true;
            this.btnBusinessLayer.Click += new System.EventHandler(this.btnBusinessLayer_Click);
            // 
            // tbnDataAccessLayer
            // 
            this.tbnDataAccessLayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tbnDataAccessLayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbnDataAccessLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbnDataAccessLayer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnDataAccessLayer.ForeColor = System.Drawing.Color.DimGray;
            this.tbnDataAccessLayer.Location = new System.Drawing.Point(1099, 130);
            this.tbnDataAccessLayer.Name = "tbnDataAccessLayer";
            this.tbnDataAccessLayer.Size = new System.Drawing.Size(157, 32);
            this.tbnDataAccessLayer.TabIndex = 99;
            this.tbnDataAccessLayer.Text = "Data Access Layer";
            this.tbnDataAccessLayer.UseVisualStyleBackColor = true;
            this.tbnDataAccessLayer.Click += new System.EventHandler(this.tbnDataAccessLayer_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(458, 739);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(16, 23);
            this.lblRecordsCount.TabIndex = 101;
            this.lblRecordsCount.Text = ".";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(349, 739);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 25);
            this.label10.TabIndex = 100;
            this.label10.Text = "Records  : ";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(464, 319);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 29);
            this.label11.TabIndex = 107;
            this.label11.Text = "e.g. CMS_DataAccess";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDataAcsessLayerName
            // 
            this.txtDataAcsessLayerName.Location = new System.Drawing.Point(318, 323);
            this.txtDataAcsessLayerName.Name = "txtDataAcsessLayerName";
            this.txtDataAcsessLayerName.Size = new System.Drawing.Size(146, 20);
            this.txtDataAcsessLayerName.TabIndex = 4;
            this.txtDataAcsessLayerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDataAccessLayerName_KeyDown);
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.DimGray;
            this.lbl.Location = new System.Drawing.Point(68, 319);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(256, 29);
            this.lbl.TabIndex = 105;
            this.lbl.Text = "Data Acsess Layer Name";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(466, 285);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 29);
            this.label13.TabIndex = 104;
            this.label13.Text = "e.g. CMS_Business";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBusinessLayerName
            // 
            this.txtBusinessLayerName.Location = new System.Drawing.Point(318, 291);
            this.txtBusinessLayerName.Name = "txtBusinessLayerName";
            this.txtBusinessLayerName.Size = new System.Drawing.Size(146, 20);
            this.txtBusinessLayerName.TabIndex = 3;
            this.txtBusinessLayerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusinessLayerName_KeyDown);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(69, 285);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(222, 29);
            this.label14.TabIndex = 102;
            this.label14.Text = "Business Layer Name";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCopy
            // 
            this.btnCopy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCopy.BackgroundImage")));
            this.btnCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.Location = new System.Drawing.Point(1229, 640);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(27, 24);
            this.btnCopy.TabIndex = 108;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // frmCodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1280, 789);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDataAcsessLayerName);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtBusinessLayerName);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbnDataAccessLayer);
            this.Controls.Add(this.btnBusinessLayer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnGenerateCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rtbCodeAsOutput);
            this.Controls.Add(this.dgvTableInfo);
            this.Controls.Add(this.gbAddColumn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTableSingleName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCodeGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Generator";
            this.Load += new System.EventHandler(this.frmCodeGenerator_Load);
            this.panel1.ResumeLayout(false);
            this.gbAddColumn.ResumeLayout(false);
            this.gbAddColumn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableInfo)).EndInit();
            this.cmsCodeGnerator.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTableSingleName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbAddColumn;
        private System.Windows.Forms.DataGridView dgvTableInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddColumn;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.RichTextBox rtbCodeAsOutput;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBusinessLayer;
        private System.Windows.Forms.Button tbnDataAccessLayer;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkPK;
        private System.Windows.Forms.CheckBox chkNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsNull;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPK;
        private System.Windows.Forms.ContextMenuStrip cmsCodeGnerator;
        private System.Windows.Forms.ToolStripMenuItem tsmDeletePatient;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDataAcsessLayerName;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBusinessLayerName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCopy;
    }
}

