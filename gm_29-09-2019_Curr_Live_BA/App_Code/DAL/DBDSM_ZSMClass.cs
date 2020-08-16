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
    public class DBDSM_ZSMClass
    {
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _strDateFormat = "MM/dd/yyyy";

        public DBDSM_ZSMClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ResultClass fn_InsertDSM_ZSM(DSM_ZSMClass objDSM_ZSMPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strInsertQueryBuilder = new StringBuilder();

                strInsertQueryBuilder.Append("INSERT INTO DSM_ZSM ");
                strInsertQueryBuilder.Append("(Code, Name, IsActive, LastModify) ");
                strInsertQueryBuilder.Append("Values");
                strInsertQueryBuilder.Append("(@Code, @Name, @IsActive, getdate());SELECT @pk_new = @@IDENTITY");
                objCommand = new SqlCommand(strInsertQueryBuilder.ToString(), objConnection);

                objCommand.Parameters.AddWithValue("@Code", objDSM_ZSMPassed.strCode);
                objCommand.Parameters.AddWithValue("@Name", objDSM_ZSMPassed.strName);
                objCommand.Parameters.AddWithValue("@IsActive", objDSM_ZSMPassed.strIsActive);

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    objDSM_ZSMPassed.iId = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                    return new ResultClass(true, "DSM_ZSM inserted successfully", objDSM_ZSMPassed, objDSM_ZSMPassed.iId, null);
                }
                else
                {
                    return new ResultClass(false, "DSM_ZSM not added", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_InsertDSM_ZSM, DBDSM_ZSMClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_InsertDSM_ZSM, DBDSM_ZSMClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_UpdateDSM_ZSM(DSM_ZSMClass objDSM_ZSMPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strUpdateQueryBuilder = new StringBuilder();

                strUpdateQueryBuilder.Append("UPDATE DSM_ZSM ");
                strUpdateQueryBuilder.Append("SET Code = @Code,");
                strUpdateQueryBuilder.Append(" Name = @Name,");
                strUpdateQueryBuilder.Append(" IsActive = @IsActive,");
                strUpdateQueryBuilder.Append(" LastModify = getdate() ");
                strUpdateQueryBuilder.Append(" WHERE Id = @Id");

                objCommand = new SqlCommand(strUpdateQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@Id", objDSM_ZSMPassed.iId);
                objCommand.Parameters.AddWithValue("@Code", objDSM_ZSMPassed.strCode);
                objCommand.Parameters.AddWithValue("@Name", objDSM_ZSMPassed.strName);
                objCommand.Parameters.AddWithValue("@IsActive", objDSM_ZSMPassed.strIsActive);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "DSM_ZSM updated successfully", objDSM_ZSMPassed, objDSM_ZSMPassed.iId, null);
                }
                else
                {
                    return new ResultClass(false, "DSM_ZSM not updated", objDSM_ZSMPassed, objDSM_ZSMPassed.iId, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_UpdateDSM_ZSM, DBDSM_ZSMClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_UpdateDSM_ZSM, DBDSM_ZSMClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetDSM_ZSMList(DSM_ZSMClass objDSM_ZSMPassed)
        {
            DSM_ZSMClass objDSM_ZSM = null;
            wwList<DSM_ZSMClass> objDSM_ZSMList = null;

            try
            {
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM DSM_ZSM", objConnection);
                objReader = objCommand.ExecuteReader();
                objDSM_ZSMList = new wwList<DSM_ZSMClass>();
                while (objReader.Read())
                {
                    objDSM_ZSM = new DSM_ZSMClass();
                    objDSM_ZSM.iId = int.Parse(objReader["Id"].ToString());
                    objDSM_ZSM.strCode = objReader["Code"].ToString();
                    objDSM_ZSM.strName = objReader["Name"].ToString();
                    objDSM_ZSM.strIsActive = objReader["IsActive"].ToString();

                    objDSM_ZSM.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objDSM_ZSMList.Add(objDSM_ZSM);
                }

                return new ResultClass(true, "DSM_ZSM List", objDSM_ZSMList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetDSM_ZSMList, DBDSM_ZSMClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetDSM_ZSMList, DBDSM_ZSMClass", null, 0, ex);
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

        public ResultClass fn_GetDSM_ZSMById(DSM_ZSMClass objDSM_ZSMPassed)
        {
            DSM_ZSMClass objDSM_ZSM = null;
            wwList<DSM_ZSMClass> objDSM_ZSMList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM DSM_ZSM WHERE Id = @id", objConnection);
                objCommand.Parameters.AddWithValue("@id", objDSM_ZSMPassed.iId);
                objReader = objCommand.ExecuteReader();
                objDSM_ZSMList = new wwList<DSM_ZSMClass>();

                if (objReader.Read())
                {
                    objDSM_ZSM = new DSM_ZSMClass();
                    objDSM_ZSM.iId = int.Parse(objReader["Id"].ToString());
                    objDSM_ZSM.strCode = objReader["Code"].ToString();
                    objDSM_ZSM.strName = objReader["Name"].ToString();
                    objDSM_ZSM.strIsActive = objReader["IsActive"].ToString();

                    objDSM_ZSM.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objDSM_ZSMList.Add(objDSM_ZSM);

                    return new ResultClass(true, "DSM_ZSM Present", objDSM_ZSMList, int.Parse(objReader["Id"].ToString()), null);
                }

                return new ResultClass(false, "DSM_ZSM not found", null, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetDSM_ZSMById, DBDSM_ZSMClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetDSM_ZSMById, DBDSM_ZSMClass", null, 0, ex);
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

        public ResultClass fn_GetActiveDSM_ZSMList(DSM_ZSMClass objDSM_ZSMPassed)
        {
            DSM_ZSMClass objDSM_ZSM = null;
            wwList<DSM_ZSMClass> objDSM_ZSMList = null;

            try
            {
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM DSM_ZSM WHERE IsActive = 'Yes' ", objConnection);
                objReader = objCommand.ExecuteReader();
                objDSM_ZSMList = new wwList<DSM_ZSMClass>();
                while (objReader.Read())
                {
                    objDSM_ZSM = new DSM_ZSMClass();
                    objDSM_ZSM.iId = int.Parse(objReader["Id"].ToString());
                    objDSM_ZSM.strCode = objReader["Code"].ToString();
                    objDSM_ZSM.strName = objReader["Name"].ToString();
                    objDSM_ZSM.strIsActive = objReader["IsActive"].ToString();

                    objDSM_ZSM.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objDSM_ZSMList.Add(objDSM_ZSM);
                }

                return new ResultClass(true, "DSM_ZSM List", objDSM_ZSMList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetDSM_ZSMList, DBDSM_ZSMClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetDSM_ZSMList, DBDSM_ZSMClass", null, 0, ex);
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

        public ResultClass fn_DeleteDSM_ZSM(DSM_ZSMClass objDSM_ZSMPassed)
        {
            try
            {
                //new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);

                objConnection.Open();

                objCommand = new SqlCommand("UPDATE DSM_ZSM SET IsActive = 'No' WHERE Id = @id", objConnection);

                objCommand.Parameters.AddWithValue("@id", objDSM_ZSMPassed.iId);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "DSM_ZSM deleted successfully", objDSM_ZSMPassed, objDSM_ZSMPassed.iId, null);
                }
                else
                {
                    return new ResultClass(false, "DSM_ZSM not deleted", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_DeleteDSM_ZSM, DBDSM_ZSMClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_DeleteDSM_ZSM, DBDSM_ZSMClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }



    }
}
