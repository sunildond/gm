namespace GlanMark
{
    partial class frmInvoiceDetailWithoutProduct
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
            this.dgvQueryExec = new System.Windows.Forms.DataGridView();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.lblReportName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpToAuthDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromAuthDate = new System.Windows.Forms.DateTimePicker();
            this.chkSTNINVAuthDate = new System.Windows.Forms.CheckBox();
            this.chkPartyName = new System.Windows.Forms.CheckBox();
            this.listPartyName = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpSTNToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpSTNFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkSTNDate = new System.Windows.Forms.CheckBox();
            this.listSTNNo = new System.Windows.Forms.ListBox();
            this.chkSTNNo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpToInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.chkInvoiceDate = new System.Windows.Forms.CheckBox();
            this.listPartyCode = new System.Windows.Forms.ListBox();
            this.cmdLocationCode = new System.Windows.Forms.ComboBox();
            this.chkLocation = new System.Windows.Forms.CheckBox();
            this.listIOMNO = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToIOMDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromIOMDate = new System.Windows.Forms.DateTimePicker();
            this.chkIOMDate = new System.Windows.Forms.CheckBox();
            this.chkPartyCode = new System.Windows.Forms.CheckBox();
            this.chkIomNo = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpToSTNAuthDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromSTNAuthDate = new System.Windows.Forms.DateTimePicker();
            this.chkSTNAuthDate = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpToINVAuthDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromINVAuthDate = new System.Windows.Forms.DateTimePicker();
            this.chkINVAuthDate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQueryExec
            // 
            this.dgvQueryExec.AllowUserToAddRows = false;
            this.dgvQueryExec.AllowUserToDeleteRows = false;
            this.dgvQueryExec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryExec.Location = new System.Drawing.Point(12, 246);
            this.dgvQueryExec.Name = "dgvQueryExec";
            this.dgvQueryExec.ReadOnly = true;
            this.dgvQueryExec.Size = new System.Drawing.Size(1160, 270);
            this.dgvQueryExec.TabIndex = 9;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Location = new System.Drawing.Point(1048, 522);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(124, 27);
            this.btnExportToExcel.TabIndex = 56;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(747, 536);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 57;
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(960, 187);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(118, 27);
            this.btnFilter.TabIndex = 58;
            this.btnFilter.Text = "Submit";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(12, 524);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(145, 27);
            this.btnReset.TabIndex = 59;
            this.btnReset.Text = "ExecuteQuery / Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 12);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(68, 220);
            this.txtQuery.TabIndex = 60;
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(186, 532);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(0, 13);
            this.lblReportName.TabIndex = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dtpToINVAuthDate);
            this.groupBox1.Controls.Add(this.dtpFromINVAuthDate);
            this.groupBox1.Controls.Add(this.chkINVAuthDate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtpToSTNAuthDate);
            this.groupBox1.Controls.Add(this.dtpFromSTNAuthDate);
            this.groupBox1.Controls.Add(this.chkSTNAuthDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpToAuthDate);
            this.groupBox1.Controls.Add(this.dtpFromAuthDate);
            this.groupBox1.Controls.Add(this.chkSTNINVAuthDate);
            this.groupBox1.Controls.Add(this.chkPartyName);
            this.groupBox1.Controls.Add(this.listPartyName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpSTNToDate);
            this.groupBox1.Controls.Add(this.dtpSTNFromDate);
            this.groupBox1.Controls.Add(this.chkSTNDate);
            this.groupBox1.Controls.Add(this.listSTNNo);
            this.groupBox1.Controls.Add(this.chkSTNNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpToInvoiceDate);
            this.groupBox1.Controls.Add(this.dtpFromInvoiceDate);
            this.groupBox1.Controls.Add(this.chkInvoiceDate);
            this.groupBox1.Controls.Add(this.listPartyCode);
            this.groupBox1.Controls.Add(this.cmdLocationCode);
            this.groupBox1.Controls.Add(this.chkLocation);
            this.groupBox1.Controls.Add(this.listIOMNO);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpToIOMDate);
            this.groupBox1.Controls.Add(this.dtpFromIOMDate);
            this.groupBox1.Controls.Add(this.chkIOMDate);
            this.groupBox1.Controls.Add(this.chkPartyCode);
            this.groupBox1.Controls.Add(this.chkIomNo);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Location = new System.Drawing.Point(86, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1086, 220);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Detail Without Product";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(932, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 90;
            this.label7.Text = "To";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(924, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 88;
            this.label8.Text = "From";
            // 
            // dtpToAuthDate
            // 
            this.dtpToAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToAuthDate.Location = new System.Drawing.Point(959, 70);
            this.dtpToAuthDate.Name = "dtpToAuthDate";
            this.dtpToAuthDate.ShowCheckBox = true;
            this.dtpToAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToAuthDate.TabIndex = 89;
            // 
            // dtpFromAuthDate
            // 
            this.dtpFromAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromAuthDate.Location = new System.Drawing.Point(959, 43);
            this.dtpFromAuthDate.Name = "dtpFromAuthDate";
            this.dtpFromAuthDate.ShowCheckBox = true;
            this.dtpFromAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromAuthDate.TabIndex = 87;
            // 
            // chkSTNINVAuthDate
            // 
            this.chkSTNINVAuthDate.AutoSize = true;
            this.chkSTNINVAuthDate.Location = new System.Drawing.Point(938, 19);
            this.chkSTNINVAuthDate.Name = "chkSTNINVAuthDate";
            this.chkSTNINVAuthDate.Size = new System.Drawing.Size(122, 17);
            this.chkSTNINVAuthDate.TabIndex = 86;
            this.chkSTNINVAuthDate.Text = "STN/INV Auth Date";
            this.chkSTNINVAuthDate.UseVisualStyleBackColor = true;
            // 
            // chkPartyName
            // 
            this.chkPartyName.AutoSize = true;
            this.chkPartyName.Location = new System.Drawing.Point(359, 22);
            this.chkPartyName.Name = "chkPartyName";
            this.chkPartyName.Size = new System.Drawing.Size(81, 17);
            this.chkPartyName.TabIndex = 85;
            this.chkPartyName.Text = "Party Name";
            this.chkPartyName.UseVisualStyleBackColor = true;
            // 
            // listPartyName
            // 
            this.listPartyName.FormattingEnabled = true;
            this.listPartyName.Location = new System.Drawing.Point(352, 45);
            this.listPartyName.Name = "listPartyName";
            this.listPartyName.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPartyName.Size = new System.Drawing.Size(181, 160);
            this.listPartyName.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(713, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 83;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(705, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "From";
            // 
            // dtpSTNToDate
            // 
            this.dtpSTNToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpSTNToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSTNToDate.Location = new System.Drawing.Point(740, 120);
            this.dtpSTNToDate.Name = "dtpSTNToDate";
            this.dtpSTNToDate.ShowCheckBox = true;
            this.dtpSTNToDate.Size = new System.Drawing.Size(98, 20);
            this.dtpSTNToDate.TabIndex = 82;
            // 
            // dtpSTNFromDate
            // 
            this.dtpSTNFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpSTNFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSTNFromDate.Location = new System.Drawing.Point(740, 93);
            this.dtpSTNFromDate.Name = "dtpSTNFromDate";
            this.dtpSTNFromDate.ShowCheckBox = true;
            this.dtpSTNFromDate.Size = new System.Drawing.Size(98, 20);
            this.dtpSTNFromDate.TabIndex = 80;
            // 
            // chkSTNDate
            // 
            this.chkSTNDate.AutoSize = true;
            this.chkSTNDate.Location = new System.Drawing.Point(709, 69);
            this.chkSTNDate.Name = "chkSTNDate";
            this.chkSTNDate.Size = new System.Drawing.Size(74, 17);
            this.chkSTNDate.TabIndex = 79;
            this.chkSTNDate.Text = "STN Date";
            this.chkSTNDate.UseVisualStyleBackColor = true;
            // 
            // listSTNNo
            // 
            this.listSTNNo.FormattingEnabled = true;
            this.listSTNNo.Location = new System.Drawing.Point(236, 44);
            this.listSTNNo.Name = "listSTNNo";
            this.listSTNNo.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listSTNNo.Size = new System.Drawing.Size(104, 160);
            this.listSTNNo.TabIndex = 78;
            // 
            // chkSTNNo
            // 
            this.chkSTNNo.AutoSize = true;
            this.chkSTNNo.Location = new System.Drawing.Point(243, 19);
            this.chkSTNNo.Name = "chkSTNNo";
            this.chkSTNNo.Size = new System.Drawing.Size(65, 17);
            this.chkSTNNo.TabIndex = 77;
            this.chkSTNNo.Text = "STN No";
            this.chkSTNNo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(564, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(556, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "From";
            // 
            // dtpToInvoiceDate
            // 
            this.dtpToInvoiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToInvoiceDate.Location = new System.Drawing.Point(591, 176);
            this.dtpToInvoiceDate.Name = "dtpToInvoiceDate";
            this.dtpToInvoiceDate.ShowCheckBox = true;
            this.dtpToInvoiceDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToInvoiceDate.TabIndex = 75;
            // 
            // dtpFromInvoiceDate
            // 
            this.dtpFromInvoiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromInvoiceDate.Location = new System.Drawing.Point(591, 149);
            this.dtpFromInvoiceDate.Name = "dtpFromInvoiceDate";
            this.dtpFromInvoiceDate.ShowCheckBox = true;
            this.dtpFromInvoiceDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromInvoiceDate.TabIndex = 73;
            // 
            // chkInvoiceDate
            // 
            this.chkInvoiceDate.AutoSize = true;
            this.chkInvoiceDate.Location = new System.Drawing.Point(560, 125);
            this.chkInvoiceDate.Name = "chkInvoiceDate";
            this.chkInvoiceDate.Size = new System.Drawing.Size(87, 17);
            this.chkInvoiceDate.TabIndex = 72;
            this.chkInvoiceDate.Text = "Invoice Date";
            this.chkInvoiceDate.UseVisualStyleBackColor = true;
            // 
            // listPartyCode
            // 
            this.listPartyCode.FormattingEnabled = true;
            this.listPartyCode.Location = new System.Drawing.Point(126, 46);
            this.listPartyCode.Name = "listPartyCode";
            this.listPartyCode.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPartyCode.Size = new System.Drawing.Size(99, 160);
            this.listPartyCode.TabIndex = 71;
            // 
            // cmdLocationCode
            // 
            this.cmdLocationCode.FormattingEnabled = true;
            this.cmdLocationCode.Location = new System.Drawing.Point(709, 39);
            this.cmdLocationCode.Name = "cmdLocationCode";
            this.cmdLocationCode.Size = new System.Drawing.Size(181, 21);
            this.cmdLocationCode.TabIndex = 70;
            // 
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.Location = new System.Drawing.Point(709, 16);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(92, 17);
            this.chkLocation.TabIndex = 69;
            this.chkLocation.Text = "LocationCode";
            this.chkLocation.UseVisualStyleBackColor = true;
            // 
            // listIOMNO
            // 
            this.listIOMNO.FormattingEnabled = true;
            this.listIOMNO.Location = new System.Drawing.Point(11, 45);
            this.listIOMNO.Name = "listIOMNO";
            this.listIOMNO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listIOMNO.Size = new System.Drawing.Size(104, 160);
            this.listIOMNO.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(564, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "From";
            // 
            // dtpToIOMDate
            // 
            this.dtpToIOMDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToIOMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToIOMDate.Location = new System.Drawing.Point(591, 73);
            this.dtpToIOMDate.Name = "dtpToIOMDate";
            this.dtpToIOMDate.ShowCheckBox = true;
            this.dtpToIOMDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToIOMDate.TabIndex = 66;
            // 
            // dtpFromIOMDate
            // 
            this.dtpFromIOMDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromIOMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromIOMDate.Location = new System.Drawing.Point(591, 46);
            this.dtpFromIOMDate.Name = "dtpFromIOMDate";
            this.dtpFromIOMDate.ShowCheckBox = true;
            this.dtpFromIOMDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromIOMDate.TabIndex = 64;
            // 
            // chkIOMDate
            // 
            this.chkIOMDate.AutoSize = true;
            this.chkIOMDate.Location = new System.Drawing.Point(560, 22);
            this.chkIOMDate.Name = "chkIOMDate";
            this.chkIOMDate.Size = new System.Drawing.Size(72, 17);
            this.chkIOMDate.TabIndex = 62;
            this.chkIOMDate.Text = "IOM Date";
            this.chkIOMDate.UseVisualStyleBackColor = true;
            // 
            // chkPartyCode
            // 
            this.chkPartyCode.AutoSize = true;
            this.chkPartyCode.Location = new System.Drawing.Point(133, 21);
            this.chkPartyCode.Name = "chkPartyCode";
            this.chkPartyCode.Size = new System.Drawing.Size(78, 17);
            this.chkPartyCode.TabIndex = 60;
            this.chkPartyCode.Text = "Party Code";
            this.chkPartyCode.UseVisualStyleBackColor = true;
            // 
            // chkIomNo
            // 
            this.chkIomNo.AutoSize = true;
            this.chkIomNo.Location = new System.Drawing.Point(12, 22);
            this.chkIomNo.Name = "chkIomNo";
            this.chkIomNo.Size = new System.Drawing.Size(65, 17);
            this.chkIomNo.TabIndex = 59;
            this.chkIomNo.Text = "IOM NO";
            this.chkIomNo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(935, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 95;
            this.label9.Text = "To";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(927, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 93;
            this.label10.Text = "From";
            // 
            // dtpToSTNAuthDate
            // 
            this.dtpToSTNAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToSTNAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToSTNAuthDate.Location = new System.Drawing.Point(962, 152);
            this.dtpToSTNAuthDate.Name = "dtpToSTNAuthDate";
            this.dtpToSTNAuthDate.ShowCheckBox = true;
            this.dtpToSTNAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToSTNAuthDate.TabIndex = 94;
            // 
            // dtpFromSTNAuthDate
            // 
            this.dtpFromSTNAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromSTNAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromSTNAuthDate.Location = new System.Drawing.Point(962, 125);
            this.dtpFromSTNAuthDate.Name = "dtpFromSTNAuthDate";
            this.dtpFromSTNAuthDate.ShowCheckBox = true;
            this.dtpFromSTNAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromSTNAuthDate.TabIndex = 92;
            // 
            // chkSTNAuthDate
            // 
            this.chkSTNAuthDate.AutoSize = true;
            this.chkSTNAuthDate.Location = new System.Drawing.Point(942, 101);
            this.chkSTNAuthDate.Name = "chkSTNAuthDate";
            this.chkSTNAuthDate.Size = new System.Drawing.Size(99, 17);
            this.chkSTNAuthDate.TabIndex = 91;
            this.chkSTNAuthDate.Text = "STN Auth Date";
            this.chkSTNAuthDate.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(805, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 100;
            this.label11.Text = "To";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(797, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 98;
            this.label12.Text = "From";
            // 
            // dtpToINVAuthDate
            // 
            this.dtpToINVAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToINVAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToINVAuthDate.Location = new System.Drawing.Point(832, 197);
            this.dtpToINVAuthDate.Name = "dtpToINVAuthDate";
            this.dtpToINVAuthDate.ShowCheckBox = true;
            this.dtpToINVAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToINVAuthDate.TabIndex = 99;
            // 
            // dtpFromINVAuthDate
            // 
            this.dtpFromINVAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromINVAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromINVAuthDate.Location = new System.Drawing.Point(832, 170);
            this.dtpFromINVAuthDate.Name = "dtpFromINVAuthDate";
            this.dtpFromINVAuthDate.ShowCheckBox = true;
            this.dtpFromINVAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromINVAuthDate.TabIndex = 97;
            // 
            // chkINVAuthDate
            // 
            this.chkINVAuthDate.AutoSize = true;
            this.chkINVAuthDate.Location = new System.Drawing.Point(812, 146);
            this.chkINVAuthDate.Name = "chkINVAuthDate";
            this.chkINVAuthDate.Size = new System.Drawing.Size(95, 17);
            this.chkINVAuthDate.TabIndex = 96;
            this.chkINVAuthDate.Text = "INV Auth Date";
            this.chkINVAuthDate.UseVisualStyleBackColor = true;
            // 
            // frmInvoiceDetailWithoutProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblReportName);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.dgvQueryExec);
            this.Name = "frmInvoiceDetailWithoutProduct";
            this.Text = "frmInvoiceDetailWithoutProduct";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQueryExec;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listIOMNO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToIOMDate;
        private System.Windows.Forms.DateTimePicker dtpFromIOMDate;
        private System.Windows.Forms.CheckBox chkIOMDate;
        private System.Windows.Forms.CheckBox chkPartyCode;
        private System.Windows.Forms.CheckBox chkIomNo;
        private System.Windows.Forms.ComboBox cmdLocationCode;
        private System.Windows.Forms.CheckBox chkLocation;
        private System.Windows.Forms.ListBox listPartyCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpToInvoiceDate;
        private System.Windows.Forms.DateTimePicker dtpFromInvoiceDate;
        private System.Windows.Forms.CheckBox chkInvoiceDate;
        private System.Windows.Forms.ListBox listSTNNo;
        private System.Windows.Forms.CheckBox chkSTNNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpSTNToDate;
        private System.Windows.Forms.DateTimePicker dtpSTNFromDate;
        private System.Windows.Forms.CheckBox chkSTNDate;
        private System.Windows.Forms.CheckBox chkPartyName;
        private System.Windows.Forms.ListBox listPartyName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpToAuthDate;
        private System.Windows.Forms.DateTimePicker dtpFromAuthDate;
        private System.Windows.Forms.CheckBox chkSTNINVAuthDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpToSTNAuthDate;
        private System.Windows.Forms.DateTimePicker dtpFromSTNAuthDate;
        private System.Windows.Forms.CheckBox chkSTNAuthDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpToINVAuthDate;
        private System.Windows.Forms.DateTimePicker dtpFromINVAuthDate;
        private System.Windows.Forms.CheckBox chkINVAuthDate;
    }
}