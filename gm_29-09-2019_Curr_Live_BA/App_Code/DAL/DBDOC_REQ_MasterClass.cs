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
    public class DBDOC_REQ_MasterClass
    {
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _strDateFormat = "MM/dd/yyyy";

        public DBDOC_REQ_MasterClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ResultClass fn_InsertDOC_REQ_Master(DOC_REQ_MasterClass objDOC_REQMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strInsertQueryBuilder = new StringBuilder();

                strInsertQueryBuilder.Append("INSERT INTO DOC_REQ_Master ");
                strInsertQueryBuilder.Append("(Name, IsActive, LastModify) ");
                strInsertQueryBuilder.Append("Values");
                strInsertQueryBuilder.Append("(@Name, @IsActive, getdate());SELECT @pk_new = @@IDENTITY");
                objCommand = new SqlCommand(strInsertQueryBuilder.ToString(), objConnection);

                objCommand.Parameters.AddWithValue("@Name", objDOC_REQMasterPassed.strName);
                objCommand.Parameters.AddWithValue("@IsActive", objDOC_REQMasterPassed.strIsActive);

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    objDOC_REQMasterPassed.iCode = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                    return new ResultClass(true, "DOC_REQ Master inserted successfully", objDOC_REQMasterPassed, objDOC_REQMasterPassed.iCode, null);
                }
                else
                {
                    return new ResultClass(false, "DSM_REQ Master not added", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_InsertDOC_REQ_Master, DBDOC_REQs_MasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_InsertDOC_REQ_Master, DBDOC_REQ_MasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_UpdateDOC_REQ_Master(DOC_REQ_MasterClass objDOC_REQMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strUpdateQueryBuilder = new StringBuilder();

                strUpdateQueryBuilder.Append("UPDATE DOC_REQ_Master ");
                strUpdateQueryBuilder.Append("SET Name = @Name,");
                strUpdateQueryBuilder.Append(" IsActive = @IsActive,");
                strUpdateQueryBuilder.Append(" LastModify = getdate() ");
                strUpdateQueryBuilder.Append(" WHERE Code = @Code");

                objCommand = new SqlCommand(strUpdateQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@Code", objDOC_REQMasterPassed.iCode);
                objCommand.Parameters.AddWithValue("@Name", objDOC_REQMasterPassed.strName);
                objCommand.Parameters.AddWithValue("@IsActive", objDOC_REQMasterPassed.strIsActive);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "DOC_REQ Master updated successfully", objDOC_REQMasterPassed, objDOC_REQMasterPassed.iCode, null);
                }
                else
                {
                    return new ResultClass(false, "DOC_REQ Master not updated", objDOC_REQMasterPassed, objDOC_REQMasterPassed.iCode, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_UpdateDOC_REQ_Master, DBDOC_REQ_MasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_UpdateDOC_REQ_Master, DBDOC_REQ_MasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetDOC_REQ_MasterList(DOC_REQ_MasterClass objDOC_REQMasterPassed)
        {
            DOC_REQ_MasterClass objDOC_REQ_Master = null;
            wwList<DOC_REQ_MasterClass> objDOC_REQ_MasterList = null;

            try
            {
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM DOC_REQ_Master", objConnection);
                objReader = objCommand.ExecuteReader();
                objDOC_REQ_MasterList = new wwList<DOC_REQ_MasterClass>();
                while (objReader.Read())
                {
                    objDOC_REQ_Master = new DOC_REQ_MasterClass();
                    objDOC_REQ_Master.iCode = int.Parse(objReader["Code"].ToString());
                    objDOC_REQ_Master.strName = objReader["Name"].ToString();
                    objDOC_REQ_Master.strIsActive = objReader["IsActive"].ToString();

                    objDOC_REQ_Master.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objDOC_REQ_MasterList.Add(objDOC_REQ_Master);
                }

                return new ResultClass(true, "DOC_REQ Master List", objDOC_REQ_MasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetDOC_REQ_MasterList, DBDOC_REQ_MasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetDOC_REQ_MasterList, DBDOC_REQ_MasterClass", null, 0, ex);
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

        public ResultClass fn_GetActiveDOC_REQ_MasterList(DOC_REQ_MasterClass objDOC_REQMasterPassed)
        {
            DOC_REQ_MasterClass objDOC_REQ_Master = null;
            wwList<DOC_REQ_MasterClass> objDOC_REQ_MasterList = null;

            try
            {
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM DOC_REQ_Master WHERE IsActive = 'Yes' ", objConnection);
                objReader = objCommand.ExecuteReader();
                objDOC_REQ_MasterList = new wwList<DOC_REQ_MasterClass>();
                while (objReader.Read())
                {
                    objDOC_REQ_Master = new DOC_REQ_MasterClass();
                    objDOC_REQ_Master.iCode = int.Parse(objReader["Code"].ToString());
                    objDOC_REQ_Master.strName = objReader["Name"].ToString();
                    objDOC_REQ_Master.strIsActive = objReader["IsActive"].ToString();

                    objDOC_REQ_Master.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objDOC_REQ_MasterList.Add(objDOC_REQ_Master);
                }

                return new ResultClass(true, "DOC_REQ Master List", objDOC_REQ_MasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetDOC_REQ_MasterList, DBDOC_REQ_MasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetDOC_REQ_MasterList, DBDOC_REQ_MasterClass", null, 0, ex);
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

        public ResultClass fn_GetDOC_REQ_MasterById(DOC_REQ_MasterClass objDOC_REQMasterPassed)
        {
            DOC_REQ_MasterClass objDOC_REQ_Master = null;
            wwList<DOC_REQ_MasterClass> objDOC_REQ_MasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM DOC_REQ_Master WHERE Code = @id", objConnection);
                objCommand.Parameters.AddWithValue("@id", objDOC_REQMasterPassed.iCode);
                objReader = objCommand.ExecuteReader();
                objDOC_REQ_MasterList = new wwList<DOC_REQ_MasterClass>();

                if (objReader.Read())
                {
                    objDOC_REQ_Master = new DOC_REQ_MasterClass();
                    objDOC_REQ_Master.iCode = int.Parse(objReader["Code"].ToString());
                    objDOC_REQ_Master.strName = objReader["Name"].ToString();
                    objDOC_REQ_Master.strIsActive = objReader["IsActive"].ToString();

                    objDOC_REQ_Master.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objDOC_REQ_MasterList.Add(objDOC_REQ_Master);

                    return new ResultClass(true, "DOC_REQ Master Present", objDOC_REQ_MasterList, int.Parse(objReader["Code"].ToString()), null);
                }

                return new ResultClass(false, "DOC_REQ Master not found", null, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetDOC_REQ_MasterById, DBDOC_REQ_MasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetDOC_REQ_MasterById, DBDOC_REQ_MasterClass", null, 0, ex);
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

        public ResultClass fn_DeleteDOC_REQ_Master(DOC_REQ_MasterClass objDOC_REQMasterPassed)
        {
            try
            {
                //new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);

                objConnection.Open();

                objCommand = new SqlCommand("UPDATE DOC_REQ_Master SET IsActive = 'No' WHERE Code = @id", objConnection);

                objCommand.Parameters.AddWithValue("@id", objDOC_REQMasterPassed.iCode);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "DOC_REQ Master deleted successfully", objDOC_REQMasterPassed, objDOC_REQMasterPassed.iCode, null);
                }
                else
                {
                    return new ResultClass(false, "DOC_REQ Master not deleted", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_DeleteDOC_REQ_Master, DBDOC_REQ_MasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_DeleteDOC_REQ_Master, DBDOC_REQ_MasterClass", null, 0, ex);
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
