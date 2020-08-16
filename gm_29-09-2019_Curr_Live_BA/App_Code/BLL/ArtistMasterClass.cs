using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ww_lib;
/// <summary>
/// Summary description for ArtistMasterClass
/// </summary>
/// 

namespace ww_admin
{
    public class ArtistMasterClass
    {
        public ArtistMasterClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        #region "Properties"

        private int _iArtistId = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iArtistId
        {
            get
            {
                return _iArtistId;
            }
            set
            {
                _iArtistId = value;
            }
        }

        private string _strArtistId = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strArtistId
        {
            get
            {
                return _strArtistId;
            }
            set
            {
                _strArtistId = value;
            }
        }

        private string _strArtistName = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strArtistName
        {
            get
            {
                return _strArtistName;
            }
            set
            {
                _strArtistName = value;
            }
        }


        private string _strAlsoKnowAs = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strAlsoKnowAs
        {
            get
            {
                return _strAlsoKnowAs;
            }
            set
            {
                _strAlsoKnowAs = value;
            }
        }


        private int _iCompany = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public int iCompany
        {
            get
            {
                return _iCompany;
            }
            set
            {
                _iCompany = value;
            }
        }


        private string _strAddress = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strAddress
        {
            get
            {
                return _strAddress;
            }
            set
            {
                _strAddress = value;
            }
        }


        private DateTime? _dtDOB = null;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public DateTime? dtDOB
        {
            get
            {
                return _dtDOB;
            }
            set
            {
                _dtDOB = value;
            }
        }


        //private string _strDOB = string.Empty;
        //[Conversion(DataTableConversion = true, AllowDbNull = true)]
        //public string strDOB
        //{
        //    get
        //    {
        //        return _strDOB;
        //    }
        //    set
        //    {
        //        _strDOB = value;
        //    }
        //}


        private string _strPlaceofbirth = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strPlaceofbirth
        {
            get
            {
                return _strPlaceofbirth;
            }
            set
            {
                _strPlaceofbirth = value;
            }
        }

        private DateTime? _dtDOD = null;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public DateTime? dtDOD
        {
            get
            {
                return _dtDOD;
            }
            set
            {
                _dtDOD = value;
            }
        }


        //private string _strDOD = string.Empty;
        //[Conversion(DataTableConversion = true, AllowDbNull = true)]
        //public string strDOD
        //{
        //    get
        //    {
        //        return _strDOD;
        //    }
        //    set
        //    {
        //        _strDOD = value;
        //    }
        //}

        private string _strPlaceofDeath = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strPlaceofDeath
        {
            get
            {
                return _strPlaceofDeath;
            }
            set
            {
                _strPlaceofDeath = value;
            }
        }


        private string _strOfficialSite = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strOfficialSite
        {
            get
            {
                return _strOfficialSite;
            }
            set
            {
                _strOfficialSite = value;
            }
        }

        private string _strOfficialFaceBook = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strOfficialFaceBook
        {
            get
            {
                return _strOfficialFaceBook;
            }
            set
            {
                _strOfficialFaceBook = value;
            }
        }

        private string _strOfficialTwitter = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strOfficialTwitter
        {
            get
            {
                return _strOfficialTwitter;
            }
            set
            {
                _strOfficialTwitter = value;
            }
        }

        private string _strOfficialYouTube = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strOfficialYouTube
        {
            get
            {
                return _strOfficialYouTube;
            }
            set
            {
                _strOfficialYouTube = value;
            }
        }

        private string _strProfile = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strProfile
        {
            get
            {
                return _strProfile;
            }
            set
            {
                _strProfile = value;
            }
        }


        private string _strContact = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strContact
        {
            get
            {
                return _strContact;
            }
            set
            {
                _strContact = value;
            }
        }

        private DateTime _dtLastModifyDate = DateTime.Now;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public DateTime dtLastModifyDate
        {
            get
            {
                return _dtLastModifyDate;
            }
            set
            {
                _dtLastModifyDate = value;
            }
        }


        private string _strLanguage = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strLanguage
        {
            get
            {
                return _strLanguage;
            }
            set
            {
                _strLanguage = value;
            }
        }


        private string _strGender = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strGender
        {
            get
            {
                return _strGender;
            }
            set
            {
                _strGender = value;
            }
        }

        private string _strNationality = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strNationality
        {
            get
            {
                return _strNationality;
            }
            set
            {
                _strNationality = value;
            }
        }


        private string _strArtisteFolder = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strArtisteFolder
        {
            get
            {
                return _strArtisteFolder;
            }
            set
            {
                _strArtisteFolder = value;
            }
        }


        private string _strArtisteFile = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strArtisteFile
        {
            get
            {
                return _strArtisteFile;
            }
            set
            {
                _strArtisteFile = value;
            }
        }


        private string _strArtisteFile1 = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strArtisteFile1
        {
            get
            {
                return _strArtisteFile1;
            }
            set
            {
                _strArtisteFile1 = value;
            }
        }

        private string _strArtisteFile2 = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strArtisteFile2
        {
            get
            {
                return _strArtisteFile2;
            }
            set
            {
                _strArtisteFile2 = value;
            }
        }


        private string _strMaritalStatus = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strMaritalStatus
        {
            get
            {
                return _strMaritalStatus;
            }
            set
            {
                _strMaritalStatus = value;
            }
        }


        private string _strSearchKeyword = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string strSearchKeyword
        {
            get
            {
                return _strSearchKeyword;
            }
            set
            {
                _strSearchKeyword = value;
            }
        }

        private string _ASearchKeywords = string.Empty;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public string ASearchKeywords
        {
            get
            {
                return _ASearchKeywords;
            }
            set
            {
                _ASearchKeywords = value;
            }
        }

        #endregion

        #region "Functions"

        public ResultClass fn_GetArtistMasterList()
        {
            DBArtistMasterClass objArtistMaster = new DBArtistMasterClass();
            return objArtistMaster.fn_GetArtistMasterList(this);
        }

        public ResultClass fn_SelectArtistByMultipleArtistId()
        {
            DBArtistMasterClass objArtistMaster = new DBArtistMasterClass();
            return objArtistMaster.fn_SelectArtistByMultipleArtistId(this);
        }

        public ResultClass fn_GetArtistMasterById()
        {
            DBArtistMasterClass objArtistMaster = new DBArtistMasterClass();
            return objArtistMaster.fn_GetArtistMasterById(this);
        }

        public ResultClass fn_InsertArtistMaster()
        {
            DBArtistMasterClass objArtistMaster = new DBArtistMasterClass();
            return objArtistMaster.fn_InsertArtistMaster(this);
        }

        public ResultClass fn_UpdateArtistMaster()
        {
            DBArtistMasterClass objArtistMaster = new DBArtistMasterClass();
            return objArtistMaster.fn_UpdateArtistMaster(this);
        }

        public ResultClass fn_GetArtistMasterListBySearch()
        {
            DBArtistMasterClass objArtistMaster = new DBArtistMasterClass();
            return objArtistMaster.fn_GetArtistMasterListBySearch(this);
        }

        public ResultClass fn_GetArtistDetailByID()
        {
            DBArtistMasterClass objArtistMaster = new DBArtistMasterClass();
            return objArtistMaster.fn_GetArtistDetailByID(this);
        }

        public ResultClass fn_GetArtistDetailListByIDs()
        {
            DBArtistMasterClass objArtistMaster = new DBArtistMasterClass();
            return objArtistMaster.fn_GetArtistDetailListByIDs(this);
        }

        #endregion

    }
}


