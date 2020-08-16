using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ww_lib;
using ww_admin;
using System.Data.SqlClient;
using System.Configuration;

namespace GlanMark
{
    public partial class frmBatch : Form
    {
        CommonFunction objC = null;
        private SqlConnection objConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        DataTable table = new DataTable();
        DataTable tblOrderSchdule = new DataTable();
        private BindingSource bindingSource = null;
        string strLogFileName = "LOG/LogRecord.txt";
        string strReason = string.Empty;

        public frmBatch()
        {
            InitializeComponent();
            //prodCode = 0;
            //iomNo = 0;
            //qty = 0;
        }

        public frmBatch(string pcode, string alisecode, string ino, string qty, string PendingQty, string ScheduleID, string Reason, string Remark)
        {
            InitializeComponent();
            //prodCode = pcode;
            //iomNo = ino;
            //qty = qty;
            lblProdCode.Text = alisecode;
            lblPendingQuantity.Text = PendingQty;
            lblIOMno.Text = ino;
            lblSchduleID.Text = ScheduleID;
            txtRemark.Text = Remark;
            strReason = Reason;


        }

        private void frmBatch_Load(object sender, EventArgs e)
        {
            bindBatch();
            BindReason(strReason);
            if (strReason != "")
                ddlReason.Text = strReason;

            DataTable dt = new DataTable();
            CommonFunction objCommon = new CommonFunction();

            dt = objC.GetDataTable("select top 1 * from ProductMaster where Aliscode = '" + lblProdCode.Text + "'");
            if (dt.Rows.Count > 0)
            {
                lblAliseName.Text = dt.Rows[0]["AliasName"].ToString();
            }

        }

        private void BindReason(string strReason)
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select ID, ReasonForPending from PendingReason");
                DataRow dr = dt.NewRow();
                if (strReason == "")
                {
                    dr["ID"] = 0;
                    dr["ReasonForPending"] = "--select--";
                }

                dt.Rows.InsertAt(dr, 0);
                ddlReason.DataSource = dt;
                ddlReason.DisplayMember = "ReasonForPending";
                ddlReason.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindOrderType \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void bindBatch()
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter(@"select OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, SubInstitution,  MRP, Remark from OrderHeader order by OrderHeaderId desc");
                //dataTable = new DataTable();
                //sqlDataAdapter.Fill(dataTable);
                DataTable dataTable1 = new DataTable();

                //dataTable1 = objC.GetDataTable("select ID,WareHouseCode,StorageCode,ProductCode,(case when StockUpload.ProductCode is not null then (select Description from ProductMaster where StockUpload.ProductCode = ProductMaster.Material and IsActive='Yes') end) ProductName, BatchNo,ProductDate,ExpiryDate,SelfLifePercentage,(Unrestricted-AllocatedQuantity) Quantity from StockUpload where Aliscode = '" + lblProdCode.Text + "' and (Unrestricted-AllocatedQuantity) > 0");
                dataTable1 = objC.GetDataTable("select ID,WareHouseCode,StorageCode,ProductCode,Description as ProductName, BatchNo,ProductDate,ExpiryDate,SelfLifePercentage,(Unrestricted-AllocatedQuantity) Quantity from StockUpload where Aliscode = '" + lblProdCode.Text + "' and (Unrestricted-AllocatedQuantity) > 0");

                //dataTable1 = objC.GetDataTable("select ID,WareHouseCode,BatchNo,ExpiryDate,SelfLifePercentage,(Unrestricted-AllocatedQuantity) Quantity from StockUpload where Aliscode = '" + lblProdCode.Text + "' and (Unrestricted-AllocatedQuantity) > 0");

                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable1;
                dgvOrderItemSchedule.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n frmBatch.cs bindBatch \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                // MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = 0;
                decimal TotQuantity = 0;
                for (int j = 0; j < dgvOrderItemSchedule.Rows.Count - 1; j++)
                {
                    if (dgvOrderItemSchedule.Rows[j].Cells["colAllocate"].Value != null)
                        TotQuantity += int.Parse(dgvOrderItemSchedule.Rows[j].Cells["colAllocate"].Value.ToString());
                }

                if (TotQuantity == 0)
                {
                    CommonFunction objCF = new CommonFunction();
                    string Query = string.Empty;

                    Query = "Update OrderItem set Reason = @Reason, IsDeliveryCompleted=@IsDeliveryCompleted, Remark = @Remark, CloseDate=getdate() where IOMNo=@IOMNO and Aliscode=@Aliscode; ";
                    //Query = "Update OrderItem set Reason = @Reason, IsDeliveryCompleted=@IsDeliveryCompleted, Remark = @Remark where IOMNo=@IOMNO and ProductCode=@ProductCode; Update ScheduleDetail set Reason = @Reason, Remark = @Remark where ScheduleID = @ScheduleID ";
                    SqlCommand objcmd = new SqlCommand(Query);
                    if (ddlReason.SelectedIndex != 0)
                    {
                        objcmd.Parameters.AddWithValue("@Reason", ddlReason.Text);
                    }
                    else
                    {
                        objcmd.Parameters.AddWithValue("@Reason", "");
                    }
                    objcmd.Parameters.AddWithValue("@Remark", txtRemark.Text);


                    objcmd.Parameters.AddWithValue("@IOMNO", Convert.ToInt32(lblIOMno.Text));
                    objcmd.Parameters.AddWithValue("@Aliscode", lblProdCode.Text);
                    objcmd.Parameters.AddWithValue("@IsDeliveryCompleted", Convert.ToBoolean(IsDeliveryCompleted.Checked));

                    Result objResult = objCF.ExecuteNewDMLQuery(objcmd);
                    if (objResult.bStatus)
                    {
                        //if (MessageBox.Show("Successfully Done") == DialogResult.OK)
                        //{
                        //this.Close();
                        //frmPendingOrder objPending = new frmPendingOrder();
                        //objPending.BindGridPendingOrder();
                        this.Close();
                        MdiForm objMDI = (MdiForm)Application.OpenForms["MdiForm"];
                        frmPendingOrder objPendingOrder = (frmPendingOrder)Application.OpenForms["frmPendingOrder"];
                        //if (MessageBox.Show("Successfully Done") == DialogResult.OK)
                        //{
                        if (objPendingOrder != null)
                        {
                            objPendingOrder.WindowState = FormWindowState.Maximized;
                            objPendingOrder.BringToFront();
                            objPendingOrder.BindGridPendingOrder();
                        }
                        else
                        {
                            objPendingOrder = new frmPendingOrder();
                            objPendingOrder.MdiParent = objMDI;
                            objPendingOrder.Show();
                            objPendingOrder.BindGridPendingOrder();

                        }
                        //}
                        //}
                    }

                }

                //if (TotQuantity <= int.Parse(lblPendingQuantity.Text))
                decimal lblPendingQuantity2 = Convert.ToDecimal(lblPendingQuantity.Text);
                if (TotQuantity <= lblPendingQuantity2)
                {
                    for (int i = 0; i < dgvOrderItemSchedule.Rows.Count - 1; i++)
                    {
                        CommonFunction objCF = new CommonFunction();
                        objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());

                        SqlCommand objcmd = new SqlCommand();
                        objcmd.Connection = objConnection;

                        objcmd.CommandText = "spBatchUpdate";
                        objcmd.CommandType = CommandType.StoredProcedure;

                        objcmd.Parameters.AddWithValue("@stockUploadId", decimal.Parse(dgvOrderItemSchedule.Rows[i].Cells["colID"].Value.ToString()));

                        if (dgvOrderItemSchedule.Rows[i].Cells["colAllocate"].Value != null)
                        {
                            objcmd.Parameters.AddWithValue("@QTY", int.Parse(dgvOrderItemSchedule.Rows[i].Cells["colAllocate"].Value.ToString()));
                        }
                        else
                        {
                            objcmd.Parameters.AddWithValue("@QTY", 0);
                        }

                        objcmd.Parameters.AddWithValue("@IOMNO", Convert.ToInt32(lblIOMno.Text));
                        objcmd.Parameters.AddWithValue("@ProductCode", dgvOrderItemSchedule.Rows[i].Cells["colProductCode"].Value.ToString());
                        objcmd.Parameters.AddWithValue("@WareHouseCode", dgvOrderItemSchedule.Rows[i].Cells["colWareHousecode"].Value.ToString());
                        objcmd.Parameters.AddWithValue("@BatchNo", dgvOrderItemSchedule.Rows[i].Cells["colBatchNo"].Value.ToString());
                        if (dgvOrderItemSchedule.Rows[i].Cells["colMFG"].Value != null)
                            objcmd.Parameters.AddWithValue("@MFGDate", DateTime.Parse(dgvOrderItemSchedule.Rows[i].Cells["colMFG"].Value.ToString()));
                        else
                            objcmd.Parameters.AddWithValue("@MFGDate", DateTime.Now);   //dgvOrderItemSchedule.Rows[i].Cells["colMFG"].Value

                        if (dgvOrderItemSchedule.Rows[i].Cells["colExpiryDate"].Value != null)
                            objcmd.Parameters.AddWithValue("@ExpiryDate", DateTime.Parse(dgvOrderItemSchedule.Rows[i].Cells["colExpiryDate"].Value.ToString()));
                        else
                            objcmd.Parameters.AddWithValue("@ExpiryDate", DateTime.Now);    //dgvOrderItemSchedule.Rows[i].Cells["colExpiryDate"].Value



                        if (lblProdCode.Text != "")
                        {
                            objcmd.Parameters.AddWithValue("@Aliscode", lblProdCode.Text);
                        }
                        else
                        {
                            objcmd.Parameters.AddWithValue("@Aliscode", "");
                        }


                        if (ddlReason.SelectedIndex != 0)
                        {
                            objcmd.Parameters.AddWithValue("@Reason", ddlReason.Text);
                        }
                        else
                        {
                            objcmd.Parameters.AddWithValue("@Reason", "");
                        }

                        objcmd.Parameters.AddWithValue("@Remark", txtRemark.Text);

                        objcmd.Parameters.AddWithValue("@SelfLifePercentage", int.Parse(dgvOrderItemSchedule.Rows[i].Cells["colSelfLifePercentage"].Value.ToString()));
                        objcmd.Parameters.AddWithValue("@ScheduleID", int.Parse(lblSchduleID.Text));

                        objcmd.Parameters.AddWithValue("@StorageCode", dgvOrderItemSchedule.Rows[i].Cells["colStorageCode"].Value.ToString());

                        //objcmd.Parameters.AddWithValue("@Message", 0);
                        //objcmd.Parameters["@Message"].Direction = ParameterDirection.ReturnValue;

                        objConnection.Open();

                        objcmd.ExecuteNonQuery();

                        //string id = objcmd.Parameters["@Message"].Value.ToString();
                        //SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                        //spInsertedKey.Direction = ParameterDirection.Output;
                        //objcmd.Parameters.Add(spInsertedKey);

                        //Result objResult = objCF.InsertNewQuery(objcmd);
                        //if (objResult.bStatus)
                        //{
                        //    flag = 1;
                        //}
                        //if (flag == 1)
                        //{

                        //}
                    }

                    if (MessageBox.Show("Batch Allocation Done Successfully") == DialogResult.OK)
                    {
                        //this.Close();
                        //frmPendingOrder objPending = new frmPendingOrder();
                        //objPending.BindGridPendingOrder();
                        this.Close();
                        MdiForm objMDI = (MdiForm)Application.OpenForms["MdiForm"];
                        frmPendingOrder objPendingOrder = (frmPendingOrder)Application.OpenForms["frmPendingOrder"];
                        if (objPendingOrder != null)
                        {
                            objPendingOrder.WindowState = FormWindowState.Maximized;
                            objPendingOrder.BringToFront();
                            objPendingOrder.BindGridPendingOrder();
                        }
                        else
                        {
                            objPendingOrder = new frmPendingOrder();
                            objPendingOrder.MdiParent = objMDI;
                            objPendingOrder.Show();
                            objPendingOrder.BindGridPendingOrder();

                        }
                    }

                }
                else if (TotQuantity > Convert.ToDecimal(lblPendingQuantity.Text))
                {
                    lblOrderScheStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    lblOrderScheStatus.Text = "Order Quantity should be not more than Total Quantity";
                }
                //else if (TotQuantity < int.Parse(lblPendingQuantity.Text))
                //{
                //    lblOrderScheStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                //    lblOrderScheStatus.Text = "Order Quantity should be not less than Total Quantity";
                //}
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n frmBatch.cs btnUpdateSchedule_Click \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                // MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
