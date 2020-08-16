using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ww_admin;
using ww_lib;
using System.IO;


namespace GlanMark
{
    public partial class frmItemCategory : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";

        //private String connectionString = null;
        //private SqlConnection sqlConnection = null;

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

        public frmItemCategory()
        {
            InitializeComponent();
        }

        private void frmItemCategory_Load(object sender, EventArgs e)
        {
            try
            {
                bindGrid();
                bindSatus();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmItemCategory frmItemCategory_Load \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bindSatus()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "GridRows";
                dt.Columns.Add("Value", Type.GetType("System.String"));
                dt.Columns.Add("Name", Type.GetType("System.String"));
                DataRow dr = dt.NewRow();
                dr["Value"] = "Yes";
                dr["Name"] = "Yes";
                DataRow dr1 = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                dr1["Value"] = "No";
                dr1["Name"] = "No";
                dt.Rows.InsertAt(dr1, 1);
                cmbStatus.DataSource = dt;
                cmbStatus.DisplayMember = "Name";
                cmbStatus.ValueMember = "Value";
                cmbStatus.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmItemCategory bindStatus \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmItemCategory save button \n" + ex.ToString();
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
                sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " ID,Name,IsActive FROM itemcategory WHERE ID NOT IN (SELECT TOP " + intSkip + " ID FROM itemcategory)");

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                ItemCategorydgv.DataSource = bindingSource;

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
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('itemcategory') AND IndId < 2");

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

        private void itemCategorydgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    id = int.Parse(ItemCategorydgv.Rows[e.RowIndex].Cells["colCategoryId"].Value.ToString());
                    if (e.ColumnIndex == ItemCategorydgv.Columns["colEdit"].Index)
                    {
                        //DataGridViewCell cell = InstitutionCategorydgv.Rows[e.RowIndex].Cells[1];
                        //InstitutionCategorydgv.CurrentCell = cell;
                        //InstitutionCategorydgv.Columns["colName"].ReadOnly = false;
                        //InstitutionCategorydgv.Rows[InstitutionCategorydgv.CurrentRow.Index].ReadOnly = false;
                        //InstitutionCategorydgv.BeginEdit(true);
                        //InstitutionCategorydgv.ReadOnly = false;
                        //InstitutionCategorydgv.CurrentRow.ReadOnly = false;
                        //DataGridViewRow r = InstitutionCategorydgv.Rows[e.RowIndex];
                        //if (r != null)
                        //{
                        //    r.ReadOnly = false;
                        //}

                        lblStatus.Text = "";
                        txtItemCategory.Text = ItemCategorydgv[ItemCategorydgv.Columns["colName"].Index, e.RowIndex].Value.ToString();
                        cmbStatus.SelectedValue = ItemCategorydgv[ItemCategorydgv.Columns["colStatus"].Index, e.RowIndex].Value.ToString();
                        lblHdnSource.Text = id.ToString();
                    }
                    else if (e.ColumnIndex == ItemCategorydgv.Columns["colDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this Category", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("UPDATE itemcategory SET IsActive = 'No' where ID='" + id + "'");
                            if (res.bStatus)
                            {
                                MessageBox.Show("Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                            //InstitutionCategorydgv.Rows.RemoveAt(InstitutionCategorydgv.CurrentRow.Index);
                            //sqlDataAdapter.Update(dataTable);

                            bindGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmInstitutionCategory save button \n" + ex.ToString();
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
                    if (lblHdnSource.Text == "0")
                    {
                        string query = "INSERT INTO itemcategory (Name, IsActive, LastModify) VALUES ('" + txtItemCategory.Text + "','" + cmbStatus.SelectedValue.ToString() + "', getdate())";
                        Result objResult = objCF.InsertQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Item Category Master Inserted Sucessfully";
                            ClearForm();
                            bindGrid();
                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            lblStatus.Text = objResult.strMessage;
                        }
                    }
                    else if (lblHdnSource.Text != "0")
                    {
                        string query = "UPDATE itemcategory set Name='" + txtItemCategory.Text + "',IsActive='" + cmbStatus.SelectedValue.ToString() + "',LastModify=getdate() WHERE ID='" + lblHdnSource.Text + "'";
                        Result objResult = objCF.ExecuteDMLQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Item Category Master Updated Sucessfully";
                            lblHdnSource.Text = "0";
                            ClearForm();
                            bindGrid();
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmItemCategory save button \n" + ex.ToString();
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
                bindGrid();
                ClearForm();
                lblHdnSource.Text = "0";
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmItemCategory save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateForm()
        {
            errorItemCategory.Clear();
            bool isValid = true;
            if (txtItemCategory.Text == "")
            {
                errorItemCategory.SetError(txtItemCategory, "Item Category");
                isValid = false;
            }

            //if (cmbStatus.SelectedValue == "")
            //{
            //    errorInstitution.SetError(cmbStatus, "Status");
            //    isValid = false;
            //}

            return isValid;
        }

        private void ClearForm()
        {
            cmbStatus.SelectedIndex = 0;
            txtItemCategory.Text = "";
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            objCF.fn_ExportToExcel("select * from ItemCategory", "Item Category", "ItemCategory");
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
       
        
    }
}
