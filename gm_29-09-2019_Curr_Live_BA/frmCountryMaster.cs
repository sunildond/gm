using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using ww_lib;
using ww_admin;
using System.IO;

namespace GLENMARK
{
    public partial class frmCountryMaster : Form
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

        public frmCountryMaster()
        {
            InitializeComponent();
        }

        private void frmCountryMaster_Load(object sender, EventArgs e)
        {
            BindCountryMaster();
            BindYesNo();
        }

        public void BindCountryMaster()
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCountryMaster save button \n" + ex.ToString();
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
                sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " CountryID, Name, Code, Status from Country WHERE CountryID NOT IN (SELECT TOP " + intSkip + " CountryID FROM Country)");
                
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvCountryMaster.DataSource = bindingSource;

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
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('Country') AND IndId < 2");

            return objres.iRecordId;

            // This select statement is very fast compare to SELECT COUNT(*)
            //string strSql = "SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('tblEmp') AND IndId < 2";
            //int intCount = 0;

            //SqlCommand cmd = this.mcnSample.CreateCommand();
            //cmd.CommandText = strSql;

            //intCount = (int)cmd.ExecuteScalar();
            //cmd.Dispose();

            //return intCount;
        }

        public void BindYesNo()
        {
            //ddlISActive.Items.Insert(0, "Yes");
            //ddlISActive.Items.Insert(1, "No");
            //ddlISActive.SelectedIndex = 0;
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "GridRows";
                dt.Columns.Add("Value", Type.GetType("System.String"));
                dt.Columns.Add("Name", Type.GetType("System.String"));
                DataRow dr = dt.NewRow();
                dr["Value"] = 1;
                dr["Name"] = "Yes";
                DataRow dr1 = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                dr1["Value"] = 0;
                dr1["Name"] = "No";
                dt.Rows.InsertAt(dr1, 1);
                ddlISActive.DataSource = dt;
                ddlISActive.DisplayMember = "Name";
                ddlISActive.ValueMember = "Value";
                ddlISActive.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Location Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        string query = "INSERT INTO Country (Name, Code, status, LastModify) VALUES ('" + txtCountryName.Text + "','" + txtCountryCode.Text + "'," + int.Parse(ddlISActive.SelectedValue.ToString()) + ", getdate())";
                        Result objResult = objCF.InsertQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Country Master Inserted Sucessfully";
                            ClearForm();
                            BindCountryMaster();
                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            lblStatus.Text = objResult.strMessage;
                        }
                    }
                    else if (lblID.Text != "0")
                    {
                        string query = "UPDATE country set Name = '" + txtCountryName.Text + "', Code = '"+txtCountryCode.Text+"', status = "+int.Parse(ddlISActive.SelectedValue.ToString())+", LastModify = getdate() where CountryID = " + lblID.Text;

                        Result objResult = objCF.ExecuteDMLQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Country Master Updated Sucessfully";
                            ClearForm();
                            BindCountryMaster();
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCountryMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtCountryName.Text = "";
            txtCountryCode.Text = "";
            ddlISActive.SelectedIndex = 0;
            lblID.Text = "0";
        }

        private bool validateForm()
        {
            errorCountry.Clear();
            bool isValid = true;
            if (txtCountryName.Text == "")
            {
                errorCountry.SetError(txtCountryName, "Country");
                isValid = false;
            }

            if (txtCountryCode.Text == "")
            {
                errorCountry.SetError(txtCountryCode, "Country");
                isValid = false;
            }

            if (txtCountryCode.Text.Length > 5)
            {
                errorCountry.SetError(txtCountryCode, "Country");
                lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                lblStatus.Text = "Country Code must be less than 5";
                isValid = false;
            }

            return isValid;
        }

        private void dgvCountryMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    id = int.Parse(dgvCountryMaster.Rows[e.RowIndex].Cells["colCountryID"].Value.ToString());

                    if (e.ColumnIndex == dgvCountryMaster.Columns["colEdit"].Index)
                    {
                        //btnSave.Text = "Update";
                        txtCountryName.Text = dgvCountryMaster[dgvCountryMaster.Columns["colName"].Index, e.RowIndex].Value.ToString();
                        txtCountryCode.Text = dgvCountryMaster[dgvCountryMaster.Columns["colCode"].Index, e.RowIndex].Value.ToString();
                        ddlISActive.SelectedValue = dgvCountryMaster[dgvCountryMaster.Columns["colStatus"].Index, e.RowIndex].Value.ToString();
                        lblID.Text = id.ToString();

                    }

                    if (e.ColumnIndex == dgvCountryMaster.Columns["colDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this Country", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("UPDATE Country SET Status = 0 where CountryID = '" + id + "'");
                            if (res.bStatus)
                            {
                                MessageBox.Show("Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            BindCountryMaster();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/dgvCountryMaster_CellContentClick \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                BindCountryMaster();
                ClearForm();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Location Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            objCF.fn_ExportToExcel("select * from Country", "Country", "Country");
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

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        sqlDataAdapter.UpdateCommand = new SqlCommandBuilder(sqlDataAdapter).GetUpdateCommand();
        //        //sqlDataAdapter.UpdateCommand= "";
        //        sqlDataAdapter.Update(dataTable);
        //        BindCountryMaster();
        //    }
        //    catch (Exception ex)
        //    {
        //        StreamWriter swLog = File.AppendText(strLogFileName);
        //        string strError = DateTime.Now.ToString() + "\n Main Page/Location Tab \n" + ex.ToString();
        //        swLog.WriteLine(strError);
        //        swLog.WriteLine();
        //        swLog.Close();
        //        MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

    }
}
