using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using ww_admin;
using ww_lib;
using System.Text.RegularExpressions;

namespace GlanMark
{
    public partial class frmIBISBilling : Form
    {

        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        string FileName = string.Empty;
        string strLogFileName = string.Empty;
        string filepth = string.Empty;        
        int IOMNO=0;
        DateTime DocumentDate;
        int Count = 0;
        string  STNNumber = string.Empty;
        string PartyCode=string.Empty;
        string DocumentNumber=string.Empty;
        string AccountName=string.Empty;
        string ProductName=string.Empty;
        string Batch=string.Empty;
        int BilledQuantity=0;
        int UpdateQuantity=0;
        string MaterialCode=string.Empty;
        string Location=string.Empty;
        string Team=string.Empty;
        string DiscPrice=string.Empty;
        string UED=string.Empty;
        string INVAMT=string.Empty;
        string ExciseDuty=string.Empty;
        string LR_NO=string.Empty;
        string LR_DT=string.Empty;
        string TRANSPORTER_ID=string.Empty;
        string TRANSPORTER_NAME=string.Empty;
        string  NRV=string.Empty;

        static string ConnectionString = ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString();
       // string strLogFileName = "LOG/LogRecord.txt";
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private int id;



        public frmIBISBilling()
        {
            InitializeComponent();
        }

        private void frmIBISBilling_Load(object sender, EventArgs e)
        {
            btnpendingorder.Visible = false;
            LastModifydateofIBISBillingUpdate();
            BindIbIS();
        }


        public void BindIbIS()
        {
            try
            {
                //DataTable dt = new DataTable();
                //SqlConnection Scon = new SqlConnection(ConnectionString);
                //SqlDataAdapter Scom = new SqlDataAdapter("select CountryID, Name, Code, Status from Country", Scon);
                ////Scom.ExecuteNonQuery();
                ////Scom.Fill(ds, "LocationMaster");
                //Scom.Fill(dt);
                //dgvCountryMaster.DataSource = dt;  //ds.Tables["LocationMaster"].DefaultView;
                //Scon.Close();

                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("select * from IBISBillingUpdate order by  1 desc ");

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvIBIS.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/BindIbIS save  \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
             //   MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void LastModifydateofIBISBillingUpdate()
        {
            try
            {

                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                string Currentdate = System.DateTime.Today.ToShortDateString();
                dt = objCommon.GetDataTable("select top(1)* from IBISBillingUpdate order by 1 desc ");
                //  dt = objCommon.GetDataTable("select top(1)* from IBISBillingUpdate  where lastmodify like '"+ Currentdate + "%' order by 1 desc ");
                lbldate.Text = dt.Rows[0]["LastModify"].ToString();

           }
           catch (Exception ex)
           {
                //StreamWriter swLog = File.AppendText(strLogFileName);
                //string strError = DateTime.Now.ToString() + "\n Main Page/ select last modifydate \n" + ex.ToString();
                //swLog.WriteLine(strError);
                //swLog.WriteLine();
                //swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "All Files (*.*)|*.*";     //"Audio File (*.mp3, *.wav)|*.mp3*;*.wav";
            //dlg.Filter =dlg.Filter = "*.xls|*.xlsx"; 
            dlg.Filter = "Excel Files (*.xls)|*.XLS";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtUpload.Text = dlg.FileName;
                FileInfo str = new FileInfo(dlg.FileName);
                string strPath = System.Windows.Forms.Application.StartupPath + "//UploadFile//" + str.Name;

                FileName = str.Name;
                filepth = dlg.FileName;

            }
        }
        public void ReadExcelFileAndInsertrecordInDB()
        {

           
                string ExcelConnString = ConnectionStringForExcel(filepth);
                DataTable TableName = GetOleDBTableNames(ExcelConnString);
                DataTable TableData = GetOleDBTableData(ExcelConnString, FileName, TableName.Rows[0]["Table_Name"].ToString());
                int count = TableData.Rows.Count;
                bool FlagStatus = false;
                for (int ctr = 0; ctr < count; ctr++)
                {
                    
                try
                {

                    if (TableData.Rows[ctr]["IOMNO"].ToString() != "")
                        IOMNO = Convert.ToInt32(TableData.Rows[ctr]["IOMNO"]);

                    STNNumber = Convert.ToString(TableData.Rows[ctr]["STNNumber"]);
                    PartyCode = Convert.ToString(TableData.Rows[ctr]["PartyCode"]);
                    DocumentNumber = Convert.ToString(TableData.Rows[ctr]["DocumentNumber"]);

                    AccountName = Convert.ToString(TableData.Rows[ctr]["AccountName"]);

                    if (TableData.Rows[ctr]["DocumentDate"].ToString() != "")

                        DocumentDate = Convert.ToDateTime(TableData.Rows[ctr]["DocumentDate"], dateformat);

                    if (TableData.Rows[ctr]["BilledQuantity"].ToString() != "")
                        ProductName = Convert.ToString(TableData.Rows[ctr]["ProductName"]);

                    Batch = Convert.ToString(TableData.Rows[ctr]["Batch"]);
                    if (TableData.Rows[ctr]["BilledQuantity"].ToString() != "")
                        BilledQuantity = Convert.ToInt32(TableData.Rows[ctr]["BilledQuantity"]);

                    if (TableData.Rows[ctr]["UpdateQuantity"].ToString() != "")
                        UpdateQuantity = Convert.ToInt32(TableData.Rows[ctr]["UpdateQuantity"]);

                    MaterialCode = Convert.ToString(TableData.Rows[ctr]["MaterialCode"]);

                    
                    if (TableData.Rows[ctr]["Location"].ToString() != "")
                        Location = Convert.ToString(TableData.Rows[ctr]["Location"]);

                    if (TableData.Rows[ctr]["Team"].ToString() != "")
                        Team = Convert.ToString(TableData.Rows[ctr]["Team"]);

                    if (TableData.Rows[ctr]["UED"].ToString() != "")
                        UED = Convert.ToString(TableData.Rows[ctr]["UED"]);

                    if (TableData.Rows[ctr]["INVAMT"].ToString() != "")
                        INVAMT = Convert.ToString(TableData.Rows[ctr]["INVAMT"]);

                    if (TableData.Rows[ctr]["ExciseDuty"].ToString() != "")
                        ExciseDuty = Convert.ToString(TableData.Rows[ctr]["ExciseDuty"]);

                    if (TableData.Rows[ctr]["LR_NO"].ToString() != "")
                        LR_NO = Convert.ToString(TableData.Rows[ctr]["LR_NO"]);

                    if (TableData.Rows[ctr]["LR_DT"].ToString() != "")
                        LR_DT = Convert.ToString(TableData.Rows[ctr]["LR_DT"]);

                    if (TableData.Rows[ctr]["TRANSPORTER_ID"].ToString() != "")
                        TRANSPORTER_ID = Convert.ToString(TableData.Rows[ctr]["TRANSPORTER_ID"]);

                    if (TableData.Rows[ctr]["TRANSPORTER_NAME"].ToString() != "")
                        TRANSPORTER_NAME = Convert.ToString(TableData.Rows[ctr]["TRANSPORTER_NAME"]);

                    if (TableData.Rows[ctr]["NRV"].ToString() != "")
                        NRV = Convert.ToString(TableData.Rows[ctr]["NRV"]);





                }
                catch (Exception ex)
                {
                    FlagStatus = true;
                    string strError = ex.ToString();
                    MessageBox.Show(strError);
                    break;


                }
                
                    //if (Convert.ToString(IOMNO) != "" | PartyCode != "" | MaterialCode != "" | Batch != "")
                    //{
                    //    FlagStatus = true;
                    //    MessageBox.Show("Invalid IOMNO or SoldToParty or MaterialCode  or Batch & Upload Unsuccessful");
                    //    break;
                    //}

                    if (!IsItNumber(Convert.ToString(IOMNO)))
                    {
                        FlagStatus = true;
                        MessageBox.Show("IOMNO" + "Invaild Datatype & Upload Unsuccessful");

                    }
                    //else if (!IsItNumber(Convert.ToString(UpdateQuantity)))
                    //{
                    //    MessageBox.Show("UpdateQuantity" + "Invaild Datatype & Upload Unsuccessful");
                    //}
                    else
                    {
                        InsertRecordDB();

                    }

                }
                if (!FlagStatus)
                {
                    MessageBox.Show("Record Inserted Successfully !");
                    btnpendingorder.Visible = true;
                    BindIbIS();
                }
           

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

             bool bstatus = true;
            bstatus = validateForm();
            if (bstatus == true)
            {
                if ((Convert.ToInt32(CheckTodayRecord())) > 0)
                {
                    var result = MessageBox.Show("Do you want ReUpload Today Records ? ", "IBISBilling", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DeleteTodayRecord();
                        ReadExcelFileAndInsertrecordInDB();
                    }
                }
                else
                {
                    ReadExcelFileAndInsertrecordInDB();
                }


            }

        }


        public string CheckTodayRecord()
        {
            string recordCount = string.Empty;
            try
            {

                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select COUNT(*) as NumberOfRecord from IBISBillingUpdate where DATEPART(YYYY, LastModify) = DATEPART(YYYY, GETDATE()) and DATEPART(MM, LastModify) = DATEPART(MM, GETDATE()) and DATEPART(dd, LastModify) = DATEPART(dd, GETDATE()) ");
                recordCount = Convert.ToString(dt.Rows[0]["NumberOfRecord"]);

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "IBISBilling / reload today Record modifydate IBISBillingUpdate \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return recordCount;

        }



        public string DeleteTodayRecord()
        {
            string recordCount = string.Empty;
            try
            {

                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                string querystring = "delete from IBISBillingUpdate where ID in (select id from IBISBillingUpdate where DATEPART(YYYY, LastModify) = DATEPART(YYYY, GETDATE()) and DATEPART(MM, LastModify) = DATEPART(MM, GETDATE()) and DATEPART(dd, LastModify) = DATEPART(dd, GETDATE()))";
                SqlCommand DeleteobjCommand = new SqlCommand(querystring);
                objCommon.ExecuteNewDMLQuery(DeleteobjCommand);
                //recordCount = Convert.ToString(dt.Rows[0]["NumberOfRecord"]);

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/   reload today Record modifydate IBISBillingUpdate \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return recordCount;

        }

        public bool IsItNumber(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            return !isnumber.IsMatch(inputvalue);
        }


        public void InsertRecordDB()
        {
            try
            {
                CommonFunction objCF = new CommonFunction();

                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());

                objConnection.Open();
                objCommand = new SqlCommand("insert into IBISBillingUpdate (IOMNO,STNNumber,PartyCode,DocumentNumber,AccountName,ProductName,Batch,BilledQuantity,UpdateQuantity,MaterialCode,LastModify,Location,Team,DiscPrice,UED,INVAMT,ExciseDuty,LR_NO,LR_DT,TRANSPORTER_ID,TRANSPORTER_NAME,NRV) values (@IOMNO,@STNNumber,@PartyCode,@DocumentNumber,@AccountName,@ProductName,@Batch,@BilledQuantity,@UpdateQuantity,@MaterialCode, getdate(),@Location,@Team,@DiscPrice,@UED,@INVAMT,@ExciseDuty,@LR_NO,@LR_DT,@TRANSPORTER_ID,@TRANSPORTER_NAME,@NRV)", objConnection);
                objCommand.Parameters.AddWithValue("@IOMNO", IOMNO);
                objCommand.Parameters.AddWithValue("@STNNumber", STNNumber);
                objCommand.Parameters.AddWithValue("@PartyCode", PartyCode);
                objCommand.Parameters.AddWithValue("@DocumentNumber", DocumentNumber);
                objCommand.Parameters.AddWithValue("@AccountName", AccountName);
                objCommand.Parameters.AddWithValue("@ProductName", ProductName);
                objCommand.Parameters.AddWithValue("@Batch", Batch);
                objCommand.Parameters.AddWithValue("@BilledQuantity", BilledQuantity);
                objCommand.Parameters.AddWithValue("@UpdateQuantity", UpdateQuantity);
                objCommand.Parameters.AddWithValue("@MaterialCode", MaterialCode);                               
                objCommand.Parameters.AddWithValue("@Location", Location);
                objCommand.Parameters.AddWithValue("@Team", Team);
                objCommand.Parameters.AddWithValue("@DiscPrice", DiscPrice);
                objCommand.Parameters.AddWithValue("@UED", UED);
                objCommand.Parameters.AddWithValue("@INVAMT", INVAMT);
                objCommand.Parameters.AddWithValue("@ExciseDuty", ExciseDuty);
                objCommand.Parameters.AddWithValue("@LR_NO", LR_NO);
                objCommand.Parameters.AddWithValue("@LR_DT", LR_DT);
                objCommand.Parameters.AddWithValue("@TRANSPORTER_ID", TRANSPORTER_ID);
                objCommand.Parameters.AddWithValue("@TRANSPORTER_NAME", TRANSPORTER_NAME);
                objCommand.Parameters.AddWithValue("@NRV", NRV);

                Result objResult = objCF.ExecuteNewDMLQuery(objCommand);
                if (objResult.bStatus)
                {
                    Count = Count + 1;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }


        public static string ConnectionStringForExcel(string filepath)
        {
            //string ExcelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
            //string ExcelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Income.xlsx;Extended Properties=""Excel 8.0;HDR=YES;""";
            //string ExcelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filepath + "; Extended Properties=\" Excel 8.0;HDR=YES;\"";
            //Below this is working Connection String
            string ExcelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"";
            //string ExcelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";

            return ExcelConnectionString;
        }

        public static DataTable GetOleDBTableNames(string ConnString)
        {
                OleDbConnection conn = new OleDbConnection();
                DataTable dtTables = default(DataTable);
            
            try
            {
                //try
                //{
                conn.ConnectionString = ConnString;
                conn.Open();
                dtTables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                //}
                //catch (OleDbException eX_SQL)
                //{
                //    throw new Exception(eX_SQL.Message);
                //}
                //catch (Exception ex)
                //{
                //    throw new Exception(ex.Message);
                //}
                //finally
                //{
                //    conn.Close();
                //    conn.Dispose();
                //}
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invaild File :-" + ex.ToString());
                
            
            }
            return dtTables;
        }

        public static DataTable GetOleDBTableData(string ConnectionString, string FileName, string TableName)
        {
            OleDbConnection conn = new OleDbConnection();
            DataSet ds = new DataSet();
            DataTable dtData = default(DataTable);
            OleDbDataAdapter da = default(OleDbDataAdapter);
            string strSQL = null;

            try
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();

                strSQL = "SELECT  * FROM [" + TableName + "]";

                da = new OleDbDataAdapter(strSQL, conn);

                da.TableMappings.Add("Table", FileName);
                da.Fill(ds);


                dtData = ds.Tables[0];
            }
            catch (OleDbException eX_SQL)
            {
                throw new Exception(eX_SQL.Message);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return dtData;
        }

        private bool validateForm()
        {
            errorProvideribis.Clear();
            bool isValid = true;
            if (txtUpload.Text == "")
            {
                errorProvideribis.SetError(txtUpload, "Please Select Excel File !");
                isValid = false;
            }
            return isValid;
        }

        private void btnpendingorder_Click(object sender, EventArgs e)
        {

        }

        private void btnpendingorder_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you Sure Want To Do Integrity Test ? ", "IBISBilling", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                btnUpload.Visible = false;

                IBISIBISIntegrityTest("IBISBillingUpdate");
                BindIbIS();
            }
            
            
            
           
        }

        public bool IsCheckRStaus()
        {
            bool Flag = false;
            CommonFunction objCF = new CommonFunction();
            objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());

            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objConnection;

            objcmd.CommandText = "select * from IBISBillingUpdate where DATEPART(YYYY, LastModify) = DATEPART(YYYY, GETDATE()) and DATEPART(MM, LastModify) = DATEPART(MM, GETDATE()) and DATEPART(dd, LastModify) = DATEPART(dd, GETDATE())  and RStatus='Invaild IOMNo' or RStatus='Invaild Product Code' or RStatus='Invaild Batch Number'";
            objcmd.CommandType = CommandType.Text;
            objConnection.Open();
            SqlDataReader objReader = objcmd.ExecuteReader();
            while (objReader.Read())
            {
                Flag = true;
            }

            objConnection.Close();

            return Flag;
        }
        public void IBISIBISIntegrityTest(string Tablename)
        {
            CommonFunction objCF = new CommonFunction();
            objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());

            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objConnection;

           // objcmd.CommandText = "IBISBillingUpdate_Integrity";
            objcmd.CommandText = "IBISBillingUpdate_Integrity_Test_ThrughSTN";
            
            objcmd.CommandType = CommandType.StoredProcedure;
            string lastmodifydatetime2 = DateTime.Parse(uploaddate.Text, dateformat).ToString();
            objcmd.Parameters.AddWithValue("@lastmodifydatetime", lastmodifydatetime2);

            //objcmd.Parameters.AddWithValue("@Tablename", Tablename);

            objConnection.Open();
            objcmd.ExecuteNonQuery();
            objConnection.Close();


        }

        private void BtnUpdateorderitem_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdateorderitem_Click_1(object sender, EventArgs e)
        {


            var result = MessageBox.Show("Are you Sure Want To Do Update Order Item ? ", "OrderItem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (IsCheckRStaus() != true)
                {

                    CommonFunction objCF = new CommonFunction();
                    objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());

                    SqlCommand objcmd = new SqlCommand();
                    objcmd.Connection = objConnection;

                    objcmd.CommandText = "UpdateOrderItemByIBIS";
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objConnection.Open();
                    //objcmd.ExecuteNonQuery();
                    objConnection.Close();
                }
                else
                {
                    MessageBox.Show("Integrity Test Fail !");
                }


            }

        }

        

 


    }
}
