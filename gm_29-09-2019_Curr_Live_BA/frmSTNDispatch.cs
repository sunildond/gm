using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ww_admin;
using ww_lib;
using System.IO;
using System.Globalization;

namespace gm
{
    public partial class frmSTNDispatch : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        private string _dateformat = "MM/dd/yyyy";
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        //private int id;
        private int flag = 0;
        public int IOMNO = 0;
        public string QueryAdd = string.Empty;
        public string QueryEdit = string.Empty;
        public string QueryAddForDDL = string.Empty;
        public string QueryEditForDDL = string.Empty;

        public frmSTNDispatch()
        {
            InitializeComponent();
        }

        private void frmSTNDispatch_Load(object sender, EventArgs e)
        {
            chkauth.Visible = false;

            dtpInvDispLRDate.Checked = false;
            dtpInvDispDelDate.Checked = false;
            dtpTentativeDelDate.Checked = false;
            dtpDispositDate.Checked = false;
            dtpDate.Checked = false;

            QueryAdd = @" SELECT distinct STNUpload.IOMNo,OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.Plnt,OrderHeader.DispThrough, 
 STNUpload.Delivery, STNUpload.deliverydate as ACGIDate, STNUpload.BillingDocument as PreInvoice,
 STNUpload.Priority,OrderHeader.DocumentRequired,orderheader.StampingID,OrderHeader.MRP, STNUpload.PartyCode as 'STN PartyCode'
 from STNUpload, OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO  and STNUpload.Delivery not in (select STNInvoice_Dispatch.Delivery from STNInvoice_Dispatch) 
 and STNUpload.Delivery != '' and STNUpload.OrdUpdated=1";

            QueryEdit = @" SELECT distinct STNUpload.IOMNo,OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.Plnt,OrderHeader.DispThrough, 
 STNUpload.Delivery, STNUpload.deliverydate as ACGIDate, STNUpload.BillingDocument as PreInvoice,
 STNUpload.Priority,OrderHeader.DocumentRequired,orderheader.StampingID,OrderHeader.MRP, STNUpload.PartyCode as 'STN PartyCode'
 from STNUpload, OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO 
 and STNUpload.Delivery in (select STNInvoice_Dispatch.Delivery from STNInvoice_Dispatch) and STNUpload.Delivery != ''";

            QueryAddForDDL = @" SELECT distinct STNUpload.IOMNo, CONVERT(varchar(100),STNUpload.IOMNo) as IOM, OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.Plnt,OrderHeader.DispThrough, 
 STNUpload.Delivery, STNUpload.deliverydate as ACGIDate, STNUpload.BillingDocument as PreInvoice,
 STNUpload.Priority,OrderHeader.DocumentRequired,orderheader.StampingID,OrderHeader.MRP, STNUpload.PartyCode as 'STN PartyCode'
 from STNUpload, OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO  and STNUpload.Delivery not in (select STNInvoice_Dispatch.Delivery from STNInvoice_Dispatch) 
 and STNUpload.Delivery != '' and STNUpload.OrdUpdated=1";

            QueryEditForDDL = @" SELECT distinct STNUpload.IOMNo, CONVERT(varchar(100),STNUpload.IOMNo) as IOM, OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.Plnt,OrderHeader.DispThrough, 
 STNUpload.Delivery, STNUpload.deliverydate as ACGIDate, STNUpload.BillingDocument as PreInvoice,
 STNUpload.Priority,OrderHeader.DocumentRequired,orderheader.StampingID,OrderHeader.MRP, STNUpload.PartyCode as 'STN PartyCode'
 from STNUpload, OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO 
 and STNUpload.Delivery in (select STNInvoice_Dispatch.Delivery from STNInvoice_Dispatch) and STNUpload.Delivery != ''";

            if (DBSessionUser.bAddPerm == true && DBSessionUser.bEditPerm == false)
            {
                if (DBSessionUser.strUserLocation != "")
                {
                    //QueryAdd = "select * from  ( " + QueryAdd + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                    //QueryAddForDDL = "select * from  ( " + QueryAddForDDL + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                    //change by 03-07-2015
                    QueryAdd = "select * from  ( " + QueryAdd + " ) as tempTbl";
                    QueryAddForDDL = "select * from  ( " + QueryAddForDDL + " ) as tempTbl";

                }

                chkAdd.Visible = true;
                chkEdit.Visible = false;
            }
            else if (DBSessionUser.bAddPerm == false && DBSessionUser.bEditPerm == true)
            {
                if (DBSessionUser.strUserLocation != "")
                {
                    //QueryEdit = "select * from  ( " + QueryEdit + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                    //QueryEditForDDL = "select * from  ( " + QueryEditForDDL + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                    //change by 03-07-2015
                    QueryEdit = "select * from  ( " + QueryEdit + " ) as tempTbl";
                    QueryEditForDDL = "select * from  ( " + QueryEditForDDL + " ) as tempTbl";

                }

                chkAdd.Visible = false;
                chkEdit.Visible = true;
            }
            else if (DBSessionUser.bAddPerm == false && DBSessionUser.bEditPerm == false)
            {
                if (DBSessionUser.strUserLocation != "")
                {
                    //QueryEdit = "select * from  ( " + QueryEdit + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                    //QueryEditForDDL = "select * from  ( " + QueryEditForDDL + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                    //change by 03-07-2015
                    QueryEdit = "select * from  ( " + QueryEdit + " ) as tempTbl";
                    QueryEditForDDL = "select * from  ( " + QueryEditForDDL + " ) as tempTbl";
                }

                chkAdd.Visible = false;
                chkEdit.Visible = false;
            }
            else if (DBSessionUser.bAddPerm == true && DBSessionUser.bEditPerm == true)
            {
                if (DBSessionUser.strUserLocation != "")
                {
                    //QueryEdit = "select * from  ( " + QueryEdit + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                    //QueryEditForDDL = "select * from  ( " + QueryEditForDDL + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                    //change by 03-07-2015
                    QueryEdit = "select * from  ( " + QueryEdit + " ) as tempTbl";
                    QueryEditForDDL = "select * from  ( " + QueryEditForDDL + " ) as tempTbl";
                }

                chkAdd.Visible = true;
                chkEdit.Visible = true;
            }
            btnAllAuthorise.Visible = false;
        }

        private void fn_getDispatchDetail(long DeliveryNo, int iomno)
        {
            try
            {
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("select * from STNInvoice_Dispatch where Delivery = " + DeliveryNo);

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //  IOMNO =  Convert.ToString(dataTable.Rows[0]["IOMNO"]);
                    //IOMNO = int.Parse(dataTable.Rows[0]["IOMNO"].ToString());
                    lbliomno.Text = iomno.ToString();

                    txtHORemark.Text = dataTable.Rows[0]["HORemarks"].ToString();
                    txtCFARemark.Text = dataTable.Rows[0]["CFARemarks"].ToString();
                    txtInvTransporter.Text = dataTable.Rows[0]["InvTransporter"].ToString();
                    txtInvLRNo.Text = dataTable.Rows[0]["InvLRNo"].ToString();
                    dtpInvDispLRDate.Text = string.Format("{0:dd/MM/yyyy}", dataTable.Rows[0]["InvDispLRdate"].ToString());
                    dtpInvDispDelDate.Text = string.Format("{0:dd/MM/yyyy}", dataTable.Rows[0]["InvDispDelDate"].ToString());
                    txtChequeNo.Text = dataTable.Rows[0]["chequenumber"].ToString();
                    dtpDate.Text = string.Format("{0:dd/MM/yyyy}", dataTable.Rows[0]["Date"].ToString());
                    txtAmount.Text = dataTable.Rows[0]["Amount"].ToString();
                    dtpDispositDate.Text = string.Format("{0:dd/MM/yyyy}", dataTable.Rows[0]["DepositDate"].ToString());
                    txtDelivery.Text = dataTable.Rows[0]["Delivery"].ToString();
                    txtCases.Text = dataTable.Rows[0]["Cases"].ToString();
                    dtpTentativeDelDate.Text = string.Format("{0:dd/MM/yyyy}", dataTable.Rows[0]["TentativeDel"].ToString());
                    //lblIOMNO.Text = dataTable.Rows[0]["IOMNo"].ToString();
                    //lblDeliveryDate.Text = string.Format("{0:dd/MM/yyyy}", dataTable.Rows[0]["OrderDeliveryDate"].ToString());

                    if (dataTable.Rows[0]["IsAuth"].ToString() == "True")
                    {
                        chkauth.Checked = true;
                    }
                    else
                    {
                        chkauth.Checked = false;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        public void bindGridBillDoc(string Query)
        {
            try
            {
                objC = new CommonFunction();
                //sqlDataAdapter = objC.GetSqlDataAdapter("select * from SAPInvoiceUpload where BillingDocument = " + BillDocNo);
                sqlDataAdapter = objC.GetSqlDataAdapter(Query);

                dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);

                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvBillingDoc.DataSource = bindingSource;

                //dgvBillingDoc.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n frmSTNDispatch/bindGridBillDoc \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdd.Checked == true)
            {
                chkauth.Visible = true;
                //bindBillingDocumentAdd();
                //bindGridBillDoc("SELECT distinct IOMNo, BillingDocument, PartyCode, Plnt, Priority from STNUpload where BillingDocument not in (select BillingDocument from STNInvoice_Dispatch) and BillingDocument != ''");
                //bindGridBillDoc("SELECT distinct STNUpload.IOMNo,OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.BillingDocument, STNUpload.PartyCode, STNUpload.Plnt, STNUpload.Priority,STNUpload.Delivery,STNUpload.AcGIdate,STNUpload.BillingDocument,OrderHeader.DispThrough,OrderHeader.DocumentRequired,orderheader.StampingID, OrderHeader.MRP from STNUpload ,OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO and   BillingDocument not in (select BillingDocument from STNInvoice_Dispatch) and BillingDocument != ''");
                //bindGridBillDoc("SELECT distinct STNUpload.IOMNo, OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.BillingDocument,STNUpload.Delivery, STNUpload.PartyCode, STNUpload.Plnt, STNUpload.Priority,STNUpload.Delivery,STNUpload.AcGIdate,STNUpload.BillingDocument,OrderHeader.DispThrough,OrderHeader.DocumentRequired,orderheader.StampingID, OrderHeader.MRP from STNUpload ,OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO and   BillingDocument not in (select BillingDocument from STNInvoice_Dispatch) and BillingDocument != ''");

                //bindGridBillDoc(" SELECT distinct STNUpload.IOMNo,OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.BillingDocument,STNUpload.Delivery,  STNUpload.PartyCode as 'STN PartyCode', STNUpload.Plnt, STNUpload.Priority,STNUpload.deliverydate,OrderHeader.DispThrough,  OrderHeader.DocumentRequired,orderheader.StampingID, OrderHeader.MRP from STNUpload, OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO  and STNUpload.Delivery not in (select STNInvoice_Dispatch.Delivery from STNInvoice_Dispatch) and STNUpload.Delivery != '' and STNUpload.OrdUpdated=1");

                bindGridBillDoc(QueryAdd);

                bindAddIOMNoAndBillingDoc();

                chkEdit.Checked = false;
                flag = 0;
                ClearForm();
                lblStatus.Text = "";
                //Authorise Column Visibility
                dgvBillingDoc.Columns[0].Visible = true;
                btnAllAuthorise.Visible = true;

            }
            else if (chkAdd.Checked == false)
            {
                //Authorise Column Visibility
                dgvBillingDoc.Columns[0].Visible = false;
                btnAllAuthorise.Visible = false;
            }
        }

        protected void bindAddIOMNoAndBillingDoc()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable(QueryAdd);

                chkIOMNo.DataSource = dt;
                chkIOMNo.DisplayMember = "IOMNo";
                chkIOMNo.ValueMember = "IOMNo";

                chkBillingDoc.DataSource = dt;
                chkBillingDoc.DisplayMember = "Delivery";
                chkBillingDoc.ValueMember = "Delivery";

                DataTable dt1 = new DataTable();
                dt1 = objCommon.GetDataTable(QueryAddForDDL);
                ddlIOMNO.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlIOMNO.AutoCompleteMode = AutoCompleteMode.Suggest;
                DataRow dr2 = dt1.NewRow();
                dr2["IOMNo"] = 0;
                dr2["IOM"] = "";

                dt1.Rows.InsertAt(dr2, 0);
                ddlIOMNO.DataSource = dt1;
                ddlIOMNO.DisplayMember = "IOM";
                ddlIOMNO.ValueMember = "IOMNo";

                ddlPreInvoice.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlPreInvoice.AutoCompleteMode = AutoCompleteMode.Suggest;
                //DataRow dr1 = dt1.NewRow();
                //dr1["IOMNo"] = 0;
                //dr1["PreInvoice"] = "";
                //dt1.Rows.InsertAt(dr1, 0);
                ddlPreInvoice.DataSource = dt1;
                ddlPreInvoice.DisplayMember = "Delivery";
                ddlPreInvoice.ValueMember = "IOMNo";

            }
            catch (Exception ex)
            {

            }
        }

        protected void bindEditIOMNoAndBillingDoc()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable(QueryEdit);

                chkIOMNo.DataSource = dt;
                chkIOMNo.DisplayMember = "IOMNo";
                chkIOMNo.ValueMember = "IOMNo";

                chkBillingDoc.DataSource = dt;
                chkBillingDoc.DisplayMember = "Delivery";
                chkBillingDoc.ValueMember = "Delivery";

                DataTable dt1 = new DataTable();
                dt1 = objCommon.GetDataTable(QueryEditForDDL);
                ddlIOMNO.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlIOMNO.AutoCompleteMode = AutoCompleteMode.Suggest;
                DataRow dr2 = dt1.NewRow();
                dr2["IOMNo"] = 0;
                dr2["IOM"] = "";

                dt1.Rows.InsertAt(dr2, 0);
                ddlIOMNO.DataSource = dt1;
                ddlIOMNO.DisplayMember = "IOM";
                ddlIOMNO.ValueMember = "IOMNo";

                ddlPreInvoice.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlPreInvoice.AutoCompleteMode = AutoCompleteMode.Suggest;
                //DataRow dr1 = dt1.NewRow();
                //dr1["IOMNo"] = 0;
                //dr1["PreInvoice"] = "";
                //dt1.Rows.InsertAt(dr1, 0);
                ddlPreInvoice.DataSource = dt1;
                ddlPreInvoice.DisplayMember = "Delivery";
                ddlPreInvoice.ValueMember = "IOMNo";

            }
            catch (Exception ex)
            {

            }
        }

        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEdit.Checked == true)
            {
                chkauth.Visible = false;

                //bindBillingDocumentEdit();
                //bindGridBillDoc("sELECT distinct STNUpload.IOMNo, OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.BillingDocument,STNUpload.Delivery, STNUpload.PartyCode, STNUpload.Plnt, STNUpload.Priority,STNUpload.Delivery,STNUpload.AcGIdate,STNUpload.BillingDocument,OrderHeader.DispThrough,OrderHeader.DocumentRequired,orderheader.StampingID, OrderHeader.MRP from STNUpload ,OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO and   BillingDocument in (select BillingDocument from STNInvoice_Dispatch) and BillingDocument != ''");
                //bindGridBillDoc("SELECT distinct STNUpload.IOMNo,OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.BillingDocument,STNUpload.Delivery, STNUpload.PartyCode as 'STN PartyCode', STNUpload.Plnt, STNUpload.Priority,STNUpload.deliverydate,OrderHeader.DispThrough, OrderHeader.DocumentRequired,orderheader.StampingID, OrderHeader.MRP from STNUpload, OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO and STNUpload.Delivery in (select STNInvoice_Dispatch.Delivery from STNInvoice_Dispatch) and STNUpload.Delivery != ''");

                bindGridBillDoc(QueryEdit);

                bindEditIOMNoAndBillingDoc();

                chkAdd.Checked = false;
                flag = 1;
                ClearForm();
                lblStatus.Text = "";

                //Authorise Column Visibility
                dgvBillingDoc.Columns[0].Visible = false;
                btnAllAuthorise.Visible = false;
            }
            else if (chkAdd.Checked == true)
                btnAllAuthorise.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (chkAdd.Checked == true)
                {
                    if (chkauth.Checked == true)
                    {
                        // bool bstatus = true;
                        bool bstatus = validateForm();
                        if (bstatus == true)
                        {
                            string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            CommonFunction objCF = new CommonFunction();
                            SqlCommand objcmd = new SqlCommand("INSERT INTO STNInvoice_Dispatch (IOMNo,Delivery, HORemarks, CFARemarks, InvTransporter, InvLRNo, InvDispLRdate, InvDispDelDate, ChequeNumber, Date, Amount, DepositDate, LastModify, Cases, TentativeDel, IsAuth, Authdate) VALUES (@IOMNo,@Delivery, @HORemarks, @CFARemarks, @InvTransporter, @InvLRNo, @InvDispLRdate, @InvDispDelDate, @ChequeNumber, @Date, @Amount, @DepositDate, getdate(), @Cases, @TentativeDel, @IsAuth, getdate()); SELECT @pk_new = @@IDENTITY");

                            if (lbliomno.Text != "")
                                objcmd.Parameters.AddWithValue("@IOMNo", int.Parse(lbliomno.Text));
                            else
                                objcmd.Parameters.AddWithValue("@IOMNo", 0);

                            if (txtDelivery.Text != "")
                                objcmd.Parameters.AddWithValue("@Delivery", long.Parse(txtDelivery.Text));   //objcmd.Parameters.AddWithValue("@Delivery", int.Parse(txtDelivery.Text));
                            else
                                objcmd.Parameters.AddWithValue("@Delivery", 0);

                            objcmd.Parameters.AddWithValue("@HORemarks", txtHORemark.Text);
                            objcmd.Parameters.AddWithValue("@CFARemarks", txtCFARemark.Text);
                            objcmd.Parameters.AddWithValue("@InvTransporter", txtInvTransporter.Text);
                            objcmd.Parameters.AddWithValue("@InvLRNo", txtInvLRNo.Text);

                            if (dtpInvDispLRDate.Checked == true)
                            {
                                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                                {
                                    objcmd.Parameters.AddWithValue("@InvDispLRdate", DateTime.Parse(dtpInvDispLRDate.Text, dateformat));
                                }
                                else
                                {
                                    objcmd.Parameters.AddWithValue("@InvDispLRdate", DateTime.Parse(dtpInvDispLRDate.Text).ToString(_dateformat));
                                }
                            }
                            else
                                objcmd.Parameters.AddWithValue("@InvDispLRdate", DBNull.Value);

                            if (dtpInvDispDelDate.Checked == true)
                            {
                                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                                {
                                    objcmd.Parameters.AddWithValue("@InvDispDelDate", DateTime.Parse(dtpInvDispDelDate.Text, dateformat));
                                }
                                else
                                {
                                    objcmd.Parameters.AddWithValue("@InvDispDelDate", DateTime.Parse(dtpInvDispDelDate.Text).ToString(_dateformat));
                                }
                            }
                            else
                                objcmd.Parameters.AddWithValue("@InvDispDelDate", DBNull.Value);

                            objcmd.Parameters.AddWithValue("@ChequeNumber", txtChequeNo.Text);

                            if (dtpDate.Checked == true)
                            {
                                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                                {
                                    objcmd.Parameters.AddWithValue("@Date", DateTime.Parse(dtpDate.Text, dateformat));
                                }
                                else
                                {
                                    objcmd.Parameters.AddWithValue("@Date", DateTime.Parse(dtpDate.Text).ToString(_dateformat));
                                }
                            }
                            else
                                objcmd.Parameters.AddWithValue("@Date", DBNull.Value);

                            if (dtpDispositDate.Checked == true)
                            {
                                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                                {
                                    objcmd.Parameters.AddWithValue("@DepositDate", DateTime.Parse(dtpDispositDate.Text, dateformat));
                                }
                                else
                                {
                                    objcmd.Parameters.AddWithValue("@DepositDate", DateTime.Parse(dtpDispositDate.Text).ToString(_dateformat));
                                }
                            }
                            else
                                objcmd.Parameters.AddWithValue("@DepositDate", DBNull.Value);

                            if (txtAmount.Text != "")
                                objcmd.Parameters.AddWithValue("@Amount", decimal.Parse(txtAmount.Text));
                            else
                                objcmd.Parameters.AddWithValue("@Amount", 0);

                            objcmd.Parameters.AddWithValue("@Cases", txtCases.Text);

                            if (dtpTentativeDelDate.Checked == true)
                            {
                                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                                {
                                    objcmd.Parameters.AddWithValue("@TentativeDel", DateTime.Parse(dtpTentativeDelDate.Text, dateformat));
                                }
                                else
                                {
                                    objcmd.Parameters.AddWithValue("@TentativeDel", DateTime.Parse(dtpTentativeDelDate.Text).ToString(_dateformat));
                                }
                            }
                            else
                                objcmd.Parameters.AddWithValue("@TentativeDel", DBNull.Value);

                            objcmd.Parameters.AddWithValue("@IsAuth", chkauth.Checked ? 1 : 0);

                            SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                            spInsertedKey.Direction = ParameterDirection.Output;
                            objcmd.Parameters.Add(spInsertedKey);

                            Result objResult = objCF.InsertNewQuery(objcmd);
                            if (objResult.bStatus)
                            {
                                lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                                lblStatus.Text = "Dispatch Detail Inserted Sucessfully";
                                lbliomno.Text = "";
                                ClearForm();
                                //bindBillingDocumentAdd();
                                //bindGridBillDoc("SELECT distinct IOMNo, BillingDocument, PartyCode, Plnt, Priority from STNUpload where 1 = 2");

                                //Comment on 23/09/2012
                                //bindGridBillDoc(@" SELECT distinct STNUpload.IOMNo,OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.Plnt,OrderHeader.DispThrough, 
                                //STNUpload.Delivery, STNUpload.deliverydate as ACGIDate, STNUpload.BillingDocument as PreInvoice, STNUpload.Priority,OrderHeader.DocumentRequired,orderheader.StampingID,OrderHeader.MRP, STNUpload.PartyCode as 'STN PartyCode'
                                //from STNUpload, OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO  and STNUpload.Delivery not in (select STNInvoice_Dispatch.Delivery from STNInvoice_Dispatch) 
                                //and STNUpload.Delivery != '' and STNUpload.OrdUpdated=1");

                                bindGridBillDoc(@"select * from  ( " + QueryAdd + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))");

                                //chkAdd.Checked = false;
                                //chkEdit.Checked = false;
                            }
                            else
                            {
                                lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                                lblStatus.Text = objResult.strMessage + " - " + objResult.eException;
                            }
                        }
                    }
                    else
                    {
                        //lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                        //lblStatus.Text = "Required Authorised!";
                        MessageBox.Show("Required Authorised!");
                    }
                }
                else if (chkEdit.Checked == true)
                {
                    UpdateRecord();
                }

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n frmDispatch/ btnSave function \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateRecord()
        {
            try
            {
                bool bstatus = true;
                bstatus = validateForm();
                if (bstatus == true)
                {
                    string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    CommonFunction objCF = new CommonFunction();
                    StringBuilder strAppend = new StringBuilder();
                    strAppend.Append(" UPDATE STNInvoice_Dispatch ");
                    strAppend.Append(" SET IOMNo = @IOMNo, ");
                    strAppend.Append(" HORemarks = @HORemarks, ");
                    strAppend.Append(" CFARemarks = @CFARemarks, ");
                    strAppend.Append(" InvTransporter = @InvTransporter, ");
                    strAppend.Append(" InvLRNo = @InvLRNo, ");
                    strAppend.Append(" InvDispLRdate = @InvDispLRdate, ");
                    strAppend.Append(" InvDispDelDate = @InvDispDelDate, ");
                    strAppend.Append(" ChequeNumber = @ChequeNumber, ");
                    strAppend.Append(" Date = @Date, ");
                    strAppend.Append(" Amount = @Amount, ");
                    strAppend.Append(" DepositDate = @DepositDate, ");
                    strAppend.Append(" Cases = @Cases, ");
                    strAppend.Append(" TentativeDel = @TentativeDel, ");

                    //strAppend.Append(" IsAuth = @IsAuth, ");
                    //strAppend.Append(" Authdate = getdate(), ");

                    strAppend.Append(" LastModify = getdate() ");
                    strAppend.Append(" WHERE Delivery = @Delivery ");

                    SqlCommand objcmd = new SqlCommand(strAppend.ToString());

                    objcmd.Parameters.AddWithValue("@IOMNo", int.Parse(lbliomno.Text));
                    objcmd.Parameters.AddWithValue("@Delivery", long.Parse(txtDelivery.Text));   //objcmd.Parameters.AddWithValue("@Delivery", int.Parse(txtDelivery.Text));
                    objcmd.Parameters.AddWithValue("@HORemarks", txtHORemark.Text);
                    objcmd.Parameters.AddWithValue("@CFARemarks", txtCFARemark.Text);
                    objcmd.Parameters.AddWithValue("@InvTransporter", txtInvTransporter.Text);
                    objcmd.Parameters.AddWithValue("@InvLRNo", txtInvLRNo.Text);

                    if (dtpInvDispLRDate.Checked == true)
                    {
                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            objcmd.Parameters.AddWithValue("@InvDispLRdate", DateTime.Parse(dtpInvDispLRDate.Text, dateformat));
                        }
                        else
                        {
                            objcmd.Parameters.AddWithValue("@InvDispLRdate", DateTime.Parse(dtpInvDispLRDate.Text).ToString(_dateformat));
                        }
                    }
                    else
                        objcmd.Parameters.AddWithValue("@InvDispLRdate", DBNull.Value);

                    if (dtpInvDispDelDate.Checked == true)
                    {
                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            objcmd.Parameters.AddWithValue("@InvDispDelDate", DateTime.Parse(dtpInvDispDelDate.Text, dateformat));
                        }
                        else
                        {
                            objcmd.Parameters.AddWithValue("@InvDispDelDate", DateTime.Parse(dtpInvDispDelDate.Text).ToString(_dateformat));
                        }
                    }
                    else
                        objcmd.Parameters.AddWithValue("@InvDispDelDate", DBNull.Value);

                    objcmd.Parameters.AddWithValue("@ChequeNumber", txtChequeNo.Text);

                    if (dtpDate.Checked == true)
                    {
                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            objcmd.Parameters.AddWithValue("@Date", DateTime.Parse(dtpDate.Text, dateformat));
                        }
                        else
                        {
                            objcmd.Parameters.AddWithValue("@Date", DateTime.Parse(dtpDate.Text).ToString(_dateformat));
                        }
                    }
                    else
                        objcmd.Parameters.AddWithValue("@Date", DBNull.Value);

                    if (txtAmount.Text != "")
                        objcmd.Parameters.AddWithValue("@Amount", decimal.Parse(txtAmount.Text));
                    else
                        objcmd.Parameters.AddWithValue("@Amount", 0);

                    if (dtpDispositDate.Checked == true)
                    {
                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            objcmd.Parameters.AddWithValue("@DepositDate", DateTime.Parse(dtpDispositDate.Text, dateformat));
                        }
                        else
                        {
                            objcmd.Parameters.AddWithValue("@DepositDate", DateTime.Parse(dtpDispositDate.Text).ToString(_dateformat));
                        }
                    }
                    else
                        objcmd.Parameters.AddWithValue("@DepositDate", DBNull.Value);

                    objcmd.Parameters.AddWithValue("@Cases", txtCases.Text);

                    if (dtpTentativeDelDate.Checked == true)
                    {
                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            objcmd.Parameters.AddWithValue("@TentativeDel", DateTime.Parse(dtpTentativeDelDate.Text, dateformat));
                        }
                        else
                        {
                            objcmd.Parameters.AddWithValue("@TentativeDel", DateTime.Parse(dtpTentativeDelDate.Text).ToString(_dateformat));
                        }
                    }
                    else
                        objcmd.Parameters.AddWithValue("@TentativeDel", DBNull.Value);

                    objcmd.Parameters.AddWithValue("@IsAuth", chkauth.Checked ? 1 : 0);

                    SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                    spInsertedKey.Direction = ParameterDirection.Output;
                    objcmd.Parameters.Add(spInsertedKey);

                    Result objResult = objCF.ExecuteNewDMLQuery(objcmd);
                    if (objResult.bStatus)
                    {
                        lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                        lblStatus.Text = "Dispatch Detail Updated Sucessfully";

                        ClearForm();
                        //bindBillingDocumentEdit();
                        //bindGridBillDoc("SELECT distinct IOMNo, BillingDocument, PartyCode, Plnt, Priority from STNUpload where 1 = 2");
                        //bindGridBillDoc("SELECT distinct STNUpload.IOMNo,OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.BillingDocument,STNUpload.Delivery, STNUpload.PartyCode as 'STN PartyCode', STNUpload.Plnt, STNUpload.Priority,STNUpload.deliverydate,OrderHeader.DispThrough, OrderHeader.DocumentRequired,orderheader.StampingID, OrderHeader.MRP from STNUpload, OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO and STNUpload.Delivery in (select STNInvoice_Dispatch.Delivery from STNInvoice_Dispatch) and STNUpload.Delivery != ''");

                        //Commented on 23/09/2012
                        //bindGridBillDoc(@" SELECT distinct STNUpload.IOMNo,OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.Plnt,OrderHeader.DispThrough, 
                        //     STNUpload.Delivery, STNUpload.deliverydate as ACGIDate, STNUpload.BillingDocument as PreInvoice,
                        //     STNUpload.Priority,OrderHeader.DocumentRequired,orderheader.StampingID,OrderHeader.MRP, STNUpload.PartyCode as 'STN PartyCode'
                        //     from STNUpload, OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO 
                        //     and STNUpload.Delivery in (select STNInvoice_Dispatch.Delivery from STNInvoice_Dispatch) and STNUpload.Delivery != ''");

                        bindGridBillDoc(@"select * from  ( " + QueryEdit + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))");

                        //chkAdd.Checked = false;
                        //chkEdit.Checked = false;
                    }
                    else
                    {
                        lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                        lblStatus.Text = objResult.strMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n frmDispatch/ Update function \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool validateForm()
        {
            errorDispatch.Clear();
            bool isValid = true;

            if (txtDelivery.Text == "")
            {
                errorDispatch.SetError(txtDelivery, "Select Delivery ");
                isValid = false;
            }

            //if (txtCFARemark.Text == "")
            //{
            //    errorDispatch.SetError(txtCFARemark, "CFA Remark");
            //    isValid = false;
            //}

            //if (txtInvTransporter.Text == "")
            //{
            //    errorDispatch.SetError(txtInvTransporter, "Invoice Transporter");
            //    isValid = false;
            //}

            //if (txtInvLRNo.Text == "")
            //{
            //    errorDispatch.SetError(txtInvLRNo, "Invoice LR Number");
            //    isValid = false;
            //}

            //if (txtChequeNo.Text == "")
            //{
            //    errorDispatch.SetError(txtChequeNo, "Cheque Number");
            //    isValid = false;
            //}

            //if (ddlBillingDocument.SelectedIndex == 0)
            //{
            //    errorDispatch.SetError(ddlBillingDocument, "Billing Document");
            //    isValid = false;
            //}

            //if (ddlBillingDocument.Text == "")
            //{
            //    errorDispatch.SetError(ddlBillingDocument, "check null value");
            //    isValid = false;
            //}

            //if (txtAmount.Text == "")
            //{
            //    errorDispatch.SetError(txtAmount, "Amount");
            //    isValid = false;
            //}

            //if (txtDelivery.Text == "")
            //{
            //    errorDispatch.SetError(txtDelivery, "Billing Document");
            //    isValid = false;
            //}

            //try
            //{
            //    decimal intAmount = decimal.Parse(txtAmount.Text);
            //}
            //catch (Exception ex)
            //{
            //    errorDispatch.SetError(txtAmount, "Only Numeric");
            //    return isValid = false;
            //}

            //try
            //{
            //    int billDoc = int.Parse(txtDelivery.Text);
            //}
            //catch (Exception ex)
            //{
            //    errorDispatch.SetError(txtDelivery, "Only Numeric");
            //    return isValid = false;
            //}


            //if (cmbStatus.SelectedValue == "")
            //{
            //    errorInstitution.SetError(cmbStatus, "Status");
            //    isValid = false;
            //}

            return isValid;
        }

        private void ClearForm()
        {
            chkauth.Checked = false;
            txtHORemark.Text = "";
            txtCFARemark.Text = "";
            txtInvTransporter.Text = "";
            txtInvLRNo.Text = "";
            txtChequeNo.Text = "";
            txtAmount.Text = "";
            txtDelivery.Text = "";
            txtCases.Text = "";
            //dtpDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //dtpDispositDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //dtpInvDispDelDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //dtpInvDispLRDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void dgvBillingDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int IOMNo = 0;
                long Delivery = 0;
                if (e.RowIndex != -1)
                {
                    IOMNo = int.Parse(dgvBillingDoc.Rows[e.RowIndex].Cells["IOMNo"].Value.ToString());
                    Delivery = long.Parse(dgvBillingDoc.Rows[e.RowIndex].Cells["Delivery"].Value.ToString());

                    //id = int.Parse(dgvBillingDoc.Rows[e.RowIndex].Cells["Delivery"].Value.ToString());

                    txtDelivery.Text = Delivery.ToString();
                    IOMNO = int.Parse(dgvBillingDoc.Rows[e.RowIndex].Cells["IOMNO"].Value.ToString());
                    lbliomno.Text = IOMNO.ToString();

                    if (e.ColumnIndex == dgvBillingDoc.Columns["colEdit"].Index)
                    {
                        lblStatus.Text = "";


                        fn_getDispatchDetail(Delivery, IOMNO);

                    }

                    if (e.ColumnIndex == dgvBillingDoc.Columns["colView"].Index)
                    {
                        DispatchDetail objDispatchDetail = new DispatchDetail(Convert.ToString(Delivery), 2);  // 2 for  STNUpload table

                        FormCollection fc = Application.OpenForms;
                        foreach (Form frm in fc)
                        {
                            if (frm.Name == "DispatchDetail")
                            {
                                if (MessageBox.Show("Dispatch Detail Form Already Open") == DialogResult.OK)
                                    frm.Activate();
                                return;
                            }
                        }

                        objDispatchDetail.Show();
                    }

                    if (e.ColumnIndex == dgvBillingDoc.Columns["colAuthorise"].Index)
                    {
                        CommonFunction objCommFunc = new CommonFunction();
                        SqlCommand objcomm = new SqlCommand("INSERT INTO STNInvoice_Dispatch (IOMNo,Delivery, HORemarks, CFARemarks, InvTransporter, InvLRNo, ChequeNumber, Amount, Cases, IsAuth, Authdate, LastModify) VALUES (@IOMNo, @Delivery, @HORemarks, @CFARemarks, @InvTransporter, @InvLRNo, @ChequeNumber, @Amount, @Cases, 1, getdate(), getdate()); SELECT @pk_new = @@IDENTITY");
                        objcomm.Parameters.AddWithValue("@IOMNo", IOMNo);
                        objcomm.Parameters.AddWithValue("@Delivery", Delivery);
                        objcomm.Parameters.AddWithValue("@HORemarks", "");
                        objcomm.Parameters.AddWithValue("@CFARemarks", "");
                        objcomm.Parameters.AddWithValue("@InvTransporter", "");
                        objcomm.Parameters.AddWithValue("@InvLRNo", "");
                        objcomm.Parameters.AddWithValue("@ChequeNumber", "");
                        objcomm.Parameters.AddWithValue("@Amount", 0);
                        objcomm.Parameters.AddWithValue("@Cases", "");

                        SqlParameter spInsertKey = new SqlParameter("@pk_new", SqlDbType.Int);
                        spInsertKey.Direction = ParameterDirection.Output;
                        objcomm.Parameters.Add(spInsertKey);

                        Result objResult = objCommFunc.InsertNewQuery(objcomm);
                        if (objResult.bStatus)
                        {
                            //bindGridBillDoc(@"select * from  ( " + QueryAdd + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))");
                            bindGridBillDoc(@"select * from  ( " + QueryAdd + " ) as tempTbl");
                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            lblStatus.Text = objResult.strMessage + " - " + objResult.eException;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Location Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            chkAdd.Checked = false;
            chkEdit.Checked = false;

            dgvBillingDoc.DataSource = null;

            dtpInvDispLRDate.Checked = false;
            dtpInvDispDelDate.Checked = false;
            dtpTentativeDelDate.Checked = false;
            dtpDispositDate.Checked = false;
            dtpDate.Checked = false;
        }

        private void gbDispatchDetail_Enter(object sender, EventArgs e)
        {

        }

        private void btnIOMNo_Click(object sender, EventArgs e)
        {
            FilterIOMNoResult();
        }

        private void btnBillingDoc_Click(object sender, EventArgs e)
        {
            FilterBillingDocResult();
        }

        protected void FilterIOMNoResult()
        {
            try
            {
                //string strIOMNo = "";
                //foreach (object itemChecked in chkIOMNo.CheckedItems)
                //{
                //    DataRowView castedItem = itemChecked as DataRowView;

                //    if (strIOMNo == "")
                //    {
                //        strIOMNo = castedItem["IomNo"].ToString();
                //    }
                //    else
                //    {
                //        strIOMNo += ", " + castedItem["IomNo"].ToString();
                //    }
                //}
                if (ddlIOMNO.Text != "")
                {
                    if (chkAdd.Checked == true)
                    {
                        chkauth.Visible = true;

                        bindGridBillDoc("select * from ( " + QueryAdd + " ) as tempTbl where IOMNo in (" + ddlIOMNO.Text + ")");

                        bindAddIOMNoAndBillingDoc();

                        chkEdit.Checked = false;
                        flag = 0;
                        ClearForm();
                        lblStatus.Text = "";
                    }
                    else if (chkEdit.Checked == true)
                    {
                        chkauth.Visible = false;

                        bindGridBillDoc("select * from ( " + QueryEdit + " ) as tempTbl where IOMNo in (" + ddlIOMNO.Text + ")");

                        chkAdd.Checked = false;
                        flag = 1;
                        ClearForm();
                        lblStatus.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void FilterBillingDocResult()
        {
            try
            {
                //string strBillingDoc = "";
                //foreach (object itemChecked in chkBillingDoc.CheckedItems)
                //{
                //    DataRowView castedItem = itemChecked as DataRowView;

                //    if (strBillingDoc == "")
                //    {
                //        strBillingDoc = "'" + castedItem["PreInvoice"].ToString() + "'";
                //    }
                //    else
                //    {
                //        strBillingDoc += ", " + "'" + castedItem["PreInvoice"].ToString() + "'";
                //    }
                //}
                if (ddlPreInvoice.Text != "")
                {
                    if (chkAdd.Checked == true)
                    {
                        chkauth.Visible = true;

                        bindGridBillDoc("select * from ( " + QueryAdd + " ) as tempTbl where Delivery in (" + ddlPreInvoice.Text + ")");

                        bindAddIOMNoAndBillingDoc();

                        chkEdit.Checked = false;
                        flag = 0;
                        ClearForm();
                        lblStatus.Text = "";

                    }
                    else if (chkEdit.Checked == true)
                    {
                        chkauth.Visible = false;

                        bindGridBillDoc("select * from ( " + QueryEdit + " ) as tempTbl where Delivery in (" + ddlPreInvoice.Text + ")");


                        chkAdd.Checked = false;
                        flag = 1;
                        ClearForm();
                        lblStatus.Text = "";

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            if (chkAdd.Checked == true)
            {
                chkauth.Visible = true;

                bindGridBillDoc(QueryAdd);

                bindAddIOMNoAndBillingDoc();

                chkEdit.Checked = false;
                flag = 0;
                ClearForm();
                lblStatus.Text = "";
            }
            else if (chkEdit.Checked == true)
            {
                chkauth.Visible = false;

                bindGridBillDoc(QueryEdit);


                chkAdd.Checked = false;
                flag = 1;
                ClearForm();
                lblStatus.Text = "";
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnAllAuthorise_Click(object sender, EventArgs e)
        {
            if (chkAdd.Checked == true && dgvBillingDoc.RowCount > 0)
            {
                CommonFunction objCommFunc = new CommonFunction();
                SqlCommand objcomm = new SqlCommand(@"INSERT INTO STNInvoice_Dispatch (IOMNo,Delivery, HORemarks, CFARemarks, InvTransporter, InvLRNo, ChequeNumber, Amount, Cases, IsAuth, Authdate, LastModify) 
select IOMNo,Delivery,'' as HORemarks,'' as CFARemarks,'' as InvTransporter,'' as InvLRNo,'' as ChequeNumber,0 as Amount,'' as Cases,
1 as IsAuth,getdate() as Authdate,getdate() as LastModify from (SELECT distinct STNUpload.IOMNo,OrderHeader.IOMDate, OrderHeader.PartyCode,OrderHeader.PartyName, STNUpload.Plnt,OrderHeader.DispThrough, 
STNUpload.Delivery, STNUpload.deliverydate as ACGIDate, STNUpload.BillingDocument as PreInvoice,
STNUpload.Priority,OrderHeader.DocumentRequired,orderheader.StampingID,OrderHeader.MRP, STNUpload.PartyCode as 'STN PartyCode'
from STNUpload, OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO  and STNUpload.Delivery not in (select STNInvoice_Dispatch.Delivery from STNInvoice_Dispatch) 
and STNUpload.Delivery != '' and STNUpload.OrdUpdated=1) as a");
                Result objResult = objCommFunc.ExecuteNewDMLQuery(objcomm);
                if (objResult.bStatus)
                {
                    //bindGridBillDoc(@"select * from  ( " + QueryAdd + " ) as tempTbl where Plnt in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))");
                    bindGridBillDoc(@"select * from  ( " + QueryAdd + " ) as tempTbl");
                    MessageBox.Show("All records are successfully Authorised.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    lblStatus.Text = objResult.strMessage + " - " + objResult.eException;
                    MessageBox.Show(lblStatus.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No Record Available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



    }
}
