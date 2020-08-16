using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using ww_admin;
using ww_lib;
using System.Configuration;
using System.IO;

namespace GlanMark
{
    public partial class frmCategory : Form
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
        

        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            bindGrid();
            bindSatus();
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
                sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " CategoryId,Code,Name,IsActive FROM CategoryMaster WHERE CategoryId NOT IN (SELECT TOP " + intSkip + " CategoryId FROM CategoryMaster)");
                //sqlDataAdapter = new SqlDataAdapter(selectQueryString, sqlConnection);
                //sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                Categorydgv.DataSource = bindingSource;

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
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('CategoryMaster') AND IndId < 2");

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
                string strError = DateTime.Now.ToString() + "\n Main Page/Location Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Categorydgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    id = int.Parse(Categorydgv.Rows[e.RowIndex].Cells["colCategoryId"].Value.ToString());
                    if (e.ColumnIndex == Categorydgv.Columns["colEdit"].Index)
                    {
                        lblStatus.Text = "";
                        txtCategoryCode.Text = Categorydgv[Categorydgv.Columns["colCode"].Index, e.RowIndex].Value.ToString();
                        txtcategoryname.Text = Categorydgv[Categorydgv.Columns["colName"].Index, e.RowIndex].Value.ToString();
                        cmbStatus.SelectedValue = Categorydgv[Categorydgv.Columns["colStatus"].Index, e.RowIndex].Value.ToString();
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
                    else if (e.ColumnIndex == Categorydgv.Columns["colDelete"].Index)
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
                    CommonFunction objCF = new CommonFunction();
                    if (lblHdnSource.Text == "0")
                    {
                        string query = "INSERT INTO CategoryMaster (Code,Name,IsActive,LastModify) VALUES ('" + txtCategoryCode.Text + "','" + txtcategoryname.Text + "','" + cmbStatus.SelectedValue.ToString() + "', getdate())";
                        Result objResult = objCF.InsertQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Category Master Inserted Sucessfully";
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
                        string query = "UPDATE CategoryMaster set Code='" + txtCategoryCode.Text + "',Name='" + txtcategoryname.Text + "',IsActive='" + cmbStatus.SelectedValue.ToString() + "',LastModify=getdate() WHERE CategoryId='" + lblHdnSource.Text + "'";
                        Result objResult = objCF.ExecuteDMLQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Category Master Updated Sucessfully";
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCategoryMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //try
            //{
            //    objCM = new CategoryMasterClass();
            //    objCM.iCode = Convert.ToInt32(txtCategoryCode.Text);
            //    objCM.strName = Convert.ToString(txtcategoryname.Text);
            //    objCM.strIsActive = Convert.ToString(cmbStatus.Text);

            //    ResultClass objResult = objCM.fn_InsertCategoryMaster();
            //    if (objResult.bStatus)
            //    {
            //        MessageBox.Show(objResult.strMessage.ToString());
            //        clearForm();
            //    }
            //    else
            //    {
            //        MessageBox.Show("error");
            //    }
            //}
            //catch(Exception ex)
            //{ 
            //}
        }

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        sqlDataAdapter.UpdateCommand = new SqlCommandBuilder(sqlDataAdapter).GetUpdateCommand();
        //        //sqlDataAdapter.UpdateCommand= "";
        //        sqlDataAdapter.Update(dataTable);
        //        bindGrid();
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

        private bool validateForm()
        {
            errorProvider.Clear();
            bool isValid = true;

            if (txtCategoryCode.Text == "")
            {
                errorProvider.SetError(txtCategoryCode, "Category Code");
                isValid = false;
            }

            if ( txtCategoryCode.Text == "")
            {
                errorProvider.SetError(txtCategoryCode, "Category Code");
                isValid = false;
            }

            if (txtcategoryname.Text == "")
            {
                errorProvider.SetError(txtcategoryname, "Category Name");
                isValid = false;
            }

            try
            {
                int intCode = int.Parse(txtCategoryCode.Text);
            }
            catch (Exception ex)
            {
                errorProvider.SetError(txtCategoryCode, "Only Numeric");
                return isValid = false;
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
            txtCategoryCode.Text = "";
            txtcategoryname.Text = "";
            cmbStatus.SelectedIndex = 0;
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

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            objCF.fn_ExportToExcel("select CategoryId as ID, Code, Name, IsActive, LastModify from CategoryMaster", "Category Master", "CategoryMaster");
        }


        //public void color_DataGridView()
        //{
        //    this.Categorygdv.DefaultCellStyle.ForeColor = Color.Coral;
        //    // Change back color of each row
        //    this.Categorygdv.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
        //    // Change GridLine Color
        //    this.Categorygdv.GridColor = Color.Blue;
        //    // Change Grid Border Style
        //    this.Categorygdv.BorderStyle = BorderStyle.Fixed3D;
        //}

        //public void colorbtnAlternate()
        //{

        //    this.Categorygdv.RowsDefaultCellStyle.BackColor = Color.White;
        //    this.Categorygdv.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
        //}




        //public void btnReorder()
        //{
        //    Categorygdv.Columns["Code"].DisplayIndex = 1;
        //    Categorygdv.Columns["Name"].DisplayIndex = 3;

        //}

        //private double Total()
        //{
        //    double tot = 0;
        //    // int i = 0;
        //    //for (i = 0; i < Categorygdv.Rows.Count; i++)
        //    //{
        //    //    tot = tot + Convert.ToDouble(Categorygdv.Rows[i].Cells["id"].Value);
        //    //}
        //    tot = Categorygdv.Rows.Count - 1;
        //    return tot;
        //}

        //public void hedernamechange()
        //{
        //    Categorygdv.Columns[0].HeaderText = "MyHeader1";
        //    Categorygdv.Columns[1].HeaderText = "MyHeader2";
        //}

        //public void resizedatagrid()
        //{
        //    Categorygdv.AutoResizeColumns();
        //    Categorygdv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //}

        //public void rowToBeSelected()
        //{
        //    int rowToBeSelected = 1; // third row
        //    if (Categorygdv.Rows.Count >= rowToBeSelected)
        //    {
        //        // Since index is zero based, you have to subtract 1
        //        Categorygdv.Rows[rowToBeSelected - 1].Selected = true;
        //    }

        //}

    }
}
