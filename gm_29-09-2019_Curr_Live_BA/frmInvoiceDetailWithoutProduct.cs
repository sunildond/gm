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
    public partial class frmInvoiceDetailWithoutProduct : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        private string _dateformat = "MM/dd/yyyy";
        public string dtFormat = string.Empty;
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        DataTable CommDT = new DataTable();
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        //private String selectQueryString = null;
        private int id;
        private int UserId = 0;

        public frmInvoiceDetailWithoutProduct()
        {
            InitializeComponent();

            CommonFunction objCommon = new CommonFunction();
            CommDT = objCommon.GetDataTable(ConfigurationSettings.AppSettings["InvoiceDetailWithoutProduct"].ToString());
            bindIOMNo();
            BindPartyCode();
            BindSTNNo();
            BindLocationCode();
            BindPartyName();
            //execQuery();
        }

        protected void execQuery(string strQuery)
        {
            try
            {
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter(strQuery.ToString());  //objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["InvoiceDetailWithoutProduct"].ToString());
                txtQuery.Text = strQuery.ToString();    //ConfigurationSettings.AppSettings["InvoiceDetailWithoutProduct"].ToString();
                lblReportName.Text = "InvoiceDetailWithoutProduct";
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
                MessageBox.Show("Invoice Detail Without Product Query not get Executed!");
            }
        }

        private void bindIOMNo()
        {
            try
            {
                //DataTable dt = new DataTable();
                //CommonFunction objCommon = new CommonFunction();
                //dt = objCommon.GetDataTable(ConfigurationSettings.AppSettings["InvoiceDetailWithoutProduct"].ToString());
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                DataTable uniqueCols = CommDT.DefaultView.ToTable(true, "IOMNo");
                listIOMNO.DataSource = uniqueCols;
                listIOMNO.DisplayMember = "IOMNo";
                listIOMNO.ValueMember = "IOMNo";

            }
            catch (Exception ex)
            {
                //StreamWriter swLog = File.AppendText(strLogFileName);
                //string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindOrderType \n" + ex.ToString();
                //swLog.WriteLine(strError);
                //swLog.WriteLine();
                //swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //StreamWriter swLog = File.AppendText(strLogFileName);
                //string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindPartyCode \n" + ex.ToString();
                //swLog.WriteLine(strError);
                //swLog.WriteLine();
                //swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BindSTNNo()
        {
            try
            {
                DataTable uniqueCols = CommDT.DefaultView.ToTable(true, "STNNO");
                listSTNNo.DataSource = uniqueCols;
                listSTNNo.DisplayMember = "STNNO";
                listSTNNo.ValueMember = "STNNO";

            }
            catch (Exception ex)
            {
                //StreamWriter swLog = File.AppendText(strLogFileName);
                //string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindPartyCode \n" + ex.ToString();
                //swLog.WriteLine(strError);
                //swLog.WriteLine();
                //swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindLocationCode()
        {
            try
            {
                //DataTable dt = new DataTable();
                //CommonFunction objCommon = new CommonFunction();
                cmdLocationCode.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmdLocationCode.AutoCompleteMode = AutoCompleteMode.Suggest;
                //dt = objCommon.GetDataTable(ConfigurationSettings.AppSettings["InvoiceDetailWithoutProduct"].ToString());
                DataTable uniqueCols = CommDT.DefaultView.ToTable(true, "LocationCode");
                cmdLocationCode.DataSource = uniqueCols;
                cmdLocationCode.DisplayMember = "LocationCode";
                cmdLocationCode.ValueMember = "LocationCode";


            }
            catch (Exception ex)
            {
                //StreamWriter swLog = File.AppendText(strLogFileName);
                //string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindPartyCode \n" + ex.ToString();
                //swLog.WriteLine(strError);
                //swLog.WriteLine();
                //swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "select * from ( " + ConfigurationSettings.AppSettings["InvoiceDetailWithoutProduct"].ToString() + " ) as a ";
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

                if (chkSTNNo.Checked)
                {
                    StringBuilder strSTNNo = new StringBuilder();
                    foreach (DataRowView objDataRowView in listSTNNo.SelectedItems)
                    {
                        if (strSTNNo.ToString() != "")
                        {
                            strSTNNo.Append(", ");
                        }
                        strSTNNo.Append(objDataRowView["STNNO"].ToString());
                    }
                    if (strSTNNo.ToString() != "")
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");
                        strWhere.Append(" a.STNNO IN (" + strSTNNo + ") ");
                    }
                }

                if (chkLocation.Checked)
                {
                    if (cmdLocationCode.SelectedValue.ToString() != "")
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");
                        strWhere.Append(" a.LocationCode = '" + cmdLocationCode.SelectedValue.ToString() + "' ");
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

                if (chkSTNINVAuthDate.Checked)
                {
                    if (dtpFromAuthDate.Checked == true && dtpToAuthDate.Checked == true)
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");

                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            strWhere.Append(" a.STNAuthDate between '" + DateTime.Parse(dtpFromAuthDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpToAuthDate.Text, dateformat) + "' ");
                            strWhere.Append(" or a.INVAuthDate between '" + DateTime.Parse(dtpFromAuthDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpToAuthDate.Text, dateformat) + "' ");
                        }
                        else
                        {
                            strWhere.Append(" a.STNAuthDate between '" + DateTime.Parse(dtpFromAuthDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpToAuthDate.Text).ToString(_dateformat) + "' ");
                            strWhere.Append(" or a.INVAuthDate between '" + DateTime.Parse(dtpFromAuthDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpToAuthDate.Text).ToString(_dateformat) + "' ");
                        }
                    }
                }

                if (chkSTNAuthDate.Checked)
                {
                    if (dtpFromSTNAuthDate.Checked == true && dtpToSTNAuthDate.Checked == true)
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");

                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            strWhere.Append(" a.STNAuthDate between '" + DateTime.Parse(dtpFromSTNAuthDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpToSTNAuthDate.Text, dateformat) + "' ");
                            //strWhere.Append(" or a.INVAuthDate between '" + DateTime.Parse(dtpFromAuthDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpToAuthDate.Text, dateformat) + "' ");
                        }
                        else
                        {
                            strWhere.Append(" a.STNAuthDate between '" + DateTime.Parse(dtpFromSTNAuthDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpToSTNAuthDate.Text).ToString(_dateformat) + "' ");
                            //strWhere.Append(" or a.INVAuthDate between '" + DateTime.Parse(dtpFromAuthDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpToAuthDate.Text).ToString(_dateformat) + "' ");
                        }
                    }
                }

                if (chkINVAuthDate.Checked)
                {
                    if (dtpFromINVAuthDate.Checked == true && dtpToINVAuthDate.Checked == true)
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");

                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            strWhere.Append(" a.INVAuthDate between '" + DateTime.Parse(dtpFromINVAuthDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpToINVAuthDate.Text, dateformat) + "' ");
                        }
                        else
                        {
                            strWhere.Append(" a.INVAuthDate between '" + DateTime.Parse(dtpFromINVAuthDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpToINVAuthDate.Text).ToString(_dateformat) + "' ");
                        }
                    }
                }

                if (chkInvoiceDate.Checked)
                {
                    if (dtpFromInvoiceDate.Checked == true && dtpToInvoiceDate.Checked == true)
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");

                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            strWhere.Append(" a.InvoiceDate between '" + DateTime.Parse(dtpFromInvoiceDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpToInvoiceDate.Text, dateformat) + "' ");
                        }
                        else
                        {
                            strWhere.Append(" a.InvoiceDate between '" + DateTime.Parse(dtpFromInvoiceDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpToInvoiceDate.Text).ToString(_dateformat) + "' ");
                        }
                    }
                }

                if (chkSTNDate.Checked)
                {
                    if (dtpSTNFromDate.Checked == true && dtpSTNToDate.Checked == true)
                    {
                        if (strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");

                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            strWhere.Append(" a.STNDate between '" + DateTime.Parse(dtpSTNFromDate.Text, dateformat) + "' and '" + DateTime.Parse(dtpSTNToDate.Text, dateformat) + "' ");
                        }
                        else
                        {
                            strWhere.Append(" a.STNDate between '" + DateTime.Parse(dtpSTNFromDate.Text).ToString(_dateformat) + "' and '" + DateTime.Parse(dtpSTNToDate.Text).ToString(_dateformat) + "' ");
                        }
                    }
                }

                //if (chkIsAuthorised.Checked)
                //{
                //    if (strWhere.ToString().Trim() != "")
                //        strWhere.Append(" and ");
                //    strWhere.Append(" a.Authorised = 1 ");
                //}

                //if (chkOrderAuthDate.Checked)
                //{
                //    if (dtpDate.Checked == true && dtpTO.Checked == true)
                //    {
                //        if (strWhere.ToString().Trim() != "")
                //            strWhere.Append(" and ");

                //        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                //        {
                //            strWhere.Append(" OrderHeader.OrderAuthoDate between " + DateTime.Parse(dtpDate.Text, dateformat) + " and " + DateTime.Parse(dtpTO.Text, dateformat) + " ");
                //        }
                //        else
                //        {
                //            strWhere.Append(" OrderHeader.OrderAuthoDate between " + DateTime.Parse(dtpDate.Text).ToString(_dateformat) + " and " + DateTime.Parse(dtpTO.Text).ToString(_dateformat) + " ");
                //        }
                //    }
                //}

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
                MessageBox.Show("Invoice Detail Without Product Query not get Executed!");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            execQuery(ConfigurationSettings.AppSettings["InvoiceDetailWithoutProduct"].ToString());
        }

        private void chkPartyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (chkPartyCode.SelectedValue.ToString() != "")
                //{
                //    CommonFunction objCF = new CommonFunction();
                //    DataTable dTable = objCF.GetDataTable("select top 1 * from CustomerMaster where CustomerCode = '" + chkPartyCode.SelectedValue.ToString() + "'");
                //    if (dTable.Rows[0]["Name"].ToString() == "" || dTable.Rows[0]["Name"].ToString() == null)
                //    {
                //        lblPartyName.Text = "";
                //    }
                //    else
                //    {
                //        lblPartyName.Text = dTable.Rows[0]["Name"].ToString();
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
        }



    }
}
