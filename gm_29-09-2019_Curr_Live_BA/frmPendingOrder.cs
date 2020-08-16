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
using System.Globalization;

namespace GlanMark
{
    public partial class frmPendingOrder : Form
    {
        CommonFunction objC = null;
        private SqlConnection objConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        DataTable table = new DataTable();
        DataTable tblOrderSchdule = new DataTable();
        private BindingSource bindingSource = null;
        //private String selectQueryString = null;
        private int id;
        string strLogFileName = "LOG/LogRecord.txt";
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        private string _dateformat = "MM/dd/yyyy";

        public frmPendingOrder()
        {
            InitializeComponent();
        }

        private void frmPendingOrder_Load(object sender, EventArgs e)
        {
            try
            {
                BindGridPendingOrder();
                BindDistinctIOMNo();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmPendingOrder frmPendingOrder_Load \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDistinctIOMNo()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                StringBuilder strQuery1 = new StringBuilder();
                ddlIOMNo.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlIOMNo.AutoCompleteMode = AutoCompleteMode.Suggest;


                strQuery1.Append(" select distinct OrderHeader.OrderHeaderId, CONVERT(varchar(100), OrderHeader.IOMNo) as IOMNo ");
                strQuery1.Append(" from OrderHeader join OrderItem on OrderHeader.IOMNo=OrderItem.IOMNo   where OrderHeader.Authorised=1 and OrderHeader.OrderDeliveryDate <=GETDATE()  ");
                strQuery1.Append(" and OrderHeader.Schedule='No'  and OrderItem.BatchQuantity < Quantity   ");
                strQuery1.Append(" Union all   ");
                strQuery1.Append(" select distinct OrderHeader.OrderHeaderId, CONVERT(varchar(100), OrderHeader.IOMNo) as IOMNo ");
                strQuery1.Append(" from OrderHeader join ScheduleDetail on OrderHeader.IOMNo=ScheduleDetail.IOMNo   where OrderHeader.Authorised=1 and OrderHeader.Schedule='Yes' ");
                strQuery1.Append(" and  ScheduleDetail.DeliveryDate <= GETDATE()  and ScheduleDetail.BatchQuantity < OrderQuantity  ");

                dt = objCommon.GetDataTable(strQuery1.ToString());
                DataRow dr = dt.NewRow();
                dr["OrderHeaderId"] = 0;
                dr["IOMNo"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlIOMNo.DataSource = dt;
                ddlIOMNo.DisplayMember = "IOMNo";
                ddlIOMNo.ValueMember = "OrderHeaderId";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerMaster \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BindGridPendingOrder()
        {
            try
            {
                objC = new CommonFunction();

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
                    strQuery1.Append("select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode , ot.ProductName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity, oh.DispThrough, oh.MRP, sm.Name as StampingName, ot.BillingRate, ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue, ot.AlisCode, sd.ScheduleID, ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark ,oh.OrderAuthoDate as    OrderAuthDate, oh.DocFile1 from OrderHeader as oh ,OrderItem as ot, ScheduleDetail as sd ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo and oh.Schedule='YES' and oh.Authorised=1 and sd.DeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text, dateformat).ToString() + "' and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");
                    strQuery1.Append("Union all ");
                    strQuery1.Append("select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode, ot.ProductName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity, oh.DispThrough, oh.MRP, sm.Name as StampingName, ot.BillingRate, ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue, ot.AlisCode, 0 as ScheduleID, ot.Reason,ot.Remark as PendingRemark ,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate, oh.DocFile1 from OrderHeader as oh ,OrderItem as ot , StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.Schedule='No'  and oh.Authorised=1 and oh.OrderDeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text, dateformat).ToString() + "' and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");
                
                }
                else
                {
                    //strQuery1.Append("select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity  , sd.ScheduleID ,ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark ,oh.OrderAuthoDate as    OrderAuthDate, ot.BillingRate,ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue,oh.DocFile1,oh.DispThrough, oh.MRP from OrderHeader as oh ,OrderItem as ot,ScheduleDetail as sd ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo and oh.Schedule='YES' and oh.Authorised=1 and sd.DeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat) + "' and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=0 ");
                    //strQuery1.Append(" Union all ");
                    //strQuery1.Append("select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity  , 0 as ScheduleID ,ot.Reason,ot.Remark as PendingRemark ,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate,ot.BillingRate,ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue,oh.DocFile1 ,oh.DispThrough, oh.MRP  from OrderHeader as oh ,OrderItem as ot ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.Schedule='No'   and oh.Authorised=1 and oh.OrderDeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat) + "' and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=0 ");
                    strQuery1.Append("select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode , ot.ProductName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity, oh.DispThrough, oh.MRP, sm.Name as StampingName, ot.BillingRate, ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue, ot.AlisCode, sd.ScheduleID, ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark ,oh.OrderAuthoDate as    OrderAuthDate, oh.DocFile1 from OrderHeader as oh ,OrderItem as ot, ScheduleDetail as sd ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo and oh.Schedule='YES' and oh.Authorised=1 and sd.DeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat) + "' and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");
                    strQuery1.Append("Union all ");
                    strQuery1.Append("select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode, ot.ProductName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity, oh.DispThrough, oh.MRP, sm.Name as StampingName, ot.BillingRate, ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue, ot.AlisCode, 0 as ScheduleID, ot.Reason,ot.Remark as PendingRemark ,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate, oh.DocFile1 from OrderHeader as oh ,OrderItem as ot , StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.Schedule='No'  and oh.Authorised=1 and oh.OrderDeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat) + "' and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");
                
                }

                dataTable1 = objC.GetDataTable(strQuery1.ToString());

                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable1;
                dgvPendingOrderMaster.DataSource = bindingSource;

                //txtIOMNo.Text = dgvPendingOrderMaster[dgvPendingOrderMaster.Columns["colIOMNo"].Index, e.RowIndex].Value.ToString();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/BindGridOrderheader \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPendingOrderMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int Orderheaderid = int.Parse(dgvPendingOrderMaster.Rows[e.RowIndex].Cells["colId"].Value.ToString());
                if (e.RowIndex != -1)
                {
                    int Orderheaderid = int.Parse(dgvPendingOrderMaster.Rows[e.RowIndex].Cells["colId"].Value.ToString());
                    if (e.ColumnIndex == dgvPendingOrderMaster.Columns["colSchedule"].Index)
                    {

                        frmBatch objBatch = (frmBatch)Application.OpenForms["frmBatch"];
                        if (objBatch != null)
                        {
                            objBatch.WindowState = FormWindowState.Normal;
                            objBatch.BringToFront();
                        }
                        else
                        {
                            //dgvOrderMaster.Rows[e.RowIndex].Cells["colDocFile1"].Value.ToString()
                            string prodCode = dgvPendingOrderMaster[dgvPendingOrderMaster.Columns["colProdCode"].Index, e.RowIndex].Value.ToString();
                            string iomNo = dgvPendingOrderMaster[dgvPendingOrderMaster.Columns["colIOMNo"].Index, e.RowIndex].Value.ToString();
                            string qty = dgvPendingOrderMaster[dgvPendingOrderMaster.Columns["colOrderQty"].Index, e.RowIndex].Value.ToString();
                            string PendingQty = dgvPendingOrderMaster[dgvPendingOrderMaster.Columns["colPenQty"].Index, e.RowIndex].Value.ToString();
                            string ScheduleID = dgvPendingOrderMaster[dgvPendingOrderMaster.Columns["colScheduleID"].Index, e.RowIndex].Value.ToString();
                            string Reason = dgvPendingOrderMaster[dgvPendingOrderMaster.Columns["colReason"].Index, e.RowIndex].Value.ToString();
                            string Remark = dgvPendingOrderMaster[dgvPendingOrderMaster.Columns["colRemark"].Index, e.RowIndex].Value.ToString();
                            string aliscode = dgvPendingOrderMaster[dgvPendingOrderMaster.Columns["colAlisCode"].Index, e.RowIndex].Value.ToString();
                            objBatch = new frmBatch(prodCode, aliscode, iomNo, qty, PendingQty, ScheduleID, Reason, Remark);
                            objBatch.Show();
                        }
                    }
                    else if (e.ColumnIndex == dgvPendingOrderMaster.Columns["colView"].Index)
                    {
                        Orderdetail objOrderDetail = new Orderdetail(Orderheaderid, 0);
                        objOrderDetail.Show();
                    }
                    else if (e.ColumnIndex == dgvPendingOrderMaster.Columns["colDocFile1"].Index)
                    {
                        if (e.ColumnIndex == dgvPendingOrderMaster.Columns["colDocFile1"].Index)
                        {
                            //int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                            string FileName = dgvPendingOrderMaster.Rows[e.RowIndex].Cells["colDocFile1"].Value.ToString();

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
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmPendingOrder dgvPendingOrderMaster_CellContentClick \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BindGridPendingOrder();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter(@"select OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, SubInstitution,  MRP, Remark from OrderHeader order by OrderHeaderId desc");
                //dataTable = new DataTable();
                //sqlDataAdapter.Fill(dataTable);
                DataTable dataTable1 = new DataTable();
                StringBuilder strQuery1 = new StringBuilder();

                string query = string.Empty;
                string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                {
                    strQuery1.Append("select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity  , sd.ScheduleID ,ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as    OrderAuthDate,ot.BillingRate,ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue,oh.DocFile1 , oh.DispThrough, oh.MRP  from OrderHeader as oh ,OrderItem as ot,ScheduleDetail as sd ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo and oh.Schedule='YES' and oh.Authorised=1 and sd.DeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text, dateformat).ToString() + "' and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");
                    strQuery1.Append(" Union all ");
                    strQuery1.Append("select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity  , 0 as ScheduleID ,ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate,ot.BillingRate,ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue,oh.DocFile1, oh.DispThrough, oh.MRP from OrderHeader as oh ,OrderItem as ot ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.Schedule='No'   and oh.Authorised=1 and oh.OrderDeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text, dateformat).ToString() + "' and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");
                }
                else
                {
                    strQuery1.Append("select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity  , sd.ScheduleID ,ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as    OrderAuthDate,ot.BillingRate,ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue,oh.DocFile1 , oh.DispThrough, oh.MRP  from OrderHeader as oh ,OrderItem as ot,ScheduleDetail as sd ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo and oh.Schedule='YES' and oh.Authorised=1 and sd.DeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat) + "' and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");
                    strQuery1.Append(" Union all ");
                    strQuery1.Append("select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity  , 0 as ScheduleID ,ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate,ot.BillingRate,ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue,oh.DocFile1, oh.DispThrough, oh.MRP from OrderHeader as oh ,OrderItem as ot ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.Schedule='No'   and oh.Authorised=1 and oh.OrderDeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat) + "' and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 ");
                }

                dataTable1 = objC.GetDataTable(strQuery1.ToString());

                //dataTable1.Merge(dataTable2);

                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable1;
                dgvPendingOrderMaster.DataSource = bindingSource;

                //txtIOMNo.Text = dgvPendingOrderMaster[dgvPendingOrderMaster.Columns["colIOMNo"].Index, e.RowIndex].Value.ToString();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/BindGridOrderheader \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmitIOM_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlIOMNo.SelectedIndex != 0)
                {
                    objC = new CommonFunction();
                    DataTable dataTable1 = new DataTable();
                    StringBuilder strQuery1 = new StringBuilder();

                    string query = string.Empty;
                string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                {
                    strQuery1.Append("select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity  , sd.ScheduleID ,ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as    OrderAuthDate,ot.BillingRate,ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue,oh.DocFile1 , oh.DispThrough, oh.MRP  from OrderHeader as oh ,OrderItem as ot,ScheduleDetail as sd ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo and oh.Schedule='YES' and oh.Authorised=1 and sd.DeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text, dateformat).ToString() + "' and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 and  oh.IOMNo = " + ddlIOMNo.Text + "");
                    strQuery1.Append(" Union all ");
                    strQuery1.Append("select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity  , 0 as ScheduleID ,ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate,ot.BillingRate,ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue,oh.DocFile1, oh.DispThrough, oh.MRP from OrderHeader as oh ,OrderItem as ot ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.Schedule='No'   and oh.Authorised=1 and oh.OrderDeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text, dateformat).ToString() + "' and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 and  oh.IOMNo = " + ddlIOMNo.Text + "");
                }
                else
                {
                    strQuery1.Append("select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity  , sd.ScheduleID ,ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as    OrderAuthDate,ot.BillingRate,ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue,oh.DocFile1 , oh.DispThrough, oh.MRP  from OrderHeader as oh ,OrderItem as ot,ScheduleDetail as sd ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo and oh.Schedule='YES' and oh.Authorised=1 and sd.DeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat) + "' and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=0 and ot.CloseItem=0 and  oh.IOMNo = " + ddlIOMNo.Text + "");
                    strQuery1.Append(" Union all ");
                    strQuery1.Append("select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode ,ot.ProductName , ot.AlisCode,sm.Name as StampingName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity  , 0 as ScheduleID ,ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate,ot.BillingRate,ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue,oh.DocFile1, oh.DispThrough, oh.MRP from OrderHeader as oh ,OrderItem as ot ,StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.Schedule='No'   and oh.Authorised=1 and oh.OrderDeliveryDate <='" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat) + "' and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=0  and ot.CloseItem=0 and  oh.IOMNo = " + ddlIOMNo.Text + "");
                }

                    dataTable1 = objC.GetDataTable(strQuery1.ToString());

                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable1;
                    dgvPendingOrderMaster.DataSource = bindingSource;

                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Pending Order /btnSubmitIOM_Click \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ddlIOMNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
