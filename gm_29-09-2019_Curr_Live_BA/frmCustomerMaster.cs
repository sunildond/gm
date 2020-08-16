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
using System.Text.RegularExpressions;

namespace GlanMark
{
    public partial class frmCustomerMaster : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";

        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private int id;

        // Page
        private int mintTotalRecords = 0;
        private int mintPageSize = 20;
        private int mintPageCount = 0;
        private int mintCurrentPage = 1;

        public frmCustomerMaster()
        {
            InitializeComponent();
        }

        private void frmCustomerMaster_Load(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
                BindLocationMaster();
                BindCustomerType();
                BindZone();
                BindIsActive();
                BindLSTCST();
                BindCustomerCode();
                BindCustomerName();
                BindCountry();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerMaster Load \n" + ex.ToString();
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
                ddlCountry.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlCountry.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select * from Country where status = 1 order by name");
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

        private void BindCustomerCode()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                ddlCustomerCode.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlCustomerCode.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select CustomerId, CustomerCode from CustomerMaster Order by CustomerCode asc");
                DataRow dr = dt.NewRow();
                dr["CustomerId"] = 0;
                dr["CustomerCode"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlCustomerCode.DataSource = dt;
                ddlCustomerCode.DisplayMember = "CustomerCode";
                ddlCustomerCode.ValueMember = "CustomerId";
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerMaster BindCustomerCode \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindCustomerName()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                ddlCustomerName.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlCustomerName.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select CustomerId, Name from CustomerMaster Order by Name asc");
                DataRow dr = dt.NewRow();
                dr["CustomerId"] = 0;
                dr["Name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlCustomerName.DataSource = dt;
                ddlCustomerName.DisplayMember = "Name";
                ddlCustomerName.ValueMember = "CustomerId";
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerMaster BindCustomerName \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindIsActive()
        {
            try
            {
                //cmbStatus.Items.Insert(0, new ListItem("0", "--Select--"));
                //cmbStatus.Items.Insert(0, new ListItem("Yes", "Yes"));
                //cmbStatus.Items.Insert(1, new ListItem("No", "No"));
                //cmbStatus.SelectedIndex = 0;
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
                ddlIsActive.DataSource = dt;
                ddlIsActive.DisplayMember = "Name";
                ddlIsActive.ValueMember = "Value";
                ddlIsActive.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmDSM-ZSM--bindStatus Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindZone()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
                dt = objCommon.GetDataTable("select ID, Name from ZoneMaster where IsActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlZone.DataSource = dt;
                ddlZone.DisplayMember = "Name";
                ddlZone.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindLSTCST()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
                dt = objCommon.GetDataTable("select ID, TaxType from TaxTypeMaster where IsActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["ID"] = 0;
                dr["TaxType"] = "--select--";
                dt.Rows.InsertAt(dr, 0);
                cmblstcst.DataSource = dt;
                cmblstcst.DisplayMember = "TaxType";
                cmblstcst.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerMaster BindLSTCST \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindCustomerType()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                dt = objCommon.GetDataTable("select ID, CustomerType from CustomerType where IsActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["ID"] = 0;
                dr["CustomerType"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlCustomerType.DataSource = dt;
                ddlCustomerType.DisplayMember = "CustomerType";
                ddlCustomerType.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindLocationMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
                dt = objCommon.GetDataTable("select LocationId, LocationCode, DispatchThru from LocationMaster where IsActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["LocationId"] = 0;
                dr["DispatchThru"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlLocation.DataSource = dt;
                ddlLocation.DisplayMember = "DispatchThru";
                ddlLocation.ValueMember = "LocationId";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/BindLocationMaster \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlLocation.SelectedIndex) != "0")
            {
                int LocationId = int.Parse(ddlLocation.SelectedValue.ToString());
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select LocationCode,TaxOn from LocationMaster where LocationId = " + LocationId);
                txtLocationCode.Text = dt.Rows[0]["LocationCode"].ToString();
                txtTaxOn.Text = dt.Rows[0]["TaxOn"].ToString();
            }
            else if (Convert.ToString(ddlLocation.SelectedIndex) == "0")
            {
                txtLocationCode.Text = "";
            }
        }

        public void BindGrid()
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomer Master Grid \n" + ex.ToString();
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
                StringBuilder sqlCustomer = new StringBuilder();

                sqlCustomer.Append("SELECT TOP " + this.mintPageSize + " CustomerId, CustomerCode, Name, City, ");
                sqlCustomer.Append(" case when CustomerMaster.ZoneID is not null then (select ZoneMaster.Name ");
                sqlCustomer.Append(" from ZoneMaster where CustomerMaster.ZoneID = ZoneMaster.ID) end ZoneName, ");
                sqlCustomer.Append(" case when CustomerMaster.CustomerTypeID IS not null then (select CustomerType.CustomerType ");
                sqlCustomer.Append(" from CustomerType where CustomerType.ID = CustomerMaster.CustomerTypeID) end CustomerType, ");
                sqlCustomer.Append(" LocationCode, DispatchThru, IsActive from CustomerMaster ");
                sqlCustomer.Append(" WHERE CustomerId NOT IN (SELECT TOP " + intSkip + " CustomerId FROM CustomerMaster order by CustomerCode asc) ");

                if (DBSessionUser.iUser_Type == 2)
                {
                    sqlCustomer.Append("  and  LocationCode = '" + DBSessionUser.strUser_Name + "'");
                }

                //sqlCustomer.Append(" order by Name asc");
                sqlCustomer.Append(" order by CustomerCode asc");

                sqlDataAdapter = objC.GetSqlDataAdapter(sqlCustomer.ToString());
                //sqlDataAdapter = new SqlDataAdapter(selectQueryString, sqlConnection);
                //sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvCustomerMaster.DataSource = bindingSource;

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
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('CustomerMaster') AND IndId < 2");

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


        private void dgvCustomerCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    id = int.Parse(dgvCustomerMaster.Rows[e.RowIndex].Cells["colCustomerId"].Value.ToString());

                    if (e.ColumnIndex == dgvCustomerMaster.Columns["colEdit"].Index)
                    {
                        //btnSave.Text = "Update";
                        //txtDSMZSMName.Text = dgvCustomerMaster[dgvCustomerMaster.Columns["colName"].Index, e.RowIndex].Value.ToString();
                        //txtDSMZSMCode.Text = dgvCustomerMaster[dgvCustomerMaster.Columns["colCode"].Index, e.RowIndex].Value.ToString();
                        //cmbStatus.SelectedValue = dgvCustomerMaster[dgvCustomerMaster.Columns["colIsActive"].Index, e.RowIndex].Value.ToString();
                        fn_getCustomerDetail(id);
                        lblID.Text = id.ToString();
                        tabControl1.SelectedTab = tabPage2;
                    }

                    if (e.ColumnIndex == dgvCustomerMaster.Columns["colDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this Customer", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("UPDATE CustomerMaster SET IsActive = 'No' where CustomerId = '" + id + "'");
                            if (res.bStatus)
                            {
                                MessageBox.Show("Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            BindGrid();
                        }
                    }

                    if (e.ColumnIndex == dgvCustomerMaster.Columns["colViewDetail"].Index)
                    {
                        CustomerDetail objCustomerDetail = new CustomerDetail(id);
                        objCustomerDetail.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/dgvCustomerCategory_CellContentClick \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fn_getCustomerDetail(int id)
        {
            try
            {
                if (id != null)
                {
                    objC = new CommonFunction();
                    DataTable dt = objC.GetDataTable("select * from CustomerMaster where CustomerId = " + id);
                    //lblID.Text = dt.Rows[0]["CustomerId"].ToString();
                    txtCustomerCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                    txtCustomerName.Text = dt.Rows[0]["Name"].ToString();
                    txtCity.Text = dt.Rows[0]["City"].ToString();
                    txtStreet.Text = dt.Rows[0]["Street"].ToString();
                    txtStreet1.Text = dt.Rows[0]["Street1"].ToString();
                    txtStreet2.Text = dt.Rows[0]["Street2"].ToString();
                    txtStreet3.Text = dt.Rows[0]["Street3"].ToString();
                    txtPostalCode.Text = dt.Rows[0]["PostalCode"].ToString();
                    txtMobileNo.Text = dt.Rows[0]["MobileNumber"].ToString();
                    txtVATNo.Text = dt.Rows[0]["VATregistrationNo"].ToString();
                    txtCSTNo.Text = dt.Rows[0]["CSTnumber"].ToString();
                    txtLSTNo.Text = dt.Rows[0]["LSTnumber"].ToString();
                    txtVATTaxCode.Text = dt.Rows[0]["VATTaxCode"].ToString();
                    txtCSTTaxCode.Text = dt.Rows[0]["CSTTaxCode"].ToString();
                    txtLSTTaxCode.Text = dt.Rows[0]["LSTTaxCode"].ToString();
                    ddlZone.SelectedValue = int.Parse(dt.Rows[0]["ZoneID"].ToString());
                    ddlCustomerType.SelectedValue = int.Parse(dt.Rows[0]["CustomerTypeID"].ToString());
                    txtLocationCode.Text = dt.Rows[0]["LocationCode"].ToString();
                    ddlLocation.Text = dt.Rows[0]["DispatchThru"].ToString();

                    txtPaymentTerms.Text = dt.Rows[0]["PaymentTerm"].ToString();
                    txtShipToParty.Text = dt.Rows[0]["ShipToParty"].ToString();
                    txtBillToParty.Text = dt.Rows[0]["BillToParty"].ToString();
                    txtPayer.Text = dt.Rows[0]["Payer"].ToString();
                    txtSoldToParty.Text = dt.Rows[0]["SoldToParty"].ToString();
                    txtCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    txtCompanyTelNo.Text = dt.Rows[0]["CompanyTelNo"].ToString();
                    txtCompanyFax.Text = dt.Rows[0]["CompanyFaxNo"].ToString();
                    txtCompanyEmailID.Text = dt.Rows[0]["CompanyEmailId"].ToString();
                    txtContactPersonName.Text = dt.Rows[0]["ContactPersonName"].ToString();
                    txtContactPersonTelNo.Text = dt.Rows[0]["ContactPersonTelNo"].ToString();
                    txtContactPersonMobNo.Text = dt.Rows[0]["ContactPersonMobNo"].ToString();
                    cmblstcst.SelectedValue = dt.Rows[0]["LST_CST"].ToString();
                    ddlIsActive.SelectedValue = dt.Rows[0]["IsActive"].ToString();

                    txtGSTNumber.Text = dt.Rows[0]["GSTNumber"].ToString();
                    txtPANNumber.Text = dt.Rows[0]["PANNumber"].ToString();
                    txtFoodLicense.Text = dt.Rows[0]["FoodLicense"].ToString();
                    txtDrugLicense1.Text = dt.Rows[0]["DrugLicense1"].ToString();
                    txtDrugLicense2.Text = dt.Rows[0]["DrugLicense2"].ToString();

                    ddlCountry.SelectedValue = int.Parse(dt.Rows[0]["CountryId"].ToString());
                    ddlState.SelectedValue = int.Parse(dt.Rows[0]["StateId"].ToString());

                }
            }
            catch (Exception ex)
            {
                //StreamWriter swLog = File.AppendText(strLogFileName);
                //string strError = DateTime.Now.ToString() + "\n Main Page/fn_getCustomerDetail \n" + ex.ToString();
                //swLog.WriteLine(strError);
                //swLog.WriteLine();
                //swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        StringBuilder strAppend = new StringBuilder();
                        //string query = "";
                        //string query = "INSERT INTO CustomerMaster (CustomerCode, Name, City, Street, Street1, Street2, Street3, PostalCode, MobileNumber, VATregistrationNo, CSTnumber, LSTnumber, VATTaxCode, CSTTaxCode, LSTTaxCode, ZoneID, CustomerTypeID, CustomerCategoryID, InstitutionID, SubInstitutionID, DocReqID, LocationID, ZSMID, Lisoner, PaymentTerm, ShipToParty, BillToParty, Payer, SoldToParty, CompanyName, CompanyTelNo, CompanyFaxNo, CompanyEmailId, ContactPersonName, ContactPersonTelNo, ContactPersonMobNo, DSM_ZSM, LST_CST, IsActive, LastModify) VALUES ('" + txtCustomerCode.Text + "','" + txtCustomerName.Text + "','" + txtCity.Text + "','" + txtStreet.Text + "','" + txtStreet1.Text + "','" + txtStreet2.Text + "','" + txtStreet3.Text + "','" + txtPostalCode.Text + "','" + txtMobileNo.Text + "','" + txtVATNo.Text + "','" + txtCSTNo.Text + "','" + txtLSTNo.Text + "','" + txtVATTaxCode.Text + "','" + txtCSTTaxCode.Text + "','" + txtLSTTaxCode.Text + "'," + int.Parse(ddlZone.SelectedValue.ToString()) + "," + int.Parse(ddlCustomerType.SelectedValue.ToString()) + "," + int.Parse(ddlCustomerCategory.SelectedValue.ToString()) + "," + int.Parse(ddlInst.SelectedValue.ToString()) + "," + int.Parse(ddlSubInst.SelectedValue.ToString()) + "," + int.Parse(ddlDocReq.SelectedValue.ToString()) + "," + int.Parse(ddlLocation.SelectedValue.ToString()) + "," + int.Parse(ddlZsm.SelectedValue.ToString()) + ",'" + txtLisioner.Text + "','" + txtPaymentTerms.Text + "','" + txtShipToParty.Text + "','" + txtBillToParty.Text + "','" + txtPayer.Text + "','" + txtSoldToParty.Text + "','" + txtCompanyName.Text + "','" + txtCompanyTelNo.Text + "','" + txtCompanyFax.Text + "','" + txtCompanyEmailID.Text + "','" + txtContactPersonName.Text + "','" + txtContactPersonTelNo.Text + "','" + txtContactPersonMobNo.Text + "'," + int.Parse(cmbdsmgsm.SelectedValue.ToString()) + "," + int.Parse(cmblstcst.SelectedValue.ToString()) + ",'" + ddlIsActive.SelectedValue.ToString() + "',GETDATE())";
                        string query = @"INSERT INTO CustomerMaster (CustomerCode, Name, City, Street, Street1, Street2, Street3, PostalCode, MobileNumber, VATregistrationNo, CSTnumber, LSTnumber, VATTaxCode, CSTTaxCode, LSTTaxCode, ZoneID, CustomerTypeID, LocationCode, DispatchThru,TaxOn, PaymentTerm, ShipToParty, BillToParty, Payer, SoldToParty, CompanyName, CompanyTelNo, CompanyFaxNo, CompanyEmailId, ContactPersonName, ContactPersonTelNo, ContactPersonMobNo, LST_CST, IsActive, LastModify, CountryId, StateId, GSTNumber, DrugLicense1, DrugLicense2, PANNumber, FoodLicense) VALUES ('" + txtCustomerCode.Text + "','" + txtCustomerName.Text + "','" + txtCity.Text + "','" + txtStreet.Text + "','" + txtStreet1.Text + "','" + txtStreet2.Text + "','" + txtStreet3.Text + "','" + txtPostalCode.Text + "','" + txtMobileNo.Text + "','" + txtVATNo.Text + "','" + txtCSTNo.Text + "','" + txtLSTNo.Text + "','" + txtVATTaxCode.Text + "','" + txtCSTTaxCode.Text + "','" + txtLSTTaxCode.Text + "'," + int.Parse(ddlZone.SelectedValue.ToString()) + "," + int.Parse(ddlCustomerType.SelectedValue.ToString()) + ",'" + txtLocationCode.Text + "','" + ddlLocation.Text + "','" + txtTaxOn.Text + "','" + txtPaymentTerms.Text + "','" + txtShipToParty.Text + "','" + txtBillToParty.Text + "','" + txtPayer.Text + "','" + txtSoldToParty.Text + "','" + txtCompanyName.Text + "','" + txtCompanyTelNo.Text + "','" + txtCompanyFax.Text + "','" + txtCompanyEmailID.Text + "','" + txtContactPersonName.Text + "','" + txtContactPersonTelNo.Text + "','" + txtContactPersonMobNo.Text + "'," + int.Parse(cmblstcst.SelectedValue.ToString()) + ",'" + ddlIsActive.SelectedValue.ToString() + "',GETDATE()," + int.Parse(ddlCountry.SelectedValue.ToString()) + ", " + int.Parse(ddlState.SelectedValue.ToString()) + ", '" + txtGSTNumber.Text + "', '" + txtDrugLicense1.Text + "', '" + txtDrugLicense2.Text + "', '" + txtPANNumber.Text + "', '" + txtFoodLicense.Text + "')";

                        Result objResult = objCF.InsertQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Customer Master Inserted Sucessfully";
                            ClearForm();
                            BindGrid();
                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            lblStatus.Text = objResult.strMessage;
                        }
                    }
                    else if (lblID.Text != "0")
                    {
                        StringBuilder strAppend = new StringBuilder();
                        //string query = "";
                        //string query = "INSERT INTO CustomerMaster (CustomerCode, Name, City, Street, Street1, Street2, Street3, PostalCode, MobileNumber, VATregistrationNo, CSTnumber, LSTnumber, VATTaxCode, CSTTaxCode, LSTTaxCode, ZoneID, CustomerTypeID, CustomerCategoryID, InstitutionID, SubInstitutionID, DocReqID, LocationID, ZSMID, Lisoner, PaymentTerm, ShipToParty, BillToParty, Payer, SoldToParty, CompanyName, CompanyTelNo, CompanyFaxNo, CompanyEmailId, ContactPersonName, ContactPersonTelNo, ContactPersonMobNo, DSM_ZSM, LST_CST, IsActive, LastModify) VALUES ('" + txtCustomerCode.Text + "','" + txtCustomerName.Text + "','" + txtCity.Text + "','" + txtStreet.Text + "','" + txtStreet1.Text + "','" + txtStreet2.Text + "','" + txtStreet3.Text + "','" + txtPostalCode.Text + "','" + txtMobileNo.Text + "','" + txtVATNo.Text + "','" + txtCSTNo.Text + "','" + txtLSTNo.Text + "','" + txtVATTaxCode.Text + "','" + txtCSTTaxCode.Text + "','" + txtLSTTaxCode.Text + "'," + int.Parse(ddlZone.SelectedValue.ToString()) + "," + int.Parse(ddlCustomerType.SelectedValue.ToString()) + "," + int.Parse(ddlCustomerCategory.SelectedValue.ToString()) + "," + int.Parse(ddlInst.SelectedValue.ToString()) + "," + int.Parse(ddlSubInst.SelectedValue.ToString()) + "," + int.Parse(ddlDocReq.SelectedValue.ToString()) + "," + int.Parse(ddlLocation.SelectedValue.ToString()) + "," + int.Parse(ddlZsm.SelectedValue.ToString()) + ",'" + txtLisioner.Text + "','" + txtPaymentTerms.Text + "','" + txtShipToParty.Text + "','" + txtBillToParty.Text + "','" + txtPayer.Text + "','" + txtSoldToParty.Text + "','" + txtCompanyName.Text + "','" + txtCompanyTelNo.Text + "','" + txtCompanyFax.Text + "','" + txtCompanyEmailID.Text + "','" + txtContactPersonName.Text + "','" + txtContactPersonTelNo.Text + "','" + txtContactPersonMobNo.Text + "'," + int.Parse(cmbdsmgsm.SelectedValue.ToString()) + "," + int.Parse(cmblstcst.SelectedValue.ToString()) + ",'" + ddlIsActive.SelectedValue.ToString() + "',GETDATE())";
                        string query = @"UPDATE CustomerMaster set CustomerCode = '" + txtCustomerCode.Text + "', Name = '" + txtCustomerName.Text + "', City = '" + txtCity.Text + "', Street = '" + txtStreet.Text + "', Street1 = '" + txtStreet1.Text + "', Street2 = '" + txtStreet2.Text + "', Street3 = '" + txtStreet3.Text + "', PostalCode = '" + txtPostalCode.Text + "', MobileNumber = '" + txtMobileNo.Text + "', VATregistrationNo = '" + txtVATNo.Text + "', CSTnumber = '" + txtCSTNo.Text + "', LSTnumber = '" + txtLSTNo.Text + "', VATTaxCode = '" + txtVATTaxCode.Text + "', CSTTaxCode = '" + txtCSTTaxCode.Text + "', LSTTaxCode = '" + txtLSTTaxCode.Text + "', ZoneID = " + int.Parse(ddlZone.SelectedValue.ToString()) + ", CustomerTypeID = " + int.Parse(ddlCustomerType.SelectedValue.ToString()) + ", LocationCode = '" + txtLocationCode.Text + "', DispatchThru = '" + ddlLocation.Text + "', TaxOn = '" + txtTaxOn.Text + "', PaymentTerm = '" + txtPaymentTerms.Text + "', ShipToParty = '" + txtShipToParty.Text + "', BillToParty = '" + txtBillToParty.Text + "', Payer = '" + txtPayer.Text + "', SoldToParty = '" + txtSoldToParty.Text + "', CompanyName = '" + txtCompanyName.Text + "', CompanyTelNo = '" + txtCompanyTelNo.Text + "', CompanyFaxNo = '" + txtCompanyFax.Text + "', CompanyEmailId = '" + txtCompanyEmailID.Text + "', ContactPersonName = '" + txtContactPersonName.Text + "', ContactPersonTelNo = '" + txtContactPersonTelNo.Text + "', ContactPersonMobNo = '" + txtContactPersonMobNo.Text + "', LST_CST = " + int.Parse(cmblstcst.SelectedValue.ToString()) + ", IsActive = '" + ddlIsActive.SelectedValue.ToString() + "', LastModify = GETDATE(), CountryId=" + int.Parse(ddlCountry.SelectedValue.ToString()) + ", StateId=" + int.Parse(ddlState.SelectedValue.ToString()) + ", GSTNumber='" + txtGSTNumber.Text + "', DrugLicense1='" + txtDrugLicense1.Text + "', DrugLicense2='" + txtDrugLicense2.Text + "', PANNumber='" + txtPANNumber.Text + "', FoodLicense='" + txtFoodLicense.Text + "' where CustomerId=" + lblID.Text;

                        Result objResult = objCF.ExecuteDMLQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Customer Master Updated Sucessfully";
                            ClearForm();
                            BindGrid();
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmStateMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateForm()
        {
            errorCustomerMaster.Clear();
            bool isValid = true;

            //try
            //{
            //    int intCode = int.Parse(txtDSMZSMCode.Text);
            //}
            //catch (Exception ex)
            //{
            //    errorCustomerMaster.SetError(txtDSMZSMCode, "DSM-ZSM");
            //    return isValid = false;
            //}


            if (txtCompanyEmailID.Text.Trim() == "")
            {
                errorCustomerMaster.SetError(txtCompanyEmailID, "CompanyEmailID");
                isValid = false;
            }

            if (txtContactPersonTelNo.Text.Trim() == "")
            {
                errorCustomerMaster.SetError(txtContactPersonTelNo, "ContactPersonTelNo");
                isValid = false;
            }

            if (txtStreet.Text == "")
            {
                errorCustomerMaster.SetError(txtStreet, "Street");
                isValid = false;
            }

            if (txtStreet1.Text == "")
            {
                errorCustomerMaster.SetError(txtStreet1, "Street1");
                isValid = false;
            }

            if (txtStreet2.Text == "")
            {
                errorCustomerMaster.SetError(txtStreet2, "Street2");
                isValid = false;
            }

            if (txtPostalCode.Text == "")
            {
                errorCustomerMaster.SetError(txtPostalCode, "PostalCode");
                isValid = false;
            }

            if (txtMobileNo.Text == "")
            {
                errorCustomerMaster.SetError(txtMobileNo, "MobileNo");
                isValid = false;
            }

            if (txtCity.Text == "")
            {
                errorCustomerMaster.SetError(txtCity, "City");
                isValid = false;
            }

            if (txtCustomerCode.Text == "")
            {
                errorCustomerMaster.SetError(txtCustomerCode, "CustomerCode");
                isValid = false;
            }

            if (txtCustomerName.Text == "")
            {
                errorCustomerMaster.SetError(txtCustomerName, "CustomerName");
                isValid = false;
            }

            //if (ddlCustomerType.SelectedIndex == 0)
            //{
            //    errorCustomerMaster.SetError(ddlCustomerType, "CustomerType");
            //    isValid = false;
            //}
            //else if (ddlCustomerType.Text.ToLower() == "s")
            //{
            //    if (txtVATNo.Text == "")
            //    {
            //        errorCustomerMaster.SetError(txtVATNo, "VATNo");
            //        isValid = false;
            //    }
            //    if (txtCSTNo.Text == "")
            //    {
            //        errorCustomerMaster.SetError(txtCSTNo, "CSTNo");
            //        isValid = false;
            //    }
            //}

            if (ddlLocation.SelectedIndex == 0)
            {
                errorCustomerMaster.SetError(ddlLocation, "Location");
                isValid = false;
            }

            if (ddlZone.SelectedIndex == 0)
            {
                errorCustomerMaster.SetError(ddlZone, "Zone");
                isValid = false;
            }

            if (ddlZone.SelectedIndex == 0)
            {
                errorCustomerMaster.SetError(ddlZone, "Zone");
                isValid = false;
            }

            if (cmblstcst.SelectedIndex == 0)
            {
                errorCustomerMaster.SetError(cmblstcst, "LST-CST");
                isValid = false;
            }

            if (ddlCountry.SelectedIndex == 0)
            {
                errorCustomerMaster.SetError(ddlCountry, "Country");
                isValid = false;
            }

            if (ddlState.SelectedIndex == 0)
            {
                errorCustomerMaster.SetError(ddlState, "State");
                isValid = false;
            }

            try
            {
                int intPostalCode = int.Parse(txtPostalCode.Text);
                if (intPostalCode == 0)
                {
                    MessageBox.Show("Please enter valid Postal Code !");

                    errorCustomerMaster.SetError(txtPostalCode, "LST-CST");
                    isValid = false;
                }
            }
            catch (Exception exPostalCode)
            {
                if (txtPostalCode.Text.Trim() != "")
                {
                    MessageBox.Show("Postal Code Should by Numeric !");
                }
                errorCustomerMaster.SetError(txtPostalCode, "PostalCode");
                return isValid = false;
            }

            var isMatch = Regex.IsMatch(txtPostalCode.Text.Trim(), "^[0-9]{6}$");
            if (isMatch != true)
            {
                MessageBox.Show("Postal Code Should by Numeric 6 digit.");
                return isValid = false;
            }

            return isValid;
        }

        private void ClearForm()
        {
            //cmbStatus.SelectedIndex = 0;
            cmblstcst.SelectedIndex = 0;
            lblID.Text = "0";
            txtCustomerCode.Text = "";
            txtCustomerName.Text = "";
            txtCity.Text = "";
            txtStreet.Text = "";
            txtStreet1.Text = "";
            txtStreet2.Text = "";
            txtStreet3.Text = "";
            txtPostalCode.Text = "";
            txtMobileNo.Text = "";
            txtVATNo.Text = "";
            txtCSTNo.Text = "";
            txtLSTNo.Text = "";
            txtVATTaxCode.Text = "";
            txtCSTTaxCode.Text = "";
            txtLSTTaxCode.Text = "";
            ddlZone.SelectedIndex = 0;
            ddlCustomerType.SelectedIndex = 0;
            ddlLocation.SelectedIndex = 0;
            txtPaymentTerms.Text = "";
            txtShipToParty.Text = "";
            txtBillToParty.Text = "";
            txtPayer.Text = "";
            txtSoldToParty.Text = "";
            txtCompanyName.Text = "";
            txtCompanyTelNo.Text = "";
            txtCompanyFax.Text = "";
            txtCompanyEmailID.Text = "";
            txtContactPersonName.Text = "";
            txtContactPersonTelNo.Text = "";
            txtContactPersonMobNo.Text = "";
            txtLocationCode.Text = "";
            txtTaxOn.Text = "";

            ddlCountry.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            txtGSTNumber.Text = "";
            txtPANNumber.Text = "";
            txtFoodLicense.Text = "";
            txtDrugLicense1.Text = "";
            txtDrugLicense2.Text = "";

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lblID.Text = "";
                BindGrid();
                ClearForm();
                tabControl1.SelectedTab = tabPage1;
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

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            objCF.fn_ExportToExcel("select CustomerId as ID, CustomerCode, Name, City, Street, Street1, Street2, Street3, PostalCode, MobileNumber, VATregistrationNo, CSTnumber, LSTnumber, VATTaxCode, CSTTaxCode, LSTTaxCode, (case when ZoneId is not null then (select ZoneMaster.Name from ZoneMaster where CustomerMaster.ZoneId = ZoneMaster.ID) end) Zone, (case when CustomerTypeID is not null then (select CustomerType from CustomerType where CustomerMaster.CustomerTypeID = CustomerType.ID) end) CustomerType, LocationCode, DispatchThru, TaxOn, PaymentTerm, ShipToParty, BillToParty, Payer, LST_CST, SoldToParty, CompanyName, CompanyTelNo, CompanyFaxNo, CompanyEmailId, ContactPersonName, ContactPersonTelNo, ContactPersonMobNo, IsActive, LastModify from CustomerMaster ", "Customer Master", "CustomerMaster");
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnSubmitCustomerCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlCustomerCode.SelectedIndex != 0)
                {
                    BindCustomerGridByID(int.Parse(ddlCustomerCode.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubmitCustomerName_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlCustomerName.SelectedIndex != 0)
                {
                    BindCustomerGridByID(int.Parse(ddlCustomerName.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BindCustomerGridByID(int CustomerID)
        {
            try
            {
                objC = new CommonFunction();
                StringBuilder sqlCustomer = new StringBuilder();

                sqlCustomer.Append(" SELECT CustomerId, CustomerCode, Name, City, ");
                sqlCustomer.Append(" case when CustomerMaster.ZoneID is not null then (select ZoneMaster.Name ");
                sqlCustomer.Append(" from ZoneMaster where CustomerMaster.ZoneID = ZoneMaster.ID) end ZoneName, ");
                sqlCustomer.Append(" case when CustomerMaster.CustomerTypeID IS not null then (select CustomerType.CustomerType ");
                sqlCustomer.Append(" from CustomerType where CustomerType.ID = CustomerMaster.CustomerTypeID) end CustomerType, ");
                sqlCustomer.Append(" LocationCode, DispatchThru, IsActive from CustomerMaster where CustomerId = " + CustomerID);

                sqlDataAdapter = objC.GetSqlDataAdapter(sqlCustomer.ToString());

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvCustomerMaster.DataSource = bindingSource;

            }
            catch (Exception ex)
            {

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
                
        private void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(ddlCountry.SelectedIndex) != "0")
                {
                    BindStateMaster(int.Parse(ddlCountry.SelectedValue.ToString()));
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

        private void BindStateMaster(int CountryID)
        {
            try
            {
                if (CountryID > 0)
                {
                    DataTable dt = new DataTable();
                    CommonFunction objCommon = new CommonFunction();
                    ddlState.AutoCompleteSource = AutoCompleteSource.ListItems;
                    ddlState.AutoCompleteMode = AutoCompleteMode.Suggest;

                    dt = objCommon.GetDataTable("select StateID, name from State where CountryID = " + CountryID);
                    DataRow dr = dt.NewRow();
                    dr["StateID"] = 0;
                    dr["Name"] = "select";
                    dt.Rows.InsertAt(dr, 0);
                    ddlState.DataSource = dt;
                    ddlState.DisplayMember = "Name";
                    ddlState.ValueMember = "StateID";
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerMaster BindStateMaster \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
