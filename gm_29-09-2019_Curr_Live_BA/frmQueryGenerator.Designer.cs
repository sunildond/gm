namespace gm
{
    partial class frmQueryGenerator
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
            this.ChkORHeader = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.ChkORderItem = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSapInvoice = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSTNUPload = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkInvoiceDispatch = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkBatchAllocation = new System.Windows.Forms.CheckedListBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQueryname = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblTblCnt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChkORHeader
            // 
            this.ChkORHeader.FormattingEnabled = true;
            this.ChkORHeader.Location = new System.Drawing.Point(12, 31);
            this.ChkORHeader.Name = "ChkORHeader";
            this.ChkORHeader.Size = new System.Drawing.Size(182, 259);
            this.ChkORHeader.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Order Header";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(454, 305);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // ChkORderItem
            // 
            this.ChkORderItem.FormattingEnabled = true;
            this.ChkORderItem.Location = new System.Drawing.Point(200, 31);
            this.ChkORderItem.Name = "ChkORderItem";
            this.ChkORderItem.Size = new System.Drawing.Size(187, 259);
            this.ChkORderItem.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Order Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "SAP Invoice";
            // 
            // chkSapInvoice
            // 
            this.chkSapInvoice.FormattingEnabled = true;
            this.chkSapInvoice.Location = new System.Drawing.Point(393, 31);
            this.chkSapInvoice.Name = "chkSapInvoice";
            this.chkSapInvoice.Size = new System.Drawing.Size(187, 259);
            this.chkSapInvoice.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(640, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "STN Upload";
            // 
            // chkSTNUPload
            // 
            this.chkSTNUPload.FormattingEnabled = true;
            this.chkSTNUPload.Location = new System.Drawing.Point(586, 31);
            this.chkSTNUPload.Name = "chkSTNUPload";
            this.chkSTNUPload.Size = new System.Drawing.Size(187, 259);
            this.chkSTNUPload.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(834, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Invoice Dispatch";
            // 
            // chkInvoiceDispatch
            // 
            this.chkInvoiceDispatch.FormattingEnabled = true;
            this.chkInvoiceDispatch.Location = new System.Drawing.Point(778, 31);
            this.chkInvoiceDispatch.Name = "chkInvoiceDispatch";
            this.chkInvoiceDispatch.Size = new System.Drawing.Size(187, 259);
            this.chkInvoiceDispatch.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1027, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Batch Allocation";
            // 
            // chkBatchAllocation
            // 
            this.chkBatchAllocation.FormattingEnabled = true;
            this.chkBatchAllocation.Location = new System.Drawing.Point(971, 31);
            this.chkBatchAllocation.Name = "chkBatchAllocation";
            this.chkBatchAllocation.Size = new System.Drawing.Size(187, 259);
            this.chkBatchAllocation.TabIndex = 48;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(200, 375);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(958, 95);
            this.txtQuery.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Query Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(124, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Query Details";
            // 
            // txtQueryname
            // 
            this.txtQueryname.Location = new System.Drawing.Point(200, 346);
            this.txtQueryname.Name = "txtQueryname";
            this.txtQueryname.Size = new System.Drawing.Size(340, 20);
            this.txtQueryname.TabIndex = 53;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(200, 476);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 54;
            this.btnSave.Text = "Submit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(643, 346);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 55;
            this.lblStatus.Text = "Status";
            this.lblStatus.Visible = false;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(69, 405);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(58, 13);
            this.lblTableName.TabIndex = 56;
            this.lblTableName.Text = "tableName";
            this.lblTableName.Visible = false;
            // 
            // lblTblCnt
            // 
            this.lblTblCnt.AutoSize = true;
            this.lblTblCnt.Location = new System.Drawing.Point(69, 437);
            this.lblTblCnt.Name = "lblTblCnt";
            this.lblTblCnt.Size = new System.Drawing.Size(60, 13);
            this.lblTblCnt.TabIndex = 57;
            this.lblTblCnt.Text = "table count";
            this.lblTblCnt.Visible = false;
            // 
            // frmQueryGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1170, 567);
            this.Controls.Add(this.lblTblCnt);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtQueryname);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkBatchAllocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkInvoiceDispatch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkSTNUPload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkSapInvoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChkORderItem);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChkORHeader);
            this.Name = "frmQueryGenerator";
            this.Text = "frmQueryGenerator";
            this.Load += new System.EventHandler(this.frmQueryGenerator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ChkORHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.CheckedListBox ChkORderItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox chkSapInvoice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chkSTNUPload;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox chkInvoiceDispatch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox chkBatchAllocation;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQueryname;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblTblCnt;
    }
}