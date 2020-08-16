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
    public partial class frmDefineReport : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        CommonFunction objC = null;
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

        public frmDefineReport()
        {
            InitializeComponent();
        }

        private void btnQuery1_Click(object sender, EventArgs e)
        {
            try
            {
                //objC = new CommonFunction();
                ////sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                //sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["IOMReport"].ToString());
                //txtQuery.Text = ConfigurationSettings.AppSettings["IOMReport"].ToString();
                //lblReportName.Text = "IOMReport";
                //DataTable dtQuery = new DataTable();
                //sqlDataAdapter.Fill(dtQuery);
                //bindingSource = new BindingSource();
                //bindingSource.DataSource = dtQuery;
                //dgvQueryExec.DataSource = bindingSource;
                //lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;

                //Open form
                filterIOMReport objfrmIOMReport = new filterIOMReport();
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "filterIOMReport")
                    {
                        if (MessageBox.Show("IOM Report Form Already Open") == DialogResult.OK)
                            frm.Activate();
                        return;
                    }
                }
                objfrmIOMReport.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("IOM Report Query not get Executed!");
            }
        }

        private void btnPendingReport_Click(object sender, EventArgs e)
        {
            try
            {
                //objC = new CommonFunction();
                ////sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                //sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["PendingReport"].ToString());
                //txtQuery.Text = ConfigurationSettings.AppSettings["PendingReport"].ToString();
                //lblReportName.Text = "PendingReport";
                //DataTable dtQuery = new DataTable();
                //sqlDataAdapter.Fill(dtQuery);
                //bindingSource = new BindingSource();
                //bindingSource.DataSource = dtQuery;
                //dgvQueryExec.DataSource = bindingSource;
                //lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;

                //Open form
                filterPendingReport objfilterPendingReport = new filterPendingReport();
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "filterPendingReport")
                    {
                        if (MessageBox.Show("Pending Report Form Already Open") == DialogResult.OK)
                            frm.Activate();
                        return;
                    }
                }

                objfilterPendingReport.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Pending Report Query not get Executed!");
            }
        }

        private void btnSTNDispatch_Click(object sender, EventArgs e)
        {
            try
            {
                //objC = new CommonFunction();
                ////sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                //sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["STNDispatch"].ToString());
                //txtQuery.Text = ConfigurationSettings.AppSettings["STNDispatch"].ToString();
                //lblReportName.Text = "STNDispatch";
                //DataTable dtQuery = new DataTable();
                //sqlDataAdapter.Fill(dtQuery);
                //bindingSource = new BindingSource();
                //bindingSource.DataSource = dtQuery;
                //dgvQueryExec.DataSource = bindingSource;
                //lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;

                //Open form
                filterSTNDispatch objfilterSTNDispatch = new filterSTNDispatch();
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "filterSTNDispatch")
                    {
                        if (MessageBox.Show("STN Dispatch Report Form Already Open") == DialogResult.OK)
                            frm.Activate();
                        return;
                    }
                }

                objfilterSTNDispatch.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("STN Dispatch Query not get Executed!");
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (txtQuery.Text != "")
            {
                CommonFunction objCF = new CommonFunction();
                objCF.fn_ExportToExcel(txtQuery.Text, lblReportName.Text, lblReportName.Text);
            }
            else
            {
                MessageBox.Show("Please select Query!");
            }
        }

        private void btnDeletedOrder_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                //sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["STNDispatch"].ToString());
                //txtQuery.Text = ConfigurationSettings.AppSettings["STNDispatch"].ToString();
                txtQuery.Text = @"select oh.IOMNo,oh.IOMDate,oh.OrderAuthoDate, oh.PartyCode,oh.PartyName, oh.DSM_ZSM,oh.DispThrough,oh.InstPONo,oh.InstPODate,oh.OrderRecieveDate,oh.OrderDeliveryDate,
oh.Schedule,(case when oh.Institution is not null then (select Name from InstitutionMaster where oh.Institution = InstitutionMaster.Code) end) Institution,
(case when oh.SubInstitution is not null then (select Name from SubInstitutionMaster where oh.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution,
oi.ProductCode,oi.ProductName,oi.Quantity,oi.BillingRate,oi.MRP,oi.EffTax,oi.ProdValue,oh.BillingAddress,oh.DeliveryAddress, sm.Name as Stamping,oh.DocFile1,
oh.MRP,oh.Lisioner,oh.Remark, 
(select SUBSTRING((select ', ' + Name from DOC_REQ_Master where Code in (select * from fnListToTable(oh.DocumentRequired)) for xml path('')),3,1000)) as DocumentRequired
from DeletedOrderHeader oh, DeletedOrderItem oi, StampingMaster sm where oh.IOMNo=oi.IOMNo and oh.StampingID=sm.StampingId and oh.Schedule = 'No'
union all
select oh.IOMNo,oh.IOMDate,oh.OrderAuthoDate, oh.PartyCode,oh.PartyName, oh.DSM_ZSM,oh.DispThrough,oh.InstPONo,oh.InstPODate,oh.OrderRecieveDate,sd.ScheduleDate as OrderDeliveryDate,
oh.Schedule,(case when oh.Institution is not null then (select Name from InstitutionMaster where oh.Institution = InstitutionMaster.Code) end) Institution,
(case when oh.SubInstitution is not null then (select Name from SubInstitutionMaster where oh.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution,
oi.ProductCode,oi.ProductName,sd.OrderQuantity,oi.BillingRate,oi.MRP,oi.EffTax,oi.ProdValue,oh.BillingAddress,oh.DeliveryAddress, sm.Name as Stamping,oh.DocFile1,
oh.MRP,oh.Lisioner,oh.Remark, (select SUBSTRING((select ', ' + Name from DOC_REQ_Master where Code in (select * from fnListToTable(oh.DocumentRequired)) for xml path('')),3,1000)) as DocumentRequired 
from DeletedOrderHeader oh, DeletedOrderItem oi, DeletedScheduleDetail sd, StampingMaster sm where oh.IOMNo=oi.IOMNo and oh.StampingID=sm.StampingId
and oh.Schedule = 'Yes'";
                sqlDataAdapter = objC.GetSqlDataAdapter(txtQuery.Text.Trim());
                lblReportName.Text = "DeletedIOMReport";
                DataTable dtQuery = new DataTable();
                sqlDataAdapter.Fill(dtQuery);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dtQuery;
                dgvQueryExec.DataSource = bindingSource;
                lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deleted IOM Query not get Executed!");
            }
        }

        private void dgvQueryExec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInvoiceDisWithPrd_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["InvoiceDispatchWithProduct"].ToString());
                txtQuery.Text = ConfigurationSettings.AppSettings["InvoiceDispatchWithProduct"].ToString();
                lblReportName.Text = "Invoice Dispatch With Product";
                DataTable dtQuery = new DataTable();
                sqlDataAdapter.Fill(dtQuery);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dtQuery;
                dgvQueryExec.DataSource = bindingSource;
                lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invoice Dispatch With Product Query not get Executed!");
            }
        }

        private void btnIBSDispatchWithProduct_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["IBSDispatchWithProduct"].ToString());
                txtQuery.Text = ConfigurationSettings.AppSettings["IBSDispatchWithProduct"].ToString();
                lblReportName.Text = "IBS Dispatch With Product";
                DataTable dtQuery = new DataTable();
                sqlDataAdapter.Fill(dtQuery);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dtQuery;
                dgvQueryExec.DataSource = bindingSource;
                lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("IBS Dispatch With Product Query not get Executed!");
            }
        }

        private void btnSAPDirectInvoiceWithProduct_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["SAPDirectInvoiceWithProduct"].ToString());
                txtQuery.Text = ConfigurationSettings.AppSettings["SAPDirectInvoiceWithProduct"].ToString();
                lblReportName.Text = "SAPDirectInvoiceWithProduct";
                DataTable dtQuery = new DataTable();
                sqlDataAdapter.Fill(dtQuery);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dtQuery;
                dgvQueryExec.DataSource = bindingSource;
                lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SAP Direct Invoice With Product Query not get Executed!");
            }
        }

        private void btnDeliveryDetail_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["DeliveryDetailWithProduct"].ToString());
                txtQuery.Text = ConfigurationSettings.AppSettings["DeliveryDetailWithProduct"].ToString();
                lblReportName.Text = "DeliveryDetailWithProduct";
                DataTable dtQuery = new DataTable();
                sqlDataAdapter.Fill(dtQuery);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dtQuery;
                dgvQueryExec.DataSource = bindingSource;
                lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delivery Detail With Product Query not get Executed!");
            }
        }

        private void btnInvoieDetail_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["InvoiceDetailWithProduct"].ToString());
                txtQuery.Text = ConfigurationSettings.AppSettings["InvoiceDetailWithProduct"].ToString();
                lblReportName.Text = "InvoiceDetailWithProduct";
                DataTable dtQuery = new DataTable();
                sqlDataAdapter.Fill(dtQuery);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dtQuery;
                dgvQueryExec.DataSource = bindingSource;
                lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invoice Detail With Product Query not get Executed!");
            }
        }

        private void btnDeliveryDetailWithoutProduct_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["DeliveryDetailWithoutProduct"].ToString());
                txtQuery.Text = ConfigurationSettings.AppSettings["DeliveryDetailWithoutProduct"].ToString();
                lblReportName.Text = "DeliveryDetailWithoutProduct";
                DataTable dtQuery = new DataTable();
                sqlDataAdapter.Fill(dtQuery);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dtQuery;
                dgvQueryExec.DataSource = bindingSource;
                lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delivery Detail Without Product Query not get Executed!");
            }
        }

        private void btnInvoiceDetailWithoutProduct_Click(object sender, EventArgs e)
        {
            try
            {
                //objC = new CommonFunction();
                ////sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                //sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["InvoiceDetailWithoutProduct"].ToString());
                //txtQuery.Text = ConfigurationSettings.AppSettings["InvoiceDetailWithoutProduct"].ToString();
                //lblReportName.Text = "InvoiceDetailWithoutProduct";
                //DataTable dtQuery = new DataTable();
                //sqlDataAdapter.Fill(dtQuery);
                //bindingSource = new BindingSource();
                //bindingSource.DataSource = dtQuery;
                //dgvQueryExec.DataSource = bindingSource;
                //lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;

                //Open form
                frmInvoiceDetailWithoutProduct objfrmInvoiceDetailWithoutProduct = new frmInvoiceDetailWithoutProduct();
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "frmInvoiceDetailWithoutProduct")
                    {
                        if (MessageBox.Show("Invoice Detail Without Product Form Already Open") == DialogResult.OK)
                            frm.Activate();
                        return;
                    }
                }
                objfrmInvoiceDetailWithoutProduct.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invoice Detail Without Product Query not get Executed!");
            }
        }

        private void btnProductWiseNotInvoiced_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["ProductWiseNotInvoiced"].ToString());
                txtQuery.Text = ConfigurationSettings.AppSettings["ProductWiseNotInvoiced"].ToString();
                lblReportName.Text = "ProductWiseNotInvoiced";
                DataTable dtQuery = new DataTable();
                sqlDataAdapter.Fill(dtQuery);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dtQuery;
                dgvQueryExec.DataSource = bindingSource;
                lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Wise Not Invoiced Query not get Executed!");
            }
        }

        private void btnProductWiseDir_INV_SAP_IBS_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["ProductWiseDir_INV_SAP_IBS"].ToString());
                txtQuery.Text = ConfigurationSettings.AppSettings["ProductWiseDir_INV_SAP_IBS"].ToString();
                lblReportName.Text = "ProductWiseDir_INV_SAP_IBS";
                DataTable dtQuery = new DataTable();
                sqlDataAdapter.Fill(dtQuery);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dtQuery;
                dgvQueryExec.DataSource = bindingSource;
                lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Wise Direct Invoice SAP IBS Query not get Executed!");
            }
        }

        private void btnProductInvoiceThroughSTNforSAP_IBS_Click(object sender, EventArgs e)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["ProductInvoiceThroughSTNforSAP_IBS"].ToString());
                txtQuery.Text = ConfigurationSettings.AppSettings["ProductInvoiceThroughSTNforSAP_IBS"].ToString();
                lblReportName.Text = "PrdInvThruSTNforSAP_IBS";
                DataTable dtQuery = new DataTable();
                sqlDataAdapter.Fill(dtQuery);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dtQuery;
                dgvQueryExec.DataSource = bindingSource;
                lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Invoice Through STN for SAP_IBS Query not get Executed!");
            }
        }

        private void btnAllSql_Click(object sender, EventArgs e)
        {
            try
            {
                //objC = new CommonFunction();
                ////sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                //sqlDataAdapter = objC.GetSqlDataAdapter(ConfigurationSettings.AppSettings["AllSqlMergeQuery"].ToString());
                //txtQuery.Text = ConfigurationSettings.AppSettings["AllSqlMergeQuery"].ToString();
                //lblReportName.Text = "AllSqlMergeQuery";
                //DataTable dtQuery = new DataTable();
                //sqlDataAdapter.Fill(dtQuery);
                //bindingSource = new BindingSource();
                //bindingSource.DataSource = dtQuery;
                //dgvQueryExec.DataSource = bindingSource;
                //lblCount.Text = "Total No. of Record: " + dgvQueryExec.Rows.Count;

                //Open form
                filterAllSqlMerge objfilterAllSqlMerge = new filterAllSqlMerge();
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "filterAllSqlMerge")
                    {
                        if (MessageBox.Show("All SQL Merge Form Already Open") == DialogResult.OK)
                            frm.Activate();
                        return;
                    }
                }
                objfilterAllSqlMerge.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("All Sql Merge Query not get Executed!");
            }
        }


    }
}
