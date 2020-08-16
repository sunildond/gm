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
    public class DBCustomerMasterClass
    {
        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _strDateFormat = "MM/dd/yyyy";

        public DBCustomerMasterClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ResultClass fn_InsertCustomerMaster(CustomerMasterClass objCustomerMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strInsertQueryBuilder = new StringBuilder();

                strInsertQueryBuilder.Append("INSERT INTO CustomerMaster ");
                strInsertQueryBuilder.Append("(Customer, Name1, City, Rg, Street, Street4, Street5, Street3, PostalCode, VATregistrationNo, CSTnumber, LSTnumber, LastModify) ");
                strInsertQueryBuilder.Append("Values");
                strInsertQueryBuilder.Append("(@Customer, @Name1, @City, @Rg, @Street, @Street4, @Street5, @Street3, @PostalCode, @VATregistrationNo, @CSTnumber, @LSTnumber, getdate());SELECT @pk_new = @@IDENTITY");
                objCommand = new SqlCommand(strInsertQueryBuilder.ToString(), objConnection);

                objCommand.Parameters.AddWithValue("@Customer", objCustomerMasterPassed.strCustomer);
                objCommand.Parameters.AddWithValue("@Name1", objCustomerMasterPassed.strName1);
                objCommand.Parameters.AddWithValue("@City", objCustomerMasterPassed.strCity);
                objCommand.Parameters.AddWithValue("@Rg", objCustomerMasterPassed.iRg);
                objCommand.Parameters.AddWithValue("@Street", objCustomerMasterPassed.strStreet);
                objCommand.Parameters.AddWithValue("@Street4", objCustomerMasterPassed.strStreet4);
                objCommand.Parameters.AddWithValue("@Street5", objCustomerMasterPassed.strStreet5);
                objCommand.Parameters.AddWithValue("@Street3", objCustomerMasterPassed.strStreet3);
                objCommand.Parameters.AddWithValue("@PostalCode", objCustomerMasterPassed.strPostalCode);
                objCommand.Parameters.AddWithValue("@VATregistrationNo", objCustomerMasterPassed.strVATregistrationNo);
                objCommand.Parameters.AddWithValue("@CSTnumber", objCustomerMasterPassed.strCSTnumber);
                objCommand.Parameters.AddWithValue("@LSTnumber", objCustomerMasterPassed.strLSTnumber);

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    objCustomerMasterPassed.iCustomerId = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                    return new ResultClass(true, "Customer Master inserted successfully", objCustomerMasterPassed, objCustomerMasterPassed.iCustomerId, null);
                }
                else
                {
                    return new ResultClass(false, "Customer Master not added", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_InsertCustomerMaster, DBCustomerMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_InsertCustomerMaster, DBCustomerMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_UpdateCustomerMaster(CustomerMasterClass objCustomerMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strUpdateQueryBuilder = new StringBuilder();

                strUpdateQueryBuilder.Append("UPDATE CustomerMaster ");
                strUpdateQueryBuilder.Append("SET Customer = @Customer,");
                strUpdateQueryBuilder.Append(" Name1 = @Name1,");
                strUpdateQueryBuilder.Append(" City = @City,");
                strUpdateQueryBuilder.Append(" Rg = @Rg,");
                strUpdateQueryBuilder.Append(" Street = @Street,");
                strUpdateQueryBuilder.Append(" Street4 = @Street4,");
                strUpdateQueryBuilder.Append(" Street5 = @Street5,");
                strUpdateQueryBuilder.Append(" Street3 = @Street3,");
                strUpdateQueryBuilder.Append(" PostalCode = @PostalCode,");
                strUpdateQueryBuilder.Append(" VATregistrationNo = @VATregistrationNo,");
                strUpdateQueryBuilder.Append(" CSTnumber = @CSTnumber,");
                strUpdateQueryBuilder.Append(" LSTnumber = @LSTnumber,");
                strUpdateQueryBuilder.Append(" LastModify = getdate() ");
                strUpdateQueryBuilder.Append(" WHERE CustomerId = @CustomerId");

                objCommand = new SqlCommand(strUpdateQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@CustomerId", objCustomerMasterPassed.iCustomerId);
                objCommand.Parameters.AddWithValue("@Customer", objCustomerMasterPassed.strCustomer);
                objCommand.Parameters.AddWithValue("@Name1", objCustomerMasterPassed.strName1);
                objCommand.Parameters.AddWithValue("@City", objCustomerMasterPassed.strCity);
                objCommand.Parameters.AddWithValue("@Rg", objCustomerMasterPassed.iRg);
                objCommand.Parameters.AddWithValue("@Street", objCustomerMasterPassed.strStreet);
                objCommand.Parameters.AddWithValue("@Street4", objCustomerMasterPassed.strStreet4);
                objCommand.Parameters.AddWithValue("@Street5", objCustomerMasterPassed.strStreet5);
                objCommand.Parameters.AddWithValue("@Street3", objCustomerMasterPassed.strStreet3);
                objCommand.Parameters.AddWithValue("@PostalCode", objCustomerMasterPassed.strPostalCode);
                objCommand.Parameters.AddWithValue("@VATregistrationNo", objCustomerMasterPassed.strVATregistrationNo);
                objCommand.Parameters.AddWithValue("@CSTnumber", objCustomerMasterPassed.strCSTnumber);
                objCommand.Parameters.AddWithValue("@LSTnumber", objCustomerMasterPassed.strLSTnumber);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Customer Master updated successfully", objCustomerMasterPassed, objCustomerMasterPassed.iCustomerId, null);
                }
                else
                {
                    return new ResultClass(false, "Customer Master not updated", objCustomerMasterPassed, objCustomerMasterPassed.iCustomerId, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_UpdateCustomerMaster, DBCustomerMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_UpdateCustomerMaster, DBCustomerMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetCustomerMasterList(CustomerMasterClass objCustomerMasterPassed)
        {
            CustomerMasterClass objCustomerMaster = null;
            wwList<CustomerMasterClass> objCustomerMasterList = null;

            try
            {
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM CustomerMaster", objConnection);
                objReader = objCommand.ExecuteReader();
                objCustomerMasterList = new wwList<CustomerMasterClass>();
                while (objReader.Read())
                {
                    objCustomerMaster = new CustomerMasterClass();
                    objCustomerMaster.iCustomerId = int.Parse(objReader["CustomerId"].ToString());
                    objCustomerMaster.strCustomer = objReader["Customer"].ToString();
                    objCustomerMaster.strName1 = objReader["Name1"].ToString();
                    objCustomerMaster.strCity = objReader["City"].ToString();
                    objCustomerMaster.iRg = int.Parse(objReader["Rg"].ToString());
                    objCustomerMaster.strStreet = objReader["Street"].ToString();
                    objCustomerMaster.strStreet4 = objReader["Street4"].ToString();
                    objCustomerMaster.strStreet5 = objReader["Street5"].ToString();
                    objCustomerMaster.strStreet3 = objReader["Street3"].ToString();
                    objCustomerMaster.strPostalCode = objReader["PostalCode"].ToString();
                    objCustomerMaster.strVATregistrationNo = objReader["VATregistrationNo"].ToString();
                    objCustomerMaster.strCSTnumber = objReader["CSTnumber"].ToString();
                    objCustomerMaster.strLSTnumber = objReader["LSTnumber"].ToString();

                    objCustomerMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objCustomerMasterList.Add(objCustomerMaster);
                }

                return new ResultClass(true, "Category Master List", objCustomerMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetCustomerMasterList, DBCustomerMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetCustomerMasterList, DBCustomerMasterClass", null, 0, ex);
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

        public ResultClass fn_GetCustomerMasterById(CustomerMasterClass objCustomerMasterPassed)
        {
            CustomerMasterClass objCustomerMaster = null;
            wwList<CustomerMasterClass> objCustomerMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM CustomerMaster WHERE CustomerId = @id", objConnection);
                objCommand.Parameters.AddWithValue("@id", objCustomerMasterPassed.iCustomerId);
                objReader = objCommand.ExecuteReader();
                objCustomerMasterList = new wwList<CustomerMasterClass>();

                if (objReader.Read())
                {
                    objCustomerMaster = new CustomerMasterClass();
                    objCustomerMaster.iCustomerId = int.Parse(objReader["CustomerId"].ToString());
                    objCustomerMaster.strCustomer = objReader["Customer"].ToString();
                    objCustomerMaster.strName1 = objReader["Name1"].ToString();
                    objCustomerMaster.strCity = objReader["City"].ToString();
                    objCustomerMaster.iRg = int.Parse(objReader["Rg"].ToString());
                    objCustomerMaster.strStreet = objReader["Street"].ToString();
                    objCustomerMaster.strStreet4 = objReader["Street4"].ToString();
                    objCustomerMaster.strStreet5 = objReader["Street5"].ToString();
                    objCustomerMaster.strStreet3 = objReader["Street3"].ToString();
                    objCustomerMaster.strPostalCode = objReader["PostalCode"].ToString();
                    objCustomerMaster.strVATregistrationNo = objReader["VATregistrationNo"].ToString();
                    objCustomerMaster.strCSTnumber = objReader["CSTnumber"].ToString();
                    objCustomerMaster.strLSTnumber = objReader["LSTnumber"].ToString();

                    objCustomerMaster.dtLastModify = objReader["LastModify"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModify"].ToString());

                    objCustomerMasterList.Add(objCustomerMaster);
                    return new ResultClass(true, "Category Master Present", objCustomerMasterList, int.Parse(objReader["CustomerId"].ToString()), null);
                }

                return new ResultClass(false, "Category Master not found", null, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetCustomerMasterById, DBCustomerMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetCustomerMasterById, DBCustomerMasterClass", null, 0, ex);
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
