using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ww_admin;
using ww_lib;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace GlanMark
{
    public partial class frmDeliveryCompletedForceFully : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        private string _dateformat = "MM/dd/yyyy";
        public string dtFormat = string.Empty;
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        DataTable CommDT = new DataTable();
        private BindingSource bindingSource = null;
        //private String selectQueryString = null;
        private int id;
        private int UserId = 0;
        string OrgQuery = "";

        public frmDeliveryCompletedForceFully()
        {
            InitializeComponent();
            OrgQuery = "select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode, ot.ProductName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity, oh.DispThrough, oh.MRP, sm.Name as StampingName, ot.BillingRate, ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue, ot.AlisCode, 0 as ScheduleID, ot.Reason,ot.Remark as PendingRemark ,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate, oh.DocFile1, ot.CloseDate from OrderHeader as oh ,OrderItem as ot , StampingMaster as sm where oh.IOMNo=ot.IOMNo and oh.StampingID=sm.StampingId and ot.IsDeliveryCompleted=1 and ot.DispatchQuantity = 0";
            CommonFunction objCommon = new CommonFunction();
            CommDT = objCommon.GetDataTable(OrgQuery);
            bindIOMNo();
            BindPartyCode();
            //execQuery();
        }

        protected void execQuery(string strQuery)
        {
            try
            {
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter(strQuery.ToString());  //objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["IOMReport"].ToString());
                txtQuery.Text = strQuery.ToString();    //ConfigurationSettings.AppSettings["IOMReport"].ToString();
                lblReportName.Text = "DeliveryCompletedForceFully";
                DataTable dtQuery = new DataTable();
                sqlDataAdapter.Fill(dtQuery);
                bindingSource = new BindingSource();
                //var query = dtQuery.AsEnumerable().Where(c => c.Field<String>("LastName").StartsWith("B")); 
                bindingSource.DataSource = dtQuery;
                dgvQueryExec.DataSource = bindingSource;
                lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Delivery Completed Force Fully not get Executed!");
            }
        }

        private void bindIOMNo()
        {
            try
            {
                DataTable uniqueCols = CommDT.DefaultView.ToTable(true, "IOMNo");
                listIOMNO.DataSource = uniqueCols;
                listIOMNO.DisplayMember = "IOMNo";
                listIOMNO.ValueMember = "IOMNo";
            }
            catch (Exception ex)
            {

            }
        }

        private void BindPartyCode()
        {
            try
            {
                DataTable uniqueCols = CommDT.DefaultView.ToTable(true, "PartyCode");
                listPartyCode.DataSource = uniqueCols;
                listPartyCode.DisplayMember = "PartyCode";
                listPartyCode.ValueMember = "PartyCode";

            }
            catch (Exception ex)
            {

            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "select * from ( " + OrgQuery + " ) as a ";
                StringBuilder strQuery = new StringBuilder();
                StringBuilder strWhere = new StringBuilder();
                if (chkIomNo.Checked)
                {
                    StringBuilder strIOM = new StringBuilder();
                    foreach (DataRowView objDataRowView in listIOMNO.SelectedItems)
                    {
                        if (strIOM.ToString() != "")
                        {
                            strIOM.Append(", ");
                        }
                        strIOM.Append(objDataRowView["IOMNo"].ToString());
                    }
                    if (strIOM.ToString() != "")
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");
                        strWhere.Append(" a.IOMNo IN (" + strIOM + ") ");
                    }
                }

                if (chkPartyCode.Checked)
                {
                    StringBuilder strPartyCode = new StringBuilder();
                    foreach (DataRowView objDataRowView in listPartyCode.SelectedItems)
                    {
                        if (strPartyCode.ToString() != "")
                        {
                            strPartyCode.Append(", ");
                        }
                        strPartyCode.Append("'" + objDataRowView["PartyCode"].ToString() + "'");
                    }
                    if (strPartyCode.ToString() != "")
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");
                        strWhere.Append(" a.PartyCode IN (" + strPartyCode + ") ");
                    }
                }

                if (chkIOMDate.Checked)
                {
                    if (dtpFromIOMDate.Checked == true && dtpToIOMDate.Checked == true)
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");

                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            strWhere.Append(" a.IOMDate between '" + DateTime.Parse(dtpFromIOMDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpToIOMDate.Text, dateformat) + "' ");
                        }
                        else
                        {
                            strWhere.Append(" a.IOMDate between '" + DateTime.Parse(dtpFromIOMDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpToIOMDate.Text).ToString(_dateformat) + "' ");
                        }
                    }
                }

                if (chkDeliveryDate.Checked)
                {
                    if (dtpFromDeliveryDate.Checked == true && dtpToDeliveryDate.Checked == true)
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");

                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            strWhere.Append(" a.DeliveryDate between '" + DateTime.Parse(dtpFromDeliveryDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpToDeliveryDate.Text, dateformat) + "' ");
                        }
                        else
                        {
                            strWhere.Append(" a.DeliveryDate between '" + DateTime.Parse(dtpFromDeliveryDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpToDeliveryDate.Text).ToString(_dateformat) + "' ");
                        }
                    }
                }

                if (strWhere.ToString().Trim() != "")
                {
                    strQuery.Append(Query + " WHERE " + strWhere.ToString());
                }
                else
                {
                    strQuery.Append(Query);
                }

                execQuery(strQuery.ToString());

            }
            catch (Exception ex)
            {

            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQuery.Text != "")
                {
                    CommonFunction objCF = new CommonFunction();
                    objCF.fn_ExportToExcel(txtQuery.Text, lblReportName.Text, lblReportName.Text);
                }
                else
                {
                    MessageBox.Show("Query Not Get Executed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("IOM Report Query not get Executed!");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            execQuery(OrgQuery);
        }
        




    }
}
