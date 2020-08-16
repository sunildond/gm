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
    public class DBCategoryMasterClass
    {
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _strDateFormat = "MM/dd/yyyy";

        public DBCategoryMasterClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ResultClass fn_InsertCategoryMaster(CategoryMasterClass objCategoryMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strInsertQueryBuilder = new StringBuilder();

                strInsertQueryBuilder.Append("INSERT INTO CategoryMaster ");
                strInsertQueryBuilder.Append("(Code, Name, IsActive, LastModify) ");
                strInsertQueryBuilder.Append("Values");
                strInsertQueryBuilder.Append("(@Code, @Name, @IsActive, getdate());SELECT @pk_new = @@IDENTITY");
                objCommand = new SqlCommand(strInsertQueryBuilder.ToString(), objConnection);

                objCommand.Parameters.AddWithValue("@Code", objCategoryMasterPassed.iCode);
                objCommand.Parameters.AddWithValue("@Name", objCategoryMasterPassed.strName);
                objCommand.Parameters.AddWithValue("@IsActive", objCategoryMasterPassed.strIsActive);

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    objCategoryMasterPassed.iCategoryId = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                    return new ResultClass(true, "Category Master inserted successfully", objCategoryMasterPassed, objCategoryMasterPassed.iCategoryId, null);
                }
                else
                {
                    return new ResultClass(false, "Category Master not added", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_InsertCategoryMaster, DBCategoryMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_InsertCategoryMaster, DBCategoryMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_UpdateCategoryMaster(CategoryMasterClass objCategoryMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strUpdateQueryBuilder = new StringBuilder();

                strUpdateQueryBuilder.Append("UPDATE CategoryMaster ");
                strUpdateQueryBuilder.Append("SET Code = @Code,");
                strUpdateQueryBuilder.Append(" Name = @Name,");
                strUpdateQueryBuilder.Append(" IsActive = @IsActive,");
                strUpdateQueryBuilder.Append(" LastModify = getdate() ");
                strUpdateQueryBuilder.Append(" WHERE CategoryId = @CategoryId");

                objCommand = new SqlCommand(strUpdateQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@CategoryId", objCategoryMasterPassed.iCategoryId);
                objCommand.Parameters.AddWithValue("@Code", objCategoryMasterPassed.iCode);
                objCommand.Parameters.AddWithValue("@Name", objCategoryMasterPassed.strName);
                objCommand.Parameters.AddWithValue("@IsActive", objCategoryMasterPassed.strIsActive);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Category Master updated successfully", objCategoryMasterPassed, objCategoryMasterPassed.iCategoryId, null);
                }
                else
                {
                    return new ResultClass(false, "Category Master not updated", objCategoryMasterPassed, objCategoryMasterPassed.iCategoryId, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_UpdateCategoryMaster, DBCategoryMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_UpdateCategoryMaster, DBCategoryMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetCategoryMasterList(CategoryMasterClass objCategoryMasterPassed)
        {
            CategoryMasterClass objCategoryMaster = null;
            wwList<CategoryMasterClass> objCategoryMasterList = null;

            try
            {

                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM CategoryMaster", objConnection);
                objReader = objCommand.ExecuteReader();
                objCategoryMasterList = new wwList<CategoryMasterClass>();
                while (objReader.Read())
                {
                    objCategoryMaster = new CategoryMasterClass();
                    objCategoryMaster.iCategoryId = int.Parse(objReader["CategoryId"].ToString());
                    objCategoryMaster.iCode = int.Parse(objReader["Code"].ToString());
                    objCategoryMaster.strName = objReader["Name"].ToString();
                    objCategoryMaster.strIsActive = objReader["IsActive"].ToString();
                    objCategoryMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objCategoryMasterList.Add(objCategoryMaster);
                }

                return new ResultClass(true, "Category Master List", objCategoryMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetCategoryMasterList, DBCategoryMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetCategoryMasterList, DBCategoryMasterClass", null, 0, ex);
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

        public ResultClass fn_GetCategoryMasterById(CategoryMasterClass objCategoryMasterPassed)
        {
            CategoryMasterClass objCategoryMaster = null;
            wwList<CategoryMasterClass> objCategoryMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM CategoryMaster WHERE CategoryId = @id", objConnection);
                objCommand.Parameters.AddWithValue("@id", objCategoryMasterPassed.iCategoryId);
                objReader = objCommand.ExecuteReader();
                objCategoryMasterList = new wwList<CategoryMasterClass>();

                if (objReader.Read())
                {
                    objCategoryMaster = new CategoryMasterClass();
                    objCategoryMaster.iCategoryId = int.Parse(objReader["CategoryId"].ToString());
                    objCategoryMaster.iCode = int.Parse(objReader["Code"].ToString());
                    objCategoryMaster.strName = objReader["Name"].ToString();
                    objCategoryMaster.strIsActive = objReader["IsActive"].ToString();
                    objCategoryMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objCategoryMasterList.Add(objCategoryMaster);

                    return new ResultClass(true, "Category Master Present", objCategoryMasterList, int.Parse(objReader["CategoryId"].ToString()), null);
                }

                return new ResultClass(false, "Category Master not found", null, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetCategoryMasterById, DBCategoryMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetCategoryMasterById, DBCategoryMasterClass", null, 0, ex);
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

        public ResultClass fn_GetActiveCategoryMasterList(CategoryMasterClass objCategoryMasterPassed)
        {
            CategoryMasterClass objCategoryMaster = null;
            wwList<CategoryMasterClass> objCategoryMasterList = null;

            try
            {

                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM CategoryMaster where IsActive = 'Yes'", objConnection);
                objReader = objCommand.ExecuteReader();
                objCategoryMasterList = new wwList<CategoryMasterClass>();
                while (objReader.Read())
                {
                    objCategoryMaster = new CategoryMasterClass();
                    objCategoryMaster.iCategoryId = int.Parse(objReader["CategoryId"].ToString());
                    objCategoryMaster.iCode = int.Parse(objReader["Code"].ToString());
                    objCategoryMaster.strName = objReader["Name"].ToString();
                    objCategoryMaster.strIsActive = objReader["IsActive"].ToString();
                    objCategoryMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objCategoryMasterList.Add(objCategoryMaster);
                }

                return new ResultClass(true, "Active Category Master List", objCategoryMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetActiveCategoryMasterList, DBCategoryMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetActiveCategoryMasterList, DBCategoryMasterClass", null, 0, ex);
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

        public ResultClass fn_DeleteCategory(CategoryMasterClass objCategoryPassed)
        {
            try
            {
                //new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);

                objConnection.Open();

                objCommand = new SqlCommand("UPDATE CategoryMaster SET IsActive = 'No' WHERE CategoryId = @id", objConnection);

                objCommand.Parameters.AddWithValue("@id", objCategoryPassed.iCategoryId);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Category deleted successfully", objCategoryPassed, objCategoryPassed.iCategoryId, null);
                }
                else
                {
                    return new ResultClass(false, "Category not deleted", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_DeleteCategory, DBCategoryMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_DeleteCategory, DBCategoryMasterClass", null, 0, ex);
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
