namespace GlanMark
{
    partial class frmQueryExecuter
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
            this.ddlQueryName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvQueryExec = new System.Windows.Forms.DataGridView();
            this.btnQueryExecute = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listOrderheaderIOMNO = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTO = new System.Windows.Forms.DateTimePicker();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.chkOrderheaderLocCode = new System.Windows.Forms.ComboBox();
            this.chkOrderheaderPartyCode = new System.Windows.Forms.ComboBox();
            this.chkOrderAuthDate = new System.Windows.Forms.CheckBox();
            this.chkIsAuthorised = new System.Windows.Forms.CheckBox();
            this.chkLocation = new System.Windows.Forms.CheckBox();
            this.chkParty = new System.Windows.Forms.CheckBox();
            this.chkIomNo = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listOrderItemIOMNO = new System.Windows.Forms.ListBox();
            this.cmbOrderItemAliasCode = new System.Windows.Forms.ComboBox();
            this.chkIsdelivery = new System.Windows.Forms.CheckBox();
            this.chkAliseCode = new System.Windows.Forms.CheckBox();
            this.chkOrderItemIOMNO = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.listBatchIOMNO = new System.Windows.Forms.ListBox();
            this.cmbBatchProduct = new System.Windows.Forms.ComboBox();
            this.cmbBatchNo = new System.Windows.Forms.ComboBox();
            this.chkProductCode = new System.Windows.Forms.CheckBox();
            this.chkBatchNo = new System.Windows.Forms.CheckBox();
            this.chkBatchIOMNO = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listInvoiceIOMNO = new System.Windows.Forms.ListBox();
            this.cmbInvoiceBiling = new System.Windows.Forms.ComboBox();
            this.chkInvoiceBilling = new System.Windows.Forms.CheckBox();
            this.chkInvoiceIOMNO = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpSTNTo = new System.Windows.Forms.DateTimePicker();
            this.dtpSTNFrom = new System.Windows.Forms.DateTimePicker();
            this.chkDelivery = new System.Windows.Forms.CheckBox();
            this.listSTNUploadIOMNO = new System.Windows.Forms.ListBox();
            this.cmbPartyCode = new System.Windows.Forms.ComboBox();
            this.cmbMaterialCode = new System.Windows.Forms.ComboBox();
            this.chkPartyCode = new System.Windows.Forms.CheckBox();
            this.chkMaterial = new System.Windows.Forms.CheckBox();
            this.chkSTNIOMNO = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listSAPinvoiceIOMNO = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpSAPTo = new System.Windows.Forms.DateTimePicker();
            this.dtpSAPFrom = new System.Windows.Forms.DateTimePicker();
            this.chkBillingDate = new System.Windows.Forms.CheckBox();
            this.cmbSAPBatch = new System.Windows.Forms.ComboBox();
            this.cmbSAPBilingDoc = new System.Windows.Forms.ComboBox();
            this.chkBatch = new System.Windows.Forms.CheckBox();
            this.chkBillingDoc = new System.Windows.Forms.CheckBox();
            this.chkSAPIOMNO = new System.Windows.Forms.CheckBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblOrderheader = new System.Windows.Forms.Label();
            this.lblSAPINvoice = new System.Windows.Forms.Label();
            this.lblSTNUpload = new System.Windows.Forms.Label();
            this.lblInvoiceDispatch = new System.Windows.Forms.Label();
            this.lblbatchallocation = new System.Windows.Forms.Label();
            this.lblOrderitem = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.lblHdnQuery = new System.Windows.Forms.Label();
            this.lblQueryName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlQueryName
            // 
            this.ddlQueryName.FormattingEnabled = true;
            this.ddlQueryName.Location = new System.Drawing.Point(84, 8);
            this.ddlQueryName.Name = "ddlQueryName";
            this.ddlQueryName.Size = new System.Drawing.Size(479, 21);
            this.ddlQueryName.TabIndex = 5;
            this.ddlQueryName.SelectedIndexChanged += new System.EventHandler(this.ddlQueryName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Query";
            // 
            // dgvQueryExec
            // 
            this.dgvQueryExec.AllowUserToAddRows = false;
            this.dgvQueryExec.AllowUserToDeleteRows = false;
            this.dgvQueryExec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryExec.Location = new System.Drawing.Point(12, 417);
            this.dgvQueryExec.Name = "dgvQueryExec";
            this.dgvQueryExec.ReadOnly = true;
            this.dgvQueryExec.Size = new System.Drawing.Size(1230, 144);
            this.dgvQueryExec.TabIndex = 7;
            // 
            // btnQueryExecute
            // 
            this.btnQueryExecute.Location = new System.Drawing.Point(577, 7);
            this.btnQueryExecute.Name = "btnQueryExecute";
            this.btnQueryExecute.Size = new System.Drawing.Size(93, 23);
            this.btnQueryExecute.TabIndex = 8;
            this.btnQueryExecute.Text = "Execute";
            this.btnQueryExecute.UseVisualStyleBackColor = true;
            this.btnQueryExecute.Click += new System.EventHandler(this.btnQueryExecute_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listOrderheaderIOMNO);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpTO);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.chkOrderheaderLocCode);
            this.groupBox1.Controls.Add(this.chkOrderheaderPartyCode);
            this.groupBox1.Controls.Add(this.chkOrderAuthDate);
            this.groupBox1.Controls.Add(this.chkIsAuthorised);
            this.groupBox1.Controls.Add(this.chkLocation);
            this.groupBox1.Controls.Add(this.chkParty);
            this.groupBox1.Controls.Add(this.chkIomNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 352);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Header";
            // 
            // listOrderheaderIOMNO
            // 
            this.listOrderheaderIOMNO.FormattingEnabled = true;
            this.listOrderheaderIOMNO.Location = new System.Drawing.Point(25, 36);
            this.listOrderheaderIOMNO.Name = "listOrderheaderIOMNO";
            this.listOrderheaderIOMNO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listOrderheaderIOMNO.Size = new System.Drawing.Size(158, 121);
            this.listOrderheaderIOMNO.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "From";
            // 
            // dtpTO
            // 
            this.dtpTO.CustomFormat = "dd/MM/yyyy";
            this.dtpTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTO.Location = new System.Drawing.Point(58, 323);
            this.dtpTO.Name = "dtpTO";
            this.dtpTO.ShowCheckBox = true;
            this.dtpTO.Size = new System.Drawing.Size(98, 20);
            this.dtpTO.TabIndex = 43;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(58, 297);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowCheckBox = true;
            this.dtpDate.Size = new System.Drawing.Size(98, 20);
            this.dtpDate.TabIndex = 41;
            // 
            // chkOrderheaderLocCode
            // 
            this.chkOrderheaderLocCode.FormattingEnabled = true;
            this.chkOrderheaderLocCode.Location = new System.Drawing.Point(22, 226);
            this.chkOrderheaderLocCode.Name = "chkOrderheaderLocCode";
            this.chkOrderheaderLocCode.Size = new System.Drawing.Size(121, 21);
            this.chkOrderheaderLocCode.TabIndex = 8;
            // 
            // chkOrderheaderPartyCode
            // 
            this.chkOrderheaderPartyCode.FormattingEnabled = true;
            this.chkOrderheaderPartyCode.Location = new System.Drawing.Point(22, 183);
            this.chkOrderheaderPartyCode.Name = "chkOrderheaderPartyCode";
            this.chkOrderheaderPartyCode.Size = new System.Drawing.Size(121, 21);
            this.chkOrderheaderPartyCode.TabIndex = 7;
            // 
            // chkOrderAuthDate
            // 
            this.chkOrderAuthDate.AutoSize = true;
            this.chkOrderAuthDate.Location = new System.Drawing.Point(5, 274);
            this.chkOrderAuthDate.Name = "chkOrderAuthDate";
            this.chkOrderAuthDate.Size = new System.Drawing.Size(103, 17);
            this.chkOrderAuthDate.TabIndex = 5;
            this.chkOrderAuthDate.Text = "Order Auth Date";
            this.chkOrderAuthDate.UseVisualStyleBackColor = true;
            // 
            // chkIsAuthorised
            // 
            this.chkIsAuthorised.AutoSize = true;
            this.chkIsAuthorised.Location = new System.Drawing.Point(5, 254);
            this.chkIsAuthorised.Name = "chkIsAuthorised";
            this.chkIsAuthorised.Size = new System.Drawing.Size(87, 17);
            this.chkIsAuthorised.TabIndex = 4;
            this.chkIsAuthorised.Text = "Is Authorised";
            this.chkIsAuthorised.UseVisualStyleBackColor = true;
            // 
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.Location = new System.Drawing.Point(5, 211);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(95, 17);
            this.chkLocation.TabIndex = 2;
            this.chkLocation.Text = "Location Code";
            this.chkLocation.UseVisualStyleBackColor = true;
            // 
            // chkParty
            // 
            this.chkParty.AutoSize = true;
            this.chkParty.Location = new System.Drawing.Point(5, 166);
            this.chkParty.Name = "chkParty";
            this.chkParty.Size = new System.Drawing.Size(75, 17);
            this.chkParty.TabIndex = 1;
            this.chkParty.Text = "PartyCode";
            this.chkParty.UseVisualStyleBackColor = true;
            // 
            // chkIomNo
            // 
            this.chkIomNo.AutoSize = true;
            this.chkIomNo.Location = new System.Drawing.Point(7, 20);
            this.chkIomNo.Name = "chkIomNo";
            this.chkIomNo.Size = new System.Drawing.Size(62, 17);
            this.chkIomNo.TabIndex = 0;
            this.chkIomNo.Text = "IOMNO";
            this.chkIomNo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listOrderItemIOMNO);
            this.groupBox2.Controls.Add(this.cmbOrderItemAliasCode);
            this.groupBox2.Controls.Add(this.chkIsdelivery);
            this.groupBox2.Controls.Add(this.chkAliseCode);
            this.groupBox2.Controls.Add(this.chkOrderItemIOMNO);
            this.groupBox2.Location = new System.Drawing.Point(218, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 352);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order Item";
            // 
            // listOrderItemIOMNO
            // 
            this.listOrderItemIOMNO.FormattingEnabled = true;
            this.listOrderItemIOMNO.Location = new System.Drawing.Point(23, 36);
            this.listOrderItemIOMNO.Name = "listOrderItemIOMNO";
            this.listOrderItemIOMNO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listOrderItemIOMNO.Size = new System.Drawing.Size(158, 121);
            this.listOrderItemIOMNO.TabIndex = 46;
            // 
            // cmbOrderItemAliasCode
            // 
            this.cmbOrderItemAliasCode.FormattingEnabled = true;
            this.cmbOrderItemAliasCode.Location = new System.Drawing.Point(23, 183);
            this.cmbOrderItemAliasCode.Name = "cmbOrderItemAliasCode";
            this.cmbOrderItemAliasCode.Size = new System.Drawing.Size(121, 21);
            this.cmbOrderItemAliasCode.TabIndex = 13;
            // 
            // chkIsdelivery
            // 
            this.chkIsdelivery.AutoSize = true;
            this.chkIsdelivery.Location = new System.Drawing.Point(6, 211);
            this.chkIsdelivery.Name = "chkIsdelivery";
            this.chkIsdelivery.Size = new System.Drawing.Size(75, 17);
            this.chkIsdelivery.TabIndex = 11;
            this.chkIsdelivery.Text = "Is Delivery";
            this.chkIsdelivery.UseVisualStyleBackColor = true;
            // 
            // chkAliseCode
            // 
            this.chkAliseCode.AutoSize = true;
            this.chkAliseCode.Location = new System.Drawing.Point(6, 166);
            this.chkAliseCode.Name = "chkAliseCode";
            this.chkAliseCode.Size = new System.Drawing.Size(76, 17);
            this.chkAliseCode.TabIndex = 10;
            this.chkAliseCode.Text = "Alise Code";
            this.chkAliseCode.UseVisualStyleBackColor = true;
            // 
            // chkOrderItemIOMNO
            // 
            this.chkOrderItemIOMNO.AutoSize = true;
            this.chkOrderItemIOMNO.Location = new System.Drawing.Point(6, 20);
            this.chkOrderItemIOMNO.Name = "chkOrderItemIOMNO";
            this.chkOrderItemIOMNO.Size = new System.Drawing.Size(62, 17);
            this.chkOrderItemIOMNO.TabIndex = 9;
            this.chkOrderItemIOMNO.Text = "IOMNO";
            this.chkOrderItemIOMNO.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listBatchIOMNO);
            this.groupBox6.Controls.Add(this.cmbBatchProduct);
            this.groupBox6.Controls.Add(this.cmbBatchNo);
            this.groupBox6.Controls.Add(this.chkProductCode);
            this.groupBox6.Controls.Add(this.chkBatchNo);
            this.groupBox6.Controls.Add(this.chkBatchIOMNO);
            this.groupBox6.Location = new System.Drawing.Point(1042, 36);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 351);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Batch Allocation";
            // 
            // listBatchIOMNO
            // 
            this.listBatchIOMNO.FormattingEnabled = true;
            this.listBatchIOMNO.Location = new System.Drawing.Point(22, 38);
            this.listBatchIOMNO.Name = "listBatchIOMNO";
            this.listBatchIOMNO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBatchIOMNO.Size = new System.Drawing.Size(174, 121);
            this.listBatchIOMNO.TabIndex = 57;
            // 
            // cmbBatchProduct
            // 
            this.cmbBatchProduct.FormattingEnabled = true;
            this.cmbBatchProduct.Location = new System.Drawing.Point(22, 225);
            this.cmbBatchProduct.Name = "cmbBatchProduct";
            this.cmbBatchProduct.Size = new System.Drawing.Size(121, 21);
            this.cmbBatchProduct.TabIndex = 56;
            // 
            // cmbBatchNo
            // 
            this.cmbBatchNo.FormattingEnabled = true;
            this.cmbBatchNo.Location = new System.Drawing.Point(22, 182);
            this.cmbBatchNo.Name = "cmbBatchNo";
            this.cmbBatchNo.Size = new System.Drawing.Size(121, 21);
            this.cmbBatchNo.TabIndex = 55;
            // 
            // chkProductCode
            // 
            this.chkProductCode.AutoSize = true;
            this.chkProductCode.Location = new System.Drawing.Point(5, 210);
            this.chkProductCode.Name = "chkProductCode";
            this.chkProductCode.Size = new System.Drawing.Size(91, 17);
            this.chkProductCode.TabIndex = 54;
            this.chkProductCode.Text = "Product Code";
            this.chkProductCode.UseVisualStyleBackColor = true;
            // 
            // chkBatchNo
            // 
            this.chkBatchNo.AutoSize = true;
            this.chkBatchNo.Location = new System.Drawing.Point(5, 165);
            this.chkBatchNo.Name = "chkBatchNo";
            this.chkBatchNo.Size = new System.Drawing.Size(71, 17);
            this.chkBatchNo.TabIndex = 53;
            this.chkBatchNo.Text = "Batch No";
            this.chkBatchNo.UseVisualStyleBackColor = true;
            // 
            // chkBatchIOMNO
            // 
            this.chkBatchIOMNO.AutoSize = true;
            this.chkBatchIOMNO.Location = new System.Drawing.Point(7, 18);
            this.chkBatchIOMNO.Name = "chkBatchIOMNO";
            this.chkBatchIOMNO.Size = new System.Drawing.Size(62, 17);
            this.chkBatchIOMNO.TabIndex = 52;
            this.chkBatchIOMNO.Text = "IOMNO";
            this.chkBatchIOMNO.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listInvoiceIOMNO);
            this.groupBox5.Controls.Add(this.cmbInvoiceBiling);
            this.groupBox5.Controls.Add(this.chkInvoiceBilling);
            this.groupBox5.Controls.Add(this.chkInvoiceIOMNO);
            this.groupBox5.Location = new System.Drawing.Point(836, 36);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 351);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Invoice Dispatch";
            // 
            // listInvoiceIOMNO
            // 
            this.listInvoiceIOMNO.FormattingEnabled = true;
            this.listInvoiceIOMNO.Location = new System.Drawing.Point(20, 39);
            this.listInvoiceIOMNO.Name = "listInvoiceIOMNO";
            this.listInvoiceIOMNO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listInvoiceIOMNO.Size = new System.Drawing.Size(174, 121);
            this.listInvoiceIOMNO.TabIndex = 55;
            // 
            // cmbInvoiceBiling
            // 
            this.cmbInvoiceBiling.FormattingEnabled = true;
            this.cmbInvoiceBiling.Location = new System.Drawing.Point(20, 183);
            this.cmbInvoiceBiling.Name = "cmbInvoiceBiling";
            this.cmbInvoiceBiling.Size = new System.Drawing.Size(121, 21);
            this.cmbInvoiceBiling.TabIndex = 54;
            // 
            // chkInvoiceBilling
            // 
            this.chkInvoiceBilling.AutoSize = true;
            this.chkInvoiceBilling.Location = new System.Drawing.Point(3, 166);
            this.chkInvoiceBilling.Name = "chkInvoiceBilling";
            this.chkInvoiceBilling.Size = new System.Drawing.Size(105, 17);
            this.chkInvoiceBilling.TabIndex = 53;
            this.chkInvoiceBilling.Text = "Billing Document";
            this.chkInvoiceBilling.UseVisualStyleBackColor = true;
            // 
            // chkInvoiceIOMNO
            // 
            this.chkInvoiceIOMNO.AutoSize = true;
            this.chkInvoiceIOMNO.Location = new System.Drawing.Point(5, 19);
            this.chkInvoiceIOMNO.Name = "chkInvoiceIOMNO";
            this.chkInvoiceIOMNO.Size = new System.Drawing.Size(62, 17);
            this.chkInvoiceIOMNO.TabIndex = 52;
            this.chkInvoiceIOMNO.Text = "IOMNO";
            this.chkInvoiceIOMNO.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.dtpSTNTo);
            this.groupBox4.Controls.Add(this.dtpSTNFrom);
            this.groupBox4.Controls.Add(this.chkDelivery);
            this.groupBox4.Controls.Add(this.listSTNUploadIOMNO);
            this.groupBox4.Controls.Add(this.cmbPartyCode);
            this.groupBox4.Controls.Add(this.cmbMaterialCode);
            this.groupBox4.Controls.Add(this.chkPartyCode);
            this.groupBox4.Controls.Add(this.chkMaterial);
            this.groupBox4.Controls.Add(this.chkSTNIOMNO);
            this.groupBox4.Location = new System.Drawing.Point(630, 36);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 351);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "STN Upload";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "To";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "From";
            // 
            // dtpSTNTo
            // 
            this.dtpSTNTo.CustomFormat = "dd/MM/yyyy";
            this.dtpSTNTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSTNTo.Location = new System.Drawing.Point(56, 302);
            this.dtpSTNTo.Name = "dtpSTNTo";
            this.dtpSTNTo.ShowCheckBox = true;
            this.dtpSTNTo.Size = new System.Drawing.Size(98, 20);
            this.dtpSTNTo.TabIndex = 55;
            // 
            // dtpSTNFrom
            // 
            this.dtpSTNFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpSTNFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSTNFrom.Location = new System.Drawing.Point(56, 276);
            this.dtpSTNFrom.Name = "dtpSTNFrom";
            this.dtpSTNFrom.ShowCheckBox = true;
            this.dtpSTNFrom.Size = new System.Drawing.Size(98, 20);
            this.dtpSTNFrom.TabIndex = 53;
            // 
            // chkDelivery
            // 
            this.chkDelivery.AutoSize = true;
            this.chkDelivery.Location = new System.Drawing.Point(3, 253);
            this.chkDelivery.Name = "chkDelivery";
            this.chkDelivery.Size = new System.Drawing.Size(93, 17);
            this.chkDelivery.TabIndex = 52;
            this.chkDelivery.Text = "Delivery Date ";
            this.chkDelivery.UseVisualStyleBackColor = true;
            // 
            // listSTNUploadIOMNO
            // 
            this.listSTNUploadIOMNO.FormattingEnabled = true;
            this.listSTNUploadIOMNO.Location = new System.Drawing.Point(20, 39);
            this.listSTNUploadIOMNO.Name = "listSTNUploadIOMNO";
            this.listSTNUploadIOMNO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listSTNUploadIOMNO.Size = new System.Drawing.Size(174, 121);
            this.listSTNUploadIOMNO.TabIndex = 51;
            // 
            // cmbPartyCode
            // 
            this.cmbPartyCode.FormattingEnabled = true;
            this.cmbPartyCode.Location = new System.Drawing.Point(20, 226);
            this.cmbPartyCode.Name = "cmbPartyCode";
            this.cmbPartyCode.Size = new System.Drawing.Size(121, 21);
            this.cmbPartyCode.TabIndex = 20;
            // 
            // cmbMaterialCode
            // 
            this.cmbMaterialCode.FormattingEnabled = true;
            this.cmbMaterialCode.Location = new System.Drawing.Point(20, 183);
            this.cmbMaterialCode.Name = "cmbMaterialCode";
            this.cmbMaterialCode.Size = new System.Drawing.Size(121, 21);
            this.cmbMaterialCode.TabIndex = 19;
            // 
            // chkPartyCode
            // 
            this.chkPartyCode.AutoSize = true;
            this.chkPartyCode.Location = new System.Drawing.Point(3, 211);
            this.chkPartyCode.Name = "chkPartyCode";
            this.chkPartyCode.Size = new System.Drawing.Size(78, 17);
            this.chkPartyCode.TabIndex = 17;
            this.chkPartyCode.Text = "Party Code";
            this.chkPartyCode.UseVisualStyleBackColor = true;
            // 
            // chkMaterial
            // 
            this.chkMaterial.AutoSize = true;
            this.chkMaterial.Location = new System.Drawing.Point(3, 166);
            this.chkMaterial.Name = "chkMaterial";
            this.chkMaterial.Size = new System.Drawing.Size(91, 17);
            this.chkMaterial.TabIndex = 16;
            this.chkMaterial.Text = "Material Code";
            this.chkMaterial.UseVisualStyleBackColor = true;
            // 
            // chkSTNIOMNO
            // 
            this.chkSTNIOMNO.AutoSize = true;
            this.chkSTNIOMNO.Location = new System.Drawing.Point(5, 19);
            this.chkSTNIOMNO.Name = "chkSTNIOMNO";
            this.chkSTNIOMNO.Size = new System.Drawing.Size(62, 17);
            this.chkSTNIOMNO.TabIndex = 15;
            this.chkSTNIOMNO.Text = "IOMNO";
            this.chkSTNIOMNO.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listSAPinvoiceIOMNO);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dtpSAPTo);
            this.groupBox3.Controls.Add(this.dtpSAPFrom);
            this.groupBox3.Controls.Add(this.chkBillingDate);
            this.groupBox3.Controls.Add(this.cmbSAPBatch);
            this.groupBox3.Controls.Add(this.cmbSAPBilingDoc);
            this.groupBox3.Controls.Add(this.chkBatch);
            this.groupBox3.Controls.Add(this.chkBillingDoc);
            this.groupBox3.Controls.Add(this.chkSAPIOMNO);
            this.groupBox3.Location = new System.Drawing.Point(424, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 351);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SAP Invoice";
            // 
            // listSAPinvoiceIOMNO
            // 
            this.listSAPinvoiceIOMNO.FormattingEnabled = true;
            this.listSAPinvoiceIOMNO.Location = new System.Drawing.Point(26, 35);
            this.listSAPinvoiceIOMNO.Name = "listSAPinvoiceIOMNO";
            this.listSAPinvoiceIOMNO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listSAPinvoiceIOMNO.Size = new System.Drawing.Size(158, 121);
            this.listSAPinvoiceIOMNO.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "From";
            // 
            // dtpSAPTo
            // 
            this.dtpSAPTo.CustomFormat = "dd/MM/yyyy";
            this.dtpSAPTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSAPTo.Location = new System.Drawing.Point(59, 302);
            this.dtpSAPTo.Name = "dtpSAPTo";
            this.dtpSAPTo.ShowCheckBox = true;
            this.dtpSAPTo.Size = new System.Drawing.Size(98, 20);
            this.dtpSAPTo.TabIndex = 48;
            // 
            // dtpSAPFrom
            // 
            this.dtpSAPFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpSAPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSAPFrom.Location = new System.Drawing.Point(59, 276);
            this.dtpSAPFrom.Name = "dtpSAPFrom";
            this.dtpSAPFrom.ShowCheckBox = true;
            this.dtpSAPFrom.Size = new System.Drawing.Size(98, 20);
            this.dtpSAPFrom.TabIndex = 46;
            // 
            // chkBillingDate
            // 
            this.chkBillingDate.AutoSize = true;
            this.chkBillingDate.Location = new System.Drawing.Point(6, 253);
            this.chkBillingDate.Name = "chkBillingDate";
            this.chkBillingDate.Size = new System.Drawing.Size(79, 17);
            this.chkBillingDate.TabIndex = 45;
            this.chkBillingDate.Text = "Billing Date";
            this.chkBillingDate.UseVisualStyleBackColor = true;
            // 
            // cmbSAPBatch
            // 
            this.cmbSAPBatch.FormattingEnabled = true;
            this.cmbSAPBatch.Location = new System.Drawing.Point(26, 225);
            this.cmbSAPBatch.Name = "cmbSAPBatch";
            this.cmbSAPBatch.Size = new System.Drawing.Size(121, 21);
            this.cmbSAPBatch.TabIndex = 14;
            // 
            // cmbSAPBilingDoc
            // 
            this.cmbSAPBilingDoc.FormattingEnabled = true;
            this.cmbSAPBilingDoc.Location = new System.Drawing.Point(26, 183);
            this.cmbSAPBilingDoc.Name = "cmbSAPBilingDoc";
            this.cmbSAPBilingDoc.Size = new System.Drawing.Size(121, 21);
            this.cmbSAPBilingDoc.TabIndex = 13;
            // 
            // chkBatch
            // 
            this.chkBatch.AutoSize = true;
            this.chkBatch.Location = new System.Drawing.Point(9, 210);
            this.chkBatch.Name = "chkBatch";
            this.chkBatch.Size = new System.Drawing.Size(54, 17);
            this.chkBatch.TabIndex = 11;
            this.chkBatch.Text = "Batch";
            this.chkBatch.UseVisualStyleBackColor = true;
            // 
            // chkBillingDoc
            // 
            this.chkBillingDoc.AutoSize = true;
            this.chkBillingDoc.Location = new System.Drawing.Point(9, 166);
            this.chkBillingDoc.Name = "chkBillingDoc";
            this.chkBillingDoc.Size = new System.Drawing.Size(105, 17);
            this.chkBillingDoc.TabIndex = 10;
            this.chkBillingDoc.Text = "Billing Document";
            this.chkBillingDoc.UseVisualStyleBackColor = true;
            // 
            // chkSAPIOMNO
            // 
            this.chkSAPIOMNO.AutoSize = true;
            this.chkSAPIOMNO.Location = new System.Drawing.Point(9, 19);
            this.chkSAPIOMNO.Name = "chkSAPIOMNO";
            this.chkSAPIOMNO.Size = new System.Drawing.Size(62, 17);
            this.chkSAPIOMNO.TabIndex = 9;
            this.chkSAPIOMNO.Text = "IOMNO";
            this.chkSAPIOMNO.UseVisualStyleBackColor = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(794, 11);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(35, 13);
            this.lblCount.TabIndex = 12;
            this.lblCount.Text = "Count";
            this.lblCount.Visible = false;
            // 
            // lblOrderheader
            // 
            this.lblOrderheader.AutoSize = true;
            this.lblOrderheader.Location = new System.Drawing.Point(656, 401);
            this.lblOrderheader.Name = "lblOrderheader";
            this.lblOrderheader.Size = new System.Drawing.Size(13, 13);
            this.lblOrderheader.TabIndex = 13;
            this.lblOrderheader.Text = "0";
            // 
            // lblSAPINvoice
            // 
            this.lblSAPINvoice.AutoSize = true;
            this.lblSAPINvoice.Location = new System.Drawing.Point(698, 401);
            this.lblSAPINvoice.Name = "lblSAPINvoice";
            this.lblSAPINvoice.Size = new System.Drawing.Size(13, 13);
            this.lblSAPINvoice.TabIndex = 14;
            this.lblSAPINvoice.Text = "0";
            // 
            // lblSTNUpload
            // 
            this.lblSTNUpload.AutoSize = true;
            this.lblSTNUpload.Location = new System.Drawing.Point(725, 401);
            this.lblSTNUpload.Name = "lblSTNUpload";
            this.lblSTNUpload.Size = new System.Drawing.Size(13, 13);
            this.lblSTNUpload.TabIndex = 15;
            this.lblSTNUpload.Text = "0";
            // 
            // lblInvoiceDispatch
            // 
            this.lblInvoiceDispatch.AutoSize = true;
            this.lblInvoiceDispatch.Location = new System.Drawing.Point(758, 402);
            this.lblInvoiceDispatch.Name = "lblInvoiceDispatch";
            this.lblInvoiceDispatch.Size = new System.Drawing.Size(13, 13);
            this.lblInvoiceDispatch.TabIndex = 16;
            this.lblInvoiceDispatch.Text = "0";
            // 
            // lblbatchallocation
            // 
            this.lblbatchallocation.AutoSize = true;
            this.lblbatchallocation.Location = new System.Drawing.Point(789, 401);
            this.lblbatchallocation.Name = "lblbatchallocation";
            this.lblbatchallocation.Size = new System.Drawing.Size(13, 13);
            this.lblbatchallocation.TabIndex = 17;
            this.lblbatchallocation.Text = "0";
            // 
            // lblOrderitem
            // 
            this.lblOrderitem.AutoSize = true;
            this.lblOrderitem.Location = new System.Drawing.Point(679, 402);
            this.lblOrderitem.Name = "lblOrderitem";
            this.lblOrderitem.Size = new System.Drawing.Size(13, 13);
            this.lblOrderitem.TabIndex = 18;
            this.lblOrderitem.Text = "0";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Location = new System.Drawing.Point(1127, 2);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(124, 27);
            this.btnExportToExcel.TabIndex = 56;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // lblHdnQuery
            // 
            this.lblHdnQuery.AutoSize = true;
            this.lblHdnQuery.Location = new System.Drawing.Point(958, 11);
            this.lblHdnQuery.Name = "lblHdnQuery";
            this.lblHdnQuery.Size = new System.Drawing.Size(0, 13);
            this.lblHdnQuery.TabIndex = 57;
            this.lblHdnQuery.Visible = false;
            // 
            // lblQueryName
            // 
            this.lblQueryName.AutoSize = true;
            this.lblQueryName.Location = new System.Drawing.Point(867, 11);
            this.lblQueryName.Name = "lblQueryName";
            this.lblQueryName.Size = new System.Drawing.Size(0, 13);
            this.lblQueryName.TabIndex = 58;
            this.lblQueryName.Visible = false;
            // 
            // frmQueryExecuter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1254, 573);
            this.Controls.Add(this.lblQueryName);
            this.Controls.Add(this.lblHdnQuery);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.lblOrderitem);
            this.Controls.Add(this.lblbatchallocation);
            this.Controls.Add(this.lblInvoiceDispatch);
            this.Controls.Add(this.lblSTNUpload);
            this.Controls.Add(this.lblSAPINvoice);
            this.Controls.Add(this.lblOrderheader);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQueryExecute);
            this.Controls.Add(this.dgvQueryExec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlQueryName);
            this.Name = "frmQueryExecuter";
            this.Text = "frmQueryExecuter";
            this.Load += new System.EventHandler(this.frmQueryExecuter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlQueryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvQueryExec;
        private System.Windows.Forms.Button btnQueryExecute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.CheckBox chkOrderAuthDate;
        private System.Windows.Forms.CheckBox chkIsAuthorised;
        private System.Windows.Forms.CheckBox chkLocation;
        private System.Windows.Forms.CheckBox chkParty;
        private System.Windows.Forms.CheckBox chkIomNo;
        private System.Windows.Forms.ComboBox chkOrderheaderPartyCode;
        private System.Windows.Forms.ComboBox chkOrderheaderLocCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTO;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbOrderItemAliasCode;
        private System.Windows.Forms.CheckBox chkIsdelivery;
        private System.Windows.Forms.CheckBox chkAliseCode;
        private System.Windows.Forms.CheckBox chkOrderItemIOMNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpSAPTo;
        private System.Windows.Forms.DateTimePicker dtpSAPFrom;
        private System.Windows.Forms.CheckBox chkBillingDate;
        private System.Windows.Forms.ComboBox cmbSAPBatch;
        private System.Windows.Forms.ComboBox cmbSAPBilingDoc;
        private System.Windows.Forms.CheckBox chkBatch;
        private System.Windows.Forms.CheckBox chkBillingDoc;
        private System.Windows.Forms.CheckBox chkSAPIOMNO;
        private System.Windows.Forms.ComboBox cmbPartyCode;
        private System.Windows.Forms.ComboBox cmbMaterialCode;
        private System.Windows.Forms.CheckBox chkPartyCode;
        private System.Windows.Forms.CheckBox chkMaterial;
        private System.Windows.Forms.CheckBox chkSTNIOMNO;
        private System.Windows.Forms.ListBox listOrderheaderIOMNO;
        private System.Windows.Forms.ListBox listOrderItemIOMNO;
        private System.Windows.Forms.Label lblOrderheader;
        private System.Windows.Forms.Label lblSAPINvoice;
        private System.Windows.Forms.Label lblSTNUpload;
        private System.Windows.Forms.Label lblInvoiceDispatch;
        private System.Windows.Forms.Label lblbatchallocation;
        private System.Windows.Forms.Label lblOrderitem;
        private System.Windows.Forms.ListBox listSAPinvoiceIOMNO;
        private System.Windows.Forms.ListBox listSTNUploadIOMNO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpSTNTo;
        private System.Windows.Forms.DateTimePicker dtpSTNFrom;
        private System.Windows.Forms.CheckBox chkDelivery;
        private System.Windows.Forms.ListBox listInvoiceIOMNO;
        private System.Windows.Forms.ComboBox cmbInvoiceBiling;
        private System.Windows.Forms.CheckBox chkInvoiceBilling;
        private System.Windows.Forms.CheckBox chkInvoiceIOMNO;
        private System.Windows.Forms.ListBox listBatchIOMNO;
        private System.Windows.Forms.ComboBox cmbBatchProduct;
        private System.Windows.Forms.ComboBox cmbBatchNo;
        private System.Windows.Forms.CheckBox chkProductCode;
        private System.Windows.Forms.CheckBox chkBatchNo;
        private System.Windows.Forms.CheckBox chkBatchIOMNO;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Label lblHdnQuery;
        private System.Windows.Forms.Label lblQueryName;
    }
}