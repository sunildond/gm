using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ww_admin;
using ww_lib;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace gm
{
    public partial class frmUserModuleMaster : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        //private String selectQueryString = null;
        private int id;

        // Page
        private int mintTotalRecords = 0;
        private int mintPageSize = 20;
        private int mintPageCount = 0;
        private int mintCurrentPage = 1;
        
        public frmUserModuleMaster()
        {
            InitializeComponent();
        }

        private void frmUserModuleMaster_Load(object sender, EventArgs e)
        {
            bindGrid();
            bindUsername();
        }

        public void bindGrid()
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
                string strError = DateTime.Now.ToString() + "\n Main Page/Category Tab \n" + ex.ToString();
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
                sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " UserMaster.user_full_name,UserMaster.user_name,UserMaster.user_email,UserMaster.IsActive from UserModuleRelation join UserMaster on UserModuleRelation.user_id=UserMaster.user_id WHERE UserModuleRelation.user_module_id NOT IN (SELECT TOP " + intSkip + " user_module_id FROM UserModuleRelation)");
                //sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " user_id,user_name,IsActive from UserMaster join UserTypeMaster on UserMaster.user_type_id=UserTypeMaster.ID WHERE user_id NOT IN (SELECT TOP " + intSkip + " user_id FROM UserMaster)");
                //sqlDataAdapter = new SqlDataAdapter(selectQueryString, sqlConnection);
                //sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvUserMaster.DataSource = bindingSource;

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
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('UserModuleRelation') AND IndId < 2");

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

        private void bindUsername()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                cmbUsername.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbUsername.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select  user_name ,user_id  from UserMaster where isActive = 'Yes' order by user_name");
                
                DataRow dr = dt.NewRow();
                dr["user_id"] = 0;
                dr["user_name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                cmbUsername.DataSource = dt;
                cmbUsername.DisplayMember = "user_name";
                cmbUsername.ValueMember = "user_id";
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

        private void bindModule()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                dt = objCommon.GetDataTable("select ModuleMaster.module_id,ModuleMaster.module_name from ModuleMaster");
                bindingSource = new BindingSource();
                bindingSource.DataSource = dt;
                dgvModule.DataSource = bindingSource;
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

        private void dgvUserMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    id = int.Parse(dgvUserMaster.Rows[e.RowIndex].Cells["colUserId"].Value.ToString());
                    if (e.ColumnIndex == dgvUserMaster.Columns["colEdit"].Index)
                    {
                        //lblStatus.Text = "";
                        //txtUserName.Text = dgvUserMaster[dgvUserMaster.Columns["colUserName"].Index, e.RowIndex].Value.ToString();
                        //txtUserName.Enabled = false;
                        //txtUserFullName.Text = dgvUserMaster[dgvUserMaster.Columns["colName"].Index, e.RowIndex].Value.ToString();
                        //txtUserEmail.Text = dgvUserMaster[dgvUserMaster.Columns["colEmail"].Index, e.RowIndex].Value.ToString();
                        ////txtUserPassword = dgvUserMaster[dgvUserMaster.Columns["colCode"].Index, e.RowIndex].Value.ToString();

                        //cmbStatus.SelectedValue = dgvUserMaster[dgvUserMaster.Columns["colStatus"].Index, e.RowIndex].Value.ToString();
                        lblHdnSource.Text = id.ToString();

                        //DataGridViewCell cell = Categorydgv.Rows[e.RowIndex].Cells[1];
                        //Categorydgv.CurrentCell = cell;
                        //Categorydgv.Columns["colName"].ReadOnly = false;
                        //Categorydgv.Rows[Categorydgv.CurrentRow.Index].ReadOnly = false;
                        //Categorydgv.BeginEdit(true);
                        //Categorydgv.ReadOnly = false;
                        //Categorydgv.CurrentRow.ReadOnly = false;
                        //DataGridViewRow r = Categorydgv.Rows[e.RowIndex];
                        //if (r != null)
                        //{
                        //    r.ReadOnly = false;
                        //}
                    }
                    else if (e.ColumnIndex == dgvUserMaster.Columns["colDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this Category", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("UPDATE CategoryMaster SET IsActive = 'No' where CategoryId='" + id + "'");
                            if (res.bStatus)
                            {
                                MessageBox.Show("Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                            //Categorydgv.Rows.RemoveAt(Categorydgv.CurrentRow.Index);
                            //sqlDataAdapter.Update(dataTable);

                            bindGrid();
                        }
                    }
                }
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
                    //CommonFunction objCF = new CommonFunction();
                    //if (lblHdnSource.Text == "0")
                    //{
                    //    string query = "select * from UserMaster where user_name = '" + txtUserName.Text + "'";
                    //    Result objResult = objCF.ExecuteReaderQuery(query);
                    //    if (!objResult.bStatus)
                    //    {
                    //        query = "INSERT INTO UserMaster (user_full_name,user_name,user_password,user_email,IsActive) VALUES ('" + txtUserFullName.Text + "','" + txtUserName.Text + "','" + txtUserPassword.Text + "','" + txtUserEmail.Text + "','" + cmbStatus.SelectedValue.ToString() + "')";
                    //        objResult = objCF.InsertQuery(query);
                    //        if (objResult.bStatus)
                    //        {
                    //            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                    //            lblStatus.Text = "User Master Inserted Sucessfully";
                    //            ClearForm();
                    //            bindGrid();
                    //        }
                    //        else
                    //        {
                    //            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    //            lblStatus.Text = objResult.strMessage;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    //        lblStatus.Text = "Same Username Present";
                    //    }
                    //}
                    //else if (lblHdnSource.Text != "0")
                    //{
                    //    string query = "UPDATE UserMaster set user_full_name='" + txtUserFullName.Text + "',user_password='" + txtUserPassword.Text + "',user_email='" + txtUserEmail.Text + "',IsActive='" + cmbStatus.SelectedValue.ToString() + "' WHERE user_id='" + lblHdnSource.Text + "'";
                    //    Result objResult = objCF.ExecuteDMLQuery(query);
                    //    if (objResult.bStatus)
                    //    {
                    //        lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                    //        lblStatus.Text = "User Master Updated Sucessfully";
                    //        lblHdnSource.Text = "0";
                    //        ClearForm();
                    //        bindGrid();
                    //        txtUserName.Enabled = true;
                    //    }
                    //    else
                    //    {
                    //        lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    //        lblStatus.Text = objResult.strMessage;
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCategoryMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool validateForm()
        {
            errorProvider.Clear();
            bool isValid = true;

            if (cmbUsername.SelectedIndex <= 0)
            {
                errorProvider.SetError(cmbUsername, "User Name");
                isValid = false;
            }
                  

            return isValid;
        }

        private void ClearForm()
        {
            cmbUsername.SelectedIndex = 0;
            dgvModule.DataSource = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                bindGrid();
                ClearForm();
                lblHdnSource.Text = "0";
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

        ////private void btnExportToExcel_Click(object sender, EventArgs e)
        ////{
        ////    //CommonFunction objCF = new CommonFunction();
        ////    //objCF.fn_ExportToExcel("select CategoryId as ID, Code, Name, IsActive, LastModify from CategoryMaster", "Category Master", "CategoryMaster");
        ////}

        

        
    }
}
