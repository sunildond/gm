namespace GlanMark
{
    partial class filterSTNDispatch
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
            this.chkDSMZSM = new System.Windows.Forms.CheckBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.listDSM_ZSM = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpToAuthDate = new System.Windows.Forms.DateTimePicker();
            this.chkAuthDate = new System.Windows.Forms.CheckBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.dtpFromAuthDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtpToDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.dtpFromDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.chkDeliveryDate = new System.Windows.Forms.CheckBox();
            this.lblReportName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSTNLocation = new System.Windows.Forms.ComboBox();
            this.chkSTNLocation = new System.Windows.Forms.CheckBox();
            this.chkSTNNo = new System.Windows.Forms.CheckBox();
            this.listSTNNo = new System.Windows.Forms.ListBox();
            this.cmdLocationCode = new System.Windows.Forms.ComboBox();
            this.chkLocation = new System.Windows.Forms.CheckBox();
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
            this.dgvQueryExec = new System.Windows.Forms.DataGridView();
            this.listPartyName = new System.Windows.Forms.ListBox();
            this.chkPartyName = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).BeginInit();
            this.SuspendLayout();
            // 
            // chkDSMZSM
            // 
            this.chkDSMZSM.AutoSize = true;
            this.chkDSMZSM.Location = new System.Drawing.Point(363, 22);
            this.chkDSMZSM.Name = "chkDSMZSM";
            this.chkDSMZSM.Size = new System.Drawing.Size(76, 17);
            this.chkDSMZSM.TabIndex = 84;
            this.chkDSMZSM.Text = "DSM ZSM";
            this.chkDSMZSM.UseVisualStyleBackColor = true;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 11);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(145, 220);
            this.txtQuery.TabIndex = 91;
            // 
            // listDSM_ZSM
            // 
            this.listDSM_ZSM.FormattingEnabled = true;
            this.listDSM_ZSM.Location = new System.Drawing.Point(354, 46);
            this.listDSM_ZSM.Name = "listDSM_ZSM";
            this.listDSM_ZSM.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listDSM_ZSM.Size = new System.Drawing.Size(103, 160);
            this.listDSM_ZSM.TabIndex = 85;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(767, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 83;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(759, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "From";
            // 
            // dtpToAuthDate
            // 
            this.dtpToAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToAuthDate.Location = new System.Drawing.Point(794, 187);
            this.dtpToAuthDate.Name = "dtpToAuthDate";
            this.dtpToAuthDate.ShowCheckBox = true;
            this.dtpToAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToAuthDate.TabIndex = 82;
            // 
            // chkAuthDate
            // 
            this.chkAuthDate.AutoSize = true;
            this.chkAuthDate.Location = new System.Drawing.Point(763, 136);
            this.chkAuthDate.Name = "chkAuthDate";
            this.chkAuthDate.Size = new System.Drawing.Size(113, 17);
            this.chkAuthDate.TabIndex = 79;
            this.chkAuthDate.Text = "Authorisation Date";
            this.chkAuthDate.UseVisualStyleBackColor = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(726, 531);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 93;
            // 
            // dtpFromAuthDate
            // 
            this.dtpFromAuthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromAuthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromAuthDate.Location = new System.Drawing.Point(794, 160);
            this.dtpFromAuthDate.Name = "dtpFromAuthDate";
            this.dtpFromAuthDate.ShowCheckBox = true;
            this.dtpFromAuthDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromAuthDate.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(621, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(613, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "From";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(12, 523);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(145, 27);
            this.btnReset.TabIndex = 90;
            this.btnReset.Text = "ExecuteQuery / Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtpToDeliveryDate
            // 
            this.dtpToDeliveryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDeliveryDate.Location = new System.Drawing.Point(648, 187);
            this.dtpToDeliveryDate.Name = "dtpToDeliveryDate";
            this.dtpToDeliveryDate.ShowCheckBox = true;
            this.dtpToDeliveryDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToDeliveryDate.TabIndex = 75;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Location = new System.Drawing.Point(1048, 521);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(124, 27);
            this.btnExportToExcel.TabIndex = 89;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // dtpFromDeliveryDate
            // 
            this.dtpFromDeliveryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDeliveryDate.Location = new System.Drawing.Point(648, 160);
            this.dtpFromDeliveryDate.Name = "dtpFromDeliveryDate";
            this.dtpFromDeliveryDate.ShowCheckBox = true;
            this.dtpFromDeliveryDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromDeliveryDate.TabIndex = 73;
            // 
            // chkDeliveryDate
            // 
            this.chkDeliveryDate.AutoSize = true;
            this.chkDeliveryDate.Location = new System.Drawing.Point(617, 136);
            this.chkDeliveryDate.Name = "chkDeliveryDate";
            this.chkDeliveryDate.Size = new System.Drawing.Size(90, 17);
            this.chkDeliveryDate.TabIndex = 72;
            this.chkDeliveryDate.Text = "Delivery Date";
            this.chkDeliveryDate.UseVisualStyleBackColor = true;
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(186, 531);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(0, 13);
            this.lblReportName.TabIndex = 92;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPartyName);
            this.groupBox1.Controls.Add(this.listPartyName);
            this.groupBox1.Controls.Add(this.cmbSTNLocation);
            this.groupBox1.Controls.Add(this.chkSTNLocation);
            this.groupBox1.Controls.Add(this.chkSTNNo);
            this.groupBox1.Controls.Add(this.listSTNNo);
            this.groupBox1.Controls.Add(this.cmdLocationCode);
            this.groupBox1.Controls.Add(this.chkLocation);
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
            this.groupBox1.Location = new System.Drawing.Point(163, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1009, 220);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Detail Without Product";
            // 
            // cmbSTNLocation
            // 
            this.cmbSTNLocation.FormattingEnabled = true;
            this.cmbSTNLocation.Location = new System.Drawing.Point(761, 99);
            this.cmbSTNLocation.Name = "cmbSTNLocation";
            this.cmbSTNLocation.Size = new System.Drawing.Size(155, 21);
            this.cmbSTNLocation.TabIndex = 91;
            // 
            // chkSTNLocation
            // 
            this.chkSTNLocation.AutoSize = true;
            this.chkSTNLocation.Location = new System.Drawing.Point(761, 76);
            this.chkSTNLocation.Name = "chkSTNLocation";
            this.chkSTNLocation.Size = new System.Drawing.Size(89, 17);
            this.chkSTNLocation.TabIndex = 90;
            this.chkSTNLocation.Text = "STNLocation";
            this.chkSTNLocation.UseVisualStyleBackColor = true;
            // 
            // chkSTNNo
            // 
            this.chkSTNNo.AutoSize = true;
            this.chkSTNNo.Location = new System.Drawing.Point(132, 22);
            this.chkSTNNo.Name = "chkSTNNo";
            this.chkSTNNo.Size = new System.Drawing.Size(65, 17);
            this.chkSTNNo.TabIndex = 88;
            this.chkSTNNo.Text = "STN No";
            this.chkSTNNo.UseVisualStyleBackColor = true;
            // 
            // listSTNNo
            // 
            this.listSTNNo.FormattingEnabled = true;
            this.listSTNNo.Location = new System.Drawing.Point(126, 46);
            this.listSTNNo.Name = "listSTNNo";
            this.listSTNNo.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listSTNNo.Size = new System.Drawing.Size(103, 160);
            this.listSTNNo.TabIndex = 89;
            // 
            // cmdLocationCode
            // 
            this.cmdLocationCode.FormattingEnabled = true;
            this.cmdLocationCode.Location = new System.Drawing.Point(761, 43);
            this.cmdLocationCode.Name = "cmdLocationCode";
            this.cmdLocationCode.Size = new System.Drawing.Size(155, 21);
            this.cmdLocationCode.TabIndex = 87;
            // 
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.Location = new System.Drawing.Point(761, 20);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(92, 17);
            this.chkLocation.TabIndex = 86;
            this.chkLocation.Text = "LocationCode";
            this.chkLocation.UseVisualStyleBackColor = true;
            // 
            // listPartyCode
            // 
            this.listPartyCode.FormattingEnabled = true;
            this.listPartyCode.Location = new System.Drawing.Point(238, 46);
            this.listPartyCode.Name = "listPartyCode";
            this.listPartyCode.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPartyCode.Size = new System.Drawing.Size(107, 160);
            this.listPartyCode.TabIndex = 71;
            // 
            // listIOMNO
            // 
            this.listIOMNO.FormattingEnabled = true;
            this.listIOMNO.Location = new System.Drawing.Point(11, 45);
            this.listIOMNO.Name = "listIOMNO";
            this.listIOMNO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listIOMNO.Size = new System.Drawing.Size(107, 160);
            this.listIOMNO.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(614, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "From";
            // 
            // dtpToIOMDate
            // 
            this.dtpToIOMDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToIOMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToIOMDate.Location = new System.Drawing.Point(641, 70);
            this.dtpToIOMDate.Name = "dtpToIOMDate";
            this.dtpToIOMDate.ShowCheckBox = true;
            this.dtpToIOMDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToIOMDate.TabIndex = 66;
            // 
            // dtpFromIOMDate
            // 
            this.dtpFromIOMDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromIOMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromIOMDate.Location = new System.Drawing.Point(641, 43);
            this.dtpFromIOMDate.Name = "dtpFromIOMDate";
            this.dtpFromIOMDate.ShowCheckBox = true;
            this.dtpFromIOMDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromIOMDate.TabIndex = 64;
            // 
            // chkIOMDate
            // 
            this.chkIOMDate.AutoSize = true;
            this.chkIOMDate.Location = new System.Drawing.Point(614, 19);
            this.chkIOMDate.Name = "chkIOMDate";
            this.chkIOMDate.Size = new System.Drawing.Size(72, 17);
            this.chkIOMDate.TabIndex = 62;
            this.chkIOMDate.Text = "IOM Date";
            this.chkIOMDate.UseVisualStyleBackColor = true;
            // 
            // chkPartyCode
            // 
            this.chkPartyCode.AutoSize = true;
            this.chkPartyCode.Location = new System.Drawing.Point(247, 22);
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
            this.btnFilter.Location = new System.Drawing.Point(912, 187);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(86, 27);
            this.btnFilter.TabIndex = 58;
            this.btnFilter.Text = "Submit";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dgvQueryExec
            // 
            this.dgvQueryExec.AllowUserToAddRows = false;
            this.dgvQueryExec.AllowUserToDeleteRows = false;
            this.dgvQueryExec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryExec.Location = new System.Drawing.Point(12, 237);
            this.dgvQueryExec.Name = "dgvQueryExec";
            this.dgvQueryExec.ReadOnly = true;
            this.dgvQueryExec.Size = new System.Drawing.Size(1160, 270);
            this.dgvQueryExec.TabIndex = 88;
            // 
            // listPartyName
            // 
            this.listPartyName.FormattingEnabled = true;
            this.listPartyName.Location = new System.Drawing.Point(466, 47);
            this.listPartyName.Name = "listPartyName";
            this.listPartyName.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPartyName.Size = new System.Drawing.Size(138, 160);
            this.listPartyName.TabIndex = 92;
            // 
            // chkPartyName
            // 
            this.chkPartyName.AutoSize = true;
            this.chkPartyName.Location = new System.Drawing.Point(472, 23);
            this.chkPartyName.Name = "chkPartyName";
            this.chkPartyName.Size = new System.Drawing.Size(81, 17);
            this.chkPartyName.TabIndex = 93;
            this.chkPartyName.Text = "Party Name";
            this.chkPartyName.UseVisualStyleBackColor = true;
            // 
            // filterSTNDispatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.lblReportName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvQueryExec);
            this.Name = "filterSTNDispatch";
            this.Text = "filterSTNDispatch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDSMZSM;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.ListBox listDSM_ZSM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpToAuthDate;
        private System.Windows.Forms.CheckBox chkAuthDate;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DateTimePicker dtpFromAuthDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DateTimePicker dtpToDeliveryDate;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.DateTimePicker dtpFromDeliveryDate;
        private System.Windows.Forms.CheckBox chkDeliveryDate;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.DataGridView dgvQueryExec;
        private System.Windows.Forms.ComboBox cmdLocationCode;
        private System.Windows.Forms.CheckBox chkLocation;
        private System.Windows.Forms.CheckBox chkSTNNo;
        private System.Windows.Forms.ListBox listSTNNo;
        private System.Windows.Forms.ComboBox cmbSTNLocation;
        private System.Windows.Forms.CheckBox chkSTNLocation;
        private System.Windows.Forms.CheckBox chkPartyName;
        private System.Windows.Forms.ListBox listPartyName;
    }
}