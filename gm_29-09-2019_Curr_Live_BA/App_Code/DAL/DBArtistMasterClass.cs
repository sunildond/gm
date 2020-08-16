using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ww_lib;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for DBArtistMasterClass
/// </summary>
/// 

namespace ww_admin
{
    public class DBArtistMasterClass
    {

        private SqlConnection objConnection = null;
        private SqlDataReader objReader = null;
        private SqlCommand objCommand = null;
        private string _strDateFormat = "MM/dd/yyyy";
        public DBArtistMasterClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        //data source=192.168.0.157;initial catalog=mtcoin;persist security info=true;user id=sa;password=sa123!@#
        public ResultClass fn_GetArtistMasterList(ArtistMasterClass objArtistMasterPassed)
        {
            ArtistMasterClass objArtistMaster = null;
            wwList<ArtistMasterClass> objArtistMasterList = null;

            try
            {

                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                //ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM ArtistMaster", objConnection);
                objReader = objCommand.ExecuteReader();
                objArtistMasterList = new wwList<ArtistMasterClass>();
                while (objReader.Read())
                {
                    objArtistMaster = new ArtistMasterClass();
                    objArtistMaster.iArtistId = int.Parse(objReader["ArtistId"].ToString());
                    objArtistMaster.strArtistName = objReader["ArtistName"].ToString();
                    objArtistMaster.strAlsoKnowAs = objReader["AlsoKnowAs"].ToString();
                    objArtistMaster.iCompany = Convert.ToInt32(objReader["Company"].ToString());
                    objArtistMaster.strAddress = objReader["Address"].ToString();

                    //objArtistMaster.dtDOB = objReader["DOB"] == DBNull.Value ? string.Empty : string.Format("{0:dd/MM/yyyy}", objReader["DOB"].ToString());

                    if (!String.IsNullOrEmpty(objReader["DOB"].ToString()))
                    {
                        objArtistMaster.dtDOB = Convert.ToDateTime(objReader["DOB"].ToString());
                    }

                    objArtistMaster.strPlaceofbirth = objReader["Placeofbirth"].ToString();
                    //objArtistMaster.dtDOD = objReader["DOD"] == DBNull.Value ? string.Empty : string.Format("{0:dd/MM/yyyy}", objReader["DOD"].ToString());

                    if (!String.IsNullOrEmpty(objReader["DOD"].ToString()))
                    {
                        objArtistMaster.dtDOD = Convert.ToDateTime(objReader["DOD"].ToString());
                    }

                    objArtistMaster.strOfficialSite = objReader["OfficialSite"].ToString();
                    objArtistMaster.strProfile = objReader["Profile"].ToString();
                    objArtistMaster.strPlaceofDeath = objReader["PlaceofDeath"].ToString();
                    objArtistMaster.strContact = objReader["Contact"].ToString();
                    objArtistMaster.dtLastModifyDate = objReader["LastModifyDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModifyDate"].ToString());
                    objArtistMaster.strLanguage = objReader["Language"].ToString();
                    objArtistMaster.strGender =String.IsNullOrEmpty(objReader["Gender"].ToString()) ? "0" : objReader["Gender"].ToString();
                    objArtistMaster.strNationality = String.IsNullOrEmpty(objReader["Nationality"].ToString()) ? string.Empty : objReader["Nationality"].ToString();
                    objArtistMaster.strArtisteFolder = objReader["ArtisteFolder"].ToString();
                    objArtistMaster.strArtisteFile = objReader["ArtisteFile"].ToString();
                    objArtistMaster.strArtisteFile1 = objReader["ArtisteFile1"].ToString();
                    objArtistMaster.strArtisteFile2 = objReader["ArtisteFile2"].ToString();
                    objArtistMaster.strMaritalStatus = String.IsNullOrEmpty(objReader["MaritalStatus"].ToString()) ? "0" : objReader["MaritalStatus"].ToString();
                    objArtistMasterList.Add(objArtistMaster);
                }

                return new ResultClass(true, "Artist Master List", objArtistMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetArtistMasterList, DBArtistMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetArtistMasterList, DBArtistMasterClass", null, 0, ex);
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

        public ResultClass fn_SelectArtistByMultipleArtistId(ArtistMasterClass objArtistMasterPassed)
        {
            ArtistMasterClass objArtistMaster = null;
            wwList<ArtistMasterClass> objArtistMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT ArtistMaster.ArtistId, ArtistMaster.ArtistName FROM ArtistMaster, hometop where ArtistMaster.ArtistId = hometop.ArtistId order by hometop.hometopId asc", objConnection);
                objReader = objCommand.ExecuteReader();
                objArtistMasterList = new wwList<ArtistMasterClass>();
                while (objReader.Read())
                {
                    objArtistMaster = new ArtistMasterClass();
                    objArtistMaster.iArtistId = int.Parse(objReader["ArtistId"].ToString());
                    objArtistMaster.strArtistName = objReader["ArtistName"].ToString();
                   
                    objArtistMasterList.Add(objArtistMaster);
                }

                return new ResultClass(true, "Artist Master List", objArtistMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_SelectArtistByMultipleArtistId, DBArtistMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_SelectArtistByMultipleArtistId, DBArtistMasterClass", null, 0, ex);
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

        public ResultClass fn_GetArtistMasterById(ArtistMasterClass objArtistMasterPassed)
        {
            ArtistMasterClass objArtistMaster = null;
            wwList<ArtistMasterClass> objArtistMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT * FROM ArtistMaster WHERE ArtistId = @id", objConnection);
                objCommand.Parameters.AddWithValue("@id", objArtistMasterPassed.iArtistId);
                objReader = objCommand.ExecuteReader();
                objArtistMasterList = new wwList<ArtistMasterClass>();

                if (objReader.Read())
                {
                    objArtistMaster = new ArtistMasterClass();
                    objArtistMaster.iArtistId = int.Parse(objReader["ArtistId"].ToString());
                    objArtistMaster.strArtistName = objReader["ArtistName"].ToString();
                    objArtistMaster.strAlsoKnowAs = objReader["AlsoKnowAs"].ToString();
                    objArtistMaster.iCompany = Convert.ToInt32(objReader["Company"].ToString());
                    objArtistMaster.strAddress = objReader["Address"].ToString();
                    if (!String.IsNullOrEmpty(objReader["DOB"].ToString()))
                    {
                        objArtistMaster.dtDOB = Convert.ToDateTime(objReader["DOB"].ToString());
                    }
                    objArtistMaster.strPlaceofbirth = objReader["Placeofbirth"].ToString();
                    if (!String.IsNullOrEmpty(objReader["DOD"].ToString()))
                    {
                        objArtistMaster.dtDOD = Convert.ToDateTime(objReader["DOD"].ToString());
                    }

                    objArtistMaster.ASearchKeywords = objReader["ASearchKeywords"].ToString();
                    objArtistMaster.strOfficialSite = objReader["OfficialSite"].ToString();
 
                    objArtistMaster.strOfficialFaceBook = objReader["OfficialFacebook"].ToString();
                    objArtistMaster.strOfficialTwitter = objReader["OfficialTwitter"].ToString();
                    objArtistMaster.strOfficialYouTube = objReader["OfficialYouTube"].ToString();

                    objArtistMaster.strProfile = objReader["Profile"].ToString();
                    objArtistMaster.strPlaceofDeath = objReader["PlaceofDeath"].ToString();
                    objArtistMaster.strContact = objReader["Contact"].ToString();
                    objArtistMaster.dtLastModifyDate = objReader["LastModifyDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(objReader["LastModifyDate"].ToString());
                    objArtistMaster.strLanguage = objReader["Language"].ToString();
                    objArtistMaster.strGender = String.IsNullOrEmpty(objReader["Gender"].ToString()) ? "0" : objReader["Gender"].ToString();
                    objArtistMaster.strNationality = String.IsNullOrEmpty(objReader["Nationality"].ToString()) ? string.Empty : objReader["Nationality"].ToString();
                    objArtistMaster.strArtisteFolder = objReader["ArtisteFolder"].ToString();
                    objArtistMaster.strArtisteFile = objReader["ArtisteFile"].ToString();
                    objArtistMaster.strArtisteFile1 = objReader["ArtisteFile1"].ToString();
                    objArtistMaster.strArtisteFile2 = objReader["ArtisteFile2"].ToString();
                    objArtistMaster.strMaritalStatus = String.IsNullOrEmpty(objReader["MaritalStatus"].ToString()) ? "0" : objReader["MaritalStatus"].ToString();
                    objArtistMasterList.Add(objArtistMaster);
                    return new ResultClass(true, "Artist Master Present", objArtistMasterList, int.Parse(objReader["ArtistId"].ToString()), null);
                }

                return new ResultClass(false, "Artist Master not found", null, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetArtistMasterById, DBArtistMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetArtistMasterById, DBArtistMasterClass", null, 0, ex);
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

        public ResultClass fn_InsertArtistMaster(ArtistMasterClass objArtistMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strInsertQueryBuilder = new StringBuilder();

                strInsertQueryBuilder.Append("INSERT INTO ArtistMaster ");
                strInsertQueryBuilder.Append("(ArtistName, AlsoKnowAs, Company, Address, DOB, Placeofbirth, DOD, OfficialSite, OfficialFacebook, OfficialTwitter, OfficialYouTube, Profile, PlaceofDeath, Contact, LastModifyDate, Language, Gender, Nationality, ArtisteFolder, ArtisteFile, ArtisteFile1, ArtisteFile2, MaritalStatus, SearchViewCount, ASearchKeywords) ");
                strInsertQueryBuilder.Append("Values");
                strInsertQueryBuilder.Append("(@ArtistName,@AlsoKnowAs, @Company, @Address, @DOB, @Placeofbirth, @DOD, @OfficialSite, @OfficialFacebook, @OfficialTwitter, @OfficialYouTube, @Profile, @PlaceofDeath, @Contact, getdate(), @Language, @Gender, @Nationality, @ArtisteFolder, @ArtisteFile, @ArtisteFile1, @ArtisteFile2, @MaritalStatus, @SearchViewCount, @ASearchKeywords);SELECT @pk_new = @@IDENTITY");
                objCommand = new SqlCommand(strInsertQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@ArtistName", objArtistMasterPassed.strArtistName);
                objCommand.Parameters.AddWithValue("@AlsoKnowAs", objArtistMasterPassed.strAlsoKnowAs);
                objCommand.Parameters.AddWithValue("@Company", objArtistMasterPassed.iCompany);
                objCommand.Parameters.AddWithValue("@Address", objArtistMasterPassed.strAddress);
                if (objArtistMasterPassed.dtDOB != null)
                    objCommand.Parameters.AddWithValue("@DOB", objArtistMasterPassed.dtDOB);
                else
                    objCommand.Parameters.AddWithValue("@DOB", SqlDateTime.Null);    
                objCommand.Parameters.AddWithValue("@Placeofbirth", objArtistMasterPassed.strPlaceofbirth);
               

                if (objArtistMasterPassed.dtDOD != null)
                    objCommand.Parameters.AddWithValue("@DOD", objArtistMasterPassed.dtDOD);
                else
                    objCommand.Parameters.AddWithValue("@DOD", SqlDateTime.Null);

                objCommand.Parameters.AddWithValue("@ASearchKeywords", objArtistMasterPassed.ASearchKeywords);
                objCommand.Parameters.AddWithValue("@OfficialSite", objArtistMasterPassed.strOfficialSite);
                objCommand.Parameters.AddWithValue("@OfficialFacebook", objArtistMasterPassed.strOfficialFaceBook);
                objCommand.Parameters.AddWithValue("@OfficialTwitter", objArtistMasterPassed.strOfficialTwitter);
                objCommand.Parameters.AddWithValue("@OfficialYouTube", objArtistMasterPassed.strOfficialYouTube);
                objCommand.Parameters.AddWithValue("@Profile", objArtistMasterPassed.strProfile);
                objCommand.Parameters.AddWithValue("@PlaceofDeath", objArtistMasterPassed.strPlaceofDeath);
                objCommand.Parameters.AddWithValue("@Contact", objArtistMasterPassed.strContact);
                objCommand.Parameters.AddWithValue("@Language", objArtistMasterPassed.strLanguage);
                objCommand.Parameters.AddWithValue("@Gender", objArtistMasterPassed.strGender);
                objCommand.Parameters.AddWithValue("@Nationality", objArtistMasterPassed.strNationality);
                objCommand.Parameters.AddWithValue("@ArtisteFolder", objArtistMasterPassed.strArtisteFolder);
                objCommand.Parameters.AddWithValue("@ArtisteFile", objArtistMasterPassed.strArtisteFile);
                objCommand.Parameters.AddWithValue("@ArtisteFile1", objArtistMasterPassed.strArtisteFile1);
                objCommand.Parameters.AddWithValue("@ArtisteFile2", objArtistMasterPassed.strArtisteFile2);
                objCommand.Parameters.AddWithValue("@MaritalStatus", objArtistMasterPassed.strMaritalStatus);
                objCommand.Parameters.AddWithValue("@SearchViewCount", CommonClass.GetRandomNumber()); 

                SqlParameter spInsertedKey = new SqlParameter("@pk_new", SqlDbType.Int);
                spInsertedKey.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(spInsertedKey);

                if (objCommand.ExecuteNonQuery() > 0)
                {
                    objArtistMasterPassed.iArtistId = int.Parse(objCommand.Parameters["@pk_new"].Value.ToString());
                    return new ResultClass(true, "Artist Master inserted successfully", objArtistMasterPassed, objArtistMasterPassed.iArtistId, null);
                }
                else
                {
                    return new ResultClass(false, "Artist Master not added", null, 0, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_InsertArtistMaster, DBArtistMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_InsertArtistMaster, DBArtistMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_UpdateArtistMaster(ArtistMasterClass objArtistMasterPassed)
        {
            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();

                StringBuilder strUpdateQueryBuilder = new StringBuilder();

                strUpdateQueryBuilder.Append("UPDATE ArtistMaster ");
                strUpdateQueryBuilder.Append("SET ArtistName= @ArtistName,");
                strUpdateQueryBuilder.Append(" AlsoKnowAs = @AlsoKnowAs,");
                strUpdateQueryBuilder.Append(" Company= @Company,");
                strUpdateQueryBuilder.Append(" Address = @Address,");
                strUpdateQueryBuilder.Append(" DOB = @DOB,");
                strUpdateQueryBuilder.Append(" Placeofbirth = @Placeofbirth,");
                strUpdateQueryBuilder.Append(" DOD = @DOD,");
                strUpdateQueryBuilder.Append(" OfficialSite = @OfficialSite,");

                strUpdateQueryBuilder.Append(" OfficialFacebook = @OfficialFacebook,");
                strUpdateQueryBuilder.Append(" OfficialTwitter = @OfficialTwitter,");
                strUpdateQueryBuilder.Append(" OfficialYouTube = @OfficialYouTube,");

                strUpdateQueryBuilder.Append(" Profile = @Profile,");
                strUpdateQueryBuilder.Append(" PlaceofDeath = @PlaceofDeath,");
                strUpdateQueryBuilder.Append(" Contact = @Contact,");
                strUpdateQueryBuilder.Append(" LastModifyDate = getdate(),");
                strUpdateQueryBuilder.Append(" Language = @Language,");
                strUpdateQueryBuilder.Append(" Gender = @Gender,");
                strUpdateQueryBuilder.Append(" Nationality = @Nationality,");
                strUpdateQueryBuilder.Append(" ArtisteFolder = @ArtisteFolder,");
                strUpdateQueryBuilder.Append(" ArtisteFile = @ArtisteFile, ");
                strUpdateQueryBuilder.Append(" ArtisteFile1 = @ArtisteFile1, ");
                strUpdateQueryBuilder.Append(" ArtisteFile2 = @ArtisteFile2, ");
                strUpdateQueryBuilder.Append(" MaritalStatus = @MaritalStatus, ");
                strUpdateQueryBuilder.Append(" ASearchKeywords = @ASearchKeywords");
                strUpdateQueryBuilder.Append(" WHERE ArtistId = @ArtistId");

                objCommand = new SqlCommand(strUpdateQueryBuilder.ToString(), objConnection);
                objCommand.Parameters.AddWithValue("@ArtistId", objArtistMasterPassed.iArtistId);
                objCommand.Parameters.AddWithValue("@ArtistName", objArtistMasterPassed.strArtistName);
                objCommand.Parameters.AddWithValue("@AlsoKnowAs", objArtistMasterPassed.strAlsoKnowAs);
                objCommand.Parameters.AddWithValue("@Company", objArtistMasterPassed.iCompany);
                objCommand.Parameters.AddWithValue("@Address", objArtistMasterPassed.strAddress);
                if (objArtistMasterPassed.dtDOB != null)
                    objCommand.Parameters.AddWithValue("@DOB", objArtistMasterPassed.dtDOB);
                else
                    objCommand.Parameters.AddWithValue("@DOB", SqlDateTime.Null); 

                objCommand.Parameters.AddWithValue("@Placeofbirth", objArtistMasterPassed.strPlaceofbirth);

                if (objArtistMasterPassed.dtDOD != null)
                    objCommand.Parameters.AddWithValue("@DOD", objArtistMasterPassed.dtDOD);
                else
                    objCommand.Parameters.AddWithValue("@DOD", SqlDateTime.Null);

                objCommand.Parameters.AddWithValue("@ASearchKeywords", objArtistMasterPassed.ASearchKeywords);
                objCommand.Parameters.AddWithValue("@OfficialSite", objArtistMasterPassed.strOfficialSite);

                objCommand.Parameters.AddWithValue("@OfficialFacebook", objArtistMasterPassed.strOfficialFaceBook);
                objCommand.Parameters.AddWithValue("@OfficialTwitter", objArtistMasterPassed.strOfficialTwitter);
                objCommand.Parameters.AddWithValue("@OfficialYouTube", objArtistMasterPassed.strOfficialYouTube);

                objCommand.Parameters.AddWithValue("@Profile", objArtistMasterPassed.strProfile);
                objCommand.Parameters.AddWithValue("@PlaceofDeath", objArtistMasterPassed.strPlaceofDeath);
                objCommand.Parameters.AddWithValue("@Contact", objArtistMasterPassed.strContact);
                objCommand.Parameters.AddWithValue("@Language", objArtistMasterPassed.strLanguage);
                objCommand.Parameters.AddWithValue("@Gender", objArtistMasterPassed.strGender);
                objCommand.Parameters.AddWithValue("@Nationality", objArtistMasterPassed.strNationality);
                objCommand.Parameters.AddWithValue("@ArtisteFolder", objArtistMasterPassed.strArtisteFolder);
                objCommand.Parameters.AddWithValue("@ArtisteFile", objArtistMasterPassed.strArtisteFile);
                objCommand.Parameters.AddWithValue("@ArtisteFile1", objArtistMasterPassed.strArtisteFile1);
                objCommand.Parameters.AddWithValue("@ArtisteFile2", objArtistMasterPassed.strArtisteFile2);
                objCommand.Parameters.AddWithValue("@MaritalStatus", objArtistMasterPassed.strMaritalStatus); 
                if (objCommand.ExecuteNonQuery() > 0)
                {
                    return new ResultClass(true, "Artist Master updated successfully", objArtistMasterPassed, objArtistMasterPassed.iArtistId, null);
                }
                else
                {
                    return new ResultClass(false, "Artist Master not updated", objArtistMasterPassed, objArtistMasterPassed.iArtistId, null);
                }
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception in fn_UpdateArtistMaster, DBArtistMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception in fn_UpdateArtistMaster, DBArtistMasterClass", null, 0, ex);
            }
            finally
            {
                if (objConnection != null)
                {
                    objConnection.Close();
                }
            }
        }

        public ResultClass fn_GetArtistMasterListBySearch(ArtistMasterClass objArtistMasterPassed)
        {
            ArtistMasterClass objArtistMaster = null;
            wwList<ArtistMasterClass> objArtistMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT ArtistId,ArtistName,DOB,AlsoKnowAs FROM ArtistMaster WHERE ArtistName like @ArtistName order by ArtistName ", objConnection);

                objCommand.Parameters.AddWithValue("@ArtistName", "%" + objArtistMasterPassed.strArtistName + "%");

                objReader = objCommand.ExecuteReader();
                objArtistMasterList = new wwList<ArtistMasterClass>();
                while (objReader.Read())
                {
                    objArtistMaster = new ArtistMasterClass();
                    objArtistMaster.iArtistId = int.Parse(objReader["ArtistId"].ToString());
                    objArtistMaster.strArtistName = objReader["ArtistName"].ToString();
                    objArtistMaster.strAlsoKnowAs = objReader["AlsoKnowAs"].ToString();

                    if (!String.IsNullOrEmpty(objReader["DOB"].ToString()))
                    {
                        objArtistMaster.dtDOB = Convert.ToDateTime(objReader["DOB"].ToString());
                    }
                    else
                    {
                        objArtistMaster.dtDOB = DateTime.Today;
                    }
                    objArtistMaster.dtDOD = DateTime.Today;
                    objArtistMasterList.Add(objArtistMaster);
                }

                return new ResultClass(true, "Artist Master List", objArtistMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetArtistMasterList, DBArtistMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetArtistMasterList, DBArtistMasterClass", null, 0, ex);
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

        public ResultClass fn_GetArtistDetailByID(ArtistMasterClass objArtistMasterPassed)
        {
            ArtistMasterClass objArtistMaster = null;
            wwList<ArtistMasterClass> objArtistMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT ArtistId, ArtistName, DOB, DOD FROM ArtistMaster WHERE ArtistId = @ArtistId", objConnection);

                objCommand.Parameters.AddWithValue("@ArtistId", objArtistMasterPassed.iArtistId);

                objReader = objCommand.ExecuteReader();
                objArtistMasterList = new wwList<ArtistMasterClass>();
                while (objReader.Read())
                {
                    objArtistMaster = new ArtistMasterClass();
                    objArtistMaster.iArtistId = int.Parse(objReader["ArtistId"].ToString());
                    objArtistMaster.strArtistName = objReader["ArtistName"].ToString();
                    if (!String.IsNullOrEmpty(objReader["DOB"].ToString()))
                    {
                        objArtistMaster.dtDOB = Convert.ToDateTime(objReader["DOB"].ToString());
                    }
                    else
                    {
                        objArtistMaster.dtDOB = DateTime.Today;
                    }

                    if (!String.IsNullOrEmpty(objReader["DOD"].ToString()))
                    {
                        objArtistMaster.dtDOD = Convert.ToDateTime(objReader["DOD"].ToString());
                    }
                    else
                    {
                        objArtistMaster.dtDOD = DateTime.Today;
                    }

                    objArtistMasterList.Add(objArtistMaster);
                }

                return new ResultClass(true, "Artist Master List", objArtistMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetArtistDetailByID, DBArtistMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetArtistDetailByID, DBArtistMasterClass", null, 0, ex);
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

        public ResultClass fn_GetArtistDetailListByIDs(ArtistMasterClass objArtistMasterPassed)
        {
            ArtistMasterClass objArtistMaster = null;
            wwList<ArtistMasterClass> objArtistMasterList = null;

            try
            {
                //objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DBSessionUser.iYearId].ConnectionString);
                objConnection = new SqlConnection(ConfigurationSettings.AppSettings[DBSessionUser.iYearId]);
                objConnection.Open();
                objCommand = new SqlCommand("SELECT ArtistId,ArtistName,DOB,DOD FROM ArtistMaster WHERE ArtistId in (" + objArtistMasterPassed.strArtistId + ")", objConnection);

                //objCommand.Parameters.AddWithValue("@ArtistId", objArtistMasterPassed.strArtistId);

                objReader = objCommand.ExecuteReader();
                objArtistMasterList = new wwList<ArtistMasterClass>();
                while (objReader.Read())
                {
                    objArtistMaster = new ArtistMasterClass();
                    objArtistMaster.iArtistId = int.Parse(objReader["ArtistId"].ToString());
                    objArtistMaster.strArtistName = objReader["ArtistName"].ToString();
                    if (!String.IsNullOrEmpty(objReader["DOB"].ToString()))
                    {
                        objArtistMaster.dtDOB = Convert.ToDateTime(objReader["DOB"].ToString());
                    }
                    else
                    {
                        objArtistMaster.dtDOB = DateTime.Today;
                    }

                    if (!String.IsNullOrEmpty(objReader["DOD"].ToString()))
                    {
                        objArtistMaster.dtDOD = Convert.ToDateTime(objReader["DOD"].ToString());
                    }
                    else
                    {
                        objArtistMaster.dtDOD = DateTime.Today;
                    }

                    objArtistMasterList.Add(objArtistMaster);
                }

                return new ResultClass(true, "Artist Master List", objArtistMasterList, 0, null);
            }
            catch (SqlException ex)
            {
                return new ResultClass(false, "SQL Exception - fn_GetArtistDetailByID, DBArtistMasterClass", null, 0, ex);
            }
            catch (Exception ex)
            {
                return new ResultClass(false, "General Exception - fn_GetArtistDetailByID, DBArtistMasterClass", null, 0, ex);
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
