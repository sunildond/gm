namespace GlanMark
{
    partial class frmIBISBilling
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
            this.BtnUpdateorderitem = new System.Windows.Forms.Button();
            this.btnpendingorder = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUpload = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblLastUploedDate = new System.Windows.Forms.LinkLabel();
            this.lbldate = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dgvIBIS = new System.Windows.Forms.DataGridView();
            this.errorProvideribis = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.uploaddate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIBIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvideribis)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(383, 34);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 21;
            this.btnUpload.Text = "Browse";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.uploaddate);
            this.groupBox2.Controls.Add(this.BtnUpdateorderitem);
            this.groupBox2.Controls.Add(this.btnpendingorder);
            this.groupBox2.Controls.Add(this.btnUpload);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtUpload);
            this.groupBox2.Location = new System.Drawing.Point(12, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(502, 206);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Uplaod IBIS Billing";
            // 
            // BtnUpdateorderitem
            // 
            this.BtnUpdateorderitem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpdateorderitem.Location = new System.Drawing.Point(319, 110);
            this.BtnUpdateorderitem.Name = "BtnUpdateorderitem";
            this.BtnUpdateorderitem.Size = new System.Drawing.Size(139, 25);
            this.BtnUpdateorderitem.TabIndex = 41;
            this.BtnUpdateorderitem.Text = "Update OrderItem";
            this.BtnUpdateorderitem.UseVisualStyleBackColor = true;
            this.BtnUpdateorderitem.Click += new System.EventHandler(this.BtnUpdateorderitem_Click_1);
            // 
            // btnpendingorder
            // 
            this.btnpendingorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpendingorder.Location = new System.Drawing.Point(210, 110);
            this.btnpendingorder.Name = "btnpendingorder";
            this.btnpendingorder.Size = new System.Drawing.Size(98, 25);
            this.btnpendingorder.TabIndex = 23;
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
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select File";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(117, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(16, 109);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "UpLoad ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUpload
            // 
            this.txtUpload.Location = new System.Drawing.Point(73, 35);
            this.txtUpload.Name = "txtUpload";
            this.txtUpload.Size = new System.Drawing.Size(278, 20);
            this.txtUpload.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(520, 14);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 30;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Notes :-";
            // 
            // lblLastUploedDate
            // 
            this.lblLastUploedDate.AutoSize = true;
            this.lblLastUploedDate.Location = new System.Drawing.Point(212, 9);
            this.lblLastUploedDate.Name = "lblLastUploedDate";
            this.lblLastUploedDate.Size = new System.Drawing.Size(108, 13);
            this.lblLastUploedDate.TabIndex = 28;
            this.lblLastUploedDate.TabStop = true;
            this.lblLastUploedDate.Text = "LastUploaded Date :-";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(339, 10);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(13, 13);
            this.lbldate.TabIndex = 29;
            this.lbldate.Text = "  ";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "While  Uploading Excel File Column Name Should be (ID,IOMNO,STNNumber,PartyCode,D" +
                "ocumentNumber,AccountName,",
            "ProductName,Batch,BilledQuantity,UpdateQuantity,MaterialCode,LastModify,Location," +
                "Team,DiscPrice,UED,INVAMT,ExciseDuty,",
            "LR_NO,LR_DT,TRANSPORTER_ID,TRANSPORTER_NAME,NRV)"});
            this.listBox1.Location = new System.Drawing.Point(570, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(691, 43);
            this.listBox1.TabIndex = 31;
            // 
            // dgvIBIS
            // 
            this.dgvIBIS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIBIS.Location = new System.Drawing.Point(520, 79);
            this.dgvIBIS.Name = "dgvIBIS";
            this.dgvIBIS.Size = new System.Drawing.Size(814, 555);
            this.dgvIBIS.TabIndex = 36;
            // 
            // errorProvideribis
            // 
            this.errorProvideribis.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(782, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Export Data in to Excel File";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Select Date";
            // 
            // uploaddate
            // 
            this.uploaddate.CustomFormat = "dd/MM/yyyy";
            this.uploaddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uploaddate.Location = new System.Drawing.Point(117, 61);
            this.uploaddate.Name = "uploaddate";
            this.uploaddate.Size = new System.Drawing.Size(98, 20);
            this.uploaddate.TabIndex = 52;
            // 
            // frmIBISBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 596);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvIBIS);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lblLastUploedDate);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmIBISBilling";
            this.Text = "frmIBISBilling";
            this.Load += new System.EventHandler(this.frmIBISBilling_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIBIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvideribis)).EndInit();
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
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dgvIBIS;
        private System.Windows.Forms.ErrorProvider errorProvideribis;
        private System.Windows.Forms.Button btnpendingorder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnUpdateorderitem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker uploaddate;
    }
}