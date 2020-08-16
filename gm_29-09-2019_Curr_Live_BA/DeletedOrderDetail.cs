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

namespace GlanMark
{
    public partial class DeletedOrderDetail : Form
    {
        CommonFunction objC = null;
        private SqlConnection objConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        private string _dateformat = "MM/dd/yyyy";
        string strLogFileName = "LOG/LogRecord.txt";
        int flag;

        public DeletedOrderDetail()
        {
            InitializeComponent();
            chkAuthorize.Enabled = false;
        }

        public DeletedOrderDetail(int Orderheaderid, int i)
        {
            InitializeComponent();
            flag = i;
            BindDeletedOrder(Orderheaderid);

            if (flag == 0)
            {
                chkAuthorize.Visible = false;
            }

            if (DBSessionUser.bIsAuthorise == true)
            {
                chkAuthorize.Visible = true;
            }
            else
            {
                chkAuthorize.Visible = false;
            }

            if (DBSessionUser.strName.ToLower() == "admin")
            {
                chkAuthorize.Visible = true;
            }
            //else
            //{
            //    chkAuthorize.Visible = false;
            //}
        }

        public void BindDeletedOrder(int Orderheaderid)
        {
            try
            {
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter(@"select (case when DeletedOrderHeader.Institution is not null then 
(select Name from InstitutionMaster where InstitutionMaster.Code = DeletedOrderHeader.Institution) end) InstitutionName,

(case when DeletedOrderHeader.SubInstitution is not null then 
(select Name from SubInstitutionMaster where SubInstitutionMaster.Code = DeletedOrderHeader.SubInstitution) end) SubInstitutionName,

(case when DeletedOrderHeader.OrderType is not null then 
(select OrderTypeName from OrderTypeMaster where OrderTypeMaster.ID = DeletedOrderHeader.OrderType) end) OrderTypeName,

(case when DeletedOrderHeader.ShelfLife is not null then 
(select ShelfLifeName from ShelfLifeMaster where ShelfLifeMaster.ShelfLifeId = DeletedOrderHeader.ShelfLife) end) ShelfLifeName,

(case when DeletedOrderHeader.StampingID is not null then 
(select Name + ' (' + Code + ')' from StampingMaster where StampingMaster.StampingId = DeletedOrderHeader.StampingID) end) StampingName,
 * 
from DeletedOrderHeader where DeletedOrderHeader.OrderHeaderId ='" + Orderheaderid + "'");

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                lblOrderType.Text = dataTable.Rows[0]["OrderTypeName"].ToString();
                lblOrderRecievedate.Text = string.Format("{0:dd/MM/yyyy}", dataTable.Rows[0]["OrderRecieveDate"]);
                lblIOMNO.Text = dataTable.Rows[0]["IOMNo"].ToString();
                lblIOMDate.Text = string.Format("{0:dd/MM/yyyy}", dataTable.Rows[0]["IOMDate"]);
                lblPONO.Text = dataTable.Rows[0]["InstPONo"].ToString();
                lblPODate.Text = string.Format("{0:dd/MM/yyyy}", dataTable.Rows[0]["InstPODate"]);
                lblPartyName.Text = dataTable.Rows[0]["PartyName"].ToString();
                lblPartyCode.Text = dataTable.Rows[0]["PartyCode"].ToString();
                lblDispatchThrough.Text = dataTable.Rows[0]["DispThrough"].ToString();
                lblLocationCode.Text = dataTable.Rows[0]["LocationCode"].ToString();
                lblInstitution.Text = dataTable.Rows[0]["InstitutionName"].ToString();
                lblSubInstitution.Text = dataTable.Rows[0]["SubInstitutionName"].ToString();
                lblLisioner.Text = dataTable.Rows[0]["Lisioner"].ToString();
                lblZSM.Text = dataTable.Rows[0]["DSM_ZSM"].ToString();
                lblShelflife.Text = dataTable.Rows[0]["ShelfLifeName"].ToString();
                lblStamping.Text = dataTable.Rows[0]["StampingName"].ToString();
                lblTaxIndicator.Text = dataTable.Rows[0]["TaxIndicator"].ToString();
                lblTaxOn.Text = dataTable.Rows[0]["TaxOn"].ToString();
                lblSchedule.Text = dataTable.Rows[0]["Schedule"].ToString();
                //if (dataTable.Rows[0]["Schedule"].ToString() == "No")
                //{

                //}
                lblMRP.Text = dataTable.Rows[0]["MRP"].ToString();
                lblLST_CST.Text = dataTable.Rows[0]["LST_CST"].ToString();
                lblBillingadd.Text = dataTable.Rows[0]["BillingAddress"].ToString();
                lblDeliveryadd.Text = dataTable.Rows[0]["DeliveryAddress"].ToString();
                lblDeliveryDate.Text = string.Format("{0:dd/MM/yyyy}", dataTable.Rows[0]["OrderDeliveryDate"].ToString());
                //lblCommision.Text = dataTable.Rows[0]["Commission"].ToString();
                lblRemarks.Text = dataTable.Rows[0]["Remark"].ToString();
                lblOrderHeaderId.Text = Orderheaderid.ToString();

                if (dataTable.Rows[0]["DocFile1"].ToString() != "")
                    lnkDocFile.Text = dataTable.Rows[0]["DocFile1"].ToString();
                else
                    lnkDocFile.Text = "Document Not Available";

                if (dataTable.Rows[0]["DocumentRequired"].ToString() != "")
                {
                    DataTable dtDocreq = objC.GetDataTable("select Name from DOC_REQ_Master where Code IN (" + dataTable.Rows[0]["DocumentRequired"].ToString() + ")");
                    for (int i = 0; i < dtDocreq.Rows.Count; i++)
                    {
                        if (lblDocRequired.Text != "")
                            lblDocRequired.Text += " ,";
                        lblDocRequired.Text += dtDocreq.Rows[i]["Name"].ToString();
                    }
                }
                else
                {
                    lblDocRequired.Text = "No Document";
                }

                if (dataTable.Rows[0]["Authorised"].ToString() == "True")
                {
                    chkAuthorize.Checked = true;
                }
                else
                {
                    chkAuthorize.Checked = false;
                }

                BindProductSchedule(Convert.ToInt32(dataTable.Rows[0]["IOMNo"].ToString()));
            }

            catch (Exception ex)
            {

            }
        }

        private void BindProductSchedule(int IOMNo)
        {
            try
            {
                //106754
                //lblSchOrderID.Text = IOMNo.ToString();
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select IOMID,IOMNo,ProductCode,AlisCode,ProductName,InstRate, Quantity,BillingRate,Commision,MRP,ProdValue,Tax,TaxValue from OrderItem where IOMNo = " + IOMNo);
                sqlDataAdapter = objC.GetSqlDataAdapter("select IOMID,IOMNo,ProductCode,AlisCode,(case when DeletedOrderItem.AlisCode is not null then (select AliasName from ProductMaster where DeletedOrderItem.ProductId = ProductMaster.ProductId) end) AliasName,InstRate, Quantity,BillingRate,Commision,MRP,ProdValue,Tax,TaxValue,ProductName from DeletedOrderItem where IOMNo = " + IOMNo);

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvProdSchedule.DataSource = bindingSource;
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvProdSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int IOMID = 0; int IOMNo = 0;
                if (e.RowIndex != -1)
                {
                    IOMID = int.Parse(dgvProdSchedule.Rows[e.RowIndex].Cells["colIOMID"].Value.ToString());
                    IOMNo = int.Parse(dgvProdSchedule.Rows[e.RowIndex].Cells["colIOMNo"].Value.ToString());

                    if (e.ColumnIndex == dgvProdSchedule.Columns["colSchedule"].Index)
                    {
                        lblProdCode.Text = dgvProdSchedule[dgvProdSchedule.Columns["colProductCode"].Index, e.RowIndex].Value.ToString();
                        //lblProdIOMNo.Text = dgvProdSchedule[dgvProdSchedule.Columns["colIOMNo"].Index, e.RowIndex].Value.ToString();
                        lblSchOrderID.Text = dgvProdSchedule[dgvProdSchedule.Columns["colIOMNo"].Index, e.RowIndex].Value.ToString();
                        lblOrderTotalQuantity.Text = dgvProdSchedule[dgvProdSchedule.Columns["colQuantity"].Index, e.RowIndex].Value.ToString();
                        BindOrderItemSchedule(Convert.ToInt32(dgvProdSchedule[dgvProdSchedule.Columns["colIOMNo"].Index, e.RowIndex].Value), dgvProdSchedule[dgvProdSchedule.Columns["colProductCode"].Index, e.RowIndex].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BindOrderItemSchedule(int IOMNo, string prodCode)
        {
            try
            {
                //106754
                //lblSchOrderID.Text = IOMNo.ToString();
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("select IOMNo,MaterialCode,OrderQuantity,ScheduleDate,DeliveryDate from DeletedScheduleDetail where IOMNo = '" + IOMNo + "' and MaterialCode='" + prodCode + "'");

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvOrderItemSchedule.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkDocFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string FileName = lnkDocFile.Text;

            if (FileName != "Document Not Available")
            {
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
}
