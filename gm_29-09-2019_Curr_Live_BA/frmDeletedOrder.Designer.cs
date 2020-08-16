namespace GlanMark
{
    partial class frmDeletedOrder
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDeletedOrderMaster = new System.Windows.Forms.DataGridView();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblPageStatus = new System.Windows.Forms.Label();
            this.btnResetIOM = new System.Windows.Forms.Button();
            this.btnSubmitIOM = new System.Windows.Forms.Button();
            this.ddlIOMNo = new System.Windows.Forms.ComboBox();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeletedOrderMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 542);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDeletedOrderMaster);
            this.tabPage1.Controls.Add(this.btnFirst);
            this.tabPage1.Controls.Add(this.btnPrevious);
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.btnLast);
            this.tabPage1.Controls.Add(this.lblPageStatus);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1152, 516);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Order Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDeletedOrderMaster
            // 
            this.dgvDeletedOrderMaster.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(241)))), ((int)(((byte)(214)))));
            this.dgvDeletedOrderMaster.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDeletedOrderMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDeletedOrderMaster.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvDeletedOrderMaster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeletedOrderMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDeletedOrderMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeletedOrderMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvDeletedOrderMaster.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeletedOrderMaster.EnableHeadersVisualStyles = false;
            this.dgvDeletedOrderMaster.GridColor = System.Drawing.SystemColors.Control;
            this.dgvDeletedOrderMaster.Location = new System.Drawing.Point(6, 6);
            this.dgvDeletedOrderMaster.MultiSelect = false;
            this.dgvDeletedOrderMaster.Name = "dgvDeletedOrderMaster";
            this.dgvDeletedOrderMaster.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeletedOrderMaster.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDeletedOrderMaster.RowHeadersVisible = false;
            this.dgvDeletedOrderMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeletedOrderMaster.Size = new System.Drawing.Size(1140, 446);
            this.dgvDeletedOrderMaster.TabIndex = 7;
            this.dgvDeletedOrderMaster.VirtualMode = true;
            this.dgvDeletedOrderMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeletedOrderMaster_CellContentClick);
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFirst.Location = new System.Drawing.Point(471, 470);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(24, 23);
            this.btnFirst.TabIndex = 127;
            this.btnFirst.Text = "|<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrevious.Location = new System.Drawing.Point(495, 470);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(24, 23);
            this.btnPrevious.TabIndex = 128;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNext.Location = new System.Drawing.Point(607, 470);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 23);
            this.btnNext.TabIndex = 129;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLast.Location = new System.Drawing.Point(631, 470);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(24, 23);
            this.btnLast.TabIndex = 130;
            this.btnLast.Text = ">|";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // lblPageStatus
            // 
            this.lblPageStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPageStatus.Enabled = false;
            this.lblPageStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPageStatus.Location = new System.Drawing.Point(520, 472);
            this.lblPageStatus.Name = "lblPageStatus";
            this.lblPageStatus.Size = new System.Drawing.Size(85, 20);
            this.lblPageStatus.TabIndex = 131;
            this.lblPageStatus.Text = "0 / 0";
            this.lblPageStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnResetIOM
            // 
            this.btnResetIOM.Location = new System.Drawing.Point(690, 14);
            this.btnResetIOM.Name = "btnResetIOM";
            this.btnResetIOM.Size = new System.Drawing.Size(75, 23);
            this.btnResetIOM.TabIndex = 129;
            this.btnResetIOM.Text = "Reset";
            this.btnResetIOM.UseVisualStyleBackColor = true;
            this.btnResetIOM.Click += new System.EventHandler(this.btnResetIOM_Click);
            // 
            // btnSubmitIOM
            // 
            this.btnSubmitIOM.Location = new System.Drawing.Point(607, 14);
            this.btnSubmitIOM.Name = "btnSubmitIOM";
            this.btnSubmitIOM.Size = new System.Drawing.Size(75, 23);
            this.btnSubmitIOM.TabIndex = 128;
            this.btnSubmitIOM.Text = "Submit";
            this.btnSubmitIOM.UseVisualStyleBackColor = true;
            this.btnSubmitIOM.Click += new System.EventHandler(this.btnSubmitIOM_Click);
            // 
            // ddlIOMNo
            // 
            this.ddlIOMNo.FormattingEnabled = true;
            this.ddlIOMNo.Location = new System.Drawing.Point(390, 16);
            this.ddlIOMNo.Name = "ddlIOMNo";
            this.ddlIOMNo.Size = new System.Drawing.Size(211, 21);
            this.ddlIOMNo.TabIndex = 127;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "OrderHeaderId";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 47;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "IOMNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "IOM No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 57;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "IOMDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "IOMDate";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 87;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "OrderAuthoDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Order Autho Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Width = 106;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PartyCode";
            this.dataGridViewTextBoxColumn5.HeaderText = "Party Code";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 95;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PartyName";
            this.dataGridViewTextBoxColumn6.HeaderText = "Party Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 99;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "InstPONo";
            this.dataGridViewTextBoxColumn7.HeaderText = "PO No";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "InstPODate";
            this.dataGridViewTextBoxColumn8.HeaderText = "PO Date";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 77;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "OrderDeliveryDate";
            this.dataGridViewTextBoxColumn9.HeaderText = "Req Del Date";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 106;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "SubInstitution";
            this.dataGridViewTextBoxColumn10.HeaderText = "SubInstitution";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 124;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "MRP";
            this.dataGridViewTextBoxColumn11.HeaderText = "MRP";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 58;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn12.HeaderText = "Remark";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 82;
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
            this.colIOMNumber.Width = 78;
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
            // frmDeletedOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.btnResetIOM);
            this.Controls.Add(this.btnSubmitIOM);
            this.Controls.Add(this.ddlIOMNo);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmDeletedOrder";
            this.Text = "Deleted Order";
            this.Load += new System.EventHandler(this.frmDeletedOrder_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeletedOrderMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvDeletedOrderMaster;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblPageStatus;
        private System.Windows.Forms.Button btnResetIOM;
        private System.Windows.Forms.Button btnSubmitIOM;
        private System.Windows.Forms.ComboBox ddlIOMNo;
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
    }
}