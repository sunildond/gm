namespace gm
{
    partial class frmReadyForBilling
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
            this.gbDispatchDetail = new System.Windows.Forms.GroupBox();
            this.dgvBillingDoc = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.lblPageStatus = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.gbDispatchDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDispatchDetail
            // 
            this.gbDispatchDetail.Controls.Add(this.dgvBillingDoc);
            this.gbDispatchDetail.Location = new System.Drawing.Point(12, 37);
            this.gbDispatchDetail.Name = "gbDispatchDetail";
            this.gbDispatchDetail.Size = new System.Drawing.Size(1189, 431);
            this.gbDispatchDetail.TabIndex = 23;
            this.gbDispatchDetail.TabStop = false;
            this.gbDispatchDetail.Text = "Ready For Billing Detail";
            // 
            // dgvBillingDoc
            // 
            this.dgvBillingDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillingDoc.Location = new System.Drawing.Point(6, 16);
            this.dgvBillingDoc.Name = "dgvBillingDoc";
            this.dgvBillingDoc.Size = new System.Drawing.Size(1176, 409);
            this.dgvBillingDoc.TabIndex = 0;
            this.dgvBillingDoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBillingDoc_CellContentClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(832, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Export Data in to Excel File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPageStatus
            // 
            this.lblPageStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPageStatus.Enabled = false;
            this.lblPageStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPageStatus.Location = new System.Drawing.Point(551, 493);
            this.lblPageStatus.Name = "lblPageStatus";
            this.lblPageStatus.Size = new System.Drawing.Size(85, 20);
            this.lblPageStatus.TabIndex = 48;
            this.lblPageStatus.Text = "0 / 0";
            this.lblPageStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLast.Location = new System.Drawing.Point(662, 491);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(24, 23);
            this.btnLast.TabIndex = 47;
            this.btnLast.Text = ">|";
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNext.Location = new System.Drawing.Point(638, 491);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 23);
            this.btnNext.TabIndex = 46;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrevious.Location = new System.Drawing.Point(526, 491);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(24, 23);
            this.btnPrevious.TabIndex = 45;
            this.btnPrevious.Text = "<";
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFirst.Location = new System.Drawing.Point(502, 491);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(24, 23);
            this.btnFirst.TabIndex = 44;
            this.btnFirst.Text = "|<";
            // 
            // frmReadyForBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1213, 566);
            this.Controls.Add(this.lblPageStatus);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbDispatchDetail);
            this.Name = "frmReadyForBilling";
            this.Text = "frmReadyForBilling";
            this.Load += new System.EventHandler(this.frmReadyForBilling_Load);
            this.gbDispatchDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingDoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDispatchDetail;
        private System.Windows.Forms.DataGridView dgvBillingDoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPageStatus;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;

    }
}