using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ww_lib;
using System.Configuration;
using ww_admin;
using System.Data.SqlClient;

namespace gm
{
    public partial class frmQueryGenerator : Form
    {
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        string strLogFileName = "LOG/LogRecord.txt";
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;

        public frmQueryGenerator()
        {
            InitializeComponent();
        }

        private void frmQueryGenerator_Load(object sender, EventArgs e)
        {
            try
            {
                bindOrderHeader();
                bindOrderItem();
                bindSAPInvoice();
                bindSTNUpload();
                ////bindSTNDispatch();
                bindInvoiceDispatch();
                bindBatchAllocation();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmQueryGenerator frmQueryGenerator_Load \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bindOrderHeader()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetTableColumn("OrderHeader");
                ChkORHeader.DataSource = dt;
                ChkORHeader.DisplayMember = "column_desc";
                ChkORHeader.ValueMember = "column";
            }
            catch (Exception ex)
            { 
            }
        }

        private void bindOrderItem()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetTableColumn("OrderItem");
                ChkORderItem.DataSource = dt;
                ChkORderItem.DisplayMember = "column_desc";
                ChkORderItem.ValueMember = "column";
            }
            catch (Exception ex)
            {
            }
        }

        private void bindSAPInvoice()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetTableColumn("SAPInvoiceUpload");
                chkSapInvoice.DataSource = dt;
                chkSapInvoice.DisplayMember = "column_desc";
                chkSapInvoice.ValueMember = "column";
            }
            catch (Exception ex)
            {
            }
        }

        private void bindSTNUpload()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetTableColumn("STNUpload");
                chkSTNUPload.DataSource = dt;
                chkSTNUPload.DisplayMember = "column_desc";
                chkSTNUPload.ValueMember = "column";
            }
            catch (Exception ex)
            {
            }
        }

        //private void bindSTNDispatch()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        CommonFunction objCommon = new CommonFunction();
        //        dt = objCommon.GetTableColumn("");
        //        chkSTNDispatch.DataSource = dt;
        //        chkSTNDispatch.DisplayMember = "column_desc";
        //        chkSTNDispatch.ValueMember = "column";
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        private void bindInvoiceDispatch()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetTableColumn("Invoice_Dispatch");
                chkInvoiceDispatch.DataSource = dt;
                chkInvoiceDispatch.DisplayMember = "column_desc";
                chkInvoiceDispatch.ValueMember = "column";
            }
            catch (Exception ex)
            {
            }
        }

        private void bindBatchAllocation()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetTableColumn("BatchAllocation");
                chkBatchAllocation.DataSource = dt;
                chkBatchAllocation.DisplayMember = "column_desc";
                chkBatchAllocation.ValueMember = "column";
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder strOrderHeader = new StringBuilder();
            StringBuilder strOrderItem = new StringBuilder();
            StringBuilder strSAPInvoice = new StringBuilder();
            StringBuilder strSTNUpload = new StringBuilder();
            StringBuilder strInvoiceDispatch = new StringBuilder();
            StringBuilder strBatchAllocation = new StringBuilder();
            StringBuilder strMainQuery = new StringBuilder();
            StringBuilder strTableName = new StringBuilder();
            StringBuilder strColumn = new StringBuilder();
            StringBuilder strWhere = new StringBuilder();


            /********Collecting Value********/
            foreach (object itemChecked in ChkORHeader.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;
                if (strOrderHeader.ToString() == "")
                {
                    strOrderHeader.Append(" OrderHeader." + castedItem["column"].ToString());
                }
                else
                {
                    strOrderHeader.Append(", OrderHeader." + castedItem["column"].ToString());
                }
            }

            foreach (object itemChecked in ChkORderItem.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;
                if (strOrderItem.ToString() == "")
                {
                    strOrderItem.Append(" OrderItem." + castedItem["column"].ToString());
                }
                else
                {
                    strOrderItem.Append(", OrderItem." + castedItem["column"].ToString());
                }
            }

            foreach (object itemChecked in chkSapInvoice.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;

                if (strSAPInvoice.ToString() == "")
                {
                    strSAPInvoice.Append(" SAPInvoiceUpload." + castedItem["column"].ToString());
                }
                else
                {
                    strSAPInvoice.Append(", SAPInvoiceUpload." + castedItem["column"].ToString());
                }
            }

            foreach (object itemChecked in chkSTNUPload.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;

                if (strSTNUpload.ToString() == "")
                {
                    strSTNUpload.Append(" STNUpload." + castedItem["column"].ToString());
                }
                else
                {
                    strSTNUpload.Append(", STNUpload." + castedItem["column"].ToString());
                }
            }

            foreach (object itemChecked in chkInvoiceDispatch.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;

                if (strInvoiceDispatch.ToString() == "")
                {
                    strInvoiceDispatch.Append(" Invoice_Dispatch." + castedItem["column"].ToString());
                }
                else
                {
                    strInvoiceDispatch.Append(", Invoice_Dispatch." + castedItem["column"].ToString());
                }
            }

            foreach (object itemChecked in chkBatchAllocation.CheckedItems)
            {
                DataRowView castedItem = itemChecked as DataRowView;

                if (strBatchAllocation.ToString() == "")
                {
                    strBatchAllocation.Append(" BatchAllocation." + castedItem["column"].ToString());
                }
                else
                {
                    strBatchAllocation.Append(", BatchAllocation." + castedItem["column"].ToString());
                }
            }
            /********Collecting Value********/
            /********TableName********/
            if (strOrderHeader.ToString() != "")
            {
                strTableName.Append(" OrderHeader ");
                strColumn.Append(strOrderHeader.ToString());
            }

            if (strOrderItem.ToString() != "")
            {
                if (strTableName.ToString() != "")
                {
                    strTableName.Append(", ");
                    strColumn.Append(", ");
                }
                strTableName.Append(" OrderItem ");
                strColumn.Append(strOrderItem.ToString());
            }
            if (strSAPInvoice.ToString() != "")
            {
                if (strTableName.ToString() != "")
                {
                    strTableName.Append(", ");
                    strColumn.Append(", ");
                }
                strTableName.Append(" SAPInvoiceUpload ");
                strColumn.Append(strSAPInvoice.ToString());
            }
            if (strSTNUpload.ToString() != "")
            {
                if (strTableName.ToString() != "")
                {
                    strTableName.Append(", ");
                    strColumn.Append(", ");
                }
                strTableName.Append(" STNUpload ");
                strColumn.Append(strSTNUpload.ToString());
            }
            if (strInvoiceDispatch.ToString() != "")
            {
                if (strTableName.ToString() != "")
                {
                    strTableName.Append(", ");
                    strColumn.Append(", ");
                }
                strTableName.Append(" Invoice_Dispatch ");
                strColumn.Append(strInvoiceDispatch.ToString());
            }
            if (strBatchAllocation.ToString() != "")
            {
                if (strTableName.ToString() != "")
                {
                    strTableName.Append(", ");
                    strColumn.Append(", ");
                }
                strTableName.Append(" BatchAllocation ");
                strColumn.Append(strBatchAllocation.ToString());
            }
            /********TableName********/
            /********QUERY Generation********/
            if (strTableName.ToString() != null)
            {
                string[] arrTablename = strTableName.ToString().Split(',');
                lblTableName.Text = arrTablename.Length.ToString();
                lblTblCnt.Text = arrTablename.Length.ToString();
                for (int i = 0; i < arrTablename.Length; i++)
                {
                    if (i < (arrTablename.Length - 1))
                    {
                        if (strWhere.ToString().Trim() != "")
                        {
                            strWhere.Append(" AND ");
                        }
                        strWhere.Append("  " + arrTablename[i].ToString() + ".IOMNO = " + arrTablename[i + 1].ToString() + ".IOMNO ");
                    }
                }
                /********Where Clause********/
                strMainQuery.Append(" Select " + strColumn.ToString() + " from  ");
                strMainQuery.Append(" " + strTableName.ToString() + " ");
                if (strWhere.ToString().Trim() != "")
                {
                    strMainQuery.Append(" WHERE " + strWhere.ToString() + " ");
                }
                lblTableName.Text = strTableName.ToString();
                txtQuery.Text = strMainQuery.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CommonFunction objCF = new CommonFunction();
                string query = "INSERT INTO QueryTable (QueryName,Query,TableNames,TableInvolvement) VALUES ('" + txtQueryname.Text + "','" + txtQuery.Text + "','" + lblTableName.Text + "','" + lblTblCnt.Text + "')";
                Result objResult = objCF.InsertQuery(query);
                if (objResult.bStatus)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                    lblStatus.Text = "Query Inserted Sucessfully";
                    ClearForm();
                    bindOrderHeader();
                    bindOrderItem();
                    bindSAPInvoice();
                    bindSTNUpload();
                    ////bindSTNDispatch();
                    bindInvoiceDispatch();
                    bindBatchAllocation();
                    lblStatus.Text = "Query Inserted Sucessfully";
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    lblStatus.Text = objResult.strMessage;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ClearForm()
        {
            txtQueryname.Text = "";
            txtQuery.Text = "";
        }

        

       


    }
}
