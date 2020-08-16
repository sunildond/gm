namespace GlanMark
{
    partial class filterPendingReport
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
            this.lblReportName = new System.Windows.Forms.Label();
            this.chkDSMZSM = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAuth = new System.Windows.Forms.CheckBox();
            this.chkAuthorised = new System.Windows.Forms.CheckBox();
            this.listDSM_ZSM = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpToAuthDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromAuthDate = new System.Windows.Forms.DateTimePicker();
            this.chkAuthDate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpToDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.chkDeliveryDate = new System.Windows.Forms.CheckBox();
            this.listPartyCode = new System.Windows.Forms.ListBox();
            this.listIOMNO = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToIOMDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromIOMDate = new System.Windows.Forms.DateTimePicker();
            this.chkIOMDate = new System.Windows.Forms.CheckBox();
            this.chkPartyCode = new System.Windows.Forms.CheckBox();
            this.chkIomNo = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvQueryExec = new System.Windows.Forms.DataGridView();
            this.listPartyName = new System.Windows.Forms.ListBox();
            this.chkPartyName = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(186, 531);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(0, 13);
            this.lblReportName.TabIndex = 85;
            // 
            // chkDSMZSM
            // 
            this.chkDSMZSM.AutoSize = true;
            this.chkDSMZSM.Location = new System.Drawing.Point(268, 21);
            this.chkDSMZSM.Name = "chkDSMZSM";
            this.chkDSMZSM.Size = new System.Drawing.Size(76, 17);
            this.chkDSMZSM.TabIndex = 84;
            this.chkDSMZSM.Text = "DSM ZSM";
            this.chkDSMZSM.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPartyName);
            this.groupBox1.Controls.Add(this.listPartyName);
            this.groupBox1.Controls.Add(this.chkAuth);
            this.groupBox1.Controls.Add(this.chkAuthorised);
            this.groupBox1.Controls.Add(this.listDSM_ZSM);
            this.groupBox1.Controls.Add(this.chkDSMZSM);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpToAuthDate);
            this.groupBox1.Controls.Add(this.dtpFromAuthDate);
            this.groupBox1.Controls.Add(this.chkAuthDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpToDeliveryDate);
            this.groupBox1.Controls.Add(this.dtpFromDeliveryDate);
            this.groupBox1.Controls.Add(this.chkDeliveryDate);
            this.groupBox1.Controls.Add(this.listPartyCode);
            this.groupBox1.Controls.Add(this.listIOMNO);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpToIOMDate);
            this.groupBox1.Controls.Add(this.dtpFromIOMDate);
            this.groupBox1.Controls.Add(this.chkIOMDate);
            this.groupBox1.Controls.Add(this.chkPartyCode);
            this.groupBox1.Controls.Add(this.chkIomNo);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Location = new System.Drawing.Point(192, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(980, 220);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Detail Without Product";
            // 
            // chkAuth
            // 
            this.chkAuth.AutoSize = true;
            this.chkAuth.Location = new System.Drawing.Point(878, 45);
            this.chkAuth.Name = "chkAuth";
            this.chkAuth.Size = new System.Drawing.Size(84, 17);
            this.chkAuth.TabIndex = 93;
            this.chkAuth.Text = "IsAuthorised";
            this.chkAuth.UseVisualStyleBackColor = true;
            // 
            // chkAuthorised
            // 
            this.chkAuthorised.AutoSize = true;
            this.chkAuthorised.Location = new System.Drawing.Point(857, 25);
            this.chkAuthorised.Name = "chkAuthorised";
            this.chkAuthorised.Size = new System.Drawing.Size(76, 17);
            this.chkAuthorised.TabIndex = 92;
            this.chkAuthorised.Text = "Authorised";
            this.chkAuthorised.UseVisualStyleBackColor = true;
            // 
            // listDSM_ZSM
            // 
            this.listDSM_ZSM.FormattingEnabled = true;
            this.listDSM_ZSM.Location = new System.Drawing.Point(263, 46);
            this.listDSM_ZSM.Name = "listDSM_ZSM";
            this.listDSM_ZSM.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listDSM_ZSM.Size = new System.Drawing.Size(114, 160);
            this.listDSM_ZSM.TabIndex = 85;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(840, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 83;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(832, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "From";
            // 
            // dtpToAuthDate
            // 
            this.dtpToAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToAuthDate.Location = new System.Drawing.Point(867, 139);
            this.dtpToAuthDate.Name = "dtpToAuthDate";
            this.dtpToAuthDate.ShowCheckBox = true;
            this.dtpToAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToAuthDate.TabIndex = 82;
            // 
            // dtpFromAuthDate
            // 
            this.dtpFromAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromAuthDate.Location = new System.Drawing.Point(867, 112);
            this.dtpFromAuthDate.Name = "dtpFromAuthDate";
            this.dtpFromAuthDate.ShowCheckBox = true;
            this.dtpFromAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromAuthDate.TabIndex = 80;
            // 
            // chkAuthDate
            // 
            this.chkAuthDate.AutoSize = true;
            this.chkAuthDate.Location = new System.Drawing.Point(836, 88);
            this.chkAuthDate.Name = "chkAuthDate";
            this.chkAuthDate.Size = new System.Drawing.Size(113, 17);
            this.chkAuthDate.TabIndex = 79;
            this.chkAuthDate.Text = "Authorisation Date";
            this.chkAuthDate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(671, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(663, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "From";
            // 
            // dtpToDeliveryDate
            // 
            this.dtpToDeliveryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDeliveryDate.Location = new System.Drawing.Point(698, 176);
            this.dtpToDeliveryDate.Name = "dtpToDeliveryDate";
            this.dtpToDeliveryDate.ShowCheckBox = true;
            this.dtpToDeliveryDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToDeliveryDate.TabIndex = 75;
            // 
            // dtpFromDeliveryDate
            // 
            this.dtpFromDeliveryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDeliveryDate.Location = new System.Drawing.Point(698, 149);
            this.dtpFromDeliveryDate.Name = "dtpFromDeliveryDate";
            this.dtpFromDeliveryDate.ShowCheckBox = true;
            this.dtpFromDeliveryDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromDeliveryDate.TabIndex = 73;
            // 
            // chkDeliveryDate
            // 
            this.chkDeliveryDate.AutoSize = true;
            this.chkDeliveryDate.Location = new System.Drawing.Point(667, 125);
            this.chkDeliveryDate.Name = "chkDeliveryDate";
            this.chkDeliveryDate.Size = new System.Drawing.Size(90, 17);
            this.chkDeliveryDate.TabIndex = 72;
            this.chkDeliveryDate.Text = "Delivery Date";
            this.chkDeliveryDate.UseVisualStyleBackColor = true;
            // 
            // listPartyCode
            // 
            this.listPartyCode.FormattingEnabled = true;
            this.listPartyCode.Location = new System.Drawing.Point(138, 46);
            this.listPartyCode.Name = "listPartyCode";
            this.listPartyCode.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPartyCode.Size = new System.Drawing.Size(114, 160);
            this.listPartyCode.TabIndex = 71;
            // 
            // listIOMNO
            // 
            this.listIOMNO.FormattingEnabled = true;
            this.listIOMNO.Location = new System.Drawing.Point(12, 45);
            this.listIOMNO.Name = "listIOMNO";
            this.listIOMNO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listIOMNO.Size = new System.Drawing.Size(116, 160);
            this.listIOMNO.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(671, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(663, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "From";
            // 
            // dtpToIOMDate
            // 
            this.dtpToIOMDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToIOMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToIOMDate.Location = new System.Drawing.Point(698, 73);
            this.dtpToIOMDate.Name = "dtpToIOMDate";
            this.dtpToIOMDate.ShowCheckBox = true;
            this.dtpToIOMDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToIOMDate.TabIndex = 66;
            // 
            // dtpFromIOMDate
            // 
            this.dtpFromIOMDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromIOMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromIOMDate.Location = new System.Drawing.Point(698, 46);
            this.dtpFromIOMDate.Name = "dtpFromIOMDate";
            this.dtpFromIOMDate.ShowCheckBox = true;
            this.dtpFromIOMDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromIOMDate.TabIndex = 64;
            // 
            // chkIOMDate
            // 
            this.chkIOMDate.AutoSize = true;
            this.chkIOMDate.Location = new System.Drawing.Point(667, 22);
            this.chkIOMDate.Name = "chkIOMDate";
            this.chkIOMDate.Size = new System.Drawing.Size(72, 17);
            this.chkIOMDate.TabIndex = 62;
            this.chkIOMDate.Text = "IOM Date";
            this.chkIOMDate.UseVisualStyleBackColor = true;
            // 
            // chkPartyCode
            // 
            this.chkPartyCode.AutoSize = true;
            this.chkPartyCode.Location = new System.Drawing.Point(142, 21);
            this.chkPartyCode.Name = "chkPartyCode";
            this.chkPartyCode.Size = new System.Drawing.Size(78, 17);
            this.chkPartyCode.TabIndex = 60;
            this.chkPartyCode.Text = "Party Code";
            this.chkPartyCode.UseVisualStyleBackColor = true;
            // 
            // chkIomNo
            // 
            this.chkIomNo.AutoSize = true;
            this.chkIomNo.Location = new System.Drawing.Point(14, 22);
            this.chkIomNo.Name = "chkIomNo";
            this.chkIomNo.Size = new System.Drawing.Size(65, 17);
            this.chkIomNo.TabIndex = 59;
            this.chkIomNo.Text = "IOM NO";
            this.chkIomNo.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(877, 184);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(88, 27);
            this.btnFilter.TabIndex = 58;
            this.btnFilter.Text = "Submit";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Location = new System.Drawing.Point(1048, 521);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(124, 27);
            this.btnExportToExcel.TabIndex = 82;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(726, 531);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 86;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 11);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(174, 220);
            this.txtQuery.TabIndex = 84;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(12, 523);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(145, 27);
            this.btnReset.TabIndex = 83;
            this.btnReset.Text = "ExecuteQuery / Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvQueryExec
            // 
            this.dgvQueryExec.AllowUserToAddRows = false;
            this.dgvQueryExec.AllowUserToDeleteRows = false;
            this.dgvQueryExec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryExec.Location = new System.Drawing.Point(12, 245);
            this.dgvQueryExec.Name = "dgvQueryExec";
            this.dgvQueryExec.ReadOnly = true;
            this.dgvQueryExec.Size = new System.Drawing.Size(1160, 270);
            this.dgvQueryExec.TabIndex = 81;
            // 
            // listPartyName
            // 
            this.listPartyName.FormattingEnabled = true;
            this.listPartyName.Location = new System.Drawing.Point(387, 45);
            this.listPartyName.Name = "listPartyName";
            this.listPartyName.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPartyName.Size = new System.Drawing.Size(244, 160);
            this.listPartyName.TabIndex = 94;
            // 
            // chkPartyName
            // 
            this.chkPartyName.AutoSize = true;
            this.chkPartyName.Location = new System.Drawing.Point(388, 19);
            this.chkPartyName.Name = "chkPartyName";
            this.chkPartyName.Size = new System.Drawing.Size(81, 17);
            this.chkPartyName.TabIndex = 95;
            this.chkPartyName.Text = "Party Name";
            this.chkPartyName.UseVisualStyleBackColor = true;
            // 
            // filterPendingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.lblReportName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dgvQueryExec);
            this.Name = "filterPendingReport";
            this.Text = "filterPendingReport";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.CheckBox chkDSMZSM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listDSM_ZSM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpToAuthDate;
        private System.Windows.Forms.DateTimePicker dtpFromAuthDate;
        private System.Windows.Forms.CheckBox chkAuthDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpToDeliveryDate;
        private System.Windows.Forms.DateTimePicker dtpFromDeliveryDate;
        private System.Windows.Forms.CheckBox chkDeliveryDate;
        private System.Windows.Forms.ListBox listPartyCode;
        private System.Windows.Forms.ListBox listIOMNO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToIOMDate;
        private System.Windows.Forms.DateTimePicker dtpFromIOMDate;
        private System.Windows.Forms.CheckBox chkIOMDate;
        private System.Windows.Forms.CheckBox chkPartyCode;
        private System.Windows.Forms.CheckBox chkIomNo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvQueryExec;
        private System.Windows.Forms.CheckBox chkAuth;
        private System.Windows.Forms.CheckBox chkAuthorised;
        private System.Windows.Forms.CheckBox chkPartyName;
        private System.Windows.Forms.ListBox listPartyName;
    }
}