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
    public partial class frmUserPermission : Form
    {
        public frmUserPermission()
        {
            InitializeComponent();
        }

        public frmUserPermission(int UserId)
        {
            InitializeComponent();
            BindPermissionByUserId(UserId);
        }

        private void BindPermissionByUserId(int UserId)
        {
            try
            {
                DataTable dt = new DataTable();
                CommonFunction objCom = new CommonFunction();
                lblUserID.Text = UserId.ToString();
                Result objres = objCom.ExecuteReaderQuery("select * from UserModuleRelation where user_id=" + UserId);
                if (objres.bStatus)
                {
                    dt = objCom.GetDataTable("select ModuleMaster.module_id,ModuleMaster.module_name,ISNULL(permission,0) as permission,user_id from UserModuleRelation right join ModuleMaster on UserModuleRelation.module_id=ModuleMaster.module_id where user_id=" + UserId);
                }
                else
                {
                    dt = objCom.GetDataTable("select ModuleMaster.module_id,ModuleMaster.module_name,0 as permission, " + UserId + " as user_id from ModuleMaster ");
                }
                BindingSource bindingSrc = new BindingSource();
                bindingSrc.DataSource = dt;
                dgvModule.DataSource = dt;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBSessionUser.iUser_Id != -1)
                {
                    CommonFunction objCF = new CommonFunction();
                    SqlCommand objcmd = new SqlCommand("Delete from UserModuleRelation where user_id=@user_id");
                    objcmd.Parameters.AddWithValue("@user_id", lblUserID.Text);

                    Result objResult = objCF.ExecuteNewDMLQuery(objcmd);
                    if (objResult.bStatus)
                    {
                        //DelFlag = 1;
                    }
                    int iflag = 0, flag = 0;
                    foreach (DataGridViewRow row in dgvModule.Rows) //int i = 0; i < dgvModule.Rows.Count - 1; i++)
                    {
                        //////if (row.Cells["colPermission"].Value != null && Convert.ToBoolean(row.Cells["colPermission"].Value) == true)
                        //////{
                        iflag++;
                        objcmd = new SqlCommand("INSERT INTO UserModuleRelation(user_id, module_id, permission) VALUES (@user_id, @module_id, @permission); SELECT @pk_new = @@IDENTITY");

                        objcmd.Parameters.AddWithValue("@user_id", lblUserID.Text);
                        objcmd.Parameters.AddWithValue("@module_id", row.Cells["colId"].Value);
                        objcmd.Parameters.AddWithValue("@permission", row.Cells["colPermission"].Value);

                        SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                        spInsertedKey.Direction = ParameterDirection.Output;
                        objcmd.Parameters.Add(spInsertedKey);

                        Result objResult1 = objCF.InsertNewQuery(objcmd);
                        if (objResult1.bStatus)
                        {
                            flag++;
                        }
                        //////}
                    }
                    //MessageBox.Show("Order Item Inserted Sucessfully");
                    if (flag == iflag)
                    {
                        if (MessageBox.Show("Permission Updated Sucessfully") == DialogResult.OK)
                        {
                            //Orderdetail objOrder = new Orderdetail();
                            //objOrder.Close();
                            this.Close();
                            frmUserMaster objfrmUserMaster = (frmUserMaster)Application.OpenForms["frmUserMaster"];
                            objfrmUserMaster.bindGrid();
                        }
                    }
                    else
                    {
                        //lblmsg.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                        //lblmsg.Text = "Order Item Not Updated Sucessfully (Error Occured)";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                frmUserMaster objfrmUserMaster = (frmUserMaster)Application.OpenForms["frmUserMaster"];
                objfrmUserMaster.bindGrid();
            }
            catch (Exception ex)
            { }

        }

        private void dgvModule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.RowIndex != -1)
                //{
                //    int id = int.Parse(dgvModule.Rows[e.RowIndex].Cells["colId"].Value.ToString());
                //    if (e.ColumnIndex == dgvModule.Columns["colPermission"].Index)
                //    {
                //        if (dgvModule.Rows[e.RowIndex].Cells["colPermission"].Value == true)
                //        { 

                //        }
                //    }
                //}
            }
            catch (Exception ex)
            { }
        }
    }
}
