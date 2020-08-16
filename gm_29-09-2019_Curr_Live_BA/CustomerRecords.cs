using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using ww_admin;
using ww_lib;
using System.IO;

namespace GlanMark
{
    public partial class customermaster : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        static string ConnectionString = ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString();
        SqlConnection sqlCon = new SqlConnection(ConnectionString);
        SqlCommandBuilder sqlCommand = null;
        SqlDataAdapter sqlAdapter = null;
        DataSet dataset = null;

        public customermaster()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //public void CustomerRecordRetrive()
        //{
        //    string ConnectionString = ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString();
        //    SqlConnection Scon = new SqlConnection(ConnectionString);
        //    SqlDataAdapter Scom = new SqlDataAdapter("select CustomerID, customer as CustomerCode ,Name1 as Name , City, rg as Type from CustomerMaster", Scon);
        //    DataSet ds = new DataSet();
        //    // Scom.ExecuteNonQuery();
        //    Scom.Fill(ds, "CategoryMaster");
        //    dataGridView1.DataSource = ds.Tables["CategoryMaster"].DefaultView;

        //    //Scom.Connection.Dispose();

        //}

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void customermaster_Load(object sender, EventArgs e)
        {
            // CustomerRecordRetrive();
            LoadData();
            color_DataGridView();
            colorbtnAlternate();
            resizedatagrid();
            rowToBeSelected();
            BindDocument();
            BindSubInstitution();
            BindInstitution();
            BINDDSMZSM();
            BindLocationMaster();
            BindStampingMaster();
        }

        private void LoadData()
        {
            //try
            //{
            sqlAdapter = new SqlDataAdapter("select CustomerId, CustomerCode, Name, Street, VATregistrationNo, CSTnumber, LSTnumber, LastModify from CustomerMaster", sqlCon);
            sqlCommand = new SqlCommandBuilder(sqlAdapter);

            sqlAdapter.InsertCommand = sqlCommand.GetInsertCommand();
            sqlAdapter.UpdateCommand = sqlCommand.GetUpdateCommand();
            sqlAdapter.DeleteCommand = sqlCommand.GetDeleteCommand();

            dataset = new DataSet();
            sqlAdapter.Fill(dataset, "CustomerMaster");
            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = dataset.Tables["CustomerMaster"];

            for (int i = 0; i < dgvEmployee.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dgvEmployee[2, i] = linkCell;
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        private void dgvEmployee_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dgvEmployee_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int lastRow = dgvEmployee.Rows.Count - 2;
                DataGridViewRow nRow = dgvEmployee.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dgvEmployee[6, lastRow] = linkCell;
                nRow.Cells["Delete"].Value = "Insert";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    string Task = dgvEmployee.Rows[e.RowIndex].Cells[6].Value.ToString();
                    if (Task == "Delete")
                    {
                        if (MessageBox.Show("Are you sure to delete?", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dgvEmployee.Rows.RemoveAt(rowIndex);
                            dataset.Tables["Employees"].Rows[rowIndex].Delete();
                            sqlAdapter.Update(dataset, "Employees");
                        }
                    }
                    else if (Task == "Insert")
                    {
                        int row = dgvEmployee.Rows.Count - 2;
                        DataRow dr = dataset.Tables["CustomerMaster"].NewRow();
                        dr["LastName"] = dgvEmployee.Rows[row].Cells["LastName"].Value;
                        dr["FirstName"] = dgvEmployee.Rows[row].Cells["FirstName"].Value;
                        dr["Title"] = dgvEmployee.Rows[row].Cells["Title"].Value;
                        dr["HireDate"] = dgvEmployee.Rows[row].Cells["HireDate"].Value;
                        dr["PostalCode"] = dgvEmployee.Rows[row].Cells["PostalCode"].Value;

                        dataset.Tables["Employees"].Rows.Add(dr);
                        dataset.Tables["Employees"].Rows.RemoveAt(dataset.Tables["Employees"].Rows.Count - 1);
                        dgvEmployee.Rows.RemoveAt(dgvEmployee.Rows.Count - 2);
                        dgvEmployee.Rows[e.RowIndex].Cells[6].Value = "Delete";
                        sqlAdapter.Update(dataset, "Employees");
                    }
                    else if (Task == "Update")
                    {
                        int r = e.RowIndex;
                        dataset.Tables["CustomerMaster"].Rows[r]["LastName"] = dgvEmployee.Rows[r].Cells["LastName"].Value;
                        dataset.Tables["CustomerMaster"].Rows[r]["FirstName"] = dgvEmployee.Rows[r].Cells["FirstName"].Value;
                        dataset.Tables["CustomerMaster"].Rows[r]["Title"] = dgvEmployee.Rows[r].Cells["Title"].Value;
                        dataset.Tables["CustomerMaster"].Rows[r]["HireDate"] = dgvEmployee.Rows[r].Cells["HireDate"].Value;
                        dataset.Tables["CustomerMaster"].Rows[r]["PostalCode"] = dgvEmployee.Rows[r].Cells["PostalCode"].Value;
                        sqlAdapter.Update(dataset, "Employees");
                        dgvEmployee.Rows[e.RowIndex].Cells[6].Value = "Delete";
                    }
                }
            }
            catch (Exception ex) 
            { 
            
            }
        }

        public void colorbtnAlternate()
        {

            this.dgvEmployee.RowsDefaultCellStyle.BackColor = Color.White;
            this.dgvEmployee.AlternatingRowsDefaultCellStyle.BackColor = Color.Aquamarine;
        }

        public void btnReorder()
        {
            dgvEmployee.Columns["Code"].DisplayIndex = 1;
            dgvEmployee.Columns["Name"].DisplayIndex = 3;

        }

        private double Total()
        {
            double tot = 0;
            // int i = 0;
            //for (i = 0; i < Categorygdv.Rows.Count; i++)
            //{
            //    tot = tot + Convert.ToDouble(Categorygdv.Rows[i].Cells["id"].Value);
            //}
            tot = dgvEmployee.Rows.Count - 1;
            return tot;
        }

        public void hedernamechange()
        {
            dgvEmployee.Columns[0].HeaderText = "MyHeader1";
            dgvEmployee.Columns[1].HeaderText = "MyHeader2";
        }

        public void color_DataGridView()
        {
            this.dgvEmployee.DefaultCellStyle.ForeColor = Color.Coral;
            // Change back color of each row
            this.dgvEmployee.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            // Change GridLine Color
            this.dgvEmployee.GridColor = Color.Blue;
            // Change Grid Border Style
            this.dgvEmployee.BorderStyle = BorderStyle.Fixed3D;
        }
        
        public void resizedatagrid()
        {
            dgvEmployee.AutoResizeColumns();
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void rowToBeSelected()
        {
            int rowToBeSelected = 1; // third row
            if (dgvEmployee.Rows.Count >= rowToBeSelected)
            {
                // Since index is zero based, you have to subtract 1
                dgvEmployee.Rows[rowToBeSelected - 1].Selected = true;
            }
        }

        public void insertupdate()
        {
            CustomerMasterClass objCM = new CustomerMasterClass();
            //objCM.iCustomerId = Convert.ToInt32(txtCategoryCode.Text);
            //objCM.s = Convert.ToString(txtcategoryname.Text);
            //objCM.strIsActive = Convert.ToString(txtactive.Text);

            ResultClass objResult = objCM.fn_InsertCustomerMaster();
            if (objResult.bStatus)
            {
                MessageBox.Show(objResult.bStatus.ToString());
            }
            else
            {
                MessageBox.Show("error");
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BindInstitution()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
                dt = objCommon.GetDataTable("select  Code ,Name  from InstitutionMaster");
                DataRow dr = dt.NewRow();
                dr["Code"] = 0;
                dr["Name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlinst.DataSource = dt;
                ddlinst.DisplayMember = "Name";
                ddlinst.ValueMember = "Code";

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

        private void BINDDSMZSM()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
                dt = objCommon.GetDataTable("select Code, Name from DSM_ZSM");
                DataRow dr = dt.NewRow();
                dr["Code"] = 0;
                dr["Name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlzsm.DataSource = dt;
                ddlzsm.DisplayMember = "Name";
                ddlzsm.ValueMember = "Code";

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
                dt = objCommon.GetDataTable("select  Code ,Name  from LocationMaster");
                DataRow dr = dt.NewRow();
                dr["Code"] = 0;
                dr["Name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddllocation.DataSource = dt;
                ddllocation.DisplayMember = "Name";
                ddllocation.ValueMember = "Code";

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

        private void BindStampingMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
                dt = objCommon.GetDataTable("select  Code ,Name  from StampingMaster");
                DataRow dr = dt.NewRow();
                dr["Code"] = 0;
                dr["Name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlStamping.DataSource = dt;
                ddlStamping.DisplayMember = "Name";
                ddlStamping.ValueMember = "Code";

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

        private void BindDocument()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);

                dt = objCommon.GetDataTable("select Code, Name from DOC_REQ_Master");

                chkdocumentlist.DataSource = dt;
                chkdocumentlist.DisplayMember = "Name";
                chkdocumentlist.ValueMember = "Code";

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
        private void BindSubInstitution()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
                dt = objCommon.GetDataTable("select  Code ,Name  from SubInstitutionMaster");
                DataRow dr = dt.NewRow();
                dr["Code"] = 0;
                dr["Name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlsubinst.DataSource = dt;
                ddlsubinst.DisplayMember = "Name";
                ddlsubinst.ValueMember = "Code";

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


    }
}
