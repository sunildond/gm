namespace GlanMark
{
    partial class frmBatch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAliseName = new System.Windows.Forms.Label();
            this.lableAName = new System.Windows.Forms.Label();
            this.IsDeliveryCompleted = new System.Windows.Forms.CheckBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.ddlReason = new System.Windows.Forms.ComboBox();
            this.lblSchduleID = new System.Windows.Forms.Label();
            this.lblIOMno = new System.Windows.Forms.Label();
            this.lblIOMnoonly = new System.Windows.Forms.Label();
            this.lblOrderScheStatus = new System.Windows.Forms.Label();
            this.btnUpdateSchedule = new System.Windows.Forms.Button();
            this.lblPendingQuantity = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblProdCode = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dgvOrderItemSchedule = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWareHousecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStorageCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMFG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelfLifePercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnrestricted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAllocate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItemSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAliseName);
            this.groupBox1.Controls.Add(this.lableAName);
            this.groupBox1.Controls.Add(this.IsDeliveryCompleted);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.lblRemark);
            this.groupBox1.Controls.Add(this.lblReason);
            this.groupBox1.Controls.Add(this.ddlReason);
            this.groupBox1.Controls.Add(this.lblSchduleID);
            this.groupBox1.Controls.Add(this.lblIOMno);
            this.groupBox1.Controls.Add(this.lblIOMnoonly);
            this.groupBox1.Controls.Add(this.lblOrderScheStatus);
            this.groupBox1.Controls.Add(this.btnUpdateSchedule);
            this.groupBox1.Controls.Add(this.lblPendingQuantity);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblProdCode);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.dgvOrderItemSchedule);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1225, 518);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Batch Master";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblAliseName
            // 
            this.lblAliseName.AutoSize = true;
            this.lblAliseName.Location = new System.Drawing.Point(956, 27);
            this.lblAliseName.Name = "lblAliseName";
            this.lblAliseName.Size = new System.Drawing.Size(0, 13);
            this.lblAliseName.TabIndex = 141;
            // 
            // lableAName
            // 
            this.lableAName.AutoSize = true;
            this.lableAName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableAName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lableAName.Location = new System.Drawing.Point(857, 27);
            this.lableAName.Name = "lableAName";
            this.lableAName.Size = new System.Drawing.Size(94, 13);
            this.lableAName.TabIndex = 140;
            this.lableAName.Text = "Alise Name :-";
            // 
            // IsDeliveryCompleted
            // 
            this.IsDeliveryCompleted.AutoSize = true;
            this.IsDeliveryCompleted.Location = new System.Drawing.Point(476, 457);
            this.IsDeliveryCompleted.Name = "IsDeliveryCompleted";
            this.IsDeliveryCompleted.Size = new System.Drawing.Size(122, 17);
            this.IsDeliveryCompleted.TabIndex = 1;
            this.IsDeliveryCompleted.Text = "IsDeliveryCompleted";
            this.IsDeliveryCompleted.UseVisualStyleBackColor = true;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(67, 486);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(681, 20);
            this.txtRemark.TabIndex = 139;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(11, 489);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(50, 13);
            this.lblRemark.TabIndex = 138;
            this.lblRemark.Text = "Remark";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(11, 455);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(50, 13);
            this.lblReason.TabIndex = 137;
            this.lblReason.Text = "Reason";
            // 
            // ddlReason
            // 
            this.ddlReason.FormattingEnabled = true;
            this.ddlReason.Location = new System.Drawing.Point(67, 451);
            this.ddlReason.Name = "ddlReason";
            this.ddlReason.Size = new System.Drawing.Size(249, 21);
            this.ddlReason.TabIndex = 136;
            // 
            // lblSchduleID
            // 
            this.lblSchduleID.AutoSize = true;
            this.lblSchduleID.Location = new System.Drawing.Point(281, 25);
            this.lblSchduleID.Name = "lblSchduleID";
            this.lblSchduleID.Size = new System.Drawing.Size(13, 13);
            this.lblSchduleID.TabIndex = 135;
            this.lblSchduleID.Text = "0";
            // 
            // lblIOMno
            // 
            this.lblIOMno.AutoSize = true;
            this.lblIOMno.Location = new System.Drawing.Point(421, 30);
            this.lblIOMno.Name = "lblIOMno";
            this.lblIOMno.Size = new System.Drawing.Size(13, 13);
            this.lblIOMno.TabIndex = 134;
            this.lblIOMno.Text = "0";
            // 
            // lblIOMnoonly
            // 
            this.lblIOMnoonly.AutoSize = true;
            this.lblIOMnoonly.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIOMnoonly.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblIOMnoonly.Location = new System.Drawing.Point(344, 29);
            this.lblIOMnoonly.Name = "lblIOMnoonly";
            this.lblIOMnoonly.Size = new System.Drawing.Size(71, 13);
            this.lblIOMnoonly.TabIndex = 133;
            this.lblIOMnoonly.Text = "IOMNo.  :-";
            // 
            // lblOrderScheStatus
            // 
            this.lblOrderScheStatus.AutoSize = true;
            this.lblOrderScheStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderScheStatus.Location = new System.Drawing.Point(321, 455);
            this.lblOrderScheStatus.Name = "lblOrderScheStatus";
            this.lblOrderScheStatus.Size = new System.Drawing.Size(105, 13);
            this.lblOrderScheStatus.TabIndex = 132;
            this.lblOrderScheStatus.Text = "BatchScheStatus";
            // 
            // btnUpdateSchedule
            // 
            this.btnUpdateSchedule.Location = new System.Drawing.Point(744, 451);
            this.btnUpdateSchedule.Name = "btnUpdateSchedule";
            this.btnUpdateSchedule.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateSchedule.TabIndex = 131;
            this.btnUpdateSchedule.Text = "Save";
            this.btnUpdateSchedule.UseVisualStyleBackColor = true;
            this.btnUpdateSchedule.Click += new System.EventHandler(this.btnUpdateSchedule_Click);
            // 
            // lblPendingQuantity
            // 
            this.lblPendingQuantity.AutoSize = true;
            this.lblPendingQuantity.Location = new System.Drawing.Point(749, 28);
            this.lblPendingQuantity.Name = "lblPendingQuantity";
            this.lblPendingQuantity.Size = new System.Drawing.Size(13, 13);
            this.lblPendingQuantity.TabIndex = 130;
            this.lblPendingQuantity.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(611, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 129;
            this.label6.Text = "Pending Quantity :-";
            // 
            // lblProdCode
            // 
            this.lblProdCode.AutoSize = true;
            this.lblProdCode.Location = new System.Drawing.Point(107, 29);
            this.lblProdCode.Name = "lblProdCode";
            this.lblProdCode.Size = new System.Drawing.Size(13, 13);
            this.lblProdCode.TabIndex = 127;
            this.lblProdCode.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 13);
            this.label17.TabIndex = 126;
            this.label17.Text = "Alis code :-";
            // 
            // dgvOrderItemSchedule
            // 
            this.dgvOrderItemSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItemSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colWareHousecode,
            this.colStorageCode,
            this.colProductCode,
            this.colProductName,
            this.colBatchNo,
            this.colMFG,
            this.colExpiryDate,
            this.colSelfLifePercentage,
            this.colUnrestricted,
            this.colAllocate});
            this.dgvOrderItemSchedule.Location = new System.Drawing.Point(9, 45);
            this.dgvOrderItemSchedule.Name = "dgvOrderItemSchedule";
            this.dgvOrderItemSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderItemSchedule.Size = new System.Drawing.Size(1210, 394);
            this.dgvOrderItemSchedule.TabIndex = 124;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "WareHouseCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Ware House Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "BatchNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "MFG Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ExpiryDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "ExpiryDate";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Unrestricted";
            this.dataGridViewTextBoxColumn4.HeaderText = "Stock";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "BatchNo";
            this.dataGridViewTextBoxColumn5.HeaderText = "Batch No";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn6.HeaderText = "Allocate";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SelfLifePercentage";
            this.dataGridViewTextBoxColumn7.HeaderText = "Allocate(input)";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn8.HeaderText = "Stock";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Allocate(input)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colWareHousecode
            // 
            this.colWareHousecode.DataPropertyName = "WareHouseCode";
            this.colWareHousecode.HeaderText = "Ware House Code";
            this.colWareHousecode.Name = "colWareHousecode";
            this.colWareHousecode.ReadOnly = true;
            // 
            // colStorageCode
            // 
            this.colStorageCode.DataPropertyName = "StorageCode";
            this.colStorageCode.HeaderText = "Storage Code";
            this.colStorageCode.Name = "colStorageCode";
            // 
            // colProductCode
            // 
            this.colProductCode.DataPropertyName = "ProductCode";
            this.colProductCode.HeaderText = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.ReadOnly = true;
            this.colProductCode.Visible = false;
            this.colProductCode.Width = 150;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.Width = 250;
            // 
            // colBatchNo
            // 
            this.colBatchNo.DataPropertyName = "BatchNo";
            this.colBatchNo.HeaderText = "Batch No";
            this.colBatchNo.Name = "colBatchNo";
            this.colBatchNo.ReadOnly = true;
            // 
            // colMFG
            // 
            this.colMFG.DataPropertyName = "ProductDate";
            this.colMFG.HeaderText = "MFG Date";
            this.colMFG.Name = "colMFG";
            this.colMFG.ReadOnly = true;
            // 
            // colExpiryDate
            // 
            this.colExpiryDate.DataPropertyName = "ExpiryDate";
            this.colExpiryDate.HeaderText = "ExpiryDate";
            this.colExpiryDate.Name = "colExpiryDate";
            this.colExpiryDate.ReadOnly = true;
            // 
            // colSelfLifePercentage
            // 
            this.colSelfLifePercentage.DataPropertyName = "SelfLifePercentage";
            this.colSelfLifePercentage.HeaderText = "SelfLifePercentage";
            this.colSelfLifePercentage.Name = "colSelfLifePercentage";
            this.colSelfLifePercentage.ReadOnly = true;
            // 
            // colUnrestricted
            // 
            this.colUnrestricted.DataPropertyName = "Quantity";
            this.colUnrestricted.HeaderText = "Stock";
            this.colUnrestricted.Name = "colUnrestricted";
            this.colUnrestricted.ReadOnly = true;
            // 
            // colAllocate
            // 
            this.colAllocate.HeaderText = "Allocate(input)";
            this.colAllocate.Name = "colAllocate";
            // 
            // frmBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 542);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBatch";
            this.Text = "frmBatch";
            this.Load += new System.EventHandler(this.frmBatch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItemSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOrderScheStatus;
        private System.Windows.Forms.Button btnUpdateSchedule;
        private System.Windows.Forms.Label lblPendingQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblProdCode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dgvOrderItemSchedule;
        private System.Windows.Forms.Label lblIOMno;
        private System.Windows.Forms.Label lblIOMnoonly;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label lblSchduleID;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox ddlReason;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.CheckBox IsDeliveryCompleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Label lableAName;
        private System.Windows.Forms.Label lblAliseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWareHousecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStorageCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMFG;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelfLifePercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnrestricted;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAllocate;
    }
}