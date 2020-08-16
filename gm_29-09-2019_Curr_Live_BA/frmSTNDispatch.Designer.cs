namespace gm
{
    partial class frmSTNDispatch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkEdit = new System.Windows.Forms.CheckBox();
            this.chkAdd = new System.Windows.Forms.CheckBox();
            this.gbDispatchDetail = new System.Windows.Forms.GroupBox();
            this.dgvBillingDoc = new System.Windows.Forms.DataGridView();
            this.colAuthorise = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colView = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkauth = new System.Windows.Forms.CheckBox();
            this.lbliomno = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpTentativeDelDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCases = new System.Windows.Forms.TextBox();
            this.txtDelivery = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpDispositDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpInvDispDelDate = new System.Windows.Forms.DateTimePicker();
            this.txtInvTransporter = new System.Windows.Forms.TextBox();
            this.txtInvLRNo = new System.Windows.Forms.TextBox();
            this.txtCFARemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInvDispLRDate = new System.Windows.Forms.DateTimePicker();
            this.txtHORemark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.errorDispatch = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkBillingDoc = new System.Windows.Forms.CheckedListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.chkIOMNo = new System.Windows.Forms.CheckedListBox();
            this.btnIOMNo = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnBillingDoc = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.ddlIOMNO = new System.Windows.Forms.ComboBox();
            this.ddlPreInvoice = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAllAuthorise = new System.Windows.Forms.Button();
            this.gbDispatchDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingDoc)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorDispatch)).BeginInit();
            this.SuspendLayout();
            // 
            // chkEdit
            // 
            this.chkEdit.AutoSize = true;
            this.chkEdit.Location = new System.Drawing.Point(95, 59);
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.Size = new System.Drawing.Size(44, 17);
            this.chkEdit.TabIndex = 30;
            this.chkEdit.Text = "Edit";
            this.chkEdit.UseVisualStyleBackColor = true;
            this.chkEdit.CheckedChanged += new System.EventHandler(this.chkEdit_CheckedChanged);
            // 
            // chkAdd
            // 
            this.chkAdd.AutoSize = true;
            this.chkAdd.Location = new System.Drawing.Point(33, 59);
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.Size = new System.Drawing.Size(45, 17);
            this.chkAdd.TabIndex = 29;
            this.chkAdd.Text = "Add";
            this.chkAdd.UseVisualStyleBackColor = true;
            this.chkAdd.CheckedChanged += new System.EventHandler(this.chkAdd_CheckedChanged);
            // 
            // gbDispatchDetail
            // 
            this.gbDispatchDetail.Controls.Add(this.dgvBillingDoc);
            this.gbDispatchDetail.Location = new System.Drawing.Point(12, 115);
            this.gbDispatchDetail.Name = "gbDispatchDetail";
            this.gbDispatchDetail.Size = new System.Drawing.Size(1189, 192);
            this.gbDispatchDetail.TabIndex = 28;
            this.gbDispatchDetail.TabStop = false;
            this.gbDispatchDetail.Text = "STN Dispatch Detail";
            this.gbDispatchDetail.Enter += new System.EventHandler(this.gbDispatchDetail_Enter);
            // 
            // dgvBillingDoc
            // 
            this.dgvBillingDoc.AllowUserToAddRows = false;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(241)))), ((int)(((byte)(214)))));
            this.dgvBillingDoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.dgvBillingDoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBillingDoc.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvBillingDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBillingDoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dgvBillingDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillingDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAuthorise,
            this.colView,
            this.colEdit});
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBillingDoc.DefaultCellStyle = dataGridViewCellStyle35;
            this.dgvBillingDoc.EnableHeadersVisualStyles = false;
            this.dgvBillingDoc.GridColor = System.Drawing.SystemColors.Control;
            this.dgvBillingDoc.Location = new System.Drawing.Point(6, 19);
            this.dgvBillingDoc.MultiSelect = false;
            this.dgvBillingDoc.Name = "dgvBillingDoc";
            this.dgvBillingDoc.ReadOnly = true;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBillingDoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.dgvBillingDoc.RowHeadersVisible = false;
            this.dgvBillingDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBillingDoc.Size = new System.Drawing.Size(1177, 165);
            this.dgvBillingDoc.TabIndex = 20;
            this.dgvBillingDoc.VirtualMode = true;
            this.dgvBillingDoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBillingDoc_CellContentClick);
            // 
            // colAuthorise
            // 
            this.colAuthorise.HeaderText = "Authorise";
            this.colAuthorise.Name = "colAuthorise";
            this.colAuthorise.ReadOnly = true;
            this.colAuthorise.Text = "Authorise";
            this.colAuthorise.UseColumnTextForButtonValue = true;
            this.colAuthorise.Width = 57;
            // 
            // colView
            // 
            this.colView.HeaderText = "View";
            this.colView.Image = global::gm.Properties.Resources.viewDetails;
            this.colView.Name = "colView";
            this.colView.ReadOnly = true;
            this.colView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colView.Width = 55;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "Edit";
            this.colEdit.Image = global::gm.Properties.Resources.edit;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.ToolTipText = "Edit";
            this.colEdit.Width = 50;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(15, 324);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1183, 233);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkauth);
            this.tabPage1.Controls.Add(this.lbliomno);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.dtpTentativeDelDate);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtCases);
            this.tabPage1.Controls.Add(this.txtDelivery);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.dtpDispositDate);
            this.tabPage1.Controls.Add(this.dtpDate);
            this.tabPage1.Controls.Add(this.txtChequeNo);
            this.tabPage1.Controls.Add(this.txtAmount);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.dtpInvDispDelDate);
            this.tabPage1.Controls.Add(this.txtInvTransporter);
            this.tabPage1.Controls.Add(this.txtInvLRNo);
            this.tabPage1.Controls.Add(this.txtCFARemark);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dtpInvDispLRDate);
            this.tabPage1.Controls.Add(this.txtHORemark);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1175, 207);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add/Edit Dispatch Detail";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkauth
            // 
            this.chkauth.AutoSize = true;
            this.chkauth.Location = new System.Drawing.Point(706, 50);
            this.chkauth.Name = "chkauth";
            this.chkauth.Size = new System.Drawing.Size(70, 17);
            this.chkauth.TabIndex = 53;
            this.chkauth.Text = "Authrised";
            this.chkauth.UseVisualStyleBackColor = true;
            // 
            // lbliomno
            // 
            this.lbliomno.AutoSize = true;
            this.lbliomno.Location = new System.Drawing.Point(764, 19);
            this.lbliomno.Name = "lbliomno";
            this.lbliomno.Size = new System.Drawing.Size(0, 13);
            this.lbliomno.TabIndex = 52;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(700, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 51;
            this.label14.Text = "IOMNO :-";
            // 
            // dtpTentativeDelDate
            // 
            this.dtpTentativeDelDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTentativeDelDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTentativeDelDate.Location = new System.Drawing.Point(481, 162);
            this.dtpTentativeDelDate.Name = "dtpTentativeDelDate";
            this.dtpTentativeDelDate.ShowCheckBox = true;
            this.dtpTentativeDelDate.Size = new System.Drawing.Size(98, 20);
            this.dtpTentativeDelDate.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(381, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 49;
            this.label13.Text = "TentativeDel Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Cases";
            // 
            // txtCases
            // 
            this.txtCases.Location = new System.Drawing.Point(481, 136);
            this.txtCases.Name = "txtCases";
            this.txtCases.Size = new System.Drawing.Size(153, 20);
            this.txtCases.TabIndex = 46;
            // 
            // txtDelivery
            // 
            this.txtDelivery.Location = new System.Drawing.Point(175, 21);
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.ReadOnly = true;
            this.txtDelivery.Size = new System.Drawing.Size(151, 20);
            this.txtDelivery.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(123, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Delivery";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(814, 158);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 31);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(679, 91);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 43;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(683, 158);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 31);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpDispositDate
            // 
            this.dtpDispositDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDispositDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDispositDate.Location = new System.Drawing.Point(481, 110);
            this.dtpDispositDate.Name = "dtpDispositDate";
            this.dtpDispositDate.ShowCheckBox = true;
            this.dtpDispositDate.Size = new System.Drawing.Size(98, 20);
            this.dtpDispositDate.TabIndex = 41;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(481, 49);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowCheckBox = true;
            this.dtpDate.Size = new System.Drawing.Size(98, 20);
            this.dtpDate.TabIndex = 40;
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Location = new System.Drawing.Point(481, 19);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(153, 20);
            this.txtChequeNo.TabIndex = 39;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(481, 81);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(153, 20);
            this.txtAmount.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(406, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Deposit Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(413, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Cheque No.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(445, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(432, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Amount";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // dtpInvDispDelDate
            // 
            this.dtpInvDispDelDate.CustomFormat = "dd/MM/yyyy";
            this.dtpInvDispDelDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvDispDelDate.Location = new System.Drawing.Point(175, 176);
            this.dtpInvDispDelDate.Name = "dtpInvDispDelDate";
            this.dtpInvDispDelDate.ShowCheckBox = true;
            this.dtpInvDispDelDate.Size = new System.Drawing.Size(98, 20);
            this.dtpInvDispDelDate.TabIndex = 33;
            // 
            // txtInvTransporter
            // 
            this.txtInvTransporter.Location = new System.Drawing.Point(175, 101);
            this.txtInvTransporter.Name = "txtInvTransporter";
            this.txtInvTransporter.Size = new System.Drawing.Size(151, 20);
            this.txtInvTransporter.TabIndex = 32;
            // 
            // txtInvLRNo
            // 
            this.txtInvLRNo.Location = new System.Drawing.Point(175, 127);
            this.txtInvLRNo.Name = "txtInvLRNo";
            this.txtInvLRNo.Size = new System.Drawing.Size(151, 20);
            this.txtInvLRNo.TabIndex = 31;
            // 
            // txtCFARemark
            // 
            this.txtCFARemark.Location = new System.Drawing.Point(175, 73);
            this.txtCFARemark.Name = "txtCFARemark";
            this.txtCFARemark.Size = new System.Drawing.Size(151, 20);
            this.txtCFARemark.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Dispatch Delete Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Dispatch LR Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "LR No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Invoice Transporter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "CWH Remarks";
            // 
            // dtpInvDispLRDate
            // 
            this.dtpInvDispLRDate.CustomFormat = "dd/MM/yyyy";
            this.dtpInvDispLRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvDispLRDate.Location = new System.Drawing.Point(175, 152);
            this.dtpInvDispLRDate.Name = "dtpInvDispLRDate";
            this.dtpInvDispLRDate.ShowCheckBox = true;
            this.dtpInvDispLRDate.Size = new System.Drawing.Size(98, 20);
            this.dtpInvDispLRDate.TabIndex = 24;
            // 
            // txtHORemark
            // 
            this.txtHORemark.Location = new System.Drawing.Point(175, 47);
            this.txtHORemark.Name = "txtHORemark";
            this.txtHORemark.Size = new System.Drawing.Size(151, 20);
            this.txtHORemark.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "HO Remarks";
            // 
            // errorDispatch
            // 
            this.errorDispatch.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorDispatch.ContainerControl = this;
            // 
            // chkBillingDoc
            // 
            this.chkBillingDoc.FormattingEnabled = true;
            this.chkBillingDoc.Location = new System.Drawing.Point(643, 12);
            this.chkBillingDoc.Name = "chkBillingDoc";
            this.chkBillingDoc.Size = new System.Drawing.Size(158, 94);
            this.chkBillingDoc.TabIndex = 63;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(1104, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 31);
            this.btnReset.TabIndex = 68;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chkIOMNo
            // 
            this.chkIOMNo.FormattingEnabled = true;
            this.chkIOMNo.Location = new System.Drawing.Point(232, 12);
            this.chkIOMNo.Name = "chkIOMNo";
            this.chkIOMNo.Size = new System.Drawing.Size(158, 94);
            this.chkIOMNo.TabIndex = 62;
            // 
            // btnIOMNo
            // 
            this.btnIOMNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIOMNo.Location = new System.Drawing.Point(396, 19);
            this.btnIOMNo.Name = "btnIOMNo";
            this.btnIOMNo.Size = new System.Drawing.Size(97, 31);
            this.btnIOMNo.TabIndex = 67;
            this.btnIOMNo.Text = "Submit";
            this.btnIOMNo.UseVisualStyleBackColor = true;
            this.btnIOMNo.Click += new System.EventHandler(this.btnIOMNo_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(544, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 13);
            this.label16.TabIndex = 66;
            this.label16.Text = "Billing Document:- ";
            // 
            // btnBillingDoc
            // 
            this.btnBillingDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillingDoc.Location = new System.Drawing.Point(807, 19);
            this.btnBillingDoc.Name = "btnBillingDoc";
            this.btnBillingDoc.Size = new System.Drawing.Size(97, 31);
            this.btnBillingDoc.TabIndex = 64;
            this.btnBillingDoc.Text = "Submit";
            this.btnBillingDoc.UseVisualStyleBackColor = true;
            this.btnBillingDoc.Click += new System.EventHandler(this.btnBillingDoc_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(174, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 65;
            this.label15.Text = "IOMNO :-";
            // 
            // ddlIOMNO
            // 
            this.ddlIOMNO.FormattingEnabled = true;
            this.ddlIOMNO.Location = new System.Drawing.Point(396, 68);
            this.ddlIOMNO.Name = "ddlIOMNO";
            this.ddlIOMNO.Size = new System.Drawing.Size(159, 21);
            this.ddlIOMNO.TabIndex = 70;
            // 
            // ddlPreInvoice
            // 
            this.ddlPreInvoice.FormattingEnabled = true;
            this.ddlPreInvoice.Location = new System.Drawing.Point(809, 68);
            this.ddlPreInvoice.Name = "ddlPreInvoice";
            this.ddlPreInvoice.Size = new System.Drawing.Size(181, 21);
            this.ddlPreInvoice.TabIndex = 71;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(3, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(132, 15);
            this.label17.TabIndex = 72;
            this.label17.Text = "STN / IBS  Dispatch";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IOMNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "IOM No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 52;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "BillingDocument";
            this.dataGridViewTextBoxColumn2.HeaderText = "Billing Document";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 102;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PartyCode";
            this.dataGridViewTextBoxColumn3.HeaderText = "Party Code";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 78;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Plnt";
            this.dataGridViewTextBoxColumn5.HeaderText = "Plnt";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "BillingDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "Billing Date";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 79;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Priority";
            this.dataGridViewTextBoxColumn7.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 63;
            // 
            // btnAllAuthorise
            // 
            this.btnAllAuthorise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllAuthorise.Location = new System.Drawing.Point(1104, 68);
            this.btnAllAuthorise.Name = "btnAllAuthorise";
            this.btnAllAuthorise.Size = new System.Drawing.Size(98, 30);
            this.btnAllAuthorise.TabIndex = 73;
            this.btnAllAuthorise.Text = "All Authorise";
            this.btnAllAuthorise.UseVisualStyleBackColor = true;
            this.btnAllAuthorise.Click += new System.EventHandler(this.btnAllAuthorise_Click);
            // 
            // frmSTNDispatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1213, 566);
            this.Controls.Add(this.btnAllAuthorise);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.ddlPreInvoice);
            this.Controls.Add(this.ddlIOMNO);
            this.Controls.Add(this.chkBillingDoc);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.chkIOMNo);
            this.Controls.Add(this.btnIOMNo);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnBillingDoc);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.chkEdit);
            this.Controls.Add(this.chkAdd);
            this.Controls.Add(this.gbDispatchDetail);
            this.Name = "frmSTNDispatch";
            this.Text = "frmSTNDispatch";
            this.Load += new System.EventHandler(this.frmSTNDispatch_Load);
            this.gbDispatchDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingDoc)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorDispatch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEdit;
        private System.Windows.Forms.CheckBox chkAdd;
        private System.Windows.Forms.GroupBox gbDispatchDetail;
        private System.Windows.Forms.DataGridView dgvBillingDoc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtDelivery;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpDispositDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpInvDispDelDate;
        private System.Windows.Forms.TextBox txtInvTransporter;
        private System.Windows.Forms.TextBox txtInvLRNo;
        private System.Windows.Forms.TextBox txtCFARemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInvDispLRDate;
        private System.Windows.Forms.TextBox txtHORemark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorDispatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TextBox txtCases;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTentativeDelDate;
        private System.Windows.Forms.Label lbliomno;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkauth;
        private System.Windows.Forms.CheckedListBox chkBillingDoc;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckedListBox chkIOMNo;
        private System.Windows.Forms.Button btnIOMNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnBillingDoc;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox ddlIOMNO;
        private System.Windows.Forms.ComboBox ddlPreInvoice;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewButtonColumn colAuthorise;
        private System.Windows.Forms.DataGridViewImageColumn colView;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.Button btnAllAuthorise;
    }
}