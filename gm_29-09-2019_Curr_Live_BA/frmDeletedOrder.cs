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
    public partial class frmDeletedOrder : Form
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

        public frmDeletedOrder()
        {
            InitializeComponent();
        }

        private void frmDeletedOrder_Load(object sender, EventArgs e)
        {
            try
            {
                BindDeletedOrderheader();
                BindDistinctIOMNo();
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmOrder frmDeletedOrder_Load \n" + ex.ToString();
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

                dt = objCommon.GetDataTable("select distinct IOMNo, CONVERT(nvarchar(100), IOMNo) as IOMNumber from DeletedOrderHeader order by IOMNo desc");
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

        public void BindDeletedOrderheader()
        {
            try
            {
                this.btnFirst.Enabled = true;
                this.btnPrevious.Enabled = true;
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
                string strError = DateTime.Now.ToString() + "\n Main Page/BindDeletedOrderheader \n" + ex.ToString();
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

                objC = new CommonFunction();
                sqlDataAdapter = objC.GetSqlDataAdapter("SELECT TOP " + this.mintPageSize + " OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, (case when DeletedOrderHeader.SubInstitution is not null then (select Name from SubInstitutionMaster where DeletedOrderHeader.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution, MRP, Remark, DocFile1 from DeletedOrderHeader WHERE OrderHeaderId NOT IN (SELECT TOP " + intSkip + " OrderHeaderId FROM DeletedOrderHeader) order by OrderHeaderId desc ");
                //sqlDataAdapter = objC.GetSqlDataAdapter(@"select OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, SubInstitution, MRP, Remark, DocFile1 from OrderHeader order by OrderHeaderId desc");
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvDeletedOrderMaster.DataSource = bindingSource;

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
            Result objres = objC.ExecuteScalarCnt("SELECT Rows FROM SYSINDEXES WHERE Id = OBJECT_ID('DeletedOrderHeader') AND IndId < 2");

            return objres.iRecordId;
        }

        private void dgvDeletedOrderMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                if (e.RowIndex != -1)
                {
                    int Orderheaderid = int.Parse(dgvDeletedOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                    int ordIOMNo = int.Parse(dgvDeletedOrderMaster.Rows[e.RowIndex].Cells["colIOMNumber"].Value.ToString());
                    if (e.ColumnIndex == dgvDeletedOrderMaster.Columns["colView"].Index)
                    {
                        DeletedOrderDetail objOrderDetail = new DeletedOrderDetail(Orderheaderid, 1);
                        FormCollection fc = Application.OpenForms;

                        foreach (Form frm in fc)
                        {
                            if (frm.Name == "DeletedOrderDetail")
                            {
                                if (MessageBox.Show("Deleted Order Detail Form Already Open") == DialogResult.OK)
                                    frm.Activate();
                                return;
                            }
                        }

                        objOrderDetail.Show();

                    }
                    else if (e.ColumnIndex == dgvDeletedOrderMaster.Columns["colDocFile1"].Index)
                    {
                        //int Orderheaderid = int.Parse(dgvOrderMaster.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                        string FileName = dgvDeletedOrderMaster.Rows[e.RowIndex].Cells["colDocFile1"].Value.ToString();

                        string strPath = System.Windows.Forms.Application.StartupPath + "//UploadFile//" + FileName;
                        if (File.Exists(strPath))
                        {
                            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                            myProcess.StartInfo.FileName = "AcroRd32.exe";
                            myProcess.StartInfo.Arguments = " /n /A \"nameddest=nameddest\" " + strPath + "\"";
                            myProcess.Start();
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                StreamWriter swLog = File.AppendText(strLogFileName);
                string strError = DateTime.Now.ToString() + "\n Main Page/frmDeletedOrder dgvDeletedOrderMaster_CellContentClick \n" + ex.ToString();
                swLog.WriteLine(strError);
                swLog.WriteLine();
                swLog.Close();
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSubmitIOM_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlIOMNo.SelectedIndex > 0)
                {
                    objC = new CommonFunction();
                    sqlDataAdapter = objC.GetSqlDataAdapter(@"select OrderHeaderId, IOMNo, IOMDate, OrderAuthoDate, PartyCode, PartyName, InstPONo, InstPODate, OrderDeliveryDate, (case when DeletedOrderHeader.SubInstitution is not null then (select Name from SubInstitutionMaster where DeletedOrderHeader.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution, MRP, Remark, DocFile1 from DeletedOrderHeader where IOMNo = " + ddlIOMNo.Text + " order by OrderHeaderId desc");
                    dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable;
                    dgvDeletedOrderMaster.DataSource = bindingSource;
                }
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
            BindDeletedOrderheader();
        }


    }
}
