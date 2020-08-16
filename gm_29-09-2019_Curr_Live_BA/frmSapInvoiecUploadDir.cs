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
using System.Globalization;

namespace GlanMark
{
    public partial class frmSapInvoiecUploadDir : Form
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        private string _Strdateformat = "MM/dd/yyyy";
        private string _dateformat = "MM/dd/yyyy";
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        string FileName = string.Empty;
        // string strLogFileName=string.Empty;
        string filepth = string.Empty;
        int ID = 0;
        int Count = 0;

        //int IOMNO = 0;
        long IOMNO_STN = 0;
        string STNNumber = string.Empty;
        string BillingDocument = string.Empty;
        string SoldToParty = string.Empty;
        string Name = string.Empty;
        string Plnt = string.Empty;
        DateTime BillingDate;
        string MaterialCode = string.Empty;
        string Description = string.Empty;
        int BilledQuantity = 0;
        int UpdateQuantity = 0;
        string Batch = string.Empty;
        string Priority = string.Empty;
        string ActualBilledQuantity = string.Empty;
        string Subtotal1 = string.Empty;
        string Subtotal2 = string.Empty;
        string Subtotal3 = string.Empty;
        string Subtotal4 = string.Empty;
        string Subtotal5 = string.Empty;
        string Total = string.Empty;
        string ZST1 = string.Empty;
        string ZEXDD = string.Empty;
        string ZCESS = string.Empty;
        string ZMR1 = string.Empty;
        string ZSTK = string.Empty;
        string ZEXD = string.Empty;
        string Mfgdate = string.Empty;
        string ExpDate = string.Empty;
        string NRV = string.Empty;
        string AlisCode = string.Empty;

        static string ConnectionString = ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString();
        string strLogFileName = "LOG/LogRecord.txt";
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private int id;



        public frmSapInvoiecUploadDir()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "*.xls|*.xlsx";    //"Audio File (*.mp3, *.wav)|*.mp3*;*.wav";       "All Files (*.*)|*.*";
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
            CommonFunction objComm = new CommonFunction();
            string ExcelConnString = ConnectionStringForExcel(filepth);
            DataTable TableName = GetOleDBTableNames(ExcelConnString);
            DataTable TableData = GetOleDBTableData(ExcelConnString, FileName, TableName.Rows[0]["Table_Name"].ToString());
            int count = TableData.Rows.Count;
            bool FlagStatus = false;
            for (int ctr = 0; ctr < count; ctr++)
            {

                try
                {
                    if (TableData.Rows[ctr]["IOMNo_STN"].ToString() != "")
                        IOMNO_STN = long.Parse(TableData.Rows[ctr]["IOMNo_STN"].ToString());
                    //IOMNO = Convert.ToInt32(TableData.Rows[ctr]["IOMNo_STN"]);

                    STNNumber = "0";// Convert.ToString(TableData.Rows[ctr]["STNNumber"]);
                    BillingDocument = Convert.ToString(TableData.Rows[ctr]["BillingDocument"]);

                    SoldToParty = Convert.ToString(TableData.Rows[ctr]["SoldToParty"]);
                    Name = Convert.ToString(TableData.Rows[ctr]["Name"]);
                    Plnt = Convert.ToString(TableData.Rows[ctr]["Plnt"]);

                    if (TableData.Rows[ctr]["BillingDate"].ToString() != "")
                        BillingDate = Convert.ToDateTime(TableData.Rows[ctr]["BillingDate"].ToString().Trim(), dateformat);

                    MaterialCode = Convert.ToString(TableData.Rows[ctr]["MaterialCode"]);

                    //Add Alise Code depeding upon MaterialCode
                    DataTable dtAlisCode = objComm.GetDataTable("select top 1 Aliscode from ProductMaster where Material = '" + MaterialCode + "'");
                    if (dtAlisCode.Rows.Count > 0)
                    {
                        AlisCode = dtAlisCode.Rows[0]["Aliscode"].ToString();
                    }
                    else
                    {
                        AlisCode = "0";
                    }

                    Description = Convert.ToString(TableData.Rows[ctr]["Description"]);
                    if (TableData.Rows[ctr]["BilledQuantity"].ToString() != "")
                        BilledQuantity = Convert.ToInt32(TableData.Rows[ctr]["BilledQuantity"]);
                    if (TableData.Rows[ctr]["UpdateQuantity"].ToString() != "")
                        UpdateQuantity = Convert.ToInt32(TableData.Rows[ctr]["UpdateQuantity"]);
                    Batch = Convert.ToString(TableData.Rows[ctr]["Batch"]);

                    if (TableData.Rows[ctr]["Priority"].ToString() != "")
                        Priority = Convert.ToString(TableData.Rows[ctr]["Priority"]);

                    if (TableData.Rows[ctr]["ActualBilledQuantity"].ToString() != "")
                        ActualBilledQuantity = Convert.ToString(TableData.Rows[ctr]["ActualBilledQuantity"]);

                    if (TableData.Rows[ctr]["Subtotal1"].ToString() != "")
                        Subtotal1 = Convert.ToString(TableData.Rows[ctr]["Subtotal1"]);

                    if (TableData.Rows[ctr]["Subtotal2"].ToString() != "")
                        Subtotal2 = Convert.ToString(TableData.Rows[ctr]["Subtotal2"]);

                    if (TableData.Rows[ctr]["Subtotal3"].ToString() != "")
                        Subtotal3 = Convert.ToString(TableData.Rows[ctr]["Subtotal3"]);


                    if (TableData.Rows[ctr]["Subtotal4"].ToString() != "")
                        Subtotal4 = Convert.ToString(TableData.Rows[ctr]["Subtotal4"]);

                    if (TableData.Rows[ctr]["Subtotal5"].ToString() != "")
                        Subtotal5 = Convert.ToString(TableData.Rows[ctr]["Subtotal5"]);

                    if (TableData.Rows[ctr]["Total"].ToString() != "")
                        Total = Convert.ToString(TableData.Rows[ctr]["Total"]);

                    if (TableData.Rows[ctr]["ZST1"].ToString() != "")
                        ZST1 = Convert.ToString(TableData.Rows[ctr]["ZST1"]);

                    if (TableData.Rows[ctr]["ZEXDD"].ToString() != "")
                        ZEXDD = Convert.ToString(TableData.Rows[ctr]["ZEXDD"]);

                    if (TableData.Rows[ctr]["ZCESS"].ToString() != "")
                        ZCESS = Convert.ToString(TableData.Rows[ctr]["ZCESS"]);


                    if (TableData.Rows[ctr]["ZMR1"].ToString() != "")
                        ZMR1 = Convert.ToString(TableData.Rows[ctr]["ZMR1"]);

                    if (TableData.Rows[ctr]["ZSTK"].ToString() != "")
                        ZSTK = Convert.ToString(TableData.Rows[ctr]["ZSTK"]).Trim();

                    if (TableData.Rows[ctr]["ZEXD"].ToString() != "")
                        ZEXD = Convert.ToString(TableData.Rows[ctr]["ZEXD"]);

                    if (TableData.Rows[ctr]["Mfgdate"].ToString() != "")
                        Mfgdate = Convert.ToString(TableData.Rows[ctr]["Mfgdate"]);

                    if (TableData.Rows[ctr]["ExpDate"].ToString() != "")
                        ExpDate = Convert.ToString(TableData.Rows[ctr]["ExpDate"]);

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
                //if (Convert.ToString(IOMNO) == "" | SoldToParty == "" | MaterialCode == "" | Batch == "")
                //{
                //    FlagStatus = true;
                //    MessageBox.Show("Invalid IOMNO or SoldToParty or MaterialCode  or Batch & Upload Unsuccessful");
                //    break;
                //}

                if (!IsItNumber(Convert.ToString(IOMNO_STN)))
                {
                    FlagStatus = true;
                    MessageBox.Show(IOMNO_STN + "Invaild Datatype & Upload Unsuccessful");
                    break;

                }

                else
                {
                    InsertRecordDB();
                }
            }
            if (!FlagStatus)
            {
                MessageBox.Show("Record Inserted Successfully !");
                btNItegrityTest.Visible = true;


            }
            BindSAPInvoice();


        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bstatus = true;
            bstatus = validateForm();
            if (bstatus == true)
            {
                // if ((Convert.ToInt32(CheckTodayRecord())) > 0)

                if ((Convert.ToInt32(CheckTodayRecord(uploaddate.Text))) > 0)
                {
                    var result = MessageBox.Show("Do you want ReUpload Today Records ? ", "Dir SapInvoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // DeleteTodayRecord();
                        ReadExcelFileAndInsertrecordInDB();
                        //btnSave.Visible = false;
                    }
                }
                else
                {
                    ReadExcelFileAndInsertrecordInDB();
                }
            }
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

                string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                {
                    objCommand = new SqlCommand(@"insert into DirSAPInvoiceUpload (IOMNO,STNNumber,BillingDocument,SoldToParty,Name,Plnt,BillingDate,
                MaterialCode,Description,BilledQuantity,UpdateQuantity,Batch,Priority,ActualBilledQuantity,Subtotal1,Subtotal2,Subtotal3,Subtotal4,
                Subtotal5,Total,ZST1,ZEXDD,ZCESS,ZMR1,ZSTK,ZEXD,Mfgdate,ExpDate,NRV,LastModify,AlisCode) values (@IOMNO,@STNNumber,@BillingDocument,@SoldToParty,
                    @Name,@Plnt,@BillingDate,@MaterialCode,@Description,@BilledQuantity,@UpdateQuantity,@Batch,@Priority,@ActualBilledQuantity,@Subtotal1,
                    @Subtotal2,@Subtotal3,@Subtotal4,@Subtotal5,@Total,@ZST1,@ZEXDD,@ZCESS,@ZMR1,@ZSTK,@ZEXD,@Mfgdate,@ExpDate,@NRV, 
                     '" + DateTime.Parse(uploaddate.Text, dateformat) + "', @AlisCode)", objConnection);
                }
                else
                {
                    objCommand = new SqlCommand(@"insert into DirSAPInvoiceUpload (IOMNO,STNNumber,BillingDocument,SoldToParty,Name,Plnt,BillingDate,
                MaterialCode,Description,BilledQuantity,UpdateQuantity,Batch,Priority,ActualBilledQuantity,Subtotal1,Subtotal2,Subtotal3,Subtotal4,
                Subtotal5,Total,ZST1,ZEXDD,ZCESS,ZMR1,ZSTK,ZEXD,Mfgdate,ExpDate,NRV,LastModify,AlisCode) values (@IOMNO,@STNNumber,@BillingDocument,@SoldToParty,
                    @Name,@Plnt,@BillingDate,@MaterialCode,@Description,@BilledQuantity,@UpdateQuantity,@Batch,@Priority,@ActualBilledQuantity,@Subtotal1,
                    @Subtotal2,@Subtotal3,@Subtotal4,@Subtotal5,@Total,@ZST1,@ZEXDD,@ZCESS,@ZMR1,@ZSTK,@ZEXD,@Mfgdate,@ExpDate,@NRV, 
                     '" + DateTime.Parse(uploaddate.Text).ToString(_Strdateformat) + "', @AlisCode)", objConnection);
                }

                objCommand.Parameters.AddWithValue("@IOMNO", IOMNO_STN);
                objCommand.Parameters.AddWithValue("@STNNumber", STNNumber);
                objCommand.Parameters.AddWithValue("@BillingDocument", BillingDocument);
                objCommand.Parameters.AddWithValue("@SoldToParty", SoldToParty);
                objCommand.Parameters.AddWithValue("@Name", Name);
                objCommand.Parameters.AddWithValue("@Plnt", Plnt);

                if (BillingDate.ToString() != "")
                {
                    //objCommand.Parameters.AddWithValue("@BillingDate", BillingDate);
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        objCommand.Parameters.AddWithValue("@BillingDate", DateTime.Parse(BillingDate.ToString(), dateformat));
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue("@BillingDate", DateTime.Parse(BillingDate.ToString()).ToString(_dateformat));
                    }
                }


                objCommand.Parameters.AddWithValue("@MaterialCode", MaterialCode);
                objCommand.Parameters.AddWithValue("@Description", Description);
                objCommand.Parameters.AddWithValue("@BilledQuantity", BilledQuantity);
                objCommand.Parameters.AddWithValue("@UpdateQuantity", UpdateQuantity);
                objCommand.Parameters.AddWithValue("@Batch", Batch);


                objCommand.Parameters.AddWithValue("@Priority", Priority);
                objCommand.Parameters.AddWithValue("@ActualBilledQuantity", ActualBilledQuantity);
                objCommand.Parameters.AddWithValue("@Subtotal1", Subtotal1);
                objCommand.Parameters.AddWithValue("@Subtotal2", Subtotal2);
                objCommand.Parameters.AddWithValue("@Subtotal3", Subtotal3);
                objCommand.Parameters.AddWithValue("@Subtotal4", Subtotal4);
                objCommand.Parameters.AddWithValue("@Subtotal5", Subtotal5);
                objCommand.Parameters.AddWithValue("@Total", Total);
                objCommand.Parameters.AddWithValue("@ZST1", ZST1);
                objCommand.Parameters.AddWithValue("@ZEXDD", ZEXDD);
                objCommand.Parameters.AddWithValue("@ZCESS", ZCESS);

                objCommand.Parameters.AddWithValue("@ZMR1", ZMR1);
                objCommand.Parameters.AddWithValue("@ZSTK", ZSTK);
                objCommand.Parameters.AddWithValue("@ZEXD", ZEXD);

                if (Mfgdate != "")
                {
                    //objCommand.Parameters.AddWithValue("@Mfgdate", Mfgdate);
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        objCommand.Parameters.AddWithValue("@Mfgdate", DateTime.Parse(Mfgdate, dateformat));
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue("@Mfgdate", DateTime.Parse(Mfgdate).ToString(_dateformat));
                    }
                }

                if (ExpDate != "")
                {
                    //objCommand.Parameters.AddWithValue("@ExpDate", ExpDate);
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        objCommand.Parameters.AddWithValue("@ExpDate", DateTime.Parse(ExpDate, dateformat));
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue("@ExpDate", DateTime.Parse(ExpDate).ToString(_dateformat));
                    }
                }

                objCommand.Parameters.AddWithValue("@NRV", NRV);
                objCommand.Parameters.AddWithValue("@AlisCode", AlisCode);

                // Result objResult = objCF.ExecuteNewDMLQuery(objCommand);

                // string lastmodifydatetime = DateTime.Parse(uploaddate.Text, dateformat).ToString();

                string lastmodifydatetime = DateTime.Parse(uploaddate.Text, dateformat).ToString();

                if (lastmodifydatetime != "")
                {
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        lastmodifydatetime = DateTime.Parse(lastmodifydatetime, dateformat).ToString();
                    }
                    else
                    {
                        lastmodifydatetime = DateTime.Parse(lastmodifydatetime).ToString(_dateformat).ToString();
                    }
                }



                Result objResult = null;
                DataTable dt = null;
                SqlConnection objConn = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                objConn.Open();
                string Query1 = @"select * from DirSAPInvoiceUpload where (CONVERT(varchar, DATEPART(YYYY, LastModify) + DATEPART(MM, LastModify) + DATEPART(dd, LastModify))+CONVERT(varchar,IOMNO) + MaterialCode +Batch) = (CONVERT(varchar, DATEPART(YYYY, '" + lastmodifydatetime + "') + DATEPART(MM, '" + lastmodifydatetime + "') + DATEPART(dd, '" + lastmodifydatetime + "'))+ CONVERT(varchar," + IOMNO_STN + ") + '" + MaterialCode + "' +'" + Batch + "')";
                dt = objCF.GetDataTable(Query1);

                if (dt.Rows.Count > 0)
                {
                    if (rtDuplicateRecord.Text != "")
                        rtDuplicateRecord.Text += ", " + IOMNO_STN.ToString();
                    else
                        rtDuplicateRecord.Text = IOMNO_STN.ToString();
                }
                else
                {
                    objResult = objCF.ExecuteNewDMLQuery(objCommand);
                    if (objResult.bStatus)
                    {
                        Count = Count + 1;
                    }
                }

                lblRecordCount.Text = Count.ToString();

                //if (objResult.bStatus)
                //{
                //  Count = Count + 1;
                //}
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

        private bool validateForm()
        {
            errorSAPInvoiceUpload.Clear();
            bool isValid = true;
            if (txtUpload.Text == "")
            {
                errorSAPInvoiceUpload.SetError(txtUpload, "Please Select Excel File !");
                isValid = false;
            }
            return isValid;
        }


        public static DataTable GetOleDBTableNames(string ConnString)
        {
            OleDbConnection conn = new OleDbConnection();
            DataTable dtTables = default(DataTable);
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

        private void button1_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Are you Sure Want To Do Integrity Test ? ", "DirSapInvoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                btnUpload.Visible = false;

                SAPInvoiceUploadIntegrityTest("DirSAP_Integrity");
                BindSAPInvoice();
                BtnUpdateorderitem.Visible = true;
            }


        }
        public void SAPInvoiceUploadIntegrityTest(string Tablename)
        {
            CommonFunction objCF = new CommonFunction();
            objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());

            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objConnection;

            objcmd.CommandText = "DirSAP_Integrity";
            objcmd.CommandType = CommandType.StoredProcedure;


            //string lastmodifydatetime2 = DateTime.Parse(uploaddate.Text, dateformat).ToString();

            string lastmodifydatetime2 = DateTime.Parse(uploaddate.Text, dateformat).ToString();
            string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            if (lastmodifydatetime2 != "")
            {
                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                {
                    lastmodifydatetime2 = DateTime.Parse(lastmodifydatetime2, dateformat).ToString();
                }
                else
                {
                    lastmodifydatetime2 = DateTime.Parse(lastmodifydatetime2).ToString(_dateformat).ToString();
                }
            }
            objcmd.Parameters.AddWithValue("@lastmodifydatetime", lastmodifydatetime2);

            //objcmd.Parameters.AddWithValue("@Tablename", Tablename);

            objConnection.Open();
            objcmd.ExecuteNonQuery();
            objConnection.Close();


        }

        private void frmSapInvoiceUpload_Load(object sender, EventArgs e)
        {
            btNItegrityTest.Visible = false;
            BtnUpdateorderitem.Visible = false;
            LastModifydateofSAPInvoiceUpload();
            BindSAPInvoice();
            dgvSapinvoice.ReadOnly = true;
            lblalert.Visible = false;
            btnBatchAllocation.Visible = false;
        }




        public void BindSAPInvoice()
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from DirSAPInvoiceUpload order by 1 desc ");
                string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                {
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select * from DirSAPInvoiceUpload where DATEPART(dd,LastModify) = DATEPART(dd,'" + DateTime.Parse(uploaddate.Text, dateformat) + "') and DATEPART(MM,LastModify) = DATEPART(MM,'" + DateTime.Parse(uploaddate.Text, dateformat) + "') and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'" + DateTime.Parse(uploaddate.Text, dateformat) + "') ");
                }
                else
                {
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select * from DirSAPInvoiceUpload where DATEPART(dd,LastModify) = DATEPART(dd,'" + DateTime.Parse(uploaddate.Text).ToString(_Strdateformat) + "') and DATEPART(MM,LastModify) = DATEPART(MM,'" + DateTime.Parse(uploaddate.Text).ToString(_Strdateformat) + "') and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'" + DateTime.Parse(uploaddate.Text).ToString(_Strdateformat) + "') ");
                }

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvSapinvoice.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/BindSAPInvoice \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LastModifydateofSAPInvoiceUpload()
        {
            try
            {

                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                //dt = objCommon.GetDataTable("select top(1)* from SAPInvoiceUpload where DATEPART(YYYY, LastModify) = DATEPART(YYYY, GETDATE()) and DATEPART(MM, LastModify) = DATEPART(MM, GETDATE())and DATEPART(dd, LastModify) = DATEPART(dd, GETDATE())  order by 1 desc ");
                dt = objCommon.GetDataTable("select top(1)* from DirSAPInvoiceUpload  order by 1 desc ");
                lbldate.Text = dt.Rows[0]["LastModify"].ToString();

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ select last modifydate SapInvoice \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        public string CheckTodayRecord(string dtDate)
        {
            string recordCount = string.Empty;
            string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            try
            {

                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                string dtSelectedDate = string.Empty;
                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                {
                    dtSelectedDate = DateTime.Parse(dtDate, dateformat).ToString();
                }
                else
                {
                    dtSelectedDate = DateTime.Parse(dtDate).ToString(_Strdateformat);
                }

                //dt = objCommon.GetDataTable("select COUNT(*) as NumberOfRecord from SAPInvoiceUpload where DATEPART(YYYY, LastModify) = DATEPART(YYYY, GETDATE()) and DATEPART(MM, LastModify) = DATEPART(MM, GETDATE()) and DATEPART(dd, LastModify) = DATEPART(dd, GETDATE()) ");
                dt = objCommon.GetDataTable("select COUNT(*) as NumberOfRecord from DirSAPInvoiceUpload where DATEPART(YYYY, LastModify) = DATEPART(YYYY, '" + dtSelectedDate + "') and DATEPART(MM, LastModify) = DATEPART(MM, '" + dtSelectedDate + "') and DATEPART(dd, LastModify) = DATEPART(dd, '" + dtSelectedDate + "') ");

                recordCount = Convert.ToString(dt.Rows[0]["NumberOfRecord"]);

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ select today Record modifydate SapInvoice \n" + ex.ToString();
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

                string querystring = "delete from DirSAPInvoiceUpload where ID in (select id from DirSAPInvoiceUpload where DATEPART(YYYY, LastModify) = DATEPART(YYYY, GETDATE()) and DATEPART(MM, LastModify) = DATEPART(MM, GETDATE()) and DATEPART(dd, LastModify) = DATEPART(dd, GETDATE()))";
                SqlCommand DeleteobjCommand = new SqlCommand(querystring);
                objCommon.ExecuteNewDMLQuery(DeleteobjCommand);
                //recordCount = Convert.ToString(dt.Rows[0]["NumberOfRecord"]);

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/ select today Record modifydate dir SapInvoice \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return recordCount;

        }





        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void BtnUpdateorderitem_Click(object sender, EventArgs e)
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

                    objcmd.CommandText = "UpdateOrderItemByDIRSAP";
                    objcmd.CommandType = CommandType.StoredProcedure;

                    //string lastmodifydatetime2 = DateTime.Parse(uploaddate.Text, dateformat).ToString();

                    string lastmodifydatetime2 = DateTime.Parse(uploaddate.Text, dateformat).ToString();
                    string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    if (lastmodifydatetime2 != "")
                    {
                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            lastmodifydatetime2 = DateTime.Parse(lastmodifydatetime2, dateformat).ToString();
                        }
                        else
                        {
                            lastmodifydatetime2 = DateTime.Parse(lastmodifydatetime2).ToString(_dateformat).ToString();
                        }
                    }
                    objcmd.Parameters.AddWithValue("@lastmodifydatetime", lastmodifydatetime2);

                    objConnection.Open();
                    objcmd.ExecuteNonQuery();
                    objConnection.Close();
                    BindSAPInvoice();
                    MessageBox.Show("Record Updated Succesfully !");
                    //btnSave.Visible = false;
                    btnCancel.Visible = false;
                    btNItegrityTest.Visible = false;
                    BtnUpdateorderitem.Visible = false;
                    lblalert.Visible = true;
                    //lblalert.Text = " You can not upload record today ";
                    btnBatchAllocation.Visible = true;
                }
                else
                {
                    MessageBox.Show("Integrity Test Fail !");
                }
            }

        }

        public bool IsCheckRStaus()
        {
            bool Flag = false;
            CommonFunction objCF = new CommonFunction();
            objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());

            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objConnection;

            string lastmodifydatetime2 = string.Empty;
            string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
            {
                lastmodifydatetime2 = DateTime.Parse(uploaddate.Text, dateformat).ToString();
            }
            else
            {
                lastmodifydatetime2 = DateTime.Parse(uploaddate.Text).ToString(_Strdateformat);
            }

            objcmd.CommandText = "select * from DirSAPInvoiceUpload where DATEPART(YYYY, LastModify) = DATEPART(YYYY, '" + lastmodifydatetime2 + "') and DATEPART(MM, LastModify) = DATEPART(MM, '" + lastmodifydatetime2 + "') and DATEPART(dd, LastModify) = DATEPART(dd, '" + lastmodifydatetime2 + "')  and RStatus!='OK'";

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            objCF.fn_ExportToExcel("select *  from DirSAPInvoiceUpload where DATEPART(YYYY, LastModify) = DATEPART(YYYY, GETDATE()) and DATEPART(MM, LastModify) = DATEPART(MM, GETDATE()) and DATEPART(dd, LastModify) = DATEPART(dd, GETDATE()) ", "SAPInvoiceUpload", "SAPInvoiceUpload");
            //objCF.fn_ExportToExcel("select *  from SAPInvoiceUpload", "SAPInvoiceUpload", "SAPInvoiceUpload");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {

                var result = MessageBox.Show("Are you Sure Want To Delete Invaild Record   Date   " + uploaddate.Text + "?", "Dir SapInvoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    //string dtSelDate = DateTime.Parse(uploaddate.Text, dateformat).ToString();


                    string lastmodifydatetime2 = DateTime.Parse(uploaddate.Text, dateformat).ToString();


                    string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        lastmodifydatetime2 = DateTime.Parse(uploaddate.Text, dateformat).ToString();
                    }
                    else
                    {
                        lastmodifydatetime2 = DateTime.Parse(uploaddate.Text).ToString(_Strdateformat);
                    }

                    objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                    objConnection.Open();
                    string Query1 = "delete from DirSAPInvoiceUpload where RStatus != 'OK' and (CONVERT(varchar, DATEPART(YYYY, LastModify) + DATEPART(MM, LastModify) + DATEPART(dd, LastModify))) = (CONVERT(varchar, DATEPART(YYYY, @lastmodifydatetime) + DATEPART(MM, @lastmodifydatetime) + DATEPART(dd, @lastmodifydatetime)))";
                    objCommand = new SqlCommand(Query1, objConnection);
                    objCommand.Parameters.AddWithValue("@lastmodifydatetime", lastmodifydatetime2);

                    if (objCommand.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Invalid Record Deleted Sucessfully");
                        BindSAPInvoice();
                    }
                    else
                    {
                        MessageBox.Show("Error Occured! Or No Record Found !");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSubmitDate_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from DirSAPInvoiceUpload order by 1 desc ");
                string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                {
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select * from DirSAPInvoiceUpload where DATEPART(dd,LastModify) = DATEPART(dd,'" + DateTime.Parse(dtpGridBind.Text, dateformat) + "') and DATEPART(MM,LastModify) = DATEPART(MM,'" + DateTime.Parse(dtpGridBind.Text, dateformat) + "') and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'" + DateTime.Parse(dtpGridBind.Text, dateformat) + "') ");
                }
                else
                {
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select * from DirSAPInvoiceUpload where DATEPART(dd,LastModify) = DATEPART(dd,'" + DateTime.Parse(dtpGridBind.Text).ToString(_Strdateformat) + "') and DATEPART(MM,LastModify) = DATEPART(MM,'" + DateTime.Parse(dtpGridBind.Text).ToString(_Strdateformat) + "') and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'" + DateTime.Parse(dtpGridBind.Text).ToString(_Strdateformat) + "') ");
                }

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvSapinvoice.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/btnReset_Click button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("select * from DirSAPInvoiceUpload order by 1 desc ");

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvSapinvoice.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/btnReset_Click button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Automated Batch Allocation
        protected DataTable getPendingList()
        {
            DataTable dataTable1 = new DataTable();
            StringBuilder strQuery1 = new StringBuilder();

            string query = string.Empty;
            string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
            {
                //09-06-2013 
                //strQuery1.Append("select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity  , sd.ScheduleID ,ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark ,oh.OrderAuthoDate as    OrderAuthDate, ot.BillingRate,ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue,oh.DocFile1,oh.DispThrough, oh.MRP from OrderHeader as oh ,OrderItem as ot,ScheduleDetail as sd ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo and oh.Schedule='YES' and oh.Authorised=1 and sd.DeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text, dateformat).ToString() + "' and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=0 ");
                //strQuery1.Append(" Union all ");
                //strQuery1.Append("select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity  , 0 as ScheduleID ,ot.Reason,ot.Remark as PendingRemark ,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate,ot.BillingRate,ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue,oh.DocFile1 ,oh.DispThrough, oh.MRP  from OrderHeader as oh ,OrderItem as ot ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.Schedule='No'   and oh.Authorised=1 and oh.OrderDeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text, dateformat).ToString() + "' and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=0 ");
                strQuery1.Append("select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode , ot.ProductName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity, oh.DispThrough, oh.MRP, sm.Name as StampingName, ot.BillingRate, ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue, ot.AlisCode, sd.ScheduleID, ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark ,oh.OrderAuthoDate as    OrderAuthDate, oh.DocFile1 from OrderHeader as oh ,OrderItem as ot, ScheduleDetail as sd ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo and oh.Schedule='YES' and oh.Authorised=1 and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");
                strQuery1.Append("Union all ");
                strQuery1.Append("select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode, ot.ProductName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity, oh.DispThrough, oh.MRP, sm.Name as StampingName, ot.BillingRate, ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue, ot.AlisCode, 0 as ScheduleID, ot.Reason,ot.Remark as PendingRemark ,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate, oh.DocFile1 from OrderHeader as oh ,OrderItem as ot , StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.Schedule='No'  and oh.Authorised=1 and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");

            }
            else
            {
                //strQuery1.Append("select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity  , sd.ScheduleID ,ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark ,oh.OrderAuthoDate as    OrderAuthDate, ot.BillingRate,ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue,oh.DocFile1,oh.DispThrough, oh.MRP from OrderHeader as oh ,OrderItem as ot,ScheduleDetail as sd ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo and oh.Schedule='YES' and oh.Authorised=1 and sd.DeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat) + "' and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=0 ");
                //strQuery1.Append(" Union all ");
                //strQuery1.Append("select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity  , 0 as ScheduleID ,ot.Reason,ot.Remark as PendingRemark ,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate,ot.BillingRate,ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue,oh.DocFile1 ,oh.DispThrough, oh.MRP  from OrderHeader as oh ,OrderItem as ot ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.Schedule='No'   and oh.Authorised=1 and oh.OrderDeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat) + "' and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=0 ");
                strQuery1.Append("select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode , ot.ProductName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity, oh.DispThrough, oh.MRP, sm.Name as StampingName, ot.BillingRate, ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue, ot.AlisCode, sd.ScheduleID, ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark ,oh.OrderAuthoDate as    OrderAuthDate, oh.DocFile1 from OrderHeader as oh ,OrderItem as ot, ScheduleDetail as sd ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo and oh.Schedule='YES' and oh.Authorised=1 and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");
                strQuery1.Append("Union all ");
                strQuery1.Append("select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode, ot.ProductName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity, oh.DispThrough, oh.MRP, sm.Name as StampingName, ot.BillingRate, ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue, ot.AlisCode, 0 as ScheduleID, ot.Reason,ot.Remark as PendingRemark ,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate, oh.DocFile1 from OrderHeader as oh ,OrderItem as ot , StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.Schedule='No'  and oh.Authorised=1 and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");

            }

            dataTable1 = objC.GetDataTable(strQuery1.ToString());

            return dataTable1;
        }

        //Automated Batch Allocation
        private void btnBatchAllocation_Click(object sender, EventArgs e)
        {
            int iflag = 0;
            try
            {
                var result = MessageBox.Show("Are you sure want to do Batch Allocation? ", "DirSapInvoice - BatchAllocation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    for (int i = 0; i < dgvSapinvoice.Rows.Count - 1; i++)
                    {
                        CommonFunction objCF = new CommonFunction();
                        objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());

                        SqlCommand objCommand = new SqlCommand();
                        objCommand.Connection = objConnection;

                        objCommand.CommandText = "spBatchUpdate_Auto";
                        objCommand.CommandType = CommandType.StoredProcedure;

                        objCommand.Parameters.AddWithValue("@IOMNO", Convert.ToInt32(dgvSapinvoice.Rows[i].Cells["IOMNO"].Value.ToString()));
                        objCommand.Parameters.AddWithValue("@ProductCode", dgvSapinvoice.Rows[i].Cells["MaterialCode"].Value.ToString());
                        objCommand.Parameters.AddWithValue("@WareHouseCode", dgvSapinvoice.Rows[i].Cells["PLNT"].Value.ToString());
                        objCommand.Parameters.AddWithValue("@BatchNo", dgvSapinvoice.Rows[i].Cells["Batch"].Value.ToString());
                        objCommand.Parameters.AddWithValue("@QTY", Decimal.ToInt32(decimal.Parse(dgvSapinvoice.Rows[i].Cells["Billedquantity"].Value.ToString())));
                        if (dgvSapinvoice.Rows[i].Cells["MfgDate"].Value != null)
                        {
                            if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                            {
                                objCommand.Parameters.AddWithValue("@MFGDate", DateTime.Parse(dgvSapinvoice.Rows[i].Cells["MfgDate"].Value.ToString(), dateformat));
                                //DateTime.Parse(uploaddate.Text, dateformat)
                            }
                            else
                            {
                                objCommand.Parameters.AddWithValue("@MFGDate", DateTime.Parse(dgvSapinvoice.Rows[i].Cells["MfgDate"].Value.ToString()).ToString(_Strdateformat));
                                //DateTime.Parse(uploaddate.Text).ToString(_Strdateformat)
                            }
                        }
                        else
                            objCommand.Parameters.AddWithValue("@MFGDate", DateTime.Now);

                        if (dgvSapinvoice.Rows[i].Cells["ExpDate"].Value != null)
                        {
                            if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                            {
                                objCommand.Parameters.AddWithValue("@ExpiryDate", DateTime.Parse(dgvSapinvoice.Rows[i].Cells["ExpDate"].Value.ToString(), dateformat));
                            }
                            else
                            {
                                objCommand.Parameters.AddWithValue("@ExpiryDate", DateTime.Parse(dgvSapinvoice.Rows[i].Cells["ExpDate"].Value.ToString()).ToString(_Strdateformat));
                            }
                        }
                        else
                            objCommand.Parameters.AddWithValue("@ExpiryDate", DateTime.Now);

                        objCommand.Parameters.AddWithValue("@AlisCode", dgvSapinvoice.Rows[i].Cells["AlisCode"].Value.ToString()); //getAlisCode(row.Cells["MaterialCode"].Value.ToString()));


                        objConnection.Open();

                        objCommand.ExecuteNonQuery();

                    }

                    if (MessageBox.Show("Batch Allocation Done Successfully") == DialogResult.OK)
                    {
                        //this.Close();
                        //if (iflag == 0)
                        btnBatchAllocation.Visible = false;
                    }

                    //                foreach (DataGridViewRow row in dgvSapinvoice.Rows)
                    //                {
                    //                    if (row.Cells["IOMNO"].Value != null && row.Cells["IOMNO"].Value != "")
                    //                    {
                    //                        CommonFunction objCF = new CommonFunction();
                    //                        objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                    //                        objConnection.Open();

                    //                        string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    //                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    //                        {
                    //                            objCommand = new SqlCommand(@"Insert into BatchAllocation (IOMNO,ProductCode,WareHouseCode,BatchNo,QTY,MFGDate,ExpiryDate,
                    //                        SelfLifePercentage,AlisCode,StorageCode,LastModify) VALUES (@IOMNO,@ProductCode,@WareHouseCode,@BatchNo,@QTY,@MFGDate,
                    //                        @ExpiryDate,@SelfLifePercentage,@AlisCode,@StorageCode,GETDATE())", objConnection);

                    //                            //'" + DateTime.Parse(uploaddate.Text, dateformat) + "', @AlisCode)", objConnection);
                    //                        }
                    //                        else
                    //                        {
                    //                            objCommand = new SqlCommand(@"Insert into BatchAllocation (IOMNO,ProductCode,WareHouseCode,BatchNo,QTY,MFGDate,ExpiryDate,
                    //                        SelfLifePercentage,AlisCode,StorageCode,LastModify) VALUES (@IOMNO,@ProductCode,@WareHouseCode,@BatchNo,@QTY,@MFGDate,
                    //                        @ExpiryDate,@SelfLifePercentage,@AlisCode,@StorageCode,GETDATE())", objConnection);
                    //                            //'" + DateTime.Parse(uploaddate.Text).ToString(_Strdateformat) + "', @AlisCode)", objConnection);
                    //                        }

                    //                        objCommand.Parameters.AddWithValue("@IOMNO", row.Cells["IOMNO"].Value.ToString());
                    //                        objCommand.Parameters.AddWithValue("@ProductCode", row.Cells["MaterialCode"].Value.ToString());
                    //                        objCommand.Parameters.AddWithValue("@WareHouseCode", row.Cells["PLNT"].Value.ToString());
                    //                        objCommand.Parameters.AddWithValue("@BatchNo", row.Cells["Batch"].Value.ToString());
                    //                        objCommand.Parameters.AddWithValue("@QTY", Decimal.ToInt32(decimal.Parse(row.Cells["Billedquantity"].Value.ToString())));

                    //                        if (row.Cells["MfgDate"].Value != null)
                    //                        {
                    //                            if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    //                            {
                    //                                objCommand.Parameters.AddWithValue("@MFGDate", DateTime.Parse(row.Cells["MfgDate"].Value.ToString(), dateformat));
                    //                                //DateTime.Parse(uploaddate.Text, dateformat)
                    //                            }
                    //                            else
                    //                            {
                    //                                objCommand.Parameters.AddWithValue("@MFGDate", DateTime.Parse(row.Cells["MfgDate"].Value.ToString()).ToString(_Strdateformat));
                    //                                //DateTime.Parse(uploaddate.Text).ToString(_Strdateformat)
                    //                            }
                    //                        }
                    //                        else
                    //                            objCommand.Parameters.AddWithValue("@MFGDate", DateTime.Now);

                    //                        if (row.Cells["ExpDate"].Value != null)
                    //                        {
                    //                            if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    //                            {
                    //                                objCommand.Parameters.AddWithValue("@ExpiryDate", DateTime.Parse(row.Cells["ExpDate"].Value.ToString(), dateformat));
                    //                            }
                    //                            else
                    //                            {
                    //                                objCommand.Parameters.AddWithValue("@ExpiryDate", DateTime.Parse(row.Cells["ExpDate"].Value.ToString()).ToString(_Strdateformat));
                    //                            }
                    //                        }
                    //                        else
                    //                            objCommand.Parameters.AddWithValue("@ExpiryDate", DateTime.Now);

                    //                        objCommand.Parameters.AddWithValue("@SelfLifePercentage", "0");
                    //                        objCommand.Parameters.AddWithValue("@AlisCode", row.Cells["AlisCode"].Value.ToString()); //getAlisCode(row.Cells["MaterialCode"].Value.ToString()));
                    //                        objCommand.Parameters.AddWithValue("@StorageCode", "FG01");

                    //                        Result objResult = null;
                    //                        SqlConnection objConn = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                    //                        objConn.Open();

                    //                        objResult = objCF.ExecuteNewDMLQuery(objCommand);
                    //                        if (objResult.bStatus)
                    //                        {
                    //                            Count = Count + 1;
                    //                        }

                    //                        //iflag = 1;
                    //                    }
                    //                }

                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/btnBatchAllocation_Click button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getAlisCode(string Productcode)
        {
            string strAlisCode = "";
            DataTable dt = new DataTable();
            CommonFunction objCommon = new CommonFunction();
            if (Productcode.ToString() != "")
            {
                dt = objC.GetDataTable("select top 1 * from ProductMaster where Material = '" + Productcode + "'");
                if (dt.Rows.Count > 0)
                {
                    return strAlisCode = dt.Rows[0]["AlisCode"].ToString();
                }
            }
            return strAlisCode;
        }

    }
}