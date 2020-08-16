using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ww_lib;
using ww_admin;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;
using System.Configuration;

namespace GlanMark
{
    public partial class EditOrder : Form
    {
        CommonFunction objC = null;
        private SqlConnection objConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        DataTable table = new DataTable();
        IFormatProvider dateformat = new System.Globalization.CultureInfo("en-GB");
        private string _dateformat = "MM/dd/yyyy";

        public int nullFlag = 0;

        string strLogFileName = "LOG/LogRecord.txt";

        public EditOrder()
        {
            InitializeComponent();

            //table.Columns.Add("ProductCode", typeof(string));
            //table.Columns.Add("AlisCode", typeof(string));
            //table.Columns.Add("ProductName", typeof(string));
            //table.Columns.Add("InstRate", typeof(string));
            //table.Columns.Add("Quantity", typeof(string));
            //table.Columns.Add("BillingRate", typeof(string));
            //table.Columns.Add("Commision", typeof(string));
            //table.Columns.Add("ProdValue", typeof(string));
            //table.Columns.Add("MRP", typeof(string));
            //table.Columns.Add("Tax", typeof(string));
            //table.Columns.Add("TaxValue", typeof(string));
            //table.Columns.Add("TaxAmt", typeof(string));
            //table.Columns.Add("EffTax", typeof(string));
            //table.Columns.Add("IOMNo", typeof(string));
            //table.Columns.Add("IOMID", typeof(string));        //Hidden Column

        }

        public EditOrder(int Orderheaderid)
        {
            InitializeComponent();
            //table.Columns.Add("IOMNo", typeof(string));
            //table.Columns.Add("IOMID", typeof(string));        //Hidden Column
            //table.Columns.Add("ProductId", typeof(string));      //Hidden Column
            //table.Columns.Add("ProductCode", typeof(string));
            //table.Columns.Add("AlisCode", typeof(string));
            //table.Columns.Add("ProductName", typeof(string));
            //table.Columns.Add("InstRate", typeof(string));
            //table.Columns.Add("Quantity", typeof(string));
            //table.Columns.Add("BillingRate", typeof(string));
            //table.Columns.Add("Commision", typeof(string));
            //table.Columns.Add("MRP", typeof(string));
            //table.Columns.Add("ProdValue", typeof(string));
            //table.Columns.Add("Tax", typeof(string));
            //table.Columns.Add("TaxValue", typeof(string));
            //table.Columns.Add("TaxAmt", typeof(string));
            //table.Columns.Add("EffTax", typeof(string));
            
            BindOrderType();
            BindPartyCode();
            BindLocationMaster();
            BindInstitution();
            BindSubInstitution();
            BindStampingMaster();
            BindTaxIndicator();
            //BindTaxOn();
            BindSchedule();
            BindMRP();
            BindDSMZSM();
            BindLiasoner();
            BindDocument();
            bindShelfLife();

            //ItemGridview.DataSource = table;

            BindOrder(Orderheaderid);

            BindMaterialCode();
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
            //dgvOrderItemSchedule.Columns[0].Name = "colScheQuantity";
            //dgvOrderItemSchedule.Columns[0].HeaderText = "Quantity";
            //dgvOrderItemSchedule.Columns[0].DataPropertyName = "OrderQuantity";
            //dgvOrderItemSchedule.Columns.Add("colScheQuantity", "Quantity");
            //dgvOrderItemSchedule.Columns["colScheQuantity"].DataPropertyName = "OrderQuantity";

            //CalendarColumn col = new CalendarColumn();
            //dgvOrderItemSchedule.Columns.Add(col);
            //dgvOrderItemSchedule.Columns[1].Name = "deliveryDate";
            //dgvOrderItemSchedule.Columns[1].HeaderText = "Delivery Date";
            //dgvOrderItemSchedule.Columns[1].DataPropertyName = "DeliveryDate";
        }

        private void BindOrder(int Orderheaderid)
        {
            try
            {
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter(@"select (CASE when OrderHeader.PartyCode is not null then (select Customerid from CustomerMaster where CustomerMaster.CustomerCode = OrderHeader.PartyCode and IsActive = 'Yes') end) Customerid, * from OrderHeader where OrderHeader.OrderHeaderId ='" + Orderheaderid + "'");
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                txtLocalPlace.Text = dataTable.Rows[0]["LocalPlace"].ToString();
                cmbOrderType.SelectedValue = dataTable.Rows[0]["OrderType"].ToString();
                dtpOrderRec.Text = dataTable.Rows[0]["OrderRecieveDate"].ToString();
                txtIOMNO.Text = dataTable.Rows[0]["IOMNo"].ToString();
                dtpIOM.Text = dataTable.Rows[0]["IOMDate"].ToString();
                txtPONo.Text = dataTable.Rows[0]["InstPONo"].ToString();
                dtpPO.Text = dataTable.Rows[0]["InstPODate"].ToString();
                txtpartyname.Text = dataTable.Rows[0]["PartyName"].ToString();
                cmbPartycode.SelectedValue = dataTable.Rows[0]["Customerid"].ToString();
                lblPartyCode.Text = dataTable.Rows[0]["PartyCode"].ToString();
                
                //txtDispatchthru.Text = dataTable.Rows[0]["DispThrough"].ToString();
                cmbLocationMst.SelectedValue = dataTable.Rows[0]["LocationCode"].ToString();
                txtLocationCode.Text = dataTable.Rows[0]["LocationCode"].ToString();
                
                DataTable dtTable = objC.GetDataTable("select Tax,EffectiveTaxRate from LocationMaster where LocationCode='" + txtLocationCode.Text + "'");
                //txtTax.Text = dtTable.Rows[0]["Tax"].ToString();
                txtEffectiveTax.Text = dtTable.Rows[0]["EffectiveTaxRate"].ToString();

                cmbInstitution.SelectedValue = dataTable.Rows[0]["Institution"].ToString();
                cmbSubInstitution.SelectedValue = dataTable.Rows[0]["SubInstitution"].ToString();
                ddlLSTCST.SelectedValue = dataTable.Rows[0]["LST_CST"].ToString();
                ddlStamping.SelectedValue = dataTable.Rows[0]["StampingID"].ToString();
                ddlTaxIndicator.SelectedValue = dataTable.Rows[0]["TaxIndicator"].ToString();
                txtTaxOn.Text = dataTable.Rows[0]["TaxOn"].ToString();
                ddlSchedule.SelectedValue = dataTable.Rows[0]["Schedule"].ToString();

                if (dataTable.Rows[0]["Schedule"].ToString() == "No")
                {
                    tabControl1.TabPages.Remove(tabPage3);
                }

                lblTaxOn.Text = dataTable.Rows[0]["TaxOn"].ToString();
                lblTaxincexc.Text = dataTable.Rows[0]["TaxIndicator"].ToString();
                lblSchedule.Text = dataTable.Rows[0]["Schedule"].ToString();
                
                ddlMRP.SelectedValue = dataTable.Rows[0]["MRP"].ToString();

                //cmbLisioner.SelectedText = dataTable.Rows[0]["Lisioner"].ToString();
                BindLiasonerByID(dataTable.Rows[0]["Lisioner"].ToString());
                
                //cmbZSM.SelectedText = dataTable.Rows[0]["DSM_ZSM"].ToString();
                BindDSMZSMByID(dataTable.Rows[0]["DSM_ZSM"].ToString());

                cmbShelflife.SelectedValue = dataTable.Rows[0]["ShelfLife"].ToString();
                txtBillingAddress.Text = dataTable.Rows[0]["BillingAddress"].ToString();
                txtDeliveryAddress.Text = dataTable.Rows[0]["DeliveryAddress"].ToString();
                dtpDelivery.Text = dataTable.Rows[0]["OrderDeliveryDate"].ToString();
                
                //lblFileName.Text = dataTable.Rows[0]["DocFile1"].ToString();

                string strPath = ConfigurationSettings.AppSettings["ServerPath"].ToString();

                if (dataTable.Rows[0]["DocFile1"].ToString() != "")
                    lnkDocFile.Text = strPath + dataTable.Rows[0]["DocFile1"].ToString();
                else
                    lnkDocFile.Text = "Document Not Available For this Order";

                //lblDeliveryDate.Text = dataTable.Rows[0]["DeliveryDate"].ToString();
                string [] docList=dataTable.Rows[0]["DocumentRequired"].ToString().Split(',');

                for (int i = 0; i < chkdocumentlist.Items.Count; i++)
                {
                    for (int j = 0; j < docList.Length; j++)
                    {
                        //if (chkdocumentlist.Items[i] == docList[j])
                        //{
                        //    chkdocumentlist.SetItemCheckState(i, CheckState.Checked);
                        //}

                        if (((System.Data.DataRowView)(chkdocumentlist.Items[i])).Row.ItemArray[0].ToString() == docList[j].Trim().ToString())
                        {
                            chkdocumentlist.SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                }

                //for (int i = 0; i < docList.Length; i++)
                //{
                //    chkdocumentlist.SelectedValue = docList[i];
                //}
                //chkdocumentlist.SelectedValue = dataTable.Rows[0]["DocumentRequired"].ToString();
                //txtComm.Text = dataTable.Rows[0]["Commission"].ToString();
                txtRemark.Text = dataTable.Rows[0]["Remark"].ToString();
                lblOrderHeaderId.Text = dataTable.Rows[0]["OrderHeaderId"].ToString();

                //MessageBox.Show(DBSessionUser.iUser_Type.ToString());

                //if (DBSessionUser.iUser_Type != 1)
                //{
                //    chkAuthorize.Visible = false;
                //    btnAuthorize.Visible = false;
                //}
                //else
                //{
                //    if (dataTable.Rows[0]["Authorised"].ToString() == "True")
                //    {
                //        chkAuthorize.Checked = true;
                //    }
                //}
                BindOrderItem(Convert.ToInt32(dataTable.Rows[0]["IOMNo"].ToString()));
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex.ToString());
            }
        }
        private void BindOrderType()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
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
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder BindOrderType \n" + ex.ToString();
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

                dt = objCommon.GetDataTable("select Customerid, convert(varchar(500), Name + ' - ' + CustomerCode) as CustomerName from CustomerMaster where isActive = 'Yes' order by CustomerName asc");
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
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder BindPartyCode \n" + ex.ToString();
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
                    dt = objCommon.GetDataTable("select CustomerMaster.Name,CustomerMaster.City,CustomerMaster.Street,CustomerMaster.Street1,CustomerMaster.PostalCode,CustomerMaster.DispatchThru,CustomerMaster.LocationCode,CustomerMaster.CustomerCode,CustomerMaster.LST_CST,LocationMaster.TaxOn from CustomerMaster join LocationMaster on CustomerMaster.LocationCode=LocationMaster.LocationCode  where CustomerId =  " + CustomerId);
                    txtpartyname.Text = dt.Rows[0]["name"].ToString();
                    //txtLSTCST.Text = dt.Rows[0]["name"].ToString();
                    string Billaddress = dt.Rows[0]["name"].ToString() + " " + dt.Rows[0]["City"].ToString() + " " + dt.Rows[0]["Street"].ToString() + " " + dt.Rows[0]["Street1"].ToString() + dt.Rows[0]["PostalCode"].ToString();
                    txtBillingAddress.Text = Billaddress;
                    txtDeliveryAddress.Text = Billaddress;
                    //txtDispatchthru.Text = dt.Rows[0]["DispatchThru"].ToString();
                    txtLocationCode.Text = dt.Rows[0]["LocationCode"].ToString();
                    lblPartyCode.Text = dt.Rows[0]["CustomerCode"].ToString();
                    txtTaxOn.Text = dt.Rows[0]["TaxOn"].ToString();
                    BindLST_CST(dt.Rows[0]["LST_CST"].ToString());
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder cmbPartycode_SelectedIndexChanged \n" + ex.ToString();
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

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
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
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder save button \n" + ex.ToString();
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

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
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
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder save button \n" + ex.ToString();
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

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
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
        private void BindLST_CST(string LSTCSTID)
        {
            try
            {
                if (LSTCSTID != "")
                {
                    DataTable dt = new DataTable();
                    CommonFunction objCommon = new CommonFunction();
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
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder BindLST_CST \n" + ex.ToString();
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
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder Tab \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //        string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder Tab \n" + ex.ToString();
        //        swLog.WriteLine(strError);
        //        swLog.WriteLine();
        //        swLog.Close();
        //        MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
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
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder Tab \n" + ex.ToString();
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
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder Tab \n" + ex.ToString();
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

                //SqlConnection conn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter("select * from Country order by name", conn);
                //da.Fill(ds, "Country");
                //da.Fill(dt);
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
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder save button \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDSMZSMByID(string strDSMZSM)
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();
                dt = objCommon.GetDataTable("select Code ,Name  from DSM_ZSM where isActive = 'Yes'");
                DataRow dr = dt.NewRow();
                dr["Code"] = 0;
                dr["Name"] = strDSMZSM;
                dt.Rows.InsertAt(dr, 0);
                cmbZSM.DataSource = dt;
                cmbZSM.DisplayMember = "Name";
                cmbZSM.ValueMember = "Code";

            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder save button \n" + ex.ToString();
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
                //DataRow dr = dt.NewRow();
                //dr["LiasonerCode"] = 0;
                //dr["LiasonerName"] = "--select--";
                //dt.Rows.InsertAt(dr, 0);
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

        private void BindLiasonerByID(string strSelected)
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
                dr["LiasonerName"] = strSelected;
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
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder BindDocument \n" + ex.ToString();
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

        public void BindMaterialCode()
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCommon = new CommonFunction();

                cmbMaterialCode.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmbMaterialCode.AutoCompleteMode = AutoCompleteMode.Suggest;

                //dt = objCommon.GetDataTable("select ProductId, convert(varchar(500), Description+' - '+ Material) as Material from ProductMaster where IsActive = 'Yes'");
                dt = objCommon.GetDataTable("select ProductId, convert(varchar(500), ISNULL(AliasName,'') + '  -  ' + Aliscode + '  -  ' + Material) as Material from ProductMaster where IsActive = 'Yes'");
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
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder BindPartyCode \n" + ex.ToString();
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
                    dt = objCommon.GetDataTable("select Material,Aliscode,Description from ProductMaster where ProductId = " + ProdID);
                    txtMaterialName.Text = dt.Rows[0]["Description"].ToString();
                    lblAliscode.Text = dt.Rows[0]["Aliscode"].ToString();
                    lblMaterialCode.Text = dt.Rows[0]["Material"].ToString();

                    CommonFunction objCommFun = new CommonFunction();
                    DataTable dtGST_Tax = objCommFun.GetDataTable("select * from HSNMaster where HSNCode = (select HSNCode from ProductMaster where Material = '" + dt.Rows[0]["Material"].ToString() + "' and Aliscode = '" + dt.Rows[0]["Aliscode"].ToString() + "')");
                    txtTax.Text = dtGST_Tax.Rows[0]["Percentage"].ToString();
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

        private void BindOrderItem(int IOMNo)
        {
            try
            {
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("select CloseItem,IOMID,IOMNo,TotTaxvalue,TotProductValue,ProductId,ProductCode,AlisCode,ProductName,InstRate, Quantity,BillingRate,Commision,MRP,ProdValue,Tax,EffTax,TaxAmt,TaxValue from OrderItem where IOMNo = '" + IOMNo + "'");

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                //lbIOMID.Text = dataTable.Rows[0]["IOMID"].ToString();  //Don't set this value it is require for item Add and Edit Logic
                lblIOMNumber.Text = dataTable.Rows[0]["IOMNo"].ToString();
                lblCommision.Text = dataTable.Rows[0]["Commision"].ToString();
                txtTotProductValue.Text = dataTable.Rows[0]["TotProductValue"].ToString();
                txtTotTaxvalue.Text = dataTable.Rows[0]["TotTaxvalue"].ToString();
                //dataTable.Columns.Remove("IOMID");
                //dataTable.Columns.Remove("IOMNo");
                dataTable.Columns.Remove("TotProductValue");
                dataTable.Columns.Remove("TotTaxvalue");
                bindingSource.DataSource = dataTable;
                ItemGridview.DataSource = bindingSource;
                dgvProdSchedule.DataSource = bindingSource;

                ItemGridview.ReadOnly = true;
                ItemGridview.Columns[0].ReadOnly = false;
                ItemGridview.Columns[1].ReadOnly = false;
                ItemGridview.Columns[2].ReadOnly = false;

            }
            catch (Exception ex)
            {
            }
        }

        private void BindOrderItemSchedule(int IOMNo, string prodCode)
        {
            try
            {
                //106754
                //lblSchOrderID.Text = IOMNo.ToString();
                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("select OrderQuantity, DeliveryDate from ScheduleDetail where IOMNo = '" + IOMNo + "' and MaterialCode='" + prodCode + "'");

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable;
                    dgvOrderItemSchedule.DataSource = bindingSource;
                }
                else
                {
                    //MdiForm objmdi = new MdiForm();
                    //DataRow dr = dataTable.NewRow();
                    //dr["OrderQuantity"] = 0;
                    //dr["DeliveryDate"] = objmdi.dtCurrent.ToString();
                    //dataTable.Rows.InsertAt(dr, 0);
                    objC = new CommonFunction();
                    sqlDataAdapter = objC.GetSqlDataAdapter("select top 1 0 as OrderQuantity, GETDATE() as DeliveryDate from ScheduleDetail where 1=1");
                    dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable;
                    dgvOrderItemSchedule.DataSource = bindingSource;
                    nullFlag = 1;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                bool bstatus = true;
                bstatus = validateItemForm();

                if (bstatus == true)
                {
                    CommonFunction objCF = null;
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


                    //this.table.Rows.Add(lblMaterialCode.Text, lblAliscode.Text, txtMaterialName.Text, txtInstRate.Text, txtQuantity.Text, Math.Round(billRate, 3).ToString(),
                    //txtCommision.Text, Math.Round(productvalue, 3).ToString(), Math.Round(mrp, 3).ToString(), txtTax.Text, Math.Round(taxVal, 3).ToString(), Math.Round(taxAmt, 3).ToString(), txtEffectiveTax.Text, cmbMaterialCode.SelectedValue.ToString());

                    //txtTotProductValue.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtTotProductValue.Text.ToString()) + productvalue, 3));
                    //txtTotTaxvalue.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtTotTaxvalue.Text.ToString()) + Convert.ToDecimal(taxVal), 3));
                    //func_SumTotItemValue();
                    string ProductCode = string.Empty;
                    int isDupMaterialCode = 0;
                    foreach (DataGridViewRow frow in ItemGridview.Rows)
                    {
                        if (frow.DataBoundItem != null)
                        {
                            ProductCode = frow.Cells["colProductCode"].Value.ToString();
                            if (lblMaterialCode.Text == ProductCode)
                            {
                                isDupMaterialCode = 1;
                                break;
                            }
                        }
                    }

                    if (lbIOMID.Text == "0")
                    {
                        if (isDupMaterialCode != 1)
                        {
                            objCF = new CommonFunction();
                            SqlCommand objcmd = new SqlCommand("INSERT INTO OrderItem(IOMNo, ProductId,ProductCode,AlisCode, ProductName, InstRate, Quantity, BillingRate, Commision, MRP, ProdValue, Tax, EffTax,TaxAmt,TaxValue, TotProductValue, TotTaxvalue, ValuePerProd, LastModify) VALUES (@IOMNO,@ProductId,@MaterialCode,@Aliscode,@MaterialName,@InstRate,@Quantity,@BillRate,@Commision,@MRP,@ProductValue,@Tax,@EffTax,@TaxAmt,@TaxValue,@TotProductValue,@TotTaxvalue, @ValuePerProd, getdate()); SELECT @pk_new = @@IDENTITY");
                            objcmd.Parameters.AddWithValue("@IOMNO", lblIOMNumber.Text);
                            objcmd.Parameters.AddWithValue("@ProductId", cmbMaterialCode.SelectedValue);
                            objcmd.Parameters.AddWithValue("@MaterialCode", lblMaterialCode.Text);
                            objcmd.Parameters.AddWithValue("@Aliscode", lblAliscode.Text);
                            objcmd.Parameters.AddWithValue("@MaterialName", txtMaterialName.Text);
                            objcmd.Parameters.AddWithValue("@InstRate", txtInstRate.Text);
                            objcmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                            objcmd.Parameters.AddWithValue("@BillRate", Math.Round(billRate, 3).ToString());
                            objcmd.Parameters.AddWithValue("@Commision", txtCommision.Text);
                            objcmd.Parameters.AddWithValue("@MRP", Math.Round(mrp, 3).ToString());
                            objcmd.Parameters.AddWithValue("@ProductValue", Math.Round(productvalue, 3).ToString());
                            objcmd.Parameters.AddWithValue("@Tax", txtTax.Text);
                            objcmd.Parameters.AddWithValue("@EffTax", txtEffectiveTax.Text);
                            objcmd.Parameters.AddWithValue("@TaxAmt", Math.Round(taxAmt, 3).ToString());
                            objcmd.Parameters.AddWithValue("@TaxValue", Math.Round(taxVal, 3).ToString());
                            objcmd.Parameters.AddWithValue("@TotProductValue", txtTotProductValue.Text);
                            objcmd.Parameters.AddWithValue("@TotTaxvalue", txtTotTaxvalue.Text);

                            objcmd.Parameters.AddWithValue("@ValuePerProd", Math.Round(Convert.ToDecimal(((Convert.ToDecimal(Math.Round(productvalue, 3).ToString())) / (Convert.ToDecimal(txtQuantity.Text.ToString())))), 3));

                            SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                            spInsertedKey.Direction = ParameterDirection.Output;
                            objcmd.Parameters.Add(spInsertedKey);

                            Result objResult = objCF.InsertNewQuery(objcmd);
                            if (objResult.bStatus)
                            {
                                BindOrderItem(Convert.ToInt32(lblIOMNumber.Text));
                            }
                        }
                        else
                        {
                            MessageBox.Show(ProductCode + " this product is already in the list.");
                        }
                    }
                    else if (lbIOMID.Text != "0")
                    {
                        objCF = new CommonFunction();
                        SqlCommand objcmd = new SqlCommand("UPDATE OrderItem set IOMNo=@IOMNO, ProductId=@ProductId, ProductCode=@MaterialCode, AlisCode=@Aliscode, ProductName=@MaterialName, InstRate=@InstRate, Quantity=@Quantity, BillingRate=@BillRate, Commision=@Commision, MRP=@MRP, ProdValue=@ProductValue, Tax=@Tax, EffTax=@EffTax, TaxAmt=@TaxAmt, TaxValue=@TaxValue, TotProductValue=@TotProductValue, TotTaxvalue=@TotTaxvalue, ValuePerProd=@ValuePerProd, LastModify=getdate() WHERE IOMID=@IOMID");
                        objcmd.Parameters.AddWithValue("@IOMID", lbIOMID.Text);
                        objcmd.Parameters.AddWithValue("@IOMNO", lblIOMNumber.Text);
                        objcmd.Parameters.AddWithValue("@ProductId", cmbMaterialCode.SelectedValue);
                        objcmd.Parameters.AddWithValue("@MaterialCode", lblMaterialCode.Text);
                        objcmd.Parameters.AddWithValue("@Aliscode", lblAliscode.Text);
                        objcmd.Parameters.AddWithValue("@MaterialName", txtMaterialName.Text);
                        objcmd.Parameters.AddWithValue("@InstRate", txtInstRate.Text);
                        objcmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                        objcmd.Parameters.AddWithValue("@BillRate", Math.Round(billRate, 3).ToString());
                        objcmd.Parameters.AddWithValue("@Commision", txtCommision.Text);
                        objcmd.Parameters.AddWithValue("@MRP", Math.Round(mrp, 3).ToString());
                        objcmd.Parameters.AddWithValue("@ProductValue", Math.Round(productvalue, 3).ToString());
                        objcmd.Parameters.AddWithValue("@Tax", txtTax.Text);
                        objcmd.Parameters.AddWithValue("@EffTax", txtEffectiveTax.Text);
                        objcmd.Parameters.AddWithValue("@TaxAmt", Math.Round(taxAmt, 3).ToString());
                        objcmd.Parameters.AddWithValue("@TaxValue", Math.Round(taxVal, 3).ToString());
                        objcmd.Parameters.AddWithValue("@TotProductValue", txtTotProductValue.Text);
                        objcmd.Parameters.AddWithValue("@TotTaxvalue", txtTotTaxvalue.Text);

                        objcmd.Parameters.AddWithValue("@ValuePerProd", Math.Round(Convert.ToDecimal(((Convert.ToDecimal(Math.Round(productvalue, 3).ToString())) / (Convert.ToDecimal(txtQuantity.Text.ToString())))), 3));

                        Result objResult = objCF.ExecuteNewDMLQuery(objcmd);
                        if (objResult.bStatus)
                        {
                            BindOrderItem(Convert.ToInt32(lblIOMNumber.Text));
                            lbIOMID.Text = "0";
                        }

                    }

                    ItemGridview.ReadOnly = true;
                    ClearItemForm();
                    func_SumTotItemValue();
                    //resizedatagrid();
                }
                else
                {
                    //MessageBox.Show("Please Enter The PTD & Quantity ! ");
                }

            }



            catch (Exception ee)
            { }
        }

        //private void func_SumTotItemValue()
        //{
        //    try
        //    {
        //        decimal TotProductValue = 0;
        //        decimal TotTaxvalue = 0;
        //        foreach (DataGridViewRow frow in ItemGridview.Rows)
        //        {
        //            if (frow.DataBoundItem != null)
        //            {
        //                //txtTotProductValue.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtTotProductValue.Text.ToString()) + productvalue,3));
        //                //txtTotTaxvalue.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtTotTaxvalue.Text.ToString()) + Convert.ToDecimal(taxVal),3));
        //                //txtTotProductValue.Text = Convert.ToString(Convert.ToDecimal(txtTotProductValue.Text.ToString()) + Convert.ToDecimal(frow.Cells["Product Value"].Value.ToString()));
        //                //txtTotTaxvalue.Text = Convert.ToString(Convert.ToDecimal(txtTotTaxvalue.Text.ToString()) + Convert.ToDecimal(frow.Cells["Tax Value"].Value.ToString()));
        //                TotProductValue = TotProductValue + Convert.ToDecimal(frow.Cells["Product Value"].Value.ToString());
        //                TotTaxvalue = TotTaxvalue + Convert.ToDecimal(frow.Cells["Tax Value"].Value.ToString());
        //            }
        //        }
        //        txtTotProductValue.Text = TotProductValue.ToString();
        //        txtTotTaxvalue.Text = TotTaxvalue.ToString();
        //    }
        //    catch
        //    {

        //    }
        //}

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
                        TotProductValue = TotProductValue + Convert.ToDecimal(frow.Cells["colProdValue"].Value.ToString());
                        TotTaxvalue = TotTaxvalue + Convert.ToDecimal(frow.Cells["colTaxValue"].Value.ToString());
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
                    int id = int.Parse(ItemGridview.Rows[e.RowIndex].Cells["colIOMID"].Value.ToString());
                    if (e.ColumnIndex == ItemGridview.Columns["colEdit"].Index)
                    {
                        cmbMaterialCode.SelectedValue = ItemGridview[ItemGridview.Columns["colProductId"].Index, e.RowIndex].Value.ToString();
                        lblMaterialCode.Text = ItemGridview[ItemGridview.Columns["colProductCode"].Index, e.RowIndex].Value.ToString();
                        lblAliscode.Text = ItemGridview[ItemGridview.Columns["colAlisCode"].Index, e.RowIndex].Value.ToString(); ;
                        txtMaterialName.Text = ItemGridview[ItemGridview.Columns["colProductName"].Index, e.RowIndex].Value.ToString();
                        txtInstRate.Text = ItemGridview[ItemGridview.Columns["colInstRate"].Index, e.RowIndex].Value.ToString();
                        txtQuantity.Text = ItemGridview[ItemGridview.Columns["colQuantity"].Index, e.RowIndex].Value.ToString();
                        //txtBillRate.Text = ItemGridview[ItemGridview.Columns["Bill Rate"].Index, e.RowIndex].Value.ToString();
                        txtCommision.Text = ItemGridview[ItemGridview.Columns["colCommision"].Index, e.RowIndex].Value.ToString();
                        //txtMRP.Text = ItemGridview[ItemGridview.Columns["MRP"].Index, e.RowIndex].Value.ToString();
                        txtTax.Text = ItemGridview[ItemGridview.Columns["colTax"].Index, e.RowIndex].Value.ToString();
                        //txtTaxValue.Text = ItemGridview[ItemGridview.Columns["Tax Value"].Index, e.RowIndex].Value.ToString();
                        txtEffectiveTax.Text = ItemGridview[ItemGridview.Columns["colEffTax"].Index, e.RowIndex].Value.ToString();
                        lbIOMID.Text = ItemGridview[ItemGridview.Columns["colIOMID"].Index, e.RowIndex].Value.ToString();

                        //txtTotProductValue.Text = Convert.ToString(Convert.ToDecimal(txtTotProductValue.Text.ToString()) - Convert.ToDecimal(ItemGridview[ItemGridview.Columns["colProdValue"].Index, e.RowIndex].Value.ToString()));
                        //txtTotTaxvalue.Text = Convert.ToString(Convert.ToDecimal(txtTotTaxvalue.Text.ToString()) - Convert.ToDecimal(ItemGridview[ItemGridview.Columns["colTaxValue"].Index, e.RowIndex].Value.ToString()));
                        //func_SumTotItemValue();

                        foreach(DataGridViewRow row in ItemGridview.SelectedRows)
                        {
                            ItemGridview.Rows.Remove(row);
                        }

                        func_SumTotItemValue();

                    }
                    else if (e.ColumnIndex == ItemGridview.Columns["colDelete"].Index)
                    {
                        var result = MessageBox.Show("Do you want delete this Item", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            //if (ItemGridview.SelectedRows.Count == ItemGridview.RowCount)
                            //{
                            //    ItemGridview.Rows.Clear();
                            //}
                            //foreach (DataGridViewRow row in ItemGridview.SelectedRows)
                            //{
                            //    ItemGridview.Rows.Remove(row);
                            //}
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("delete OrderItem where IOMID='" + id + "'");
                            if (res.bStatus)
                            {
                                MessageBox.Show("Record Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Record not deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            
                            BindOrderItem(Convert.ToInt32(lblIOMNumber.Text));
                            func_SumTotItemValue();
                        }
                    }
                    else if (e.ColumnIndex == ItemGridview.Columns["colCloseItem"].Index)
                    {
                        //ItemGridview.EndEdit();  //Stop editing of cell.
                        if ((bool)ItemGridview.Rows[e.RowIndex].Cells["colCloseItem"].Value == false)
                        {
                            var result = MessageBox.Show("Are you sure close this Item", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                objC = new CommonFunction();
                                Result res = objC.ExecuteDMLQuery("update OrderItem set CloseItem = 1 where IOMID='" + id + "'");
                                if (res.bStatus)
                                {
                                    //MessageBox.Show("Item Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    BindOrderItem(Convert.ToInt32(lblIOMNumber.Text));
                                }
                                else
                                {
                                    MessageBox.Show("Item not closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else if ((bool)ItemGridview.Rows[e.RowIndex].Cells["colCloseItem"].Value == true)
                        {
                            //MessageBox.Show("UnChecked", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            objC = new CommonFunction();
                            Result res = objC.ExecuteDMLQuery("update OrderItem set CloseItem = 0 where IOMID='" + id + "'");
                            if (res.bStatus)
                            {
                                //MessageBox.Show("Item Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindOrderItem(Convert.ToInt32(lblIOMNumber.Text));
                            }
                            else
                            {
                                MessageBox.Show("Item not Active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/EditOrder CellContentClick \n" + ex.ToString();
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
                    IOMID = int.Parse(dgvProdSchedule.Rows[e.RowIndex].Cells["cIOMID"].Value.ToString());
                    IOMNo = int.Parse(dgvProdSchedule.Rows[e.RowIndex].Cells["cIOMNo"].Value.ToString());

                    if (e.ColumnIndex == dgvProdSchedule.Columns["cSchedule"].Index)
                    {
                        lblProdCode.Text = dgvProdSchedule[dgvProdSchedule.Columns["cProductCode"].Index, e.RowIndex].Value.ToString();
                        //lblProdIOMNo.Text = dgvProdSchedule[dgvProdSchedule.Columns["colIOMNo"].Index, e.RowIndex].Value.ToString();
                        lblSchOrderID.Text = dgvProdSchedule[dgvProdSchedule.Columns["cIOMNo"].Index, e.RowIndex].Value.ToString();
                        lblOrderTotalQuantity.Text = dgvProdSchedule[dgvProdSchedule.Columns["cQuantity"].Index, e.RowIndex].Value.ToString();

                        //dgvOrderItemSchedule.DataSource = null;

                        ////dgvOrderItemSchedule.Columns.Add("colScheQuantity", "Quantity");
                        ////dgvOrderItemSchedule.Columns["colScheQuantity"].DataPropertyName = "OrderQuantity";
                        //dgvOrderItemSchedule.Columns[1].Name = "colScheQuantity";
                        //dgvOrderItemSchedule.Columns[1].HeaderText = "Quantity";
                        //dgvOrderItemSchedule.Columns[1].DataPropertyName = "OrderQuantity";


                        ////CalendarColumn col = new CalendarColumn();
                        ////dgvOrderItemSchedule.Columns.Add(col);
                        ////dgvOrderItemSchedule.Columns[2].Name = "deliveryDate";
                        ////dgvOrderItemSchedule.Columns[2].HeaderText = "Delivery Date";
                        ////dgvOrderItemSchedule.Columns[2].DataPropertyName = "DeliveryDate";

                        BindOrderItemSchedule(Convert.ToInt32(lblSchOrderID.Text), lblProdCode.Text);
                        lblOrderScheStatus.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/dgvProdSchedule_CellContentClick \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrderItemSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == dgvOrderItemSchedule.Columns["colDeletePS"].Index)
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

        private void btnUpdateOrderHeader_Click(object sender, EventArgs e)
        {
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

                        string query = string.Empty;
                        string dtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                        //string query = @"UPDATE OrderHeader set OrderType='" + cmbOrderType.SelectedValue + "', IOMNo='" + txtIOMNO.Text + "', IOMDate='" + dtpIOM.Text + "', InstPONo='" + txtPONo.Text + "', InstPODate='" + dtpPO.Text + "', OrderRecieveDate='" + dtpOrderRec.Text + "', PartyCode='" + lblPartyCode.Text + "', PartyName='" + txtpartyname.Text + "', LocationCode='" + txtLocationCode.Text + "', DispThrough='" + txtDispatchthru.Text + "',  Institution='" + cmbInstitution.SelectedValue.ToString() + "', SubInstitution='" + cmbSubInstitution.SelectedValue.ToString() + "', StampingID=" + int.Parse(ddlStamping.SelectedValue.ToString()) + ", LST_CST='" + ddlLSTCST.Text + "',  TaxIndicator='" + ddlTaxIndicator.SelectedValue.ToString() + "', TaxOn='" + txtTaxOn.Text + "', Schedule='" + ddlSchedule.SelectedValue.ToString() + "', MRP='" + ddlMRP.SelectedValue.ToString() + "', DSM_ZSM='" + cmbZSM.SelectedValue + "',Lisioner='" + txtLisioner.Text + "', Commission=" + comm + ", BillingAddress='" + txtBillingAddress.Text + "', DeliveryAddress='" + txtDeliveryAddress.Text + "', DocumentRequired='" + strDocument.ToString() + "', Remark='" + txtRemark.Text + "', LastModify=getdate() WHERE OrderHeaderId='" + lblOrderHeaderId.Text + "'";

                        if (dtFormat == "MM/dd/yyyy" || dtFormat == "M/d/yyyy")
                        {
                            query = @"UPDATE OrderHeader set IOMDate='" + DateTime.Parse(dtpIOM.Text, dateformat).ToString() + "', InstPONo='" + txtPONo.Text + "', InstPODate='" + DateTime.Parse(dtpPO.Text, dateformat).ToString() + "', OrderRecieveDate='" + DateTime.Parse(dtpOrderRec.Text, dateformat).ToString() + "', PartyCode='" + lblPartyCode.Text + "', PartyName='" + txtpartyname.Text + "', LocationCode='" + txtLocationCode.Text + "', DispThrough='" + cmbLocationMst.Text + "',  Institution='" + cmbInstitution.SelectedValue.ToString() + "', SubInstitution='" + cmbSubInstitution.SelectedValue.ToString() + "', StampingID=" + int.Parse(ddlStamping.SelectedValue.ToString()) + ", LST_CST='0',  TaxIndicator='" + ddlTaxIndicator.SelectedValue.ToString() + "', TaxOn='" + txtTaxOn.Text + "', Schedule='" + ddlSchedule.SelectedValue.ToString() + "', MRP='" + ddlMRP.SelectedValue.ToString() + "', DSM_ZSM='" + cmbZSM.Text + "',Lisioner='" + cmbLisioner.Text + "', BillingAddress='" + txtBillingAddress.Text + "', DeliveryAddress='" + txtDeliveryAddress.Text + "', OrderDeliveryDate='" + DateTime.Parse(dtpDelivery.Text, dateformat).ToString() + "', DocumentRequired='" + strDocument.ToString() + "', Remark='" + txtRemark.Text + "', ShelfLife='" + cmbShelflife.SelectedValue + "', DocFile1 = '" + txtUpload.Text + "' , LastModify=getdate(), LocalPlace = '" + txtLocalPlace.Text + "' WHERE OrderHeaderId=" + lblOrderHeaderId.Text;
                        }
                        else
                        {
                            query = @"UPDATE OrderHeader set IOMDate='" + DateTime.Parse(dtpIOM.Text).ToString(_dateformat) + "', InstPONo='" + txtPONo.Text + "', InstPODate='" + DateTime.Parse(dtpPO.Text).ToString(_dateformat) + "', OrderRecieveDate='" + DateTime.Parse(dtpOrderRec.Text).ToString(_dateformat) + "', PartyCode='" + lblPartyCode.Text + "', PartyName='" + txtpartyname.Text + "', LocationCode='" + txtLocationCode.Text + "', DispThrough='" + cmbLocationMst.Text + "',  Institution='" + cmbInstitution.SelectedValue.ToString() + "', SubInstitution='" + cmbSubInstitution.SelectedValue.ToString() + "', StampingID=" + int.Parse(ddlStamping.SelectedValue.ToString()) + ", LST_CST='0',  TaxIndicator='" + ddlTaxIndicator.SelectedValue.ToString() + "', TaxOn='" + txtTaxOn.Text + "', Schedule='" + ddlSchedule.SelectedValue.ToString() + "', MRP='" + ddlMRP.SelectedValue.ToString() + "', DSM_ZSM='" + cmbZSM.Text + "',Lisioner='" + cmbLisioner.Text + "', BillingAddress='" + txtBillingAddress.Text + "', DeliveryAddress='" + txtDeliveryAddress.Text + "', OrderDeliveryDate='" + DateTime.Parse(dtpDelivery.Text).ToString(_dateformat) + "', DocumentRequired='" + strDocument.ToString() + "', Remark='" + txtRemark.Text + "', ShelfLife='" + cmbShelflife.SelectedValue + "', DocFile1 = '" + txtUpload.Text + "' , LastModify=getdate(), LocalPlace = '" + txtLocalPlace.Text + "' WHERE OrderHeaderId=" + lblOrderHeaderId.Text;
                        }

                        Result objResult = objCF.ExecuteDMLQuery(query);
                        if (objResult.bStatus)
                        {
                            //tabControl1.TabPages.Add(tabPage3);
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            lblStatus.Text = "Order Header Updated Sucessfully";

                            lbIOMID.Text = objResult.iRecordId.ToString();
                            //lblOrderHeaderID.Text = objResult.iRecordId.ToString();

                            dataTable = objCF.GetDataTable("select Tax,EffectiveTaxRate from LocationMaster where LocationCode='" + txtLocationCode.Text + "'");

                            //txtTax.Text = dataTable.Rows[0]["Tax"].ToString();
                            txtEffectiveTax.Text = dataTable.Rows[0]["EffectiveTaxRate"].ToString();

                            lblIOMNumber.Text = txtIOMNO.Text;
                            //lblCommision.Text = comm.ToString();
                            //txtCommision.Text = comm.ToString();
                            lblTaxOn.Text = txtTaxOn.Text;
                            lblTaxincexc.Text = ddlTaxIndicator.SelectedValue.ToString();

                            if (ddlSchedule.SelectedValue.ToString() == "Yes")
                            {
                                tabControl1.TabPages.Add(tabPage2);
                                tabControl1.SelectTab(tabPage2);
                            }
                            else if (ddlSchedule.SelectedValue.ToString() == "No")
                            {
                                DeleteScheduledData();
                            }

                            //lblIOMNo.Text = "";
                            //lblOrderHeaderID.Text = "";

                            //txtTax.Text = "5.00";

                            //lblIOMNumber.Text = "12100000";
                            //lblCommision.Text = "10";
                            //txtCommision.Text = "10";
                            //lblTaxOn.Text = "Bill Rate";
                            //lblTaxincexc.Text = "Tax Include";

                            ClearForm();
                            tabControl1.SelectTab(tabPage2);
                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
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
                            //ClearForm();
                            //BindGridOrderheader();
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
        }

        private void DeleteScheduledData()
        {
            try
            {
                CommonFunction objCF = new CommonFunction();
                SqlCommand objcmd = new SqlCommand("Delete from ScheduleDetail where IOMNo=@IOMNo");
                objcmd.Parameters.AddWithValue("@IOMNo", txtIOMNO.Text);
                Result objResult = objCF.ExecuteNewDMLQuery(objcmd);

                //string query = "Delete from ScheduleDetail where IOMNo='" + lblIOMNumber.Text + "' and MaterialCode NOT IN (" + strMatCode + ")";
                //Result objResult = objCF.ExecuteDMLQuery(query);
                //if (objResult.bStatus)
                //{
                //    lblOrderScheStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                //    lblOrderScheStatus.Text = "Order Item Updated Sucessfully";
                //}
                //tabControl1.SelectTab(tabPage3);
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/btnUpdateItem_Click Submit \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            

            return isValid;
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

            //if (cmbZSM.Text != "")
            //{
            //    errOrderHeader.SetError(cmbZSM, "ZSM");
            //    isValid = false;
            //}

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

        public void ClearItemForm()
        {
            txtInstRate.Text = "";
            txtQuantity.Text = "";
            txtMaterialName.Text = "";
            txtCommision.Text = "";
            cmbMaterialCode.SelectedIndex = 0;
        }
        private void ClearForm()
        {
            //txtiomno.Text = "";
            dtpIOM.Text = DateTime.Now.ToString();
            cmbPartycode.SelectedIndex = 0;
            //txtParytCode.Text = "";
            ddlStamping.SelectedIndex = 0;
            txtpartyname.Text = "";
            //ddlLocation.SelectedIndex = 0;
            txtPONo.Text = "";
            dtpPO.Text = DateTime.Now.ToString();
            cmbInstitution.SelectedIndex = 0;
            cmbSubInstitution.SelectedIndex = 0;
            //cmbShelflife.SelectedIndex = 0;
            cmbOrderType.SelectedIndex = 0;
            txtBillingAddress.Text = "";
            txtDeliveryAddress.Text = "";
            chkdocumentlist.ClearSelected();
            cmbZSM.SelectedIndex = 0;
            cmbLocationMst.SelectedIndex = 0;
            txtLocationCode.Text = "";
            txtRemark.Text = "";
            //txtComm.Text = "";
            cmbLisioner.SelectedIndex = 0;
            ddlMRP.SelectedIndex = 0;
            ddlSchedule.SelectedIndex = 0;
            ddlTaxIndicator.SelectedIndex = 0;
            //ddlTaxOn.SelectedIndex = 0;
            txtTaxOn.Text = "";
            ddlLSTCST.DataSource = null;
            chkdocumentlist.ClearSelected();
            foreach (int i in chkdocumentlist.CheckedIndices)
            {
                chkdocumentlist.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = 0;
                int DelFlag = 0;
                int TotQuantity = 0;

                for (int j = 0; j < dgvOrderItemSchedule.Rows.Count - 1; j++)
                {
                    TotQuantity += int.Parse(dgvOrderItemSchedule.Rows[j].Cells["colScheQuantity"].Value.ToString());
                }

                if (TotQuantity == int.Parse(lblOrderTotalQuantity.Text))
                {
                    CommonFunction objCF = new CommonFunction();
                    SqlCommand objcmd = new SqlCommand("Delete from ScheduleDetail where IOMNo=@IOMNo and MaterialCode=@MaterialCode");
                    objcmd.Parameters.AddWithValue("@MaterialCode", lblProdCode.Text);
                    objcmd.Parameters.AddWithValue("@IOMNo", lblSchOrderID.Text);

                    Result objResult = objCF.ExecuteNewDMLQuery(objcmd);
                    if (objResult.bStatus)
                    {
                        DelFlag = 1;
                    }
                    for (int i = 0; i < dgvOrderItemSchedule.Rows.Count - 1; i++)
                    {

                        //objcmd = new SqlCommand("UPDATE ScheduleDetail SET IOMNo=@IOMNo, MaterialCode=@MaterialCode, OrderQuantity=@OrderQuantity, DeliveryDate=@DeliveryDate, LastModify=getdate() WHERE ScheduleID = '"++"'");
                        objcmd = new SqlCommand("INSERT INTO ScheduleDetail(IOMNo, MaterialCode, OrderQuantity, ScheduleDate, DeliveryDate, LastModify) VALUES (@IOMNo, @MaterialCode, @OrderQuantity, getdate(), @DeliveryDate, getdate()); SELECT @pk_new = @@IDENTITY");

                        objcmd.Parameters.AddWithValue("@MaterialCode", lblProdCode.Text);
                        objcmd.Parameters.AddWithValue("@IOMNo", lblSchOrderID.Text);
                        objcmd.Parameters.AddWithValue("@OrderQuantity", dgvOrderItemSchedule.Rows[i].Cells["colScheQuantity"].Value);
                        objcmd.Parameters.AddWithValue("@DeliveryDate", dgvOrderItemSchedule.Rows[i].Cells["deliveryDate"].Value);

                        SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                        spInsertedKey.Direction = ParameterDirection.Output;
                        objcmd.Parameters.Add(spInsertedKey);

                        Result objResult1 = objCF.InsertNewQuery(objcmd);
                        if (objResult1.bStatus)
                        {
                            flag = 1;
                        }
                    }
                    //MessageBox.Show("Order Item Inserted Sucessfully");
                    if (flag == 1 && (DelFlag == 1 || nullFlag == 1))
                    {
                        lblOrderScheStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                        lblOrderScheStatus.Text = "Order Schedule Item Updated Sucessfully";
                        //dgvOrderItemSchedule.DataSource = null;
                        lblProdCode.Text = "";
                        lblSchOrderID.Text = "";
                        //tabControl1.SelectTab(tabPage4);

                        if (MessageBox.Show("Order Schedule Item Updated Sucessfully") == DialogResult.OK)
                        {
                            //Orderdetail objOrder = new Orderdetail();
                            //objOrder.Close();
                            //this.Close();
                            frmOrder objOrder = (frmOrder)Application.OpenForms["frmOrder"];
                            objOrder.BindGridOrderheader();
                        }
                    }
                    else
                    {
                        lblOrderScheStatus.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                        lblOrderScheStatus.Text = "Order Item Not Updated Sucessfully (Error Occured)";
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
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strMatCode="";
                for (int j = 0; j < ItemGridview.Rows.Count - 1; j++)
                {
                    if (strMatCode != "")
                        strMatCode += " , ";
                    strMatCode += "'" + ItemGridview.Rows[j].Cells["colProductCode"].Value.ToString() + "'";
                }
                CommonFunction objCF = new CommonFunction();
                //SqlCommand objcmd = new SqlCommand("Delete from ScheduleDetail where IOMNo=@IOMNo and MaterialCode NOT IN (@MaterialCode)");
                //objcmd.Parameters.AddWithValue("@MaterialCode", strMatCode);
                //objcmd.Parameters.AddWithValue("@IOMNo", lblIOMNumber.Text);
                //Result objResult = objCF.ExecuteNewDMLQuery(objcmd);

                string query = "Delete from ScheduleDetail where IOMNo=" + lblIOMNumber.Text + " and MaterialCode NOT IN (" + strMatCode + ")";
                Result objResult = objCF.ExecuteDMLQuery(query);
                if (objResult.bStatus)
                {
                    lblOrderScheStatus.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
                    lblOrderScheStatus.Text = "Order Item Updated Sucessfully";

                    MessageBox.Show("Order Item Updated Successfully");
                   
                }
                MessageBox.Show("Order Item Updated Successfully");                   
                //tabControl1.SelectTab(tabPage3);
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/btnUpdateItem_Click Submit \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files (*.*)|*.*";     //"Audio File (*.mp3, *.wav)|*.mp3*;*.wav";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtUpload.Text = dlg.FileName;
                FileInfo str = new FileInfo(dlg.FileName);
                string strPath = System.Windows.Forms.Application.StartupPath + "//UploadFile//" + str.Name;
                if (!File.Exists(strPath))
                {
                    File.Copy(txtUpload.Text, strPath); //"D:\\WinSearch\\WinSearch" + F:\\gm_17_03_2012\\gm\\bin\\Release
                    txtUpload.Text = str.Name;
                    MessageBox.Show("File Upload Successfully", "Information Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var result = MessageBox.Show("Do you want Overwrite the existing file", "Delete Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        File.Copy(txtUpload.Text, strPath, true);
                        txtUpload.Text = str.Name;
                        MessageBox.Show("File Upload Successfully", "Information Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            frmOrder objOrder = (frmOrder)Application.OpenForms["frmOrder"];
            objOrder.BindGridOrderheader();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void lnkDocFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtInstRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void txtCommision_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaterialName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEffectiveTax_TextChanged(object sender, EventArgs e)
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

public class CalendarColumn : DataGridViewColumn
{
    public CalendarColumn() : base(new CalendarCell())
    {

    }

    public override DataGridViewCell CellTemplate
    {
        get
        {
            return base.CellTemplate;
        }
        set
        {
            // Ensure that the cell used for the template is a CalendarCell.
            if (value != null &&
                !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
            {
                throw new InvalidCastException("Must be a CalendarCell");
            }
            base.CellTemplate = value;
        }
    }
}

public class CalendarCell : DataGridViewTextBoxCell
{

    public CalendarCell()
        : base()
    {
        // Use the short date format.
        this.Style.Format = "d";
    }

    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
        try
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl ctl =
                DataGridView.EditingControl as CalendarEditingControl;
            // Use the default row value when Value property is null.

            if (this.Value == null)
            {
                ctl.Value = (DateTime)this.DefaultNewRowValue;
            }
            else
            {
                //(DateTime)cVal = this.Value;
                if (ctl.Value != null)
                {
                    ctl.Value = (DateTime)this.DefaultNewRowValue;
                    //ctl.Value = (DateTime)this.Value;
                }
                else
                {
                    ctl.Value = (DateTime)this.Value;
                }

            }
        }
        catch (Exception ex)
        {
            this.Value = (DateTime)this.DefaultNewRowValue;
        }
    }

    public override Type EditType
    {
        get
        {
            // Return the type of the editing control that CalendarCell uses.
            return typeof(CalendarEditingControl);
        }
    }

    public override Type ValueType
    {
        get
        {
            // Return the type of the value that CalendarCell contains.

            return typeof(DateTime);
        }
    }

    public override object DefaultNewRowValue
    {
        get
        {
            // Use the current date and time as the default value.
            return DateTime.Now;
        }
    }
}

class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
{
    DataGridView dataGridView;
    private bool valueChanged = false;
    int rowIndex;

    public CalendarEditingControl()
    {
        this.Format = DateTimePickerFormat.Short;
    }

    // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
    // property.
    public object EditingControlFormattedValue
    {
        get
        {
            return this.Value.ToShortDateString();
        }
        set
        {
            if (value is String)
            {
                try
                {
                    // This will throw an exception of the string is 
                    // null, empty, or not in the format of a date.
                    this.Value = DateTime.Parse((String)value);
                }
                catch
                {
                    // In the case of an exception, just use the 
                    // default value so we're not left with a null
                    // value.
                    this.Value = DateTime.Now;
                }
            }
        }
    }

    // Implements the 
    // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
    public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
    {
        return EditingControlFormattedValue;
    }

    // Implements the 
    // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
    public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
    {
        this.Font = dataGridViewCellStyle.Font;
        this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
        this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
    }

    // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
    // property.
    public int EditingControlRowIndex
    {
        get
        {
            return rowIndex;
        }
        set
        {
            rowIndex = value;
        }
    }

    // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
    // method.
    public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
    {
        // Let the DateTimePicker handle the keys listed.
        switch (key & Keys.KeyCode)
        {
            case Keys.Left:
            case Keys.Up:
            case Keys.Down:
            case Keys.Right:
            case Keys.Home:
            case Keys.End:
            case Keys.PageDown:
            case Keys.PageUp:
                return true;
            default:
                return !dataGridViewWantsInputKey;
        }
    }

    // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
    // method.
    public void PrepareEditingControlForEdit(bool selectAll)
    {
        // No preparation needs to be done.
    }

    // Implements the IDataGridViewEditingControl
    // .RepositionEditingControlOnValueChange property.
    public bool RepositionEditingControlOnValueChange
    {
        get
        {
            return false;
        }
    }

    // Implements the IDataGridViewEditingControl
    // .EditingControlDataGridView property.
    public DataGridView EditingControlDataGridView
    {
        get
        {
            return dataGridView;
        }
        set
        {
            dataGridView = value;
        }
    }

    // Implements the IDataGridViewEditingControl
    // .EditingControlValueChanged property.
    public bool EditingControlValueChanged
    {
        get
        {
            return valueChanged;
        }
        set
        {
            valueChanged = value;
        }
    }

    // Implements the IDataGridViewEditingControl
    // .EditingPanelCursor property.
    public Cursor EditingPanelCursor
    {
        get
        {
            return base.Cursor;
        }
    }

    protected override void OnValueChanged(EventArgs eventargs)
    {
        // Notify the DataGridView that the contents of the cell
        // have changed.
        valueChanged = true;
        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        base.OnValueChanged(eventargs);
    }
}