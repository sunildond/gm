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
    public class DBLocationMasterClass
    {
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _strDateFormat = "MM/dd/yyyy";

        public DBLocationMasterClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ResultClass fn_InsertLocationMaster(LocationMasterClass objLocationMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strInsertQueryBuilder = new StringBuilder();

                strInsertQueryBuilder.Append("INSERT INTO LocationMaster ");
                strInsertQueryBuilder.Append("(Code, Name, StateCode, IsActive, LastModify) ");
                strInsertQueryBuilder.Append("Values");
                strInsertQueryBuilder.Append("(@Code, @Name, @StateCode, @IsActive, getdate());SELECT @pk_new = @@IDENTITY");
                objCommand = new SqlCommand(strInsertQueryBuilder.ToString(), objConnection);

                objCommand.Parameters.AddWithValue("@Code", objLocationMasterPassed.strCode);
                objCommand.Parameters.AddWithValue("@Name", objLocationMasterPassed.strName);
                objCommand.Parameters.AddWithValue("@StateCode", objLocationMasterPassed.iStateCode);
                objCommand.Parameters.AddWithValue("@IsActive", objLocationMasterPassed.strIsActive);

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    objLocationMasterPassed.iLocationId = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                    return new ResultClass(true, "Location Master inserted successfully", objLocationMasterPassed, objLocationMasterPassed.iLocationId, null);
                }
                else
                {
                    return new ResultClass(false, "Location Master not added", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_InsertLocationMaster, DBLocationMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_InsertLocationMaster, DBLocationMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_UpdateLocationMaster(LocationMasterClass objLocationMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strUpdateQueryBuilder = new StringBuilder();

                strUpdateQueryBuilder.Append("UPDATE LocationMaster ");
                strUpdateQueryBuilder.Append("SET Code = @Code,");
                strUpdateQueryBuilder.Append(" Name = @Name,");
                strUpdateQueryBuilder.Append(" StateCode = @StateCode,");
                strUpdateQueryBuilder.Append(" IsActive = @IsActive,");
                strUpdateQueryBuilder.Append(" LastModify = getdate() ");
                strUpdateQueryBuilder.Append(" WHERE LocationId = @LocationId");

                objCommand = new SqlCommand(strUpdateQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@Code", objLocationMasterPassed.strCode);
                objCommand.Parameters.AddWithValue("@Name", objLocationMasterPassed.strName);
                objCommand.Parameters.AddWithValue("@StateCode", objLocationMasterPassed.iStateCode);
                objCommand.Parameters.AddWithValue("@IsActive", objLocationMasterPassed.strIsActive);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Location Master updated successfully", objLocationMasterPassed, objLocationMasterPassed.iLocationId, null);
                }
                else
                {
                    return new ResultClass(false, "Location Master not updated", objLocationMasterPassed, objLocationMasterPassed.iLocationId, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_UpdateLocationMaster, DBLocationMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_UpdateLocationMaster, DBLocationMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetLocationMasterList(LocationMasterClass objLocationMasterPassed)
        {
            LocationMasterClass objLocationMaster = null;
            wwList<LocationMasterClass> objLocationMasterList = null;

            try
            {
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM LocationMaster", objConnection);
                objReader = objCommand.ExecuteReader();
                objLocationMasterList = new wwList<LocationMasterClass>();
                while (objReader.Read())
                {
                    objLocationMaster = new LocationMasterClass();
                    objLocationMaster.iLocationId = int.Parse(objReader["LocationId"].ToString());
                    objLocationMaster.strCode = objReader["Code"].ToString();
                    objLocationMaster.strName = objReader["Name"].ToString();
                    if (objReader["StateCode"].ToString() != "")
                    {
                        objLocationMaster.iStateCode = int.Parse(objReader["StateCode"].ToString());
                    }
                    objLocationMaster.strIsActive = objReader["IsActive"].ToString();

                    objLocationMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objLocationMasterList.Add(objLocationMaster);
                }

                return new ResultClass(true, "Location Master List", objLocationMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetLocationMasterList, DBLocationMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetLocationMasterList, DBLocationMasterClass", null, 0, ex);
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

        public ResultClass fn_GetActiveLocationMasterList(LocationMasterClass objLocationMasterPassed)
        {
            LocationMasterClass objLocationMaster = null;
            wwList<LocationMasterClass> objLocationMasterList = null;

            try
            {
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM LocationMaster WHERE IsActive = 'Yes'", objConnection);
                objReader = objCommand.ExecuteReader();
                objLocationMasterList = new wwList<LocationMasterClass>();
                while (objReader.Read())
                {
                    objLocationMaster = new LocationMasterClass();
                    objLocationMaster.iLocationId = int.Parse(objReader["LocationId"].ToString());
                    objLocationMaster.strCode = objReader["Code"].ToString();
                    objLocationMaster.strName = objReader["Name"].ToString();
                    objLocationMaster.iStateCode = int.Parse(objReader["StateCode"].ToString());
                    objLocationMaster.strIsActive = objReader["IsActive"].ToString();

                    objLocationMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objLocationMasterList.Add(objLocationMaster);
                }

                return new ResultClass(true, "Location Master List", objLocationMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetLocationMasterList, DBLocationMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetLocationMasterList, DBLocationMasterClass", null, 0, ex);
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

        public ResultClass fn_GetLocationMasterById(LocationMasterClass objLocationMasterPassed)
        {
            LocationMasterClass objLocationMaster = null;
            wwList<LocationMasterClass> objLocationMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM LocationMaster WHERE LocationId = @id", objConnection);
                objCommand.Parameters.AddWithValue("@id", objLocationMasterPassed.iLocationId);
                objReader = objCommand.ExecuteReader();
                objLocationMasterList = new wwList<LocationMasterClass>();

                if (objReader.Read())
                {
                    objLocationMaster = new LocationMasterClass();
                    objLocationMaster.iLocationId = int.Parse(objReader["LocationId"].ToString());
                    objLocationMaster.strCode = objReader["Code"].ToString();
                    objLocationMaster.strName = objReader["Name"].ToString();
                    objLocationMaster.iStateCode = int.Parse(objReader["StateCode"].ToString());
                    objLocationMaster.strIsActive = objReader["IsActive"].ToString();

                    objLocationMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objLocationMasterList.Add(objLocationMaster);

                    return new ResultClass(true, "Location Master Present", objLocationMasterList, int.Parse(objReader["LocationId"].ToString()), null);
                }

                return new ResultClass(false, "Location Master not found", null, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetLocationMasterById, DBLocationMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetLocationMasterById, DBLocationMasterClass", null, 0, ex);
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

        public ResultClass fn_DeleteLocationMaster(LocationMasterClass objLocationMasterPassed)
        {
            try
            {
                //new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);

                objConnection.Open();

                objCommand = new SqlCommand("UPDATE LocationMaster SET IsActive = 'No' WHERE LocationId = @id", objConnection);

                objCommand.Parameters.AddWithValue("@id", objLocationMasterPassed.iLocationId);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Location Master deleted successfully", objLocationMasterPassed, objLocationMasterPassed.iLocationId, null);
                }
                else
                {
                    return new ResultClass(false, "Location Master not deleted", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_DeleteLocationMaster, DBLocationMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_DeleteLocationMaster, DBLocationMasterClass", null, 0, ex);
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
