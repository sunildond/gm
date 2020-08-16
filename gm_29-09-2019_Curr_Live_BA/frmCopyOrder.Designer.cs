namespace GlanMark
{
    partial class frmCopyOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSubmitIOM = new System.Windows.Forms.Button();
            this.ddlIOMNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIOMNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIOMID = new System.Windows.Forms.Label();
            this.btnCopyIOMNo = new System.Windows.Forms.Button();
            this.dgvOrderMaster = new System.Windows.Forms.DataGridView();
            this.colView = new System.Windows.Forms.DataGridViewImageColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIOMNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIOMDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderAuthoDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPartyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPODate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReqDelDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubInstitution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocFile1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmitIOM
            // 
            this.btnSubmitIOM.Location = new System.Drawing.Point(535, 21);
            this.btnSubmitIOM.Name = "btnSubmitIOM";
            this.btnSubmitIOM.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitIOM.TabIndex = 30;
            this.btnSubmitIOM.Text = "Submit";
            this.btnSubmitIOM.UseVisualStyleBackColor = true;
            this.btnSubmitIOM.Click += new System.EventHandler(this.btnSubmitIOM_Click);
            // 
            // ddlIOMNo
            // 
            this.ddlIOMNo.FormattingEnabled = true;
            this.ddlIOMNo.Location = new System.Drawing.Point(310, 22);
            this.ddlIOMNo.Name = "ddlIOMNo";
            this.ddlIOMNo.Size = new System.Drawing.Size(211, 21);
            this.ddlIOMNo.TabIndex = 29;
            this.ddlIOMNo.SelectedIndexChanged += new System.EventHandler(this.ddlIOMNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Select IOM No:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIOMNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblIOMID);
            this.groupBox1.Controls.Add(this.btnCopyIOMNo);
            this.groupBox1.Controls.Add(this.dgvOrderMaster);
            this.groupBox1.Controls.Add(this.btnSubmitIOM);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ddlIOMNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1208, 471);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Copy IOM Number";
            // 
            // txtIOMNo
            // 
            this.txtIOMNo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtIOMNo.Location = new System.Drawing.Point(773, 23);
            this.txtIOMNo.Name = "txtIOMNo";
            this.txtIOMNo.ReadOnly = true;
            this.txtIOMNo.Size = new System.Drawing.Size(111, 20);
            this.txtIOMNo.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(661, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "New IOM Number Is:";
            // 
            // lblIOMID
            // 
            this.lblIOMID.AutoSize = true;
            this.lblIOMID.Location = new System.Drawing.Point(16, 25);
            this.lblIOMID.Name = "lblIOMID";
            this.lblIOMID.Size = new System.Drawing.Size(0, 13);
            this.lblIOMID.TabIndex = 33;
            // 
            // btnCopyIOMNo
            // 
            this.btnCopyIOMNo.Location = new System.Drawing.Point(1039, 19);
            this.btnCopyIOMNo.Name = "btnCopyIOMNo";
            this.btnCopyIOMNo.Size = new System.Drawing.Size(151, 26);
            this.btnCopyIOMNo.TabIndex = 32;
            this.btnCopyIOMNo.Text = "Copy IOM Number";
            this.btnCopyIOMNo.UseVisualStyleBackColor = true;
            this.btnCopyIOMNo.Click += new System.EventHandler(this.btnCopyIOMNo_Click);
            // 
            // dgvOrderMaster
            // 
            this.dgvOrderMaster.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(241)))), ((int)(((byte)(214)))));
            this.dgvOrderMaster.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrderMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOrderMaster.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvOrderMaster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrderMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colView,
            this.colID,
            this.colIOMNumber,
            this.colIOMDATE,
            this.colOrderAuthoDate,
            this.colPartyCode,
            this.colPartyName,
            this.colPONo,
            this.colPODate,
            this.colReqDelDate,
            this.colSubInstitution,
            this.colMRP,
            this.colRemark,
            this.colDocFile1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderMaster.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrderMaster.EnableHeadersVisualStyles = false;
            this.dgvOrderMaster.GridColor = System.Drawing.SystemColors.Control;
            this.dgvOrderMaster.Location = new System.Drawing.Point(6, 50);
            this.dgvOrderMaster.MultiSelect = false;
            this.dgvOrderMaster.Name = "dgvOrderMaster";
            this.dgvOrderMaster.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderMaster.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrderMaster.RowHeadersVisible = false;
            this.dgvOrderMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderMaster.Size = new System.Drawing.Size(1184, 415);
            this.dgvOrderMaster.TabIndex = 31;
            this.dgvOrderMaster.VirtualMode = true;
            this.dgvOrderMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderMaster_CellContentClick);
            // 
            // colView
            // 
            this.colView.HeaderText = "View";
            this.colView.Image = global::gm.Properties.Resources.viewDetails;
            this.colView.Name = "colView";
            this.colView.ReadOnly = true;
            this.colView.Width = 43;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "OrderHeaderId";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            this.colID.Width = 47;
            // 
            // colIOMNumber
            // 
            this.colIOMNumber.DataPropertyName = "IOMNo";
            this.colIOMNumber.HeaderText = "IOM No";
            this.colIOMNumber.Name = "colIOMNumber";
            this.colIOMNumber.ReadOnly = true;
            this.colIOMNumber.Width = 57;
            // 
            // colIOMDATE
            // 
            this.colIOMDATE.DataPropertyName = "IOMDate";
            this.colIOMDATE.HeaderText = "IOMDate";
            this.colIOMDATE.Name = "colIOMDATE";
            this.colIOMDATE.ReadOnly = true;
            this.colIOMDATE.Width = 87;
            // 
            // colOrderAuthoDate
            // 
            this.colOrderAuthoDate.DataPropertyName = "OrderAuthoDate";
            this.colOrderAuthoDate.HeaderText = "Order Autho Date";
            this.colOrderAuthoDate.Name = "colOrderAuthoDate";
            this.colOrderAuthoDate.ReadOnly = true;
            this.colOrderAuthoDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOrderAuthoDate.Width = 106;
            // 
            // colPartyCode
            // 
            this.colPartyCode.DataPropertyName = "PartyCode";
            this.colPartyCode.HeaderText = "Party Code";
            this.colPartyCode.Name = "colPartyCode";
            this.colPartyCode.ReadOnly = true;
            this.colPartyCode.Width = 95;
            // 
            // colPartyName
            // 
            this.colPartyName.DataPropertyName = "PartyName";
            this.colPartyName.HeaderText = "Party Name";
            this.colPartyName.Name = "colPartyName";
            this.colPartyName.ReadOnly = true;
            this.colPartyName.Width = 99;
            // 
            // colPONo
            // 
            this.colPONo.DataPropertyName = "InstPONo";
            this.colPONo.HeaderText = "PO No";
            this.colPONo.Name = "colPONo";
            this.colPONo.ReadOnly = true;
            this.colPONo.Width = 50;
            // 
            // colPODate
            // 
            this.colPODate.DataPropertyName = "InstPODate";
            this.colPODate.HeaderText = "PO Date";
            this.colPODate.Name = "colPODate";
            this.colPODate.ReadOnly = true;
            this.colPODate.Width = 77;
            // 
            // colReqDelDate
            // 
            this.colReqDelDate.DataPropertyName = "OrderDeliveryDate";
            this.colReqDelDate.HeaderText = "Req Del Date";
            this.colReqDelDate.Name = "colReqDelDate";
            this.colReqDelDate.ReadOnly = true;
            this.colReqDelDate.Width = 106;
            // 
            // colSubInstitution
            // 
            this.colSubInstitution.DataPropertyName = "SubInstitution";
            this.colSubInstitution.HeaderText = "SubInstitution";
            this.colSubInstitution.Name = "colSubInstitution";
            this.colSubInstitution.ReadOnly = true;
            this.colSubInstitution.Width = 124;
            // 
            // colMRP
            // 
            this.colMRP.DataPropertyName = "MRP";
            this.colMRP.HeaderText = "MRP";
            this.colMRP.Name = "colMRP";
            this.colMRP.ReadOnly = true;
            this.colMRP.Width = 58;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 82;
            // 
            // colDocFile1
            // 
            this.colDocFile1.DataPropertyName = "DocFile1";
            this.colDocFile1.HeaderText = "Doc File";
            this.colDocFile1.Name = "colDocFile1";
            this.colDocFile1.ReadOnly = true;
            this.colDocFile1.Width = 37;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderHeaderId";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 47;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "IOMNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "IOM No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 57;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "IOMDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "IOMDate";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 87;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "OrderAuthoDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Order Autho Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Width = 106;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PartyCode";
            this.dataGridViewTextBoxColumn5.HeaderText = "Party Code";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 95;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PartyName";
            this.dataGridViewTextBoxColumn6.HeaderText = "Party Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 99;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "InstPONo";
            this.dataGridViewTextBoxColumn7.HeaderText = "PO No";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "InstPODate";
            this.dataGridViewTextBoxColumn8.HeaderText = "PO Date";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 77;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "OrderDeliveryDate";
            this.dataGridViewTextBoxColumn9.HeaderText = "Req Del Date";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 106;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "SubInstitution";
            this.dataGridViewTextBoxColumn10.HeaderText = "SubInstitution";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 124;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "MRP";
            this.dataGridViewTextBoxColumn11.HeaderText = "MRP";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 58;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn12.HeaderText = "Remark";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 82;
            // 
            // frmCopyOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1232, 506);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCopyOrder";
            this.Text = "frmCopyOrder";
            this.Load += new System.EventHandler(this.frmCopyOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSubmitIOM;
        private System.Windows.Forms.ComboBox ddlIOMNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCopyIOMNo;
        private System.Windows.Forms.DataGridView dgvOrderMaster;
        private System.Windows.Forms.DataGridViewImageColumn colView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIOMNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIOMDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderAuthoDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPODate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqDelDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubInstitution;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewLinkColumn colDocFile1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.Label lblIOMID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIOMNo;
    }
}