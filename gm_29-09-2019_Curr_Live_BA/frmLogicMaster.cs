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
    public partial class frmLogicMaster : Form
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

        public frmLogicMaster()
        {
            InitializeComponent();
        }

        private void frmLogicMaster_Load(object sender, EventArgs e)
        {
            try
            {
                bindGrid();
                bindSatus();
                BindOrderType();
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
                cmbOrderType.DataSource = dt;
                cmbOrderType.DisplayMember = "Name";
                cmbOrderType.ValueMember = "Value";
                cmbOrderType.SelectedItem = 0;
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

        public void BindOrderType()
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                //SqlConnection conn = new SqlConnection(ConnectionString);
                objC = new CommonFunction();
                SqlDataAdapter da = objC.GetSqlDataAdapter("select OrderTypeName,ID from OrderTypeMaster order by OrderTypeName");
                //new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                da.Fill(dt);
                dr["ID"] = 0;
                dr["OrderTypeName"] = "select";
                dt.Rows.InsertAt(dr, 0);
                cmbOrderType.DataSource = dt;
                cmbOrderType.DisplayMember = "OrderTypeName";
                cmbOrderType.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmlocation Tab \n" + ex.ToString();
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
                sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " IOMLogicMaster.ID,IOMLogicMaster.OrderTypeId,OrderTypeMaster.OrderTypeName,IOMLogicMaster.StartingNumber,IOMLogicMaster.LastNumber,IOMLogicMaster.Year,IOMLogicMaster.LastUsed from IOMLogicMaster join OrderTypeMaster on IOMLogicMaster.OrderTypeId=OrderTypeMaster.ID WHERE IOMLogicMaster.ID NOT IN (SELECT TOP " + intSkip + " IOMLogicMaster.ID FROM IOMLogicMaster)");
                
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                IOMLogicdgv.DataSource = bindingSource;

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
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('IOMLogicMaster') AND IndId < 2");

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

        private void IOMLogicdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    id = int.Parse(IOMLogicdgv.Rows[e.RowIndex].Cells["colCategoryId"].Value.ToString());
                    if (e.ColumnIndex == IOMLogicdgv.Columns["colEdit"].Index)
                    {
                        lblStatus.Text = "";
                        cmbOrderType.SelectedValue = IOMLogicdgv[IOMLogicdgv.Columns["colOrderTypeId"].Index, e.RowIndex].Value.ToString();
                        txtStartingNumber.Text = IOMLogicdgv[IOMLogicdgv.Columns["colStartingNumber"].Index, e.RowIndex].Value.ToString();
                        txtLastNumber.Text = IOMLogicdgv[IOMLogicdgv.Columns["colLastNumber"].Index, e.RowIndex].Value.ToString();
                        txtYear.Text = IOMLogicdgv[IOMLogicdgv.Columns["colYear"].Index, e.RowIndex].Value.ToString();
                        
                        lblHdnSource.Text = id.ToString();
                    }
                    //else if (e.ColumnIndex == IOMLogicdgv.Columns["colDelete"].Index)
                    //{
                    //    var result = MessageBox.Show("Do you want delete this Category", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //    if (result == DialogResult.Yes)
                    //    {
                    //        objC = new CommonFunction();
                    //        Result res = objC.ExecuteDMLQuery("UPDATE IOMLogicMaster SET IsActive = 'No' where ID='" + id + "'");
                    //        if (res.bStatus)
                    //        {
                    //            MessageBox.Show("Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        }
                    //        else
                    //        {
                    //            MessageBox.Show("Record not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        }


                    //        //InstitutionCategorydgv.Rows.RemoveAt(InstitutionCategorydgv.CurrentRow.Index);
                    //        //sqlDataAdapter.Update(dataTable);

                    //        bindGrid();
                    //    }
                    //}
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
                        string query = "INSERT INTO IOMLogicMaster (OrderTypeId,StartingNumber,LastNumber,Year,LastModify) VALUES ('" + cmbOrderType.SelectedValue.ToString() + "','" + txtStartingNumber.Text + "','" + txtLastNumber.Text + "','" + txtYear.Text + "', getdate())";
                        Result objResult = objCF.InsertQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "IOM Logic Master Inserted Sucessfully";
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
                        string query = "UPDATE IOMLogicMaster set OrderTypeId='" + cmbOrderType.SelectedValue.ToString() + "',StartingNumber='" + txtStartingNumber.ToString() + "',LastNumber='" + txtLastNumber.Text + "',Year='" + txtYear.Text + "',LastModify=getdate() WHERE ID='" + lblHdnSource.Text + "'";
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
            errorIOmLogic.Clear();
            bool isValid = true;
            if (txtStartingNumber.Text == "")
            {
                errorIOmLogic.SetError(txtStartingNumber, "Starting Number");
                isValid = false;
            }

            if (txtLastNumber.Text == "")
            {
                errorIOmLogic.SetError(txtLastNumber, "Last Number");
                isValid = false;
            }

            if (txtYear.Text == "")
            {
                errorIOmLogic.SetError(txtYear, "Year");
                isValid = false;
            }

            if (cmbOrderType.SelectedIndex == 0)
            {
                errorIOmLogic.SetError(cmbOrderType, "Order Type");
                isValid = false;
            }

            try
            {
                int intStartingNumber = int.Parse(txtStartingNumber.Text);
            }
            catch (Exception ex)
            {
                errorIOmLogic.SetError(txtStartingNumber, "Only Numeric");
                return isValid = false;
            }

            try
            {
                int intLastNumber = int.Parse(txtLastNumber.Text);
            }
            catch (Exception ex)
            {
                errorIOmLogic.SetError(txtLastNumber, "Only Numeric");
                return isValid = false;
            }

            try
            {
                int intYear = int.Parse(txtYear.Text);
            }
            catch (Exception ex)
            {
                errorIOmLogic.SetError(txtYear, "Only Numeric");
                return isValid = false;
            }


            return isValid;
        }

        private void ClearForm()
        {
            cmbOrderType.SelectedIndex = 0;
            txtStartingNumber.Text = "";
            txtLastNumber.Text = "";
            txtYear.Text = "";
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            objCF.fn_ExportToExcel("select * from IOMLogicMaster", "IOM Logic Master", "IOMLogicMaster");
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
