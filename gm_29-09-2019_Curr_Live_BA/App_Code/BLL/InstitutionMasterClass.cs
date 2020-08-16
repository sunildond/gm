using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ww_lib;

namespace ww_admin
{
    public class InstitutionMasterClass
    {
        #region "Properties"

        private int _iCode = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iCode
        {
            get
            {
                return _iCode;
            }
            set
            {
                _iCode = value;
            }
        }

        private string _strName = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strName
        {
            get
            {
                return _strName;
            }
            set
            {
                _strName = value;
            }
        }

        private string _strIsActive = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strIsActive
        {
            get
            {
                return _strIsActive;
            }
            set
            {
                _strIsActive = value;
            }
        }

        private DateTime _dtLastModify = DateTime.Now;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public DateTime dtLastModify
        {
            get
            {
                return _dtLastModify;
            }
            set
            {
                _dtLastModify = value;
            }
        }

        #endregion

        #region "Functions"

        public ResultClass fn_InsertInstitutionMaster()
        {
            DBInstitutionMasterClass objInstitutionMaster = new DBInstitutionMasterClass();
            return objInstitutionMaster.fn_InsertInstitutionMaster(this);
        }

        public ResultClass fn_UpdateInstitutionMaster()
        {
            DBInstitutionMasterClass objInstitutionMaster = new DBInstitutionMasterClass();
            return objInstitutionMaster.fn_UpdateInstitutionMaster(this);
        }

        public ResultClass fn_GetInstitutionMasterList()
        {
            DBInstitutionMasterClass objInstitutionMaster = new DBInstitutionMasterClass();
            return objInstitutionMaster.fn_GetInstitutionMasterList(this);
        }

        public ResultClass fn_GetActiveInstitutionMasterList()
        {
            DBInstitutionMasterClass objInstitutionMaster = new DBInstitutionMasterClass();
            return objInstitutionMaster.fn_GetActiveInstitutionMasterList(this);
        }

        public ResultClass fn_GetInstitutionMasterById()
        {
            DBInstitutionMasterClass objInstitutionMaster = new DBInstitutionMasterClass();
            return objInstitutionMaster.fn_GetInstitutionMasterById(this);
        }

        public ResultClass fn_DeleteInstitutionMaster()
        {
            DBInstitutionMasterClass objInstitutionMaster = new DBInstitutionMasterClass();
            return objInstitutionMaster.fn_DeleteInstitutionMaster(this);
        }

        #endregion

    }
}
