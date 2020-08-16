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
    public partial class filterPendingReport : Form
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

        public filterPendingReport()
        {
            InitializeComponent();

            CommonFunction objCommon = new CommonFunction();
            CommDT = objCommon.GetDataTable(ConfigurationSettings.AppSettings["PendingReport"].ToString());
            bindIOMNo();
            BindPartyCode();
            BindDSMZSM();
            BindPartyName();
            //execQuery();
        }

        protected void execQuery(string strQuery)
        {
            try
            {
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter(strQuery.ToString());  //objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["PendingReport"].ToString());
                txtQuery.Text = strQuery.ToString();    //ConfigurationSettings.AppSettings["PendingReport"].ToString();
                lblReportName.Text = "PendingReport";
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
                MessageBox.Show("Pending Report not get Executed!");
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

        private void BindPartyName()
        {
            try
            {
                DataTable uniqueCols = CommDT.DefaultView.ToTable(true, "PartyName", "PartyCode");
                listPartyName.DataSource = uniqueCols;
                listPartyName.DisplayMember = "PartyName";
                listPartyName.ValueMember = "PartyCode";

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
                string Query = "select * from ( " + ConfigurationSettings.AppSettings["PendingReport"].ToString() + " ) as a ";
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

                if (chkPartyName.Checked)
                {
                    StringBuilder strPartyName = new StringBuilder();
                    foreach (DataRowView objDataRowView in listPartyName.SelectedItems)
                    {
                        if (strPartyName.ToString() != "")
                        {
                            strPartyName.Append(", ");
                        }
                        strPartyName.Append("'" + objDataRowView["PartyCode"].ToString() + "'");
                    }
                    if (strPartyName.ToString() != "")
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");
                        strWhere.Append(" a.PartyCode IN (" + strPartyName + ") ");
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
                            strWhere.Append(" a.DelDate between '" + DateTime.Parse(dtpFromDeliveryDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpToDeliveryDate.Text, dateformat) + "' ");
                        }
                        else
                        {
                            strWhere.Append(" a.DelDate between '" + DateTime.Parse(dtpFromDeliveryDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpToDeliveryDate.Text).ToString(_dateformat) + "' ");
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
                            strWhere.Append(" a.OrderAuthoDate between '" + DateTime.Parse(dtpFromAuthDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpToAuthDate.Text, dateformat) + "' ");
                        }
                        else
                        {
                            strWhere.Append(" a.OrderAuthoDate between '" + DateTime.Parse(dtpFromAuthDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpToAuthDate.Text).ToString(_dateformat) + "' ");
                        }
                    }
                }

                if (chkAuthorised.Checked)
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    if (chkAuth.Checked)
                        strWhere.Append(" a.Authorised = 1 ");
                    else
                        strWhere.Append(" a.Authorised = 0 ");
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
                    MessageBox.Show("Pending Report Query Not Get Executed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pending Report Query not get Executed!");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            execQuery(ConfigurationSettings.AppSettings["PendingReport"].ToString());
        }

    }
}
