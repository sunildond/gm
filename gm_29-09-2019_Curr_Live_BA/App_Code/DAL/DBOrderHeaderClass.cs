using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ww_lib;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;

namespace ww_admin
{
    public class DBOrderHeaderClass
    {
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _strDateFormat = "MM/dd/yyyy";

        public DBOrderHeaderClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ResultClass fn_InsertOrderHeader(OrderHeaderClass objOrderHeaderPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strInsertQueryBuilder = new StringBuilder();

                strInsertQueryBuilder.Append("INSERT INTO OrderHeader ");
                strInsertQueryBuilder.Append("(IOMDate, OrderAuthoDate, PartyCode, PartyName, DSM_ZSM, DispThrough, InstPONo, InstPODate, ReqDelDate, Staggered_Immediate, StagDueOn, Institution, SubInstitution, LastModify) ");
                strInsertQueryBuilder.Append("Values");
                strInsertQueryBuilder.Append("(@IOMDate, @OrderAuthoDate, @PartyCode, @PartyName, @DSM_ZSM, @DispThrough, @InstPONo, @InstPODate, @ReqDelDate, @Staggered_Immediate, @StagDueOn, @Institution, @SubInstitution, getdate());SELECT @pk_new = @@IDENTITY");
                objCommand = new SqlCommand(strInsertQueryBuilder.ToString(), objConnection);

                objCommand.Parameters.AddWithValue("@IOMDate", objOrderHeaderPassed.dtIOMDate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@OrderAuthoDate", objOrderHeaderPassed.dtOrderAuthoDate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@PartyCode", objOrderHeaderPassed.strPartyCode);
                objCommand.Parameters.AddWithValue("@PartyName", objOrderHeaderPassed.strPartyName);
                objCommand.Parameters.AddWithValue("@DSM_ZSM", objOrderHeaderPassed.strDSM_ZSM);
                objCommand.Parameters.AddWithValue("@DispThrough", objOrderHeaderPassed.strDispThrough);
                objCommand.Parameters.AddWithValue("@InstPONo", objOrderHeaderPassed.strInstPONo);
                objCommand.Parameters.AddWithValue("@InstPODate", objOrderHeaderPassed.dtInstPODate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@ReqDelDate", objOrderHeaderPassed.dtReqDelDate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@Staggered_Immediate", objOrderHeaderPassed.strStaggered_Immediate);
                objCommand.Parameters.AddWithValue("@StagDueOn", objOrderHeaderPassed.strStagDueOn);
                objCommand.Parameters.AddWithValue("@Institution", objOrderHeaderPassed.strInstitution);
                objCommand.Parameters.AddWithValue("@SubInstitution", objOrderHeaderPassed.strSubInstitution);

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    objOrderHeaderPassed.iIOMNo = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                    return new ResultClass(true, "Order Header inserted successfully", objOrderHeaderPassed, objOrderHeaderPassed.iIOMNo, null);
                }
                else
                {
                    return new ResultClass(false, "Order Header not added", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_InsertOrderHeader, DBOrderHeaderClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_InsertOrderHeader, DBOrderHeaderClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_UpdateOrderHeader(OrderHeaderClass objOrderHeaderPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strUpdateQueryBuilder = new StringBuilder();

                strUpdateQueryBuilder.Append("UPDATE OrderHeader ");
                strUpdateQueryBuilder.Append("SET IOMDate = @IOMDate,");
                strUpdateQueryBuilder.Append(" OrderAuthoDate = @OrderAuthoDate,");
                strUpdateQueryBuilder.Append(" PartyCode = @PartyCode,");
                strUpdateQueryBuilder.Append(" PartyName = @PartyName,");
                strUpdateQueryBuilder.Append(" DSM_ZSM = @DSM_ZSM,");
                strUpdateQueryBuilder.Append(" DispThrough = @DispThrough,");
                strUpdateQueryBuilder.Append(" InstPONo = @InstPONo,");
                strUpdateQueryBuilder.Append(" InstPODate = @InstPODate,");
                strUpdateQueryBuilder.Append(" ReqDelDate = @ReqDelDate,");
                strUpdateQueryBuilder.Append(" Staggered_Immediate = @Staggered_Immediate,");
                strUpdateQueryBuilder.Append(" StagDueOn = @StagDueOn,");
                strUpdateQueryBuilder.Append(" Institution = @Institution,");
                strUpdateQueryBuilder.Append(" SubInstitution = @SubInstitution,");
                strUpdateQueryBuilder.Append(" LastModify = getdate() ");
                strUpdateQueryBuilder.Append(" WHERE IOMNo = @IOMNo");

                objCommand = new SqlCommand(strUpdateQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@IOMNo", objOrderHeaderPassed.iIOMNo);
                objCommand.Parameters.AddWithValue("@IOMDate", objOrderHeaderPassed.dtIOMDate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@OrderAuthoDate", objOrderHeaderPassed.dtOrderAuthoDate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@PartyCode", objOrderHeaderPassed.strPartyCode);
                objCommand.Parameters.AddWithValue("@PartyName", objOrderHeaderPassed.strPartyName);
                objCommand.Parameters.AddWithValue("@DSM_ZSM", objOrderHeaderPassed.strDSM_ZSM);
                objCommand.Parameters.AddWithValue("@DispThrough", objOrderHeaderPassed.strDispThrough);
                objCommand.Parameters.AddWithValue("@InstPONo", objOrderHeaderPassed.strInstPONo);
                objCommand.Parameters.AddWithValue("@InstPODate", objOrderHeaderPassed.dtInstPODate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@ReqDelDate", objOrderHeaderPassed.dtReqDelDate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@Staggered_Immediate", objOrderHeaderPassed.strStaggered_Immediate);
                objCommand.Parameters.AddWithValue("@StagDueOn", objOrderHeaderPassed.strStagDueOn);
                objCommand.Parameters.AddWithValue("@Institution", objOrderHeaderPassed.strInstitution);
                objCommand.Parameters.AddWithValue("@SubInstitution", objOrderHeaderPassed.strSubInstitution);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Order Header updated successfully", objOrderHeaderPassed, objOrderHeaderPassed.iIOMNo, null);
                }
                else
                {
                    return new ResultClass(false, "Order Header not updated", objOrderHeaderPassed, objOrderHeaderPassed.iIOMNo, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_UpdateOrderHeader, DBOrderHeaderClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_UpdateOrderHeader, DBOrderHeaderClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetOrderHeaderList(OrderHeaderClass objOrderHeaderPassed)
        {
            OrderHeaderClass objOrderHeader = null;
            wwList<OrderHeaderClass> objOrderHeaderList = null;

            try
            {

                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM OrderHeader", objConnection);
                objReader = objCommand.ExecuteReader();
                objOrderHeaderList = new wwList<OrderHeaderClass>();
                while (objReader.Read())
                {
                    objOrderHeader = new OrderHeaderClass();
                    objOrderHeader.iIOMNo = int.Parse(objReader["IOMNo"].ToString());
                    objOrderHeader.dtIOMDate = Convert.ToDateTime(objReader["IOMDate"].ToString());
                    objOrderHeader.dtOrderAuthoDate = Convert.ToDateTime(objReader["OrderAuthoDate"].ToString());
                    objOrderHeader.strPartyCode = objReader["PartyCode"].ToString();
                    objOrderHeader.strPartyName = objReader["PartyName"].ToString();
                    objOrderHeader.strDSM_ZSM = objReader["DSM_ZSM"].ToString();
                    objOrderHeader.strDispThrough = objReader["DispThrough"].ToString();
                    objOrderHeader.strInstPONo = objReader["InstPONo"].ToString();
                    objOrderHeader.dtInstPODate = Convert.ToDateTime(objReader["InstPODate"].ToString());
                    objOrderHeader.dtReqDelDate = Convert.ToDateTime(objReader["ReqDelDate"].ToString());
                    objOrderHeader.strStaggered_Immediate = objReader["Staggered_Immediate"].ToString();
                    objOrderHeader.strStagDueOn = objReader["StagDueOn"].ToString();
                    objOrderHeader.strInstitution = objReader["Institution"].ToString();
                    objOrderHeader.strSubInstitution = objReader["SubInstitution"].ToString();

                    objOrderHeader.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objOrderHeaderList.Add(objOrderHeader);
                }

                return new ResultClass(true, "Order Header List", objOrderHeaderList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetOrderHeaderList, DBOrderHeaderClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetOrderHeaderList, DBOrderHeaderClass", null, 0, ex);
            }
            finally
            {
                if (objReader != null)
                {
                    objReader.Close();
                }
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetOrderHeaderById(OrderHeaderClass objOrderHeaderPassed)
        {
            OrderHeaderClass objOrderHeader = null;
            wwList<OrderHeaderClass> objOrderHeaderList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM OrderHeader WHERE IOMNo = @id", objConnection);
                objCommand.Parameters.AddWithValue("@id", objOrderHeaderPassed.iIOMNo);
                objReader = objCommand.ExecuteReader();
                objOrderHeaderList = new wwList<OrderHeaderClass>();

                if (objReader.Read())
                {
                    objOrderHeader = new OrderHeaderClass();
                    objOrderHeader.iIOMNo = int.Parse(objReader["IOMNo"].ToString());
                    objOrderHeader.dtIOMDate = Convert.ToDateTime(objReader["IOMDate"].ToString());
                    objOrderHeader.dtOrderAuthoDate = Convert.ToDateTime(objReader["OrderAuthoDate"].ToString());
                    objOrderHeader.strPartyCode = objReader["PartyCode"].ToString();
                    objOrderHeader.strPartyName = objReader["PartyName"].ToString();
                    objOrderHeader.strDSM_ZSM = objReader["DSM_ZSM"].ToString();
                    objOrderHeader.strDispThrough = objReader["DispThrough"].ToString();
                    objOrderHeader.strInstPONo = objReader["InstPONo"].ToString();
                    objOrderHeader.dtInstPODate = Convert.ToDateTime(objReader["InstPODate"].ToString());
                    objOrderHeader.dtReqDelDate = Convert.ToDateTime(objReader["ReqDelDate"].ToString());
                    objOrderHeader.strStaggered_Immediate = objReader["Staggered_Immediate"].ToString();
                    objOrderHeader.strStagDueOn = objReader["StagDueOn"].ToString();
                    objOrderHeader.strInstitution = objReader["Institution"].ToString();
                    objOrderHeader.strSubInstitution = objReader["SubInstitution"].ToString();

                    objOrderHeader.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objOrderHeaderList.Add(objOrderHeader);
                    return new ResultClass(true, "Order Header Present", objOrderHeaderList, int.Parse(objReader["IOMNo"].ToString()), null);
                }

                return new ResultClass(false, "Order Header not found", null, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetOrderHeaderById, DBOrderHeaderClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetOrderHeaderById, DBOrderHeaderClass", null, 0, ex);
            }
            finally
            {
                if (objReader != null)
                {
                    objReader.Close();
                }
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }


    }
}
