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

namespace GlanMark
{
    public partial class frmlocation : Form
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

        public frmlocation()
        {
            InitializeComponent();
        }

        private void frmlocation_Load(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "";
                bindGrid();
                bindSatus();
                BindCountry();
                bindTaxOn();
                //color_DataGridView();
                //colorbtnAlternate();
                //resizedatagrid();
                //rowToBeSelected();
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

        private void bindTaxOn()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "GridRows";
                dt.Columns.Add("Value", Type.GetType("System.String"));
                dt.Columns.Add("Name", Type.GetType("System.String"));
                DataRow dr = dt.NewRow();
                dr["Value"] = "MRP";
                dr["Name"] = "MRP";
                DataRow dr1 = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                dr1["Value"] = "PTD";
                dr1["Name"] = "PTD";
                dt.Rows.InsertAt(dr1, 1);
                ddlTaxOn.DataSource = dt;
                ddlTaxOn.DisplayMember = "Name";
                ddlTaxOn.ValueMember = "Value";
                ddlTaxOn.SelectedItem = 0;
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
                string strError = DateTime.Now.ToString() + "\n Main Page/Location Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadPage()
        {
            try
            {
                int intSkip = (this.mintCurrentPage * this.mintPageSize);

                objC = new CommonFunction();

                string sqlSelect = "SELECT TOP " + this.mintPageSize + " LocationId, CountryID, StateCode, LocationCode, DispatchThru, TinVatNo, TaxOn, Tax, EffectiveTaxRate, DrugLicense1, DrugLicense2, Address1, Address2, IsActive FROM LocationMaster WHERE LocationId NOT IN (SELECT TOP " + intSkip + " LocationId FROM LocationMaster) ";
                if (DBSessionUser.iUser_Type == 2)
                {
                    sqlSelect += "  and LocationCode = '" + DBSessionUser.strUser_Name + "'";
                }
                sqlDataAdapter = objC.GetSqlDataAdapter(sqlSelect);
                //sqlDataAdapter = new SqlDataAdapter(selectQueryString, sqlConnection);
                //sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                locationdgv.DataSource = bindingSource;

                this.lblPageStatus.Text = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmlocation Tab Bind Grid \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int getCount()
        {
            objC = new CommonFunction();
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('LocationMaster') AND IndId < 2");

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


        private void locationdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        //    try
        //    {
                if (e.RowIndex != -1)
                {
                    id = int.Parse(locationdgv.Rows[e.RowIndex].Cells["colCategoryId"].Value.ToString());
                    if (e.ColumnIndex == locationdgv.Columns["colEdit"].Index)
                    {
                        lblStatus.Text = "";
                        txtLocCode.Text = locationdgv[locationdgv.Columns["colLocationCode"].Index, e.RowIndex].Value.ToString();
                        txtLocName.Text = locationdgv[locationdgv.Columns["colDispatchThru"].Index, e.RowIndex].Value.ToString();
                        if (locationdgv[locationdgv.Columns["colAddress1"].Index, e.RowIndex].Value != null)
                            txtAddress1.Text = locationdgv[locationdgv.Columns["colAddress1"].Index, e.RowIndex].Value.ToString();

                        if (locationdgv[locationdgv.Columns["colAddress2"].Index, e.RowIndex].Value != null)
                            txtAddress2.Text = locationdgv[locationdgv.Columns["colAddress2"].Index, e.RowIndex].Value.ToString();

                        if (locationdgv[locationdgv.Columns["colDrugLicense1"].Index, e.RowIndex].Value != null)
                            txtDrugLicense1.Text = locationdgv[locationdgv.Columns["colDrugLicense1"].Index, e.RowIndex].Value.ToString();

                        if (locationdgv[locationdgv.Columns["colDrugLicense2"].Index, e.RowIndex].Value != null)
                            txtDrugLicense2.Text = locationdgv[locationdgv.Columns["colDrugLicense2"].Index, e.RowIndex].Value.ToString();

                        if (locationdgv[locationdgv.Columns["colTinVatNo"].Index, e.RowIndex].Value != null)
                            txtTINVATNo.Text = locationdgv[locationdgv.Columns["colTinVatNo"].Index, e.RowIndex].Value.ToString();

                        if (locationdgv[locationdgv.Columns["colTax"].Index, e.RowIndex].Value != null)
                            txtTax.Text = locationdgv[locationdgv.Columns["colTax"].Index, e.RowIndex].Value.ToString();

                            txtEffectiveTAXRate.Text = locationdgv[locationdgv.Columns["colEffectiveTaxRate"].Index, e.RowIndex].Value.ToString();
                        
                        
                        if (locationdgv[locationdgv.Columns["colTaxOn"].Index, e.RowIndex].Value != null)
                            ddlTaxOn.SelectedValue = locationdgv[locationdgv.Columns["colTaxOn"].Index, e.RowIndex].Value.ToString();

                       // cmbStatus.SelectedValue = locationdgv[locationdgv.Columns["colStatus"].Index, e.RowIndex].Value.ToString();
                       
                        if (locationdgv[locationdgv.Columns["colCountry"].Index, e.RowIndex].Value.ToString() != "")
                        {
                            ddlCountry.SelectedValue = int.Parse(locationdgv[locationdgv.Columns["colCountry"].Index, e.RowIndex].Value.ToString());
                            BindState(locationdgv[locationdgv.Columns["colCountry"].Index, e.RowIndex].Value.ToString());
                            ddlState.SelectedValue = int.Parse(locationdgv[locationdgv.Columns["colState"].Index, e.RowIndex].Value.ToString());
                        }
                        else
                        {
                            ddlCountry.SelectedValue = 0;
                        }

                        //if (locationdgv[locationdgv.Columns["colIsActive"].Index, e.RowIndex].Value.ToString() != "")
                        //{
                        cmbStatus.SelectedValue = locationdgv[locationdgv.Columns["colIsActive"].Index, e.RowIndex].Value.ToString();
                          
                        //}
                        //else
                        //{
                        //    cmbStatus.SelectedValue = 0;
                        //}

                        lblHdnSource.Text = id.ToString();


                        //DataGridViewCell cell = locationdgv.Rows[e.RowIndex].Cells[1];
                        //locationdgv.CurrentCell = cell;
                        //locationdgv.Columns["colName"].ReadOnly = false;
                        //locationdgv.Rows[locationdgv.CurrentRow.Index].ReadOnly = false;
                        //locationdgv.BeginEdit(true);
                        //locationdgv.ReadOnly = false;
                        //locationdgv.CurrentRow.ReadOnly = false;
                        //DataGridViewRow r = locationdgv.Rows[e.RowIndex];
                        //if (r != null)
                        //{
                        //    r.ReadOnly = false;
                        //}
                    }
                    else if (e.ColumnIndex == locationdgv.Columns["colDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this Category", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("UPDATE LocationMaster SET IsActive = 'No' where LocationId='" + id + "'");
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
        //    }
        //    catch (Exception ex)
        //    {
        //        StreamWriter swLog = File.AppendText(strLogFileName);
        //        string strError = DateTime.Now.ToString() + "\n Main Page/frmlocation Tab \n" + ex.ToString();
        //        swLog.WriteLine(strError);
        //        swLog.WriteLine();
        //        swLog.Close();
        //        MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        }

        public void BindCountry()
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                //SqlConnection conn = new SqlConnection(ConnectionString);
                objC = new CommonFunction();
                SqlDataAdapter da = objC.GetSqlDataAdapter("select * from Country order by name"); 
                //new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                da.Fill(dt);
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmlocation Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindState(string CountryID)
        {
            try
            {
                DataTable dtState = new DataTable();
                //SqlConnection connState = new SqlConnection(ConnectionString);
                //SqlDataAdapter daState = new SqlDataAdapter("select * from State where CountryID = " + CountryID + " order by name", connState);
                objC = new CommonFunction();
                SqlDataAdapter daState = objC.GetSqlDataAdapter("select * from State where CountryID = " + CountryID + " order by name"); 
                
                //da.Fill(ds, "Country");
                daState.Fill(dtState);
                ddlState.DataSource = dtState;
                ddlState.DisplayMember = "name";
                ddlState.ValueMember = "StateID";

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

        private void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlCountry.SelectedIndex) != "0")
            {
                BindState(ddlCountry.SelectedValue.ToString());
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
                        string query = "INSERT INTO LocationMaster (LocationCode, DispatchThru, State, CountryId, StateCode, Address1, Address2, DrugLicense1, DrugLicense2, TinVatNo, Tax, TaxOn, EffectiveTaxRate, IsActive, LastModify) VALUES ('" + txtLocCode.Text + "','" + txtLocName.Text + "','" + ddlState.Text + "','" + ddlCountry.SelectedValue.ToString() + "','" + ddlState.SelectedValue.ToString() + "','" + txtAddress1.Text + "','" + txtAddress2.Text + "','" + txtDrugLicense1.Text + "','" + txtDrugLicense2.Text + "','" + txtTINVATNo.Text + "'," + decimal.Parse(txtTax.Text) + ",'" + ddlTaxOn.SelectedValue.ToString() + "'," + decimal.Parse(txtEffectiveTAXRate.Text) + ",'" + cmbStatus.SelectedValue.ToString() + "', getdate())";
                        Result objResult = objCF.InsertQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Location Master Inserted Sucessfully";
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
                        string query = "UPDATE LocationMaster set LocationCode='" + txtLocCode.Text + "', DispatchThru='" + txtLocName.Text + "', State='" + ddlState.Text + "', CountryId='" + ddlCountry.SelectedValue.ToString() + "', StateCode='" + ddlState.SelectedValue.ToString() + "', TinVatNo='" + Convert.ToString(txtTINVATNo.Text) + "', TaxOn='" + ddlTaxOn.Text.ToString() + "',tax='" + decimal.Parse(txtTax.Text) + "', EffectiveTaxRate='" + txtEffectiveTAXRate.Text.ToString() + "', DrugLicense1='" + txtDrugLicense1.Text.ToString() + "', DrugLicense2='" + txtDrugLicense2.Text.ToString() + "', Address1='" + txtAddress1.Text.ToString() + "', Address2='" + txtAddress2.Text.ToString() + "', IsActive='" + cmbStatus.SelectedValue.ToString() + "', LastModify=getdate() WHERE LocationId='" + lblHdnSource.Text + "'";
                        Result objResult = objCF.ExecuteDMLQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Location Master Updated Sucessfully";
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
                string strError = DateTime.Now.ToString() + "\n Main Page/Location Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateForm()
        {
            errorLocation.Clear();
            bool isValid = true;
            if (txtLocCode.Text == "")
            {
                errorLocation.SetError(txtLocCode, "Location Code");
                isValid = false;
            }

            if (txtLocName.Text == "")
            {
                errorLocation.SetError(txtLocName, "Location Name");
                isValid = false;
            }

            if (ddlCountry.SelectedIndex == 0)
            {
                errorLocation.SetError(ddlCountry, "Country");
                isValid = false;
            }

            return isValid;
        }

        private void ClearForm()
        {
            txtLocCode.Text = "";
            txtLocName.Text = "";
            ddlCountry.SelectedIndex = 0;
            //ddlTaxOn.SelectedIndex = 0;
            
            ddlState.DataSource = null;
            cmbStatus.SelectedIndex = 0;
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtDrugLicense1.Text = "";
            txtDrugLicense2.Text = "";
            txtTax.Text = "0";
            txtTINVATNo.Text = "";
            txtEffectiveTAXRate.Text = "0";
            lblHdnSource.Text = "";
            
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
            objCF.fn_ExportToExcel("select LocationId as ID, LocationCode, DispatchThru, State, (case when CountryId is not null then (select Name from Country where LocationMaster.CountryId = Country.CountryID) end) CountryName, Address1, Address2, DrugLicense1, DrugLicense2, TinVatNo, Tax, TaxOn, EffectiveTaxRate, IsActive, LastModify from LocationMaster", "Location Master", "LocationMaster");
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

        

       

        //public void colorbtnAlternate()
        //{
        //    this.locationdgv.RowsDefaultCellStyle.BackColor = Color.White;
        //    this.locationdgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
        //}
        //public void btnReorder()
        //{
        //    locationdgv.Columns["Code"].DisplayIndex = 1;
        //    locationdgv.Columns["Name"].DisplayIndex = 3;
        //}
        //private double Total()
        //{
        //    double tot = 0;
        //    // int i = 0;
        //    //for (i = 0; i < Categorygdv.Rows.Count; i++)
        //    //{
        //    //    tot = tot + Convert.ToDouble(Categorygdv.Rows[i].Cells["id"].Value);
        //    //}
        //    tot = locationdgv.Rows.Count - 1;
        //    return tot;
        //}
        //public void hedernamechange()
        //{
        //    locationdgv.Columns[0].HeaderText = "MyHeader1";
        //    locationdgv.Columns[1].HeaderText = "MyHeader2";
        //}
        //public void color_DataGridView()
        //{
        //    this.locationdgv.DefaultCellStyle.ForeColor = Color.Coral;
        //    // Change back color of each row
        //    this.locationdgv.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
        //    // Change GridLine Color
        //    this.locationdgv.GridColor = Color.Blue;
        //    // Change Grid Border Style
        //    this.locationdgv.BorderStyle = BorderStyle.Fixed3D;
        //}
        //public void resizedatagrid()
        //{
        //    locationdgv.AutoResizeColumns();
        //    locationdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //}
        //public void rowToBeSelected()
        //{
        //    int rowToBeSelected = 1; // third row
        //    if (locationdgv.Rows.Count >= rowToBeSelected)
        //    {
        //        // Since index is zero based, you have to subtract 1
        //        locationdgv.Rows[rowToBeSelected - 1].Selected = true;
        //    }

        //}
        //public void LocationRetrive()
        //{
        //    DataTable dt = new DataTable();
        //    SqlConnection Scon = new SqlConnection(ConnectionString);
        //    SqlDataAdapter Scom = new SqlDataAdapter("select LocationId, Code, Name from LocationMaster order by 1 asc", Scon);
        //    //DataSet ds = new DataSet();
        //    //Scom.ExecuteNonQuery();
        //    //Scom.Fill(ds, "LocationMaster");
        //    Scom.Fill(dt);
        //    locationdgv.DataSource = dt;  //ds.Tables["LocationMaster"].DefaultView;
        //    //Scom.Connection.Dispose();

        //    //LocationMasterClass objLM = new LocationMasterClass();
        //    //ResultClass objResult = objLM.fn_GetLocationMasterList();
        //    //if (objResult.bStatus)
        //    //{
        //    //    wwList<LocationMasterClass> objLMList = objResult.objData as wwList<LocationMasterClass>;
        //    //    if (objLMList.Count > 0)
        //    //    {
        //    //        DataTable dt = (DataTable)objLMList;
        //    //        locationdgv.DataSource = dt;
        //    //        //locationdgv.Columns.Remove("strIsActive");
        //    //        this.locationdgv.Columns["iLocationId"].Visible = false;
        //    //        this.locationdgv.Columns["iStateCode"].Visible = false;
        //    //        this.locationdgv.Columns["strIsActive"].Visible = false;
        //    //        this.locationdgv.Columns["dtLastModify"].Visible = false;
        //    //        this.locationdgv.Columns["strCode"].HeaderText = "Code";
        //    //        this.locationdgv.Columns["strName"].HeaderText = "Name";
        //    //        locationdgv.AutoGenerateColumns = false;
        //    //    }
        //    //    else
        //    //    {
        //    //        locationdgv.AutoGenerateColumns = false;
        //    //        locationdgv.DataSource = null;
        //    //    }
        //    //}
        //}
        //private void ddlCategory_Validating(object sender, CancelEventArgs e)
        //{
        //    if (ddlCountry.SelectedIndex == 0)
        //    {
        //        errorLocation.SetError(ddlCountry, "Select Category");
        //    }
        //    else
        //    {
        //        errorLocation.SetError(ddlCountry, "");
        //    }
        //}
    }
}
