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
    public class DBInstitutionMasterClass
    {
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _strDateFormat = "MM/dd/yyyy";

        public DBInstitutionMasterClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ResultClass fn_InsertInstitutionMaster(InstitutionMasterClass objInstitutionMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strInsertQueryBuilder = new StringBuilder();

                strInsertQueryBuilder.Append("INSERT INTO InstitutionMaster ");
                strInsertQueryBuilder.Append("(Name, IsActive, LastModify) ");
                strInsertQueryBuilder.Append("Values");
                strInsertQueryBuilder.Append("(@Name, @IsActive, getdate());SELECT @pk_new = @@IDENTITY");
                objCommand = new SqlCommand(strInsertQueryBuilder.ToString(), objConnection);

                objCommand.Parameters.AddWithValue("@Name", objInstitutionMasterPassed.strName);
                objCommand.Parameters.AddWithValue("@IsActive", objInstitutionMasterPassed.strIsActive);

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    objInstitutionMasterPassed.iCode = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                    return new ResultClass(true, "Institution Master inserted successfully", objInstitutionMasterPassed, objInstitutionMasterPassed.iCode, null);
                }
                else
                {
                    return new ResultClass(false, "Institution Master not added", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_InsertInstitutionMaster, DBInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_InsertInstitutionMaster, DBInstitutionMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_UpdateInstitutionMaster(InstitutionMasterClass objInstitutionMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strUpdateQueryBuilder = new StringBuilder();

                strUpdateQueryBuilder.Append("UPDATE InstitutionMaster ");
                strUpdateQueryBuilder.Append("SET Name = @Name,");
                strUpdateQueryBuilder.Append(" IsActive = @IsActive,");
                strUpdateQueryBuilder.Append(" LastModify = getdate() ");
                strUpdateQueryBuilder.Append(" WHERE Code = @Code");

                objCommand = new SqlCommand(strUpdateQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@Code", objInstitutionMasterPassed.iCode);
                objCommand.Parameters.AddWithValue("@Name", objInstitutionMasterPassed.strName);
                objCommand.Parameters.AddWithValue("@IsActive", objInstitutionMasterPassed.strIsActive);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Institution Master updated successfully", objInstitutionMasterPassed, objInstitutionMasterPassed.iCode, null);
                }
                else
                {
                    return new ResultClass(false, "Institution Master not updated", objInstitutionMasterPassed, objInstitutionMasterPassed.iCode, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_UpdateInstitutionMaster, DBInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_UpdateInstitutionMaster, DBInstitutionMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetInstitutionMasterList(InstitutionMasterClass objInstitutionMasterPassed)
        {
            InstitutionMasterClass objInstitutionMaster = null;
            wwList<InstitutionMasterClass> objInstitutionMasterList = null;

            try
            {
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM InstitutionMaster", objConnection);
                objReader = objCommand.ExecuteReader();
                objInstitutionMasterList = new wwList<InstitutionMasterClass>();
                while (objReader.Read())
                {
                    objInstitutionMaster = new InstitutionMasterClass();
                    objInstitutionMaster.iCode = int.Parse(objReader["Code"].ToString());
                    objInstitutionMaster.strName = objReader["Name"].ToString();
                    objInstitutionMaster.strIsActive = objReader["IsActive"].ToString();

                    objInstitutionMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objInstitutionMasterList.Add(objInstitutionMaster);
                }

                return new ResultClass(true, "Institution Master List", objInstitutionMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetInstitutionMasterList, DBInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetInstitutionMasterList, DBInstitutionMasterClass", null, 0, ex);
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

        public ResultClass fn_GetActiveInstitutionMasterList(InstitutionMasterClass objInstitutionMasterPassed)
        {
            InstitutionMasterClass objInstitutionMaster = null;
            wwList<InstitutionMasterClass> objInstitutionMasterList = null;

            try
            {
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM InstitutionMaster WHERE IsActive = 'Yes'", objConnection);
                objReader = objCommand.ExecuteReader();
                objInstitutionMasterList = new wwList<InstitutionMasterClass>();
                while (objReader.Read())
                {
                    objInstitutionMaster = new InstitutionMasterClass();
                    objInstitutionMaster.iCode = int.Parse(objReader["Code"].ToString());
                    objInstitutionMaster.strName = objReader["Name"].ToString();
                    objInstitutionMaster.strIsActive = objReader["IsActive"].ToString();

                    objInstitutionMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objInstitutionMasterList.Add(objInstitutionMaster);
                }

                return new ResultClass(true, "Institution Master List", objInstitutionMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetActiveInstitutionMasterList, DBInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetActiveInstitutionMasterList, DBInstitutionMasterClass", null, 0, ex);
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

        public ResultClass fn_GetInstitutionMasterById(InstitutionMasterClass objInstitutionMasterPassed)
        {
            InstitutionMasterClass objInstitutionMaster = null;
            wwList<InstitutionMasterClass> objInstitutionMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM InstitutionMaster WHERE Code = @id", objConnection);
                objCommand.Parameters.AddWithValue("@id", objInstitutionMasterPassed.iCode);
                objReader = objCommand.ExecuteReader();
                objInstitutionMasterList = new wwList<InstitutionMasterClass>();

                if (objReader.Read())
                {
                    objInstitutionMaster = new InstitutionMasterClass();
                    objInstitutionMaster.iCode = int.Parse(objReader["Code"].ToString());
                    objInstitutionMaster.strName = objReader["Name"].ToString();
                    objInstitutionMaster.strIsActive = objReader["IsActive"].ToString();

                    objInstitutionMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objInstitutionMasterList.Add(objInstitutionMaster);

                    return new ResultClass(true, "Institution Master Present", objInstitutionMasterList, int.Parse(objReader["Code"].ToString()), null);
                }

                return new ResultClass(false, "Institution Master not found", null, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetInstitutionMasterById, DBInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetInstitutionMasterById, DBInstitutionMasterClass", null, 0, ex);
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

        public ResultClass fn_DeleteInstitutionMaster(InstitutionMasterClass objInstitutionMasterPassed)
        {
            try
            {
                //new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);

                objConnection.Open();

                objCommand = new SqlCommand("UPDATE InstitutionMaster SET IsActive = 'No' WHERE Code = @id", objConnection);

                objCommand.Parameters.AddWithValue("@id", objInstitutionMasterPassed.iCode);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Institution Master deleted successfully", objInstitutionMasterPassed, objInstitutionMasterPassed.iCode, null);
                }
                else
                {
                    return new ResultClass(false, "Institution Master not deleted", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_DeleteInstitutionMaster, DBInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_DeleteInstitutionMaster, DBInstitutionMasterClass", null, 0, ex);
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
