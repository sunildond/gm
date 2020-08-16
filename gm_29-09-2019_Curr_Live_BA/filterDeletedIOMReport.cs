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
    public partial class filterDeletedIOMReport : Form
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
        public string DeletedIOMQuery = @"select oh.IOMNo,oh.IOMDate,oh.OrderAuthoDate, oh.PartyCode,oh.PartyName, oh.DSM_ZSM,oh.DispThrough,oh.InstPONo,oh.InstPODate,oh.OrderRecieveDate,oh.OrderDeliveryDate,
oh.Schedule,(case when oh.Institution is not null then (select Name from InstitutionMaster where oh.Institution = InstitutionMaster.Code) end) Institution,
(case when oh.SubInstitution is not null then (select Name from SubInstitutionMaster where oh.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution,
oi.ProductCode,oi.ProductName,oi.Quantity,oi.BillingRate,oi.MRP,oi.EffTax,oi.ProdValue,oh.BillingAddress,oh.DeliveryAddress, sm.Name as Stamping,oh.DocFile1,
oh.MRP as MRPyn,oh.Lisioner,oh.Remark, 
(select SUBSTRING((select ', ' + Name from DOC_REQ_Master where Code in (select * from fnListToTable(oh.DocumentRequired)) for xml path('')),3,1000)) as DocumentRequired
from DeletedOrderHeader oh, DeletedOrderItem oi, StampingMaster sm where oh.IOMNo=oi.IOMNo and oh.StampingID=sm.StampingId and oh.Schedule = 'No'
union all
select oh.IOMNo,oh.IOMDate,oh.OrderAuthoDate, oh.PartyCode,oh.PartyName, oh.DSM_ZSM,oh.DispThrough,oh.InstPONo,oh.InstPODate,oh.OrderRecieveDate,sd.ScheduleDate as OrderDeliveryDate,
oh.Schedule,(case when oh.Institution is not null then (select Name from InstitutionMaster where oh.Institution = InstitutionMaster.Code) end) Institution,
(case when oh.SubInstitution is not null then (select Name from SubInstitutionMaster where oh.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution,
oi.ProductCode,oi.ProductName,sd.OrderQuantity,oi.BillingRate,oi.MRP,oi.EffTax,oi.ProdValue,oh.BillingAddress,oh.DeliveryAddress, sm.Name as Stamping,oh.DocFile1,
oh.MRP as MRPyn,oh.Lisioner,oh.Remark, (select SUBSTRING((select ', ' + Name from DOC_REQ_Master where Code in (select * from fnListToTable(oh.DocumentRequired)) for xml path('')),3,1000)) as DocumentRequired 
from DeletedOrderHeader oh, DeletedOrderItem oi, DeletedScheduleDetail sd, StampingMaster sm where oh.IOMNo=oi.IOMNo and oh.StampingID=sm.StampingId
and oh.Schedule = 'Yes'";

        public filterDeletedIOMReport()
        {
            InitializeComponent();

            CommonFunction objCommon = new CommonFunction();
            CommDT = objCommon.GetDataTable(DeletedIOMQuery);
            bindIOMNo();
            BindPartyCode();
            BindDSMZSM();
            //execQuery();
        }

        protected void execQuery(string strQuery)
        {
            try
            {
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter(strQuery.ToString());
                txtQuery.Text = strQuery.ToString();
                lblReportName.Text = "DeletedIOMReport";
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
                MessageBox.Show("Deleted IOM Report not get Executed!");
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

        private void BindDSMZSM()
        {
            try
            {
                DataTable uniqueCols = CommDT.DefaultView.ToTable(true, "DSM_ZSM");
                listDSM_ZSM.DataSource = uniqueCols;
                listDSM_ZSM.DisplayMember = "DSM_ZSM";
                listDSM_ZSM.ValueMember = "DSM_ZSM";

            }
            catch (Exception ex)
            {

            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "select * from ( " + DeletedIOMQuery + " ) as a ";
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

                if (chkDSMZSM.Checked)
                {
                    StringBuilder strDSMZSM = new StringBuilder();
                    foreach (DataRowView objDataRowView in listDSM_ZSM.SelectedItems)
                    {
                        if (strDSMZSM.ToString() != "")
                        {
                            strDSMZSM.Append(", ");
                        }
                        strDSMZSM.Append("'" + objDataRowView["DSM_ZSM"].ToString() + "'");
                    }
                    if (strDSMZSM.ToString() != "")
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");
                        strWhere.Append(" a.DSM_ZSM IN (" + strDSMZSM + ") ");
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

                if (chkAuthDate.Checked)
                {
                    if (dtpFromAuthDate.Checked == true && dtpToAuthDate.Checked == true)
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");

                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            strWhere.Append(" a.AuthrisationDate between '" + DateTime.Parse(dtpFromAuthDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpToAuthDate.Text, dateformat) + "' ");
                        }
                        else
                        {
                            strWhere.Append(" a.AuthrisationDate between '" + DateTime.Parse(dtpFromAuthDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpToAuthDate.Text).ToString(_dateformat) + "' ");
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            execQuery(DeletedIOMQuery);        
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
                MessageBox.Show("Deleted IOM Report Query not get Executed!");
            }
        }

    }
}
