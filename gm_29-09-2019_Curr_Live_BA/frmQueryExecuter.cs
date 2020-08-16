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
using System.Globalization;

namespace GlanMark
{
    public partial class frmQueryExecuter : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        
        private string _dateformat = "MM/dd/yyyy";
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");

        CommonFunction objC = null;
        public string dtFormat = string.Empty;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        //private String selectQueryString = null;
        private int id;
        private int UserId = 0;

        // Page
        private int mintTotalRecords = 0;
        private int mintPageSize = 20;
        private int mintPageCount = 0;
        private int mintCurrentPage = 1;

        public frmQueryExecuter()
        {
            InitializeComponent();
        }

        private void frmQueryExecuter_Load(object sender, EventArgs e)
        {
            bindQueryName();
            hideGroupBox();
            /**OrderHeader Binding**/
            bindOrderheaderIOMNo();
            bindOrderheaderPartyCode();
            bindOrderheaderLocationCode();
            /**OrderItem Binding**/
            bindOrderitemIOMNo();
            bindOrderItemAliasCode();
            /**SAP Invoice Binding**/
            bindSAPInvoiceIOMNo();
            bindSAPInvoiceBillingDoc();
            bindSAPInvoiceBatch();
            /**STN Upload Binding**/
            bindSTNUploadIOMNo();
            bindSTNUploadMaterialCode();
            bindSTNUploadBatch();
            /**Invoice Dispatch Binding**/
            bindInvoiceDispatchIOMNo();
            bindInvoiceDispatchBillingDoc();
            /**Batch Allocation Binding**/
            bindBatchIOMNo();
            bindBatchNo();
            bindBatchProductCode();

            dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        }

        private void bindOrderheaderIOMNo()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct IOMNo from orderheader");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                listOrderheaderIOMNO.DataSource = dt;
                listOrderheaderIOMNO.DisplayMember = "IOMNO";
                listOrderheaderIOMNO.ValueMember = "IOMNO";

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
        private void bindOrderheaderPartyCode()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct PartyCode from OrderHeader");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                chkOrderheaderPartyCode.DataSource = dt;
                chkOrderheaderPartyCode.DisplayMember = "PartyCode";
                chkOrderheaderPartyCode.ValueMember = "PartyCode";
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
        private void bindOrderheaderLocationCode()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct LocationCode from OrderHeader");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                chkOrderheaderLocCode.DataSource = dt;
                chkOrderheaderLocCode.DisplayMember = "LocationCode";
                chkOrderheaderLocCode.ValueMember = "LocationCode";
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
       
        private void bindOrderitemIOMNo()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct IOMNo from OrderItem");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                listOrderItemIOMNO.DataSource = dt;
                listOrderItemIOMNO.DisplayMember = "IOMNO";
                listOrderItemIOMNO.ValueMember = "IOMNO";

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
        private void bindOrderItemAliasCode()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct AlisCode from OrderItem");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                cmbOrderItemAliasCode.DataSource = dt;
                cmbOrderItemAliasCode.DisplayMember = "AlisCode";
                cmbOrderItemAliasCode.ValueMember = "AlisCode";
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

        private void bindSAPInvoiceIOMNo()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct IOMNo from SAPInvoiceUpload");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                listSAPinvoiceIOMNO.DataSource = dt;
                listSAPinvoiceIOMNO.DisplayMember = "IOMNO";
                listSAPinvoiceIOMNO.ValueMember = "IOMNO";

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
        private void bindSAPInvoiceBillingDoc()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct BillingDocument from SAPInvoiceUpload");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                cmbSAPBilingDoc.DataSource = dt;
                cmbSAPBilingDoc.DisplayMember = "BillingDocument";
                cmbSAPBilingDoc.ValueMember = "BillingDocument";
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
        private void bindSAPInvoiceBatch()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct Batch from SAPInvoiceUpload");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                cmbSAPBatch.DataSource = dt;
                cmbSAPBatch.DisplayMember = "Batch";
                cmbSAPBatch.ValueMember = "Batch";
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

        private void bindSTNUploadIOMNo()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct IOMNo from STNUpload");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                listSTNUploadIOMNO.DataSource = dt;
                listSTNUploadIOMNO.DisplayMember = "IOMNo";
                listSTNUploadIOMNO.ValueMember = "IOMNo";

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
        private void bindSTNUploadMaterialCode()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct MaterialCode from STNUpload");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                cmbMaterialCode.DataSource = dt;
                cmbMaterialCode.DisplayMember = "MaterialCode";
                cmbMaterialCode.ValueMember = "MaterialCode";
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
        private void bindSTNUploadBatch()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct PartyCode from STNUpload");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                cmbPartyCode.DataSource = dt;
                cmbPartyCode.DisplayMember = "PartyCode";
                cmbPartyCode.ValueMember = "PartyCode";
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

        private void bindInvoiceDispatchIOMNo()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct IOMNo from Invoice_Dispatch");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                listSTNUploadIOMNO.DataSource = dt;
                listSTNUploadIOMNO.DisplayMember = "IOMNo";
                listSTNUploadIOMNO.ValueMember = "IOMNo";

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
        private void bindInvoiceDispatchBillingDoc()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct BillingDocument from Invoice_Dispatch");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                cmbInvoiceBiling.DataSource = dt;
                cmbInvoiceBiling.DisplayMember = "BillingDocument";
                cmbInvoiceBiling.ValueMember = "BillingDocument";
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
        
        private void bindBatchIOMNo()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct IOMNo from BatchAllocation");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                listBatchIOMNO.DataSource = dt;
                listBatchIOMNO.DisplayMember = "IOMNo";
                listBatchIOMNO.ValueMember = "IOMNo";

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
        private void bindBatchNo()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct BatchNo from BatchAllocation");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                cmbBatchNo.DataSource = dt;
                cmbBatchNo.DisplayMember = "BatchNo";
                cmbBatchNo.ValueMember = "BatchNo";
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
        private void bindBatchProductCode()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select distinct ProductCode from BatchAllocation");
                //DataRow dr = dt.NewRow();
                //dr["IOMNO"] = 0;
                //dr["IOMNO"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                cmbBatchProduct.DataSource = dt;
                cmbBatchProduct.DisplayMember = "ProductCode";
                cmbBatchProduct.ValueMember = "ProductCode";
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


        private void hideGroupBox()
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            lblOrderheader.Text = "0";
            lblOrderitem.Text = "0";
            lblSAPINvoice.Text = "0";
            lblSTNUpload.Text = "0";
            lblInvoiceDispatch.Text = "0";
            lblbatchallocation.Text = "0";
        }

        private void bindQueryName()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                ddlQueryName.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlQueryName.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select ID, QueryName from QueryTable order by QueryName asc");
                DataRow dr = dt.NewRow();
                dr["ID"] = 0;
                dr["QueryName"] = "--select--";
                dt.Rows.InsertAt(dr, 0);
                ddlQueryName.DataSource = dt;
                ddlQueryName.DisplayMember = "QueryName";
                ddlQueryName.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmQueryExecuter bindQueryName \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQueryExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlQueryName.SelectedIndex > 0) //Convert.ToString(cmbOrderType.SelectedIndex) != "0"
                {
                    StringBuilder strChkWhere = new StringBuilder();
                    StringBuilder strQuery = new StringBuilder();
                    StringBuilder strWhere=new StringBuilder();
                    CommonFunction objCF = new CommonFunction();
                    dataTable = objCF.GetDataTable("select * from QueryTable where ID = " + ddlQueryName.SelectedValue.ToString());
                    strQuery.Append(dataTable.Rows[0]["Query"].ToString());
                    lblQueryName.Text = dataTable.Rows[0]["QueryName"].ToString();

                    if(lblOrderheader.Text == "1")
                    {
                        strWhere.Append(" " + bindOderheaderWhere().ToString() + " ");
                    }
                    if (lblOrderitem.Text == "1")
                    {
                        strChkWhere = new StringBuilder();
                        strChkWhere.Append(bindOderItemWhere().ToString());

                        if (strChkWhere.ToString().Trim() != "" && strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");
                        strWhere.Append(" " + strChkWhere.ToString() + " ");
                    }
                    if (lblSAPINvoice.Text == "1")
                    {
                        strChkWhere = new StringBuilder();
                        strChkWhere.Append(bindSAPInvoiceWhere().ToString());

                        if (strChkWhere.ToString().Trim() != "" && strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");
                        strWhere.Append(" " + strChkWhere.ToString() + " ");
                    }
                    if (lblSTNUpload.Text == "1")
                    {
                        strChkWhere = new StringBuilder();
                        strChkWhere.Append(bindSTNUploadWhere().ToString());

                        if (strChkWhere.ToString().Trim() != "" && strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");
                        strWhere.Append(" " + strChkWhere.ToString() + " ");
                    }
                    if (lblInvoiceDispatch.Text == "1")
                    {
                        strChkWhere = new StringBuilder();
                        strChkWhere.Append(bindInvoiceDispatchWhere().ToString());

                        if (strChkWhere.ToString().Trim() != "" && strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");
                        strWhere.Append(" " + strChkWhere.ToString() + " ");
                    }
                    if (lblbatchallocation.Text == "1")
                    {
                        strChkWhere = new StringBuilder();
                        strChkWhere.Append(bindBatchAllocationWhere().ToString());

                        if (strChkWhere.ToString().Trim() != "" && strWhere.ToString().Trim() != "")
                            strWhere.Append(" and ");
                        strWhere.Append(" " + strChkWhere.ToString() + " ");
                    }

                    if (strWhere.ToString().Trim() != "")
                    {
                        //strChkWhere = new StringBuilder();

                        if (dataTable.Rows[0]["TableInvolvement"].ToString() == "1")
                        {
                            strQuery.Append(" WHERE " + strWhere.ToString());
                        }
                        else
                        {
                            strQuery.Append(" and " + strWhere.ToString());
                        }
                    }

                    objC = new CommonFunction();
                    //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                    
                    lblHdnQuery.Text = strQuery.ToString();

                    sqlDataAdapter = objC.GetSqlDataAdapter(strQuery.ToString());

                    DataTable dtQuery = new DataTable();
                    sqlDataAdapter.Fill(dtQuery);
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dtQuery;
                    dgvQueryExec.DataSource = bindingSource;
                }
                else
                {
                    MessageBox.Show("Please select Query!");
                }
            }
            catch (Exception ex)
            {
                //StreamWriter swLog = File.AppendText(strLogFileName);
                //string strError = DateTime.Now.ToString() + "\n Main Page/btnQueryExecute_Click \n" + ex.ToString();
                //swLog.WriteLine(strError);
                //swLog.WriteLine();
                //swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                MessageBox.Show("Query not get Executed!");

            }
        }

        private StringBuilder bindOderheaderWhere()
        {
            StringBuilder strWhere = new StringBuilder();
            if (chkIomNo.Checked)
            {
                StringBuilder strIOM = new StringBuilder();
                foreach (DataRowView objDataRowView in listOrderheaderIOMNO.SelectedItems)
                {
                    if (strIOM.ToString() != "")
                    {
                        strIOM.Append(", ");
                    }
                    strIOM.Append(objDataRowView["IOMNO"].ToString());
                }
                if (strIOM.ToString() != "")
                {
                    strWhere.Append(" OrderHeader.IOMNo IN (" + strIOM + ") ");
                }
            }
            if (chkParty.Checked)
            {
                if (chkOrderheaderPartyCode.SelectedValue.ToString() != "") {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    strWhere.Append(" OrderHeader.PartyCode = '" + chkOrderheaderPartyCode.SelectedValue.ToString() + "' ");
                }
            }
            if (chkLocation.Checked)
            {
                if (chkOrderheaderLocCode.SelectedValue.ToString() != "")
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    strWhere.Append(" OrderHeader.LocationCode = '" + chkOrderheaderLocCode.SelectedValue.ToString() + "' ");
                }
            }
            if (chkIsAuthorised.Checked)
            {
                if (strWhere.ToString().Trim() != "")
                    strWhere.Append(" and ");
                strWhere.Append(" OrderHeader.Authorised = 1 ");
            }
            if (chkOrderAuthDate.Checked)
            {
                if (dtpDate.Checked == true && dtpTO.Checked==true)
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");

                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        strWhere.Append(" OrderHeader.OrderAuthoDate between " + DateTime.Parse(dtpDate.Text, dateformat) + " and " + DateTime.Parse(dtpTO.Text, dateformat) + " ");
                    }
                    else
                    {
                        strWhere.Append(" OrderHeader.OrderAuthoDate between " + DateTime.Parse(dtpDate.Text).ToString(_dateformat) + " and " + DateTime.Parse(dtpTO.Text).ToString(_dateformat) + " ");
                    }
                }
            }

            return strWhere;
        }

        private StringBuilder bindOderItemWhere()
        {
            StringBuilder strWhere = new StringBuilder();
            if (chkOrderItemIOMNO.Checked)
            {
                StringBuilder strIOM = new StringBuilder();
                foreach (DataRowView objDataRowView in listOrderItemIOMNO.SelectedItems)
                {
                    if (strIOM.ToString() != "")
                    {
                        strIOM.Append(", ");
                    }
                    strIOM.Append(objDataRowView["IOMNO"].ToString());
                }
                if (strIOM.ToString() != "")
                {
                    strWhere.Append(" OrderItem.IOMNo IN (" + strIOM + ") ");
                }
            }
            if (chkAliseCode.Checked)
            {
                if (cmbOrderItemAliasCode.SelectedValue.ToString() != "")
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    strWhere.Append(" OrderItem.AlisCode = '" + cmbOrderItemAliasCode.SelectedValue.ToString() + "' ");
                }
            }

            if (chkIsdelivery.Checked)
            {
                if (strWhere.ToString().Trim() != "")
                    strWhere.Append(" and ");
                strWhere.Append(" OrderHeader.IsDeliveryCompleted = 1 ");
            }

            return strWhere;
        }

        private StringBuilder bindSAPInvoiceWhere()
        {
            StringBuilder strWhere = new StringBuilder();
            if (chkSAPIOMNO.Checked)
            {
                StringBuilder strIOM = new StringBuilder();
                foreach (DataRowView objDataRowView in listSAPinvoiceIOMNO.SelectedItems)
                {
                    if (strIOM.ToString() != "")
                    {
                        strIOM.Append(", ");
                    }
                    strIOM.Append(objDataRowView["IOMNo"].ToString());
                }
                if (strIOM.ToString() != "")
                {
                    strWhere.Append(" SAPInvoiceUpload.IOMNo IN (" + strIOM + ") ");
                }
            }
            if (chkBillingDoc.Checked)
            {
                if (cmbSAPBilingDoc.SelectedValue.ToString() != "")
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    strWhere.Append(" SAPInvoiceUpload.BillingDocument = '" + cmbSAPBilingDoc.SelectedValue.ToString() + "' ");
                }
            }
            if (chkBatch.Checked)
            {
                if (cmbSAPBatch.SelectedValue.ToString() != "")
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    strWhere.Append(" SAPInvoiceUpload.Batch = '" + cmbSAPBatch.SelectedValue.ToString() + "' ");
                }
            }
            if (chkBillingDate.Checked)
            {
                if (dtpSAPFrom.Checked == true && dtpSAPTo.Checked == true)
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        strWhere.Append(" SAPInvoiceUpload.BillingDate between " + DateTime.Parse(dtpSAPFrom.Text, dateformat) + " and " + DateTime.Parse(dtpSAPTo.Text, dateformat) + " ");
                    }
                    else
                    {
                        strWhere.Append(" SAPInvoiceUpload.BillingDate between " + DateTime.Parse(dtpSAPFrom.Text).ToString(_dateformat) + " and " + DateTime.Parse(dtpSAPTo.Text).ToString(_dateformat) + " ");
                    }

                }
            }
            

            return strWhere;
        }

        private StringBuilder bindSTNUploadWhere()
        {
            StringBuilder strWhere = new StringBuilder();
            if (chkSTNIOMNO.Checked)
            {
                StringBuilder strIOM = new StringBuilder();
                foreach (DataRowView objDataRowView in listSTNUploadIOMNO.SelectedItems)
                {
                    if (strIOM.ToString() != "")
                    {
                        strIOM.Append(", ");
                    }
                    strIOM.Append(objDataRowView["IOMNo"].ToString());
                }
                if (strIOM.ToString() != "")
                {
                    strWhere.Append(" STNUpload.IOMNo IN (" + strIOM + ") ");
                }
            }
            if (chkMaterial.Checked)
            {
                if (cmbMaterialCode.SelectedValue.ToString() != "")
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    strWhere.Append(" STNUpload.MaterialCode = '" + cmbMaterialCode.SelectedValue.ToString() + "' ");
                }
            }
            if (chkPartyCode.Checked)
            {
                if (cmbPartyCode.SelectedValue.ToString() != "")
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    strWhere.Append(" STNUpload.PartyCode = '" + cmbPartyCode.SelectedValue.ToString() + "' ");
                }
            }
            if (chkDelivery.Checked)
            {
                if (dtpSTNFrom.Checked == true && dtpSTNTo.Checked == true)
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        strWhere.Append(" STNUpload.deliverydate between " + DateTime.Parse(dtpSTNFrom.Text, dateformat) + " and " + DateTime.Parse(dtpSTNTo.Text, dateformat) + " ");
                    }
                    else
                    {
                        strWhere.Append(" STNUpload.deliverydate between " + DateTime.Parse(dtpSTNFrom.Text).ToString(_dateformat) + " and " + DateTime.Parse(dtpSTNTo.Text).ToString(_dateformat) + " ");
                    }
                }
            }

            return strWhere;
        }

        private StringBuilder bindInvoiceDispatchWhere()
        {
            StringBuilder strWhere = new StringBuilder();
            if (chkInvoiceIOMNO.Checked)
            {
                StringBuilder strIOM = new StringBuilder();
                foreach (DataRowView objDataRowView in listInvoiceIOMNO.SelectedItems)
                {
                    if (strIOM.ToString() != "")
                    {
                        strIOM.Append(", ");
                    }
                    strIOM.Append(objDataRowView["IOMNo"].ToString());
                }
                if (strIOM.ToString() != "")
                {
                    strWhere.Append(" Invoice_Dispatch.IOMNo IN (" + strIOM + ") ");
                }
            }
            if (chkInvoiceBilling.Checked)
            {
                if (cmbInvoiceBiling.SelectedValue.ToString() != "")
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    strWhere.Append(" Invoice_Dispatch.BillingDocument = '" + cmbInvoiceBiling.SelectedValue.ToString() + "' ");
                }
            }


            return strWhere;
        }

        private StringBuilder bindBatchAllocationWhere()
        {
            StringBuilder strWhere = new StringBuilder();
            if (chkBatchIOMNO.Checked)
            {
                StringBuilder strIOM = new StringBuilder();
                foreach (DataRowView objDataRowView in listBatchIOMNO.SelectedItems)
                {
                    if (strIOM.ToString() != "")
                    {
                        strIOM.Append(", ");
                    }
                    strIOM.Append(objDataRowView["IOMNo"].ToString());
                }
                if (strIOM.ToString() != "")
                {
                    strWhere.Append(" BatchAllocation.IOMNo IN (" + strIOM + ") ");
                }
            }
            if (chkBatchNo.Checked)
            {
                if (cmbBatchNo.SelectedValue.ToString() != "")
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    strWhere.Append(" BatchAllocation.BatchNo = '" + cmbBatchNo.SelectedValue.ToString() + "' ");
                }
            }
            if (chkProductCode.Checked)
            {
                if (cmbBatchProduct.SelectedValue.ToString() != "")
                {
                    if (strWhere.ToString().Trim() != "")
                        strWhere.Append(" and ");
                    strWhere.Append(" BatchAllocation.ProductCode = '" + cmbBatchProduct.SelectedValue.ToString() + "' ");
                }
            }


            return strWhere;
        }

        private void ddlQueryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlQueryName.SelectedIndex > 0) //Convert.ToString(cmbOrderType.SelectedIndex) != "0"
                {
                    DataTable dt = new DataTable();
                    CommonFunction objCommon = new CommonFunction();

                    ddlQueryName.AutoCompleteSource = AutoCompleteSource.ListItems;
                    ddlQueryName.AutoCompleteMode = AutoCompleteMode.Suggest;

                    dt = objCommon.GetDataTable("select QueryName,Query,TableNames from QueryTable where ID=" + ddlQueryName.SelectedValue.ToString());
                    string[] arrTablename = dt.Rows[0]["TableNames"].ToString().Split(',');
                    lblCount.Text = arrTablename.Length.ToString();
                    hideGroupBox();
                    for (int i = 0; i < arrTablename.Length; i++)
                    {
                        if (arrTablename[i].ToString().Trim() == "OrderHeader")
                        {
                            groupBox1.Visible = true;
                            lblOrderheader.Text = "1";
                        }
                        if (arrTablename[i].ToString().Trim() == "OrderItem")
                        {
                            groupBox2.Visible = true;
                            lblOrderitem.Text = "1";
                        }
                        if (arrTablename[i].ToString().Trim() == "SAPInvoiceUpload")
                        {
                            groupBox3.Visible = true;
                            lblSAPINvoice.Text = "1";
                        }
                        if (arrTablename[i].ToString().Trim() == "STNUpload")
                        {
                            groupBox4.Visible = true;
                            lblSTNUpload.Text = "1";
                        }
                        if (arrTablename[i].ToString().Trim() == "Invoice_Dispatch")
                        {
                            groupBox5.Visible = true;
                            lblInvoiceDispatch.Text = "1";
                        }
                        if (arrTablename[i].ToString().Trim() == "BatchAllocation")
                        {
                            groupBox6.Visible = true;
                            lblbatchallocation.Text = "1";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ////StreamWriter swLog = File.AppendText(strLogFileName);
                ////string strError = DateTime.Now.ToString() + "\n Main Page/frmQueryExecuter bindQueryName \n" + ex.ToString();
                ////swLog.WriteLine(strError);
                ////swLog.WriteLine();
                ////swLog.Close();
                ////MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            CommonFunction objCF = new CommonFunction();
            objCF.fn_ExportToExcel(lblHdnQuery.Text, lblQueryName.Text, lblQueryName.Text);
        }        



    }
}
