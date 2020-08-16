namespace GLENMARK
{
    partial class frmStateMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvStateMaster = new System.Windows.Forms.DataGridView();
            this.colStateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblSelectCountry = new System.Windows.Forms.Label();
            this.ddlCountry = new System.Windows.Forms.ComboBox();
            this.ddlCounrtyName = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlISActive = new System.Windows.Forms.ComboBox();
            this.txtStateCode = new System.Windows.Forms.TextBox();
            this.txtStateName = new System.Windows.Forms.TextBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.lblStateCode = new System.Windows.Forms.Label();
            this.lblStateName = new System.Windows.Forms.Label();
            this.errorState = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblID = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStateMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorState)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(244, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvStateMaster
            // 
            this.dgvStateMaster.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(241)))), ((int)(((byte)(214)))));
            this.dgvStateMaster.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStateMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStateMaster.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvStateMaster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStateMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStateMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStateMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStateID,
            this.colCountryID,
            this.colCode,
            this.colName,
            this.colStatus,
            this.colEdit,
            this.colDelete});
            this.dgvStateMaster.EnableHeadersVisualStyles = false;
            this.dgvStateMaster.GridColor = System.Drawing.SystemColors.Control;
            this.dgvStateMaster.Location = new System.Drawing.Point(6, 46);
            this.dgvStateMaster.MultiSelect = false;
            this.dgvStateMaster.Name = "dgvStateMaster";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStateMaster.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStateMaster.RowHeadersVisible = false;
            this.dgvStateMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStateMaster.Size = new System.Drawing.Size(542, 490);
            this.dgvStateMaster.TabIndex = 21;
            this.dgvStateMaster.VirtualMode = true;
            this.dgvStateMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStateMaster_CellContentClick);
            // 
            // colStateID
            // 
            this.colStateID.DataPropertyName = "StateID";
            this.colStateID.HeaderText = "StateID";
            this.colStateID.Name = "colStateID";
            this.colStateID.Visible = false;
            this.colStateID.Width = 56;
            // 
            // colCountryID
            // 
            this.colCountryID.DataPropertyName = "CountryID";
            this.colCountryID.HeaderText = "CountryID";
            this.colCountryID.Name = "colCountryID";
            this.colCountryID.Visible = false;
            this.colCountryID.Width = 69;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Width = 61;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 64;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.Width = 68;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "Edit";
            this.colEdit.Image = global::gm.Properties.Resources.edit;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 35;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "Delete";
            this.colDelete.Image = global::gm.Properties.Resources.cross1;
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDelete.Width = 69;
            // 
            // lblSelectCountry
            // 
            this.lblSelectCountry.AutoSize = true;
            this.lblSelectCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectCountry.Location = new System.Drawing.Point(41, 21);
            this.lblSelectCountry.Name = "lblSelectCountry";
            this.lblSelectCountry.Size = new System.Drawing.Size(103, 15);
            this.lblSelectCountry.TabIndex = 1;
            this.lblSelectCountry.Text = "Select Country:";
            // 
            // ddlCountry
            // 
            this.ddlCountry.FormattingEnabled = true;
            this.ddlCountry.Location = new System.Drawing.Point(148, 19);
            this.ddlCountry.Name = "ddlCountry";
            this.ddlCountry.Size = new System.Drawing.Size(261, 21);
            this.ddlCountry.TabIndex = 2;
            this.ddlCountry.SelectedIndexChanged += new System.EventHandler(this.ddlCountry_SelectedIndexChanged);
            // 
            // ddlCounrtyName
            // 
            this.ddlCounrtyName.FormattingEnabled = true;
            this.ddlCounrtyName.Location = new System.Drawing.Point(165, 75);
            this.ddlCounrtyName.Name = "ddlCounrtyName";
            this.ddlCounrtyName.Size = new System.Drawing.Size(190, 21);
            this.ddlCounrtyName.TabIndex = 17;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(87, 78);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(74, 13);
            this.lblCountry.TabIndex = 16;
            this.lblCountry.Text = "Country Name";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(141, 291);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlISActive
            // 
            this.ddlISActive.FormattingEnabled = true;
            this.ddlISActive.Location = new System.Drawing.Point(165, 175);
            this.ddlISActive.Name = "ddlISActive";
            this.ddlISActive.Size = new System.Drawing.Size(100, 21);
            this.ddlISActive.TabIndex = 13;
            // 
            // txtStateCode
            // 
            this.txtStateCode.Location = new System.Drawing.Point(165, 141);
            this.txtStateCode.Name = "txtStateCode";
            this.txtStateCode.Size = new System.Drawing.Size(100, 20);
            this.txtStateCode.TabIndex = 12;
            // 
            // txtStateName
            // 
            this.txtStateName.Location = new System.Drawing.Point(165, 109);
            this.txtStateName.Name = "txtStateName";
            this.txtStateName.Size = new System.Drawing.Size(190, 20);
            this.txtStateName.TabIndex = 11;
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(116, 178);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(45, 13);
            this.lblIsActive.TabIndex = 10;
            this.lblIsActive.Text = "IsActive";
            // 
            // lblStateCode
            // 
            this.lblStateCode.AutoSize = true;
            this.lblStateCode.Location = new System.Drawing.Point(98, 144);
            this.lblStateCode.Name = "lblStateCode";
            this.lblStateCode.Size = new System.Drawing.Size(60, 13);
            this.lblStateCode.TabIndex = 9;
            this.lblStateCode.Text = "State Code";
            // 
            // lblStateName
            // 
            this.lblStateName.AutoSize = true;
            this.lblStateName.Location = new System.Drawing.Point(95, 112);
            this.lblStateName.Name = "lblStateName";
            this.lblStateName.Size = new System.Drawing.Size(63, 13);
            this.lblStateName.TabIndex = 8;
            this.lblStateName.Text = "State Name";
            // 
            // errorState
            // 
            this.errorState.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorState.ContainerControl = this;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(116, 371);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStateMaster);
            this.groupBox1.Controls.Add(this.ddlCountry);
            this.groupBox1.Controls.Add(this.lblSelectCountry);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 542);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "State Master";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExportToExcel);
            this.groupBox2.Controls.Add(this.lblID);
            this.groupBox2.Controls.Add(this.ddlCounrtyName);
            this.groupBox2.Controls.Add(this.lblStateCode);
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.lblStateName);
            this.groupBox2.Controls.Add(this.lblIsActive);
            this.groupBox2.Controls.Add(this.lblCountry);
            this.groupBox2.Controls.Add(this.txtStateName);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.txtStateCode);
            this.groupBox2.Controls.Add(this.ddlISActive);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(589, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 542);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add/Edit State Master";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(119, 235);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(13, 13);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "0";
            this.lblID.Visible = false;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Location = new System.Drawing.Point(393, 487);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(124, 27);
            this.btnExportToExcel.TabIndex = 46;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // frmStateMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1192, 566);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmStateMaster";
            this.Text = "State Master";
            this.Load += new System.EventHandler(this.frmStateMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStateMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorState)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSelectCountry;
        private System.Windows.Forms.ComboBox ddlCountry;
        private System.Windows.Forms.ErrorProvider errorState;
        private System.Windows.Forms.ComboBox ddlCounrtyName;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox ddlISActive;
        private System.Windows.Forms.TextBox txtStateCode;
        private System.Windows.Forms.TextBox txtStateName;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblStateCode;
        private System.Windows.Forms.Label lblStateName;
        private System.Windows.Forms.DataGridView dgvStateMaster;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStateID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnExportToExcel;
    }
}