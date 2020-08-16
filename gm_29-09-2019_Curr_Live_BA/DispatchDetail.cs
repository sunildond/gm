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
    public partial class DispatchDetail : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        private string _strDateFormat = "MM/dd/yyyy";
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private int id;
        private int flag = 0;

        public DispatchDetail(string id, int flag)
        {
            InitializeComponent();
            bindGridDispatchDetail(id, flag);
        }

        public void bindGridDispatchDetail(string BillID, int flag)
        {
            try
            {
                string Query = string.Empty;
                objC = new CommonFunction();
                // 1 for SAPInvoiceUpload and 2 for STNUpload
                if (flag == 1)
                {
                    //Query = "select MaterialCode, Description, BilledQuantity as Quantity, Batch, (case when IOMNO is not null then (select DocFile1 from OrderHeader where OrderHeader.IOMNo = SAPInvoiceUpload.IOMNO) end) as 'DocFile1' from SAPInvoiceUpload where BillingDocument = '" + BillID + "'";

                    Query = @"select distinct * from ((select  sap.BillingDocument,sap.MaterialCode, sap.Description, sap.BilledQuantity  as  Quantity,sap.Batch,sap.IOMNo as 'BILLINGIOMNO',oh.IOMNo as 'ORDEDR IOM NO' ,oh.DocFile1,oh.DocFile2 from SAPInvoiceUpload as sap,STNUpload as stn, OrderHeader as oh where sap.IOMNo=stn.Delivery  and stn.IOMNO  =oh.IOMNo )  Union all (select  sap.BillingDocument,sap.MaterialCode, sap.Description, sap.BilledQuantity as Quantity ,sap.Batch,sap.IOMNo as 'BILLINGIOMNO',oh.IOMNo as 'ORDER IOM NO' ,oh.DocFile1,oh.DocFile2 from DirSAPInvoiceUpload as sap,OrderHeader as oh where sap. IOMNO  =oh.IOMNo )  Union all (select  sap.DocumentNumber  as 'Billingdocument',sap.MaterialCode,  sap.ProductName as 'desrciption', sap.BilledQuantity as Quantity ,sap.Batch,sap.IOMNo as 'BILLINGIOMNO',oh.IOMNo as 'ORDER IOM NO' ,oh.DocFile1,oh.DocFile2 from IBISBillingUpdate as sap,STNUpload as stn, OrderHeader as oh where sap.IOMNo=stn.Delivery  and stn.IOMNO  =oh.IOMNo  )  Union all (select  sap.DocumentNumber  as 'Billingdocument',sap.MaterialCode,  sap.ProductName as 'desrciption', sap.BilledQuantity as Quantity ,sap.Batch,sap.IOMNo as 'BILLINGIOMNO',oh.IOMNo as 'ORDER IOM NO' ,oh.DocFile1,oh.DocFile2 from IBISDirectBillingUpdate as sap, OrderHeader as oh where  sap.IOMNO  =oh.IOMNo ) ) as e where BillingDocument = '" + BillID + "'";
                    
                }
                else if (flag == 2)
                {

                    //Query = "select MaterialCode, Description, DeliveryQuantity as Quantity, Batch, (case when IOMNO is not null then (select DocFile1 from OrderHeader where OrderHeader.IOMNo = STNUpload.IOMNO) end) as 'DocFile1' from STNUpload where Delivery = " + BillID;
                    Query = @"select stn.Delivery , stn.MaterialCode,stn.Description,stn.DeliveryQuantity  as Quantity ,stn.Batch, oh.IOMNo  as 'oh no'   , oh.DocFile1, oh.DocFile2  from STNUpload as stn ,OrderHeader as oh  where stn.IOMNO=oh.IOMNo   and stn.Delivery='" + BillID + "'";

                }

                sqlDataAdapter = objC.GetSqlDataAdapter(Query);

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvDispatchDetail.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n frmDispatch/bindGridDispatchDetail \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDispatchDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvDispatchDetail.Columns["colDocFile1"].Index)
                {
                    //int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                    string FileName = dgvDispatchDetail.Rows[e.RowIndex].Cells["colDocFile1"].Value.ToString();

                    //string strPath = System.Windows.Forms.Application.StartupPath + "//UploadFile//" + FileName;
                    string strPath = ConfigurationSettings.AppSettings["ServerPath"].ToString() + FileName;
                    if (File.Exists(strPath))
                    {
                        System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                        myProcess.StartInfo.FileName = "AcroRd32.exe";
                        myProcess.StartInfo.Arguments = " /n /A \"nameddest=nameddest\" " + strPath + "\"";
                        myProcess.Start();

                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/DispatchDetail dgvDispatchDetail_CellContentClick \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
