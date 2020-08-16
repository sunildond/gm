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
using ww_admin;
using System.IO;
using System.Data.SqlClient;


namespace GlanMark
{
    public partial class frmTaxMaster : Form
    {
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        //private String selectQueryString = null;
        private int id;

        string strLogFileName = "LOG/LogRecord.txt";

        // Page
        private int mintTotalRecords = 0;
        private int mintPageSize = 20;
        private int mintPageCount = 0;
        private int mintCurrentPage = 1;

        public frmTaxMaster()
        {
            InitializeComponent();
        }

        private void frmTaxMaster_Load(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "";
                bindGrid();
                bindSatus();
                BindTaxType();
                //color_DataGridView();
                //colorbtnAlternate();
                //resizedatagrid();
                //rowToBeSelected();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmTaxMaster Tab \n" + ex.ToString();
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
                string strError = DateTime.Now.ToString() + "\n Main Page/Location Tab \n" + ex.ToString();
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmTaxMaster Tab \n" + ex.ToString();
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
                sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " TaxMaster.ID,TaxMaster.TaxTypeID, TaxTypeMaster.TaxType ,TaxMaster.TaxCode,TaxMaster.Description,TaxMaster.Percentage,TaxMaster.IsActive from TaxMaster inner join TaxTypeMaster on TaxMaster.TaxTypeID=TaxTypeMaster.ID WHERE TaxMaster.ID NOT IN (SELECT TOP " + intSkip + " TaxMaster.ID FROM TaxMaster)");
                
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                taxmasterdgv.DataSource = bindingSource;

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
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('TaxMaster') AND IndId < 2");

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

        private void taxmasterdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    id = int.Parse(taxmasterdgv.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                    if (e.ColumnIndex == taxmasterdgv.Columns["colEdit"].Index)
                    {
                        lblStatus.Text = "";
                        txtTaxCode.Text = taxmasterdgv[taxmasterdgv.Columns["colTaxCode"].Index, e.RowIndex].Value.ToString();
                        txtDesc.Text = taxmasterdgv[taxmasterdgv.Columns["colDescription"].Index, e.RowIndex].Value.ToString();
                        txtPer.Text = taxmasterdgv[taxmasterdgv.Columns["colPercentage"].Index, e.RowIndex].Value.ToString();
                        cmbStatus.SelectedValue = taxmasterdgv[taxmasterdgv.Columns["colStatus"].Index, e.RowIndex].Value.ToString();

                        if (taxmasterdgv[taxmasterdgv.Columns["colTaxTypeID"].Index, e.RowIndex].Value.ToString() != "")
                        {
                            cmbTextType.SelectedValue = int.Parse(taxmasterdgv[taxmasterdgv.Columns["colTaxTypeID"].Index, e.RowIndex].Value.ToString());
                        }
                        else
                        {
                            cmbTextType.SelectedValue = 0;
                        }

                        lblHdnSource.Text = id.ToString();

                    }
                    else if (e.ColumnIndex == taxmasterdgv.Columns["colDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this TaxMaster", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("UPDATE TaxMaster SET IsActive = 'No' where ID='" + id + "'");
                            if (res.bStatus)
                            {
                                MessageBox.Show("Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            //locationdgv.Rows.RemoveAt(locationdgv.CurrentRow.Index);
                            //sqlDataAdapter.Update(dataTable);

                            bindGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmTaxMaster Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindTaxType()
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                objC = new CommonFunction();
                SqlDataAdapter da = objC.GetSqlDataAdapter("select * from TaxTypeMaster order by TaxType");
                da.Fill(dt);
                dr["ID"] = 0;
                dr["TaxType"] = "select Tax Type";
                dt.Rows.InsertAt(dr, 0);
                cmbTextType.DataSource = dt;
                cmbTextType.DisplayMember = "TaxType";
                cmbTextType.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmTaxMaster Tab \n" + ex.ToString();
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
                        string query = "INSERT INTO TaxMaster (TaxTypeID,TaxCode, Description, Percentage, IsActive, LastModify) VALUES ('" + cmbTextType.SelectedValue.ToString() + "','" + txtTaxCode.Text + "','" + txtDesc.Text + "','" + txtPer.Text + "','" + cmbStatus.SelectedValue.ToString() + "', getdate())";
                        Result objResult = objCF.InsertQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Tax Master Inserted Sucessfully";
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
                        string query = "UPDATE TaxMaster set TaxTypeID='" + cmbTextType.SelectedValue.ToString() + "',TaxCode='" + txtTaxCode.Text + "',Description='" + txtDesc.Text + "',Percentage='" + txtPer.Text.ToString() + "',IsActive='" + cmbStatus.SelectedValue.ToString() + "',LastModify=getdate() WHERE ID='" + lblHdnSource.Text + "'";
                        Result objResult = objCF.ExecuteDMLQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Tax Master Updated Sucessfully";
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmTaxMaster Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateForm()
        {
            errorTaxMaster.Clear();
            bool isValid = true;
            if (txtTaxCode.Text == "")
            {
                errorTaxMaster.SetError(txtTaxCode, "Tax Code");
                isValid = false;
            }

            if (txtPer.Text == "")
            {
                errorTaxMaster.SetError(txtPer, "Percentage");
                isValid = false;
            }

            if (cmbTextType.SelectedIndex == 0)
            {
                errorTaxMaster.SetError(cmbTextType, "Location");
                isValid = false;
            }

            return isValid;
        }

        private void ClearForm()
        {
            txtTaxCode.Text = "";
            txtDesc.Text = "";
            cmbTextType.SelectedIndex = 0;
            txtPer.Text = "";
            cmbStatus.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                bindGrid();
                lblHdnSource.Text = "0";
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
            objCF.fn_ExportToExcel("select TaxMaster.*, (case when TaxTypeID is not null then (select TaxType from TaxTypeMaster where TaxTypeMaster.ID = TaxMaster.TaxTypeID) end) TaxType from TaxMaster", "TaxMaster", "TaxMaster");
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
