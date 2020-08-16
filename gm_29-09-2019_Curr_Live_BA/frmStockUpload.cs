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

namespace GlenMark
{
    public partial class frmStockUpload : Form
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB"); 
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;

        static string ConnectionString = ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString();
        string strLogFileName = "LOG/LogRecord.txt";
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private int id;


        DateTime StockUpdate;
        int ID = 0;
        int Count = 0;
        string WareHouseCode = string.Empty;
        string StorageCode = string.Empty;
        string ProductCode = string.Empty;
        string Description = string.Empty;
        string BatchNo = string.Empty;
        int AllocatedQuantity = 0;
        int Unrestricted = 0;
        DateTime ExpiryDate = DateTime.Now;
        DateTime ProductDate = DateTime.Now;
        string ProdDate = string.Empty;
        string expDate = string.Empty;
        int SelfLifePercentage = 0;
        int Month = 0;
        DateTime LastDayOfMonth = DateTime.Now;
        DateTime LastModify;
        string AlisCode = string.Empty;
        string FileName = string.Empty;
        string filepth = string.Empty;

        public frmStockUpload()
        {
            InitializeComponent();
        }

        

        public string CheckTodayRecord()
        {
            string recordCount = string.Empty;
            try
            {

                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select COUNT(*) as NumberOfRecord from StockUpload where DATEPART(YYYY, LastModify) = DATEPART(YYYY, GETDATE()) and DATEPART(MM, LastModify) = DATEPART(MM, GETDATE()) and DATEPART(dd, LastModify) = DATEPART(dd, GETDATE()) ");
                recordCount = Convert.ToString(dt.Rows[0]["NumberOfRecord"]);

            }
            catch (Exception ex)
            {
                //StreamWriter swLog = File.AppendText(strLogFileName);
                //string strError = DateTime.Now.ToString() + "STNUpload / reload today Record modifydate STNUpload \n" + ex.ToString();
                //swLog.WriteLine(strError);
                //swLog.WriteLine();
                //swLog.Close();
               // MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return recordCount;

        }

        public void ReadExcelFileAndInsertrecordInDB()
        {
            bool bstatus = true;
            bstatus = validateForm();
            bool FlagStatus = false;
            if (bstatus == true)
            {

                string ExcelConnString = ConnectionStringForExcel(filepth);
                DataTable TableName = GetOleDBTableNames(ExcelConnString);
                DataTable TableData = GetOleDBTableData(ExcelConnString, FileName, TableName.Rows[0]["Table_Name"].ToString());
                int count = TableData.Rows.Count;
                TruncateTable();
                for (int ctr = 0; ctr < count; ctr++)
                {

                    //try
                   // {
                        //Name = Convert.ToString(TableData.Rows[ctr]["Name"]);
                        WareHouseCode = Convert.ToString(TableData.Rows[ctr]["WareHouseCode"]);
                        StorageCode = Convert.ToString(TableData.Rows[ctr]["StorageCode"]);
                        ProductCode = Convert.ToString(TableData.Rows[ctr]["ProductCode"]);
                        Description = Convert.ToString(TableData.Rows[ctr]["Description"]);
                        BatchNo = Convert.ToString(TableData.Rows[ctr]["BatchNo"]).Replace("'", "").Trim();

                       
                        if (TableData.Rows[ctr]["AllocatedQuantity"].ToString() != "")
                            AllocatedQuantity = Convert.ToInt32(TableData.Rows[ctr]["AllocatedQuantity"]);

                        if (TableData.Rows[ctr]["Unrestricted"].ToString() != "")
                            Unrestricted = Convert.ToInt32(TableData.Rows[ctr]["Unrestricted"]);

                        if (TableData.Rows[ctr]["ExpiryDate"].ToString() != "")
                            ExpiryDate = Convert.ToDateTime(TableData.Rows[ctr]["ExpiryDate"], dateformat); //DateTime.Parse(TableData.Rows[ctr]["ExpiryDate"]).ToString("dd/mm/yyyy");
                        
                        if (TableData.Rows[ctr]["ProductDate"].ToString() != "")
                            ProductDate = Convert.ToDateTime(TableData.Rows[ctr]["ProductDate"], dateformat);

                        if (TableData.Rows[ctr]["SelfLifePercentage"].ToString() != "")
                            SelfLifePercentage = Convert.ToInt32(TableData.Rows[ctr]["SelfLifePercentage"]);

                        if (TableData.Rows[ctr]["Month"].ToString() != "")
                            Month = Convert.ToInt32(TableData.Rows[ctr]["Month"]);

                        if (TableData.Rows[ctr]["LastDayOfMonth"].ToString() != "")
                            LastDayOfMonth = Convert.ToDateTime(TableData.Rows[ctr]["LastDayOfMonth"], dateformat);

                        //int daysInMarch2012 = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);  //DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month,1);
                        //int monthDays = DateTime.DaysInMonth(2012, 3);
                        DateTime dt = DateTime.Now;
                        DateTime TotDate = LastDayOfMonthFromDateTime(dt);
                        AlisCode=GetAlisCode(Convert.ToString(ProductCode));
                        int mDays = TotDate.Day;

                        float tDays = (ExpiryDate - LastDayOfMonthFromDateTime(dt)).Days;
                        float bDays = (ExpiryDate - ProductDate).Days;
                        float result = (tDays / bDays) * 100;

                  
                        SelfLifePercentage = int.Parse(Math.Round(result, 0).ToString());

                        float monDays = (ExpiryDate - LastDayOfMonthFromDateTime(dt)).Days;
                        float mresult = (monDays / TotDate.Day);
                        Month = int.Parse(Math.Round(mresult, 0).ToString());
                    //}


                  //  catch (Exception ex)
                    //{

                        //FlagStatus = true;
                        //string strError = ex.ToString();
                        //MessageBox.Show(strError);
                        //break;

                    //}


                    InsertRecordDB();

                }
                if (!FlagStatus)
                {
                    MessageBox.Show("Record Inserted Successfully !");
                    BindStockupload();
                }

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
                    var result = MessageBox.Show("Do you want ReUpload Today Records ? ", "StockUpload", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //DeleteTodayRecord();
                        ReadExcelFileAndInsertrecordInDB();
                    }
                }
                else
                {
                    ReadExcelFileAndInsertrecordInDB();
                }
            }
        }

        public DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files (*.*)|*.*";     
           // dlg.Filter = "Excel Files (*.xls)|*.XLS";

           // dlg.Filter = "Excel Files (*.xls)|*.XLS|*.xlsx|.XLSX";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtUpload.Text = dlg.FileName;
                FileInfo str = new FileInfo(dlg.FileName);
                string strPath = System.Windows.Forms.Application.StartupPath + "//UploadFile//" + str.Name;

                FileName = str.Name;
                filepth = dlg.FileName;

                //if (!File.Exists(strPath))
                //{
                //    File.Copy(txtUpload.Text, strPath); //"D:\\WinSearch\\WinSearch" + F:\\gm_17_03_2012\\gm\\bin\\Release
                //    txtUpload.Text = str.Name;
                //    MessageBox.Show("File Upload Successfully", "Information Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    var result = MessageBox.Show("Do you want Overwrite the existing file", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (result == DialogResult.Yes)
                //    {
                //        File.Copy(txtUpload.Text, strPath, true);
                //        txtUpload.Text = str.Name;
                //        MessageBox.Show("File Upload Successfully", "Information Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
            }
        }

        public void InsertRecordDB()
        {
            try
            {
                CommonFunction objCF = new CommonFunction();
                //objConnection = new SqlConnection("Data Source=SHANKAR-A395FB0\\SQLEXPRESS_SATYA;Initial Catalog=gm;Integrated Security=True");                
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                
                objConnection.Open();
                objCommand = new SqlCommand("insert into StockUpload (WareHouseCode, StorageCode, ProductCode,AlisCode, ProductDate, Description, BatchNo, AllocatedQuantity, Unrestricted, ExpiryDate, SelfLifePercentage, Month, LastDayOfMonth, LastModify) values (@WareHouseCode, @StorageCode, @ProductCode,@AlisCode, @ProductDate, @Description, @BatchNo, @AllocatedQuantity, @Unrestricted, @ExpiryDate, @SelfLifePercentage, @Month, @LastDayOfMonth, getdate())", objConnection);
                objCommand.Parameters.AddWithValue("@WareHouseCode", WareHouseCode);
                objCommand.Parameters.AddWithValue("@StorageCode", StorageCode);
                objCommand.Parameters.AddWithValue("@ProductCode", ProductCode);
                objCommand.Parameters.AddWithValue("@AlisCode", AlisCode);
                
                objCommand.Parameters.AddWithValue("@ProductDate", ProductDate);
                objCommand.Parameters.AddWithValue("@Description", Description);
                objCommand.Parameters.AddWithValue("@BatchNo", BatchNo);
                objCommand.Parameters.AddWithValue("@AllocatedQuantity", AllocatedQuantity);
                objCommand.Parameters.AddWithValue("@Unrestricted", Unrestricted);
                objCommand.Parameters.AddWithValue("@ExpiryDate", ExpiryDate);
                objCommand.Parameters.AddWithValue("@SelfLifePercentage", SelfLifePercentage);
                objCommand.Parameters.AddWithValue("@Month", Month);
                objCommand.Parameters.AddWithValue("@LastDayOfMonth", LastDayOfMonth);

                Result objResult = objCF.ExecuteNewDMLQuery(objCommand);
                if (objResult.bStatus)
                {
                    Count = Count + 1;
                }
                lblRecordCount.Text = Count.ToString();
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

        public void TruncateTable()
        {
            try
            {
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                
                objConnection.Open();
                objCommand = new SqlCommand("Truncate Table StockUpload", objConnection);
                objCommand.ExecuteNonQuery();
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

            //MessageBox.Show("Table Empty  and Please Wait DATA Updation Process Started");
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

        private void dgvstnupload_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public string GetAlisCode(string MaterialCode)
        {
            string AlisCode = "0";
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from StockUpload where ProductCode="+MaterialCode);

                DataTable dt = objC.GetDataTable("select  AlisCode from ProductMaster where Material = '" + MaterialCode.Trim() + "'");

                 AlisCode = Convert.ToString(dt.Rows[0]["AlisCode"]);
                //recordCount = Convert.ToString(dt.Rows[0]["NumberOfRecord"]);

            }
            catch (Exception ee)
            { 
            
            }
                return AlisCode;
            


        }

        public void BindStockupload()
        {
            try
            {
               

                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("select * from StockUpload");

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvstockupload.DataSource = bindingSource;
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

        private void frmStockUpload_Load(object sender, EventArgs e)
        {
            BindStockupload();
        }

        private bool validateForm()
        {
            errorStockUpload.Clear();
            bool isValid = true;
            if (txtUpload.Text == "")
            {
                errorStockUpload.SetError(txtUpload, "Please Select Excel File !");
                isValid = false;
            }
            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

    }
}
