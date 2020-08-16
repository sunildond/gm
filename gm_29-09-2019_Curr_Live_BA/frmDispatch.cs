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
using System.Data.OleDb;
using System.Net;

namespace gm
{
    public partial class frmDispatch : Form
    {
        string strLogFileName = "LOG/LogRecord.txt";
        private string _dateformat = "MM/dd/yyyy";
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _Strdateformat = "MM/dd/yyyy";
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        CommonFunction objC = null;
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private int id;
        private string BDoc = string.Empty;
        private int flag = 0;
        public string QueryAdd = string.Empty;
        public string QueryEdit = string.Empty;
        public string QueryAddForDDL = string.Empty;
        public string QueryEditForDDL = string.Empty;
        string FileName = string.Empty;
        string filepth = string.Empty;

        //Variable for Upload File
        int Count = 0;
        long IOMNO = 0;
        string BillingDocument = string.Empty;
        string InvTransporter = string.Empty;
        string InvLRNo = string.Empty;
        DateTime InvDispLRdate;
        DateTime InvDispDelDate;
        int Cases = 0;


        public frmDispatch()
        {
            InitializeComponent();
        }

        private void frmDispatch_Load(object sender, EventArgs e)
        {
            txtBillingDocument.ReadOnly = true;
            chkauth.Visible = false;

            dtpInvDispLRDate.Checked = false;
            dtpInvDispDelDate.Checked = false;
            dtpDate.Checked = false;
            dtpDispositDate.Checked = false;
            dtpTentativeDelDate.Checked = false;

            QueryAdd = @" select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, SAPInvoiceUpload.BillingDocument,SAPInvoiceUpload.IOMNo as 'StnNo', 
                    OrderHeader.PartyCode,OrderHeader.PartyName,   SAPInvoiceUpload.SoldToParty as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      
                    StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    SAPInvoiceUpload.Priority, OrderHeader.LocationCode as 'Plant' 
                    from SAPInvoiceUpload,STNUpload,OrderHeader,StampingMaster where   SAPInvoiceUpload.IOMNo=STNUpload.Delivery 
                    and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId 
                    and  SAPInvoiceUpload.BillingDocument not in (select  BillingDocument from Invoice_Dispatch) and SAPInvoiceUpload.OrdUpdated=1 
                    and STNUpload.RStatus = 'OK'
                    Union all 
                    select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, DirSAPInvoiceUpload.BillingDocument,DirSAPInvoiceUpload.IOMNo as 'StnNo', 
                    OrderHeader.PartyCode,OrderHeader.PartyName,   DirSAPInvoiceUpload.SoldToParty as 'INV PartyCode', DirSAPInvoiceUpload.BillingDate as 'STN DelDate',      
                    StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    DirSAPInvoiceUpload.Priority, OrderHeader.LocationCode as 'Plant'  
                    from DirSAPInvoiceUpload,OrderHeader,StampingMaster where OrderHeader.StampingID=StampingMaster.StampingId 
                    and OrderHeader.IOMNo=DirSAPInvoiceUpload.IOMNo and DirSAPInvoiceUpload.BillingDocument  not in (select  BillingDocument from Invoice_Dispatch) 
                    and DirSAPInvoiceUpload.OrdUpdated=1 
                    Union all 
                    select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, IBISBillingUpdate.DocumentNumber as  BillingDocument,
                    IBISBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   
                    IBISBillingUpdate.PartyCode as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      
                    StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,   '' As Priority, OrderHeader.LocationCode as 'Plant' 
                    from IBISBillingUpdate,STNUpload,OrderHeader,
                    StampingMaster where   IBISBillingUpdate.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo 
                    and OrderHeader.StampingID=StampingMaster.StampingId 
                    and  IBISBillingUpdate.DocumentNumber not in (select  BillingDocument from Invoice_Dispatch) and IBISBillingUpdate.OrdUpdated=1 
                    and STNUpload.RStatus = 'OK'
                    Union all 
                    select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, IBISDirectBillingUpdate.DocumentNumber as  BillingDocument,
                    IBISDirectBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   IBISDirectBillingUpdate.PartyCode as 'INV PartyCode', 
                    IBISDirectBillingUpdate.LR_DT as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,  '' As Priority, OrderHeader.LocationCode as 'Plant'    
                    from IBISDirectBillingUpdate,OrderHeader,StampingMaster where  IBISDirectBillingUpdate.IOMNO=OrderHeader.IOMNo and 
                    OrderHeader.StampingID=StampingMaster.StampingId and  IBISDirectBillingUpdate.DocumentNumber not in (select  BillingDocument from Invoice_Dispatch) 
                    and IBISDirectBillingUpdate.OrdUpdated=1 ";

            QueryEdit = @" select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, SAPInvoiceUpload.BillingDocument,SAPInvoiceUpload.IOMNo as 'StnNo', 
                     OrderHeader.PartyCode,OrderHeader.PartyName,   SAPInvoiceUpload.SoldToParty as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      
                     StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    SAPInvoiceUpload.Priority, OrderHeader.LocationCode as 'Plant'  
                     from SAPInvoiceUpload,STNUpload,OrderHeader,StampingMaster where   SAPInvoiceUpload.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo 
                     and OrderHeader.StampingID=StampingMaster.StampingId and  SAPInvoiceUpload.BillingDocument in (select  BillingDocument from Invoice_Dispatch) 
                     and SAPInvoiceUpload.OrdUpdated=1 
                     Union all 
                     select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, DirSAPInvoiceUpload.BillingDocument,DirSAPInvoiceUpload.IOMNo as 'StnNo',
                      OrderHeader.PartyCode,OrderHeader.PartyName,   DirSAPInvoiceUpload.SoldToParty as 'INV PartyCode', DirSAPInvoiceUpload.BillingDate as 'STN DelDate',      
                      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    DirSAPInvoiceUpload.Priority, OrderHeader.LocationCode as 'Plant'    
                      from DirSAPInvoiceUpload,OrderHeader,StampingMaster where   OrderHeader.StampingID=StampingMaster.StampingId 
                      and OrderHeader.IOMNo=DirSAPInvoiceUpload.IOMNo and DirSAPInvoiceUpload.BillingDocument  in (select  BillingDocument from Invoice_Dispatch) 
                      and DirSAPInvoiceUpload.OrdUpdated=1 
                    Union all 
                    select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, 
                      IBISBillingUpdate.DocumentNumber as  BillingDocument,IBISBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   
                      IBISBillingUpdate.PartyCode as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate', StampingMaster.name  as 'Stamping',OrderHeader.MRP,
                      OrderHeader.DispThrough,   '' As Priority, OrderHeader.LocationCode as 'Plant' 
                        from IBISBillingUpdate,STNUpload,OrderHeader,StampingMaster 
                      where   IBISBillingUpdate.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  
                      IBISBillingUpdate.DocumentNumber in (select  BillingDocument from Invoice_Dispatch) and IBISBillingUpdate.OrdUpdated=1 
                      Union all 
                      select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, IBISDirectBillingUpdate.DocumentNumber as  BillingDocument,
                      IBISDirectBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   IBISDirectBillingUpdate.PartyCode as 'INV PartyCode', 
                      IBISDirectBillingUpdate.LR_DT as 'STN DelDate', StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,   '' As Priority, OrderHeader.LocationCode as 'Plant' 
                       from IBISDirectBillingUpdate,OrderHeader,StampingMaster where  IBISDirectBillingUpdate.IOMNO=OrderHeader.IOMNo 
                       and OrderHeader.StampingID=StampingMaster.StampingId and  IBISDirectBillingUpdate.DocumentNumber in (select  BillingDocument from Invoice_Dispatch) 
                       and IBISDirectBillingUpdate.OrdUpdated=1 ";

            QueryAddForDDL = @" select distinct  OrderHeader.IOMNo  as 'IomNo', CONVERT(varchar(100),OrderHeader.IOMNo) as IOM,OrderHeader.IOMDate, SAPInvoiceUpload.BillingDocument,SAPInvoiceUpload.IOMNo as 'StnNo', 
                    OrderHeader.PartyCode,OrderHeader.PartyName,   SAPInvoiceUpload.SoldToParty as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      
                    StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    SAPInvoiceUpload.Priority, OrderHeader.LocationCode as 'Plant' 
                    from SAPInvoiceUpload,STNUpload,OrderHeader,StampingMaster where   SAPInvoiceUpload.IOMNo=STNUpload.Delivery 
                    and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId 
                    and  SAPInvoiceUpload.BillingDocument not in (select  BillingDocument from Invoice_Dispatch) and SAPInvoiceUpload.OrdUpdated=1 
                    and STNUpload.RStatus = 'OK'
                    Union all 
                    select distinct  OrderHeader.IOMNo  as 'IomNo',CONVERT(varchar(100),OrderHeader.IOMNo) as IOM,OrderHeader.IOMDate, DirSAPInvoiceUpload.BillingDocument,DirSAPInvoiceUpload.IOMNo as 'StnNo', 
                    OrderHeader.PartyCode,OrderHeader.PartyName,   DirSAPInvoiceUpload.SoldToParty as 'INV PartyCode', DirSAPInvoiceUpload.BillingDate as 'STN DelDate',      
                    StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    DirSAPInvoiceUpload.Priority, OrderHeader.LocationCode as 'Plant'  
                    from DirSAPInvoiceUpload,OrderHeader,StampingMaster where   OrderHeader.StampingID=StampingMaster.StampingId 
                    and OrderHeader.IOMNo=DirSAPInvoiceUpload.IOMNo and DirSAPInvoiceUpload.BillingDocument  not in (select  BillingDocument from Invoice_Dispatch) 
                    and DirSAPInvoiceUpload.OrdUpdated=1 
                    Union all 
                    select distinct  OrderHeader.IOMNo  as 'IomNo',CONVERT(varchar(100),OrderHeader.IOMNo) as IOM,OrderHeader.IOMDate, IBISBillingUpdate.DocumentNumber as  BillingDocument,
                    IBISBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   
                    IBISBillingUpdate.PartyCode as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      
                    StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,   '' As Priority, OrderHeader.LocationCode as 'Plant' 
                    from IBISBillingUpdate,STNUpload,OrderHeader,
                    StampingMaster where   IBISBillingUpdate.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo 
                    and OrderHeader.StampingID=StampingMaster.StampingId 
                    and  IBISBillingUpdate.DocumentNumber not in (select  BillingDocument from Invoice_Dispatch) and IBISBillingUpdate.OrdUpdated=1 
                    and STNUpload.RStatus = 'OK'
                    Union all 
                    select distinct  OrderHeader.IOMNo  as 'IomNo',CONVERT(varchar(100),OrderHeader.IOMNo) as IOM,OrderHeader.IOMDate, IBISDirectBillingUpdate.DocumentNumber as  BillingDocument,
                    IBISDirectBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   IBISDirectBillingUpdate.PartyCode as 'INV PartyCode', 
                    IBISDirectBillingUpdate.LR_DT as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,  '' As Priority, OrderHeader.LocationCode as 'Plant'    
                    from IBISDirectBillingUpdate,OrderHeader,StampingMaster where  IBISDirectBillingUpdate.IOMNO=OrderHeader.IOMNo and 
                    OrderHeader.StampingID=StampingMaster.StampingId and  IBISDirectBillingUpdate.DocumentNumber not in (select  BillingDocument from Invoice_Dispatch) 
                    and IBISDirectBillingUpdate.OrdUpdated=1 ";

            QueryEditForDDL = @" select distinct  OrderHeader.IOMNo  as 'IomNo',CONVERT(varchar(100),OrderHeader.IOMNo) as IOM,OrderHeader.IOMDate, SAPInvoiceUpload.BillingDocument,SAPInvoiceUpload.IOMNo as 'StnNo', 
                     OrderHeader.PartyCode,OrderHeader.PartyName,   SAPInvoiceUpload.SoldToParty as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      
                     StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    SAPInvoiceUpload.Priority, OrderHeader.LocationCode as 'Plant'  
                     from SAPInvoiceUpload,STNUpload,OrderHeader,StampingMaster where   SAPInvoiceUpload.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo 
                     and OrderHeader.StampingID=StampingMaster.StampingId and  SAPInvoiceUpload.BillingDocument in (select  BillingDocument from Invoice_Dispatch) 
                     and SAPInvoiceUpload.OrdUpdated=1 
                     Union all 
                     select distinct  OrderHeader.IOMNo  as 'IomNo',CONVERT(varchar(100),OrderHeader.IOMNo) as IOM,OrderHeader.IOMDate, DirSAPInvoiceUpload.BillingDocument,DirSAPInvoiceUpload.IOMNo as 'StnNo',
                      OrderHeader.PartyCode,OrderHeader.PartyName,   DirSAPInvoiceUpload.SoldToParty as 'INV PartyCode', DirSAPInvoiceUpload.BillingDate as 'STN DelDate',      
                      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    DirSAPInvoiceUpload.Priority, OrderHeader.LocationCode as 'Plant'    
                      from DirSAPInvoiceUpload,OrderHeader,StampingMaster where   OrderHeader.StampingID=StampingMaster.StampingId 
                      and OrderHeader.IOMNo=DirSAPInvoiceUpload.IOMNo and DirSAPInvoiceUpload.BillingDocument  in (select  BillingDocument from Invoice_Dispatch) 
                      and DirSAPInvoiceUpload.OrdUpdated=1 
                    Union all 
                    select distinct  OrderHeader.IOMNo  as 'IomNo',CONVERT(varchar(100),OrderHeader.IOMNo) as IOM,OrderHeader.IOMDate, 
                      IBISBillingUpdate.DocumentNumber as  BillingDocument,IBISBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   
                      IBISBillingUpdate.PartyCode as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate', StampingMaster.name  as 'Stamping',OrderHeader.MRP,
                      OrderHeader.DispThrough,   '' As Priority, OrderHeader.LocationCode as 'Plant' 
                        from IBISBillingUpdate,STNUpload,OrderHeader,StampingMaster 
                      where   IBISBillingUpdate.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  
                      IBISBillingUpdate.DocumentNumber in (select  BillingDocument from Invoice_Dispatch) and IBISBillingUpdate.OrdUpdated=1 
                      Union all 
                      select distinct  OrderHeader.IOMNo  as 'IomNo',CONVERT(varchar(100),OrderHeader.IOMNo) as IOM,OrderHeader.IOMDate, IBISDirectBillingUpdate.DocumentNumber as  BillingDocument,
                      IBISDirectBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   IBISDirectBillingUpdate.PartyCode as 'INV PartyCode', 
                      IBISDirectBillingUpdate.LR_DT as 'STN DelDate', StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,   '' As Priority, OrderHeader.LocationCode as 'Plant' 
                       from IBISDirectBillingUpdate,OrderHeader,StampingMaster where  IBISDirectBillingUpdate.IOMNO=OrderHeader.IOMNo 
                       and OrderHeader.StampingID=StampingMaster.StampingId and  IBISDirectBillingUpdate.DocumentNumber in (select  BillingDocument from Invoice_Dispatch) 
                       and IBISDirectBillingUpdate.OrdUpdated=1 ";

            //if (DBSessionUser.bAddPerm == true)
            //{
            //    if (DBSessionUser.strUserLocation != "")
            //    {
            //        QueryAdd = "select * from  ( " + QueryAdd + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
            //        QueryAddForDDL = "select * from  ( " + QueryAddForDDL + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
            //    }

            //    chkAdd.Visible = true;
            //    chkEdit.Visible = false;
            //}
            //else if (DBSessionUser.bEditPerm == true)
            //{
            //    if (DBSessionUser.strUserLocation != "")
            //    {
            //        QueryEdit = "select * from  ( " + QueryEdit + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
            //        QueryEditForDDL = "select * from  ( " + QueryEditForDDL + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
            //    }

            //    chkAdd.Visible = false;
            //    chkEdit.Visible = true;
            //}

            if (DBSessionUser.bAddPerm == true && DBSessionUser.bEditPerm == false)
            {
                //if (DBSessionUser.strUserLocation != "")
                //{
                //    QueryAdd = "select * from  ( " + QueryAdd + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                //    QueryAddForDDL = "select * from  ( " + QueryAddForDDL + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                //}

                chkAdd.Visible = true;
                chkEdit.Visible = false;
            }
            else if (DBSessionUser.bAddPerm == false && DBSessionUser.bEditPerm == true)
            {
                //if (DBSessionUser.strUserLocation != "")
                //{
                //    QueryEdit = "select * from  ( " + QueryEdit + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                //    QueryEditForDDL = "select * from  ( " + QueryEditForDDL + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                //}

                chkAdd.Visible = false;
                chkEdit.Visible = true;
            }
            else if (DBSessionUser.bAddPerm == false && DBSessionUser.bEditPerm == false)
            {
                //if (DBSessionUser.strUserLocation != "")
                //{
                //    QueryEdit = "select * from  ( " + QueryEdit + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                //    QueryEditForDDL = "select * from  ( " + QueryEditForDDL + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                //}

                chkAdd.Visible = false;
                chkEdit.Visible = false;
            }
            else if (DBSessionUser.bAddPerm == true && DBSessionUser.bEditPerm == true)
            {
                //if (DBSessionUser.strUserLocation != "")
                //{
                //    QueryEdit = "select * from  ( " + QueryEdit + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                //    QueryEditForDDL = "select * from  ( " + QueryEditForDDL + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                //}

                chkAdd.Visible = true;
                chkEdit.Visible = true;
            }

            if (DBSessionUser.strUserLocation != "")
            {
                QueryAdd = "select * from  ( " + QueryAdd + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                QueryAddForDDL = "select * from  ( " + QueryAddForDDL + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                QueryEdit = "select * from  ( " + QueryEdit + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
                QueryEditForDDL = "select * from  ( " + QueryEditForDDL + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))";
            }
            else
            {
                QueryAdd = "";
                QueryAddForDDL = "";
                QueryEdit = "";
                QueryEditForDDL = "";
            }
            btnAllAuthorise.Visible = false;
            grpUpload.Visible = false;
        }

        //private void bindBillingDocumentAdd()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        CommonFunction objCommon = new CommonFunction();

        //        dt = objCommon.GetDataTable("SELECT distinct (BillingDocument) from SAPInvoiceUpload  where BillingDocument not in (select BillingDocument from Invoice_Dispatch) and BillingDocument != ''");
        //        DataRow dr = dt.NewRow();
        //        dr["BillingDocument"] = 0;
        //        dr["BillingDocument"] = "select";
        //        dt.Rows.InsertAt(dr, 0);
        //        ddlBillingDocument.DataSource = dt;
        //        ddlBillingDocument.DisplayMember = "BillingDocument";
        //        ddlBillingDocument.ValueMember = "BillingDocument";

        //    }
        //    catch (Exception ex)
        //    {
        //        StreamWriter swLog = File.AppendText(strLogFileName);
        //        string strError = DateTime.Now.ToString() + "\n Main Page/frmDispatch bindBillingDocumentAdd \n" + ex.ToString();
        //        swLog.WriteLine(strError);
        //        swLog.WriteLine();
        //        swLog.Close();
        //        MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void bindBillingDocumentEdit()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        CommonFunction objCommon = new CommonFunction();

        //        dt = objCommon.GetDataTable("SELECT distinct (BillingDocument) from SAPInvoiceUpload  where BillingDocument in (select BillingDocument from Invoice_Dispatch) and BillingDocument != ''");
        //        DataRow dr = dt.NewRow();
        //        dr["BillingDocument"] = 0;
        //        dr["BillingDocument"] = "select";
        //        dt.Rows.InsertAt(dr, 0);
        //        ddlBillingDocument.DataSource = dt;
        //        ddlBillingDocument.DisplayMember = "BillingDocument";
        //        ddlBillingDocument.ValueMember = "BillingDocument";

        //    }
        //    catch (Exception ex)
        //    {
        //        StreamWriter swLog = File.AppendText(strLogFileName);
        //        string strError = DateTime.Now.ToString() + "\n Main Page/frmDispatch bindBillingDocumentEdit \n" + ex.ToString();
        //        swLog.WriteLine(strError);
        //        swLog.WriteLine();
        //        swLog.Close();
        //        MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void ddlBillingDocument_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //try
        //{
        //if (ddlBillingDocument.SelectedIndex != 0)
        //{
        //    bindGridBillDoc(int.Parse(ddlBillingDocument.Text));

        //    if (chkEdit.Checked == true)
        //    {
        //        fn_getDispatchDetail(int.Parse(ddlBillingDocument.Text));
        //    }

        //}
        //else
        //{
        //    dgvBillingDoc.DataSource = null;
        //}
        //lblStatus.Text = "";
        //}
        //catch (Exception ex)
        //{
        //StreamWriter swLog = File.AppendText(strLogFileName);
        //string strError = DateTime.Now.ToString() + "\n frmDispatch /btnSubmitIOM_Click \n" + ex.ToString();
        //swLog.WriteLine(strError);
        //swLog.WriteLine();
        //swLog.Close();
        //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //}

        private void fn_getDispatchDetail(string DeliveryNo, int IOMNO)
        {
            try
            {
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("select * from Invoice_Dispatch where BillingDocument = '" + DeliveryNo + "'");

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    //lbliomno.Text = IOMNO.ToString();
                    txtBillingDocument.Text = dataTable.Rows[0]["BillingDocument"].ToString();
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
                lblTotalRows.Text = "Total Record: " + dgvBillingDoc.Rows.Count;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n frmDispatch/bindGridBillDoc \n" + ex.ToString();
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
                //bindGridBillDoc("SELECT distinct IOMNo, BillingDocument, SoldToParty, Name, Plnt, BillingDate, Priority from SAPInvoiceUpload where BillingDocument not in (select BillingDocument from Invoice_Dispatch) and BillingDocument != ''");
                //bindGridBillDoc("SELECT distinct STNUpload.IOMNo, OrderHeader.IOMDate, OrderHeader.PartyCode, OrderHeader.PartyName, STNUpload.BillingDocument,STNUpload.Delivery, STNUpload.PartyCode, STNUpload.Plnt, STNUpload.Priority,STNUpload.Delivery,STNUpload.AcGIdate,STNUpload.BillingDocument,OrderHeader.DispThrough, OrderHeader.DocumentRequired,orderheader.StampingID, OrderHeader.MRP from STNUpload, OrderHeader where OrderHeader.IOMNo=STNUpload.IOMNO and STNUpload.Delivery not in (select Invoice_Dispatch.Delivery from Invoice_Dispatch) and Delivery != ''");


                //bindGridBillDoc("SELECT distinct SAPInvoiceUpload.IOMNo, OrderHeader.IOMDate, OrderHeader.PartyCode, OrderHeader.PartyName, SAPInvoiceUpload.BillingDocument, SAPInvoiceUpload.Name, SAPInvoiceUpload.Plnt, SAPInvoiceUpload.Priority, SAPInvoiceUpload.BillingDate, OrderHeader.DispThrough, OrderHeader.DocumentRequired,orderheader.StampingID, OrderHeader.MRP from SAPInvoiceUpload, OrderHeader where OrderHeader.IOMNo=SAPInvoiceUpload.IOMNO and SAPInvoiceUpload.BillingDocument not in (select Invoice_Dispatch.BillingDocument from Invoice_Dispatch) and BillingDocument != ''");


                //bindGridBillDoc("select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, SAPInvoiceUpload.BillingDocument,SAPInvoiceUpload.IOMNo as 'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   SAPInvoiceUpload.SoldToParty as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    SAPInvoiceUpload.Priority   from SAPInvoiceUpload,STNUpload,OrderHeader,StampingMaster where   SAPInvoiceUpload.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  SAPInvoiceUpload.BillingDocument not in (select  BillingDocument from Invoice_Dispatch)");

                bindGridBillDoc(QueryAdd);

                //bindGridBillDoc("select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, SAPInvoiceUpload.BillingDocument,SAPInvoiceUpload.IOMNo as 'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   SAPInvoiceUpload.SoldToParty as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    SAPInvoiceUpload.Priority   from SAPInvoiceUpload,STNUpload,OrderHeader,StampingMaster where   SAPInvoiceUpload.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  SAPInvoiceUpload.BillingDocument not in (select  BillingDocument from Invoice_Dispatch) and SAPInvoiceUpload.OrdUpdated=1 Union all select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, DirSAPInvoiceUpload.BillingDocument,DirSAPInvoiceUpload.IOMNo as 'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   DirSAPInvoiceUpload.SoldToParty as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    DirSAPInvoiceUpload.Priority   from DirSAPInvoiceUpload,STNUpload,OrderHeader,StampingMaster where   DirSAPInvoiceUpload.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  DirSAPInvoiceUpload.BillingDocument not in (select  BillingDocument from Invoice_Dispatch) and DirSAPInvoiceUpload.OrdUpdated=1 Union all select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, IBISBillingUpdate.DocumentNumber as  BillingDocument,IBISBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   IBISBillingUpdate.PartyCode as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,   '' As Priority   from IBISBillingUpdate,STNUpload,OrderHeader,StampingMaster where   IBISBillingUpdate.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  IBISBillingUpdate.DocumentNumber not in (select  BillingDocument from Invoice_Dispatch) and IBISBillingUpdate.OrdUpdated=1 Union all select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, IBISDirectBillingUpdate.DocumentNumber as  BillingDocument,IBISDirectBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   IBISDirectBillingUpdate.PartyCode as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,   '' As Priority   from IBISDirectBillingUpdate,STNUpload,OrderHeader,StampingMaster where   IBISDirectBillingUpdate.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  IBISDirectBillingUpdate.DocumentNumber not in (select  BillingDocument from Invoice_Dispatch) and IBISDirectBillingUpdate.OrdUpdated=1");

                bindAddIOMNoAndBillingDoc();

                chkEdit.Checked = false;
                flag = 0;
                ClearForm();
                lblStatus.Text = "";

                //Authorise Column Visibility
                dgvBillingDoc.Columns[0].Visible = true;
                btnAllAuthorise.Visible = true;
                grpUpload.Visible = false;
            }
            else if (chkAdd.Checked == false)
            {
                //Authorise Column Visibility
                dgvBillingDoc.Columns[0].Visible = false;
                btnAllAuthorise.Visible = false;
                grpUpload.Visible = true;
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
                chkIOMNo.DisplayMember = "IomNo";
                chkIOMNo.ValueMember = "IomNo";

                chkBillingDoc.DataSource = dt;
                chkBillingDoc.DisplayMember = "BillingDocument";
                chkBillingDoc.ValueMember = "BillingDocument";

                DataTable dt1 = new DataTable();
                dt1 = objCommon.GetDataTable(QueryAddForDDL);
                ddlIOMNO.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlIOMNO.AutoCompleteMode = AutoCompleteMode.Suggest;
                DataRow dr2 = dt1.NewRow();
                dr2["IomNo"] = 0;
                dr2["IOM"] = "";

                dt1.Rows.InsertAt(dr2, 0);
                ddlIOMNO.DataSource = dt1;
                ddlIOMNO.DisplayMember = "IOM";
                ddlIOMNO.ValueMember = "IomNo";

                ddlBillingDocument.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlBillingDocument.AutoCompleteMode = AutoCompleteMode.Suggest;
                //DataRow dr1 = dt1.NewRow();
                //dr1["IOMNo"] = 0;
                //dr1["PreInvoice"] = "";
                //dt1.Rows.InsertAt(dr1, 0);
                ddlBillingDocument.DataSource = dt1;
                ddlBillingDocument.DisplayMember = "BillingDocument";
                ddlBillingDocument.ValueMember = "IomNo";


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
                chkIOMNo.DisplayMember = "IomNo";
                chkIOMNo.ValueMember = "IomNo";

                chkBillingDoc.DataSource = dt;
                chkBillingDoc.DisplayMember = "BillingDocument";
                chkBillingDoc.ValueMember = "BillingDocument";

                DataTable dt1 = new DataTable();
                dt1 = objCommon.GetDataTable(QueryEditForDDL);
                ddlIOMNO.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlIOMNO.AutoCompleteMode = AutoCompleteMode.Suggest;
                DataRow dr2 = dt1.NewRow();
                dr2["IomNo"] = 0;
                dr2["IOM"] = "";

                dt1.Rows.InsertAt(dr2, 0);
                ddlIOMNO.DataSource = dt1;
                ddlIOMNO.DisplayMember = "IOM";
                ddlIOMNO.ValueMember = "IomNo";

                ddlBillingDocument.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlBillingDocument.AutoCompleteMode = AutoCompleteMode.Suggest;
                //DataRow dr1 = dt1.NewRow();
                //dr1["IOMNo"] = 0;
                //dr1["PreInvoice"] = "";
                //dt1.Rows.InsertAt(dr1, 0);
                ddlBillingDocument.DataSource = dt1;
                ddlBillingDocument.DisplayMember = "BillingDocument";
                ddlBillingDocument.ValueMember = "IomNo";

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
                ////bindGridBillDoc("SELECT distinct IOMNo, BillingDocument, SoldToParty, Name, Plnt, BillingDate, Priority from SAPInvoiceUpload where BillingDocument in (select BillingDocument from Invoice_Dispatch) and BillingDocument != ''");
                //bindGridBillDoc("SELECT distinct SAPInvoiceUpload.IOMNo, OrderHeader.IOMDate, OrderHeader.PartyCode, OrderHeader.PartyName, SAPInvoiceUpload.BillingDocument, SAPInvoiceUpload.Name, SAPInvoiceUpload.Plnt, SAPInvoiceUpload.Priority, SAPInvoiceUpload.BillingDate, OrderHeader.DispThrough, OrderHeader.DocumentRequired,orderheader.StampingID, OrderHeader.MRP from SAPInvoiceUpload, OrderHeader where OrderHeader.IOMNo=SAPInvoiceUpload.IOMNO and SAPInvoiceUpload.BillingDocument in (select Invoice_Dispatch.BillingDocument from Invoice_Dispatch) and BillingDocument != ''");

                //bindGridBillDoc("select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, SAPInvoiceUpload.BillingDocument,SAPInvoiceUpload.IOMNo as 'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   SAPInvoiceUpload.SoldToParty as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    SAPInvoiceUpload.Priority   from SAPInvoiceUpload,STNUpload,OrderHeader,StampingMaster where   SAPInvoiceUpload.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  SAPInvoiceUpload.BillingDocument  in (select  BillingDocument from Invoice_Dispatch)");


                bindGridBillDoc(QueryEdit);

                bindEditIOMNoAndBillingDoc();

                chkAdd.Checked = false;
                flag = 1;
                ClearForm();
                lblStatus.Text = "";

                //Authorise Column Visibility
                dgvBillingDoc.Columns[0].Visible = false;
                btnAllAuthorise.Visible = false;
                grpUpload.Visible = true;
            }
            else if (chkAdd.Checked == true)
            {
                btnAllAuthorise.Visible = false;
                grpUpload.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkAdd.Checked == true)
                {
                    if (chkauth.Checked == true)
                    {
                        bool bstatus = true;
                        bstatus = validateForm();
                        if (bstatus == true)
                        {
                            string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                            CommonFunction objCF = new CommonFunction();
                            SqlCommand objcmd = new SqlCommand("INSERT INTO Invoice_Dispatch (IOMNo, Delivery, BillingDocument, HORemarks, CFARemarks, InvTransporter, InvLRNo, InvDispLRdate, InvDispDelDate, ChequeNumber, Date, Amount, DepositDate, LastModify, Cases, TentativeDel,IsAuth,Authdate,BillingDate) VALUES (@IOMNo, @Delivery, @BillingDocument, @HORemarks, @CFARemarks, @InvTransporter, @InvLRNo, @InvDispLRdate, @InvDispDelDate, @ChequeNumber, @Date, @Amount, @DepositDate, getdate(), @Cases, @TentativeDel, @IsAuth, getdate(), @BillingDate); SELECT @pk_new = @@IDENTITY");

                            objcmd.Parameters.AddWithValue("@IOMNo", int.Parse(lbliomno.Text));
                            objcmd.Parameters.AddWithValue("@Delivery", lblSTNNo.Text);

                            if (lblBillingDate.Text != "")
                            {
                                //objcmd.Parameters.AddWithValue("@BillingDate", lblBillingDate.Text);
                                if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                                {
                                    objcmd.Parameters.AddWithValue("@BillingDate", DateTime.Parse(lblBillingDate.Text, dateformat));
                                }
                                else
                                {
                                    objcmd.Parameters.AddWithValue("@BillingDate", DateTime.Parse(lblBillingDate.Text).ToString(_dateformat));
                                }
                            }
                            else
                            {
                                objcmd.Parameters.AddWithValue("@BillingDate", DBNull.Value);
                            }


                            objcmd.Parameters.AddWithValue("@BillingDocument", txtBillingDocument.Text);
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
                            objcmd.Parameters.AddWithValue("@IsAuth", chkauth.Checked ? 1 : 0);

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

                                //commneted on 23/09/2012
                                //bindGridBillDoc(" select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, SAPInvoiceUpload.BillingDocument,SAPInvoiceUpload.IOMNo as 'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   SAPInvoiceUpload.SoldToParty as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    SAPInvoiceUpload.Priority   from SAPInvoiceUpload,STNUpload,OrderHeader,StampingMaster where   SAPInvoiceUpload.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  SAPInvoiceUpload.BillingDocument not in (select  BillingDocument from Invoice_Dispatch) and SAPInvoiceUpload.OrdUpdated=1 Union all select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, DirSAPInvoiceUpload.BillingDocument,DirSAPInvoiceUpload.IOMNo as 'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   DirSAPInvoiceUpload.SoldToParty as 'INV PartyCode', DirSAPInvoiceUpload.BillingDate as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    DirSAPInvoiceUpload.Priority   from DirSAPInvoiceUpload,OrderHeader,StampingMaster where   OrderHeader.StampingID=StampingMaster.StampingId and OrderHeader.IOMNo=DirSAPInvoiceUpload.IOMNo and DirSAPInvoiceUpload.BillingDocument  not in (select  BillingDocument from Invoice_Dispatch) and DirSAPInvoiceUpload.OrdUpdated=1 Union all select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, IBISBillingUpdate.DocumentNumber as  BillingDocument,IBISBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   IBISBillingUpdate.PartyCode as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,   '' As Priority   from IBISBillingUpdate,STNUpload,OrderHeader,StampingMaster where   IBISBillingUpdate.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  IBISBillingUpdate.DocumentNumber not in (select  BillingDocument from Invoice_Dispatch) and IBISBillingUpdate.OrdUpdated=1 Union all select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, IBISDirectBillingUpdate.DocumentNumber as  BillingDocument,IBISDirectBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   IBISDirectBillingUpdate.PartyCode as 'INV PartyCode', IBISDirectBillingUpdate.LR_DT as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,   '' As Priority   from IBISDirectBillingUpdate,OrderHeader,StampingMaster where  IBISDirectBillingUpdate.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  IBISDirectBillingUpdate.DocumentNumber not in (select  BillingDocument from Invoice_Dispatch) and IBISDirectBillingUpdate.OrdUpdated=1 ");
                                bindGridBillDoc(@"select * from  ( " + QueryAdd + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))");

                                //Result objExeUpdDelivery = objCF.ExecuteDMLQuery("update Invoice_Dispatch set Invoice_Dispatch.Delivery =  SAPInvoiceUpload.IOMNo from Invoice_Dispatch, SAPInvoiceUpload where Invoice_Dispatch.IOMNO = SAPInvoiceUpload.STNIOMNo and Invoice_Dispatch.BillingDocument = SAPInvoiceUpload.BillingDocument and  Invoice_Dispatch.Delivery = 0; update Invoice_Dispatch set Invoice_Dispatch.Delivery =  IBISBillingUpdate.IOMNo from Invoice_Dispatch, IBISBillingUpdate where Invoice_Dispatch.IOMNO = IBISBillingUpdate.STNIOMNo and Invoice_Dispatch.BillingDocument = IBISBillingUpdate.DocumentNumber  and  Invoice_Dispatch.Delivery = 0");
                                Result objExeUpdDelivery = objCF.ExecuteDMLQuery("update Invoice_Dispatch set Invoice_Dispatch.Delivery =  SAPInvoiceUpload.IOMNo, Invoice_Dispatch.BillingDate = SAPInvoiceUpload.BillingDate from Invoice_Dispatch, SAPInvoiceUpload where Invoice_Dispatch.IOMNO = SAPInvoiceUpload.STNIOMNo and Invoice_Dispatch.BillingDocument = SAPInvoiceUpload.BillingDocument; update Invoice_Dispatch set Invoice_Dispatch.Delivery =  IBISBillingUpdate.IOMNo, Invoice_Dispatch.BillingDate = IBISBillingUpdate.DocumentDate from Invoice_Dispatch, IBISBillingUpdate where Invoice_Dispatch.IOMNO = IBISBillingUpdate.STNIOMNo and Invoice_Dispatch.BillingDocument = IBISBillingUpdate.DocumentNumber; update Invoice_Dispatch set Invoice_Dispatch.BillingDate = DirSAPInvoiceUpload.BillingDate from Invoice_Dispatch,  DirSAPInvoiceUpload where Invoice_Dispatch.IOMNO =  DirSAPInvoiceUpload.IOMNo and Invoice_Dispatch.BillingDocument = DirSAPInvoiceUpload.BillingDocument; update Invoice_Dispatch set Invoice_Dispatch.BillingDate = IBISDirectBillingUpdate.DocumentDate from Invoice_Dispatch,IBISDirectBillingUpdate where Invoice_Dispatch.IOMNO =  IBISDirectBillingUpdate.IOMNo and Invoice_Dispatch.BillingDocument = IBISDirectBillingUpdate.DocumentNumber; ");

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
                    strAppend.Append(" UPDATE Invoice_Dispatch ");
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
                    strAppend.Append(" WHERE BillingDocument = @BillingDocument ");

                    SqlCommand objcmd = new SqlCommand(strAppend.ToString());

                    objcmd.Parameters.AddWithValue("@IOMNo", int.Parse(lbliomno.Text));
                    objcmd.Parameters.AddWithValue("@BillingDocument", txtBillingDocument.Text);
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
                    {
                        objcmd.Parameters.AddWithValue("@Amount", decimal.Parse(txtAmount.Text));
                    }
                    else
                    {
                        objcmd.Parameters.AddWithValue("@Amount", 0);
                    }

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
                        lblStatus.Text = "Dispatch Updated Sucessfully";

                        ClearForm();
                        //bindBillingDocumentEdit();

                        //commneted on 23/09/2012
                        //bindGridBillDoc("SELECT distinct IOMNo, BillingDocument, SoldToParty, Name, Plnt, BillingDate, Priority from SAPInvoiceUpload where 1 = 2");
                        //                        bindGridBillDoc(@" select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, SAPInvoiceUpload.BillingDocument,SAPInvoiceUpload.IOMNo as 'StnNo', 
                        //                     OrderHeader.PartyCode,OrderHeader.PartyName,   SAPInvoiceUpload.SoldToParty as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      
                        //                     StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    SAPInvoiceUpload.Priority   
                        //                     from SAPInvoiceUpload,STNUpload,OrderHeader,StampingMaster where   SAPInvoiceUpload.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo 
                        //                     and OrderHeader.StampingID=StampingMaster.StampingId and  SAPInvoiceUpload.BillingDocument in (select  BillingDocument from Invoice_Dispatch) 
                        //                     and SAPInvoiceUpload.OrdUpdated=1 
                        //                     Union all 
                        //                     select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, DirSAPInvoiceUpload.BillingDocument,DirSAPInvoiceUpload.IOMNo as 'StnNo',
                        //                      OrderHeader.PartyCode,OrderHeader.PartyName,   DirSAPInvoiceUpload.SoldToParty as 'INV PartyCode', DirSAPInvoiceUpload.BillingDate as 'STN DelDate',      
                        //                      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    DirSAPInvoiceUpload.Priority   
                        //                      from DirSAPInvoiceUpload,OrderHeader,StampingMaster where   OrderHeader.StampingID=StampingMaster.StampingId 
                        //                      and OrderHeader.IOMNo=DirSAPInvoiceUpload.IOMNo and DirSAPInvoiceUpload.BillingDocument  in (select  BillingDocument from Invoice_Dispatch) 
                        //                      and DirSAPInvoiceUpload.OrdUpdated=1 Union all select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, 
                        //                      IBISBillingUpdate.DocumentNumber as  BillingDocument,IBISBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   
                        //                      IBISBillingUpdate.PartyCode as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,
                        //                      OrderHeader.DispThrough,   '' As Priority   from IBISBillingUpdate,STNUpload,OrderHeader,StampingMaster 
                        //                      where   IBISBillingUpdate.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId and  
                        //                      IBISBillingUpdate.DocumentNumber in (select  BillingDocument from Invoice_Dispatch) and IBISBillingUpdate.OrdUpdated=1 
                        //                      Union all 
                        //                      select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, IBISDirectBillingUpdate.DocumentNumber as  BillingDocument,
                        //                      IBISDirectBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   IBISDirectBillingUpdate.PartyCode as 'INV PartyCode', 
                        //                      IBISDirectBillingUpdate.LR_DT as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,   '' As Priority  
                        //                       from IBISDirectBillingUpdate,OrderHeader,StampingMaster where  IBISDirectBillingUpdate.IOMNO=OrderHeader.IOMNo 
                        //                       and OrderHeader.StampingID=StampingMaster.StampingId and  IBISDirectBillingUpdate.DocumentNumber in (select  BillingDocument from Invoice_Dispatch) 
                        //                       and IBISDirectBillingUpdate.OrdUpdated=1 ");

                        bindGridBillDoc(@"select * from  ( " + QueryEdit + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))");

                        //Result objExeUpdDelivery = objCF.ExecuteDMLQuery("update Invoice_Dispatch set Invoice_Dispatch.Delivery =  SAPInvoiceUpload.IOMNo from Invoice_Dispatch, SAPInvoiceUpload where Invoice_Dispatch.IOMNO = SAPInvoiceUpload.STNIOMNo and Invoice_Dispatch.BillingDocument = SAPInvoiceUpload.BillingDocument and  Invoice_Dispatch.Delivery = 0; update Invoice_Dispatch set Invoice_Dispatch.Delivery =  IBISBillingUpdate.IOMNo from Invoice_Dispatch, IBISBillingUpdate where Invoice_Dispatch.IOMNO = IBISBillingUpdate.STNIOMNo and Invoice_Dispatch.BillingDocument = IBISBillingUpdate.DocumentNumber  and  Invoice_Dispatch.Delivery = 0");
                        Result objExeUpdDelivery = objCF.ExecuteDMLQuery("update Invoice_Dispatch set Invoice_Dispatch.Delivery =  SAPInvoiceUpload.IOMNo, Invoice_Dispatch.BillingDate = SAPInvoiceUpload.BillingDate from Invoice_Dispatch, SAPInvoiceUpload where Invoice_Dispatch.IOMNO = SAPInvoiceUpload.STNIOMNo and Invoice_Dispatch.BillingDocument = SAPInvoiceUpload.BillingDocument; update Invoice_Dispatch set Invoice_Dispatch.Delivery =  IBISBillingUpdate.IOMNo, Invoice_Dispatch.BillingDate = IBISBillingUpdate.DocumentDate from Invoice_Dispatch, IBISBillingUpdate where Invoice_Dispatch.IOMNO = IBISBillingUpdate.STNIOMNo and Invoice_Dispatch.BillingDocument = IBISBillingUpdate.DocumentNumber; update Invoice_Dispatch set Invoice_Dispatch.BillingDate = DirSAPInvoiceUpload.BillingDate from Invoice_Dispatch,  DirSAPInvoiceUpload where Invoice_Dispatch.IOMNO =  DirSAPInvoiceUpload.IOMNo and Invoice_Dispatch.BillingDocument = DirSAPInvoiceUpload.BillingDocument; update Invoice_Dispatch set Invoice_Dispatch.BillingDate = IBISDirectBillingUpdate.DocumentDate from Invoice_Dispatch,IBISDirectBillingUpdate where Invoice_Dispatch.IOMNO =  IBISDirectBillingUpdate.IOMNo and Invoice_Dispatch.BillingDocument = IBISDirectBillingUpdate.DocumentNumber; ");

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

            if (txtBillingDocument.Text == "")
            {
                errorDispatch.SetError(txtBillingDocument, "Billing Document");
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

            //if (txtBillingDocument.Text == "")
            //{
            //    errorDispatch.SetError(txtBillingDocument, "Billing Document");
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
            //    int billDoc = int.Parse(txtBillingDocument.Text);
            //}
            //catch (Exception ex)
            //{
            //    errorDispatch.SetError(txtBillingDocument, "Only Numeric");
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
            txtBillingDocument.Text = "";
            txtCases.Text = "";
            //dtpDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //dtpDispositDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ////dtpInvDispDelDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //dtpInvDispLRDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void dgvBillingDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    CommonFunction objComm = new CommonFunction();
                    lblBillingDate.Text = "";
                    //id = int.Parse(dgvBillingDoc.Rows[e.RowIndex].Cells["BillingDocument"].Value.ToString());
                    BDoc = dgvBillingDoc.Rows[e.RowIndex].Cells["BillingDocument"].Value.ToString();
                    int IOMNO = int.Parse(dgvBillingDoc.Rows[e.RowIndex].Cells["IOMNO"].Value.ToString());
                    lblSTNNo.Text = dgvBillingDoc.Rows[e.RowIndex].Cells["StnNo"].Value.ToString();

                    DataTable dt = objComm.GetDataTable("select top 1 * from (select STNIOMNo,BillingDocument,BillingDate,STNNumber from SAPInvoiceUpload union all select STNIOMNo,DocumentNumber,DocumentDate,STNNumber from IBISBillingUpdate) as a where a.BillingDocument = '" + BDoc + "'");

                    lbliomno.Text = IOMNO.ToString();

                    if (dt.Rows.Count > 0)
                        lblBillingDate.Text = dt.Rows[0]["BillingDate"].ToString();
                    else
                        lblBillingDate.Text = "";

                    txtBillingDocument.Text = BDoc;
                    if (e.ColumnIndex == dgvBillingDoc.Columns["colEdit"].Index)
                    {
                        lblStatus.Text = "";

                        //int IOMNO = int.Parse(dgvBillingDoc.Rows[e.RowIndex].Cells["IOMNO"].Value.ToString());
                        //lbliomno.Text = IOMNO.ToString();
                        fn_getDispatchDetail(BDoc, IOMNO);

                    }

                    if (e.ColumnIndex == dgvBillingDoc.Columns["colView"].Index)
                    {
                        DispatchDetail objDispatchDetail = new DispatchDetail(BDoc, 1);  // 1 for  SAPInvoiceUpload table

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
                        string BillingDocumentNo = dgvBillingDoc.Rows[e.RowIndex].Cells["BillingDocument"].Value.ToString();
                        int IOMNumber = int.Parse(dgvBillingDoc.Rows[e.RowIndex].Cells["IOMNo"].Value.ToString());
                        string DeliveryNo = dgvBillingDoc.Rows[e.RowIndex].Cells["StnNo"].Value.ToString();
                        string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        CommonFunction objCommFun = new CommonFunction();
                        SqlCommand objcomm = new SqlCommand(@"INSERT INTO Invoice_Dispatch (IOMNo, Delivery, BillingDocument, HORemarks, CFARemarks, InvTransporter, InvLRNo, InvDispLRdate, InvDispDelDate, ChequeNumber, Date, Amount, DepositDate, LastModify, Cases, TentativeDel,IsAuth,Authdate,BillingDate) 
                                                                                    VALUES (@IOMNo, @Delivery, @BillingDocument, @HORemarks, @CFARemarks, @InvTransporter, @InvLRNo, @InvDispLRdate, @InvDispDelDate, @ChequeNumber, @Date, @Amount, @DepositDate, getdate(), @Cases, @TentativeDel, @IsAuth, getdate(), @BillingDate); SELECT @pk_new = @@IDENTITY");

                        objcomm.Parameters.AddWithValue("@IOMNo", IOMNumber);
                        objcomm.Parameters.AddWithValue("@Delivery", DeliveryNo);
                        objcomm.Parameters.AddWithValue("@BillingDocument", BillingDocumentNo);

                        if (lblBillingDate.Text != "")
                        {
                            if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                            {
                                objcomm.Parameters.AddWithValue("@BillingDate", DateTime.Parse(lblBillingDate.Text, dateformat));
                            }
                            else
                            {
                                objcomm.Parameters.AddWithValue("@BillingDate", DateTime.Parse(lblBillingDate.Text).ToString(_dateformat));
                            }
                        }
                        else
                        {
                            objcomm.Parameters.AddWithValue("@BillingDate", DBNull.Value);
                        }

                        objcomm.Parameters.AddWithValue("@HORemarks", "");
                        objcomm.Parameters.AddWithValue("@CFARemarks", "");
                        objcomm.Parameters.AddWithValue("@InvTransporter", "");
                        objcomm.Parameters.AddWithValue("@InvLRNo", "");

                        objcomm.Parameters.AddWithValue("@InvDispLRdate", DBNull.Value);
                        objcomm.Parameters.AddWithValue("@InvDispDelDate", DBNull.Value);
                        objcomm.Parameters.AddWithValue("@ChequeNumber", txtChequeNo.Text);
                        objcomm.Parameters.AddWithValue("@Date", DBNull.Value);
                        objcomm.Parameters.AddWithValue("@DepositDate", DBNull.Value);
                        objcomm.Parameters.AddWithValue("@Amount", 0);

                        objcomm.Parameters.AddWithValue("@Cases", "");
                        objcomm.Parameters.AddWithValue("@IsAuth", 1);
                        objcomm.Parameters.AddWithValue("@TentativeDel", DBNull.Value);

                        SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                        spInsertedKey.Direction = ParameterDirection.Output;
                        objcomm.Parameters.Add(spInsertedKey);

                        Result objInsResult = objCommFun.InsertNewQuery(objcomm);
                        if (objInsResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Dispatch Detail Inserted Sucessfully";
                            lbliomno.Text = "";
                            ClearForm();

                            bindGridBillDoc(@"select * from  ( " + QueryAdd + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))");

                            Result objExeUpdDelivery = objCommFun.ExecuteDMLQuery("update Invoice_Dispatch set Invoice_Dispatch.Delivery =  SAPInvoiceUpload.IOMNo, Invoice_Dispatch.BillingDate = SAPInvoiceUpload.BillingDate from Invoice_Dispatch, SAPInvoiceUpload where Invoice_Dispatch.IOMNO = SAPInvoiceUpload.STNIOMNo and Invoice_Dispatch.BillingDocument = SAPInvoiceUpload.BillingDocument; update Invoice_Dispatch set Invoice_Dispatch.Delivery =  IBISBillingUpdate.IOMNo, Invoice_Dispatch.BillingDate = IBISBillingUpdate.DocumentDate from Invoice_Dispatch, IBISBillingUpdate where Invoice_Dispatch.IOMNO = IBISBillingUpdate.STNIOMNo and Invoice_Dispatch.BillingDocument = IBISBillingUpdate.DocumentNumber; update Invoice_Dispatch set Invoice_Dispatch.BillingDate = DirSAPInvoiceUpload.BillingDate from Invoice_Dispatch,  DirSAPInvoiceUpload where Invoice_Dispatch.IOMNO =  DirSAPInvoiceUpload.IOMNo and Invoice_Dispatch.BillingDocument = DirSAPInvoiceUpload.BillingDocument; update Invoice_Dispatch set Invoice_Dispatch.BillingDate = IBISDirectBillingUpdate.DocumentDate from Invoice_Dispatch,IBISDirectBillingUpdate where Invoice_Dispatch.IOMNO =  IBISDirectBillingUpdate.IOMNo and Invoice_Dispatch.BillingDocument = IBISDirectBillingUpdate.DocumentNumber; ");

                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            lblStatus.Text = objInsResult.strMessage;
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
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

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
                        chkauth.Enabled = true;

                        bindGridBillDoc("select * from ( " + QueryAdd + " ) as tempTbl where IOMNo in (" + ddlIOMNO.Text + ")");

                        bindAddIOMNoAndBillingDoc();

                        chkEdit.Checked = false;
                        flag = 0;
                        ClearForm();
                        lblStatus.Text = "";
                    }
                    else if (chkEdit.Checked == true)
                    {
                        chkauth.Enabled = false;

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
                //        strBillingDoc = "'" + castedItem["BillingDocument"].ToString() + "'";
                //    }
                //    else
                //    {
                //        strBillingDoc += ", " + "'" + castedItem["BillingDocument"].ToString() + "'";
                //    }
                //}
                if (ddlBillingDocument.Text != "")
                {
                    if (chkAdd.Checked == true)
                    {
                        chkauth.Enabled = true;

                        bindGridBillDoc("select * from ( " + QueryAdd + " ) as tempTbl where BillingDocument in ('" + ddlBillingDocument.Text + "')");

                        bindAddIOMNoAndBillingDoc();

                        chkEdit.Checked = false;
                        flag = 0;
                        ClearForm();
                        lblStatus.Text = "";
                    }
                    else if (chkEdit.Checked == true)
                    {
                        chkauth.Enabled = false;

                        bindGridBillDoc("select * from ( " + QueryEdit + " ) as tempTbl where BillingDocument in ('" + ddlBillingDocument.Text + "')");


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

        private void btnAllAuthorise_Click(object sender, EventArgs e)
        {
            if (chkAdd.Checked == true && dgvBillingDoc.RowCount > 0)
            {
                CommonFunction objCommFunc = new CommonFunction();
                SqlCommand objcomm = new SqlCommand(@"INSERT INTO Invoice_Dispatch (IOMNo, Delivery, BillingDocument, HORemarks, CFARemarks, InvTransporter, InvLRNo, InvDispLRdate, InvDispDelDate, ChequeNumber, 
                Date, Amount, DepositDate, LastModify, Cases, TentativeDel,IsAuth,Authdate,BillingDate) 
                select IomNo, StnNo as Delivery, BillingDocument,'' as HORemarks, '' as CFARemarks, '' as InvTransporter, '' as InvLRNo, NULL as InvDispLRdate,
                NULL as InvDispDelDate, '' as ChequeNumber, NULL as Date, 0 as Amount, NULL as DepositDate, GETDATE() as LastModify, '' as Cases, NULL as TentativeDel, 1 as IsAuth,
                GETDATE() as Authdate,
                case when a.BillingDocument is not null then (select top 1 billDoc.BillingDate from 
                (select SINVUPD.STNIOMNo,SINVUPD.BillingDocument,SINVUPD.BillingDate,SINVUPD.STNNumber from SAPInvoiceUpload SINVUPD
                union all select IBISUPD.STNIOMNo,IBISUPD.DocumentNumber,IBISUPD.DocumentDate,IBISUPD.STNNumber from IBISBillingUpdate IBISUPD) as billDoc 
                where billDoc.BillingDocument = a.BillingDocument) else '' end as BillingDate
                from 
                (select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, SAPInvoiceUpload.BillingDocument,SAPInvoiceUpload.IOMNo as 'StnNo', 
                OrderHeader.PartyCode,OrderHeader.PartyName,   SAPInvoiceUpload.SoldToParty as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      
                StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    SAPInvoiceUpload.Priority, OrderHeader.LocationCode as 'Plant' 
                from SAPInvoiceUpload,STNUpload,OrderHeader,StampingMaster where   SAPInvoiceUpload.IOMNo=STNUpload.Delivery 
                and STNUpload.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId 
                and  SAPInvoiceUpload.BillingDocument not in (select  BillingDocument from Invoice_Dispatch) and SAPInvoiceUpload.OrdUpdated=1 
                and STNUpload.RStatus = 'OK'
                Union all 
                select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, DirSAPInvoiceUpload.BillingDocument,DirSAPInvoiceUpload.IOMNo as 'StnNo', 
                OrderHeader.PartyCode,OrderHeader.PartyName,   DirSAPInvoiceUpload.SoldToParty as 'INV PartyCode', DirSAPInvoiceUpload.BillingDate as 'STN DelDate',      
                StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,    DirSAPInvoiceUpload.Priority, OrderHeader.LocationCode as 'Plant'  
                from DirSAPInvoiceUpload,OrderHeader,StampingMaster where OrderHeader.StampingID=StampingMaster.StampingId 
                and OrderHeader.IOMNo=DirSAPInvoiceUpload.IOMNo and DirSAPInvoiceUpload.BillingDocument  not in (select  BillingDocument from Invoice_Dispatch) 
                and DirSAPInvoiceUpload.OrdUpdated=1 
                Union all 
                select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, IBISBillingUpdate.DocumentNumber as  BillingDocument,
                IBISBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   
                IBISBillingUpdate.PartyCode as 'INV PartyCode', STNUpload.deliverydate as 'STN DelDate',      
                StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,   '' As Priority, OrderHeader.LocationCode as 'Plant' 
                from IBISBillingUpdate,STNUpload,OrderHeader,
                StampingMaster where   IBISBillingUpdate.IOMNo=STNUpload.Delivery and STNUpload.IOMNO=OrderHeader.IOMNo 
                and OrderHeader.StampingID=StampingMaster.StampingId 
                and  IBISBillingUpdate.DocumentNumber not in (select  BillingDocument from Invoice_Dispatch) and IBISBillingUpdate.OrdUpdated=1 
                and STNUpload.RStatus = 'OK'
                Union all 
                select distinct  OrderHeader.IOMNo  as 'IomNo',OrderHeader.IOMDate, IBISDirectBillingUpdate.DocumentNumber as  BillingDocument,
                IBISDirectBillingUpdate.IOMNo as  'StnNo', OrderHeader.PartyCode,OrderHeader.PartyName,   IBISDirectBillingUpdate.PartyCode as 'INV PartyCode', 
                IBISDirectBillingUpdate.LR_DT as 'STN DelDate',      StampingMaster.name  as 'Stamping',OrderHeader.MRP,OrderHeader.DispThrough,  '' As Priority, OrderHeader.LocationCode as 'Plant'    
                from IBISDirectBillingUpdate,OrderHeader,StampingMaster where  IBISDirectBillingUpdate.IOMNO=OrderHeader.IOMNo and 
                OrderHeader.StampingID=StampingMaster.StampingId and  IBISDirectBillingUpdate.DocumentNumber not in (select  BillingDocument from Invoice_Dispatch) 
                and IBISDirectBillingUpdate.OrdUpdated=1 ) as a");
                Result objResult = objCommFunc.ExecuteNewDMLQuery(objcomm);
                if (objResult.bStatus)
                {

                    bindGridBillDoc(@"select * from  ( " + QueryAdd + " ) as tempTbl where Plant in (select LocationCode from LocationMaster where LocationId in (select LocationId from UserLocationRelation where UserId = " + DBSessionUser.iUser_Id + " and Permission = 1))");

                    Result objExeUpdDelivery = objCommFunc.ExecuteDMLQuery("update Invoice_Dispatch set Invoice_Dispatch.Delivery =  SAPInvoiceUpload.IOMNo, Invoice_Dispatch.BillingDate = SAPInvoiceUpload.BillingDate from Invoice_Dispatch, SAPInvoiceUpload where Invoice_Dispatch.IOMNO = SAPInvoiceUpload.STNIOMNo and Invoice_Dispatch.BillingDocument = SAPInvoiceUpload.BillingDocument; update Invoice_Dispatch set Invoice_Dispatch.Delivery =  IBISBillingUpdate.IOMNo, Invoice_Dispatch.BillingDate = IBISBillingUpdate.DocumentDate from Invoice_Dispatch, IBISBillingUpdate where Invoice_Dispatch.IOMNO = IBISBillingUpdate.STNIOMNo and Invoice_Dispatch.BillingDocument = IBISBillingUpdate.DocumentNumber; update Invoice_Dispatch set Invoice_Dispatch.BillingDate = DirSAPInvoiceUpload.BillingDate from Invoice_Dispatch,  DirSAPInvoiceUpload where Invoice_Dispatch.IOMNO =  DirSAPInvoiceUpload.IOMNo and Invoice_Dispatch.BillingDocument = DirSAPInvoiceUpload.BillingDocument; update Invoice_Dispatch set Invoice_Dispatch.BillingDate = IBISDirectBillingUpdate.DocumentDate from Invoice_Dispatch,IBISDirectBillingUpdate where Invoice_Dispatch.IOMNO =  IBISDirectBillingUpdate.IOMNo and Invoice_Dispatch.BillingDocument = IBISDirectBillingUpdate.DocumentNumber; ");
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "*.xls|*.xlsx";    //"Audio File (*.mp3, *.wav)|*.mp3*;*.wav";       "All Files (*.*)|*.*";
            dlg.Filter = "Excel Files (*.xls)|*.XLS";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtUpload.Text = dlg.FileName;
                FileInfo str = new FileInfo(dlg.FileName);
                string strPath = System.Windows.Forms.Application.StartupPath + "//UploadFile//" + str.Name;

                FileName = str.Name;
                filepth = dlg.FileName;

            }
        }

        private bool validateUploadForm()
        {
            errorDispatch.Clear();
            bool isValid = true;
            if (txtUpload.Text == "")
            {
                errorDispatch.SetError(txtUpload, "Please Select Excel File !");
                isValid = false;
            }
            return isValid;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            bool bstatus = true;
            bstatus = validateUploadForm();
            if (bstatus == true)
            {
                ReadExcelFileAndUpdateRecord();
            }
        }

        public void ReadExcelFileAndUpdateRecord()
        {
            CommonFunction objComm = new CommonFunction();
            string ExcelConnString = ConnectionStringForExcel(filepth);
            DataTable TableName = GetOleDBTableNames(ExcelConnString);
            DataTable TableData = GetOleDBTableData(ExcelConnString, FileName, TableName.Rows[0]["Table_Name"].ToString());
            int count = TableData.Rows.Count;
            bool FlagStatus = false;
            Count = 0;
            for (int ctr = 0; ctr < count; ctr++)
            {
                try
                {
                    if (TableData.Rows[ctr]["IOMNO"].ToString() != "")
                        IOMNO = long.Parse(TableData.Rows[ctr]["IOMNO"].ToString());

                    BillingDocument = Convert.ToString(TableData.Rows[ctr]["BillingDocument"]);

                    InvTransporter = Convert.ToString(TableData.Rows[ctr]["InvTransporter"]);
                    InvLRNo = Convert.ToString(TableData.Rows[ctr]["InvLRNo"]);
                    if (TableData.Rows[ctr]["Cases"].ToString() != "")
                        Cases = Convert.ToInt32(TableData.Rows[ctr]["Cases"]);

                    if (TableData.Rows[ctr]["InvDispLRdate"].ToString() != "")
                        InvDispLRdate = Convert.ToDateTime(TableData.Rows[ctr]["InvDispLRdate"].ToString().Trim(), dateformat);

                    if (TableData.Rows[ctr]["InvDispDelDate"].ToString() != "")
                        InvDispDelDate = Convert.ToDateTime(TableData.Rows[ctr]["InvDispDelDate"].ToString().Trim(), dateformat);

                    UpdateRecordDB();

                }
                catch (Exception ex)
                {
                    FlagStatus = true;
                    string strError = ex.ToString();
                    MessageBox.Show(strError);
                    break;
                }
            }
            if (!FlagStatus)
            {
                MessageBox.Show("Total " + Count.ToString() + " Records updated.", "Information");
            }
        }

        public void UpdateRecordDB()
        {
            try
            {
                CommonFunction objCommFn = new CommonFunction();
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                objConnection.Open();
                string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                StringBuilder strAppend = new StringBuilder();
                strAppend.Append(" UPDATE Invoice_Dispatch ");
                strAppend.Append(" SET InvTransporter = @InvTransporter, ");
                strAppend.Append(" InvLRNo = @InvLRNo, ");
                strAppend.Append(" InvDispLRdate = @InvDispLRdate, ");
                strAppend.Append(" InvDispDelDate = @InvDispDelDate, ");
                strAppend.Append(" Cases = @Cases, ");
                strAppend.Append(" LastModify = getdate() ");
                strAppend.Append(" WHERE BillingDocument = @BillingDocument AND IOMNo = @IOMNo");

                SqlCommand objcmd = new SqlCommand(strAppend.ToString());

                objcmd.Parameters.AddWithValue("@IOMNo", IOMNO);
                objcmd.Parameters.AddWithValue("@BillingDocument", BillingDocument);
                objcmd.Parameters.AddWithValue("@InvTransporter", InvTransporter);
                objcmd.Parameters.AddWithValue("@InvLRNo", InvLRNo);
                objcmd.Parameters.AddWithValue("@Cases", Cases);

                if (InvDispLRdate.ToString() != "")
                {
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        objcmd.Parameters.AddWithValue("@InvDispLRdate", DateTime.Parse(InvDispLRdate.ToString(), dateformat));
                    }
                    else
                    {
                        objcmd.Parameters.AddWithValue("@InvDispLRdate", DateTime.Parse(InvDispLRdate.ToString()).ToString(_dateformat));
                    }
                }
                else
                    objcmd.Parameters.AddWithValue("@InvDispLRdate", DBNull.Value);


                if (InvDispDelDate.ToString() != "")
                {
                    if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                    {
                        objcmd.Parameters.AddWithValue("@InvDispDelDate", DateTime.Parse(InvDispDelDate.ToString(), dateformat));
                    }
                    else
                    {
                        objcmd.Parameters.AddWithValue("@InvDispDelDate", DateTime.Parse(InvDispDelDate.ToString()).ToString(_dateformat));
                    }
                }
                else
                    objcmd.Parameters.AddWithValue("@InvDispDelDate", DBNull.Value);

                Result objResult = objCommFn.ExecuteNewDMLQuery(objcmd);
                if (objResult.bStatus)
                {
                    Count = Count + 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public static string ConnectionStringForExcel(string filepath)
        {
            //Below this is working Connection String
            string ExcelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"";

            return ExcelConnectionString;
        }

        public static DataTable GetOleDBTableNames(string ConnString)
        {
            OleDbConnection conn = new OleDbConnection();
            DataTable dtTables = default(DataTable);
            //try
            //{
            conn.ConnectionString = ConnString;
            conn.Open();
            dtTables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            //}
            //catch (OleDbException eX_SQL)
            //{
            //    throw new Exception(eX_SQL.Message);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //    conn.Dispose();
            //}
            return dtTables;
        }

        public static DataTable GetOleDBTableData(string ConnectionString, string FileName, string TableName)
        {
            OleDbConnection conn = new OleDbConnection();
            DataSet ds = new DataSet();
            DataTable dtData = default(DataTable);
            OleDbDataAdapter da = default(OleDbDataAdapter);
            string strSQL = null;

            try
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();

                strSQL = "SELECT  * FROM [" + TableName + "]";

                da = new OleDbDataAdapter(strSQL, conn);

                da.TableMappings.Add("Table", FileName);
                da.Fill(ds);


                dtData = ds.Tables[0];
            }
            catch (OleDbException eX_SQL)
            {
                throw new Exception(eX_SQL.Message);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return dtData;
        }

        private void lnkDownloadFormat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string strPath = Application.StartupPath + "\\INVUpdate.xls";
                if (File.Exists(strPath))
                {

                    System.Diagnostics.Process.Start(strPath);

                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}
