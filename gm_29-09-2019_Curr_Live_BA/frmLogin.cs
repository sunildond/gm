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
using System.Security.Principal;
using System.Threading;
using System.Security.AccessControl;
using System.Net.NetworkInformation;

namespace GlanMark
{

    public partial class frmLogin : Form
    {
        private int ID;
        private SqlConnection objConnection = null;
        string strLogFileName = "LOG\\LogRecord.txt";
        string strFileLOG = "LOG\\";

        public frmLogin()
        {
            InitializeComponent();
            OtherInitialize();
            DirectoryInfo oMyDirectoryInfo = new DirectoryInfo(strFileLOG);
            if (!oMyDirectoryInfo.Exists)
            {
                oMyDirectoryInfo.Create();
                DirectorySecurity oDirectorySecurity = oMyDirectoryInfo.GetAccessControl();
                oDirectorySecurity.AddAccessRule(new FileSystemAccessRule(WindowsIdentity.GetCurrent().Name, FileSystemRights.FullControl, AccessControlType.Allow));
                oMyDirectoryInfo.SetAccessControl(oDirectorySecurity);

                string strpath = System.Windows.Forms.Application.StartupPath;
                string strFileName = strpath + "LogRecord.txt";
                if (!File.Exists(strFileName))
                {
                    File.Create(strFileName);
                }
            }
        }

        private void OtherInitialize()
        {
            try
            {
                this.Closing += new CancelEventHandler(this.Form1_Closing);
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Login Page/OtherInitialize \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Closing(Object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = false;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Login Page/Form1_Closing \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        private void saveMACId(string MacID)
        {
            try
            {
                CommonFunction objCF = new CommonFunction();
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[ddlYear.SelectedValue.ToString()].ToString());
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = objConnection;
                objcmd.CommandText = "SPInsertIfNotExist";
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.Parameters.AddWithValue("@MacId", MacID);
                objConnection.Open();
                objcmd.ExecuteNonQuery();
                objConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //if (DateTime.Now.Day <= 20 || DateTime.Now.Month <= 9 || DateTime.Now.Year <= 2013)
                //{
                    //string MACId = string.Empty;
                    //MACId = GetMACAddress();
                    //if (MACId != "")
                    //{
                    //    saveMACId(MACId);
                    //}

                    ValidateUserID();
                    ValidatePassword();
                    if (ValidateUserID() && ValidatePassword())
                    {
                        string struname = txtUserId.Text;
                        string strpwd = txtPassword.Text;
                        //DBAdminUser objU = new DBAdminUser();
                        CommonFunction objCom = new CommonFunction();
                        DBSessionUser.iYearId = ddlYear.SelectedValue.ToString();
                        Result objResult = objCom.fn_ComparePassword(struname, strpwd);
                        
                        if (objResult.bStatus)
                        {
                            if (ddlYear.SelectedIndex != -1)
                            {
                                DBSessionUser.strUserLocation = getUserLocation(DBSessionUser.iUser_Id);
                                //DBSessionUser.iYearId = ddlYear.SelectedValue.ToString();
                                MdiForm parent = (MdiForm)this.MdiParent;
                                
                                //lblSelectedYear

                                txtUserId.Text = "";
                                txtPassword.Text = "";
                                txtUserId.Focus();
                                errorLogin.SetError(txtUserId, "");
                                errorLogin.SetError(txtPassword, "");
                                frmLogin newForm = (frmLogin)Application.OpenForms["frmLogin"];
                                newForm.Hide();
                                MdiForm au = new MdiForm();
                                au.Show();
                            }
                            else
                            {
                                MessageBox.Show("Select Year!!!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                        else
                        {
                            MessageBox.Show("You are Not Valid User!!Please Contact Administrator!!!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUserId.Text = "";
                            txtPassword.Text = "";
                            txtUserId.Focus();
                            errorLogin.SetError(txtPassword, "");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please, Enter Valid information!!!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                //}
                //else
                    //MessageBox.Show("Please Contact Your Software Administrator!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Login Page/btnLogin_Click \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected string getUserLocation(int UserId)
        {
            CommonFunction objComFun = new CommonFunction();
            DataTable dt = objComFun.GetDataTable("select SUBSTRING((select ', ' + LocationId from UserLocationRelation where UserId = 1 and Permission = 1 for xml path('')),3,6000) as Locations");

            return dt.Rows[0]["Locations"].ToString();

        }

        private void txtUserId_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                bool bStatus = ValidateUserID();
                if (bStatus == false)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Login Page/txtUserId_Validating \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidatePassword();
        }

        private bool ValidateUserID()
        {
            try
            {
                bool bStatus = true;
                if (txtUserId.Text == "")
                {
                    errorLogin.SetError(txtUserId, "Please enter User Name");
                    bStatus = false;
                }
                else
                {
                    errorLogin.SetError(txtUserId, "");
                }
                return bStatus;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Login Page/ValidateUserID \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool ValidatePassword()
        {
            try
            {
                bool bStatus = true;
                if (txtPassword.Text == "")
                {
                    errorLogin.SetError(txtPassword, "Please enter Password");
                    bStatus = false;
                }
                else
                {
                    errorLogin.SetError(txtPassword, "");
                }
                return bStatus;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Login Page/ValidatePassword \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                ActiveControl = txtUserId;

                BindYear();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Login Page/frmLogin_Load \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindYear()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "YearMaster";
                dt.Columns.Add("ID", Type.GetType("System.String"));
                dt.Columns.Add("Year", Type.GetType("System.String"));
                //CommonFunction objCommon = new CommonFunction();
                //dt = objCommon.GetDataTable("select ID, Year from YearMaster order by ID desc");
                //DataRow dr = dt.NewRow();
                //dr["ID"] = 2;
                //dr["Year"] = "2018 - 2019";
                //dt.Rows.InsertAt(dr, 0);

                DataRow dr1 = dt.NewRow();
                dr1["ID"] = 1;
                dr1["Year"] = "2018 - 2019";
                dt.Rows.InsertAt(dr1, 1);

                ddlYear.DataSource = dt;
                ddlYear.DisplayMember = "Year";
                ddlYear.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmLogin BindYear \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogin objLogin = (frmLogin)Application.OpenForms["frmLogin"];
                if (objLogin != null)
                {
                    objLogin.Close();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Login Page/btnExit_Click \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
