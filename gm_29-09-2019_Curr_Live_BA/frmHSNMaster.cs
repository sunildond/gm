using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using ww_lib;
using System.IO;
using ww_admin;
using System.Data.SqlClient;

namespace GLENMARK
{
    public partial class frmHSNMaster : Form
    {
        static string ConnectionString = ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString();
        string strLogFileName = "LOG/LogRecord.txt";
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private int id;

        // Page
        private int mintTotalRecords = 0;
        private int mintPageSize = 25;
        private int mintPageCount = 0;
        private int mintCurrentPage = 1;

        public frmHSNMaster()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool bstatus = true;
                bstatus = validateForm();
                if (bstatus == true)
                {
                    CommonFunction objCF = new CommonFunction();
                    if (lblID.Text == "0")
                    {
                        if (checkDuplicateHSNCode(txtHSNCode.Text.Trim().ToString()) != true)
                        {
                            string query = "INSERT INTO HSNMaster (HSNCode, Percentage, LastModify) VALUES ('" + txtHSNCode.Text + "','" + txtPercentage.Text + "', getdate())";
                            Result objResult = objCF.InsertQuery(query);
                            if (objResult.bStatus)
                            {
                                lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                                //lblStatus.Text = "HSN Master Inserted Sucessfully";
                                MessageBox.Show("HSN Master Inserted Sucessfully", "Information");
                                ClearForm();
                                BindHSNMaster();
                            }
                            else
                            {
                                lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                                lblStatus.Text = objResult.strMessage;
                            }
                        }
                        else
                            MessageBox.Show("HSN Code already exist!", "Information");
                    }
                    else if (lblID.Text != "0")
                    {
                        string query = "UPDATE HSNMaster set HSNCode = '" + txtHSNCode.Text + "', Percentage = '" + txtPercentage.Text + "', LastModify = getdate() where ID = " + lblID.Text;

                        Result objResult = objCF.ExecuteDMLQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            //lblStatus.Text = "HSN Master Updated Sucessfully";
                            MessageBox.Show("HSN Master Updated Sucessfully", "Information");
                            ClearForm();
                            BindHSNMaster();
                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            lblStatus.Text = objResult.strMessage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmHSNMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkDuplicateHSNCode(string HSNCode)
        {
            CommonFunction objCommon = new CommonFunction();
            DataTable dt = objCommon.GetDataTable("select * from HSNMaster where HSNCode = '" + HSNCode + "'");
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                BindHSNMaster();
                ClearForm();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n frmHSNMaster btnCancel_Click  \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHSNMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    id = int.Parse(dgvHSNMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());

                    if (e.ColumnIndex == dgvHSNMaster.Columns["colEdit"].Index)
                    {
                        //btnSave.Text = "Update";
                        txtHSNCode.Text = dgvHSNMaster[dgvHSNMaster.Columns["colHSNCode"].Index, e.RowIndex].Value.ToString();
                        txtPercentage.Text = dgvHSNMaster[dgvHSNMaster.Columns["colPercentage"].Index, e.RowIndex].Value.ToString();
                        lblID.Text = id.ToString();

                    }

                    if (e.ColumnIndex == dgvHSNMaster.Columns["colDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this HSN Code", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("Delete from HSNMaster where ID = '" + id + "'");
                            if (res.bStatus)
                            {
                                MessageBox.Show("Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            BindHSNMaster();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/dgvHSNMaster_CellContentClick \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmHSNMaster_Load(object sender, EventArgs e)
        {
            BindHSNMaster();
        }

        public void BindHSNMaster()
        {
            try
            {
                this.btnFirst.Enabled = true;
                this.btnPrevious.Enabled = true;
                this.lblStatus.Enabled = true;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;

                // For Page view.
                this.mintTotalRecords = getCount();
                this.mintPageCount = this.mintTotalRecords / this.mintPageSize;

                // Adjust page count if the last page contains partial page.
                if (this.mintTotalRecords % this.mintPageSize > 0)
                    this.mintPageCount++;

                this.mintCurrentPage = 0;

                loadPage();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmHSNMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadPage()
        {
            try
            {
                int intSkip = (this.mintCurrentPage * this.mintPageSize);

                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " ID, HSNCode, Percentage from HSNMaster WHERE ID NOT IN (SELECT TOP " + intSkip + " ID FROM HSNMaster)");

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvHSNMaster.DataSource = bindingSource;

                this.lblPageStatus.Text = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString();
            }
            catch (Exception ex)
            {
                //StreamWriter swLog = File.AppendText(strLogFileName);
                //string strError = DateTime.Now.ToString() + "\n Main Page/Location Tab \n" + ex.ToString();
                //swLog.WriteLine(strError);
                //swLog.WriteLine();
                //swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int getCount()
        {
            objC = new CommonFunction();
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('HSNMaster') AND IndId < 2");

            return objres.iRecordId;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.mintCurrentPage = 0;

            loadPage();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.mintCurrentPage == this.mintPageCount)
                this.mintCurrentPage = this.mintPageCount - 1;

            this.mintCurrentPage--;

            if (this.mintCurrentPage < 1)
                this.mintCurrentPage = 0;

            loadPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.mintCurrentPage++;

            if (this.mintCurrentPage > (this.mintPageCount - 1))
                this.mintCurrentPage = this.mintPageCount - 1;

            loadPage();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.mintCurrentPage = this.mintPageCount - 1;

            loadPage();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            objCF.fn_ExportToExcel("select HSNCode, Percentage from HSNMaster", "HSNMaster", "HSNMaster");
        }

        private void ClearForm()
        {
            txtHSNCode.Text = "";
            txtPercentage.Text = "0";
            lblID.Text = "0";
        }

        private bool validateForm()
        {
            errorHSNMaster.Clear();
            bool isValid = true;
            if (txtHSNCode.Text == "")
            {
                errorHSNMaster.SetError(txtHSNCode, "Country");
                isValid = false;
            }

            if (txtPercentage.Text == "")
            {
                errorHSNMaster.SetError(txtPercentage, "Percentage");
                isValid = false;
            }

            try
            {
                int iHSNCode = int.Parse(txtHSNCode.Text);
                if (iHSNCode == 0)
                {
                    MessageBox.Show("Please enter valid HSN Code !");

                    errorHSNMaster.SetError(txtHSNCode, "HSN Code");
                    isValid = false;
                }
            }
            catch (Exception ex)
            {
                if (txtHSNCode.Text.Trim() != "")
                {
                    MessageBox.Show("HSN Code Should by Numeric !");
                }
                errorHSNMaster.SetError(txtHSNCode, "HSN Code");
                return isValid = false;
            }

            //try
            //{
            //    int iPercentage = int.Parse(txtPercentage.Text);
            //    if (iPercentage == 0)
            //    {
            //        MessageBox.Show("Please enter valid percentage !");

            //        errorHSNMaster.SetError(txtPercentage, "Percentage");
            //        isValid = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (txtPercentage.Text.Trim() != "")
            //    {
            //        MessageBox.Show("Percentage Should by Numeric !");
            //    }
            //    errorHSNMaster.SetError(txtPercentage, "Percentage");
            //    return isValid = false;
            //}

            return isValid;
        }

    }
}
