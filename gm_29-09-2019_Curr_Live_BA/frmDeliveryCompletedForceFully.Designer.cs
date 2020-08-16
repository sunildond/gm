namespace GlanMark
{
    partial class frmDeliveryCompletedForceFully
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
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.lblReportName = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvQueryExec = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Location = new System.Drawing.Point(1048, 522);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(124, 27);
            this.btnExportToExcel.TabIndex = 82;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(355, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(817, 220);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Detail Without Product";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "From";
            // 
            // dtpToDeliveryDate
            // 
            this.dtpToDeliveryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDeliveryDate.Location = new System.Drawing.Point(311, 183);
            this.dtpToDeliveryDate.Name = "dtpToDeliveryDate";
            this.dtpToDeliveryDate.ShowCheckBox = true;
            this.dtpToDeliveryDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToDeliveryDate.TabIndex = 75;
            // 
            // dtpFromDeliveryDate
            // 
            this.dtpFromDeliveryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDeliveryDate.Location = new System.Drawing.Point(311, 156);
            this.dtpFromDeliveryDate.Name = "dtpFromDeliveryDate";
            this.dtpFromDeliveryDate.ShowCheckBox = true;
            this.dtpFromDeliveryDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromDeliveryDate.TabIndex = 73;
            // 
            // chkDeliveryDate
            // 
            this.chkDeliveryDate.AutoSize = true;
            this.chkDeliveryDate.Location = new System.Drawing.Point(280, 132);
            this.chkDeliveryDate.Name = "chkDeliveryDate";
            this.chkDeliveryDate.Size = new System.Drawing.Size(90, 17);
            this.chkDeliveryDate.TabIndex = 72;
            this.chkDeliveryDate.Text = "Delivery Date";
            this.chkDeliveryDate.UseVisualStyleBackColor = true;
            // 
            // listPartyCode
            // 
            this.listPartyCode.FormattingEnabled = true;
            this.listPartyCode.Location = new System.Drawing.Point(143, 46);
            this.listPartyCode.Name = "listPartyCode";
            this.listPartyCode.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listPartyCode.Size = new System.Drawing.Size(114, 160);
            this.listPartyCode.TabIndex = 71;
            // 
            // listIOMNO
            // 
            this.listIOMNO.FormattingEnabled = true;
            this.listIOMNO.Location = new System.Drawing.Point(11, 45);
            this.listIOMNO.Name = "listIOMNO";
            this.listIOMNO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listIOMNO.Size = new System.Drawing.Size(116, 160);
            this.listIOMNO.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "From";
            // 
            // dtpToIOMDate
            // 
            this.dtpToIOMDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToIOMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToIOMDate.Location = new System.Drawing.Point(311, 73);
            this.dtpToIOMDate.Name = "dtpToIOMDate";
            this.dtpToIOMDate.ShowCheckBox = true;
            this.dtpToIOMDate.Size = new System.Drawing.Size(98, 20);
            this.dtpToIOMDate.TabIndex = 66;
            // 
            // dtpFromIOMDate
            // 
            this.dtpFromIOMDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromIOMDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromIOMDate.Location = new System.Drawing.Point(311, 46);
            this.dtpFromIOMDate.Name = "dtpFromIOMDate";
            this.dtpFromIOMDate.ShowCheckBox = true;
            this.dtpFromIOMDate.Size = new System.Drawing.Size(98, 20);
            this.dtpFromIOMDate.TabIndex = 64;
            // 
            // chkIOMDate
            // 
            this.chkIOMDate.AutoSize = true;
            this.chkIOMDate.Location = new System.Drawing.Point(280, 22);
            this.chkIOMDate.Name = "chkIOMDate";
            this.chkIOMDate.Size = new System.Drawing.Size(72, 17);
            this.chkIOMDate.TabIndex = 62;
            this.chkIOMDate.Text = "IOM Date";
            this.chkIOMDate.UseVisualStyleBackColor = true;
            // 
            // chkPartyCode
            // 
            this.chkPartyCode.AutoSize = true;
            this.chkPartyCode.Location = new System.Drawing.Point(147, 21);
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
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(468, 179);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(88, 27);
            this.btnFilter.TabIndex = 58;
            this.btnFilter.Text = "Submit";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(186, 532);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(0, 13);
            this.lblReportName.TabIndex = 85;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(726, 532);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 86;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 12);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(337, 220);
            this.txtQuery.TabIndex = 84;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(12, 524);
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
            this.dgvQueryExec.Location = new System.Drawing.Point(12, 246);
            this.dgvQueryExec.Name = "dgvQueryExec";
            this.dgvQueryExec.ReadOnly = true;
            this.dgvQueryExec.Size = new System.Drawing.Size(1160, 270);
            this.dgvQueryExec.TabIndex = 81;
            // 
            // frmDeliveryCompletedForceFully
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1184, 562);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblReportName);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dgvQueryExec);
            this.Name = "frmDeliveryCompletedForceFully";
            this.Text = "frmDeliveryCompletedForceFully";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvQueryExec;
    }
}