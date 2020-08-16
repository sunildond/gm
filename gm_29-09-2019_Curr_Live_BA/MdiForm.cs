using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLENMARK;
using System.IO;
using ww_lib;
using ww_admin;
using System.Security.AccessControl;
using System.Security.Principal;
using GlenMark;
using gm;

namespace GlanMark
{
    public partial class MdiForm : Form
    {
        string strFilePDF = "LOG\\";
        string strLogFileName = "LOG/LogRecord.txt";
        public DateTime dtCurrent;
        private int childFormNumber = 0;
        public MdiForm()
        {
            InitializeComponent();
            OtherInitialize();
            fn_CheckAuthentication();
            //////fn_CheckforLog();
            DataTable dt = new DataTable();
            CommonFunction objCommon = new CommonFunction();
            dt = objCommon.GetDataTable("select GETDATE() as CDate");
            dtCurrent = DateTime.Parse(dt.Rows[0]["CDate"].ToString());


        }

        public void fn_CheckforLog()
        {
            try
            {
                DirectoryInfo oMyDirectoryInfo = new DirectoryInfo(strFilePDF);
                if (!oMyDirectoryInfo.Exists)
                {
                    oMyDirectoryInfo.Create();
                    DirectorySecurity oDirectorySecurity = oMyDirectoryInfo.GetAccessControl();
                    oDirectorySecurity.AddAccessRule(new FileSystemAccessRule(WindowsIdentity.GetCurrent().Name, FileSystemRights.FullControl, AccessControlType.Allow));
                    oMyDirectoryInfo.SetAccessControl(oDirectorySecurity);
                    StreamWriter swLog;
                    if (!File.Exists(strLogFileName))
                    {
                        swLog = new StreamWriter(strLogFileName);
                    }
                    else
                    {
                        swLog = File.AppendText(strLogFileName);
                    }
                    swLog.WriteLine("Created On " + DateTime.Now.ToString("dd MMM yyyy"));
                    swLog.WriteLine();
                    swLog.Close();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/fn_CheckforLog \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fn_CheckAuthentication()
        {
            try
            {
                if (DBSessionUser.iUser_Id != -1)
                {
                    CommonFunction objAdminUser = new CommonFunction();
                    DataTable dt = new DataTable();
                    ////dt = objAdminUser.GetDataTable(" select ModuleMaster.module_name,UserModuleRelation.permission from UserModuleRelation join ModuleMaster on UserModuleRelation.module_id=ModuleMaster.module_id where UserModuleRelation.user_id=" + DBSessionUser.iUser_Id);
                    dt = objAdminUser.GetDataTable(" select * from UserModuleRelation where user_id=" + DBSessionUser.iUser_Id);
                    if (dt.Rows.Count > 0)
                    {
                        //menuToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[0]["order"]);
                        categoryMasterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[0]["permission"]);
                        locationMasterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[1]["permission"]);
                        subInstMasterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[2]["permission"]);
                        subInsttitutionToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[3]["permission"]);
                        dOCREQMasterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[4]["permission"]);
                        itemCatMasterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[5]["permission"]);
                        customerMasterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[6]["permission"]);
                        CustomerTypeToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[7]["permission"]);
                        CustomerCategoryToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[8]["permission"]);
                        productMasterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[9]["permission"]);
                        StampingMaster.Enabled = Convert.ToBoolean(dt.Rows[10]["permission"]);
                        DSMZSMtoolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[11]["permission"]);
                        orderTypeToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[12]["permission"]);
                        CountryToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[13]["permission"]);
                        StateToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[14]["permission"]);
                        ZoneToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[15]["permission"]);
                        IOMLogicMasterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[16]["permission"]);
                        TaxTypeMasterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[17]["permission"]);
                        taxMasterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[18]["permission"]);
                        //transactionToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[0]["order"]);
                        orderToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[19]["permission"]);
                        //---pendingOrderToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[0]["order"]);
                        dispatchDetailToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[20]["permission"]);
                        STNDispatchToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[21]["permission"]);
                        readyForBillingToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[22]["permission"]);
                        importDataToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[23]["permission"]);
                        importFormSAPToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[24]["permission"]);
                        //importFromSTNToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[0]["order"]);
                        importFromIBSToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[25]["permission"]);
                        importStockToWhareHosueToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[26]["permission"]);
                        //queryToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[27]["permission"]);
                        reportsToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[28]["permission"]);
                        pendingReasonsToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[29]["permission"]);
                        userMasterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[30]["permission"]);
                        pendingOrderToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[31]["permission"]);
                        queryLToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[32]["permission"]);
                        queryGeneratorToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[33]["permission"]);
                        queryExecuterToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[34]["permission"]);
                        copyIOMToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[35]["permission"]);
                        resetBatchAllocationToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[36]["permission"]);
                        LiasonerMastertoolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[37]["permission"]);
                        deletedOrderToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[38]["permission"]);


                        iOMReportToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[39]["permission"]);
                        pendingReportToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[40]["permission"]);
                        STNDispatchToolStripMenuItem1.Enabled = Convert.ToBoolean(dt.Rows[41]["permission"]);
                        invoiceDetailWithoutProductToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[42]["permission"]);
                        allSQlMeToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[43]["permission"]);
                        deletedIOMReportToolStripMenuItem.Enabled = Convert.ToBoolean(dt.Rows[43]["permission"]);

                        if (DBSessionUser.strName.ToLower() == "admin")
                        {
                            dataBaseBackupToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            dataBaseBackupToolStripMenuItem.Enabled = false;
                        }


                        //-------------------------------------------For Only CFA Location------------------------------------------
                        //dispatchDetailToolStripMenuItem.Enabled = false;
                        //transactionToolStripMenuItem.Enabled = false;
                        //Hide Inside Transaction Menu

                        //Hide All Menus except Transaction
                        //menuToolStripMenuItem.Enabled = false;
                        //importDataToolStripMenuItem.Enabled = false;
                        //queryToolStripMenuItem.Enabled = false;
                        //reportsToolStripMenuItem.Enabled = false;
                        //sToolStripMenuItem.Enabled = false;
                        //windowsMenu.Enabled = false;
                        //viewMenu.Enabled = false;
                        //helpMenu.Enabled = false;
                        //orderToolStripMenuItem.Enabled = false;
                        //pendingOrderToolStripMenuItem.Enabled = false;
                        //readyForBillingToolStripMenuItem.Enabled = false;
                        //STNDispatchToolStripMenuItem.Enabled = false;
                        //copyIOMToolStripMenuItem.Enabled = false;
                        //resetBatchAllocationToolStripMenuItem.Enabled = false;
                        //deletedOrderToolStripMenuItem.Enabled = false;
                        //readyForBillingNewToolStripMenuItem.Enabled = false;

                    }
                    else
                    {
                        var result = MessageBox.Show("You have not permission to access this!", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            frmLogin objLogin = new frmLogin();
                            objLogin.ShowDialog();
                        }
                        else
                        {
                            frmLogin newForm = (frmLogin)Application.OpenForms["frmLogin"];
                            newForm.Dispose();
                        }
                    }
                }
                else
                {
                    frmLogin objLogin = new frmLogin();
                    objLogin.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/fn_CheckAuthentication \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
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
                string strError = DateTime.Now.ToString() + "\n Main Page/OtherInitialize \n" + ex.ToString();
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
                if (DBSessionUser.iUser_Id != -1)
                {
                    frmLogin newForm = (frmLogin)Application.OpenForms["frmLogin"];
                    newForm.Dispose();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Form1_Closing \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoryMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void locationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoryMasterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //frmCategory frm = new frmCategory();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
            try
            {
                frmCategory objfrmCategory = (frmCategory)Application.OpenForms["frmCategory"];
                if (objfrmCategory != null)
                {
                    objfrmCategory.WindowState = FormWindowState.Normal;
                    objfrmCategory.BringToFront();
                }
                else
                {
                    objfrmCategory = new frmCategory();
                    objfrmCategory.MdiParent = this;
                    objfrmCategory.Show();
                }
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

        private void locationMasterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            //location frm = new location();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
            try
            {
                frmlocation objLocation = (frmlocation)Application.OpenForms["location"];
                if (objLocation != null)
                {
                    objLocation.WindowState = FormWindowState.Normal;
                    objLocation.BringToFront();
                }
                else
                {
                    objLocation = new frmlocation();
                    objLocation.MdiParent = this;
                    objLocation.Show();
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

        private void subInstMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmInstitutionCategory frm = new frmInstitutionCategory();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
            try
            {
                frmInstitutionCategory objfrmInstitutionCategory = (frmInstitutionCategory)Application.OpenForms["frmInstitutionCategory"];
                if (objfrmInstitutionCategory != null)
                {
                    objfrmInstitutionCategory.WindowState = FormWindowState.Normal;
                    objfrmInstitutionCategory.BringToFront();
                }
                else
                {
                    objfrmInstitutionCategory = new frmInstitutionCategory();
                    objfrmInstitutionCategory.MdiParent = this;
                    objfrmInstitutionCategory.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Institution Category Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void subInsttitutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSubInstitutionCategory frm = new frmSubInstitutionCategory();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
            try
            {
                frmSubInstitutionCategory objfrmSubInstitutionCategory = (frmSubInstitutionCategory)Application.OpenForms["frmSubInstitutionCategory"];
                if (objfrmSubInstitutionCategory != null)
                {
                    objfrmSubInstitutionCategory.WindowState = FormWindowState.Normal;
                    objfrmSubInstitutionCategory.BringToFront();
                }
                else
                {
                    objfrmSubInstitutionCategory = new frmSubInstitutionCategory();
                    objfrmSubInstitutionCategory.MdiParent = this;
                    objfrmSubInstitutionCategory.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/SubInstitution Category Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customerMasterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //customermaster frm = new customermaster();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
            try
            {
                frmCustomerMaster objCustomerMaster = (frmCustomerMaster)Application.OpenForms["frmCustomerMaster"];
                if (objCustomerMaster != null)
                {
                    objCustomerMaster.WindowState = FormWindowState.Maximized;
                    objCustomerMaster.BringToFront();
                }
                else
                {
                    objCustomerMaster = new frmCustomerMaster();
                    objCustomerMaster.MdiParent = this;
                    objCustomerMaster.WindowState = FormWindowState.Maximized;
                    objCustomerMaster.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Customer Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dOCREQMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmRequestdoc objSM = (frmRequestdoc)Application.OpenForms["frmRequestdoc"];
                if (objSM != null)
                {
                    objSM.WindowState = FormWindowState.Normal;
                    objSM.BringToFront();
                }
                else
                {
                    objSM = new frmRequestdoc();
                    objSM.MdiParent = this;
                    objSM.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/State Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemCatMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemCategory objSM = (frmItemCategory)Application.OpenForms["frmItemCategory"];
                if (objSM != null)
                {
                    objSM.WindowState = FormWindowState.Maximized;
                    objSM.BringToFront();
                }
                else
                {
                    objSM = new frmItemCategory();
                    objSM.MdiParent = this;
                    objSM.WindowState = FormWindowState.Maximized;
                    objSM.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/State Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void productMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductMaster objSM = (frmProductMaster)Application.OpenForms["frmProductMaster"];
                if (objSM != null)
                {
                    objSM.WindowState = FormWindowState.Maximized;
                    objSM.BringToFront();
                }
                else
                {
                    objSM = new frmProductMaster();
                    objSM.MdiParent = this;
                    objSM.WindowState = FormWindowState.Maximized;
                    objSM.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/State Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void switchUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Really want to Switch to another Login?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DBSessionUser.iUser_Id = -1;
                    MdiForm objMaster = (MdiForm)Application.OpenForms["MdiForm"];
                    objMaster.Close();
                    frmLogin objLogin = (frmLogin)Application.OpenForms["frmLogin"];
                    objLogin.Show();
                    objLogin.BringToFront();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/swichUserToolStripMenuItem_Click \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult Response;
            //Response = MessageBox.Show("Are you sure you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //if (Response == DialogResult.Yes)
            //    Application.Exit();

            try
            {
                if (MessageBox.Show("Really want to Exit?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //DBSessionUser.iUser_Id = -1;
                    DBSessionUser.iUser_Id = -1;
                    DBSessionUser.strUser_Name = "";
                    MdiForm objMaster = (MdiForm)Application.OpenForms["MdiForm"];
                    objMaster.Close();
                    frmLogin objLogin = (frmLogin)Application.OpenForms["frmLogin"];
                    objLogin.Close();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/exitToolStripMenuItem_Click \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void StampingMaster_Click(object sender, EventArgs e)
        {
            try
            {
                frmStampingMaster objSM = (frmStampingMaster)Application.OpenForms["frmStampingMaster"];
                if (objSM != null)
                {
                    objSM.WindowState = FormWindowState.Maximized;
                    objSM.BringToFront();
                }
                else
                {
                    objSM = new frmStampingMaster();
                    objSM.MdiParent = this;
                    objSM.WindowState = FormWindowState.Maximized;
                    objSM.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/State Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AboutBoxGlenmark frm = new AboutBoxGlenmark();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Normal;
            //frm.Show();
            try
            {
                AboutBoxGlenmark objAboutBox = (AboutBoxGlenmark)Application.OpenForms["AboutBoxGlenmark"];
                if (objAboutBox != null)
                {
                    objAboutBox.WindowState = FormWindowState.Normal;
                    objAboutBox.BringToFront();
                }
                else
                {
                    objAboutBox = new AboutBoxGlenmark();
                    objAboutBox.MdiParent = this;
                    objAboutBox.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/About Us Category Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult Response;
            //Response = MessageBox.Show("Are you sure you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //if (Response == DialogResult.Yes)
            //    Application.Exit();

            try
            {
                if (MessageBox.Show("Really want to Exit?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ////DBSessionUser.ID = -1;
                    DBSessionUser.iUser_Id = -1;
                    DBSessionUser.strUser_Name = "";
                    MdiForm objMaster = (MdiForm)Application.OpenForms["MdiForm"];
                    objMaster.Close();
                    frmLogin objLogin = (frmLogin)Application.OpenForms["frmLogin"];
                    objLogin.Close();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/exitToolStripMenuItem_Click \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Order frm = new Order();
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
            try
            {
                frmOrder objOrder = (frmOrder)Application.OpenForms["frmOrder"];
                if (objOrder != null)
                {
                    objOrder.WindowState = FormWindowState.Maximized;
                    objOrder.BringToFront();
                }
                else
                {
                    objOrder = new frmOrder();
                    objOrder.MdiParent = this;
                    objOrder.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Order Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void orderAuthrosisationToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //order_authrosisation frm = new order_authrosisation();
        //    //frm.MdiParent = this;
        //    //frm.WindowState = FormWindowState.Maximized;
        //    //frm.Show();
        //    try
        //    {
        //        order_authrosisation objOrderAuthorisation = (order_authrosisation)Application.OpenForms["order_authrosisation"];
        //        if (objOrderAuthorisation != null)
        //        {
        //            objOrderAuthorisation.WindowState = FormWindowState.Normal;
        //            objOrderAuthorisation.BringToFront();
        //        }
        //        else
        //        {
        //            objOrderAuthorisation = new order_authrosisation();
        //            objOrderAuthorisation.MdiParent = this;
        //            objOrderAuthorisation.Show();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        StreamWriter swLog = File.AppendText(strLogFileName);
        //        string strError = DateTime.Now.ToString() + "\n Main Page/Order Authrosisation Tab \n" + ex.ToString();
        //        swLog.WriteLine(strError);
        //        swLog.WriteLine();
        //        swLog.Close();
        //        MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void CountryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCountryMaster objCountryMaster = (frmCountryMaster)Application.OpenForms["frmCountryMaster"];
                if (objCountryMaster != null)
                {
                    objCountryMaster.WindowState = FormWindowState.Normal;
                    objCountryMaster.BringToFront();
                }
                else
                {
                    objCountryMaster = new frmCountryMaster();
                    objCountryMaster.MdiParent = this;
                    objCountryMaster.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Country Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmStateMaster objSM = (frmStateMaster)Application.OpenForms["frmStateMaster"];
                if (objSM != null)
                {
                    objSM.WindowState = FormWindowState.Normal;
                    objSM.BringToFront();
                }
                else
                {
                    objSM = new frmStateMaster();
                    objSM.MdiParent = this;
                    objSM.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/State Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DSMZSMtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDSMZSMMaster objDSM = (frmDSMZSMMaster)Application.OpenForms["frmDSMZSMMaster"];
                if (objDSM != null)
                {
                    objDSM.WindowState = FormWindowState.Normal;
                    objDSM.BringToFront();
                }
                else
                {
                    objDSM = new frmDSMZSMMaster();
                    objDSM.MdiParent = this;
                    objDSM.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/DSM-ZSM Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmZoneMaster objZoneMaster = (frmZoneMaster)Application.OpenForms["frmZoneMaster"];
                if (objZoneMaster != null)
                {
                    objZoneMaster.WindowState = FormWindowState.Normal;
                    objZoneMaster.BringToFront();
                }
                else
                {
                    objZoneMaster = new frmZoneMaster();
                    objZoneMaster.MdiParent = this;
                    objZoneMaster.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmZoneMaster Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void orderTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmOrderType objZoneMaster = (frmOrderType)Application.OpenForms["frmOrderType"];
                if (objZoneMaster != null)
                {
                    objZoneMaster.WindowState = FormWindowState.Normal;
                    objZoneMaster.BringToFront();
                }
                else
                {
                    objZoneMaster = new frmOrderType();
                    objZoneMaster.MdiParent = this;
                    objZoneMaster.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmZoneMaster Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerType objCustomerType = (frmCustomerType)Application.OpenForms["frmCustomerType"];
                if (objCustomerType != null)
                {
                    objCustomerType.WindowState = FormWindowState.Normal;
                    objCustomerType.BringToFront();
                }
                else
                {
                    objCustomerType = new frmCustomerType();
                    objCustomerType.MdiParent = this;
                    objCustomerType.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerType Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerCategory objCustomerCategory = (frmCustomerCategory)Application.OpenForms["frmCustomerCategory"];
                if (objCustomerCategory != null)
                {
                    objCustomerCategory.WindowState = FormWindowState.Normal;
                    objCustomerCategory.BringToFront();
                }
                else
                {
                    objCustomerCategory = new frmCustomerCategory();
                    objCustomerCategory.MdiParent = this;
                    objCustomerCategory.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerCategory Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IOMLogicMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogicMaster objCustomerType = (frmLogicMaster)Application.OpenForms["frmLogicMaster"];
                if (objCustomerType != null)
                {
                    objCustomerType.WindowState = FormWindowState.Normal;
                    objCustomerType.BringToFront();
                }
                else
                {
                    objCustomerType = new frmLogicMaster();
                    objCustomerType.MdiParent = this;
                    objCustomerType.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerType Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaxTypeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTaxTypeMaster objTaxType = (frmTaxTypeMaster)Application.OpenForms["frmTaxTypeMaster"];
                if (objTaxType != null)
                {
                    objTaxType.WindowState = FormWindowState.Normal;
                    objTaxType.BringToFront();
                }
                else
                {
                    objTaxType = new frmTaxTypeMaster();
                    objTaxType.MdiParent = this;
                    objTaxType.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmTaxTypeMaster \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void taxMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTaxMaster objTaxMaster = (frmTaxMaster)Application.OpenForms["frmTaxMaster"];
                if (objTaxMaster != null)
                {
                    objTaxMaster.WindowState = FormWindowState.Normal;
                    objTaxMaster.BringToFront();
                }
                else
                {
                    objTaxMaster = new frmTaxMaster();
                    objTaxMaster.MdiParent = this;
                    objTaxMaster.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmTaxMaster Master Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importStockToWhareHosueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmStockUpload objfrmStockUpload = (frmStockUpload)Application.OpenForms["frmStockUpload"];
                //objfrmStockUpload.WindowState = FormWindowState.Maximized;
                if (objfrmStockUpload != null)
                {
                    objfrmStockUpload.WindowState = FormWindowState.Maximized;
                    objfrmStockUpload.BringToFront();
                }
                else
                {

                    objfrmStockUpload = new frmStockUpload();
                    objfrmStockUpload.WindowState = FormWindowState.Maximized;
                    objfrmStockUpload.MdiParent = this;
                    objfrmStockUpload.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Stock Upload \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pendingOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPendingOrder objfrmPendingOrder = (frmPendingOrder)Application.OpenForms["frmPendingOrder"];
                //objfrmStockUpload.WindowState = FormWindowState.Maximized;
                if (objfrmPendingOrder != null)
                {
                    objfrmPendingOrder.WindowState = FormWindowState.Maximized;
                    objfrmPendingOrder.BringToFront();
                }
                else
                {

                    objfrmPendingOrder = new frmPendingOrder();
                    objfrmPendingOrder.WindowState = FormWindowState.Maximized;
                    objfrmPendingOrder.MdiParent = this;
                    objfrmPendingOrder.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Pending Order \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importFromSTNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmStnUpload objfrmStockUpload = (frmStnUpload)Application.OpenForms["frmStnUpload"];
                //objfrmStockUpload.WindowState = FormWindowState.Maximized;
                if (objfrmStockUpload != null)
                {
                    objfrmStockUpload.WindowState = FormWindowState.Maximized;
                    objfrmStockUpload.BringToFront();
                }
                else
                {

                    objfrmStockUpload = new frmStnUpload();
                    objfrmStockUpload.WindowState = FormWindowState.Maximized;
                    objfrmStockUpload.MdiParent = this;
                    objfrmStockUpload.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/STN Upload \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //frmStnUpload
        }

        private void importFormSAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSapInvoiceUpload objfrmStockUpload = (frmSapInvoiceUpload)Application.OpenForms["frmSapInvoiceUpload"];

                if (objfrmStockUpload != null)
                {
                    objfrmStockUpload.WindowState = FormWindowState.Maximized;
                    objfrmStockUpload.BringToFront();
                }
                else
                {
                    objfrmStockUpload = new frmSapInvoiceUpload();
                    objfrmStockUpload.WindowState = FormWindowState.Maximized;
                    objfrmStockUpload.MdiParent = this;
                    objfrmStockUpload.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/STN Upload \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importFromIBSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //IBISDirectBilling objfrmIBISBilling = (IBISDirectBilling)Application.OpenForms["frmIBISBilling"];
                frmIBISBillingThrughSTN objfrmIBISBilling = (frmIBISBillingThrughSTN)Application.OpenForms["frmIBISBillingThrughSTN"];

                if (objfrmIBISBilling != null)
                {
                    objfrmIBISBilling.WindowState = FormWindowState.Maximized;
                    objfrmIBISBilling.BringToFront();
                }
                else
                {
                    objfrmIBISBilling = new frmIBISBillingThrughSTN();
                    objfrmIBISBilling.WindowState = FormWindowState.Maximized;
                    objfrmIBISBilling.MdiParent = this;
                    objfrmIBISBilling.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/STN Upload \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readyForBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmReadyForBilling objfrmRFB = (frmReadyForBilling)Application.OpenForms["frmReadyForBilling"];

                if (objfrmRFB != null)
                {
                    objfrmRFB.WindowState = FormWindowState.Maximized;
                    objfrmRFB.BringToFront();
                }
                else
                {
                    objfrmRFB = new frmReadyForBilling();
                    objfrmRFB.WindowState = FormWindowState.Maximized;
                    objfrmRFB.MdiParent = this;
                    objfrmRFB.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmDispatch \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dispatchDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDispatch objfrmDispatch = (frmDispatch)Application.OpenForms["frmDispatch"];

                if (objfrmDispatch != null)
                {
                    objfrmDispatch.WindowState = FormWindowState.Maximized;
                    objfrmDispatch.BringToFront();
                }
                else
                {
                    objfrmDispatch = new frmDispatch();
                    objfrmDispatch.WindowState = FormWindowState.Maximized;
                    objfrmDispatch.MdiParent = this;
                    objfrmDispatch.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmDispatch \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void STNDispatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSTNDispatch objfrmSTNDispatch = (frmSTNDispatch)Application.OpenForms["frmSTNDispatch"];

                if (objfrmSTNDispatch != null)
                {
                    objfrmSTNDispatch.WindowState = FormWindowState.Maximized;
                    objfrmSTNDispatch.BringToFront();
                }
                else
                {
                    objfrmSTNDispatch = new frmSTNDispatch();
                    objfrmSTNDispatch.WindowState = FormWindowState.Maximized;
                    objfrmSTNDispatch.MdiParent = this;
                    objfrmSTNDispatch.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmSTNDispatch \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void userMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserMaster objfrmUserMaster = (frmUserMaster)Application.OpenForms["frmUserMaster"];

                if (objfrmUserMaster != null)
                {
                    objfrmUserMaster.WindowState = FormWindowState.Maximized;
                    objfrmUserMaster.BringToFront();
                }
                else
                {
                    objfrmUserMaster = new frmUserMaster();
                    objfrmUserMaster.WindowState = FormWindowState.Maximized;
                    objfrmUserMaster.MdiParent = this;
                    objfrmUserMaster.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/objfrmUserMaster \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pendingReasonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPendingReasons objfrmPendingOrder = (frmPendingReasons)Application.OpenForms["frmPendingReasons"];

                if (objfrmPendingOrder != null)
                {
                    objfrmPendingOrder.WindowState = FormWindowState.Maximized;
                    objfrmPendingOrder.BringToFront();
                }
                else
                {
                    objfrmPendingOrder = new frmPendingReasons();
                    objfrmPendingOrder.WindowState = FormWindowState.Maximized;
                    objfrmPendingOrder.MdiParent = this;
                    objfrmPendingOrder.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmPendingReasons \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importDirectSAPInvoceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSapInvoiecUploadDir objfrmDirSAPInvoice = (frmSapInvoiecUploadDir)Application.OpenForms["frmSapInvoiecUploadDir"];
                //objfrmStockUpload.WindowState = FormWindowState.Maximized;
                if (objfrmDirSAPInvoice != null)
                {
                    objfrmDirSAPInvoice.WindowState = FormWindowState.Maximized;
                    objfrmDirSAPInvoice.BringToFront();
                }
                else
                {

                    objfrmDirSAPInvoice = new frmSapInvoiecUploadDir();
                    objfrmDirSAPInvoice.WindowState = FormWindowState.Maximized;
                    objfrmDirSAPInvoice.MdiParent = this;
                    objfrmDirSAPInvoice.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmSapInvoiecUploadDir \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importDirectSAPIBSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IBISDirectBilling objfrmIBISBilling = (IBISDirectBilling)Application.OpenForms["IBISDirectBilling"];// direct ibs
                // frmIBISBillingThrughSTN objfrmIBISBilling = (frmIBISBillingThrughSTN)Application.OpenForms["frmIBISBillingThrughSTN"];

                if (objfrmIBISBilling != null)
                {
                    objfrmIBISBilling.WindowState = FormWindowState.Maximized;
                    objfrmIBISBilling.BringToFront();
                }
                else
                {
                    objfrmIBISBilling = new IBISDirectBilling();
                    objfrmIBISBilling.WindowState = FormWindowState.Maximized;
                    objfrmIBISBilling.MdiParent = this;
                    objfrmIBISBilling.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ IBISDirectBilling \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void queryGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmQueryGenerator objfrmQueryGenerator = (frmQueryGenerator)Application.OpenForms["frmQueryGenerator"];

                if (objfrmQueryGenerator != null)
                {
                    objfrmQueryGenerator.WindowState = FormWindowState.Maximized;
                    objfrmQueryGenerator.BringToFront();
                }
                else
                {
                    objfrmQueryGenerator = new frmQueryGenerator();
                    objfrmQueryGenerator.WindowState = FormWindowState.Maximized;
                    objfrmQueryGenerator.MdiParent = this;
                    objfrmQueryGenerator.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ frmQueryGenerator \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void queryExecuterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmQueryExecuter objfrmQueryExecuter = (frmQueryExecuter)Application.OpenForms["frmQueryExecuter"];

                if (objfrmQueryExecuter != null)
                {
                    objfrmQueryExecuter.WindowState = FormWindowState.Maximized;
                    objfrmQueryExecuter.BringToFront();
                }
                else
                {
                    objfrmQueryExecuter = new frmQueryExecuter();
                    objfrmQueryExecuter.WindowState = FormWindowState.Maximized;
                    objfrmQueryExecuter.MdiParent = this;
                    objfrmQueryExecuter.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfrmQueryExecuter \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void queryLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmQueryListing objfrmQueryListing = (frmQueryListing)Application.OpenForms["frmQueryListing"];

                if (objfrmQueryListing != null)
                {
                    objfrmQueryListing.WindowState = FormWindowState.Maximized;
                    objfrmQueryListing.BringToFront();
                }
                else
                {
                    objfrmQueryListing = new frmQueryListing();
                    objfrmQueryListing.WindowState = FormWindowState.Maximized;
                    objfrmQueryListing.MdiParent = this;
                    objfrmQueryListing.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfrmQueryListing \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copyIOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (DBSessionUser.iYearId == "1")
                //{
                //    MessageBox.Show("Copy IOM is not allowed for Year 2012 - 2016.", "Information", MessageBoxButtons.OK);
                //}
                //else
                //{
                    frmCopyOrder objfrmCopyOrder = (frmCopyOrder)Application.OpenForms["frmCopyOrder"];

                    if (objfrmCopyOrder != null)
                    {
                        objfrmCopyOrder.WindowState = FormWindowState.Maximized;
                        objfrmCopyOrder.BringToFront();
                    }
                    else
                    {
                        objfrmCopyOrder = new frmCopyOrder();
                        objfrmCopyOrder.WindowState = FormWindowState.Maximized;
                        objfrmCopyOrder.MdiParent = this;
                        objfrmCopyOrder.Show();
                    }
                //}
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfrmCopyOrder \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void defineReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDefineReport objfrmDefineReport = (frmDefineReport)Application.OpenForms["frmDefineReport"];

                if (objfrmDefineReport != null)
                {
                    objfrmDefineReport.WindowState = FormWindowState.Maximized;
                    objfrmDefineReport.BringToFront();
                }
                else
                {
                    objfrmDefineReport = new frmDefineReport();
                    objfrmDefineReport.WindowState = FormWindowState.Maximized;
                    objfrmDefineReport.MdiParent = this;
                    objfrmDefineReport.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfrmDefineReport \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetBatchAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmResetOMNO objfrmResetOMNO = (frmResetOMNO)Application.OpenForms["frmResetOMNO"];

                if (objfrmResetOMNO != null)
                {
                    objfrmResetOMNO.WindowState = FormWindowState.Maximized;
                    objfrmResetOMNO.BringToFront();
                }
                else
                {
                    objfrmResetOMNO = new frmResetOMNO();
                    objfrmResetOMNO.WindowState = FormWindowState.Maximized;
                    objfrmResetOMNO.MdiParent = this;
                    objfrmResetOMNO.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ frmResetOMNO \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LiasonerMastertoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLiasoner objfrmLiasoner = (frmLiasoner)Application.OpenForms["frmLiasoner"];

                if (objfrmLiasoner != null)
                {
                    objfrmLiasoner.WindowState = FormWindowState.Maximized;
                    objfrmLiasoner.BringToFront();
                }
                else
                {
                    objfrmLiasoner = new frmLiasoner();
                    objfrmLiasoner.WindowState = FormWindowState.Maximized;
                    objfrmLiasoner.MdiParent = this;
                    objfrmLiasoner.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfrmLiasoner \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deletedOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDeletedOrder objfrmDeletedOrder = (frmDeletedOrder)Application.OpenForms["frmDeletedOrder"];

                if (objfrmDeletedOrder != null)
                {
                    objfrmDeletedOrder.WindowState = FormWindowState.Maximized;
                    objfrmDeletedOrder.BringToFront();
                }
                else
                {
                    objfrmDeletedOrder = new frmDeletedOrder();
                    objfrmDeletedOrder.WindowState = FormWindowState.Maximized;
                    objfrmDeletedOrder.MdiParent = this;
                    objfrmDeletedOrder.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfrmLiasoner \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataBaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSQLServerBackup objfrmSQLServerBackup = (frmSQLServerBackup)Application.OpenForms["frmSQLServerBackup"];

                if (objfrmSQLServerBackup != null)
                {
                    objfrmSQLServerBackup.WindowState = FormWindowState.Maximized;
                    objfrmSQLServerBackup.BringToFront();
                }
                else
                {
                    objfrmSQLServerBackup = new frmSQLServerBackup();
                    objfrmSQLServerBackup.WindowState = FormWindowState.Maximized;
                    objfrmSQLServerBackup.MdiParent = this;
                    objfrmSQLServerBackup.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfrmSQLServerBackup \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iOMReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                filterIOMReport objfilterIOMReport = (filterIOMReport)Application.OpenForms["filterIOMReport"];
                if (objfilterIOMReport != null)
                {
                    objfilterIOMReport.WindowState = FormWindowState.Maximized;
                    objfilterIOMReport.BringToFront();
                }
                else
                {
                    objfilterIOMReport = new filterIOMReport();
                    objfilterIOMReport.WindowState = FormWindowState.Maximized;
                    objfilterIOMReport.MdiParent = this;
                    objfilterIOMReport.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfilterIOMReport \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pendingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                filterPendingReport objfilterPendingReport = (filterPendingReport)Application.OpenForms["filterPendingReport"];
                if (objfilterPendingReport != null)
                {
                    objfilterPendingReport.WindowState = FormWindowState.Maximized;
                    objfilterPendingReport.BringToFront();
                }
                else
                {
                    objfilterPendingReport = new filterPendingReport();
                    objfilterPendingReport.WindowState = FormWindowState.Maximized;
                    objfilterPendingReport.MdiParent = this;
                    objfilterPendingReport.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfilterPendingReport \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sTNDispatchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                filterSTNDispatch objfilterSTNDispatch = (filterSTNDispatch)Application.OpenForms["filterSTNDispatch"];
                if (objfilterSTNDispatch != null)
                {
                    objfilterSTNDispatch.WindowState = FormWindowState.Maximized;
                    objfilterSTNDispatch.BringToFront();
                }
                else
                {
                    objfilterSTNDispatch = new filterSTNDispatch();
                    objfilterSTNDispatch.WindowState = FormWindowState.Maximized;
                    objfilterSTNDispatch.MdiParent = this;
                    objfilterSTNDispatch.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfilterSTNDispatch \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void invoiceDetailWithoutProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmInvoiceDetailWithoutProduct objfrmInvDetailWithoutProduct = (frmInvoiceDetailWithoutProduct)Application.OpenForms["frmInvoiceDetailWithoutProduct"];
                if (objfrmInvDetailWithoutProduct != null)
                {
                    objfrmInvDetailWithoutProduct.WindowState = FormWindowState.Maximized;
                    objfrmInvDetailWithoutProduct.BringToFront();
                }
                else
                {
                    objfrmInvDetailWithoutProduct = new frmInvoiceDetailWithoutProduct();
                    objfrmInvDetailWithoutProduct.WindowState = FormWindowState.Maximized;
                    objfrmInvDetailWithoutProduct.MdiParent = this;
                    objfrmInvDetailWithoutProduct.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfrmInvDetailWithoutProduct \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void allSQlMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                filterAllSqlMerge objfilterAllSqlMerge = (filterAllSqlMerge)Application.OpenForms["filterAllSqlMerge"];
                if (objfilterAllSqlMerge != null)
                {
                    objfilterAllSqlMerge.WindowState = FormWindowState.Maximized;
                    objfilterAllSqlMerge.BringToFront();
                }
                else
                {
                    objfilterAllSqlMerge = new filterAllSqlMerge();
                    objfilterAllSqlMerge.WindowState = FormWindowState.Maximized;
                    objfilterAllSqlMerge.MdiParent = this;
                    objfilterAllSqlMerge.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfilterAllSqlMerge \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deletedIOMReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                filterDeletedIOMReport objfilterDeletedIOMReport = (filterDeletedIOMReport)Application.OpenForms["filterDeletedIOMReport"];
                if (objfilterDeletedIOMReport != null)
                {
                    objfilterDeletedIOMReport.WindowState = FormWindowState.Maximized;
                    objfilterDeletedIOMReport.BringToFront();
                }
                else
                {
                    objfilterDeletedIOMReport = new filterDeletedIOMReport();
                    objfilterDeletedIOMReport.WindowState = FormWindowState.Maximized;
                    objfilterDeletedIOMReport.MdiParent = this;
                    objfilterDeletedIOMReport.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objfilterDeletedIOMReport \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void readyForBillingNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReadyForBilling objReadyForBilling = (ReadyForBilling)Application.OpenForms["ReadyForBilling"];
                if (objReadyForBilling != null)
                {
                    objReadyForBilling.WindowState = FormWindowState.Maximized;
                    objReadyForBilling.BringToFront();
                }
                else
                {
                    objReadyForBilling = new ReadyForBilling();
                    objReadyForBilling.WindowState = FormWindowState.Maximized;
                    objReadyForBilling.MdiParent = this;
                    objReadyForBilling.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objReadyForBilling \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MdiForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(DBSessionUser.iYearId);
            if (DBSessionUser.iYearId.Trim() == "1")
                lblSelectedYear.Text = "Year: 2018 - 2019";
            //else
            //{
            //    lblSelectedYear.Text = "Year: 2016 - 2017";
            //    //lblSelectedYear.Text = "Year: " + DateTime.Now.Year + " - " + int.Parse(DateTime.Now.Year.ToString())+1;
            //}
            //lblSelectedYear.Text = "Year: 2016 - 2017";

        }

        private void deliveryCompletedForceFullyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDeliveryCompletedForceFully objDeliveryCompletedForceFully = (frmDeliveryCompletedForceFully)Application.OpenForms["frmDeliveryCompletedForceFully"];
                if (objDeliveryCompletedForceFully != null)
                {
                    objDeliveryCompletedForceFully.WindowState = FormWindowState.Maximized;
                    objDeliveryCompletedForceFully.BringToFront();
                }
                else
                {
                    objDeliveryCompletedForceFully = new frmDeliveryCompletedForceFully();
                    objDeliveryCompletedForceFully.WindowState = FormWindowState.Maximized;
                    objDeliveryCompletedForceFully.MdiParent = this;
                    objDeliveryCompletedForceFully.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objDeliveryCompletedForceFully \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HSNMasterMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmHSNMaster objHSNMaster = (frmHSNMaster)Application.OpenForms["frmHSNMaster"];
                if (objHSNMaster != null)
                {
                    objHSNMaster.WindowState = FormWindowState.Maximized;
                    objHSNMaster.BringToFront();
                }
                else
                {
                    objHSNMaster = new frmHSNMaster();
                    objHSNMaster.WindowState = FormWindowState.Maximized;
                    objHSNMaster.MdiParent = this;
                    objHSNMaster.Show();
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ objHSNMaster \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

