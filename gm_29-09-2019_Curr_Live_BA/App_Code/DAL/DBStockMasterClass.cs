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
    public class DBStockMasterClass
    {
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _strDateFormat = "MM/dd/yyyy";

        public DBStockMasterClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ResultClass fn_InsertStockMaster(StockMasterClass objStockMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strInsertQueryBuilder = new StringBuilder();

                strInsertQueryBuilder.Append("INSERT INTO StockMaster ");
                strInsertQueryBuilder.Append("(Plnt, SLoc, Dv, Material, Description, Batch, Unrestricted, Unrestricted1, ShelfLifeExpDate, InspDate, ProdDate, LastModify) ");
                strInsertQueryBuilder.Append("Values");
                strInsertQueryBuilder.Append("(@Plnt, @SLoc, @Dv, @Material, @Description, @Batch, @Unrestricted, @Unrestricted1, @ShelfLifeExpDate, @InspDate, @ProdDate, getdate());SELECT @pk_new = @@IDENTITY");

                objCommand = new SqlCommand(strInsertQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@Plnt", objStockMasterPassed.strPlnt);
                objCommand.Parameters.AddWithValue("@SLoc", objStockMasterPassed.strSLoc);
                objCommand.Parameters.AddWithValue("@Dv", objStockMasterPassed.iDv);
                objCommand.Parameters.AddWithValue("@Material", objStockMasterPassed.strMaterial);
                objCommand.Parameters.AddWithValue("@Description", objStockMasterPassed.strDescription);
                objCommand.Parameters.AddWithValue("@Batch", objStockMasterPassed.strBatch);
                objCommand.Parameters.AddWithValue("@Unrestricted", objStockMasterPassed.iUnrestricted);
                objCommand.Parameters.AddWithValue("@Unrestricted1", objStockMasterPassed.strUnrestricted1);
                objCommand.Parameters.AddWithValue("@ShelfLifeExpDate", objStockMasterPassed.dtShelfLifeExpDate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@InspDate", objStockMasterPassed.dtInspDate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@ProdDate", objStockMasterPassed.dtProdDate.ToString(_strDateFormat));

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    objStockMasterPassed.iStockId = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                    return new ResultClass(true, "Stock Master inserted successfully", objStockMasterPassed, objStockMasterPassed.iStockId, null);
                }
                else
                {
                    return new ResultClass(false, "Stock Master not added", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_InsertStockMaster, DBStockMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_InsertStockMaster, DBStockMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_UpdateStockMaster(StockMasterClass objStockMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strUpdateQueryBuilder = new StringBuilder();

                strUpdateQueryBuilder.Append("UPDATE StockMaster ");
                strUpdateQueryBuilder.Append("SET Plnt = @Plnt, ");
                strUpdateQueryBuilder.Append(" SLoc = @SLoc, ");
                strUpdateQueryBuilder.Append(" Dv = @Dv, ");
                strUpdateQueryBuilder.Append(" Material = @Material, ");
                strUpdateQueryBuilder.Append(" Description = @Description, ");
                strUpdateQueryBuilder.Append(" Batch = @Batch, ");
                strUpdateQueryBuilder.Append(" Unrestricted = @Unrestricted, ");
                strUpdateQueryBuilder.Append(" Unrestricted1 = @Unrestricted1, ");
                strUpdateQueryBuilder.Append(" ShelfLifeExpDate = @ShelfLifeExpDate, ");
                strUpdateQueryBuilder.Append(" InspDate = @InspDate, ");
                strUpdateQueryBuilder.Append(" ProdDate = @ProdDate, ");
                strUpdateQueryBuilder.Append(" LastModify = getdate() ");
                strUpdateQueryBuilder.Append(" WHERE StockId = @StockId");

                objCommand = new SqlCommand(strUpdateQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@StockId", objStockMasterPassed.iStockId);
                objCommand.Parameters.AddWithValue("@Plnt", objStockMasterPassed.strPlnt);
                objCommand.Parameters.AddWithValue("@SLoc", objStockMasterPassed.strSLoc);
                objCommand.Parameters.AddWithValue("@Dv", objStockMasterPassed.iDv);
                objCommand.Parameters.AddWithValue("@Material", objStockMasterPassed.strMaterial);
                objCommand.Parameters.AddWithValue("@Description", objStockMasterPassed.strDescription);
                objCommand.Parameters.AddWithValue("@Batch", objStockMasterPassed.strBatch);
                objCommand.Parameters.AddWithValue("@Unrestricted", objStockMasterPassed.iUnrestricted);
                objCommand.Parameters.AddWithValue("@Unrestricted1", objStockMasterPassed.strUnrestricted1);
                objCommand.Parameters.AddWithValue("@ShelfLifeExpDate", objStockMasterPassed.dtShelfLifeExpDate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@InspDate", objStockMasterPassed.dtInspDate.ToString(_strDateFormat));
                objCommand.Parameters.AddWithValue("@ProdDate", objStockMasterPassed.dtProdDate.ToString(_strDateFormat));

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Stock Master updated successfully", objStockMasterPassed, objStockMasterPassed.iStockId, null);
                }
                else
                {
                    return new ResultClass(false, "Stock Master not updated", objStockMasterPassed, objStockMasterPassed.iStockId, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_UpdateStockMaster, DBStockMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_UpdateStockMaster, DBStockMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetStockMasterList(StockMasterClass objStockMasterPassed)
        {
            StockMasterClass objStockMaster = null;
            wwList<StockMasterClass> objStockMasterList = null;

            try
            {

                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM StockMaster", objConnection);
                objReader = objCommand.ExecuteReader();
                objStockMasterList = new wwList<StockMasterClass>();
                while (objReader.Read())
                {
                    objStockMaster = new StockMasterClass();
                    objStockMaster.iStockId = int.Parse(objReader["StockId"].ToString());
                    objStockMaster.strPlnt = objReader["Plnt"].ToString();
                    objStockMaster.strSLoc = objReader["SLoc"].ToString();
                    objStockMaster.iDv = int.Parse(objReader["Dv"].ToString());
                    objStockMaster.strMaterial = objReader["Material"].ToString();
                    objStockMaster.strDescription = objReader["Description"].ToString();
                    objStockMaster.strBatch = objReader["Batch"].ToString();
                    objStockMaster.iUnrestricted = int.Parse(objReader["Unrestricted"].ToString());
                    objStockMaster.strUnrestricted1 = objReader["Unrestricted1"].ToString();
                    objStockMaster.dtShelfLifeExpDate = Convert.ToDateTime(objReader["ShelfLifeExpDate"].ToString());
                    objStockMaster.dtInspDate = Convert.ToDateTime(objReader["InspDate"].ToString());
                    objStockMaster.dtProdDate = Convert.ToDateTime(objReader["ProdDate"].ToString());

                    objStockMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objStockMasterList.Add(objStockMaster);
                }

                return new ResultClass(true, "Stock Master List", objStockMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetStockMasterList, DBStockMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetStockMasterList, DBStockMasterClass", null, 0, ex);
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

        public ResultClass fn_GetStockMasterById(StockMasterClass objStockMasterPassed)
        {
            StockMasterClass objStockMaster = null;
            wwList<StockMasterClass> objStockMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM StockMaster WHERE StockId = @id", objConnection);
                objCommand.Parameters.AddWithValue("@id", objStockMasterPassed.iStockId);
                objReader = objCommand.ExecuteReader();
                objStockMasterList = new wwList<StockMasterClass>();

                if (objReader.Read())
                {
                    objStockMaster = new StockMasterClass();
                    objStockMaster.iStockId = int.Parse(objReader["StockId"].ToString());
                    objStockMaster.strPlnt = objReader["Plnt"].ToString();
                    objStockMaster.strSLoc = objReader["SLoc"].ToString();
                    objStockMaster.iDv = int.Parse(objReader["Dv"].ToString());
                    objStockMaster.strMaterial = objReader["Material"].ToString();
                    objStockMaster.strDescription = objReader["Description"].ToString();
                    objStockMaster.strBatch = objReader["Batch"].ToString();
                    objStockMaster.iUnrestricted = int.Parse(objReader["Unrestricted"].ToString());
                    objStockMaster.strUnrestricted1 = objReader["Unrestricted1"].ToString();
                    objStockMaster.dtShelfLifeExpDate = Convert.ToDateTime(objReader["ShelfLifeExpDate"].ToString());
                    objStockMaster.dtInspDate = Convert.ToDateTime(objReader["InspDate"].ToString());
                    objStockMaster.dtProdDate = Convert.ToDateTime(objReader["ProdDate"].ToString());

                    objStockMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objStockMasterList.Add(objStockMaster);

                    return new ResultClass(true, "Stock Master Present", objStockMasterList, int.Parse(objReader["StockId"].ToString()), null);
                }

                return new ResultClass(false, "Stock Master not found", null, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetStockMasterById, DBStockMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetStockMasterById, DBStockMasterClass", null, 0, ex);
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
