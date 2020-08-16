using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ww_lib;
using ww_admin;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System;

namespace ww_lib
{
    public class CommonFunction
    {
        private SqlConnection objConnection = null;
        private string selectQueryString = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataTable dataTable = null;
        //public SqlConnection Connection
        //{
        //  get { return new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString()); }
        //}

        private SqlCommand objCommand = null;
        private SqlDataReader objReader = null;

        static string strLogFileName = "LOG/LogRecord.txt";

        public CommonFunction()
        {

        }

        public DataTable GetTableColumn(string tblname)
        {
            try
            {
                DataTable dt = new DataTable();
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                StringBuilder strQuery = new StringBuilder();
                strQuery.Append(" SELECT u.name + '.' + t.name AS [table],td.value AS [table_desc],c.name AS [column],cd.value AS [column_desc] ");
                strQuery.Append(" FROM sysobjects t ");
                strQuery.Append(" INNER JOIN  sysusers u ON u.uid = t.uid ");
                strQuery.Append(" LEFT OUTER JOIN sys.extended_properties td ON td.major_id = t.id AND td.minor_id = 0 AND td.name = 'MS_Description' ");
                strQuery.Append(" INNER JOIN  syscolumns c ON c.id = t.id ");
                strQuery.Append(" LEFT OUTER JOIN sys.extended_properties cd ON cd.major_id = c.id AND cd.minor_id = c.colid AND cd.name = 'MS_Description' ");
                strQuery.Append(" WHERE t.type = 'u' and t.name ='" + tblname + "'");
                strQuery.Append(" ORDER BY    t.name, c.colorder");
                SqlDataAdapter da = new SqlDataAdapter(strQuery.ToString(), objConnection);
                da.Fill(dt);
                return dt;
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public DataTable GetDataTable(string Query)
        {
            try
            {
                DataTable dt = new DataTable();
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                SqlDataAdapter da = new SqlDataAdapter(Query, objConnection);
                da.SelectCommand.CommandTimeout = 90000;
                da.Fill(dt);
                return dt;
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public DataSet GetDataSet(string Query, string TableName)
        {
            try
            {
                DataSet ds = new DataSet();
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                SqlDataAdapter da = new SqlDataAdapter(Query, objConnection);
                da.SelectCommand.CommandTimeout = 90000;
                da.Fill(ds, TableName);
                return ds;
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public Result ExecuteReaderQuery(string Query)
        {
            try
            {
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                objConnection.Open();
                objCommand = new SqlCommand(Query, objConnection);
                objCommand.CommandTimeout = 90000;
                objReader = objCommand.ExecuteReader();

                if (objReader.Read())
                {
                    return new Result(true, "Query Execute Sucessfully", 0, null);
                }
                else
                {
                    return new Result(false, "Error Occured", 0, null);
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Error Occured", 0, null);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }


        public Result InsertQuery(string Query)
        {
            try
            {
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                objConnection.Open();
                string Query1 = Query + "; SELECT @pk_new = @@IDENTITY";
                objCommand = new SqlCommand(Query1, objConnection);

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new Result(true, "Query Execute Sucessfully", int.Parse(objCommand.Parameters["@pk_new"].Value.ToString()), null);

                }
                else
                {
                    return new Result(false, "Error Occured", 0, null);
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Error Occured", 0, null);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public Result ExecuteDMLQuery(string Query)
        {
            try
            {
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                objConnection.Open();
                string Query1 = Query;
                objCommand = new SqlCommand(Query1, objConnection);
                objCommand.CommandTimeout = 90000;
                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new Result(true, "Query Execute Sucessfully", 0, null);
                }
                else
                {
                    return new Result(false, "Error Occured", 0, null);
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Error Occured", 0, null);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public Result ExecuteScalarCnt(string Query)
        {
            try
            {
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                objConnection.Open();
                string Query1 = Query;
                objCommand = new SqlCommand(Query1, objConnection);
                int intCount = (int)objCommand.ExecuteScalar();

                if (intCount > 0)
                {
                    return new Result(true, "Query Execute Sucessfully", intCount, null);
                }
                else
                {
                    return new Result(false, "Error Occured", 0, null);
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Error Occured", 0, null);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public Result InsertNewQuery(SqlCommand cmd)
        {
            try
            {
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                objConnection.Open();

                objCommand = cmd;
                objCommand.Connection = objConnection;

                //SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                //spInsertedKey.Direction = ParameterDirection.Output;
                //objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new Result(true, "Query Execute Sucessfully", int.Parse(objCommand.Parameters["@pk_new"].Value.ToString()), null);

                }
                else
                {
                    return new Result(false, "Error Occured", 0, null);
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Error Occured", 0, null);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public Result ExecuteNewDMLQuery(SqlCommand cmbQuery)
        {
            try
            {
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                objConnection.Open();

                objCommand = cmbQuery;
                objCommand.Connection = objConnection;
                objCommand.CommandTimeout = 90000;
                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new Result(true, "Query Execute Sucessfully", 0, null);
                }
                else
                {
                    return new Result(false, "Error Occured", 0, null);
                }
            }
            catch (Exception ex)
            {
                return new Result(false, "Error Occured", 0, null);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public SqlDataAdapter GetSqlDataAdapter(string Query)
        {
            //SqlConnection objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
            SqlConnection objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
            SqlDataAdapter da = new SqlDataAdapter(Query, objConnection);
            return da;
        }

        public void OpenConnection()
        {
            try
            {
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                objConnection.Open();
            }
            catch(Exception ex)
            { 
                
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public Result fn_ComparePassword(string uname, string pwd)
        {
            try
            {
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId].ToString());
                objConnection.Open();
                string Query = "select * from UserMaster where UserName=@uname and Password=@pwd and IsActive='Yes'";
                objCommand = new SqlCommand(Query, objConnection);
                objCommand.Parameters.AddWithValue("@uname",uname);
                objCommand.Parameters.AddWithValue("@pwd", pwd);
                objReader = objCommand.ExecuteReader();                
                if (objReader.Read())
                {
                    DBSessionUser.iUser_Id = Convert.ToInt32(objReader["UserId"].ToString());
                    ////DBSessionUser.iUser_Type = Convert.ToInt32(objReader["UserTypeId"].ToString());
                    DBSessionUser.strName = objReader["Name"].ToString();
                    DBSessionUser.strUser_Name = objReader["UserName"].ToString();
                    DBSessionUser.bAddPerm = Convert.ToBoolean(objReader["addPerm"].ToString());
                    DBSessionUser.bEditPerm = Convert.ToBoolean(objReader["editPerm"].ToString());
                    DBSessionUser.bIsAuthorise = Convert.ToBoolean(objReader["IsAuthorise"].ToString());

                    return new Result(true, "Query Execute Sucessfully", int.Parse(objReader["UserId"].ToString()), null);
                }
                return new Result(false, "Error Occured", 0, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return new Result(false, "Error Occured", 0, null);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public void fn_ExportToExcel(string Query, string SheetName, string FileName)
        {
            try
            {   
                string DestinationFilePath = string.Empty;
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DestinationFilePath = folderBrowserDialog1.SelectedPath;

                    objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                    //selectQueryString = "SELECT * FROM StampingMaster";
                    //sqlDataAdapter = new SqlDataAdapter(Query, objConnection);

                    dataTable = new DataTable();
                    //sqlDataAdapter.Fill(dataTable);
                    dataTable = GetDataTable(Query.ToString());

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;

                    //Excel.Range chartRange = null;

                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.ApplicationClass();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    int j = 0;
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        j = j + 1;
                        xlWorkSheet.Cells[1, j] = column.ColumnName;
                    }

                    xlWorkSheet.Name = SheetName;

                    //xlWorkSheet.get_Range(1, 5).Font.Bold = true;
                    //for (int i = 0; i < dataTable.Rows.Count; i++)
                    //{
                    //    DataRow row = dataTable.Rows[1];
                    //    //xlWorkSheet.Cells[1, 1] = "http://csharp.net-informations.com";
                    //}

                    int r = 2, c = 1;
                    foreach (DataRow row in dataTable.Rows) // Loop over the rows.
                    {
                        //Console.WriteLine("--- Row ---"); // Print separator.
                        foreach (var item in row.ItemArray) // Loop over the items.
                        {
                            //Console.Write("Item: "); // Print label.
                            //Console.WriteLine(item); // Invokes ToString abstract method.
                            xlWorkSheet.Cells[r, c] = item;
                            c = c + 1;
                        }
                        r = r + 1;
                        c = 1;
                    }

                    xlWorkBook.SaveAs(DestinationFilePath + "\\" + FileName + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);     //xlWorkbookNormal

                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    MessageBox.Show("Excel file created , you can find the file " + DestinationFilePath + "\\" + FileName + ".xls");
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel file is not created!");
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


    }
}
