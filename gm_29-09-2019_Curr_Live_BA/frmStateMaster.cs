using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ww_lib;
using System.Configuration;
using ww_admin;
using System.Data.SqlClient;
using System.IO;

namespace GLENMARK
{
    public partial class frmStateMaster : Form
    {
        static string ConnectionString = ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString();
        string strLogFileName = "LOG/LogRecord.txt";
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private int id;

        public frmStateMaster()
        {
            InitializeComponent();
        }

        private void frmStateMaster_Load(object sender, EventArgs e)
        {
            BindCountry();
            BindCountryName();
            BindYesNo();
            //btnSave.Text = "Save";
        }

        public void BindYesNo()
        {
            //ddlISActive.Items.Insert(0, "Yes");
            //ddlISActive.Items.Insert(1, "No");
            //ddlISActive.Items.Insert(0, new ListItem("0", "Yes"));
            //ddlISActive.Items.Insert(1, new ListItem("1", "No"));
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

        private void BindCountryName()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
                dt = objCommon.GetDataTable("select * from Country order by name");
                DataRow dr = dt.NewRow();
                dr["CountryID"] = 0;
                dr["Name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlCounrtyName.DataSource = dt;
                ddlCounrtyName.DisplayMember = "Name";
                ddlCounrtyName.ValueMember = "CountryID";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmStateMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindCountry()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                
                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
                dt = objCommon.GetDataTable("select * from Country order by name");
                DataRow dr = dt.NewRow();
                dr["CountryID"] = 0;
                dr["Name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlCountry.DataSource = dt;
                ddlCountry.DisplayMember = "Name";
                ddlCountry.ValueMember = "CountryID";
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmStateMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlCountry.SelectedIndex) != "0")
            {
                BindStateMaster(int.Parse(ddlCountry.SelectedValue.ToString()));
            }
        }

        private void BindStateMaster(int CountryID)
        {
            try
            {
                if (CountryID > 0)
                {
                    //DataTable dt = new DataTable();
                    //SqlConnection Scon = new SqlConnection(ConnectionString);
                    //SqlDataAdapter Scom = new SqlDataAdapter("select StateID, CountryID, code, name, Status from State where CountryID = " + CountryID, Scon);
                    ////Scom.ExecuteNonQuery();
                    ////Scom.Fill(ds, "LocationMaster");
                    //Scom.Fill(dt);
                    //dgvStateMaster.DataSource = dt;  //ds.Tables["LocationMaster"].DefaultView;
                    //Scon.Close();

                    objC = new CommonFunction();
                    //objC.ExecuteDMLQuery();
                    //sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                    //selectQueryString = "SELECT Code,Name,IsActive FROM InstitutionMaster";
                    sqlDataAdapter = objC.GetSqlDataAdapter("select StateID, CountryID, code, name, Status from State where CountryID = " + CountryID);
                    //sqlDataAdapter = new SqlDataAdapter(selectQueryString, sqlConnection);
                    //sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                    dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable;
                    dgvStateMaster.DataSource = bindingSource;
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmStateMaster save button \n" + ex.ToString();
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
                        string query = "INSERT INTO State (CountryID, Code, Name, Status, LastModify) VALUES (" + int.Parse(ddlCounrtyName.SelectedValue.ToString()) + ",'" + txtStateCode.Text + "','" + txtStateName.Text + "'," + int.Parse(ddlISActive.SelectedValue.ToString()) + ", getdate())";
                        Result objResult = objCF.InsertQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "State Master Inserted Sucessfully";
                            ClearForm();
                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            lblStatus.Text = objResult.strMessage;
                        }
                    }
                    else if (lblID.Text != "0")
                    {
                        string query = "UPDATE State set CountryID = " + int.Parse(ddlCounrtyName.SelectedValue.ToString()) + ", Code = '" + txtStateCode.Text + "', Name = '" + txtStateName.Text + "', Status = " + int.Parse(ddlISActive.SelectedValue.ToString()) + ", LastModify = getdate() where StateID = " + lblID.Text;

                        Result objResult = objCF.ExecuteDMLQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "State Master Updated Sucessfully";
                            ClearForm();
                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            lblStatus.Text = objResult.strMessage;
                        }
                    }
                    if (Convert.ToString(ddlCountry.SelectedIndex) != "0")
                    {
                        BindStateMaster(int.Parse(ddlCountry.SelectedValue.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmStateMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtStateCode.Text = "";
            txtStateName.Text = "";
            ddlCounrtyName.SelectedIndex = 0;
            ddlISActive.SelectedIndex = 0;
            lblID.Text = "0";
            //btnSave.Text = "Save";
        }

        private bool validateForm()
        {
            errorState.Clear();
            bool isValid = true;
            if (txtStateName.Text == "")
            {
                errorState.SetError(txtStateName, "State");
                isValid = false;
            }

            if (txtStateCode.Text == "")
            {
                errorState.SetError(txtStateCode, "State");
                isValid = false;
            }

            if (ddlCounrtyName.SelectedIndex == 0)
            {
                errorState.SetError(ddlCounrtyName, "State");
                isValid = false;
            }

            if (txtStateCode.Text.Length > 5)
            {
                errorState.SetError(txtStateCode, "State");
                lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                lblStatus.Text = "State Code must be less than 5";
                isValid = false;
            }

            return isValid;
        }

        private void dgvStateMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    id = int.Parse(dgvStateMaster.Rows[e.RowIndex].Cells["colStateID"].Value.ToString());
                    
                    if (e.ColumnIndex == dgvStateMaster.Columns["colEdit"].Index)
                    {
                        //btnSave.Text = "Update";
                        ddlCounrtyName.SelectedIndex = int.Parse(ddlCountry.SelectedIndex.ToString());
                        txtStateName.Text = dgvStateMaster[dgvStateMaster.Columns["colName"].Index, e.RowIndex].Value.ToString();
                        txtStateCode.Text = dgvStateMaster[dgvStateMaster.Columns["colCode"].Index, e.RowIndex].Value.ToString();
                        ddlISActive.SelectedValue = dgvStateMaster[dgvStateMaster.Columns["colStatus"].Index, e.RowIndex].Value.ToString();
                        lblID.Text = id.ToString();

                    }

                    if (e.ColumnIndex == dgvStateMaster.Columns["colDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this State", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("UPDATE State SET Status = 0 where StateID = '" + id + "'");
                            if (res.bStatus)
                            {
                                MessageBox.Show("Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            if (Convert.ToString(ddlCountry.SelectedIndex) != "0")
                            {
                                BindStateMaster(int.Parse(ddlCountry.SelectedValue.ToString()));
                            }
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

        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        sqlDataAdapter.UpdateCommand = new SqlCommandBuilder(sqlDataAdapter).GetUpdateCommand();
        //        //sqlDataAdapter.UpdateCommand= "";
        //        sqlDataAdapter.Update(dataTable);
        //        if (Convert.ToString(ddlCountry.SelectedIndex) != "0")
        //        {
        //            BindStateMaster(int.Parse(ddlCountry.SelectedValue.ToString()));
        //        }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(ddlCountry.SelectedIndex) != "0")
                {
                    BindStateMaster(int.Parse(ddlCountry.SelectedValue.ToString()));
                }
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

        private void lblCountry_Click(object sender, EventArgs e)
        {

        }

        private void ddlCounrtyName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ddlISActive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtStateCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStateName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblIsActive_Click(object sender, EventArgs e)
        {

        }

        private void lblStateName_Click(object sender, EventArgs e)
        {

        }

        private void lblStateCode_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            
            if (Convert.ToString(ddlCountry.SelectedIndex) != "0")
            {
                objCF.fn_ExportToExcel("select * from State where CountryID = " + int.Parse(ddlCountry.SelectedValue.ToString()), "State", "State");
            }
            else
            {
                objCF.fn_ExportToExcel("select * from State", "State", "State");
            }
        }

        //private void dgvStateMaster_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{
        //    DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)dgvStateMaster.Rows[e.RowIndex].Cells["colStatus"].OwningColumn;
            
        //    int title = int.Parse(dgvTitles.Rows[e.RowIndex].Cells[2].Value.ToString());
        //    EDanaIILibraryWebService.LibraryDataSet.AvailableCopiesDataTable data = service.FindAvailableCopies(title);
        //    //combo.DataSource = data;
        //    //combo.ValueMember = "ISBNCopy";
        //    //combo.DisplayMember = "ISBNCopy";

        //    ddlISActive.Items.Insert(0, "Yes");
        //    ddlISActive.Items.Insert(1, "No");
        //    ddlISActive.SelectedIndex = 0;
        //}
        
        
    }
}
