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
    public class DBSubInstitutionMasterClass
    {
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _strDateFormat = "MM/dd/yyyy";

        public DBSubInstitutionMasterClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ResultClass fn_InsertSubInstitutionMaster(SubInstitutionMasterClass objSubInstitutionMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strInsertQueryBuilder = new StringBuilder();

                strInsertQueryBuilder.Append("INSERT INTO SubInstitutionMaster ");
                strInsertQueryBuilder.Append("(Name, IsActive, LastModify) ");
                strInsertQueryBuilder.Append("Values");
                strInsertQueryBuilder.Append("(@Name, @IsActive, getdate());SELECT @pk_new = @@IDENTITY");
                objCommand = new SqlCommand(strInsertQueryBuilder.ToString(), objConnection);

                objCommand.Parameters.AddWithValue("@Name", objSubInstitutionMasterPassed.strName);
                objCommand.Parameters.AddWithValue("@IsActive", objSubInstitutionMasterPassed.strIsActive);

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    objSubInstitutionMasterPassed.iCode = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                    return new ResultClass(true, "SubInstitution Master inserted successfully", objSubInstitutionMasterPassed, objSubInstitutionMasterPassed.iCode, null);
                }
                else
                {
                    return new ResultClass(false, "SubInstitution Master not added", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_InsertSubInstitutionMaster, DBSubInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_InsertSubInstitutionMaster, DBSubInstitutionMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_UpdateSubInstitutionMaster(SubInstitutionMasterClass objSubInstitutionMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strUpdateQueryBuilder = new StringBuilder();

                strUpdateQueryBuilder.Append("UPDATE SubInstitutionMaster ");
                strUpdateQueryBuilder.Append("SET Name = @Name,");
                strUpdateQueryBuilder.Append(" IsActive = @IsActive,");
                strUpdateQueryBuilder.Append(" LastModify = getdate() ");
                strUpdateQueryBuilder.Append(" WHERE Code = @Code");

                objCommand = new SqlCommand(strUpdateQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@Code", objSubInstitutionMasterPassed.iCode);
                objCommand.Parameters.AddWithValue("@Name", objSubInstitutionMasterPassed.strName);
                objCommand.Parameters.AddWithValue("@IsActive", objSubInstitutionMasterPassed.strIsActive);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "SubInstitution Master updated successfully", objSubInstitutionMasterPassed, objSubInstitutionMasterPassed.iCode, null);
                }
                else
                {
                    return new ResultClass(false, "SubInstitution Master not updated", objSubInstitutionMasterPassed, objSubInstitutionMasterPassed.iCode, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_UpdateSubInstitutionMaster, DBSubInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_UpdateSubInstitutionMaster, DBSubInstitutionMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetSubInstitutionMasterList(SubInstitutionMasterClass objSubInstitutionMasterPassed)
        {
            SubInstitutionMasterClass objSubInstitutionMaster = null;
            wwList<SubInstitutionMasterClass> objSubInstitutionMasterList = null;

            try
            {
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM SubInstitutionMaster", objConnection);
                objReader = objCommand.ExecuteReader();
                objSubInstitutionMasterList = new wwList<SubInstitutionMasterClass>();
                while (objReader.Read())
                {
                    objSubInstitutionMaster = new SubInstitutionMasterClass();
                    objSubInstitutionMaster.iCode = int.Parse(objReader["Code"].ToString());
                    objSubInstitutionMaster.strName = objReader["Name"].ToString();
                    objSubInstitutionMaster.strIsActive = objReader["IsActive"].ToString();

                    objSubInstitutionMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objSubInstitutionMasterList.Add(objSubInstitutionMaster);
                }

                return new ResultClass(true, "SubInstitution Master List", objSubInstitutionMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetSubInstitutionMasterList, DBSubInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetSubInstitutionMasterList, DBSubInstitutionMasterClass", null, 0, ex);
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

        public ResultClass fn_GetActiveSubInstitutionMasterList(SubInstitutionMasterClass objSubInstitutionMasterPassed)
        {
            SubInstitutionMasterClass objSubInstitutionMaster = null;
            wwList<SubInstitutionMasterClass> objSubInstitutionMasterList = null;

            try
            {
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM SubInstitutionMaster WHERE IsActive = 'Yes'", objConnection);
                objReader = objCommand.ExecuteReader();
                objSubInstitutionMasterList = new wwList<SubInstitutionMasterClass>();
                while (objReader.Read())
                {
                    objSubInstitutionMaster = new SubInstitutionMasterClass();
                    objSubInstitutionMaster.iCode = int.Parse(objReader["Code"].ToString());
                    objSubInstitutionMaster.strName = objReader["Name"].ToString();
                    objSubInstitutionMaster.strIsActive = objReader["IsActive"].ToString();

                    objSubInstitutionMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objSubInstitutionMasterList.Add(objSubInstitutionMaster);
                }

                return new ResultClass(true, "SubInstitution Master List", objSubInstitutionMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetActiveSubInstitutionMasterList, DBSubInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetActiveSubInstitutionMasterList, DBSubInstitutionMasterClass", null, 0, ex);
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

        public ResultClass fn_GetSubInstitutionMasterById(SubInstitutionMasterClass objSubInstitutionMasterPassed)
        {
            SubInstitutionMasterClass objSubInstitutionMaster = null;
            wwList<SubInstitutionMasterClass> objSubInstitutionMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM SubInstitutionMaster WHERE Code = @id", objConnection);
                objCommand.Parameters.AddWithValue("@id", objSubInstitutionMasterPassed.iCode);
                objReader = objCommand.ExecuteReader();
                objSubInstitutionMasterList = new wwList<SubInstitutionMasterClass>();

                if (objReader.Read())
                {
                    objSubInstitutionMaster = new SubInstitutionMasterClass();
                    objSubInstitutionMaster.iCode = int.Parse(objReader["Code"].ToString());
                    objSubInstitutionMaster.strName = objReader["Name"].ToString();
                    objSubInstitutionMaster.strIsActive = objReader["IsActive"].ToString();

                    objSubInstitutionMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objSubInstitutionMasterList.Add(objSubInstitutionMaster);

                    return new ResultClass(true, "SubInstitution Master Present", objSubInstitutionMasterList, int.Parse(objReader["Code"].ToString()), null);
                }

                return new ResultClass(false, "SubInstitution Master not found", null, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetSubInstitutionMasterById, DBSubInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetSubInstitutionMasterById, DBSubInstitutionMasterClass", null, 0, ex);
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

        public ResultClass fn_DeleteSubInstitutionMaster(SubInstitutionMasterClass objSubInstitutionMasterPassed)
        {
            try
            {
                //new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);

                objConnection.Open();

                objCommand = new SqlCommand("UPDATE SubInstitutionMaster SET IsActive = 'No' WHERE Code = @id", objConnection);

                objCommand.Parameters.AddWithValue("@id", objSubInstitutionMasterPassed.iCode);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Institution Master deleted successfully", objSubInstitutionMasterPassed, objSubInstitutionMasterPassed.iCode, null);
                }
                else
                {
                    return new ResultClass(false, "Institution Master not deleted", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_DeleteSubInstitutionMaster, DBSubInstitutionMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_DeleteSubInstitutionMaster, DBSubInstitutionMasterClass", null, 0, ex);
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
