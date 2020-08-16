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
    public partial class frmResetOMNO : Form
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

        public frmResetOMNO()
        {
            InitializeComponent();
        }

        private void frmCopyOrder_Load(object sender, EventArgs e)
        {
            try
            {
                BindDistinctIOMNo();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCopyOrder frmCopyOrder_Load \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmitIOM_Click(object sender, EventArgs e)
        {
            BindIOMDetailByIOMNo();
        }

        private void BindIOMDetailByIOMNo()
        {
            try
            {
                if (ddlIOMNo.SelectedIndex > 0)
                {
                    if (int.Parse(ddlIOMNo.SelectedValue.ToString()) > 0)
                    {
                        objC = new CommonFunction();
                        //sqlDataAdapter = objC.GetSqlDataAdapter("select * from OrderHeader where IOMNo = " + ddlIOMNo.Text + " and IOMNo in (select iomno from orderitem where BilledQuantity=0)");
                        //sqlDataAdapter = objC.GetSqlDataAdapter("select oh.*,ba.BatchAllocationId, ba.ProductCode,ba.QTY from OrderHeader oh, BatchAllocation ba where oh.IOMNo = ba.IOMNO and oh.IOMNo =  " + ddlIOMNo.Text + "  and oh.IOMNo in (select iomno from orderitem where BilledQuantity=0)");
                        sqlDataAdapter = objC.GetSqlDataAdapter("select ba.ProductCode,ba.QTY, ba.BatchNo,(case when ba.ProductCode is not null then (select distinct top 1 Description from ProductMaster where Material = ba.ProductCode) end) as ProductName,oh.*,ba.BatchAllocationId from OrderHeader oh, BatchAllocation ba where oh.IOMNo = ba.IOMNO and oh.IOMNo =  " + ddlIOMNo.Text + " and oh.IOMNo in (select iomno from orderitem where BilledQuantity=0)");

                        dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        bindingSource = new BindingSource();
                        bindingSource.DataSource = dataTable;
                        dgvOrderMaster.DataSource = bindingSource;
                    }
                }
                else
                {
                    MessageBox.Show("IOM No Not Exist in given list!","Information");
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/BindGridCopyOrder \n" + ex.ToString();
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

                //strQuery1.Append("select distinct IOMNO, IOMNO as IOMID from batchallocation where IOMNO in (select distinct IOMNo from OrderItem where BilledQuantity=0)");
                strQuery1.Append("select distinct CONVERT(nvarchar(250), IOMNO) as 'IOMNO', IOMNO as IOMID from batchallocation where IOMNO in (select distinct IOMNo from OrderItem where BilledQuantity=0)");
                
                dt = objCommon.GetDataTable(strQuery1.ToString());
                DataRow dr = dt.NewRow();
                dr["IOMID"] = 0;
                dr["IOMNO"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlIOMNo.DataSource = dt;
                ddlIOMNo.DisplayMember = "IOMNO";
                ddlIOMNo.ValueMember = "IOMID";

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

        private void dgvOrderMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                if (e.RowIndex != -1)
                {
                    int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                    //if (e.ColumnIndex == dgvOrderMaster.Columns["colView"].Index)
                    //{
                    //    Orderdetail objOrderDetail = new Orderdetail(Orderheaderid, 1);
                    //    //foreach (Form form in OwnedForms)
                    //    //{
                    //    //    if (form.Name == "Orderdetail")
                    //    //    {
                    //    //        form.Activate();
                    //    //        return;
                    //    //    }
                    //    //}

                    //    FormCollection fc = Application.OpenForms;

                    //    foreach (Form frm in fc)
                    //    {
                    //        if (frm.Name == "Orderdetail")
                    //        {
                    //            if (MessageBox.Show("Order Detail Form Already Open") == DialogResult.OK)
                    //                frm.Activate();
                    //            return;
                    //        }
                    //    }

                    //    objOrderDetail.Show();

                    //}

                    if (e.ColumnIndex == dgvOrderMaster.Columns["colDocFile1"].Index)
                    {
                        //int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                        string FileName = dgvOrderMaster.Rows[e.RowIndex].Cells["colDocFile1"].Value.ToString();

                        string strPath = System.Windows.Forms.Application.StartupPath + "//UploadFile//" + FileName;
                        if (File.Exists(strPath))
                        {
                            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                            myProcess.StartInfo.FileName = "AcroRd32.exe";
                            myProcess.StartInfo.Arguments = " /n /A \"nameddest=nameddest\" " + strPath + "\"";
                            myProcess.Start();

                        }
                    }

                    if (e.ColumnIndex == dgvOrderMaster.Columns["colResetBatch"].Index)
                    {
                        int OrderHeaId = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                        int IOMNo = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colIOMNumber"].Value.ToString());
                        int BatchAllocationId = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colBatchAllocationId"].Value.ToString());
                        int BatchQTY = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colBatchQTY"].Value.ToString());
                        string ProductCode = dgvOrderMaster.Rows[e.RowIndex].Cells["colProductCode"].Value.ToString();

                        var result = MessageBox.Show("Are you Sure Want To Do Reset Batch Allocation  ? ", "BatchAllocation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string ProcOutPut = FrmBatchAllocation(IOMNo, ProductCode, BatchQTY, BatchAllocationId);
                            if (ProcOutPut == "Success")
                            {
                                MessageBox.Show("IomNo " + (ddlIOMNo.Text) + " Record Reset Successfully");
                                BindIOMDetailByIOMNo();
                            }
                            else
                            {
                                MessageBox.Show(ProcOutPut);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCopyOrder dgvOrderMaster_CellContentClick \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private int getNewIOMNo(string OrderTypeID)
        {
            int IOMNumber = 0;
            CommonFunction objCF = new CommonFunction();
            //IOM NUMBER LOGIC START          
            //string yR = string.Format("0:Y",dtpIOM.Text);
            string IOMnO = "";
            dataTable = objCF.GetDataTable("select * from IOMLogicMaster where OrderTypeId='" + OrderTypeID + "' and Year=DATEPART(YYYY,GETDATE())");
            if (dataTable.Rows[0]["LastUsed"].ToString() == "" || dataTable.Rows[0]["LastUsed"].ToString() == null)
            {
                IOMnO = dataTable.Rows[0]["StartingNumber"].ToString();
            }
            else
            {
                IOMnO = Convert.ToString(Convert.ToInt32(dataTable.Rows[0]["LastUsed"].ToString()) + 1);
            }

            lblIOMID.Text = dataTable.Rows[0]["ID"].ToString();
            //IOM NUMBER LOGIC END
            return IOMNumber = int.Parse(IOMnO.ToString());
        }

        //private void ddlIOMNo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlIOMNo.SelectedIndex != 0)
        //        {
        //            objC = new CommonFunction();
        //            sqlDataAdapter = objC.GetSqlDataAdapter(@"select distinct batchallocationid, convert(varchar, IOMNo) as IOMNo from batchallocation where  iomno="+ddlIOMNo.Text +  "and  iomno in (select iomno from orderitem where BilledQuantity=0)");
        //            dataTable = new DataTable();
        //            sqlDataAdapter.Fill(dataTable);
        //            bindingSource = new BindingSource();
        //            bindingSource.DataSource = dataTable;
        //            dgvOrderMaster.DataSource = bindingSource;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        StreamWriter swLog = File.AppendText(strLogFileName);
        //        string strError = DateTime.Now.ToString() + "\n Main Page/BindGridCopyOrder \n" + ex.ToString();
        //        swLog.WriteLine(strError);
        //        swLog.WriteLine();
        //        swLog.Close();
        //        MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (int.Parse(ddlIOMNo.SelectedValue.ToString()) > 0)
            //{

            //    var result = MessageBox.Show("Are you Sure Want To Do Reset Batch Allocation  ? ", "BatchAllocation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        string ProcOutPut = FrmBatchAllocation(Convert.ToInt64(ddlIOMNo.Text));

            //        if (ProcOutPut == "Success")
            //        {

            //            MessageBox.Show("IomNo " + (ddlIOMNo.Text) + " Record Reset Successfully");
            //        }
            //        else
            //        {
            //            MessageBox.Show(ProcOutPut);
            //        }

            //    }
            //}
        }


        public string FrmBatchAllocation(long IomNO, string ProductCode, int BatchQTY, int BatchAllocationId)
        {
            string message = String.Empty;
            CommonFunction objCF = new CommonFunction();
            objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());

            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objConnection;
            objConnection.Open();

            objcmd.CommandText = "BatchAllocationReset";
            objcmd.CommandType = CommandType.StoredProcedure;

            objcmd.Parameters.AddWithValue("@IIOMNO", IomNO);

            objcmd.Parameters.AddWithValue("@ProductCode", ProductCode);
            objcmd.Parameters.AddWithValue("@BatchQuantity", BatchQTY);
            objcmd.Parameters.AddWithValue("@BatchAllocationId", BatchAllocationId);

           // SqlParameter spInsertedKey = new SqlParameter("@Message", SqlDbType.VarChar);
            //spInsertedKey.Direction = ParameterDirection.Output;
            //string procvalue = objcmd.Parameters["@Message"].Value.ToString();


            SqlParameter parms;
            parms = objcmd.Parameters.Add("@Message", SqlDbType.VarChar, 250);
            parms.Direction = ParameterDirection.Output;
            

            objcmd.ExecuteNonQuery();
            message = objcmd.Parameters["@Message"].Value.ToString();
            objConnection.Close();


            return message;
        }

    }
}
