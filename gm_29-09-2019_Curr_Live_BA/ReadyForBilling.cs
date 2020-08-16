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

namespace gm
{
    public partial class ReadyForBilling : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        private string _strDateFormat = "MM/dd/yyyy";
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        CommonFunction objC = null;
        private SqlConnection objConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private int id;
        string strQuery = string.Empty;
                

        public ReadyForBilling()
        {
            InitializeComponent();
        }

        private void ReadyForBilling_Load(object sender, EventArgs e)
        {
//            strQuery = (@"SELECT BatchAllocation.IOMNO,OrderHeader.IOMDate,OrderHeader.PartyCode,OrderHeader.PartyName, OrderHeader.DispThrough, OrderHeader.InstPONo,OrderHeader.InstPODate,
//                OrderItem.Remark,BatchAllocation.WareHouseCode,BatchAllocation.StorageCode, BatchAllocation.ProductCode  ,OrderItem.ProductName,BatchAllocation.BatchNo,BatchAllocation.QTY,
//                OrderItem.BillingRate,OrderItem.MRP as MRPRate, OrderItem.EffTax,OrderItem.ProdValue,
//                BatchAllocation.MFGDate, BatchAllocation.ExpiryDate,BatchAllocation.SelfLifePercentage, OrderHeader.MRP,StampingMaster.Name as Stamping, 
//                (OrderItem.MRP * BatchAllocation.QTY) as MRPValue  FROM BatchAllocation,OrderHeader,OrderItem,StampingMaster 
//                WHERE   BatchAllocation.IOMNO=OrderHeader.IOMNo      and OrderHeader.StampingID=StampingMaster.StampingId 
//                and BatchAllocation.AlisCode=OrderItem.AlisCode and OrderItem.IOMNo=OrderHeader.IOMNo
//                and CONVERT(varchar, BatchAllocation.IOMNO)+BatchAllocation.ProductCode  
//                not in ( select CONVERT(varchar,iomno)+MaterialCode from stnupload  where OrdUpdated =1 
//                Union all   
//                select CONVERT(varchar,iomno)+MaterialCode from SAPInvoiceUpload  where OrdUpdated =1  
//                Union all   
//                select CONVERT(varchar,iomno)+MaterialCode  from DirSAPInvoiceUpload  where OrdUpdated =1  
//                Union all  
//                select CONVERT(varchar,iomno)+MaterialCode from IBISBillingUpdate  where OrdUpdated =1
//                Union all   select CONVERT(varchar,iomno)+MaterialCode 
//                from  IBISDirectBillingUpdate  where OrdUpdated =1 )");

            CommonFunction objCF = new CommonFunction();
            objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());

            SqlCommand objcmd = new SqlCommand();
            objcmd.CommandTimeout = 90000;
            objcmd.Connection = objConnection;

            objcmd.CommandText = "spReadyForBilling";
            objcmd.CommandType = CommandType.StoredProcedure;
            objConnection.Open();
            objcmd.ExecuteNonQuery();


            strQuery = "select * from tmpReadyForBilling";
            dgvBillingDoc.ReadOnly = true;
            bindGridRFBilling();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            //objCF.fn_ExportToExcel("SELECT BatchAllocation.IOMNO,OrderHeader.IOMDate,OrderHeader.PartyCode,OrderHeader.PartyName, BatchAllocation.ProductCode  ,OrderItem.ProductName,OrderHeader.DispThrough,OrderHeader.InstPONo,OrderHeader.InstPODate, OrderItem.BillingRate,OrderItem  .EffTax,OrderItem.ProdValue,OrderItem.Remark,OrderHeader.MRP,StampingMaster.Name as Stamping, BatchAllocation.WareHouseCode,  BatchAllocation.BatchNo,BatchAllocation.QTY, BatchAllocation.MFGDate, BatchAllocation.ExpiryDate,BatchAllocation.SelfLifePercentage  FROM BatchAllocation,OrderHeader,OrderItem,StampingMaster  WHERE   BatchAllocation.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and BatchAllocation.ProductCode=OrderItem.ProductCode and CONVERT(varchar, BatchAllocation.IOMNO)+BatchAllocation.ProductCode  not in (    select CONVERT(varchar,iomno)+MaterialCode from stnupload  where OrdUpdated =1   Union all   select CONVERT(varchar,iomno)+MaterialCode  from SAPInvoiceUpload  where OrdUpdated =1  Union all   select CONVERT(varchar,iomno)+MaterialCode  from DirSAPInvoiceUpload  where OrdUpdated =1  Union all   select CONVERT(varchar,iomno)+MaterialCode from IBISBillingUpdate  where OrdUpdated =1  Union all   select CONVERT(varchar,iomno)+MaterialCode from  IBISDirectBillingUpdate  where OrdUpdated =1 )", "ReadyForBilling", "ReadyForBilling");
            objCF.fn_ExportToExcel(strQuery.ToString(), "ReadyForBilling", "ReadyForBilling");
        }

        public void bindGridRFBilling()
        {
            // try
            //{
            objC = new CommonFunction();
            //sqlDataAdapter = objC.GetSqlDataAdapter("SELECT IOMNO, ProductCode, WareHouseCode, BatchNo, QTY, MFGDate, ExpiryDate, SelfLifePercentage,BillQuantity FROM BatchAllocation WHERE IOMNO in (select IOMNO from OrderItem where BatchQuantity > 0 and BilledQuantity != BatchQuantity)");

            //sqlDataAdapter = objC.GetSqlDataAdapter(" SELECT BatchAllocation.IOMNO,OrderHeader.IOMDate,OrderHeader.PartyCode,OrderHeader.PartyName, BatchAllocation.ProductCode  ,OrderItem.ProductName,OrderHeader.DispThrough,OrderHeader.InstPONo,OrderHeader.InstPODate, OrderItem.BillingRate,OrderItem  .EffTax,OrderItem.ProdValue,OrderItem.Remark,OrderHeader.MRP,(OrderItem.MRP * BatchAllocation.QTY) as MRPValue, StampingMaster.Name as Stamping, BatchAllocation.WareHouseCode,  BatchAllocation.BatchNo,BatchAllocation.QTY, BatchAllocation.MFGDate, BatchAllocation.ExpiryDate,BatchAllocation.SelfLifePercentage  FROM BatchAllocation,OrderHeader,OrderItem,StampingMaster  WHERE   BatchAllocation.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and BatchAllocation.ProductCode=OrderItem.ProductCode and CONVERT(varchar, BatchAllocation.IOMNO)+BatchAllocation.ProductCode  not in (    select CONVERT(varchar,iomno)+MaterialCode from stnupload  where OrdUpdated =1   Union all   select CONVERT(varchar,iomno)+MaterialCode  from SAPInvoiceUpload  where OrdUpdated =1  Union all   select CONVERT(varchar,iomno)+MaterialCode  from DirSAPInvoiceUpload  where OrdUpdated =1  Union all   select CONVERT(varchar,iomno)+MaterialCode from IBISBillingUpdate  where OrdUpdated =1  Union all   select CONVERT(varchar,iomno)+MaterialCode from  IBISDirectBillingUpdate  where OrdUpdated =1 )");
            
            sqlDataAdapter = objC.GetSqlDataAdapter(strQuery);
            
            //sqlDataAdapter = objC.GetSqlDataAdapter("SELECT BatchAllocation.IOMNO,OrderHeader.IOMDate,OrderHeader.PartyCode,OrderHeader.PartyName, BatchAllocation.ProductCode,OrderItem.ProductName,OrderHeader.DispThrough,OrderHeader.InstPONo,OrderHeader.InstPODate, OrderItem.BillingRate,OrderItem.EffTax,OrderItem.ProdValue,OrderItem.Remark,OrderHeader.MRP,StampingMaster.Name as Stamping, BatchAllocation.WareHouseCode,BatchAllocation.BatchNo,BatchAllocation.QTY, BatchAllocation.MFGDate, BatchAllocation.ExpiryDate,BatchAllocation.SelfLifePercentage FROM BatchAllocation,OrderHeader,OrderItem,StampingMaster  WHERE BatchAllocation.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and BatchAllocation.ProductCode=OrderItem.ProductCode and BatchAllocation.IOMNO  =OrderItem.IOMNo and  BatchAllocation.IOMNO in (select IOMNO from OrderItem where BatchQuantity > 0 and BilledQuantity != BatchQuantity)"); 
            
            dataTable = new DataTable();
            //DataSet ds=new DataSet() 
            sqlDataAdapter.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            dgvBillingDoc.DataSource = bindingSource;

            lblTotalRecord.Text = dataTable.Rows.Count.ToString();
            //}
            //catch (Exception ex)
            // {
            //StreamWriter swLog = File.AppendText(strLogFileName);
            //string strError = DateTime.Now.ToString() + "\n frmReadyForBilling/bindGridRFBilling \n" + ex.ToString();
            //swLog.WriteLine(strError);
            //swLog.WriteLine();
            //swLog.Close();
            //  MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        
    }
}
