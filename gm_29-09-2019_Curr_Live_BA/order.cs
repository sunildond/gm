using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ww_lib;
using System.IO;
using ww_admin;

namespace GlanMark
{
    public partial class Order : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        public Order()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Order_Load(object sender, EventArgs e)
        {
          //  tabPage5.Hide();
          //  tabPage2.Hide();
            BindPartyCode();
            BindInstitution();
            BindSubInstitution();
            BindYesNo();
            BindDocument();
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlpartycode.SelectedIndex) != "0")
            {
                 DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                    DataSet DS = new DataSet();
                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
                DS = objCommon.GetDataSet("select name1  from CustomerMaster where customerid="+ddlpartycode.SelectedValue.ToString(),"CustomerMaster");
                txtpartyname.Text = DS.Tables["CustomerMaster"].Rows[0]["name1"].ToString();

            }
        }

        public void BindYesNo()
        {
           
            ddlshelflife.Items.Insert(0, "Yes");
            ddlshelflife.Items.Insert(1, "No");
            ddlshelflife.SelectedIndex = 0;
        }

        private void BindPartyCode()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
                dt = objCommon.GetDataTable("select  Customerid,Customer  from CustomerMaster");
                DataRow dr = dt.NewRow();
                dr["Customerid"] = 0;
                dr["Customer"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlpartycode.DataSource = dt;
                ddlpartycode.DisplayMember = "Customer";
                ddlpartycode.ValueMember = "Customerid";

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

        private void tabPage2_Click(object sender, EventArgs e)
        {

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
                   //string query = "INSERT INTO OrderHeader (IOMDate,PartyName,InstPONo,InstPODate,Institution,SubInstitution,LastModify) VALUES ('" + txtiomno.Text + "','" + txtCountryCode.Text + "'," + int.Parse(ddlISActive.SelectedIndex.ToString()) + ", getdate())";
                   string query = "";
                    Result objResult = objCF.InsertQuery(query);
                    if (objResult.bStatus)
                    {
                        lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                        lblStatus.Text = "Country Master Inserted Sucessfully";
                        //ClearForm();
                        //BindCountryMaster();
                    }
                    else
                    {
                        lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                        lblStatus.Text = objResult.strMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCountryMaster save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool validateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;
            if (txtiomno.Text == "")
            {
                errorProvider1.SetError(txtiomno, "Location");
                isValid = false;
            }

            //if (txt.Text == "")
            //{
            //    errorProvider1.SetError(txtStateCode, "Location");
            //    isValid = false;
            //}

            //if (ddlCounrtyName.SelectedIndex == 0)
            //{
            //    errorProvider1.SetError(ddlCounrtyName, "Location");
            //    isValid = false;
            //}

            return isValid;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {

            tabControl1.TabPages.Add(tabPage5);
            tabControl1.TabPages.Add(tabPage6);
            for (int i = 0; i < ItemGridview.Rows.Count - 1; i++)
            {

            }     
        }

    }
}
