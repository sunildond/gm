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

namespace GlenMark
{
    public partial class frmStnUpload : Form
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        private string _Strdateformat = "MM/dd/yyyy";
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _dateformat = "MM/dd/yyyy";
        static string ConnectionString = ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString();
        string strLogFileName = "LOG/LogRecord.txt";
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private int id;
        
        //DateTime StockUpdate;
        int ID = 0;
        int Count = 0;

        int IOMNO = 0;
        long IOMNO_STN = 0;
        string Delivery = string.Empty;
        DateTime DeliveryDate;
        string PartyCode = string.Empty;
        string MaterialCode = string.Empty;
        string Description = string.Empty;
        string SLoc = string.Empty;
        string Batch = string.Empty;
        decimal DeliveryQuantity;
        decimal UpdateQty;
        string Plnt = string.Empty;
        string BillingDocument = string.Empty;
        string Priority = string.Empty;
        string ActualDeliveryQuantity = string.Empty;
        string ActualGoodsMovement = string.Empty;
        string MfgDate = string.Empty;
        string ExpDate = string.Empty;
        string Netvalue = string.Empty;
        string ZMR1UnitPrice = string.Empty;
        string ZSTKUnitPrice = string.Empty;
        string ZEXDUnitPrice = string.Empty;
        string ZCESUnitPrice = string.Empty;
        string RateMaster = string.Empty;
        string AlisCode = string.Empty;

        DateTime LastModify;

        string FileName = string.Empty;
        string filepth = string.Empty;

        public frmStnUpload()
        {
            InitializeComponent();
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
                    //Name = Convert.ToString(TableData.Rows[ctr]["Name"]);
                    if (TableData.Rows[ctr]["IOMNO_STN"].ToString() != "")
                        IOMNO_STN = long.Parse(TableData.Rows[ctr]["IOMNO_STN"].ToString().Trim());
                        //IOMNO = Convert.ToInt32(TableData.Rows[ctr]["IOMNO_STN"].ToString().Trim());

                    Delivery = Convert.ToString(TableData.Rows[ctr]["Delivery"]);

                    if (TableData.Rows[ctr]["DeliveryDate"].ToString() != "")
                        DeliveryDate = DateTime.Parse(TableData.Rows[ctr]["DeliveryDate"].ToString().Trim());

                    PartyCode = Convert.ToString(TableData.Rows[ctr]["PartyCode"]);
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
                    SLoc = Convert.ToString(TableData.Rows[ctr]["SLoc"]);
                    Batch = Convert.ToString(TableData.Rows[ctr]["Batch"]).Replace("'", "").Trim();    //remove ' while reading excel file

                    if (TableData.Rows[ctr]["DeliveryQuantity"].ToString() != "")
                        DeliveryQuantity = Convert.ToDecimal(TableData.Rows[ctr]["DeliveryQuantity"]);

                    //if (TableData.Rows[ctr]["UpdateQuantity"].ToString() != "")
                    //    UpdateQty = Convert.ToDecimal(TableData.Rows[ctr]["UpdateQuantity"]);
                    UpdateQty = 0;


                    Plnt = Convert.ToString(TableData.Rows[ctr]["Plant"]);



                    if (TableData.Rows[ctr]["BillingDocument"].ToString() != "")
                        BillingDocument = Convert.ToString(TableData.Rows[ctr]["BillingDocument"]);

                    //if (TableData.Rows[ctr]["Priority"].ToString() != "")
                    //    Priority = Convert.ToString(TableData.Rows[ctr]["Priority"]);
                    Priority = "";
                    //if (TableData.Rows[ctr]["ActualDeliveryQuantity"].ToString() != "")
                    //    ActualDeliveryQuantity = Convert.ToString(TableData.Rows[ctr]["ActualDeliveryQuantity"]);
                    ActualDeliveryQuantity = "";

                    if (TableData.Rows[ctr]["ActualGoodsMovement"].ToString() != "")
                        ActualGoodsMovement = Convert.ToString(TableData.Rows[ctr]["ActualGoodsMovement"]).Trim();

                    if (TableData.Rows[ctr]["MfgDate"].ToString() != "")
                        MfgDate = Convert.ToString(TableData.Rows[ctr]["MfgDate"]);

                    if (TableData.Rows[ctr]["ExpDate"].ToString() != "")
                        ExpDate = Convert.ToString(TableData.Rows[ctr]["ExpDate"]);


                    if (TableData.Rows[ctr]["Netvalue"].ToString() != "")
                        Netvalue = Convert.ToString(TableData.Rows[ctr]["Netvalue"]);

                    if (TableData.Rows[ctr]["ExpDate"].ToString() != "")
                        ExpDate = Convert.ToString(TableData.Rows[ctr]["ExpDate"]).Trim();


                    if (TableData.Rows[ctr]["MfgDate"].ToString() != "")
                        MfgDate = Convert.ToString(TableData.Rows[ctr]["MfgDate"]).Trim();

                    if (TableData.Rows[ctr]["ZMR1UnitPrice"].ToString() != "")
                        ZMR1UnitPrice = Convert.ToString(TableData.Rows[ctr]["ZMR1UnitPrice"]);

                    if (TableData.Rows[ctr]["ZSTKUnitPrice"].ToString() != "")
                        ZSTKUnitPrice = Convert.ToString(TableData.Rows[ctr]["ZSTKUnitPrice"]);

                    if (TableData.Rows[ctr]["ZEXDUnitPrice"].ToString() != "")
                        ZEXDUnitPrice = Convert.ToString(TableData.Rows[ctr]["ZEXDUnitPrice"]);


                    if (TableData.Rows[ctr]["ZCESUnitPrice"].ToString() != "")
                        ZCESUnitPrice = Convert.ToString(TableData.Rows[ctr]["ZCESUnitPrice"]);

                    //if (TableData.Rows[ctr]["RateMaster"].ToString() != "")
                    //    RateMaster = Convert.ToString(TableData.Rows[ctr]["RateMaster"]);
                    RateMaster = "";


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
                //    MessageBox.Show("Invalid IOMNO or PartyCode or MaterialCode  or Batch & Upload Unsuccessful");
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
                btnpendingorder.Visible = true;
            }
            BindStn();

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bstatus = true;
            bstatus = validateForm();
            if (bstatus == true)
            {
                if ((Convert.ToInt32(CheckTodayRecord(uploaddate.Text))) > 0)
                {
                    var result = MessageBox.Show("Do you want ReUpload Today Records ? ", "STNUpload", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // DeleteTodayRecord();
                        ReadExcelFileAndInsertrecordInDB();
                    }
                }
                else
                {
                    ReadExcelFileAndInsertrecordInDB();
                }
            }
        }


        public string CheckTodayRecord(string dtDate)
        {
            string recordCount = string.Empty;
            string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            try
            {
                string dtSelectedDate = string.Empty;
                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                {
                    dtSelectedDate = DateTime.Parse(dtDate, dateformat).ToString();
                }
                else
                {
                    dtSelectedDate = DateTime.Parse(dtDate).ToString(_Strdateformat);
                }

                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select COUNT(*) as NumberOfRecord from STNUpload where DATEPART(YYYY, LastModify) = DATEPART(YYYY, '" + dtSelectedDate + "') and DATEPART(MM, LastModify) = DATEPART(MM, '" + dtSelectedDate + "') and DATEPART(dd, LastModify) = DATEPART(dd, '" + dtSelectedDate + "') ");
                recordCount = Convert.ToString(dt.Rows[0]["NumberOfRecord"]);

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "STNUpload / reload today Record modifydate STNUpload \n" + ex.ToString();
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
                string lastmodifydatetime2 = DateTime.Parse(uploaddate.Text).ToString("yyyy/MM/dd");
                //string querystring = "delete from STNUpload where ID in (select id from STNUpload where  RStatus not in('OK') and LastModify=" + lastmodifydatetime2 + ")";

                string querystring = @"delete from STNUpload where ID in (select id from STNUpload where  RStatus not in('OK') or RStatus is null) 
                        and (CONVERT(varchar, DATEPART(YYYY, LastModify) + DATEPART(MM, LastModify) + DATEPART(dd, LastModify)))
                          = (CONVERT(varchar, DATEPART(YYYY, '" + lastmodifydatetime2 + "') + DATEPART(MM, '" + lastmodifydatetime2 + "') + DATEPART(dd, '" + lastmodifydatetime2 + "')))";


                SqlCommand DeleteobjCommand = new SqlCommand(querystring);
                objCommon.ExecuteNewDMLQuery(DeleteobjCommand);
                //recordCount = Convert.ToString(dt.Rows[0]["NumberOfRecord"]);

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n STNUpload/ Reload today Record  STNUpload \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return recordCount;

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
                    objCommand = new SqlCommand(@"insert into STNUpload (IOMNO, Delivery, DeliveryDate, PartyCode, MaterialCode, Description, SLoc, Batch, 
                DeliveryQuantity, UpdateQty, Plnt, BillingDocument, Priority,ActualDeliveryQuantity,ActualGoodsMovement,MfgDate,ExpDate,Netvalue,
                ZMR1UnitPrice,ZSTKUnitPrice,ZEXDUnitPrice,ZCESUnitPrice,RateMaster,LastModify,AlisCode) values (@IOMNO, @Delivery, @DeliveryDate, @PartyCode, 
                    @MaterialCode, @Description, @SLoc, @Batch, @DeliveryQuantity, @UpdateQty, @Plnt, @BillingDocument,@Priority,@ActualDeliveryQuantity,
                    @ActualGoodsMovement,@MfgDate,@ExpDate,@Netvalue,@ZMR1UnitPrice,@ZSTKUnitPrice,@ZEXDUnitPrice,@ZCESUnitPrice,@RateMaster, 
                    '" + DateTime.Parse(uploaddate.Text, dateformat) + "', @AlisCode)", objConnection);
                }
                else
                {
                    objCommand = new SqlCommand(@"insert into STNUpload (IOMNO, Delivery, DeliveryDate, PartyCode, MaterialCode, Description, SLoc, Batch, 
                DeliveryQuantity, UpdateQty, Plnt, BillingDocument, Priority,ActualDeliveryQuantity,ActualGoodsMovement,MfgDate,ExpDate,Netvalue,
                ZMR1UnitPrice,ZSTKUnitPrice,ZEXDUnitPrice,ZCESUnitPrice,RateMaster,LastModify,AlisCode) values (@IOMNO, @Delivery, @DeliveryDate, @PartyCode, 
                    @MaterialCode, @Description, @SLoc, @Batch, @DeliveryQuantity, @UpdateQty, @Plnt, @BillingDocument,@Priority,@ActualDeliveryQuantity,
                    @ActualGoodsMovement,@MfgDate,@ExpDate,@Netvalue,@ZMR1UnitPrice,@ZSTKUnitPrice,@ZEXDUnitPrice,@ZCESUnitPrice,@RateMaster, 
                    '" + DateTime.Parse(uploaddate.Text).ToString(_Strdateformat) + "', @AlisCode)", objConnection);
                }


                objCommand.Parameters.AddWithValue("@IOMNO", IOMNO_STN);
                objCommand.Parameters.AddWithValue("@Delivery", Delivery);

                if (DeliveryDate.ToString() != "")
                {
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        objCommand.Parameters.AddWithValue("@DeliveryDate", DateTime.Parse(DeliveryDate.ToString(), dateformat));
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue("@DeliveryDate", DateTime.Parse(DeliveryDate.ToString()).ToString(_dateformat));
                    }
                }

                
                objCommand.Parameters.AddWithValue("@PartyCode", PartyCode);
                objCommand.Parameters.AddWithValue("@MaterialCode", MaterialCode);
                objCommand.Parameters.AddWithValue("@Description", Description);
                objCommand.Parameters.AddWithValue("@SLoc", SLoc);
                objCommand.Parameters.AddWithValue("@Batch", Batch);
                objCommand.Parameters.AddWithValue("@DeliveryQuantity", DeliveryQuantity);
                objCommand.Parameters.AddWithValue("@UpdateQty", UpdateQty);
                objCommand.Parameters.AddWithValue("@Plnt", Plnt);
                objCommand.Parameters.AddWithValue("@BillingDocument", BillingDocument);

                objCommand.Parameters.AddWithValue("@Priority", Priority);
                objCommand.Parameters.AddWithValue("@ActualDeliveryQuantity", ActualDeliveryQuantity);

                if (ActualGoodsMovement != "")
                {
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        objCommand.Parameters.AddWithValue("@ActualGoodsMovement", DateTime.Parse(ActualGoodsMovement, dateformat));
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue("@ActualGoodsMovement", DateTime.Parse(ActualGoodsMovement).ToString(_dateformat));
                    }
                }

                if (MfgDate != "")
                {
                    //objCommand.Parameters.AddWithValue("@MfgDate", MfgDate);
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        objCommand.Parameters.AddWithValue("@MfgDate", DateTime.Parse(MfgDate, dateformat));
                    }
                    else
                    {
                        objCommand.Parameters.AddWithValue("@MfgDate", DateTime.Parse(MfgDate).ToString(_dateformat));
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

                objCommand.Parameters.AddWithValue("@Netvalue", Netvalue);
                objCommand.Parameters.AddWithValue("@ZMR1UnitPrice", ZMR1UnitPrice);
                objCommand.Parameters.AddWithValue("@ZSTKUnitPrice", ZSTKUnitPrice);

                objCommand.Parameters.AddWithValue("@ZEXDUnitPrice", ZEXDUnitPrice);
                objCommand.Parameters.AddWithValue("@ZCESUnitPrice", ZCESUnitPrice);
                objCommand.Parameters.AddWithValue("@RateMaster", RateMaster);
                objCommand.Parameters.AddWithValue("@AlisCode", AlisCode);

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
                string Query1 = @"select * from STNUpload where (CONVERT(varchar, DATEPART(YYYY, LastModify) + DATEPART(MM, LastModify) + DATEPART(dd, LastModify))+CONVERT(varchar,IOMNO) + MaterialCode +Batch) = (CONVERT(varchar, DATEPART(YYYY, '" + lastmodifydatetime + "') + DATEPART(MM, '" + lastmodifydatetime + "') + DATEPART(dd, '" + lastmodifydatetime + "'))+ CONVERT(varchar," + IOMNO_STN + ") + '" + MaterialCode + "' +'" + Batch + "')";
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "All Files (*.*)|*.*";     //"Audio File (*.mp3, *.wav)|*.mp3*;*.wav";
            //dlg.Filter = "All Files (*.xls*)|*.xlsx*";
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

        private void frmStnUpload_Load(object sender, EventArgs e)
        {
            dgvstnupload.ReadOnly = false;
            btnpendingorder.Visible = false;
            LastModifydateofSTNUpload();
            BindStn();
        }

        private void btnpendingorder_Click(object sender, EventArgs e)
        {

        }

        private bool validateForm()
        {
            errorStnUpload.Clear();
            bool isValid = true;
            if (txtUpload.Text == "")
            {
                errorStnUpload.SetError(txtUpload, "Please Select Excel File !");
                isValid = false;
            }
            return isValid;
        }


        public void BindStn()
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
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from StnUpload order by 1 desc ");
                string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                {
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select * from STNUpload where DATEPART(dd,LastModify) = DATEPART(dd,'" + DateTime.Parse(uploaddate.Text, dateformat) + "') and DATEPART(MM,LastModify) = DATEPART(MM,'" + DateTime.Parse(uploaddate.Text, dateformat) + "') and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'" + DateTime.Parse(uploaddate.Text, dateformat) + "') ");
                }
                else
                {
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select * from STNUpload where DATEPART(dd,LastModify) = DATEPART(dd,'" + DateTime.Parse(uploaddate.Text).ToString(_Strdateformat) + "') and DATEPART(MM,LastModify) = DATEPART(MM,'" + DateTime.Parse(uploaddate.Text).ToString(_Strdateformat) + "') and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'" + DateTime.Parse(uploaddate.Text).ToString(_Strdateformat) + "') ");
                }

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvstnupload.DataSource = bindingSource;
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




        public void LastModifydateofSTNUpload()
        {
            try
            {

                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                string Currentdate = System.DateTime.Today.ToShortDateString();
                //dt = objCommon.GetDataTable("select top(1)* from STNUpload where DATEPART(YYYY, LastModify) = DATEPART(YYYY, GETDATE()) and DATEPART(MM, LastModify) = DATEPART(MM, GETDATE())and DATEPART(dd, LastModify) = DATEPART(dd, GETDATE())  order by 1 desc ");
                dt = objCommon.GetDataTable("select top(1)* from STNUpload order by 1 desc ");
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnpendingorder_Click_1(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Are you Sure Want To Do Integrity Test ? ", "IBISBilling", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                btnUpload.Visible = false;

                STNIntegrityTest("STNUpload");
                BindStn();
            }

        }



        public void STNIntegrityTest(string Tablename)
        {
            CommonFunction objCF = new CommonFunction();
            objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());

            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objConnection;

            objcmd.CommandText = "STN_Integrity";
            objcmd.CommandType = CommandType.StoredProcedure;

            //Locat Format
            //string lastmodifydatetime2 = DateTime.Parse(uploaddate.Text).ToString();

            //Server Format
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
            //string lastmodifydatetime2 = DateTime.Parse(uploaddate.Text).ToString();

            objcmd.Parameters.AddWithValue("@lastmodifydatetime", lastmodifydatetime2);

            objConnection.Open();
            objcmd.ExecuteNonQuery();
            objConnection.Close();

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

                    objcmd.CommandText = "UpdateOrderItemBySTN";
                    objcmd.CommandType = CommandType.StoredProcedure;

                   // string lastmodifydatetime2 = DateTime.Parse(uploaddate.Text, dateformat).ToString();


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

                    MessageBox.Show("Record Updated Successfully !");
                    BtnUpdateorderitem.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Integrity Test Fail !");
                }
            }
            BindStn();

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

            objcmd.CommandText = "select * from STNUpload where DATEPART(YYYY, LastModify) = DATEPART(YYYY, '" + lastmodifydatetime2 + "') and DATEPART(MM, LastModify) = DATEPART(MM, '" + lastmodifydatetime2 + "') and DATEPART(dd, LastModify) = DATEPART(dd, '" + lastmodifydatetime2 + "')  and RStatus!='OK'";
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



        private void button1_Click(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            //objCF.fn_ExportToExcel("select * from STNUpload ", "STNUpload", "STNUpload");
            objCF.fn_ExportToExcel("select * from STNUpload where LastModify=" + uploaddate.Text + ")", "STNUpload", "STNUpload");
        }

        private void dgvstnupload_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
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
                string Query1 = "delete from STNUpload where RStatus != 'OK' and (CONVERT(varchar, DATEPART(YYYY, LastModify) + DATEPART(MM, LastModify) + DATEPART(dd, LastModify))) = (CONVERT(varchar, DATEPART(YYYY, @lastmodifydatetime) + DATEPART(MM, @lastmodifydatetime) + DATEPART(dd, @lastmodifydatetime)))";
                objCommand = new SqlCommand(Query1, objConnection);
                objCommand.Parameters.AddWithValue("@lastmodifydatetime", lastmodifydatetime2);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Invalid Record Deleted Sucessfully");
                }
                else
                {
                    MessageBox.Show("Error Occured!");
                }
            }
            catch (Exception ex)
            {

            }

            BindStn();
        }

        private void btnReset_Click(object sender, EventArgs e)
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
                sqlDataAdapter = objC.GetSqlDataAdapter("select * from StnUpload order by 1 desc ");

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvstnupload.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCountryMaster btnReset_Click button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmitDate_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from StnUpload order by 1 desc ");
                string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                
                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                {
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select * from STNUpload where DATEPART(dd,LastModify) = DATEPART(dd,'" + DateTime.Parse(dtpGridBind.Text, dateformat) + "') and DATEPART(MM,LastModify) = DATEPART(MM,'" + DateTime.Parse(dtpGridBind.Text, dateformat) + "') and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'" + DateTime.Parse(dtpGridBind.Text, dateformat) + "') ");
                }
                else
                {
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select * from STNUpload where DATEPART(dd,LastModify) = DATEPART(dd,'" + DateTime.Parse(dtpGridBind.Text).ToString(_Strdateformat) + "') and DATEPART(MM,LastModify) = DATEPART(MM,'" + DateTime.Parse(dtpGridBind.Text).ToString(_Strdateformat) + "') and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'" + DateTime.Parse(dtpGridBind.Text).ToString(_Strdateformat) + "') ");
                }

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvstnupload.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCountryMaster btnSubmitDate_Click button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
