namespace GlanMark
{
    partial class frmDefineReport
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
            this.dgvQueryExec = new System.Windows.Forms.DataGridView();
            this.btnIOMReport = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSTNDispatch = new System.Windows.Forms.Button();
            this.btnPendingReport = new System.Windows.Forms.Button();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.lblReportName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAllSql = new System.Windows.Forms.Button();
            this.btnProductInvoiceThroughSTNforSAP_IBS = new System.Windows.Forms.Button();
            this.btnProductWiseDir_INV_SAP_IBS = new System.Windows.Forms.Button();
            this.btnProductWiseNotInvoiced = new System.Windows.Forms.Button();
            this.btnInvoiceDetailWithoutProduct = new System.Windows.Forms.Button();
            this.btnDeliveryDetailWithoutProduct = new System.Windows.Forms.Button();
            this.btnDeliveryDetail = new System.Windows.Forms.Button();
            this.btnInvoieDetail = new System.Windows.Forms.Button();
            this.btnInvoiceDisWithPrd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeletedOrder = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQueryExec
            // 
            this.dgvQueryExec.AllowUserToAddRows = false;
            this.dgvQueryExec.AllowUserToDeleteRows = false;
            this.dgvQueryExec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryExec.Location = new System.Drawing.Point(12, 233);
            this.dgvQueryExec.Name = "dgvQueryExec";
            this.dgvQueryExec.ReadOnly = true;
            this.dgvQueryExec.Size = new System.Drawing.Size(1221, 285);
            this.dgvQueryExec.TabIndex = 8;
            this.dgvQueryExec.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQueryExec_CellContentClick);
            // 
            // btnIOMReport
            // 
            this.btnIOMReport.Location = new System.Drawing.Point(10, 19);
            this.btnIOMReport.Name = "btnIOMReport";
            this.btnIOMReport.Size = new System.Drawing.Size(97, 27);
            this.btnIOMReport.TabIndex = 9;
            this.btnIOMReport.Text = "IOM Report";
            this.btnIOMReport.UseVisualStyleBackColor = true;
            this.btnIOMReport.Click += new System.EventHandler(this.btnQuery1_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(580, 13);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(653, 203);
            this.txtQuery.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Query:";
            // 
            // btnSTNDispatch
            // 
            this.btnSTNDispatch.Location = new System.Drawing.Point(216, 19);
            this.btnSTNDispatch.Name = "btnSTNDispatch";
            this.btnSTNDispatch.Size = new System.Drawing.Size(97, 27);
            this.btnSTNDispatch.TabIndex = 53;
            this.btnSTNDispatch.Text = "STN Dispatch";
            this.btnSTNDispatch.UseVisualStyleBackColor = true;
            this.btnSTNDispatch.Click += new System.EventHandler(this.btnSTNDispatch_Click);
            // 
            // btnPendingReport
            // 
            this.btnPendingReport.Location = new System.Drawing.Point(113, 19);
            this.btnPendingReport.Name = "btnPendingReport";
            this.btnPendingReport.Size = new System.Drawing.Size(97, 27);
            this.btnPendingReport.TabIndex = 54;
            this.btnPendingReport.Text = "Pending Report";
            this.btnPendingReport.UseVisualStyleBackColor = true;
            this.btnPendingReport.Click += new System.EventHandler(this.btnPendingReport_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Location = new System.Drawing.Point(1109, 524);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(124, 27);
            this.btnExportToExcel.TabIndex = 55;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(56, 9);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(0, 13);
            this.lblReportName.TabIndex = 56;
            this.lblReportName.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAllSql);
            this.groupBox1.Controls.Add(this.btnProductInvoiceThroughSTNforSAP_IBS);
            this.groupBox1.Controls.Add(this.btnProductWiseDir_INV_SAP_IBS);
            this.groupBox1.Controls.Add(this.btnProductWiseNotInvoiced);
            this.groupBox1.Controls.Add(this.btnInvoiceDetailWithoutProduct);
            this.groupBox1.Controls.Add(this.btnDeliveryDetailWithoutProduct);
            this.groupBox1.Controls.Add(this.btnDeliveryDetail);
            this.groupBox1.Controls.Add(this.btnInvoieDetail);
            this.groupBox1.Controls.Add(this.btnInvoiceDisWithPrd);
            this.groupBox1.Controls.Add(this.btnSTNDispatch);
            this.groupBox1.Controls.Add(this.btnIOMReport);
            this.groupBox1.Controls.Add(this.btnPendingReport);
            this.groupBox1.Location = new System.Drawing.Point(9, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 149);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Related Query";
            // 
            // btnAllSql
            // 
            this.btnAllSql.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnAllSql.Location = new System.Drawing.Point(389, 52);
            this.btnAllSql.Name = "btnAllSql";
            this.btnAllSql.Size = new System.Drawing.Size(116, 56);
            this.btnAllSql.TabIndex = 56;
            this.btnAllSql.Text = "All SQL Merge";
            this.btnAllSql.UseVisualStyleBackColor = true;
            this.btnAllSql.Click += new System.EventHandler(this.btnAllSql_Click);
            // 
            // btnProductInvoiceThroughSTNforSAP_IBS
            // 
            this.btnProductInvoiceThroughSTNforSAP_IBS.Location = new System.Drawing.Point(305, 116);
            this.btnProductInvoiceThroughSTNforSAP_IBS.Name = "btnProductInvoiceThroughSTNforSAP_IBS";
            this.btnProductInvoiceThroughSTNforSAP_IBS.Size = new System.Drawing.Size(205, 27);
            this.btnProductInvoiceThroughSTNforSAP_IBS.TabIndex = 64;
            this.btnProductInvoiceThroughSTNforSAP_IBS.Text = "ProductInvoiceThroughSTNforSAP_IBS";
            this.btnProductInvoiceThroughSTNforSAP_IBS.UseVisualStyleBackColor = true;
            this.btnProductInvoiceThroughSTNforSAP_IBS.Click += new System.EventHandler(this.btnProductInvoiceThroughSTNforSAP_IBS_Click);
            // 
            // btnProductWiseDir_INV_SAP_IBS
            // 
            this.btnProductWiseDir_INV_SAP_IBS.Location = new System.Drawing.Point(135, 116);
            this.btnProductWiseDir_INV_SAP_IBS.Name = "btnProductWiseDir_INV_SAP_IBS";
            this.btnProductWiseDir_INV_SAP_IBS.Size = new System.Drawing.Size(165, 27);
            this.btnProductWiseDir_INV_SAP_IBS.TabIndex = 63;
            this.btnProductWiseDir_INV_SAP_IBS.Text = "Product WiseDir INV SAP_IBS";
            this.btnProductWiseDir_INV_SAP_IBS.UseVisualStyleBackColor = true;
            this.btnProductWiseDir_INV_SAP_IBS.Click += new System.EventHandler(this.btnProductWiseDir_INV_SAP_IBS_Click);
            // 
            // btnProductWiseNotInvoiced
            // 
            this.btnProductWiseNotInvoiced.Location = new System.Drawing.Point(5, 116);
            this.btnProductWiseNotInvoiced.Name = "btnProductWiseNotInvoiced";
            this.btnProductWiseNotInvoiced.Size = new System.Drawing.Size(126, 27);
            this.btnProductWiseNotInvoiced.TabIndex = 62;
            this.btnProductWiseNotInvoiced.Text = "Product Wise Not INV";
            this.btnProductWiseNotInvoiced.UseVisualStyleBackColor = true;
            this.btnProductWiseNotInvoiced.Click += new System.EventHandler(this.btnProductWiseNotInvoiced_Click);
            // 
            // btnInvoiceDetailWithoutProduct
            // 
            this.btnInvoiceDetailWithoutProduct.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnInvoiceDetailWithoutProduct.Location = new System.Drawing.Point(201, 81);
            this.btnInvoiceDetailWithoutProduct.Name = "btnInvoiceDetailWithoutProduct";
            this.btnInvoiceDetailWithoutProduct.Size = new System.Drawing.Size(186, 27);
            this.btnInvoiceDetailWithoutProduct.TabIndex = 59;
            this.btnInvoiceDetailWithoutProduct.Text = "Invoice Detail without Product";
            this.btnInvoiceDetailWithoutProduct.UseVisualStyleBackColor = true;
            this.btnInvoiceDetailWithoutProduct.Click += new System.EventHandler(this.btnInvoiceDetailWithoutProduct_Click);
            // 
            // btnDeliveryDetailWithoutProduct
            // 
            this.btnDeliveryDetailWithoutProduct.Location = new System.Drawing.Point(10, 81);
            this.btnDeliveryDetailWithoutProduct.Name = "btnDeliveryDetailWithoutProduct";
            this.btnDeliveryDetailWithoutProduct.Size = new System.Drawing.Size(186, 27);
            this.btnDeliveryDetailWithoutProduct.TabIndex = 58;
            this.btnDeliveryDetailWithoutProduct.Text = "Delivery Detail without Product";
            this.btnDeliveryDetailWithoutProduct.UseVisualStyleBackColor = true;
            this.btnDeliveryDetailWithoutProduct.Click += new System.EventHandler(this.btnDeliveryDetailWithoutProduct_Click);
            // 
            // btnDeliveryDetail
            // 
            this.btnDeliveryDetail.Location = new System.Drawing.Point(11, 52);
            this.btnDeliveryDetail.Name = "btnDeliveryDetail";
            this.btnDeliveryDetail.Size = new System.Drawing.Size(186, 27);
            this.btnDeliveryDetail.TabIndex = 57;
            this.btnDeliveryDetail.Text = "Delivery Detail with Product(New)";
            this.btnDeliveryDetail.UseVisualStyleBackColor = true;
            this.btnDeliveryDetail.Click += new System.EventHandler(this.btnDeliveryDetail_Click);
            // 
            // btnInvoieDetail
            // 
            this.btnInvoieDetail.Location = new System.Drawing.Point(201, 52);
            this.btnInvoieDetail.Name = "btnInvoieDetail";
            this.btnInvoieDetail.Size = new System.Drawing.Size(186, 27);
            this.btnInvoieDetail.TabIndex = 56;
            this.btnInvoieDetail.Text = "Invoice Detail with Product(New)";
            this.btnInvoieDetail.UseVisualStyleBackColor = true;
            this.btnInvoieDetail.Click += new System.EventHandler(this.btnInvoieDetail_Click);
            // 
            // btnInvoiceDisWithPrd
            // 
            this.btnInvoiceDisWithPrd.Location = new System.Drawing.Point(319, 19);
            this.btnInvoiceDisWithPrd.Name = "btnInvoiceDisWithPrd";
            this.btnInvoiceDisWithPrd.Size = new System.Drawing.Size(186, 27);
            this.btnInvoiceDisWithPrd.TabIndex = 55;
            this.btnInvoiceDisWithPrd.Text = "Invoice Dispatch With Product";
            this.btnInvoiceDisWithPrd.UseVisualStyleBackColor = true;
            this.btnInvoiceDisWithPrd.Click += new System.EventHandler(this.btnInvoiceDisWithPrd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeletedOrder);
            this.groupBox2.Location = new System.Drawing.Point(12, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 57);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deleted Ordre Related Query";
            // 
            // btnDeletedOrder
            // 
            this.btnDeletedOrder.Location = new System.Drawing.Point(10, 19);
            this.btnDeletedOrder.Name = "btnDeletedOrder";
            this.btnDeletedOrder.Size = new System.Drawing.Size(116, 27);
            this.btnDeletedOrder.TabIndex = 55;
            this.btnDeletedOrder.Text = "Deleted IOM Report";
            this.btnDeletedOrder.UseVisualStyleBackColor = true;
            this.btnDeletedOrder.Click += new System.EventHandler(this.btnDeletedOrder_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(761, 537);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(35, 13);
            this.lblCount.TabIndex = 59;
            this.lblCount.Text = "label1";
            // 
            // frmDefineReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1245, 562);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblReportName);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.dgvQueryExec);
            this.Name = "frmDefineReport";
            this.Text = "Define Report";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryExec)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQueryExec;
        private System.Windows.Forms.Button btnIOMReport;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSTNDispatch;
        private System.Windows.Forms.Button btnPendingReport;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeletedOrder;
        private System.Windows.Forms.Button btnInvoiceDisWithPrd;
        private System.Windows.Forms.Button btnInvoieDetail;
        private System.Windows.Forms.Button btnDeliveryDetail;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnInvoiceDetailWithoutProduct;
        private System.Windows.Forms.Button btnDeliveryDetailWithoutProduct;
        private System.Windows.Forms.Button btnProductInvoiceThroughSTNforSAP_IBS;
        private System.Windows.Forms.Button btnProductWiseDir_INV_SAP_IBS;
        private System.Windows.Forms.Button btnProductWiseNotInvoiced;
        private System.Windows.Forms.Button btnAllSql;
    }
}