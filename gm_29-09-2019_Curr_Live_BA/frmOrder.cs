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
using System.Globalization;

namespace GlanMark
{
    public partial class frmOrder : Form
    {
        CommonFunction objC = null;
        MdiForm objmdi = new MdiForm();
        private SqlDataAdapter sqlDataAdapter = null;
        //private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        DataTable table = new DataTable();
        DataTable tblOrderSchdule = new DataTable();
        private BindingSource bindingSource = null;
        //private String selectQueryString = null;
        private int id;
        //CalendarColumn col = new CalendarColumn();
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        private string _dateformat = "MM/dd/yyyy";
        string strLogFileName = "LOG/LogRecord.txt";
        // Page
        private int mintTotalRecords = 0;
        private int mintPageSize = 25;
        private int mintPageCount = 0;
        private int mintCurrentPage = 1;

        public frmOrder()
        {
            InitializeComponent();

            table.Columns.Add("Material Code", typeof(string));
            table.Columns.Add("AlisCode", typeof(string));
            table.Columns.Add("Material Name", typeof(string));
            table.Columns.Add("Inst. Rate", typeof(string));
            table.Columns.Add("Quantity", typeof(string));
            table.Columns.Add("PTD", typeof(string));
            table.Columns.Add("Commision", typeof(string));
            table.Columns.Add("Product Value", typeof(string));
            table.Columns.Add("MRP", typeof(string));
            table.Columns.Add("Tax", typeof(string));
            table.Columns.Add("Tax Value", typeof(string));
            table.Columns.Add("TaxAmt", typeof(string));
            table.Columns.Add("EffTax", typeof(string));
            table.Columns.Add("ProductId", typeof(string));        //Hidden Column

            //table.Columns.Add("LST/CST", typeof(string));
            //table.Columns.Add("Edit", typeof(Image));
            //table.Columns.Add("Delete", typeof(Image));

            //tblOrderSchdule.Columns.Add("Quantity", typeof(string));
            //DateTimePicker dtSchedule = new DateTimePicker();
            //tblOrderSchdule.Columns.Add("Date", dtSchedule.Text);
            //DataGridViewColumnCollection dgvColColl = new DataGridViewColumnCollection(dgvOrderItemSchedule);
            //dgvColColl.Add(

            dtpIOM.Text = objmdi.dtCurrent.ToString();
            dtpOrderRec.Text = objmdi.dtCurrent.ToString();
            dtpPO.Text = objmdi.dtCurrent.ToString();
            dtpDelivery.Text = objmdi.dtCurrent.ToString();

        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            try
            {
                BindGridOrderheader();
                BindOrderType();
                BindPartyCode();
                BindLocationMaster();
                BindInstitution();
                BindSubInstitution();
                BindStampingMaster();
                BindTaxIndicator();
                BindDistinctIOMNo();
                //BindTaxOn();
                BindSchedule();
                BindMRP();
                BindDSMZSM();
                BindLiasoner();
                BindDocument();
                //BindLocationMaster();
                bindShelfLife();

                BindMaterialCode();

                //AddProductMaster();

                ItemGridview.DataSource = table;
                ItemGridview.Columns["ProductId"].Visible = false;

                ////////BindProductSchedule(12100008);
                //dgvOrderItemSchedule.Columns.Add("colScheQuantity", "Quantity");
                //CalendarColumn col = new CalendarColumn();
                //dgvOrderItemSchedule.Columns.Add(col);
                //dgvOrderItemSchedule.Columns[2].Name = "deliveryDate";
                //dgvOrderItemSchedule.Columns[2].HeaderText = "Delivery Date";

                //dgvOrderItemSchedule.Columns.Add(col);
                //dgvOrderItemSchedule.Columns[2].Name = "deliveryDate";
                //dgvOrderItemSchedule.Columns[2].HeaderText = "Delivery Date";
                //dgvOrderItemSchedule.Columns[2].DataPropertyName = "DeliveryDate";

                //Tab Management
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage6);

                //DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dgvOrderItemSchedule.Columns[0];
                //imgCol.Image = Image.FromFile("cross.gif");

                //DataGridViewImageColumn img = new DataGridViewImageColumn();
                //Image image = Image.FromFile("global::gm.Properties.Resources.cross1");
                //Bitmap image1 = (Bitmap)Image.FromFile("E:\\gm\\images\\cross.gif", true);

                //img.Image = image1;  //global::gm.Properties.Resources.cross1;
                //dgvOrderItemSchedule.Columns.Add(img);
                //img.HeaderText = "ImageColumn";
                //img.Name = "img";

                //dgvOrderItemSchedule.RowCount = 5;
                //foreach (DataGridViewRow row in dgvOrderItemSchedule.Rows)
                //{
                //    row.Cells[0].Value = DateTime.Now;
                //}
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder frmOrder_Load \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BindGridOrderheader()
        {
            try
            {
                this.btnFirst.Enabled = true;
                this.btnPrevious.Enabled = true;
                this.lblStatus.Enabled = true;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;

                // For Page view.
                this.mintTotalRecords = getCount();
                this.mintPageCount = this.mintTotalRecords / this.mintPageSize;

                // Adjust page count if the last page contains partial page.
                if (this.mintTotalRecords % this.mintPageSize > 0)
                    this.mintPageCount++;

                this.mintCurrentPage = 0;

                loadPage();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/BindGridOrderheader \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadPage()
        {
            try
            {
                int intSkip = (this.mintCurrentPage * this.mintPageSize);
                string strPath = ConfigurationSettings.AppSettings["ServerPath"].ToString();
                objC = new CommonFunction();
                //commented on 23-09-2012
                //sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, (case when OrderHeader.SubInstitution is not null then (select Name from SubInstitutionMaster where OrderHeader.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution, MRP, Remark, DocFile1 from OrderHeader WHERE OrderHeaderId NOT IN (SELECT TOP " + intSkip + " OrderHeaderId FROM OrderHeader) order by OrderHeaderId desc ");
                sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, (case when OrderHeader.SubInstitution is not null then (select Name from SubInstitutionMaster where OrderHeader.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution, MRP, Remark, (case when DocFile1 <> '' then ('" + strPath + "'+DocFile1) end) DocFile1 from OrderHeader WHERE OrderHeaderId NOT IN (SELECT TOP " + intSkip + " OrderHeaderId FROM OrderHeader) order by OrderHeaderId desc ");

                //sqlDataAdapter = objC.GetSqlDataAdapter(@"select OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, SubInstitution, MRP, Remark, DocFile1 from OrderHeader order by OrderHeaderId desc");
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvOrderMaster.DataSource = bindingSource;

                this.lblPageStatus.Text = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString();
            }
            catch (Exception ex)
            {
                //StreamWriter swLog = File.AppendText(strLogFileName);
                //string strError = DateTime.Now.ToString() + "\n Main Page/Location Tab \n" + ex.ToString();
                //swLog.WriteLine(strError);
                //swLog.WriteLine();
                //swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int getCount()
        {
            objC = new CommonFunction();
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('OrderHeader') AND IndId < 2");

            return objres.iRecordId;
        }
        private void BindOrderType()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select OrderTypeName,ID from OrderTypeMaster where isActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["ID"] = 0;
                dr["OrderTypeName"] = "--select--";
                dt.Rows.InsertAt(dr, 0);
                cmbOrderType.DataSource = dt;
                cmbOrderType.DisplayMember = "OrderTypeName";
                cmbOrderType.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindOrderType \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbOrderType.SelectedIndex) != "0")
                {
                    CommonFunction objCF = new CommonFunction();
                    //IOM NUMBER LOGIC START          
                    //string yR = string.Format("0:Y",dtpIOM.Text);
                    string IOMnO = "";
                    dataTable = objCF.GetDataTable("select * from IOMLogicMaster where OrderTypeId='" + cmbOrderType.SelectedValue.ToString() + "' and Year=DATEPART(YYYY,GETDATE())");
                    if (dataTable.Rows[0]["LastUsed"].ToString() == "" || dataTable.Rows[0]["LastUsed"].ToString() == null)
                    {
                        IOMnO = dataTable.Rows[0]["StartingNumber"].ToString();
                    }
                    else
                    {
                        IOMnO = Convert.ToString(Convert.ToInt32(dataTable.Rows[0]["LastUsed"].ToString()) + 1);
                    }
                    lblIOMID.Text = dataTable.Rows[0]["ID"].ToString();
                    //IOM NUMBER LOGIC END
                    txtIOMNO.Text = IOMnO.ToString();

                    objCF.ExecuteDMLQuery("UPDATE IOMLogicMaster set LastUsed='" + txtIOMNO.Text + "' where ID='" + lblIOMID.Text + "' ");
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder cmbOrderType_SelectedIndexChanged \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindLocationMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                cmbLocationMst.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbLocationMst.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select LocationId, LocationCode, DispatchThru from LocationMaster where IsActive = 'Yes' order by LocationCode asc");
                DataRow dr = dt.NewRow();
                dr["LocationCode"] = "0";
                dr["DispatchThru"] = "--Select--";
                dt.Rows.InsertAt(dr, 0);
                cmbLocationMst.DataSource = dt;
                cmbLocationMst.DisplayMember = "DispatchThru";
                cmbLocationMst.ValueMember = "LocationCode";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindLocationMaster \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLocationMst_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbLocationMst.SelectedIndex) != "0")
                {
                    string LocationCode = cmbLocationMst.SelectedValue.ToString();
                    DataTable dt = new DataTable();
                    CommonFunction objCommon = new CommonFunction();
                    dt = objCommon.GetDataTable("select * from LocationMaster where LocationCode = '" + LocationCode + "'");
                    txtLocationCode.Text = dt.Rows[0]["LocationCode"].ToString();
                    //txtDispatchthru.Text = dt.Rows[0]["DispatchThru"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BindPartyCode()
        {
            try
            {
                //DataTable dt = new DataTable();
                //CommonFunction objCommon = new CommonFunction();
                //DataSet ds = new DataSet();
                //SqlConnection objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", objConnection);
                //da.Fill(ds, "Country");
                //da.Fill(dt);

                //dt = objCommon.GetDataTable("select Customerid, convert(varchar(500), Name + ' - ' + CustomerCode) as CustomerName from CustomerMaster where isActive = 'Yes' order by CustomerName asc");
                //DataRow dr = dt.NewRow();
                //dr["Customerid"] = 0;
                //dr["CustomerName"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
                //cmbPartycode.DataSource = dt;
                //cmbPartycode.DisplayMember = "CustomerName";
                //cmbPartycode.ValueMember = "Customerid";

                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                cmbPartycode.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbPartycode.AutoCompleteMode = AutoCompleteMode.Suggest;

                //dt = objCommon.GetDataTable("select Customerid, convert(varchar(500), Name + ' - ' + CustomerCode) as CustomerName from CustomerMaster where isActive = 'Yes' order by CustomerName asc");
                dt = objCommon.GetDataTable("select Customerid, convert(varchar(500),Name  + ' - ' + CustomerCode) as CustomerName from CustomerMaster where isActive = 'Yes' order by CustomerName asc");
                DataRow dr = dt.NewRow();
                dr["Customerid"] = 0;
                //dr["Material"] = "--select--";
                dr["CustomerName"] = "";
                dt.Rows.InsertAt(dr, 0);
                cmbPartycode.DataSource = dt;
                cmbPartycode.DisplayMember = "CustomerName";
                cmbPartycode.ValueMember = "Customerid";

                //txtParytCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //txtParytCode.AutoCompleteMode = AutoCompleteMode.Suggest;
                //// AutoCompleteStringCollection 
                //AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
                //SqlConnection objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                //objConnection.Open();
                //SqlCommand objCommand = new SqlCommand("select convert(varchar(500), Name + ' - ' + CustomerCode) as CustomerName from CustomerMaster where isActive = 'Yes'", objConnection);

                //SqlDataReader objReader = objCommand.ExecuteReader();
                //while (objReader.Read())
                //{
                //    data1.Add(objReader["CustomerName"].ToString());
                //}

                //txtParytCode.AutoCompleteCustomSource = data1;

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindPartyCode \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbPartycode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbPartycode.SelectedIndex) != "0")
                {
                    int CustomerId = int.Parse(cmbPartycode.SelectedValue.ToString());

                    DataTable dt = new DataTable();
                    CommonFunction objCommon = new CommonFunction();
                    dt = objCommon.GetDataTable("select CustomerMaster.Name, CustomerMaster.City, CustomerMaster.Street, CustomerMaster.Street1, CustomerMaster.Street2, CustomerMaster.Street3, CustomerMaster.MobileNumber, CustomerMaster.PostalCode, CustomerMaster.DispatchThru, CustomerMaster.LocationCode, CustomerMaster.CustomerCode, CustomerMaster.LST_CST, LocationMaster.TaxOn from CustomerMaster join LocationMaster on CustomerMaster.LocationCode=LocationMaster.LocationCode where CustomerId = " + CustomerId);
                    txtpartyname.Text = dt.Rows[0]["name"].ToString();
                    //txtLSTCST.Text = dt.Rows[0]["name"].ToString();
                    string Billaddress = "";
                    if (dt.Rows[0]["MobileNumber"].ToString().Trim() != "")
                    {
                        if (dt.Rows[0]["Street3"].ToString().Trim() != "" && dt.Rows[0]["Street2"].ToString().Trim() != "")
                            Billaddress = dt.Rows[0]["name"].ToString() + ", " + dt.Rows[0]["Street"].ToString() + " " + dt.Rows[0]["Street1"].ToString() + " " + dt.Rows[0]["Street2"].ToString() + ", " + dt.Rows[0]["Street3"].ToString() + ", " + dt.Rows[0]["City"].ToString() + " - " + dt.Rows[0]["PostalCode"].ToString() + ", Contact No. " + dt.Rows[0]["MobileNumber"].ToString();

                        else if (dt.Rows[0]["Street3"].ToString().Trim() == "" && dt.Rows[0]["Street2"].ToString().Trim() != "")
                            Billaddress = dt.Rows[0]["name"].ToString() + ", " + dt.Rows[0]["Street"].ToString() + " " + dt.Rows[0]["Street1"].ToString() + " " + dt.Rows[0]["Street2"].ToString() + ", " + dt.Rows[0]["City"].ToString() + " - " + dt.Rows[0]["PostalCode"].ToString() + ", Contact No. " + dt.Rows[0]["MobileNumber"].ToString();

                        else if (dt.Rows[0]["Street3"].ToString().Trim() != "" && dt.Rows[0]["Street2"].ToString().Trim() == "")
                            Billaddress = dt.Rows[0]["name"].ToString() + ", " + dt.Rows[0]["Street"].ToString() + " " + dt.Rows[0]["Street1"].ToString() + " " + dt.Rows[0]["Street3"].ToString() + ", " + dt.Rows[0]["City"].ToString() + " - " + dt.Rows[0]["PostalCode"].ToString() + ", Contact No. " + dt.Rows[0]["MobileNumber"].ToString();

                        else if (dt.Rows[0]["Street3"].ToString().Trim() == "" && dt.Rows[0]["Street2"].ToString().Trim() == "")
                            Billaddress = dt.Rows[0]["name"].ToString() + ", " + dt.Rows[0]["Street"].ToString() + " " + dt.Rows[0]["Street1"].ToString() + " " + dt.Rows[0]["City"].ToString() + " - " + dt.Rows[0]["PostalCode"].ToString() + ", Contact No. " + dt.Rows[0]["MobileNumber"].ToString();
                    }
                    else
                    {
                        if (dt.Rows[0]["Street3"].ToString().Trim() != "" && dt.Rows[0]["Street2"].ToString().Trim() != "")
                            Billaddress = dt.Rows[0]["name"].ToString() + ", " + dt.Rows[0]["Street"].ToString() + " " + dt.Rows[0]["Street1"].ToString() + " " + dt.Rows[0]["Street2"].ToString() + ", " + dt.Rows[0]["Street3"].ToString() + ", " + dt.Rows[0]["City"].ToString() + " - " + dt.Rows[0]["PostalCode"].ToString();

                        else if (dt.Rows[0]["Street3"].ToString().Trim() == "" && dt.Rows[0]["Street2"].ToString().Trim() != "")
                            Billaddress = dt.Rows[0]["name"].ToString() + ", " + dt.Rows[0]["Street"].ToString() + " " + dt.Rows[0]["Street1"].ToString() + " " + dt.Rows[0]["Street2"].ToString() + ", " + dt.Rows[0]["City"].ToString() + " - " + dt.Rows[0]["PostalCode"].ToString();

                        else if (dt.Rows[0]["Street3"].ToString().Trim() != "" && dt.Rows[0]["Street2"].ToString().Trim() == "")
                            Billaddress = dt.Rows[0]["name"].ToString() + ", " + dt.Rows[0]["Street"].ToString() + " " + dt.Rows[0]["Street1"].ToString() + " " + dt.Rows[0]["Street3"].ToString() + ", " + dt.Rows[0]["Street3"].ToString() + ", " + dt.Rows[0]["City"].ToString() + " - " + dt.Rows[0]["PostalCode"].ToString();

                        else if (dt.Rows[0]["Street3"].ToString().Trim() == "" && dt.Rows[0]["Street2"].ToString().Trim() == "")
                            Billaddress = dt.Rows[0]["name"].ToString() + ", " + dt.Rows[0]["Street"].ToString() + " " + dt.Rows[0]["Street1"].ToString() + " " + dt.Rows[0]["City"].ToString() + " - " + dt.Rows[0]["PostalCode"].ToString();
                    }

                    txtBillingAddress.Text = Billaddress;
                    txtDeliveryAddress.Text = Billaddress;

                    //txtDispatchthru.Text = dt.Rows[0]["DispatchThru"].ToString();
                    cmbLocationMst.SelectedValue = dt.Rows[0]["LocationCode"].ToString();

                    txtLocationCode.Text = dt.Rows[0]["LocationCode"].ToString();
                    lblPartyCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                    txtTaxOn.Text = dt.Rows[0]["TaxOn"].ToString();
                    BindLST_CST(dt.Rows[0]["LST_CST"].ToString());
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder cmbPartycode_SelectedIndexChanged \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindLST_CST(string LSTCSTID)
        {
            try
            {
                if (LSTCSTID != "")
                {
                    DataTable dt = new DataTable();
                    CommonFunction objCommon = new CommonFunction();
                    ddlLSTCST.AutoCompleteSource = AutoCompleteSource.ListItems;
                    ddlLSTCST.AutoCompleteMode = AutoCompleteMode.Suggest;

                    dt = objCommon.GetDataTable("select Percentage from TaxMaster where TaxTypeID = " + int.Parse(LSTCSTID));
                    //DataRow dr = dt.NewRow();
                    //dr["ID"] = 0;
                    //dr["Percentage"] = "--select--";
                    //dt.Rows.InsertAt(dr, 0);
                    ddlLSTCST.DataSource = dt;
                    ddlLSTCST.DisplayMember = "Percentage";
                    ddlLSTCST.ValueMember = "Percentage";
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindLST_CST \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindInstitution()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                cmbInstitution.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbInstitution.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select  Code ,Name  from InstitutionMaster where isActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["Code"] = 0;
                dr["Name"] = "--select--";
                dt.Rows.InsertAt(dr, 0);
                cmbInstitution.DataSource = dt;
                cmbInstitution.DisplayMember = "Name";
                cmbInstitution.ValueMember = "Code";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindSubInstitution()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                cmbSubInstitution.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbSubInstitution.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select  Code ,Name  from SubInstitutionMaster where isActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["Code"] = 0;
                dr["Name"] = "--select--";
                dt.Rows.InsertAt(dr, 0);
                cmbSubInstitution.DataSource = dt;
                cmbSubInstitution.DisplayMember = "Name";
                cmbSubInstitution.ValueMember = "Code";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindStampingMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                ddlStamping.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlStamping.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select StampingId, Name from StampingMaster where IsActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["StampingId"] = 0;
                dr["Name"] = "select";
                dt.Rows.InsertAt(dr, 0);
                ddlStamping.DataSource = dt;
                ddlStamping.DisplayMember = "Name";
                ddlStamping.ValueMember = "StampingId";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerMaster \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindTaxIndicator()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "GridRows";
                dt.Columns.Add("Value", Type.GetType("System.String"));
                dt.Columns.Add("Name", Type.GetType("System.String"));

                DataRow dr = dt.NewRow();
                dr["Value"] = "0";
                dr["Name"] = "--Select--";
                dt.Rows.InsertAt(dr, 0);

                DataRow dr1 = dt.NewRow();
                dr1["Value"] = "Tax Include";
                dr1["Name"] = "Tax Include";
                dt.Rows.InsertAt(dr1, 1);

                DataRow dr2 = dt.NewRow();
                dr2["Value"] = "Tax Exclude";
                dr2["Name"] = "Tax Exclude";
                dt.Rows.InsertAt(dr2, 2);

                ddlTaxIndicator.DataSource = dt;
                ddlTaxIndicator.DisplayMember = "Name";
                ddlTaxIndicator.ValueMember = "Value";
                ddlTaxIndicator.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindSchedule()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "GridRows";
                dt.Columns.Add("Value", Type.GetType("System.String"));
                dt.Columns.Add("Name", Type.GetType("System.String"));

                DataRow dr = dt.NewRow();
                dr["Value"] = "0";
                dr["Name"] = "--Select--";
                dt.Rows.InsertAt(dr, 0);

                DataRow dr1 = dt.NewRow();
                dr1["Value"] = "No";
                dr1["Name"] = "No";
                dt.Rows.InsertAt(dr1, 1);

                DataRow dr2 = dt.NewRow();
                dr2["Value"] = "Yes";
                dr2["Name"] = "Yes";
                dt.Rows.InsertAt(dr2, 1);

                ddlSchedule.DataSource = dt;
                ddlSchedule.DisplayMember = "Name";
                ddlSchedule.ValueMember = "Value";
                ddlSchedule.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindMRP()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "GridRows";
                dt.Columns.Add("Value", Type.GetType("System.String"));
                dt.Columns.Add("Name", Type.GetType("System.String"));
                DataRow dr = dt.NewRow();
                dr["Value"] = "No";
                dr["Name"] = "No";
                DataRow dr1 = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                dr1["Value"] = "Yes";
                dr1["Name"] = "Yes";
                dt.Rows.InsertAt(dr1, 1);
                ddlMRP.DataSource = dt;
                ddlMRP.DisplayMember = "Name";
                ddlMRP.ValueMember = "Value";
                ddlMRP.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindDSMZSM()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                cmbZSM.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbZSM.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select Code ,Name  from DSM_ZSM where isActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["Code"] = 0;
                dr["Name"] = "--select--";
                dt.Rows.InsertAt(dr, 0);
                cmbZSM.DataSource = dt;
                cmbZSM.DisplayMember = "Name";
                cmbZSM.ValueMember = "Code";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindLiasoner()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                cmbLisioner.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbLisioner.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select LiasonerCode,LiasonerName from LiasonerMaster where IsActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["LiasonerCode"] = 0;
                dr["LiasonerName"] = "--select--";
                dt.Rows.InsertAt(dr, 0);
                cmbLisioner.DataSource = dt;
                cmbLisioner.DisplayMember = "LiasonerName";
                cmbLisioner.ValueMember = "LiasonerCode";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BindDocument()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);

                dt = objCommon.GetDataTable("select Code, Name from DOC_REQ_Master where isActive = 'Yes'");

                chkdocumentlist.DataSource = dt;
                chkdocumentlist.DisplayMember = "Name";
                chkdocumentlist.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindDocument \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void bindShelfLife()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                cmbShelflife.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbShelflife.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select ShelfLifeId,ShelfLifeName from ShelfLifeMaster where IsActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["ShelfLifeId"] = 0;
                dr["ShelfLifeName"] = "--select--";
                dt.Rows.InsertAt(dr, 0);
                cmbShelflife.DataSource = dt;
                cmbShelflife.DisplayMember = "ShelfLifeName";
                cmbShelflife.ValueMember = "ShelfLifeId";

                //DataTable dt = new DataTable();
                //dt.TableName = "GridRows";
                //dt.Columns.Add("Value", Type.GetType("System.String"));
                //dt.Columns.Add("Name", Type.GetType("System.String"));

                //DataRow dr = dt.NewRow();
                //dr["Value"] = "0";
                //dr["Name"] = "--Select--";
                //dt.Rows.InsertAt(dr, 0);

                //DataRow dr1 = dt.NewRow();
                //dr1["Value"] = "1";
                //dr1["Name"] = "MORE THAN 80%";
                //dt.Rows.InsertAt(dr1, 1);

                //DataRow dr2 = dt.NewRow();
                //dr2["Value"] = "2";
                //dr2["Name"] = "MORE THAN 75%";
                //dt.Rows.InsertAt(dr2, 2);

                //DataRow dr3 = dt.NewRow();
                //dr3["Value"] = "3";
                //dr3["Name"] = "MORE THAN 60%";
                //dt.Rows.InsertAt(dr3, 3);

                //DataRow dr4 = dt.NewRow();
                //dr4["Value"] = "4";
                //dr4["Name"] = "CONFIRMATON REQUIED";
                //dt.Rows.InsertAt(dr4, 4);

                //cmbShelflife.DataSource = dt;
                //cmbShelflife.DisplayMember = "Name";
                //cmbShelflife.ValueMember = "Value";
                //cmbShelflife.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder bindShelfife \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindProductSchedule(int IOMNo)
        {
            try
            {
                //lblSchOrderID.Text = IOMNo.ToString();
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("select IOMID, IOMNo, ProductCode, ProductName, Quantity from OrderItem where IOMNo = " + IOMNo);

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvProdSchedule.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder Master Product Schedule Grid \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        dgvOrderItemSchedule.DataSource = null;

                        dgvOrderItemSchedule.Columns.Add("colScheQuantity", "Quantity");
                        dgvOrderItemSchedule.Columns["colScheQuantity"].DataPropertyName = "OrderQuantity";

                        CalendarColumn col = new CalendarColumn();

                        dgvOrderItemSchedule.Columns.Add(col);
                        dgvOrderItemSchedule.Columns[2].Name = "deliveryDate";
                        dgvOrderItemSchedule.Columns[2].HeaderText = "Delivery Date";
                        dgvOrderItemSchedule.Columns[2].DataPropertyName = "DeliveryDate";

                        BindOrderItemSchedule(Convert.ToInt32(lblSchOrderID.Text), lblProdCode.Text);

                        //DataTable dTable = new DataTable();
                        //dTable.Columns.Add("OrderQuantity", Type.GetType("System.String"));
                        //dTable.Columns.Add("DeliveryDate", Type.GetType("System.DateTime"));

                        //bindingSource = new BindingSource();
                        //bindingSource.DataSource = dTable;
                        //dgvOrderItemSchedule.DataSource = bindingSource;
                    }
                }
            }
            catch (Exception ex)
            {
                //StreamWriter swLog = File.AppendText(strLogFileName);
                //string strError = DateTime.Now.ToString() + "\n Main Page/dgvProdSchedule_CellContentClick \n" + ex.ToString();
                //swLog.WriteLine(strError);
                //swLog.WriteLine();
                //swLog.Close();
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindOrderItemSchedule(int IOMNo, string prodCode)
        {
            try
            {
                //106754
                //lblSchOrderID.Text = IOMNo.ToString();
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("select OrderQuantity,DeliveryDate from ScheduleDetail where IOMNo = '" + IOMNo + "' and MaterialCode='" + prodCode + "'");

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

        //private void BindTaxOn()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt.TableName = "GridRows";
        //        dt.Columns.Add("Value", Type.GetType("System.String"));
        //        dt.Columns.Add("Name", Type.GetType("System.String"));

        //        DataRow dr = dt.NewRow();
        //        dr["Value"] = "0";
        //        dr["Name"] = "--Select--";
        //        dt.Rows.InsertAt(dr, 0);

        //        DataRow dr1 = dt.NewRow();
        //        dr1["Value"] = "MRP";
        //        dr1["Name"] = "MRP";
        //        dt.Rows.InsertAt(dr1, 1);

        //        DataRow dr2 = dt.NewRow();
        //        dr2["Value"] = "Bill Rate";
        //        dr2["Name"] = "Bill Rate";
        //        dt.Rows.InsertAt(dr2, 2);

        //        ddlTaxOn.DataSource = dt;
        //        ddlTaxOn.DisplayMember = "Name";
        //        ddlTaxOn.ValueMember = "Value";
        //        ddlTaxOn.SelectedItem = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        StreamWriter swLog = File.AppendText(strLogFileName);
        //        string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder Tab \n" + ex.ToString();
        //        swLog.WriteLine(strError);
        //        swLog.WriteLine();
        //        swLog.Close();
        //        MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //private DataGridView dataGridView1 = new DataGridView();

        //private void AddProductMaster()
        //{
        //    DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
        //    DataTable dt = new DataTable();
        //    CommonFunction objCommon = new CommonFunction();
        //    dt = objCommon.GetDataTable("select ProductId, Material, Description from ProductMaster");
        //    comboBoxColumn.DataSource = dt;
        //    comboBoxColumn.DisplayMember = "Material";
        //    comboBoxColumn.ValueMember = "ProductId";
        //    comboBoxColumn.HeaderText = "Material Code";

        //    //ItemGridview.Columns.Insert(0,comboBoxColumn);
        //    ItemGridview.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);

        //    // ItemGridview.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        //}

        //private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    ComboBox combo = e.Control as ComboBox;
        //    if (combo != null)
        //    {
        //        // Remove an existing event-handler, if present, to avoid 
        //        // adding multiple handlers when the editing control is reused.
        //        combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);

        //        // Add the event handler. 
        //        combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
        //    }
        //}

        //private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void BindLocationMaster()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        CommonFunction objCommon = new CommonFunction();

        //        //SqlConnection conn = new SqlConnection(ConnectionString);
        //        //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
        //        //da.Fill(ds, "Country");
        //        //da.Fill(dt);
        //        dt = objCommon.GetDataTable("select LocationId, LocationCode, DispatchThru from LocationMaster where IsActive = 'Yes'");
        //        DataRow dr = dt.NewRow();
        //        dr["LocationId"] = 0;
        //        dr["DispatchThru"] = "--select--";
        //        dt.Rows.InsertAt(dr, 0);
        //        ddlLocation.DataSource = dt;
        //        ddlLocation.DisplayMember = "DispatchThru";
        //        ddlLocation.ValueMember = "LocationId";

        //    }
        //    catch (Exception ex)
        //    {
        //        StreamWriter swLog = File.AppendText(strLogFileName);
        //        string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindLocationMaster \n" + ex.ToString();
        //        swLog.WriteLine(strError);
        //        swLog.WriteLine();
        //        swLog.Close();
        //        MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void BindMaterialCode()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                cmbMaterialCode.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbMaterialCode.AutoCompleteMode = AutoCompleteMode.Suggest;

                //dt = objCommon.GetDataTable("select ProductId, convert(varchar(500), Description+' - '+ Material) as Material from ProductMaster where IsActive = 'Yes'");
                //dt = objCommon.GetDataTable("select ProductId, convert(varchar(500), Aliscode +'  -  '+ Material) as Material from ProductMaster where IsActive = 'Yes'");
                //dt = objCommon.GetDataTable("select ProductId, convert(varchar(500), ISNULL(AliasName,'') + '  -  ' + Aliscode + '  -  ' + Material) as Material from ProductMaster where IsActive = 'Yes'");
                dt = objCommon.GetDataTable("select ProductId, convert(varchar(500), ISNULL(AliasName,'') + '  -  ' + Aliscode) as Material from ProductMaster where IsActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["ProductId"] = 0;
                //dr["Material"] = "--select--";
                dr["Material"] = "";
                dt.Rows.InsertAt(dr, 0);
                cmbMaterialCode.DataSource = dt;
                cmbMaterialCode.DisplayMember = "Material";
                cmbMaterialCode.ValueMember = "ProductId";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindMaterialCode \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMaterialCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
                if (Convert.ToString(cmbMaterialCode.SelectedIndex) != "0")
                {
                    int ProdID = int.Parse(cmbMaterialCode.SelectedValue.ToString());

                    DataTable dt = new DataTable();
                    CommonFunction objCommon = new CommonFunction();
                    dt = objCommon.GetDataTable("select Material,Aliscode,AliasName,Description from ProductMaster where ProductId = " + ProdID);
                    txtMaterialName.Text = dt.Rows[0]["Description"].ToString();
                    txtAliasName.Text = dt.Rows[0]["AliasName"].ToString();
                    lblAliscode.Text = dt.Rows[0]["Aliscode"].ToString();
                    lblMaterialCode.Text = dt.Rows[0]["Material"].ToString();
                    
                    //Get GST Tax from HSN Master 11-11-2017
                    CommonFunction objCommFun = new CommonFunction();
                    DataTable dtGST_Tax = objCommFun.GetDataTable("select * from HSNMaster where HSNCode = (select HSNCode from ProductMaster where Material = '"+dt.Rows[0]["Material"].ToString()+"' and Aliscode = '"+dt.Rows[0]["Aliscode"].ToString()+"')");
                    if (dtGST_Tax.Rows.Count > 0)
                        txtTax.Text = dtGST_Tax.Rows[0]["Percentage"].ToString();
                    else
                        txtTax.Text = "0";

                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder cmbMaterialCode_SelectedIndexChanged \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDistinctIOMNo()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                ddlIOMNo.AutoCompleteSource = AutoCompleteSource.ListItems;
                ddlIOMNo.AutoCompleteMode = AutoCompleteMode.Suggest;

                dt = objCommon.GetDataTable("select distinct IOMNo, CONVERT(nvarchar(100), IOMNo) as IOMNumber from OrderHeader order by IOMNo desc");
                DataRow dr = dt.NewRow();
                dr["IOMNo"] = 0;
                dr["IOMNumber"] = "Select";
                dt.Rows.InsertAt(dr, 0);
                ddlIOMNo.DataSource = dt;
                ddlIOMNo.DisplayMember = "IOMNumber";
                ddlIOMNo.ValueMember = "IOMNo";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmCustomerMaster \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmitIOM_Click(object sender, EventArgs e)
        {
            try
            {
                //'" + strPath + "'+DocFile1
                string strPath = ConfigurationSettings.AppSettings["ServerPath"].ToString();

                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter(@"select OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, (case when OrderHeader.SubInstitution is not null then (select Name from SubInstitutionMaster where OrderHeader.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution, MRP, Remark, '" + strPath + "'+DocFile1 from OrderHeader where IOMNo = " + ddlIOMNo.Text + " order by OrderHeaderId desc");
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvOrderMaster.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/BindGridOrderheader \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetIOM_Click(object sender, EventArgs e)
        {
            BindGridOrderheader();
        }

        private void btnSaveOrderHeader_Click(object sender, EventArgs e)
        {
            //if (DBSessionUser.iYearId == "1")
            //{
            //    MessageBox.Show("Order Punching is not allowed for Year 2012 - 2016.","Information", MessageBoxButtons.OK);
            //}
            //else
            //{
            // SaveFileDialog saveFileDialog = new SaveFileDialog();
            // saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            // saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //// if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            // //{
            //     string FileName = saveFileDialog.FileName;
            //     txtUpload.Text = FileName;
            //}


            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.Yes)
            //{
            //    string FileName = saveFileDialog.FileName;
            //}


            try
            {
                //decimal comm = 0;
                bool bstatus = true;
                bstatus = validateForm();
                if (bstatus == true)
                {
                    CommonFunction objCF = new CommonFunction();
                    //if (txtComm.Text != "")
                    //    comm = decimal.Parse(txtComm.Text);

                    if (lblHdnSource.Text == "0")
                    {
                        //Updating IOM table start
                        //objCF.ExecuteDMLQuery("UPDATE IOMLogicMaster set LastUsed='" + txtIOMNO.Text + "' where ID='" + lblIOMID.Text + "' ");
                        //Updating IOM table end

                        string strDocument = "";
                        foreach (object itemChecked in chkdocumentlist.CheckedItems)
                        {
                            DataRowView castedItem = itemChecked as DataRowView;
                            //string comapnyName = castedItem["CompanyName"];
                            //int? id = castedItem["Code"];

                            if (strDocument == "")
                            {
                                strDocument = castedItem["Code"].ToString();
                            }
                            else
                            {
                                strDocument += ", " + castedItem["Code"].ToString();
                            }
                        }

                        //DateTime dtpIOMDateTime = Convert.ToDateTime(dtpIOM.Text, dateformat);
                        //DateTime dtpPODateTime = Convert.ToDateTime(dtpPO.Text, dateformat);
                        //DateTime dtpOrderRecDateTime = Convert.ToDateTime(dtpOrderRec.Text, dateformat);
                        //DateTime dtpDeliveryDateTime = Convert.ToDateTime(dtpDelivery.Text, dateformat);

                        //DateTime dtpIOMDateTime = Convert.ToDateTime(dtpIOM.Text, dateformat);
                        //DateTime dtpPODateTime = Convert.ToDateTime(dtpPO.Text, dateformat);
                        //DateTime dtpOrderRecDateTime = Convert.ToDateTime(dtpOrderRec.Text, dateformat);
                        //DateTime dtpDeliveryDateTime = Convert.ToDateTime(dtpDelivery.Text, dateformat);

                        //DateTime dtpIOMDateTime = DateTime.ParseExact(dtpIOM.Text, "yyyy/MM/dd", null);
                        //DateTime dtpPODateTime = DateTime.ParseExact(dtpPO.Text, "yyyy/MM/dd", null);
                        //DateTime dtpOrderRecDateTime = DateTime.ParseExact(dtpOrderRec.Text, "yyyy/MM/dd", null);
                        //DateTime dtpDeliveryDateTime = DateTime.ParseExact(dtpDelivery.Text, "yyyy/MM/dd", null);
                        string query = string.Empty;
                        string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            query = @"INSERT INTO OrderHeader(OrderType, IOMNo, IOMDate, InstPONo, InstPODate, OrderRecieveDate, PartyCode, PartyName, LocationCode, DispThrough,  
                                                Institution, SubInstitution, StampingID, LST_CST,  TaxIndicator, TaxOn, Schedule, MRP, DSM_ZSM,Lisioner, BillingAddress, DeliveryAddress, 
                                                OrderDeliveryDate, DocumentRequired, Remark, ShelfLife, DocFile1, LastModify, LocalPlace) 
VALUES ('" + cmbOrderType.SelectedValue + "','" + txtIOMNO.Text + "','" + DateTime.Parse(dtpIOM.Text, dateformat).ToString() + "','" + txtPONo.Text + "','" + DateTime.Parse(dtpPO.Text, dateformat).ToString() + "','" + DateTime.Parse(dtpOrderRec.Text, dateformat).ToString()
               + "','" + lblPartyCode.Text + "','" + txtpartyname.Text + "','" + txtLocationCode.Text + "','" + cmbLocationMst.Text + "','" + cmbInstitution.SelectedValue.ToString() + "','" + cmbSubInstitution.SelectedValue.ToString() + "'," + int.Parse(ddlStamping.SelectedValue.ToString()) + ",'"
               + '0' + "','" + ddlTaxIndicator.SelectedValue.ToString() + "','" + txtTaxOn.Text + "','" + ddlSchedule.SelectedValue.ToString() + "','" + ddlMRP.SelectedValue.ToString() + "','" + cmbZSM.Text + "','" + cmbLisioner.Text + "','" + txtBillingAddress.Text + "','" + txtDeliveryAddress.Text + "','"
               + DateTime.Parse(dtpDelivery.Text, dateformat).ToString() + "','" + strDocument.ToString() + "','" + txtRemark.Text + "','" + cmbShelflife.SelectedValue + "','" + txtUpload.Text + "', getdate(), '" + txtLocalPlace.Text + "')";
                        }
                        else
                        {
                            query = @"INSERT INTO OrderHeader(OrderType, IOMNo, IOMDate, InstPONo, InstPODate, OrderRecieveDate, PartyCode, PartyName, LocationCode, DispThrough,  
                                                Institution, SubInstitution, StampingID, LST_CST,  TaxIndicator, TaxOn, Schedule, MRP, DSM_ZSM,Lisioner, BillingAddress, DeliveryAddress, 
                                                OrderDeliveryDate, DocumentRequired, Remark, ShelfLife, DocFile1, LastModify, LocalPlace) 
VALUES ('" + cmbOrderType.SelectedValue + "','" + txtIOMNO.Text + "','" + DateTime.Parse(dtpIOM.Text).ToString(_dateformat) + "','" + txtPONo.Text + "','" + DateTime.Parse(dtpPO.Text).ToString(_dateformat) + "','" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat)
               + "','" + lblPartyCode.Text + "','" + txtpartyname.Text + "','" + txtLocationCode.Text + "','" + cmbLocationMst.Text + "','" + cmbInstitution.SelectedValue.ToString() + "','" + cmbSubInstitution.SelectedValue.ToString() + "'," + int.Parse(ddlStamping.SelectedValue.ToString()) + ",'"
               + '0' + "','" + ddlTaxIndicator.SelectedValue.ToString() + "','" + txtTaxOn.Text + "','" + ddlSchedule.SelectedValue.ToString() + "','" + ddlMRP.SelectedValue.ToString() + "','" + cmbZSM.Text + "','" + cmbLisioner.Text + "','" + txtBillingAddress.Text + "','" + txtDeliveryAddress.Text + "','"
               + DateTime.Parse(dtpDelivery.Text).ToString(_dateformat) + "','" + strDocument.ToString() + "','" + txtRemark.Text + "','" + cmbShelflife.SelectedValue + "','" + txtUpload.Text + "', getdate(), '" + txtLocalPlace.Text + "')";
                        }

                        Result objResult = objCF.InsertQuery(query);
                        if (objResult.bStatus)
                        {
                            tabControl1.TabPages.Add(tabPage3);
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Order Header Inserted Sucessfully";

                            lblIOMNo.Text = objResult.iRecordId.ToString();
                            lblOrderHeaderID.Text = objResult.iRecordId.ToString();

                            dataTable = objCF.GetDataTable("select Tax,EffectiveTaxRate from LocationMaster where LocationCode='" + txtLocationCode.Text + "'");

                            //txtTax.Text = dataTable.Rows[0]["Tax"].ToString();
                            txtEffectiveTax.Text = dataTable.Rows[0]["EffectiveTaxRate"].ToString();

                            lblIOMNumber.Text = txtIOMNO.Text;
                            //lblCommision.Text = comm.ToString();
                            //txtCommision.Text = comm.ToString();
                            lblTaxOn.Text = txtTaxOn.Text;
                            lblTaxincexc.Text = ddlTaxIndicator.SelectedValue.ToString();
                            lblSchedule.Text = ddlSchedule.SelectedValue.ToString();

                            //lblIOMNo.Text = "";
                            //lblOrderHeaderID.Text = "";

                            //txtTax.Text = "5.00";

                            //lblIOMNumber.Text = "12100000";
                            //lblCommision.Text = "10";
                            //txtCommision.Text = "10";
                            //lblTaxOn.Text = ss"PTD";
                            //lblTaxincexc.Text = "Tax Include";

                            lblOrderheaderstatus.Text = "1";
                            lblIOMNUMBERStatus.Text = txtIOMNO.Text;
                            lblOrderScheduleYN.Text = ddlSchedule.Text;
                            ClearForm();
                            tabControl1.SelectTab(tabPage3);
                            BindGridOrderheader();
                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = objResult.strMessage;
                        }
                    }
                    else if (lblHdnSource.Text != "0")
                    {
                        string query = ""; //"UPDATE OrderHeader set IOMNo = '', IOMDate = '', PartyCode = '', PartyName = '', DispThrough = '', InstPONo = '', InstPODate = '', Institution = '', SubInstitution = '', ShelfLife = '', OrderType = '', DocumentRequired = '', BillingAddress = '', DeliveryAddress = , StampingID = , LST_CST, TaxIndicator, TaxOn, Schedule, MRP, Commission, Remark, DeliveryDate, LastModify = getdate() WHERE OrderHeaderId ='" + lbldgvOrderHeaderID.Text + "'";
                        Result objResult = objCF.ExecuteDMLQuery(query);
                        if (objResult.bStatus)
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Order Header Updated Sucessfully";

                            lblHdnSource.Text = "0";

                            ClearForm();

                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            lblStatus.Text = objResult.strMessage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n frmOrder / btnSave_Click  \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
        }

        private void btnSaveOrderItem_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = 0;
                for (int i = 0; i < ItemGridview.Rows.Count - 1; i++)
                {
                    CommonFunction objCF = new CommonFunction();
                    SqlCommand objcmd = new SqlCommand("INSERT INTO OrderItem(IOMNo, ProductId,ProductCode,AlisCode, ProductName, InstRate, Quantity, BillingRate, Commision, MRP, ProdValue, Tax, EffTax,TaxAmt,TaxValue, TotProductValue, ValuePerProd,TotTaxvalue, LastModify) VALUES (@IOMNO,@ProductId,@MaterialCode,@Aliscode,@MaterialName,@InstRate,@Quantity,@BillRate,@Commision,@MRP,@ProductValue,@Tax,@EffTax,@TaxAmt,@TaxValue,@TotProductValue,@ValuePerProd,@TotTaxvalue,getdate()); SELECT @pk_new = @@IDENTITY");
                    objcmd.Parameters.AddWithValue("@IOMNO", lblIOMNumber.Text);
                    objcmd.Parameters.AddWithValue("@ProductId", ItemGridview.Rows[i].Cells["ProductId"].Value);
                    objcmd.Parameters.AddWithValue("@MaterialCode", ItemGridview.Rows[i].Cells["Material Code"].Value);
                    objcmd.Parameters.AddWithValue("@Aliscode", ItemGridview.Rows[i].Cells["AlisCode"].Value);
                    objcmd.Parameters.AddWithValue("@MaterialName", ItemGridview.Rows[i].Cells["Material Name"].Value);
                    objcmd.Parameters.AddWithValue("@InstRate", ItemGridview.Rows[i].Cells["Inst. Rate"].Value);
                    objcmd.Parameters.AddWithValue("@Quantity", ItemGridview.Rows[i].Cells["Quantity"].Value.ToString());
                    objcmd.Parameters.AddWithValue("@BillRate", ItemGridview.Rows[i].Cells["PTD"].Value.ToString());
                    objcmd.Parameters.AddWithValue("@Commision", ItemGridview.Rows[i].Cells["Commision"].Value.ToString());
                    objcmd.Parameters.AddWithValue("@MRP", ItemGridview.Rows[i].Cells["MRP"].Value.ToString());
                    objcmd.Parameters.AddWithValue("@ProductValue", ItemGridview.Rows[i].Cells["Product Value"].Value.ToString());
                    objcmd.Parameters.AddWithValue("@Tax", ItemGridview.Rows[i].Cells["Tax"].Value.ToString());
                    objcmd.Parameters.AddWithValue("@EffTax", ItemGridview.Rows[i].Cells["EffTax"].Value.ToString());
                    objcmd.Parameters.AddWithValue("@TaxAmt", ItemGridview.Rows[i].Cells["TaxAmt"].Value.ToString());
                    objcmd.Parameters.AddWithValue("@TaxValue", ItemGridview.Rows[i].Cells["Tax Value"].Value.ToString());
                    objcmd.Parameters.AddWithValue("@TotProductValue", txtTotProductValue.Text);
                    decimal ValuePerProd = Convert.ToDecimal(txtTotProductValue.Text) / Convert.ToDecimal(ItemGridview.Rows[i].Cells["Quantity"].Value);

                    objcmd.Parameters.AddWithValue("@ValuePerProd", ValuePerProd);
                    objcmd.Parameters.AddWithValue("@TotTaxvalue", txtTotTaxvalue.Text);
                    //objcmd.Parameters.AddWithValue("@ValuePerProd", Math.Round(Convert.ToDecimal(((Convert.ToDecimal(ItemGridview.Rows[i].Cells["Product Value"].Value.ToString())) / (Convert.ToDecimal(ItemGridview.Rows[i].Cells["Quantity"].Value.ToString())))), 3));
                    SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                    spInsertedKey.Direction = ParameterDirection.Output;
                    objcmd.Parameters.Add(spInsertedKey);

                    Result objResult = objCF.InsertNewQuery(objcmd);
                    if (objResult.bStatus)
                    {
                        flag = 1;
                    }
                }
                //MessageBox.Show("Order Item Inserted Sucessfully");
                if (flag == 1)
                {
                    lblOrderItemStatus.Text = "1";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                    lblStatus.Text = "Order Item Inserted Sucessfully";
                    ClearItemForm();
                    //bindGrid();
                    ItemGridview.DataSource = null;
                    txtTotProductValue.Text = "0";
                    txtTotTaxvalue.Text = "0";
                    lblIOMShedule.Text = lblIOMNumber.Text;
                    lblIOMNo.Text = "";
                    if (lblSchedule.Text == "Yes")
                    {
                        tabControl1.TabPages.Add(tabPage4);
                        tabControl1.SelectTab(tabPage4);

                        BindProductSchedule(int.Parse(lblIOMShedule.Text));
                    }
                    else if (lblSchedule.Text == "No")
                    {
                        MdiForm objMDI = (MdiForm)Application.OpenForms["MdiForm"];
                        frmOrder objOrder = (frmOrder)Application.OpenForms["frmOrder"];
                        objOrder = new frmOrder();
                        objOrder.MdiParent = objMDI;
                        objOrder.Show();
                    }
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    lblStatus.Text = "Order Item Not Inserted Sucessfully (Error Occured)";
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Order Item Submit \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnScheduleSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = 0;
                int TotQuantity = 0;
                for (int j = 0; j < dgvOrderItemSchedule.Rows.Count - 1; j++)
                {
                    TotQuantity += int.Parse(dgvOrderItemSchedule.Rows[j].Cells["colScheQuantity"].Value.ToString());
                }

                if (TotQuantity == int.Parse(lblOrderTotalQuantity.Text.ToString()))
                {
                    for (int i = 0; i < dgvOrderItemSchedule.Rows.Count - 1; i++)
                    {
                        CommonFunction objCF = new CommonFunction();
                        SqlCommand objcmd = new SqlCommand("INSERT INTO ScheduleDetail(IOMNo, MaterialCode, OrderQuantity, ScheduleDate, DeliveryDate, LastModify) VALUES (@IOMNo, @MaterialCode, @OrderQuantity, getdate(), @DeliveryDate, getdate()); SELECT @pk_new = @@IDENTITY");

                        objcmd.Parameters.AddWithValue("@MaterialCode", lblProdCode.Text);
                        objcmd.Parameters.AddWithValue("@IOMNo", lblSchOrderID.Text);
                        objcmd.Parameters.AddWithValue("@OrderQuantity", dgvOrderItemSchedule.Rows[i].Cells["colScheQuantity"].Value);
                        objcmd.Parameters.AddWithValue("@DeliveryDate", dgvOrderItemSchedule.Rows[i].Cells["deliveryDate"].Value);

                        SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                        spInsertedKey.Direction = ParameterDirection.Output;
                        objcmd.Parameters.Add(spInsertedKey);

                        Result objResult = objCF.InsertNewQuery(objcmd);
                        if (objResult.bStatus)
                        {
                            flag = 1;
                        }
                    }
                    //MessageBox.Show("Order Item Inserted Sucessfully");
                    if (flag == 1)
                    {
                        lblScheduleStatus.Text = "1";
                        lblOrderScheStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                        lblOrderScheStatus.Text = "Order Schedule Item Inserted Sucessfully";
                        dgvOrderItemSchedule.DataSource = null;
                        lblProdCode.Text = "";
                        lblSchOrderID.Text = "";
                        tabControl1.SelectTab(tabPage4);
                        btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);

                        this.Close();
                        MdiForm objMDI = (MdiForm)Application.OpenForms["MdiForm"];
                        frmOrder objOrder = (frmOrder)Application.OpenForms["frmOrder"];
                        if (MessageBox.Show("Order Schedule Item Inserted Sucessfully") == DialogResult.OK)
                        {
                            if (objOrder != null)
                            {
                                objOrder.WindowState = FormWindowState.Maximized;
                                objOrder.BringToFront();
                            }
                            else
                            {
                                objOrder = new frmOrder();
                                objOrder.MdiParent = objMDI;
                                objOrder.Show();
                                objOrder.BindGridOrderheader();
                                tabControl1.TabPages.Add(tabPage2);
                                tabControl1.SelectTab(tabPage2);
                            }
                        }
                    }
                    else
                    {
                        lblOrderScheStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                        lblOrderScheStatus.Text = "Order Item Not Inserted Sucessfully (Error Occured)";
                    }
                }
                else if (TotQuantity > int.Parse(lblOrderTotalQuantity.Text))
                {
                    lblOrderScheStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    lblOrderScheStatus.Text = "Order Quantity should be not more than Total Quantity";
                }
                else if (TotQuantity < int.Parse(lblOrderTotalQuantity.Text))
                {
                    lblOrderScheStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    lblOrderScheStatus.Text = "Order Quantity should be not less than Total Quantity";
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/Order Item Submit \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //var result = MessageBox.Show("Do you want  Continue Place  Order ? ", "Order Header", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    tabControl1.SelectTab(tabPage2);
            //}
            //else
            //{
            //    tabControl1.SelectTab(tabPage1);
            //}
        }

        private void dgvOrderItemSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == dgvOrderItemSchedule.Columns["columnDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this Item", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (dgvOrderItemSchedule.SelectedRows.Count == dgvOrderItemSchedule.RowCount)
                            {
                                dgvOrderItemSchedule.Rows.Clear();
                            }
                            foreach (DataGridViewRow row in dgvOrderItemSchedule.SelectedRows)
                            {
                                dgvOrderItemSchedule.Rows.Remove(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder CellContentClick \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void func_SumTotItemValue()
        {
            try
            {
                decimal TotProductValue = 0;
                decimal TotTaxvalue = 0;
                foreach (DataGridViewRow frow in ItemGridview.Rows)
                {
                    if (frow.DataBoundItem != null)
                    {
                        //txtTotProductValue.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtTotProductValue.Text.ToString()) + productvalue,3));
                        //txtTotTaxvalue.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtTotTaxvalue.Text.ToString()) + Convert.ToDecimal(taxVal),3));
                        //txtTotProductValue.Text = Convert.ToString(Convert.ToDecimal(txtTotProductValue.Text.ToString()) + Convert.ToDecimal(frow.Cells["Product Value"].Value.ToString()));
                        //txtTotTaxvalue.Text = Convert.ToString(Convert.ToDecimal(txtTotTaxvalue.Text.ToString()) + Convert.ToDecimal(frow.Cells["Tax Value"].Value.ToString()));
                        TotProductValue = TotProductValue + Convert.ToDecimal(frow.Cells["Product Value"].Value.ToString());
                        TotTaxvalue = TotTaxvalue + Convert.ToDecimal(frow.Cells["Tax Value"].Value.ToString());
                    }
                }
                txtTotProductValue.Text = TotProductValue.ToString();
                txtTotTaxvalue.Text = TotTaxvalue.ToString();
            }
            catch
            {

            }
        }

        private void ItemGridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == ItemGridview.Columns["colEdit"].Index)
                    {
                        cmbMaterialCode.SelectedValue = ItemGridview[ItemGridview.Columns["ProductId"].Index, e.RowIndex].Value.ToString();
                        lblMaterialCode.Text = ItemGridview[ItemGridview.Columns["Material Code"].Index, e.RowIndex].Value.ToString();
                        lblAliscode.Text = ItemGridview[ItemGridview.Columns["AlisCode"].Index, e.RowIndex].Value.ToString(); ;
                        txtMaterialName.Text = ItemGridview[ItemGridview.Columns["Material Name"].Index, e.RowIndex].Value.ToString();
                        txtInstRate.Text = ItemGridview[ItemGridview.Columns["Inst. Rate"].Index, e.RowIndex].Value.ToString();
                        txtQuantity.Text = ItemGridview[ItemGridview.Columns["Quantity"].Index, e.RowIndex].Value.ToString();
                        //txtBillRate.Text = ItemGridview[ItemGridview.Columns["PTD"].Index, e.RowIndex].Value.ToString();
                        txtCommision.Text = ItemGridview[ItemGridview.Columns["Commision"].Index, e.RowIndex].Value.ToString();
                        //txtMRP.Text = ItemGridview[ItemGridview.Columns["MRP"].Index, e.RowIndex].Value.ToString();
                        txtTax.Text = ItemGridview[ItemGridview.Columns["Tax"].Index, e.RowIndex].Value.ToString();
                        //txtTaxValue.Text = ItemGridview[ItemGridview.Columns["Tax Value"].Index, e.RowIndex].Value.ToString();
                        txtEffectiveTax.Text = ItemGridview[ItemGridview.Columns["EffTax"].Index, e.RowIndex].Value.ToString();

                        //txtTotProductValue.Text = Convert.ToString(Convert.ToDecimal(txtTotProductValue.Text.ToString()) - Convert.ToDecimal(ItemGridview[ItemGridview.Columns["Product Value"].Index, e.RowIndex].Value.ToString()));
                        //txtTotTaxvalue.Text = Convert.ToString(Convert.ToDecimal(txtTotTaxvalue.Text.ToString()) - Convert.ToDecimal(ItemGridview[ItemGridview.Columns["Tax Value"].Index, e.RowIndex].Value.ToString()));
                        func_SumTotItemValue();

                        foreach (DataGridViewRow row in ItemGridview.SelectedRows)
                        {
                            ItemGridview.Rows.Remove(row);
                        }
                    }
                    else if (e.ColumnIndex == ItemGridview.Columns["colDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this Item", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (ItemGridview.SelectedRows.Count == ItemGridview.RowCount)
                            {
                                ItemGridview.Rows.Clear();
                            }
                            foreach (DataGridViewRow row in ItemGridview.SelectedRows)
                            {
                                ItemGridview.Rows.Remove(row);
                            }
                            func_SumTotItemValue();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder CellContentClick \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrderMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                if (e.RowIndex != -1)
                {
                    int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                    int ordIOMNo = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colIOMNumber"].Value.ToString());
                    if (e.ColumnIndex == dgvOrderMaster.Columns["colEditOrder"].Index)
                    {
                        objC = new CommonFunction();
                        dataTable = objC.GetDataTable("select Authorised from OrderHeader where OrderHeaderId = '" + Orderheaderid + "'");
                        if (dataTable.Rows[0]["Authorised"].ToString() == "False")
                        {
                            EditOrder objEditOrder = (EditOrder)Application.OpenForms["EditOrder"];
                            if (objEditOrder != null)
                            {
                                objEditOrder.WindowState = FormWindowState.Normal;
                                objEditOrder.BringToFront();
                            }
                            else
                            {
                                objEditOrder = new EditOrder(Orderheaderid);
                                objEditOrder.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot Edit this Order");
                        }
                    }
                    else if (e.ColumnIndex == dgvOrderMaster.Columns["colView"].Index)
                    {
                        Orderdetail objOrderDetail = new Orderdetail(Orderheaderid, 1);
                        //foreach (Form form in OwnedForms)
                        //{
                        //    if (form.Name == "Orderdetail")
                        //    {
                        //        form.Activate();
                        //        return;
                        //    }
                        //}

                        FormCollection fc = Application.OpenForms;

                        foreach (Form frm in fc)
                        {
                            if (frm.Name == "Orderdetail")
                            {
                                if (MessageBox.Show("Order Detail Form Already Open") == DialogResult.OK)
                                    frm.Activate();
                                return;
                            }
                        }

                        objOrderDetail.Show();

                    }
                    else if (e.ColumnIndex == dgvOrderMaster.Columns["colDocFile1"].Index)
                    {
                        //int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                        string FileName = dgvOrderMaster.Rows[e.RowIndex].Cells["colDocFile1"].Value.ToString();

                        //string strPath = System.Windows.Forms.Application.StartupPath + "//UploadFile//" + FileName;
                        string strPath = FileName;
                        if (File.Exists(strPath))
                        {
                            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                            myProcess.StartInfo.FileName = "AcroRd32.exe";
                            myProcess.StartInfo.Arguments = " /n /A \"nameddest=nameddest\" " + strPath + "\"";
                            myProcess.Start();

                        }

                        //frmPDFRead.cs
                        //frmPDFRead objfrmPDFRead = (frmPDFRead)Application.OpenForms["frmPDFRead"];
                        //if (objfrmPDFRead != null)
                        //{
                        //    objfrmPDFRead.WindowState = FormWindowState.Normal;
                        //    objfrmPDFRead.BringToFront();
                        //}
                        //else
                        //{
                        //    objfrmPDFRead = new frmPDFRead(FileName);
                        //    objfrmPDFRead.Show();
                        //}
                    }
                    else if (e.ColumnIndex == dgvOrderMaster.Columns["colDeleteorder"].Index)
                    {
                        objC = new CommonFunction();
                        CommonFunction objCommon = new CommonFunction();
                        dataTable = objC.GetDataTable("select Authorised from OrderHeader where OrderHeaderId = '" + Orderheaderid + "'");
                        //if (dataTable.Rows[0]["Authorised"].ToString() == "False")
                        //{
                        var result = MessageBox.Show("Do you want delete this Order", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            if (ordIOMNo != null)
                            {
                                objCommon.ExecuteDMLQuery(@"insert into DeletedOrderHeader(OrderHeaderId, OrderType, IOMNo, IOMDate, OrderAuthoDate, OrderRecieveDate, OrderDeliveryDate, InstPONo, InstPODate,
PartyCode, PartyName, LocationCode, DispThrough, Institution, SubInstitution, StampingID, LST_CST, TaxIndicator, TaxOn, Schedule, MRP, DSM_ZSM,
Lisioner, Commission, BillingAddress, DeliveryAddress, DocumentRequired, Remark, ShelfLife, Staggered_Immediate, StagDueOn, DocFile1, DocFile2,
Authorised, LastModify) (select OrderHeaderId, OrderType, IOMNo, IOMDate, OrderAuthoDate, OrderRecieveDate, OrderDeliveryDate, InstPONo, InstPODate,
PartyCode, PartyName, LocationCode, DispThrough, Institution, SubInstitution, StampingID, LST_CST, TaxIndicator, TaxOn, Schedule, MRP, DSM_ZSM,
Lisioner, Commission, BillingAddress, DeliveryAddress, DocumentRequired, Remark, ShelfLife, Staggered_Immediate, StagDueOn, DocFile1, DocFile2,
Authorised, GETDATE() from OrderHeader where IOMNo = " + ordIOMNo + ")");

                                objCommon.ExecuteDMLQuery(@"insert into DeletedOrderItem(IOMID, IOMNo, ProductId, ProductCode, AlisCode, ProductName, InstRate, Quantity, BillingRate, Commision, ProdValue,
MRP, Tax, EffTax, TaxAmt, TaxValue, TotProductValue, TotTaxvalue, Sheldule, TaxStructure, BillingAddress, DeliveryAddress, StampingText,
MRPPrint, InstarRemarks, DispatchQuantity, BatchQuantity, BilledQuantity, Reason, Remark, IsDeliveryCompleted, ValuePerProd, LastModify) 
(select IOMID, IOMNo, ProductId, ProductCode, AlisCode, ProductName, InstRate, Quantity, BillingRate, Commision, ProdValue,
MRP, Tax, EffTax, TaxAmt, TaxValue, TotProductValue, TotTaxvalue, Sheldule, TaxStructure, BillingAddress, DeliveryAddress, StampingText,
MRPPrint, InstarRemarks, DispatchQuantity, BatchQuantity, BilledQuantity, Reason, Remark, IsDeliveryCompleted, ValuePerProd, GETDATE() 
from OrderItem where IOMNo = " + ordIOMNo + ")");

                                objCommon.ExecuteDMLQuery(@"insert into DeletedScheduleDetail (ScheduleID,IOMNo, MaterialCode, OrderQuantity, DispatchQuantity, ScheduleDate, DeliveryDate, BatchQuantity,
BilledQuantity,Reason, Remark, IsDeliveryCompleted, LastModify) (select ScheduleID,IOMNo, MaterialCode, OrderQuantity, DispatchQuantity, ScheduleDate, DeliveryDate, BatchQuantity,
BilledQuantity,Reason, Remark, IsDeliveryCompleted, GETDATE() from ScheduleDetail where IOMNo = " + ordIOMNo + ")");
                                //Result res = objC.ExecuteDMLQuery("delete from OrderHeader where OrderHeaderId = '" + Orderheaderid + "'");
                                Result res = objC.ExecuteDMLQuery("Delete From OrderHeader where IOMNo=" + ordIOMNo + "; Delete from OrderItem where IOMNo=" + ordIOMNo + "; Delete From ScheduleDetail where IOMNo=" + ordIOMNo + ";");
                                if (res.bStatus)
                                {
                                    MessageBox.Show("Record Deleted Successfully and Shifted to Deleted Record", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Record not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                BindGridOrderheader();
                            }
                            else
                            {
                                MessageBox.Show("Cannot delete this Order. Please try again!");
                            }
                        }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Cannot delete this Order");
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder dgvOrderMaster_CellContentClick \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            bool bstatus = true;
            bstatus = validateItemForm();

            if (bstatus == true)
            {
                //txtCommision.Text = lblCommision.Text;
                //decimal comm = Convert.ToDecimal(lblCommision.Text);
                decimal comm = Convert.ToDecimal(txtCommision.Text);
                decimal instRate = Convert.ToDecimal(txtInstRate.Text);
                decimal quantity = Convert.ToDecimal(txtQuantity.Text);
                //decimal EffectiveTax = Convert.ToDecimal(txtEffectiveTax.Text);
                decimal EffectiveTax = Convert.ToDecimal(txtTax.Text);
                decimal billRate = 0;
                decimal productvalue = 0;
                decimal mrp = 0;
                decimal taxAmt = 0;
                decimal taxVal = 0;
                decimal basicRate = 0;

                if (lblTaxincexc.Text == "Tax Exclude" && lblTaxOn.Text == "PTD")        //Tax Excluding MRP & Tax on Billing Rate
                {
                    billRate = instRate - ((instRate * comm) / 100);
                    productvalue = quantity * billRate;
                    mrp = instRate + ((instRate * EffectiveTax) / 100);
                    taxAmt = productvalue;
                    taxVal = taxAmt * (EffectiveTax / 100);
                }
                else if (lblTaxincexc.Text == "Tax Exclude" && lblTaxOn.Text == "MRP")         //Tax Excluding MRP & Tax on MRP
                {
                    billRate = instRate - ((instRate * comm) / 100);
                    productvalue = quantity * billRate;
                    mrp = instRate + (instRate * (EffectiveTax / 100));
                    taxAmt = quantity * mrp;
                    taxVal = taxAmt * (EffectiveTax / 100);
                }
                else if (lblTaxincexc.Text == "Tax Include" && lblTaxOn.Text == "PTD")   //Tax Including MRP & Tax on Billing Rate
                {
                    basicRate = (instRate / (100 + EffectiveTax)) * 100;
                    billRate = basicRate - (basicRate * (comm / 100));
                    productvalue = quantity * billRate;
                    mrp = instRate;
                    taxAmt = quantity * billRate;
                    taxVal = taxAmt * (EffectiveTax / 100);
                }
                else if (lblTaxincexc.Text == "Tax Include" && lblTaxOn.Text == "MRP")         //Tax Including MRP & Tax on MRP
                {
                    basicRate = (instRate / (100 + EffectiveTax)) * 100;
                    billRate = basicRate - (basicRate * (comm / 100));
                    productvalue = quantity * billRate;
                    mrp = instRate;
                    taxAmt = quantity * mrp;
                    taxVal = taxAmt * (EffectiveTax / 100);
                }

                string ProductCode = string.Empty;
                int isDupMaterialCode = 0;
                for (int i = 0; i < ItemGridview.Rows.Count - 1; i++)
                {
                    ProductCode = ItemGridview.Rows[i].Cells["Material Code"].Value.ToString();    //frow.Cells["colProductCode"].Value.ToString();
                    if (lblMaterialCode.Text == ProductCode)
                    {
                        isDupMaterialCode = 1;
                        break;
                    }
                }

                if (isDupMaterialCode != 1)
                {
                    this.table.Rows.Add(lblMaterialCode.Text, lblAliscode.Text, txtMaterialName.Text, txtInstRate.Text, txtQuantity.Text, Math.Round(billRate, 3).ToString(),

                    //ItemGridview.Rows[1].Cells["TaxAmt"].Value.ToString();

                    txtCommision.Text, Math.Round(productvalue, 3).ToString(), Math.Round(mrp, 3).ToString(), txtTax.Text, Math.Round(taxVal, 3).ToString(), Math.Round(taxAmt, 3).ToString(), txtEffectiveTax.Text, cmbMaterialCode.SelectedValue.ToString());

                    //txtTotProductValue.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtTotProductValue.Text.ToString()) + productvalue,3));
                    //txtTotTaxvalue.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtTotTaxvalue.Text.ToString()) + Convert.ToDecimal(taxVal),3));
                    func_SumTotItemValue();

                    ItemGridview.ReadOnly = true;
                    ClearItemForm();
                    //resizedatagrid();
                }
                else
                {
                    MessageBox.Show(ProductCode + " this product is already in the list.");
                }
            }
            else
            {
                //MessageBox.Show("Please Enter The PTD & Quantity ! ");
            }
        }

        public void ClearItemForm()
        {
            txtInstRate.Text = "";
            txtQuantity.Text = "";
            txtMaterialName.Text = "";
            txtCommision.Text = "";
            txtAliasName.Text = "";
            cmbMaterialCode.SelectedIndex = 0;
        }

        private void ClearForm()
        {
            //txtiomno.Text = "";
            cmbOrderType.SelectedIndex = 0;
            //dtpIOM.Text = objmdi.dtCurrent.ToString();
            //dtpOrderRec.Text = objmdi.dtCurrent.ToString();
            // dtpPO.Text = objmdi.dtCurrent.ToString();
            //dtpDelivery.Text = objmdi.dtCurrent.ToString();
            txtPONo.Text = "";
            cmbPartycode.SelectedIndex = 0;
            txtpartyname.Text = "";
            ddlStamping.SelectedIndex = 0;
            //ddlLocation.SelectedIndex = 0;

            cmbInstitution.SelectedIndex = 0;
            cmbSubInstitution.SelectedIndex = 0;
            cmbShelflife.SelectedIndex = 0;
            cmbOrderType.SelectedIndex = 0;
            txtBillingAddress.Text = "";
            txtDeliveryAddress.Text = "";
            chkdocumentlist.ClearSelected();
            cmbZSM.SelectedIndex = 0;
            cmbLocationMst.SelectedIndex = 0;
            txtLocationCode.Text = "";
            txtRemark.Text = "";
            //txtComm.Text = "";
            cmbLisioner.Text = "";
            ddlMRP.SelectedIndex = 0;
            ddlSchedule.SelectedIndex = 0;
            ddlTaxIndicator.SelectedIndex = 0;
            //ddlTaxOn.SelectedIndex = 0;
            txtTaxOn.Text = "";
            //ddlLSTCST.DataSource = null;
            chkdocumentlist.ClearSelected();
            foreach (int i in chkdocumentlist.CheckedIndices)
            {
                chkdocumentlist.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private bool validateForm()
        {
            errOrderHeader.Clear();
            bool isValid = true;

            if (cmbOrderType.SelectedIndex <= 0)
            {
                errOrderHeader.SetError(cmbOrderType, "CustomerType");
                isValid = false;
            }

            if (cmbPartycode.SelectedIndex <= 0)
            {
                errOrderHeader.SetError(cmbPartycode, "Party Code");
                isValid = false;
            }

            if (cmbLocationMst.SelectedIndex <= 0)
            {
                errOrderHeader.SetError(cmbLocationMst, "Location Master");
                isValid = false;
            }

            if (cmbInstitution.SelectedIndex <= 0)
            {
                errOrderHeader.SetError(cmbInstitution, "Institution");
                isValid = false;
            }

            if (cmbSubInstitution.SelectedIndex <= 0)
            {
                errOrderHeader.SetError(cmbSubInstitution, "Subinstitution");
                isValid = false;
            }

            if (ddlStamping.SelectedIndex <= 0)
            {
                errOrderHeader.SetError(ddlStamping, "Stamping");
                isValid = false;
            }

            //if (ddlLSTCST.SelectedIndex == 0)
            //{
            //    errOrderHeader.SetError(ddlLSTCST, "LST-CST");
            //    isValid = false;
            //}

            if (ddlTaxIndicator.SelectedIndex <= 0)
            {
                errOrderHeader.SetError(ddlTaxIndicator, "Tax Indicator");
                isValid = false;
            }

            //if (ddlTaxOn.SelectedIndex == 0)
            //{
            //    errOrderHeader.SetError(ddlTaxOn, "Tax On");
            //    isValid = false;
            //}

            if (ddlSchedule.SelectedIndex <= 0)
            {
                errOrderHeader.SetError(ddlSchedule, "Schedule");
                isValid = false;
            }

            if (cmbZSM.SelectedIndex <= 0)
            {
                errOrderHeader.SetError(cmbZSM, "ZSM");
                isValid = false;
            }

            if (cmbShelflife.SelectedIndex <= 0)
            {
                errOrderHeader.SetError(cmbShelflife, "Shelflife");
                isValid = false;
            }

            //if (txtComm.Text == "")
            //{
            //    errOrderHeader.SetError(txtComm, "Commission");
            //    isValid = false;
            //}

            return isValid;
        }

        private bool validateItemForm()
        {
            errOrderHeader.Clear();
            bool isValid = true;

            if (cmbMaterialCode.SelectedIndex == 0)
            {
                errOrderHeader.SetError(cmbMaterialCode, "Material Code");
                isValid = false;
            }

            try
            {
                decimal deInstRate = decimal.Parse(txtInstRate.Text);
            }
            catch (Exception ex)
            {
                errOrderHeader.SetError(txtInstRate, "Inst Rate");
                return isValid = false;
            }

            try
            {
                decimal deQuantity = decimal.Parse(txtQuantity.Text);
            }
            catch (Exception ex)
            {
                errOrderHeader.SetError(txtQuantity, "Quantity");
                return isValid = false;
            }

            try
            {
                decimal deCommision = decimal.Parse(txtCommision.Text);
            }
            catch (Exception ex)
            {
                errOrderHeader.SetError(txtCommision, "Commision");
                return isValid = false;
            }

            //try
            //{
            //    decimal deBillRate = decimal.Parse(txtBillRate.Text);
            //}
            //catch (Exception ex)
            //{
            //    errOrderHeader.SetError(txtBillRate, "BillRate");
            //    return isValid = false;
            //}

            //try
            //{
            //    decimal deMRP = decimal.Parse(txtMRP.Text);
            //}
            //catch (Exception ex)
            //{
            //    errOrderHeader.SetError(txtMRP, "MRP");
            //    return isValid = false;
            //}

            //try
            //{
            //    decimal deTax = decimal.Parse(txtTax.Text);
            //}
            //catch (Exception ex)
            //{
            //    errOrderHeader.SetError(txtTax, "Tax");
            //    return isValid = false;
            //}

            //try
            //{
            //    decimal deTaxValue = decimal.Parse(txtTaxValue.Text);
            //}
            //catch (Exception ex)
            //{
            //    errOrderHeader.SetError(txtTaxValue, "TaxValue");
            //    return isValid = false;
            //}

            return isValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = openFileDialog.FileName;
            //    txtUpload.Text = FileName;
            //}

            //string path = System.Windows.Forms.Application.StartupPath;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files (*.*)|*.*";     //"Audio File (*.mp3, *.wav)|*.mp3*;*.wav";


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtUpload.Text = dlg.FileName;
                FileInfo str = new FileInfo(dlg.FileName);
                //string strPath = System.Windows.Forms.Application.StartupPath + "//UploadFile//" + str.Name;

                string strPath = ConfigurationSettings.AppSettings["ServerPath"].ToString();

                if (!File.Exists(strPath))
                {
                    //File.Copy(txtUpload.Text, strPath); //"D:\\WinSearch\\WinSearch" + F:\\gm_17_03_2012\\gm\\bin\\Release
                    //txtUpload.Text = str.Name;
                    int count = 0;
                    string[] FName;
                    foreach (string s in dlg.FileNames)
                    {
                        FName = s.Split('\\');

                        //File.Copy(s, "C:\\file\\" + FName[FName.Length - 1]);
                        File.Copy(s, strPath + FName[FName.Length - 1]);

                        count++;

                    }
                    MessageBox.Show("File Upload Successfully for this path " + strPath, "Information Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var result = MessageBox.Show("Do you want Overwrite the existing file", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //File.Copy(txtUpload.Text, strPath, true);
                        //txtUpload.Text = str.Name;
                        int count = 0;
                        string[] FName;
                        foreach (string s in dlg.FileNames)
                        {
                            FName = s.Split('\\');

                            //File.Copy(s, "C:\\file\\" + FName[FName.Length - 1]);
                            File.Copy(s, strPath + FName[FName.Length - 1]);

                            count++;

                        }
                        MessageBox.Show("File Upload Successfully", "Information Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            this.Close();
            MdiForm objMDI = (MdiForm)Application.OpenForms["MdiForm"];
            frmOrder objOrder = (frmOrder)Application.OpenForms["frmOrder"];

            if (objOrder != null)
            {
                objOrder.WindowState = FormWindowState.Maximized;
                objOrder.BringToFront();
            }
            else
            {
                objOrder = new frmOrder();
                objOrder.MdiParent = objMDI;
                objOrder.Show();
                objOrder.BindGridOrderheader();
                tabControl1.TabPages.Add(tabPage2);
                //objOrder.tabControl1.SelectedTab = tabPage2;
                tabControl1.SelectTab(tabPage2);

            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.mintCurrentPage = 0;

            loadPage();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.mintCurrentPage == this.mintPageCount)
                this.mintCurrentPage = this.mintPageCount - 1;

            this.mintCurrentPage--;

            if (this.mintCurrentPage < 1)
                this.mintCurrentPage = 0;

            loadPage();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.mintCurrentPage++;

            if (this.mintCurrentPage > (this.mintPageCount - 1))
                this.mintCurrentPage = this.mintPageCount - 1;

            loadPage();
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            this.mintCurrentPage = this.mintPageCount - 1;

            loadPage();
        }

        private void frmOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (lblOrderheaderstatus.Text == "1")
                {
                    if (lblOrderScheduleYN.Text == "Yes")
                    {
                        if (lblOrderItemStatus.Text == "0")
                        {
                            if (MessageBox.Show("Order Item Not Added,Data may Lose..Continue", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                CommonFunction objCF = new CommonFunction();
                                SqlCommand objcmd = new SqlCommand("Delete From OrderHeader where IOMNo=@IOMNo");
                                objcmd.Parameters.AddWithValue("@IOMNo", lblIOMNUMBERStatus.Text);

                                Result objResult = objCF.ExecuteNewDMLQuery(objcmd);
                                if (objResult.bStatus)
                                {

                                }
                            }
                        }
                        else if (lblScheduleStatus.Text == "0")
                        {
                            if (MessageBox.Show("Order Schedule Not Added,Data may Lose..Continue", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                CommonFunction objCF = new CommonFunction();
                                SqlCommand objcmd = new SqlCommand("Delete From OrderHeader where IOMNo=@IOMNo;Delete from OrderItem where IOMNo=@IOMNo;");
                                objcmd.Parameters.AddWithValue("@IOMNo", lblIOMNUMBERStatus.Text);

                                Result objResult = objCF.ExecuteNewDMLQuery(objcmd);
                                if (objResult.bStatus)
                                {

                                }
                            }
                        }
                    }
                    else if (lblOrderItemStatus.Text == "0")
                    {
                        if (MessageBox.Show("Order Item Not Added,Data may Lose..Continue", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            CommonFunction objCF = new CommonFunction();
                            SqlCommand objcmd = new SqlCommand("Delete from OrderHeader where IOMNo=@IOMNo");
                            objcmd.Parameters.AddWithValue("@IOMNo", lblIOMNUMBERStatus.Text);

                            Result objResult = objCF.ExecuteNewDMLQuery(objcmd);
                            if (objResult.bStatus)
                            {

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            tabControl1.SelectTab(tabPage1);
        }

        private void ddlLSTCST_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}


//private DataGridView dataGridView1 = new DataGridView();

//private void AddColorColumn()
//{
//    DataGridViewComboBoxColumn comboBoxColumn =
//        new DataGridViewComboBoxColumn();
//    comboBoxColumn.Items.AddRange(
//        Color.Red, Color.Yellow, Color.Green, Color.Blue);
//    comboBoxColumn.ValueType = typeof(Color);
//    dataGridView1.Columns.Add(comboBoxColumn);
//    dataGridView1.EditingControlShowing +=
//        new DataGridViewEditingControlShowingEventHandler(
//        dataGridView1_EditingControlShowing);
//}

//private void dataGridView1_EditingControlShowing(object sender,
//    DataGridViewEditingControlShowingEventArgs e)
//{
//    ComboBox combo = e.Control as ComboBox;
//    if (combo != null)
//    {
//        // Remove an existing event-handler, if present, to avoid 
//        // adding multiple handlers when the editing control is reused.
//        combo.SelectedIndexChanged -=
//            new EventHandler(ComboBox_SelectedIndexChanged);

//        // Add the event handler. 
//        combo.SelectedIndexChanged +=
//            new EventHandler(ComboBox_SelectedIndexChanged);
//    }
//}

//private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
//{
//    ((ComboBox)sender).BackColor = (Color)((ComboBox)sender).SelectedItem;
//}






//public class CalendarColumn : DataGridViewColumn
//{
//    public CalendarColumn() : base(new CalendarCell())
//    {

//    }

//    public override DataGridViewCell CellTemplate
//    {
//        get
//        {
//            return base.CellTemplate;
//        }
//        set
//        {
//            // Ensure that the cell used for the template is a CalendarCell.
//            if (value != null &&
//                !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
//            {
//                throw new InvalidCastException("Must be a CalendarCell");
//            }
//            base.CellTemplate = value;
//        }
//    }
//}

//public class CalendarCell : DataGridViewTextBoxCell
//{

//    public CalendarCell()
//        : base()
//    {
//        // Use the short date format.
//        this.Style.Format = "dd/MM/yyyy";
//    }

//    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
//    {

//        // Set the value of the editing control to the current cell value.
//        base.InitializeEditingControl(rowIndex, initialFormattedValue,
//            dataGridViewCellStyle);
//        CalendarEditingControl ctl =
//            DataGridView.EditingControl as CalendarEditingControl;
//        // Use the default row value when Value property is null.
//        if (this.Value == null)
//        {
//            ctl.Value = (DateTime)this.DefaultNewRowValue;
//        }
//        else
//        {
//            //(DateTime)cVal = this.Value;

//            if (this.Value != "")
//            {
//                ctl.Value = (DateTime)this.Value;
//            }
//            else
//            {

//            }
//        }
//    }

//    public override Type EditType
//    {
//        get
//        {
//            // Return the type of the editing control that CalendarCell uses.
//            return typeof(CalendarEditingControl);
//        }
//    }

//    public override Type ValueType
//    {
//        get
//        {
//            // Return the type of the value that CalendarCell contains.

//            return typeof(DateTime);
//        }
//    }

//    public override object DefaultNewRowValue
//    {
//        get
//        {
//            // Use the current date and time as the default value.
//            return DateTime.Now;
//        }
//    }
//}

//class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
//{
//    DataGridView dataGridView;
//    private bool valueChanged = false;
//    int rowIndex;

//    public CalendarEditingControl()
//    {
//        this.Format = DateTimePickerFormat.Short;
//    }

//    // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
//    // property.
//    public object EditingControlFormattedValue
//    {
//        get
//        {
//            return this.Value.ToShortDateString();
//        }
//        set
//        {
//            if (value is String)
//            {
//                try
//                {
//                    // This will throw an exception of the string is 
//                    // null, empty, or not in the format of a date.
//                    this.Value = DateTime.Parse((String)value);
//                }
//                catch
//                {
//                    // In the case of an exception, just use the 
//                    // default value so we're not left with a null
//                    // value.
//                    this.Value = DateTime.Now;
//                }
//            }
//        }
//    }

//    // Implements the 
//    // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
//    public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
//    {
//        return EditingControlFormattedValue;
//    }

//    // Implements the 
//    // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
//    public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
//    {
//        this.Font = dataGridViewCellStyle.Font;
//        this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
//        this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
//    }

//    // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
//    // property.
//    public int EditingControlRowIndex
//    {
//        get
//        {
//            return rowIndex;
//        }
//        set
//        {
//            rowIndex = value;
//        }
//    }

//    // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
//    // method.
//    public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
//    {
//        // Let the DateTimePicker handle the keys listed.
//        switch (key & Keys.KeyCode)
//        {
//            case Keys.Left:
//            case Keys.Up:
//            case Keys.Down:
//            case Keys.Right:
//            case Keys.Home:
//            case Keys.End:
//            case Keys.PageDown:
//            case Keys.PageUp:
//                return true;
//            default:
//                return !dataGridViewWantsInputKey;
//        }
//    }

//    // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
//    // method.
//    public void PrepareEditingControlForEdit(bool selectAll)
//    {
//        // No preparation needs to be done.
//    }

//    // Implements the IDataGridViewEditingControl
//    // .RepositionEditingControlOnValueChange property.
//    public bool RepositionEditingControlOnValueChange
//    {
//        get
//        {
//            return false;
//        }
//    }

//    // Implements the IDataGridViewEditingControl
//    // .EditingControlDataGridView property.
//    public DataGridView EditingControlDataGridView
//    {
//        get
//        {
//            return dataGridView;
//        }
//        set
//        {
//            dataGridView = value;
//        }
//    }

//    // Implements the IDataGridViewEditingControl
//    // .EditingControlValueChanged property.
//    public bool EditingControlValueChanged
//    {
//        get
//        {
//            return valueChanged;
//        }
//        set
//        {
//            valueChanged = value;
//        }
//    }

//    // Implements the IDataGridViewEditingControl
//    // .EditingPanelCursor property.
//    public Cursor EditingPanelCursor
//    {
//        get
//        {
//            return base.Cursor;
//        }
//    }

//    protected override void OnValueChanged(EventArgs eventargs)
//    {
//        // Notify the DataGridView that the contents of the cell
//        // have changed.
//        valueChanged = true;
//        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
//        base.OnValueChanged(eventargs);
//    }
//}
