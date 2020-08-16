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
    public class DBProductMasterClass
    {
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _strDateFormat = "MM/dd/yyyy";

        public DBProductMasterClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ResultClass fn_InsertProductMaster(ProductMasterClass objProductMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strInsertQueryBuilder = new StringBuilder();

                strInsertQueryBuilder.Append("INSERT INTO ProductMaster ");
                strInsertQueryBuilder.Append("(Material, Description, Aliscode, Unit, LastModify) ");
                strInsertQueryBuilder.Append("Values");
                strInsertQueryBuilder.Append("(@Material, @Description, @Aliscode, @Unit, getdate());SELECT @pk_new = @@IDENTITY");
                objCommand = new SqlCommand(strInsertQueryBuilder.ToString(), objConnection);

                objCommand.Parameters.AddWithValue("@Material", objProductMasterPassed.strMaterial);
                objCommand.Parameters.AddWithValue("@Description", objProductMasterPassed.strDescription);
                objCommand.Parameters.AddWithValue("@Aliscode", objProductMasterPassed.iAliscode);
                objCommand.Parameters.AddWithValue("@Unit", objProductMasterPassed.iUnit);

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    objProductMasterPassed.iProductId = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                    return new ResultClass(true, "Product Master inserted successfully", objProductMasterPassed, objProductMasterPassed.iProductId, null);
                }
                else
                {
                    return new ResultClass(false, "Product Master not added", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_InsertProductMaster, DBProductMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_InsertProductMaster, DBProductMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_UpdateProductMaster(ProductMasterClass objProductMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strUpdateQueryBuilder = new StringBuilder();

                strUpdateQueryBuilder.Append("UPDATE ProductMaster ");
                strUpdateQueryBuilder.Append("SET Material = @Material,");
                strUpdateQueryBuilder.Append(" Description = @Description,");
                strUpdateQueryBuilder.Append(" Aliscode = @Aliscode,");
                strUpdateQueryBuilder.Append(" Unit = @Unit,");
                strUpdateQueryBuilder.Append(" LastModify = getdate() ");
                strUpdateQueryBuilder.Append(" WHERE ProductId = @ProductId");

                objCommand = new SqlCommand(strUpdateQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@ProductId", objProductMasterPassed.iProductId);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Product Master updated successfully", objProductMasterPassed, objProductMasterPassed.iProductId, null);
                }
                else
                {
                    return new ResultClass(false, "Product Master not updated", objProductMasterPassed, objProductMasterPassed.iProductId, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_UpdateProductMaster, DBProductMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_UpdateProductMaster, DBProductMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetProductMasterList(ProductMasterClass objProductMasterPassed)
        {
            ProductMasterClass objProductMaster = null;
            wwList<ProductMasterClass> objProductMasterList = null;

            try
            {

                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM ProductMaster", objConnection);
                objReader = objCommand.ExecuteReader();
                objProductMasterList = new wwList<ProductMasterClass>();
                while (objReader.Read())
                {
                    objProductMaster = new ProductMasterClass();
                    objProductMaster.iProductId = int.Parse(objReader["ProductId"].ToString());                    
                    objProductMaster.strMaterial = objReader["Material"].ToString();
                    objProductMaster.strDescription = objReader["Description"].ToString();
                    objProductMaster.iAliscode = int.Parse(objReader["Aliscode"].ToString());
                    objProductMaster.iUnit = int.Parse(objReader["Unit"].ToString());

                    objProductMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objProductMasterList.Add(objProductMaster);
                }

                return new ResultClass(true, "Product Master List", objProductMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetProductMasterList, DBProductMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetProductMasterList, DBProductMasterClass", null, 0, ex);
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

        public ResultClass fn_GetProductMasterById(ProductMasterClass objProductMasterPassed)
        {
            ProductMasterClass objProductMaster = null;
            wwList<ProductMasterClass> objProductMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM ProductMaster WHERE ProductId = @id", objConnection);
                objCommand.Parameters.AddWithValue("@id", objProductMasterPassed.iProductId);
                objReader = objCommand.ExecuteReader();
                objProductMasterList = new wwList<ProductMasterClass>();

                if (objReader.Read())
                {
                    objProductMaster = new ProductMasterClass();
                    objProductMaster.iProductId = int.Parse(objReader["ProductId"].ToString());
                    objProductMaster.strMaterial = objReader["Material"].ToString();
                    objProductMaster.strDescription = objReader["Description"].ToString();
                    objProductMaster.iAliscode = int.Parse(objReader["Aliscode"].ToString());
                    objProductMaster.iUnit = int.Parse(objReader["Unit"].ToString());

                    objProductMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objProductMasterList.Add(objProductMaster);

                    return new ResultClass(true, "Product Master Present", objProductMasterList, int.Parse(objReader["ProductId"].ToString()), null);
                }

                return new ResultClass(false, "Product Master not found", null, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetProductMasterById, DBProductMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetProductMasterById, DBProductMasterClass", null, 0, ex);
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
