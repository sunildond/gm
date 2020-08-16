namespace GlenMark
{
    partial class frmStnUpload
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uploaddate = new System.Windows.Forms.DateTimePicker();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.BtnUpdateorderitem = new System.Windows.Forms.Button();
            this.btnpendingorder = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUpload = new System.Windows.Forms.TextBox();
            this.lblLastUploedDate = new System.Windows.Forms.LinkLabel();
            this.lbldate = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dgvstnupload = new System.Windows.Forms.DataGridView();
            this.errorStnUpload = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.rtDuplicateRecord = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtpGridBind = new System.Windows.Forms.DateTimePicker();
            this.btnSubmitDate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstnupload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorStnUpload)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(397, 32);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 21;
            this.btnUpload.Text = "Browse";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblRecordCount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.uploaddate);
            this.groupBox2.Controls.Add(this.linkLabel2);
            this.groupBox2.Controls.Add(this.BtnUpdateorderitem);
            this.groupBox2.Controls.Add(this.btnpendingorder);
            this.groupBox2.Controls.Add(this.btnUpload);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtUpload);
            this.groupBox2.Location = new System.Drawing.Point(8, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 142);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Uplaod STN UpLoad";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // uploaddate
            // 
            this.uploaddate.CustomFormat = "dd/MM/yyyy";
            this.uploaddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uploaddate.Location = new System.Drawing.Point(344, 72);
            this.uploaddate.Name = "uploaddate";
            this.uploaddate.Size = new System.Drawing.Size(98, 20);
            this.uploaddate.TabIndex = 42;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(213, 72);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(108, 13);
            this.linkLabel2.TabIndex = 41;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "LastUploaded Date :-";
            // 
            // BtnUpdateorderitem
            // 
            this.BtnUpdateorderitem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdateorderitem.Location = new System.Drawing.Point(344, 109);
            this.BtnUpdateorderitem.Name = "BtnUpdateorderitem";
            this.BtnUpdateorderitem.Size = new System.Drawing.Size(139, 25);
            this.BtnUpdateorderitem.TabIndex = 40;
            this.BtnUpdateorderitem.Text = "Update OrderItem";
            this.BtnUpdateorderitem.UseVisualStyleBackColor = true;
            this.BtnUpdateorderitem.Click += new System.EventHandler(this.BtnUpdateorderitem_Click);
            // 
            // btnpendingorder
            // 
            this.btnpendingorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpendingorder.Location = new System.Drawing.Point(237, 108);
            this.btnpendingorder.Name = "btnpendingorder";
            this.btnpendingorder.Size = new System.Drawing.Size(98, 25);
            this.btnpendingorder.TabIndex = 36;
            this.btnpendingorder.Text = "Integrity Test ";
            this.btnpendingorder.UseVisualStyleBackColor = true;
            this.btnpendingorder.Click += new System.EventHandler(this.btnpendingorder_Click_1);
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
            this.label1.Location = new System.Drawing.Point(31, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select File";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(141, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(51, 111);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "UpLoad ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUpload
            // 
            this.txtUpload.Location = new System.Drawing.Point(91, 35);
            this.txtUpload.Name = "txtUpload";
            this.txtUpload.Size = new System.Drawing.Size(278, 20);
            this.txtUpload.TabIndex = 0;
            // 
            // lblLastUploedDate
            // 
            this.lblLastUploedDate.AutoSize = true;
            this.lblLastUploedDate.Location = new System.Drawing.Point(173, 15);
            this.lblLastUploedDate.Name = "lblLastUploedDate";
            this.lblLastUploedDate.Size = new System.Drawing.Size(108, 13);
            this.lblLastUploedDate.TabIndex = 27;
            this.lblLastUploedDate.TabStop = true;
            this.lblLastUploedDate.Text = "LastUploaded Date :-";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(287, 16);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(13, 13);
            this.lbldate.TabIndex = 29;
            this.lbldate.Text = "  ";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "While  Uploading Excel File Column Name Should be (IOMNO_STN,Delivery,Delivery_Da" +
                "te,PartyCode,Material,Description,SLoc,Batch,",
            "DeliveryQuantity,UpdateQuantity,Plnt,BillingDocument,Priority,ActualDeliveryQuant" +
                "ity,ActualGoodsMovement",
            ",MfgDate,ExpDate,Netvalue,ZMR1UnitPrice,ZSTKUnitPrice,ZEXDUnitPrice,ZCESUnitPrice" +
                ",RateMaster)"});
            this.listBox1.Location = new System.Drawing.Point(565, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(625, 43);
            this.listBox1.TabIndex = 33;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(510, 17);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 34;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Notes :-";
            // 
            // dgvstnupload
            // 
            this.dgvstnupload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstnupload.Location = new System.Drawing.Point(8, 181);
            this.dgvstnupload.Name = "dgvstnupload";
            this.dgvstnupload.Size = new System.Drawing.Size(1168, 386);
            this.dgvstnupload.TabIndex = 35;
            this.dgvstnupload.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvstnupload_CellContentClick);
            // 
            // errorStnUpload
            // 
            this.errorStnUpload.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(743, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Export Data in to Excel File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtDuplicateRecord
            // 
            this.rtDuplicateRecord.Location = new System.Drawing.Point(513, 93);
            this.rtDuplicateRecord.Name = "rtDuplicateRecord";
            this.rtDuplicateRecord.Size = new System.Drawing.Size(663, 73);
            this.rtDuplicateRecord.TabIndex = 39;
            this.rtDuplicateRecord.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Duplicate Record:";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(1025, 64);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(151, 23);
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Text = "Delete Invalid Record";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(1102, 574);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(74, 23);
            this.btnReset.TabIndex = 44;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtpGridBind
            // 
            this.dtpGridBind.CustomFormat = "dd/MM/yyyy";
            this.dtpGridBind.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGridBind.Location = new System.Drawing.Point(904, 577);
            this.dtpGridBind.Name = "dtpGridBind";
            this.dtpGridBind.Size = new System.Drawing.Size(98, 20);
            this.dtpGridBind.TabIndex = 43;
            // 
            // btnSubmitDate
            // 
            this.btnSubmitDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitDate.Location = new System.Drawing.Point(1008, 574);
            this.btnSubmitDate.Name = "btnSubmitDate";
            this.btnSubmitDate.Size = new System.Drawing.Size(74, 23);
            this.btnSubmitDate.TabIndex = 45;
            this.btnSubmitDate.Text = "Submit";
            this.btnSubmitDate.UseVisualStyleBackColor = true;
            this.btnSubmitDate.Click += new System.EventHandler(this.btnSubmitDate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Uploaded Record";
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(98, 80);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(13, 13);
            this.lblRecordCount.TabIndex = 44;
            this.lblRecordCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "0";
            // 
            // frmStnUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 628);
            this.Controls.Add(this.btnSubmitDate);
            this.Controls.Add(this.dtpGridBind);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtDuplicateRecord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvstnupload);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lblLastUploedDate);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmStnUpload";
            this.Text = "frmStnUpload (1.Import SAP STN( check order item ))";
            this.Load += new System.EventHandler(this.frmStnUpload_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstnupload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorStnUpload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUpload;
        private System.Windows.Forms.LinkLabel lblLastUploedDate;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridView dgvstnupload;
        private System.Windows.Forms.ErrorProvider errorStnUpload;
        private System.Windows.Forms.Button btnpendingorder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnUpdateorderitem;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.DateTimePicker uploaddate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtDuplicateRecord;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DateTimePicker dtpGridBind;
        private System.Windows.Forms.Button btnSubmitDate;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;

    }
}