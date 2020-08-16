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

namespace GlanMark
{
    public partial class frmUserMaster : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        //private String selectQueryString = null;
        private int id;
        private int UserId = 0;

        // Page
        private int mintTotalRecords = 0;
        private int mintPageSize = 20;
        private int mintPageCount = 0;
        private int mintCurrentPage = 1;

        public frmUserMaster()
        {
            InitializeComponent();
        }

        private void frmUserMaster_Load(object sender, EventArgs e)
        {
            bindGrid();
            bindSatus();
            bindLocation();
        }

        public void bindLocation()
        {
            try
            {
                DataTable dtLoc = new DataTable();
                CommonFunction objCom = new CommonFunction();

                //dt = objCom.GetDataTable("select LocationMaster.LocationId, LocationMaster.LocationCode, LocationMaster.DispatchThru, ISNULL(Permission,0) as Permission, UserId from UserLocationRelation right join LocationMaster on LocationMaster.LocationId = LocationMaster.LocationId where LocationMaster.IsActive = 'Yes' and UserId=1");
                dtLoc = objCom.GetDataTable("select LocationMaster.LocationId, LocationMaster.LocationCode, LocationMaster.DispatchThru, 0 as Permission, 0 as UserId from LocationMaster where LocationMaster.IsActive = 'Yes'");

                BindingSource bsLocation = new BindingSource();
                bsLocation.DataSource = dtLoc;
                dgvLocation.DataSource = dtLoc;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/bindLocation Tab \n" + ex.ToString();
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
                sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " UserId,Name,UserName,Email,IsActive,addPerm,editPerm,IsAuthorise from UserMaster WHERE UserId NOT IN (SELECT TOP " + intSkip + " UserId FROM UserMaster)");
                //sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " UserId,UserName,IsActive from UserMaster join UserTypeMaster on UserMaster.user_type_id=UserTypeMaster.ID WHERE UserId NOT IN (SELECT TOP " + intSkip + " UserId FROM UserMaster)");
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
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('UserMaster') AND IndId < 2");

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

        private void dgvUserMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    id = int.Parse(dgvUserMaster.Rows[e.RowIndex].Cells["colUserId"].Value.ToString());
                    if (e.ColumnIndex == dgvUserMaster.Columns["colEdit"].Index)
                    {
                        lblStatus.Text = "";
                        txtUserName.Text = dgvUserMaster[dgvUserMaster.Columns["colUserName"].Index, e.RowIndex].Value.ToString();
                        //txtUserName.Enabled = false;
                        txtUserFullName.Text = dgvUserMaster[dgvUserMaster.Columns["colName"].Index, e.RowIndex].Value.ToString();
                        txtUserEmail.Text = dgvUserMaster[dgvUserMaster.Columns["colEmail"].Index, e.RowIndex].Value.ToString();
                        //txtUserPassword = dgvUserMaster[dgvUserMaster.Columns["colCode"].Index, e.RowIndex].Value.ToString();

                        cmbStatus.SelectedValue = dgvUserMaster[dgvUserMaster.Columns["colStatus"].Index, e.RowIndex].Value.ToString();

                        chkAdd.Checked = bool.Parse(dgvUserMaster[dgvUserMaster.Columns["colAddPerm"].Index, e.RowIndex].Value.ToString());
                        chkEdit.Checked = bool.Parse(dgvUserMaster[dgvUserMaster.Columns["colEditPerm"].Index, e.RowIndex].Value.ToString());

                        chkIsAuthorise.Checked = bool.Parse(dgvUserMaster[dgvUserMaster.Columns["colIsAuthorise"].Index, e.RowIndex].Value.ToString());

                        lblHdnSource.Text = id.ToString();

                        bindLocationByUserId(id);

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
                        var result = MessageBox.Show("Do you want delete this User", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("UPDATE UserMaster SET IsActive = 'No' where UserId='" + id + "'");
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
                    else if (e.ColumnIndex == dgvUserMaster.Columns["colPermission"].Index)
                    {
                        frmUserPermission objUserPermission = (frmUserPermission)Application.OpenForms["frmUserPermission"];
                        if (objUserPermission != null)
                        {
                            objUserPermission.WindowState = FormWindowState.Normal;
                            objUserPermission.BringToFront();
                        }
                        else
                        {
                            objUserPermission = new frmUserPermission(id);
                            objUserPermission.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmUserMaster Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void bindLocationByUserId(int UId)
        {
            try
            {
                DataTable dtLoc = new DataTable();
                CommonFunction objCom = new CommonFunction();

                dtLoc = objCom.GetDataTable("select LocationMaster.LocationId, LocationMaster.LocationCode, LocationMaster.DispatchThru, ISNULL(permission,0) as Permission, UserId from UserLocationRelation right join LocationMaster on UserLocationRelation.LocationId = LocationMaster.LocationId where LocationMaster.IsActive = 'Yes' and UserId = " + UId);

                if (dtLoc.Rows.Count > 0)
                {
                    BindingSource bsLocation = new BindingSource();
                    bsLocation.DataSource = dtLoc;
                    dgvLocation.DataSource = dtLoc;
                }
                else
                {
                    bindLocation();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/bindLocationByUserId Tab \n" + ex.ToString();
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
                int bAdd = 0;
                int bEdit = 0;
                int IsAuthorise = 0;
                bstatus = validateForm();
                if (bstatus == true)
                {
                    if (chkAdd.Checked == true)
                        bAdd = 1;
                    else
                        bAdd = 0;

                    if (chkEdit.Checked == true)
                        bEdit = 1;
                    else
                        bEdit = 0;

                    if (chkIsAuthorise.Checked == true)
                        IsAuthorise = 1;
                    else
                        IsAuthorise = 0;

                    CommonFunction objCF = new CommonFunction();
                    if (lblHdnSource.Text == "0")
                    {
                        string query = "select * from UserMaster where UserName = '" + txtUserName.Text + "'";
                        Result objResult = objCF.ExecuteReaderQuery(query);
                        if (!objResult.bStatus)
                        {
                            query = "INSERT INTO UserMaster (Name,UserName,Password,Email,IsActive,addPerm,editPerm,IsAuthorise) VALUES ('" + txtUserFullName.Text + "','" + txtUserName.Text + "','" + txtUserPassword.Text + "','" + txtUserEmail.Text + "','" + cmbStatus.SelectedValue.ToString() + "'," + bAdd + "," + bEdit + ","+ IsAuthorise +")";
                            objResult = objCF.InsertQuery(query);
                            if (objResult.bStatus)
                            {
                                InsertUserPermission(objResult.iRecordId);
                                lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                                lblStatus.Text = "User Master Inserted Sucessfully";
                                ClearForm();
                                bindGrid();

                                bindLocation();
                            }
                            else
                            {
                                lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                                lblStatus.Text = objResult.strMessage;
                            }
                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            lblStatus.Text = "Same Username Present";
                        }
                    }
                    else if (lblHdnSource.Text != "0")
                    {
                        string query = "UPDATE UserMaster set UserName = '" + txtUserName.Text.Trim() + "', Name='" + txtUserFullName.Text + "',Password='" + txtUserPassword.Text + "',Email='" + txtUserEmail.Text + "',IsActive='" + cmbStatus.SelectedValue.ToString() + "' ,addPerm=" + bAdd + ",editPerm=" + bEdit + ",IsAuthorise=" + IsAuthorise + " WHERE UserId='" + lblHdnSource.Text + "'";
                        Result objResult = objCF.ExecuteDMLQuery(query);
                        if (objResult.bStatus)
                        {
                            UpdateUserPermission(int.Parse(lblHdnSource.Text));
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "User Master Updated Sucessfully";
                            lblHdnSource.Text = "0";
                            ClearForm();
                            bindGrid();
                            //txtUserName.Enabled = true;
                            bindLocation();
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

        }

        private void InsertUserPermission(int UId)
        {
            try
            {
                CommonFunction objCF = new CommonFunction();
                //SqlCommand objcmd = new SqlCommand("Delete from UserModuleRelation where user_id=@user_id");
                //objcmd.Parameters.AddWithValue("@user_id", id);

                //Result objResult = objCF.ExecuteNewDMLQuery(objcmd);
                //if (objResult.bStatus)
                //{
                //    //DelFlag = 1;
                //}

                int iflag = 0, flag = 0;
                foreach (DataGridViewRow row in dgvLocation.Rows)
                {
                    //////if (row.Cells["colPermission"].Value != null && Convert.ToBoolean(row.Cells["colPermission"].Value) == true)
                    //////{
                    iflag++;
                    SqlCommand objcmd = new SqlCommand("INSERT INTO UserLocationRelation (UserId, LocationId, Permission, LastModify) VALUES (@UserId, @LocationId, @Permission, getdate()); SELECT @pk_new = @@IDENTITY");

                    objcmd.Parameters.AddWithValue("@UserId", UId);
                    objcmd.Parameters.AddWithValue("@LocationId", row.Cells["colLocationId"].Value);
                    objcmd.Parameters.AddWithValue("@Permission", row.Cells["colPerm"].Value);

                    SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                    spInsertedKey.Direction = ParameterDirection.Output;
                    objcmd.Parameters.Add(spInsertedKey);

                    Result objResult1 = objCF.InsertNewQuery(objcmd);
                    if (objResult1.bStatus)
                    {
                        flag++;
                    }
                    //////}
                }
                //MessageBox.Show("Order Item Inserted Sucessfully");
                if (flag == iflag)
                {
                    if (MessageBox.Show("Permission Inserted Sucessfully") == DialogResult.OK)
                    {
                        //Orderdetail objOrder = new Orderdetail();
                        //objOrder.Close();

                        //this.Close();
                        //frmUserMaster objfrmUserMaster = (frmUserMaster)Application.OpenForms["frmUserMaster"];
                        //objfrmUserMaster.bindGrid();
                    }
                }
                else
                {
                    //lblmsg.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    //lblmsg.Text = "Order Item Not Updated Sucessfully (Error Occured)";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void UpdateUserPermission(int UserId)
        {
            try
            {
                //DelFlag = 1;
                int iflag = 0, flag = 0;

                CommonFunction objCF = new CommonFunction();
                SqlCommand objcmdDel = new SqlCommand("Delete from UserLocationRelation where UserId = @UserId");
                objcmdDel.Parameters.AddWithValue("@UserId", UserId);

                Result objResult = objCF.ExecuteNewDMLQuery(objcmdDel);
                if (objResult.bStatus)
                {

                }

                foreach (DataGridViewRow row in dgvLocation.Rows)
                {
                    iflag++;
                    SqlCommand objcmd = new SqlCommand("INSERT INTO UserLocationRelation (UserId, LocationId, Permission, LastModify) VALUES (@UserId, @LocationId, @Permission, getdate()); SELECT @pk_new = @@IDENTITY");

                    objcmd.Parameters.AddWithValue("@UserId", UserId);
                    objcmd.Parameters.AddWithValue("@LocationId", row.Cells["colLocationId"].Value);
                    objcmd.Parameters.AddWithValue("@Permission", row.Cells["colPerm"].Value);

                    SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                    spInsertedKey.Direction = ParameterDirection.Output;
                    objcmd.Parameters.Add(spInsertedKey);

                    Result objResult1 = objCF.InsertNewQuery(objcmd);
                    if (objResult1.bStatus)
                    {
                        flag++;
                    }
                }

                if (flag == iflag)
                {
                    MessageBox.Show("Permission Updated Sucessfully");
                }
                else
                {
                    //lblmsg.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    //lblmsg.Text = "Order Item Not Updated Sucessfully (Error Occured)";
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

            if (txtUserName.Text == "")
            {
                errorProvider.SetError(txtUserName, "User Name");
                isValid = false;
            }

            if (txtUserFullName.Text == "")
            {
                errorProvider.SetError(txtUserFullName, "Full Name");
                isValid = false;
            }

            if (txtUserEmail.Text == "")
            {
                errorProvider.SetError(txtUserEmail, "Email");
                isValid = false;
            }

            if (txtUserPassword.Text == "")
            {
                errorProvider.SetError(txtUserPassword, "Password");
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
            txtUserName.Text = "";
            txtUserFullName.Text = "";
            txtUserEmail.Text = "";
            txtUserPassword.Text = "";
            chkAdd.Checked = false;
            chkEdit.Checked = false;
            chkIsAuthorise.Checked = false;
            cmbStatus.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                bindGrid();
                ClearForm();
                lblHdnSource.Text = "0";
                bindLocation();
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
            objCF.fn_ExportToExcel("select UserId,Name,UserName,Email,IsActive from UserMaster", "User Master", "UserMaster");
        }

        private void dgvLocation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        

    }
}
