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
    public partial class frmProductMaster : Form
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
        private int mintPageSize = 25;
        private int mintPageCount = 0;
        private int mintCurrentPage = 1;

        public frmProductMaster()
        {
            InitializeComponent();
        }

        private void frmProductMaster_Load(object sender, EventArgs e)
        {
            try
            {
                bindGrid();
                bindSatus();
                BindItemCategory();
                BindAliseCode();
                BindProductName();
                BindHSNCode();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmProductMaster Load \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BindHSNCode()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                ddlHSNCode.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlHSNCode.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select cast(HSNCode as varchar(100)) as HSNCode from HSNMaster");
                DataRow dr = dt.NewRow();
                dr["HSNCode"] = 0;
                dr["HSNCode"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlHSNCode.DataSource = dt;
                ddlHSNCode.DisplayMember = "HSNCode";
                ddlHSNCode.ValueMember = "HSNCode";
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmProductMaster BindHSNCode \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BindItemCategory()
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                //SqlConnection conn = new SqlConnection(ConnectionString);
                objC = new CommonFunction();
                SqlDataAdapter da = objC.GetSqlDataAdapter("select * from ItemCategory order by Name");
                //new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                da.Fill(dt);
                dr["ID"] = 0;
                dr["Name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                cmbItemCategory.DataSource = dt;
                cmbItemCategory.DisplayMember = "Name";
                cmbItemCategory.ValueMember = "ID";

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

        private void BindAliseCode()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                ddlAliseName.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlAliseName.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select distinct Aliscode from ProductMaster");
                DataRow dr = dt.NewRow();
                dr["Aliscode"] = 0;
                dr["Aliscode"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlAliseName.DataSource = dt;
                ddlAliseName.DisplayMember = "Aliscode";
                ddlAliseName.ValueMember = "Aliscode";
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmProductMaster BindAliseCode \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindProductName()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                ddlProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlProductName.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select ProductId, Description from ProductMaster");
                DataRow dr = dt.NewRow();
                dr["Description"] = 0;
                dr["Description"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlProductName.DataSource = dt;
                ddlProductName.DisplayMember = "Description";
                ddlProductName.ValueMember = "ProductId";
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmProductMaster BindProductName \n" + ex.ToString();
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmProductMaster.cs Grid \n" + ex.ToString();
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
                sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " ProductId,HSNCode,Material,Description,Aliscode,AliasName,Unit,ItemCategory,IsActive FROM ProductMaster WHERE ProductId NOT IN (SELECT TOP " + intSkip + " ProductId FROM ProductMaster)");
                //sqlDataAdapter = new SqlDataAdapter(selectQueryString, sqlConnection);
                //sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                Productdgv.DataSource = bindingSource;

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
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('ProductMaster') AND IndId < 2");

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

        private void Productdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ClearForm();
                if (e.RowIndex != -1)
                {
                    id = int.Parse(Productdgv.Rows[e.RowIndex].Cells["colProductId"].Value.ToString());
                    if (e.ColumnIndex == Productdgv.Columns["colEdit"].Index)
                    {
                        lblStatus.Text = "";
                        //txtHSNCode.Text = Productdgv[Productdgv.Columns["colHSNCode"].Index, e.RowIndex].Value.ToString();
                        if (Productdgv[Productdgv.Columns["colHSNCode"].Index, e.RowIndex].Value.ToString() != "")
                        {
                            ddlHSNCode.SelectedValue = Productdgv[Productdgv.Columns["colHSNCode"].Index, e.RowIndex].Value.ToString();
                        }
                        else
                        {
                            ddlHSNCode.SelectedValue = "0";
                        }


                        txtMaterial.Text = Productdgv[Productdgv.Columns["colMaterial"].Index, e.RowIndex].Value.ToString();
                        txtDesc.Text = Productdgv[Productdgv.Columns["colDescription"].Index, e.RowIndex].Value.ToString();
                        if (Productdgv[Productdgv.Columns["colAlisCode"].Index, e.RowIndex].Value.ToString() != "")
                        {
                            txtAliscode.Text = Productdgv[Productdgv.Columns["colAlisCode"].Index, e.RowIndex].Value.ToString();
                        }
                        else
                        {
                            txtAliscode.Text = "0";
                        }

                        if (Productdgv[Productdgv.Columns["colAliasName"].Index, e.RowIndex].Value.ToString() != "")
                        {
                            txtAliasName.Text = Productdgv[Productdgv.Columns["colAliasName"].Index, e.RowIndex].Value.ToString();
                        }
                        //else
                        //{
                        //    txtAliscode.Text = "0";
                        //}

                        if (Productdgv[Productdgv.Columns["colUnit"].Index, e.RowIndex].Value.ToString() != "")
                        {
                            txtUnit.Text = Productdgv[Productdgv.Columns["colUnit"].Index, e.RowIndex].Value.ToString();
                        }
                        else
                        {
                            txtUnit.Text = "0";
                        }
                        if (Productdgv[Productdgv.Columns["colItemcategory"].Index, e.RowIndex].Value.ToString() != "")
                        {
                            cmbItemCategory.SelectedValue = Productdgv[Productdgv.Columns["colItemcategory"].Index, e.RowIndex].Value.ToString();                    
                        }
                        else
                        {
                            cmbItemCategory.SelectedValue = "0";
                        }
                        //txtLocName.Text = Productdgv[Productdgv.Columns["colIsActive"].Index, e.RowIndex].Value.ToString();
                        cmbStatus.SelectedValue = Productdgv[Productdgv.Columns["colStatus"].Index, e.RowIndex].Value.ToString();

                        //if (Productdgv[Productdgv.Columns["colCountry"].Index, e.RowIndex].Value.ToString() != "")
                        //{
                        //    ddlCountry.SelectedValue = int.Parse(Productdgv[Productdgv.Columns["colCountry"].Index, e.RowIndex].Value.ToString());
                        //    BindState(Productdgv[Productdgv.Columns["colCountry"].Index, e.RowIndex].Value.ToString());
                        //    ddlState.SelectedValue = int.Parse(Productdgv[Productdgv.Columns["colState"].Index, e.RowIndex].Value.ToString());
                        //}
                        //else
                        //{
                        //    ddlCountry.SelectedValue = 0;
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
                    else if (e.ColumnIndex == Productdgv.Columns["colDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this Product", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("UPDATE ProductMaster SET IsActive = 'No' where ProductId='" + id + "'");
                            if (res.bStatus)
                            {
                                MessageBox.Show("Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                            //Productdgv.Rows.RemoveAt(Productdgv.CurrentRow.Index);
                            //sqlDataAdapter.Update(dataTable);

                            bindGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmProductMaster.cs CellContentClick \n" + ex.ToString();
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
                    //SqlCommand objCommand = new SqlCommand();
                    if (lblHdnSource.Text == "0")
                    {
                        //string query = "INSERT INTO ProductMaster (Material,Description,Aliscode,AliasName,Unit,ItemCategory,IsActive,LastModify) VALUES ('" + txtMaterial.Text + "','" + txtDesc.Text + "','" + txtAliscode.Text + "','" + txtAliasName.Text + "','" + txtUnit.Text + "','" + cmbItemCategory.SelectedValue.ToString() + "','" + cmbStatus.SelectedValue.ToString() + "', getdate())";

                        string Query = "INSERT INTO ProductMaster (HSNCode,Material,Description,Aliscode,AliasName,Unit,ItemCategory,IsActive,LastModify) VALUES (@HSNCode,@Material,@Description,@Aliscode,@AliasName,@Unit,@ItemCategory,@IsActive, getdate())";
                        SqlCommand objCommand = new SqlCommand(Query);
                        objCommand.Parameters.AddWithValue("@HSNCode", int.Parse(ddlHSNCode.SelectedValue.ToString()));
                        objCommand.Parameters.AddWithValue("@Material", txtMaterial.Text);
                        objCommand.Parameters.AddWithValue("@Description", txtDesc.Text);

                        objCommand.Parameters.AddWithValue("@Aliscode", txtAliscode.Text);
                        objCommand.Parameters.AddWithValue("@AliasName", txtAliasName.Text);

                        objCommand.Parameters.AddWithValue("@Unit", txtUnit.Text);
                        objCommand.Parameters.AddWithValue("@ItemCategory", cmbItemCategory.SelectedValue.ToString());
                        objCommand.Parameters.AddWithValue("@IsActive", cmbStatus.SelectedValue.ToString());
                        Result objResult = objCF.ExecuteNewDMLQuery(objCommand);

                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Product Master Inserted Sucessfully";
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
                        //string query = "UPDATE ProductMaster set Material='" + txtMaterial.Text + "',Description='" + txtDesc.Text + "',Aliscode='" + txtAliscode.Text + "',AliasName='" + txtAliasName.Text + "',Unit='" + txtUnit.Text + "',ItemCategory='" + cmbItemCategory.SelectedValue.ToString() + "',IsActive='" + cmbStatus.SelectedValue.ToString() + "',LastModify=getdate() WHERE ProductId='" + lblHdnSource.Text + "'";
                        string query = "UPDATE ProductMaster set HSNCode=@HSNCode, Material=@Material,Description=@Description,Aliscode=@Aliscode,AliasName=@AliasName,Unit=@Unit,ItemCategory=@ItemCategory,IsActive= @IsActive,LastModify=getdate() WHERE ProductId=" + lblHdnSource.Text;
                        //string Query = "INSERT INTO ProductMaster (Material,Description,Aliscode,AliasName,Unit,ItemCategory,IsActive,LastModify) VALUES ('" + txtMaterial.Text + "','" + txtDesc.Text + "','" + txtAliscode.Text + "','" + txtAliasName.Text + "','" + txtUnit.Text + "','" + cmbItemCategory.SelectedValue.ToString() + "','" + cmbStatus.SelectedValue.ToString() + "', getdate())";
                        SqlCommand objCommand = new SqlCommand(query);
                        objCommand.Parameters.AddWithValue("@HSNCode", int.Parse(ddlHSNCode.SelectedValue.ToString()));
                        objCommand.Parameters.AddWithValue("@Material", txtMaterial.Text);
                        objCommand.Parameters.AddWithValue("@Description", txtDesc.Text);
                        objCommand.Parameters.AddWithValue("@Aliscode", txtAliscode.Text);
                        objCommand.Parameters.AddWithValue("@AliasName", txtAliasName.Text);
                        objCommand.Parameters.AddWithValue("@Unit", txtUnit.Text);
                        objCommand.Parameters.AddWithValue("@ItemCategory", cmbItemCategory.SelectedValue.ToString());
                        objCommand.Parameters.AddWithValue("@IsActive", cmbStatus.SelectedValue.ToString());

                        Result objResult = objCF.ExecuteNewDMLQuery(objCommand);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Product Master Updated Sucessfully";
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmProductMaster.cs save button \n" + ex.ToString();
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
                lblHdnSource.Text = "0";
                ClearForm();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmProductMaster.cs cancel button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateForm()
        {
            errorProduct.Clear();
            bool isValid = true;

            
            if (txtMaterial.Text == "")
            {
                errorProduct.SetError(txtMaterial, "Material");
                isValid = false;
            }

            if (txtDesc.Text == "")
            {
                errorProduct.SetError(txtDesc, "Description");
                isValid = false;
            }

            if (txtAliscode.Text == "")
            {
                errorProduct.SetError(txtAliscode, "Aliscode");
                isValid = false;
            }

            if (txtUnit.Text == "")
            {
                errorProduct.SetError(txtUnit, "Unit");
                isValid = false;
            }

            if (cmbItemCategory.SelectedIndex == 0)
            {
                errorProduct.SetError(cmbItemCategory, "Item Category");
                isValid = false;
            }

            if (ddlHSNCode.SelectedIndex == 0)
            {
                errorProduct.SetError(ddlHSNCode, "HSN Code");
                isValid = false;
            }

            //try
            //{
            //    int intHSNCode = int.Parse(txtHSNCode.Text);
            //}
            //catch (Exception ex)
            //{
            //    errorProduct.SetError(txtHSNCode, "Only Numeric");
            //    return isValid = false;
            //}

            try
            {
                int intUnit = int.Parse(txtUnit.Text);
            }
            catch (Exception ex)
            {
                errorProduct.SetError(txtUnit, "Only Numeric");
                return isValid = false;
            }

            //if (cmbStatus.SelectedValue == "")
            //{
            //    errorProduct.SetError(cmbStatus, "Status");
            //    isValid = false;
            //}

            return isValid;
        }

        private void ClearForm()
        {
            ddlHSNCode.SelectedValue = 0;
            txtMaterial.Text = "";
            txtAliscode.Text = "";
            txtAliasName.Text = "";
            txtDesc.Text = "";
            txtUnit.Text = "";
            cmbItemCategory.SelectedIndex = 0;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            objCF.fn_ExportToExcel("select * from ProductMaster", "Product Master", "ProductMaster");
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

        private void ddlCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmitAliseName_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlAliseName.SelectedIndex != 0)
                {
                    BindProductGridByID(ddlAliseName.Text.ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void BindProductGridByID(string Aliscode)
        {
            try
            {
                objC = new CommonFunction();
                StringBuilder sqlProduct = new StringBuilder();

                sqlProduct.Append(" SELECT ProductId,HSNCode,Material,Description,Aliscode,AliasName,Unit,ItemCategory,IsActive FROM ProductMaster ");
                sqlProduct.Append(" WHERE Aliscode = '" + Aliscode + "'");

                sqlDataAdapter = objC.GetSqlDataAdapter(sqlProduct.ToString());

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                Productdgv.DataSource = bindingSource;

            }
            catch (Exception ex)
            {

            }
        }

        private void BindProductGridByName(int ProductId)
        {
            try
            {
                objC = new CommonFunction();
                StringBuilder sqlProduct = new StringBuilder();

                sqlProduct.Append(" SELECT ProductId,HSNCode,Material,Description,Aliscode,AliasName,Unit,ItemCategory,IsActive FROM ProductMaster ");
                sqlProduct.Append(" WHERE ProductId = " + ProductId);

                sqlDataAdapter = objC.GetSqlDataAdapter(sqlProduct.ToString());

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                Productdgv.DataSource = bindingSource;

            }
            catch (Exception ex)
            {

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSubmitProductName_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlProductName.SelectedIndex != 0)
                {
                    BindProductGridByName(int.Parse(ddlProductName.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {

            }
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
        //        string strError = DateTime.Now.ToString() + "\n Main Page/frmProductMaster.cs Update button \n" + ex.ToString();
        //        swLog.WriteLine(strError);
        //        swLog.WriteLine();
        //        swLog.Close();
        //        MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

    }
}
