namespace gm
{
    partial class frmDirSAPInvoice
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
            this.errorStnUpload = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvstnupload = new System.Windows.Forms.DataGridView();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblLastUploedDate = new System.Windows.Forms.LinkLabel();
            this.BtnUpdateorderitem = new System.Windows.Forms.Button();
            this.btnpendingorder = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUpload = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorStnUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstnupload)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorStnUpload
            // 
            this.errorStnUpload.ContainerControl = this;
            // 
            // dgvstnupload
            // 
            this.dgvstnupload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstnupload.Location = new System.Drawing.Point(502, 74);
            this.dgvstnupload.Name = "dgvstnupload";
            this.dgvstnupload.Size = new System.Drawing.Size(809, 588);
            this.dgvstnupload.TabIndex = 44;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(505, 15);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 43;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Notes :-";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "While  Uploading Excel File Column Name Should be (IOMNO,Delivery,AcGIdate,PartyC" +
                "ode,Material,Description,SLoc,Batch,",
            "DeliveryQuantity,UpdateQuantity,Plnt,BillingDocument,Priority,ActualDeliveryQuant" +
                "ity,ActualGoodsMovement",
            ",MfgDate,ExpDate,Netvalue,ZMR1UnitPrice,ZSTKUnitPrice,ZEXDUnitPrice,ZCESUnitPrice" +
                ",RateMaster)"});
            this.listBox1.Location = new System.Drawing.Point(560, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(625, 43);
            this.listBox1.TabIndex = 42;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(282, 14);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(13, 13);
            this.lbldate.TabIndex = 41;
            this.lbldate.Text = "  ";
            // 
            // lblLastUploedDate
            // 
            this.lblLastUploedDate.AutoSize = true;
            this.lblLastUploedDate.Location = new System.Drawing.Point(168, 13);
            this.lblLastUploedDate.Name = "lblLastUploedDate";
            this.lblLastUploedDate.Size = new System.Drawing.Size(108, 13);
            this.lblLastUploedDate.TabIndex = 40;
            this.lblLastUploedDate.TabStop = true;
            this.lblLastUploedDate.Text = "LastUploaded Date :-";
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
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(738, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "Export Data in to Excel File";
            this.button1.UseVisualStyleBackColor = true;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnUpdateorderitem);
            this.groupBox2.Controls.Add(this.btnpendingorder);
            this.groupBox2.Controls.Add(this.btnUpload);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtUpload);
            this.groupBox2.Location = new System.Drawing.Point(3, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(489, 165);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Uplaod STN UpLoad";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
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
            this.btnSave.Location = new System.Drawing.Point(51, 110);
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
            // frmDirSAPInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 666);
            this.Controls.Add(this.dgvstnupload);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.lblLastUploedDate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmDirSAPInvoice";
            this.Text = "frmDirSAPInvoice";
            ((System.ComponentModel.ISupportInitialize)(this.errorStnUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstnupload)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorStnUpload;
        private System.Windows.Forms.DataGridView dgvstnupload;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.LinkLabel lblLastUploedDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnUpdateorderitem;
        private System.Windows.Forms.Button btnpendingorder;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUpload;


    }
}