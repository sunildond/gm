namespace GlanMark
{
    partial class frmPendingOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSubmitIOM = new System.Windows.Forms.Button();
            this.ddlIOMNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpOrderRec = new System.Windows.Forms.DateTimePicker();
            this.dgvPendingOrderMaster = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewImageColumn();
            this.colSchedule = new System.Windows.Forms.DataGridViewImageColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIOMNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIOMDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderAuthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScheduledate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPenQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDispThrough = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStampingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBillingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlisCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProdCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderHeaderRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocFile1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrderMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSubmitIOM);
            this.groupBox1.Controls.Add(this.ddlIOMNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dtpOrderRec);
            this.groupBox1.Controls.Add(this.dgvPendingOrderMaster);
            this.groupBox1.Location = new System.Drawing.Point(4, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1237, 550);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pending Order Detail";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1084, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 28;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSubmitIOM
            // 
            this.btnSubmitIOM.Location = new System.Drawing.Point(644, 14);
            this.btnSubmitIOM.Name = "btnSubmitIOM";
            this.btnSubmitIOM.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitIOM.TabIndex = 27;
            this.btnSubmitIOM.Text = "Submit";
            this.btnSubmitIOM.UseVisualStyleBackColor = true;
            this.btnSubmitIOM.Click += new System.EventHandler(this.btnSubmitIOM_Click);
            // 
            // ddlIOMNo
            // 
            this.ddlIOMNo.FormattingEnabled = true;
            this.ddlIOMNo.Location = new System.Drawing.Point(419, 15);
            this.ddlIOMNo.Name = "ddlIOMNo";
            this.ddlIOMNo.Size = new System.Drawing.Size(211, 21);
            this.ddlIOMNo.TabIndex = 26;
            this.ddlIOMNo.SelectedIndexChanged += new System.EventHandler(this.ddlIOMNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Select IOM No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Select Date:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(193, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Submit";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpOrderRec
            // 
            this.dtpOrderRec.CustomFormat = "dd/MM/yyyy";
            this.dtpOrderRec.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderRec.Location = new System.Drawing.Point(84, 16);
            this.dtpOrderRec.Name = "dtpOrderRec";
            this.dtpOrderRec.Size = new System.Drawing.Size(98, 20);
            this.dtpOrderRec.TabIndex = 21;
            // 
            // dgvPendingOrderMaster
            // 
            this.dgvPendingOrderMaster.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(241)))), ((int)(((byte)(214)))));
            this.dgvPendingOrderMaster.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPendingOrderMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPendingOrderMaster.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPendingOrderMaster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPendingOrderMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPendingOrderMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingOrderMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colView,
            this.colSchedule,
            this.colId,
            this.colIOMNo,
            this.colIOMDate,
            this.colPartyCode,
            this.colPartyName,
            this.colOrderAuthDate,
            this.colScheduledate,
            this.colProdName,
            this.colOrderQty,
            this.colPenQty,
            this.colDispThrough,
            this.colMRP,
            this.colStampingName,
            this.colBillingRate,
            this.colProductValue,
            this.colReason,
            this.colRemark,
            this.colAlisCode,
            this.colProdCode,
            this.colScheduleID,
            this.OrderHeaderRemark,
            this.colDocFile1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPendingOrderMaster.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPendingOrderMaster.EnableHeadersVisualStyles = false;
            this.dgvPendingOrderMaster.GridColor = System.Drawing.SystemColors.Control;
            this.dgvPendingOrderMaster.Location = new System.Drawing.Point(6, 45);
            this.dgvPendingOrderMaster.MultiSelect = false;
            this.dgvPendingOrderMaster.Name = "dgvPendingOrderMaster";
            this.dgvPendingOrderMaster.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPendingOrderMaster.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPendingOrderMaster.RowHeadersVisible = false;
            this.dgvPendingOrderMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendingOrderMaster.Size = new System.Drawing.Size(1225, 495);
            this.dgvPendingOrderMaster.TabIndex = 20;
            this.dgvPendingOrderMaster.VirtualMode = true;
            this.dgvPendingOrderMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPendingOrderMaster_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderHeaderId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 41;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "IOMNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "IOM No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 52;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "IOMDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "IOM Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 72;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PartyCode";
            this.dataGridViewTextBoxColumn4.HeaderText = "Party Code";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Width = 78;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PartyName";
            this.dataGridViewTextBoxColumn5.HeaderText = "Party Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "OrderDeliveryDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "Schedule Date";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 95;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ProductCode";
            this.dataGridViewTextBoxColumn7.HeaderText = "Prod Code";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 76;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ProductName";
            this.dataGridViewTextBoxColumn8.HeaderText = "Prod Name";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 79;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn9.HeaderText = "Order Qty";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 71;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "PendingQuantity";
            this.dataGridViewTextBoxColumn10.HeaderText = "Pending Qty";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 83;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ScheduleID";
            this.dataGridViewTextBoxColumn11.HeaderText = "ScheduleID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 88;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "AlisCode";
            this.dataGridViewTextBoxColumn12.HeaderText = "Alis Code";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 70;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Reason";
            this.dataGridViewTextBoxColumn13.HeaderText = "Reason";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 69;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn14.HeaderText = "Remark";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            this.dataGridViewTextBoxColumn14.Width = 69;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "StampingName";
            this.dataGridViewTextBoxColumn15.HeaderText = "Stamping Name";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 98;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "OrderAuthDate";
            this.dataGridViewTextBoxColumn16.HeaderText = "Authorisation Date";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 109;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "MRP";
            this.dataGridViewTextBoxColumn17.HeaderText = "MRP";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 56;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "ProductValue";
            this.dataGridViewTextBoxColumn18.HeaderText = "Product Value";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Visible = false;
            this.dataGridViewTextBoxColumn18.Width = 91;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "DocFile1";
            this.dataGridViewTextBoxColumn19.HeaderText = "Document File";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Visible = false;
            this.dataGridViewTextBoxColumn19.Width = 92;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "StampingName";
            this.dataGridViewTextBoxColumn20.HeaderText = "Stamping Name";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Visible = false;
            this.dataGridViewTextBoxColumn20.Width = 98;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "OrderHeaderRemark";
            this.dataGridViewTextBoxColumn21.HeaderText = "OrderHeaderRemark";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.Width = 130;
            // 
            // colView
            // 
            this.colView.HeaderText = "View";
            this.colView.Image = global::gm.Properties.Resources.viewDetails;
            this.colView.Name = "colView";
            this.colView.ReadOnly = true;
            this.colView.Width = 36;
            // 
            // colSchedule
            // 
            this.colSchedule.HeaderText = "Schedule";
            this.colSchedule.Image = global::gm.Properties.Resources.schedule;
            this.colSchedule.Name = "colSchedule";
            this.colSchedule.ReadOnly = true;
            this.colSchedule.Width = 58;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "OrderHeaderId";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 41;
            // 
            // colIOMNo
            // 
            this.colIOMNo.DataPropertyName = "IOMNo";
            this.colIOMNo.HeaderText = "IOM No";
            this.colIOMNo.Name = "colIOMNo";
            this.colIOMNo.ReadOnly = true;
            this.colIOMNo.Width = 69;
            // 
            // colIOMDate
            // 
            this.colIOMDate.DataPropertyName = "IOMDate";
            this.colIOMDate.HeaderText = "IOM Date";
            this.colIOMDate.Name = "colIOMDate";
            this.colIOMDate.ReadOnly = true;
            this.colIOMDate.Width = 78;
            // 
            // colPartyCode
            // 
            this.colPartyCode.DataPropertyName = "PartyCode";
            this.colPartyCode.HeaderText = "Party Code";
            this.colPartyCode.Name = "colPartyCode";
            this.colPartyCode.ReadOnly = true;
            this.colPartyCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPartyCode.Width = 84;
            // 
            // colPartyName
            // 
            this.colPartyName.DataPropertyName = "PartyName";
            this.colPartyName.HeaderText = "Party Name";
            this.colPartyName.Name = "colPartyName";
            this.colPartyName.ReadOnly = true;
            this.colPartyName.Width = 87;
            // 
            // colOrderAuthDate
            // 
            this.colOrderAuthDate.DataPropertyName = "OrderAuthDate";
            this.colOrderAuthDate.HeaderText = "Authorisation Date";
            this.colOrderAuthDate.Name = "colOrderAuthDate";
            this.colOrderAuthDate.ReadOnly = true;
            this.colOrderAuthDate.Width = 109;
            // 
            // colScheduledate
            // 
            this.colScheduledate.DataPropertyName = "DelDate";
            this.colScheduledate.HeaderText = "Schedule Date";
            this.colScheduledate.Name = "colScheduledate";
            this.colScheduledate.ReadOnly = true;
            this.colScheduledate.Width = 95;
            // 
            // colProdName
            // 
            this.colProdName.DataPropertyName = "ProductName";
            this.colProdName.HeaderText = "Prod Name";
            this.colProdName.Name = "colProdName";
            this.colProdName.ReadOnly = true;
            this.colProdName.Width = 79;
            // 
            // colOrderQty
            // 
            this.colOrderQty.DataPropertyName = "QTY";
            this.colOrderQty.HeaderText = "Order Qty";
            this.colOrderQty.Name = "colOrderQty";
            this.colOrderQty.ReadOnly = true;
            this.colOrderQty.Width = 71;
            // 
            // colPenQty
            // 
            this.colPenQty.DataPropertyName = "PendingQuantity";
            this.colPenQty.HeaderText = "Pending Qty";
            this.colPenQty.Name = "colPenQty";
            this.colPenQty.ReadOnly = true;
            this.colPenQty.Width = 83;
            // 
            // colDispThrough
            // 
            this.colDispThrough.DataPropertyName = "DispThrough";
            this.colDispThrough.HeaderText = "DispThrough";
            this.colDispThrough.Name = "colDispThrough";
            this.colDispThrough.ReadOnly = true;
            this.colDispThrough.Width = 93;
            // 
            // colMRP
            // 
            this.colMRP.DataPropertyName = "MRP";
            this.colMRP.HeaderText = "MRP";
            this.colMRP.Name = "colMRP";
            this.colMRP.ReadOnly = true;
            this.colMRP.Width = 56;
            // 
            // colStampingName
            // 
            this.colStampingName.DataPropertyName = "StampingName";
            this.colStampingName.HeaderText = "Stamping Name";
            this.colStampingName.Name = "colStampingName";
            this.colStampingName.ReadOnly = true;
            this.colStampingName.Width = 98;
            // 
            // colBillingRate
            // 
            this.colBillingRate.DataPropertyName = "BillingRate";
            this.colBillingRate.HeaderText = "BillingRate";
            this.colBillingRate.Name = "colBillingRate";
            this.colBillingRate.ReadOnly = true;
            this.colBillingRate.Width = 82;
            // 
            // colProductValue
            // 
            this.colProductValue.DataPropertyName = "ProductValue";
            this.colProductValue.HeaderText = "Product Value";
            this.colProductValue.Name = "colProductValue";
            this.colProductValue.ReadOnly = true;
            this.colProductValue.Width = 91;
            // 
            // colReason
            // 
            this.colReason.DataPropertyName = "Reason";
            this.colReason.HeaderText = "Reason";
            this.colReason.Name = "colReason";
            this.colReason.ReadOnly = true;
            this.colReason.Width = 69;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "PendingRemark";
            this.colRemark.HeaderText = "PendingRemark";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 108;
            // 
            // colAlisCode
            // 
            this.colAlisCode.DataPropertyName = "AlisCode";
            this.colAlisCode.HeaderText = "Alis Code";
            this.colAlisCode.Name = "colAlisCode";
            this.colAlisCode.ReadOnly = true;
            this.colAlisCode.Visible = false;
            this.colAlisCode.Width = 70;
            // 
            // colProdCode
            // 
            this.colProdCode.DataPropertyName = "ProdCode";
            this.colProdCode.HeaderText = "Prod Code";
            this.colProdCode.Name = "colProdCode";
            this.colProdCode.ReadOnly = true;
            this.colProdCode.Visible = false;
            this.colProdCode.Width = 76;
            // 
            // colScheduleID
            // 
            this.colScheduleID.DataPropertyName = "ScheduleID";
            this.colScheduleID.HeaderText = "ScheduleID";
            this.colScheduleID.Name = "colScheduleID";
            this.colScheduleID.ReadOnly = true;
            this.colScheduleID.Visible = false;
            this.colScheduleID.Width = 88;
            // 
            // OrderHeaderRemark
            // 
            this.OrderHeaderRemark.DataPropertyName = "OrderHeaderRemark";
            this.OrderHeaderRemark.HeaderText = "OrderHeaderRemark";
            this.OrderHeaderRemark.Name = "OrderHeaderRemark";
            this.OrderHeaderRemark.ReadOnly = true;
            this.OrderHeaderRemark.Width = 130;
            // 
            // colDocFile1
            // 
            this.colDocFile1.DataPropertyName = "DocFile1";
            this.colDocFile1.HeaderText = "Document File";
            this.colDocFile1.Name = "colDocFile1";
            this.colDocFile1.ReadOnly = true;
            this.colDocFile1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDocFile1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDocFile1.Width = 92;
            // 
            // frmPendingOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 567);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPendingOrder";
            this.Text = "frmPendingOrder";
            this.Load += new System.EventHandler(this.frmPendingOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrderMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPendingOrderMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DateTimePicker dtpOrderRec;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlIOMNo;
        private System.Windows.Forms.Button btnSubmitIOM;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewImageColumn colView;
        private System.Windows.Forms.DataGridViewImageColumn colSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIOMNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIOMDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderAuthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduledate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPenQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDispThrough;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStampingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBillingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlisCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProdCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderHeaderRemark;
        private System.Windows.Forms.DataGridViewLinkColumn colDocFile1;
    }
}