namespace GlanMark
{
    partial class frmSapInvoiceUpload
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uploaddate = new System.Windows.Forms.DateTimePicker();
            this.BtnUpdateorderitem = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btNItegrityTest = new System.Windows.Forms.Button();
            this.txtUpload = new System.Windows.Forms.TextBox();
            this.lblLastUploedDate = new System.Windows.Forms.LinkLabel();
            this.lbldate = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.errorSAPInvoiceUpload = new System.Windows.Forms.ErrorProvider(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dgvSapinvoice = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lblalert = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rtDuplicateRecord = new System.Windows.Forms.RichTextBox();
            this.btnSubmitDate = new System.Windows.Forms.Button();
            this.dtpGridBind = new System.Windows.Forms.DateTimePicker();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorSAPInvoiceUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSapinvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(398, 34);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 21;
            this.btnUpload.Text = "Browse";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(20, 238);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select File";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(119, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.uploaddate);
            this.groupBox2.Controls.Add(this.BtnUpdateorderitem);
            this.groupBox2.Controls.Add(this.btnUpload);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btNItegrityTest);
            this.groupBox2.Controls.Add(this.txtUpload);
            this.groupBox2.Location = new System.Drawing.Point(8, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 147);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Uplaod SAP UpLoad";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Select Date";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // uploaddate
            // 
            this.uploaddate.CustomFormat = "dd/MM/yyyy";
            this.uploaddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uploaddate.Location = new System.Drawing.Point(84, 71);
            this.uploaddate.Name = "uploaddate";
            this.uploaddate.Size = new System.Drawing.Size(98, 20);
            this.uploaddate.TabIndex = 43;
            this.uploaddate.ValueChanged += new System.EventHandler(this.uploaddate_ValueChanged);
            // 
            // BtnUpdateorderitem
            // 
            this.BtnUpdateorderitem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdateorderitem.Location = new System.Drawing.Point(332, 110);
            this.BtnUpdateorderitem.Name = "BtnUpdateorderitem";
            this.BtnUpdateorderitem.Size = new System.Drawing.Size(139, 25);
            this.BtnUpdateorderitem.TabIndex = 23;
            this.BtnUpdateorderitem.Text = "Update OrderItem";
            this.BtnUpdateorderitem.UseVisualStyleBackColor = true;
            this.BtnUpdateorderitem.Click += new System.EventHandler(this.BtnUpdateorderitem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(25, 109);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "UpLoad ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btNItegrityTest
            // 
            this.btNItegrityTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNItegrityTest.Location = new System.Drawing.Point(210, 109);
            this.btNItegrityTest.Name = "btNItegrityTest";
            this.btNItegrityTest.Size = new System.Drawing.Size(98, 25);
            this.btNItegrityTest.TabIndex = 22;
            this.btNItegrityTest.Text = "Integrity Test ";
            this.btNItegrityTest.UseVisualStyleBackColor = true;
            this.btNItegrityTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUpload
            // 
            this.txtUpload.Location = new System.Drawing.Point(84, 35);
            this.txtUpload.Name = "txtUpload";
            this.txtUpload.Size = new System.Drawing.Size(278, 20);
            this.txtUpload.TabIndex = 0;
            // 
            // lblLastUploedDate
            // 
            this.lblLastUploedDate.AutoSize = true;
            this.lblLastUploedDate.Location = new System.Drawing.Point(165, 26);
            this.lblLastUploedDate.Name = "lblLastUploedDate";
            this.lblLastUploedDate.Size = new System.Drawing.Size(108, 13);
            this.lblLastUploedDate.TabIndex = 26;
            this.lblLastUploedDate.TabStop = true;
            this.lblLastUploedDate.Text = "LastUploaded Date :-";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(279, 26);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(13, 13);
            this.lbldate.TabIndex = 27;
            this.lbldate.Text = "  ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(496, 17);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 33;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Notes :-";
            // 
            // errorSAPInvoiceUpload
            // 
            this.errorSAPInvoiceUpload.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorSAPInvoiceUpload.ContainerControl = this;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "While  Uploading Excel File Column Name Should be (IOMNo_STN,STNNumber,BillingDoc" +
                "ument,SoldToParty,Name,Plnt,BillingDate,",
            "MaterialCode,Description,BilledQuantity,UpdateQuantity,Batch,Priority,ActualBille" +
                "dQuantity,Subtotal1,Subtotal2,Subtotal3,Subtotal4,Subtotal5,",
            "Total,ZST1,ZEXDD,ZCESS,ZMR1,ZSTK,ZEXD,Mfgdate,ExpDate,NRV)"});
            this.listBox1.Location = new System.Drawing.Point(539, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(704, 43);
            this.listBox1.TabIndex = 33;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // dgvSapinvoice
            // 
            this.dgvSapinvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSapinvoice.Location = new System.Drawing.Point(539, 82);
            this.dgvSapinvoice.Name = "dgvSapinvoice";
            this.dgvSapinvoice.Size = new System.Drawing.Size(691, 394);
            this.dgvSapinvoice.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1087, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Export Data in to Excel File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblalert
            // 
            this.lblalert.AutoSize = true;
            this.lblalert.Location = new System.Drawing.Point(89, 271);
            this.lblalert.Name = "lblalert";
            this.lblalert.Size = new System.Drawing.Size(0, 13);
            this.lblalert.TabIndex = 38;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(351, 211);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(151, 23);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "Delete Invalid Record";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Duplicate Record:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // rtDuplicateRecord
            // 
            this.rtDuplicateRecord.Location = new System.Drawing.Point(8, 240);
            this.rtDuplicateRecord.Name = "rtDuplicateRecord";
            this.rtDuplicateRecord.Size = new System.Drawing.Size(494, 87);
            this.rtDuplicateRecord.TabIndex = 44;
            this.rtDuplicateRecord.Text = "";
            this.rtDuplicateRecord.TextChanged += new System.EventHandler(this.rtDuplicateRecord_TextChanged);
            // 
            // btnSubmitDate
            // 
            this.btnSubmitDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitDate.Location = new System.Drawing.Point(116, 453);
            this.btnSubmitDate.Name = "btnSubmitDate";
            this.btnSubmitDate.Size = new System.Drawing.Size(74, 23);
            this.btnSubmitDate.TabIndex = 49;
            this.btnSubmitDate.Text = "Submit";
            this.btnSubmitDate.UseVisualStyleBackColor = true;
            this.btnSubmitDate.Click += new System.EventHandler(this.btnSubmitDate_Click);
            // 
            // dtpGridBind
            // 
            this.dtpGridBind.CustomFormat = "dd/MM/yyyy";
            this.dtpGridBind.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGridBind.Location = new System.Drawing.Point(12, 456);
            this.dtpGridBind.Name = "dtpGridBind";
            this.dtpGridBind.Size = new System.Drawing.Size(98, 20);
            this.dtpGridBind.TabIndex = 47;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(210, 453);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(74, 23);
            this.btnReset.TabIndex = 48;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(111, 192);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(13, 13);
            this.lblRecordCount.TabIndex = 51;
            this.lblRecordCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Uploaded Record";
            // 
            // frmSapInvoiceUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 529);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubmitDate);
            this.Controls.Add(this.dtpGridBind);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtDuplicateRecord);
            this.Controls.Add(this.lblalert);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvSapinvoice);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lblLastUploedDate);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmSapInvoiceUpload";
            this.Text = "(2.Import   SAP Invoice thrugh STN( check stn ))frmSapInvoiceUpload";
            this.Load += new System.EventHandler(this.frmSapInvoiceUpload_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorSAPInvoiceUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSapinvoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUpload;
        private System.Windows.Forms.Button btNItegrityTest;
        private System.Windows.Forms.LinkLabel lblLastUploedDate;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ErrorProvider errorSAPInvoiceUpload;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dgvSapinvoice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnUpdateorderitem;
        private System.Windows.Forms.Label lblalert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtDuplicateRecord;
        private System.Windows.Forms.DateTimePicker uploaddate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmitDate;
        private System.Windows.Forms.DateTimePicker dtpGridBind;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label4;
    }
}