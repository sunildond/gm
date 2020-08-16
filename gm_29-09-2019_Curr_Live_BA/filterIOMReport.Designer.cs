namespace GlanMark
{
    partial class filterIOMReport
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
            this.lblReportName = new System.Windows.Forms.Label();
            this.dtpFromIOMDate = new System.Windows.Forms.DateTimePicker();
            this.chkIOMDate = new System.Windows.Forms.CheckBox();
            this.chkPartyCode = new System.Windows.Forms.CheckBox();
            this.chkIomNo = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPartyName = new System.Windows.Forms.CheckBox();
            this.listPartyName = new System.Windows.Forms.ListBox();
            this.chkAuth = new System.Windows.Forms.CheckBox();
            this.chkAuthorised = new System.Windows.Forms.CheckBox();
            this.cmdSubInstitution = new System.Windows.Forms.ComboBox();
            this.chkSubInstitution = new System.Windows.Forms.CheckBox();
            this.listDSM_ZSM = new System.Windows.Forms.ListBox();
            this.chkDSMZSM = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.dgvQueryExec = new System.Windows.Forms.DataGridView();
            this.btnSearchIOM = new System.Windows.Forms.Button();
            this.txtIOMNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(732, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 83;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(724, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "From";
            // 
            // dtpToAuthDate
            // 
            this.dtpToAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToAuthDate.Location = new System.Drawing.Point(759, 183);
            this.dtpToAuthDate.Name = "dtpToAuthDate";
            this.dtpToAuthDate.ShowCheckBox = true;
            this.dtpToAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToAuthDate.TabIndex = 82;
            // 
            // dtpFromAuthDate
            // 
            this.dtpFromAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromAuthDate.Location = new System.Drawing.Point(759, 156);
            this.dtpFromAuthDate.Name = "dtpFromAuthDate";
            this.dtpFromAuthDate.ShowCheckBox = true;
            this.dtpFromAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromAuthDate.TabIndex = 80;
            // 
            // chkAuthDate
            // 
            this.chkAuthDate.AutoSize = true;
            this.chkAuthDate.Location = new System.Drawing.Point(728, 132);
            this.chkAuthDate.Name = "chkAuthDate";
            this.chkAuthDate.Size = new System.Drawing.Size(113, 17);
            this.chkAuthDate.TabIndex = 79;
            this.chkAuthDate.Text = "Authorisation Date";
            this.chkAuthDate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(540, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "From";
            // 
            // dtpToDeliveryDate
            // 
            this.dtpToDeliveryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDeliveryDate.Location = new System.Drawing.Point(567, 183);
            this.dtpToDeliveryDate.Name = "dtpToDeliveryDate";
            this.dtpToDeliveryDate.ShowCheckBox = true;
            this.dtpToDeliveryDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToDeliveryDate.TabIndex = 75;
            // 
            // dtpFromDeliveryDate
            // 
            this.dtpFromDeliveryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDeliveryDate.Location = new System.Drawing.Point(567, 156);
            this.dtpFromDeliveryDate.Name = "dtpFromDeliveryDate";
            this.dtpFromDeliveryDate.ShowCheckBox = true;
            this.dtpFromDeliveryDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromDeliveryDate.TabIndex = 73;
            // 
            // chkDeliveryDate
            // 
            this.chkDeliveryDate.AutoSize = true;
            this.chkDeliveryDate.Location = new System.Drawing.Point(536, 132);
            this.chkDeliveryDate.Name = "chkDeliveryDate";
            this.chkDeliveryDate.Size = new System.Drawing.Size(90, 17);
            this.chkDeliveryDate.TabIndex = 72;
            this.chkDeliveryDate.Text = "Delivery Date";
            this.chkDeliveryDate.UseVisualStyleBackColor = true;
            // 
            // listPartyCode
            // 
            this.listPartyCode.FormattingEnabled = true;
            this.listPartyCode.Location = new System.Drawing.Point(116, 46);
            this.listPartyCode.Name = "listPartyCode";
            this.listPartyCode.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPartyCode.Size = new System.Drawing.Size(99, 160);
            this.listPartyCode.TabIndex = 71;
            // 
            // listIOMNO
            // 
            this.listIOMNO.FormattingEnabled = true;
            this.listIOMNO.Location = new System.Drawing.Point(9, 45);
            this.listIOMNO.Name = "listIOMNO";
            this.listIOMNO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listIOMNO.Size = new System.Drawing.Size(100, 160);
            this.listIOMNO.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(533, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "From";
            // 
            // dtpToIOMDate
            // 
            this.dtpToIOMDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToIOMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToIOMDate.Location = new System.Drawing.Point(568, 73);
            this.dtpToIOMDate.Name = "dtpToIOMDate";
            this.dtpToIOMDate.ShowCheckBox = true;
            this.dtpToIOMDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToIOMDate.TabIndex = 66;
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(186, 531);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(0, 13);
            this.lblReportName.TabIndex = 78;
            // 
            // dtpFromIOMDate
            // 
            this.dtpFromIOMDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromIOMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromIOMDate.Location = new System.Drawing.Point(568, 46);
            this.dtpFromIOMDate.Name = "dtpFromIOMDate";
            this.dtpFromIOMDate.ShowCheckBox = true;
            this.dtpFromIOMDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromIOMDate.TabIndex = 64;
            // 
            // chkIOMDate
            // 
            this.chkIOMDate.AutoSize = true;
            this.chkIOMDate.Location = new System.Drawing.Point(537, 22);
            this.chkIOMDate.Name = "chkIOMDate";
            this.chkIOMDate.Size = new System.Drawing.Size(72, 17);
            this.chkIOMDate.TabIndex = 62;
            this.chkIOMDate.Text = "IOM Date";
            this.chkIOMDate.UseVisualStyleBackColor = true;
            // 
            // chkPartyCode
            // 
            this.chkPartyCode.AutoSize = true;
            this.chkPartyCode.Location = new System.Drawing.Point(125, 21);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtIOMNo);
            this.groupBox1.Controls.Add(this.btnSearchIOM);
            this.groupBox1.Controls.Add(this.chkPartyName);
            this.groupBox1.Controls.Add(this.listPartyName);
            this.groupBox1.Controls.Add(this.chkAuth);
            this.groupBox1.Controls.Add(this.txtQuery);
            this.groupBox1.Controls.Add(this.chkAuthorised);
            this.groupBox1.Controls.Add(this.cmdSubInstitution);
            this.groupBox1.Controls.Add(this.chkSubInstitution);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1160, 220);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Detail Without Product";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkPartyName
            // 
            this.chkPartyName.AutoSize = true;
            this.chkPartyName.Location = new System.Drawing.Point(351, 22);
            this.chkPartyName.Name = "chkPartyName";
            this.chkPartyName.Size = new System.Drawing.Size(81, 17);
            this.chkPartyName.TabIndex = 93;
            this.chkPartyName.Text = "Party Name";
            this.chkPartyName.UseVisualStyleBackColor = true;
            // 
            // listPartyName
            // 
            this.listPartyName.FormattingEnabled = true;
            this.listPartyName.Location = new System.Drawing.Point(342, 45);
            this.listPartyName.Name = "listPartyName";
            this.listPartyName.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPartyName.Size = new System.Drawing.Size(165, 160);
            this.listPartyName.TabIndex = 92;
            // 
            // chkAuth
            // 
            this.chkAuth.AutoSize = true;
            this.chkAuth.Location = new System.Drawing.Point(932, 152);
            this.chkAuth.Name = "chkAuth";
            this.chkAuth.Size = new System.Drawing.Size(84, 17);
            this.chkAuth.TabIndex = 91;
            this.chkAuth.Text = "IsAuthorised";
            this.chkAuth.UseVisualStyleBackColor = true;
            // 
            // chkAuthorised
            // 
            this.chkAuthorised.AutoSize = true;
            this.chkAuthorised.Location = new System.Drawing.Point(911, 132);
            this.chkAuthorised.Name = "chkAuthorised";
            this.chkAuthorised.Size = new System.Drawing.Size(76, 17);
            this.chkAuthorised.TabIndex = 90;
            this.chkAuthorised.Text = "Authorised";
            this.chkAuthorised.UseVisualStyleBackColor = true;
            // 
            // cmdSubInstitution
            // 
            this.cmdSubInstitution.FormattingEnabled = true;
            this.cmdSubInstitution.Location = new System.Drawing.Point(727, 49);
            this.cmdSubInstitution.Name = "cmdSubInstitution";
            this.cmdSubInstitution.Size = new System.Drawing.Size(171, 21);
            this.cmdSubInstitution.TabIndex = 89;
            // 
            // chkSubInstitution
            // 
            this.chkSubInstitution.AutoSize = true;
            this.chkSubInstitution.Location = new System.Drawing.Point(727, 26);
            this.chkSubInstitution.Name = "chkSubInstitution";
            this.chkSubInstitution.Size = new System.Drawing.Size(90, 17);
            this.chkSubInstitution.TabIndex = 88;
            this.chkSubInstitution.Text = "SubInstitution";
            this.chkSubInstitution.UseVisualStyleBackColor = true;
            // 
            // listDSM_ZSM
            // 
            this.listDSM_ZSM.FormattingEnabled = true;
            this.listDSM_ZSM.Location = new System.Drawing.Point(222, 46);
            this.listDSM_ZSM.Name = "listDSM_ZSM";
            this.listDSM_ZSM.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listDSM_ZSM.Size = new System.Drawing.Size(114, 160);
            this.listDSM_ZSM.TabIndex = 85;
            // 
            // chkDSMZSM
            // 
            this.chkDSMZSM.AutoSize = true;
            this.chkDSMZSM.Location = new System.Drawing.Point(227, 21);
            this.chkDSMZSM.Name = "chkDSMZSM";
            this.chkDSMZSM.Size = new System.Drawing.Size(76, 17);
            this.chkDSMZSM.TabIndex = 84;
            this.chkDSMZSM.Text = "DSM ZSM";
            this.chkDSMZSM.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(1055, 181);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(88, 27);
            this.btnFilter.TabIndex = 58;
            this.btnFilter.Text = "Submit";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(726, 531);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 79;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(727, 76);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(127, 30);
            this.txtQuery.TabIndex = 77;
            this.txtQuery.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(12, 523);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(145, 27);
            this.btnReset.TabIndex = 76;
            this.btnReset.Text = "ExecuteQuery / Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Location = new System.Drawing.Point(1048, 521);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(124, 27);
            this.btnExportToExcel.TabIndex = 75;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
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
            this.dgvQueryExec.TabIndex = 74;
            // 
            // btnSearchIOM
            // 
            this.btnSearchIOM.Location = new System.Drawing.Point(1068, 47);
            this.btnSearchIOM.Name = "btnSearchIOM";
            this.btnSearchIOM.Size = new System.Drawing.Size(75, 23);
            this.btnSearchIOM.TabIndex = 94;
            this.btnSearchIOM.Text = "Submit";
            this.btnSearchIOM.UseVisualStyleBackColor = true;
            this.btnSearchIOM.Click += new System.EventHandler(this.btnSearchIOM_Click);
            // 
            // txtIOMNo
            // 
            this.txtIOMNo.Location = new System.Drawing.Point(962, 49);
            this.txtIOMNo.Name = "txtIOMNo";
            this.txtIOMNo.Size = new System.Drawing.Size(100, 20);
            this.txtIOMNo.TabIndex = 95;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(964, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 96;
            this.label7.Text = "IOM Number";
            // 
            // filterIOMReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1184, 562);
            this.Controls.Add(this.lblReportName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.dgvQueryExec);
            this.Name = "filterIOMReport";
            this.Text = "filterIOMReport";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.DateTimePicker dtpFromIOMDate;
        private System.Windows.Forms.CheckBox chkIOMDate;
        private System.Windows.Forms.CheckBox chkPartyCode;
        private System.Windows.Forms.CheckBox chkIomNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.DataGridView dgvQueryExec;
        private System.Windows.Forms.ListBox listDSM_ZSM;
        private System.Windows.Forms.CheckBox chkDSMZSM;
        private System.Windows.Forms.ComboBox cmdSubInstitution;
        private System.Windows.Forms.CheckBox chkSubInstitution;
        private System.Windows.Forms.CheckBox chkAuthorised;
        private System.Windows.Forms.CheckBox chkAuth;
        private System.Windows.Forms.CheckBox chkPartyName;
        private System.Windows.Forms.ListBox listPartyName;
        private System.Windows.Forms.TextBox txtIOMNo;
        private System.Windows.Forms.Button btnSearchIOM;
        private System.Windows.Forms.Label label7;
    }
}