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
    public partial class frmCopyOrder : Form
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

        public frmCopyOrder()
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
            try
            {
                if (int.Parse(ddlIOMNo.SelectedValue.ToString()) > 0)
                {
                    objC = new CommonFunction();
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, (case when OrderHeader.SubInstitution is not null then (select Name from SubInstitutionMaster where OrderHeader.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution, MRP, Remark, DocFile1, LocalPlace from OrderHeader where IOMNo = " + ddlIOMNo.Text + " order by OrderHeaderId desc");
                    dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable;
                    dgvOrderMaster.DataSource = bindingSource;
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

                strQuery1.Append("select distinct OrderHeaderId, convert(varchar, IOMNo) as IOMNo from OrderHeader");

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

        private void dgvOrderMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                if (e.RowIndex != -1)
                {
                    int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                    if (e.ColumnIndex == dgvOrderMaster.Columns["colView"].Index)
                    {
                        Orderdetail objOrderDetail = new Orderdetail(Orderheaderid, 1);
                        //foreach (Form form in OwnedForms)
                        //{
                        //    if (form.Name == "Orderdetail")
                        //    {
                        //        form.Activate();
                        //        return;
                        //    }
                        //}

                        FormCollection fc = Application.OpenForms;

                        foreach (Form frm in fc)
                        {
                            if (frm.Name == "Orderdetail")
                            {
                                if (MessageBox.Show("Order Detail Form Already Open") == DialogResult.OK)
                                    frm.Activate();
                                return;
                            }
                        }

                        objOrderDetail.Show();

                    }
                    else if (e.ColumnIndex == dgvOrderMaster.Columns["colDocFile1"].Index)
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

        private void btnCopyIOMNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(ddlIOMNo.SelectedValue.ToString()) > 0)
                {
                    var Result = MessageBox.Show("Are you sure Copy this IOM No. " + ddlIOMNo.Text, "Confirmation Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Result == DialogResult.Yes)
                    {
                        DataTable dt = new DataTable();
                        CommonFunction objCommon = new CommonFunction();
                        StringBuilder strQuery1 = new StringBuilder();

                        strQuery1.Append("select * from OrderHeader where IOMNo = " + ddlIOMNo.Text);
                        dt = objCommon.GetDataTable(strQuery1.ToString());
                        string OrderTypeId = dt.Rows[0]["OrderType"].ToString();
                        int IOMNumber = getNewIOMNo(OrderTypeId);

                        objCommon.ExecuteDMLQuery("UPDATE IOMLogicMaster set LastUsed='" + IOMNumber + "' where ID='" + lblIOMID.Text + "' ");

                        objCommon.ExecuteDMLQuery(@"insert into OrderHeader (OrderType, IOMNo, IOMDate, InstPONo, InstPODate, OrderRecieveDate, PartyCode, PartyName, 
                    LocationCode, DispThrough, Institution, SubInstitution, StampingID, LST_CST,  TaxIndicator, TaxOn, Schedule, MRP, DSM_ZSM,Lisioner, 
                    BillingAddress, DeliveryAddress, OrderDeliveryDate, DocumentRequired, Remark, ShelfLife, DocFile1, LastModify, LocalPlace, CopyIOM) 
                    (select OrderType, " + IOMNumber + ", getdate(), InstPONo, InstPODate, getdate(), PartyCode, PartyName, LocationCode, DispThrough, Institution, SubInstitution, StampingID, LST_CST,  TaxIndicator, TaxOn, Schedule, MRP, DSM_ZSM,Lisioner, BillingAddress, DeliveryAddress, OrderDeliveryDate, DocumentRequired, Remark, ShelfLife, DocFile1, getdate(), LocalPlace, " + ddlIOMNo.Text + " from OrderHeader where IOMNo = " + ddlIOMNo.Text + ") ");

                        objCommon.ExecuteDMLQuery(@"INSERT INTO OrderItem (IOMNo, ProductId,ProductCode,AlisCode, ProductName, InstRate, Quantity, 
                    BillingRate, Commision, MRP, ProdValue, Tax, EffTax,TaxAmt,TaxValue, TotProductValue, ValuePerProd,TotTaxvalue, LastModify) (select " + IOMNumber + ", ProductId,ProductCode,AlisCode, ProductName, InstRate, Quantity, BillingRate, Commision, MRP, ProdValue, Tax, EffTax,TaxAmt,TaxValue, TotProductValue, ValuePerProd,TotTaxvalue, getdate() from OrderItem where IOMNo = " + ddlIOMNo.Text + ")");

                        objCommon.ExecuteDMLQuery(@"INSERT INTO ScheduleDetail(IOMNo, MaterialCode, OrderQuantity, ScheduleDate, DeliveryDate, LastModify) 
                    (select " + IOMNumber + ", MaterialCode, OrderQuantity, ScheduleDate, DeliveryDate, getdate() from ScheduleDetail where IOMNo = " + ddlIOMNo.Text + ")");

                        txtIOMNo.Text = IOMNumber.ToString();
                        BindDistinctIOMNo();
                                                
                        // load here grid
                        bindgridafternewiomnno();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select IOM Number!");
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCopyOrder btnCopyIOMNo_Click \n" + ex.ToString();
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

        private void ddlIOMNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlIOMNo.SelectedIndex != 0)
                {
                    objC = new CommonFunction();
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, (case when OrderHeader.SubInstitution is not null then (select Name from SubInstitutionMaster where OrderHeader.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution, MRP, Remark, DocFile1 from OrderHeader where IOMNo = " + ddlIOMNo.Text + " order by OrderHeaderId desc");
                    dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable;
                    dgvOrderMaster.DataSource = bindingSource;
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

        public void bindgridafternewiomnno()
        {

            try
            {
                    objC = new CommonFunction();
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, (case when OrderHeader.SubInstitution is not null then (select Name from SubInstitutionMaster where OrderHeader.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution, MRP, Remark, DocFile1 from OrderHeader where IOMNo = " + txtIOMNo.Text + " order by OrderHeaderId desc");
                    dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable;
                    dgvOrderMaster.DataSource = bindingSource;
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


    }
}
