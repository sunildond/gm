using System;
using System.Collections.Generic;
using System.Text;
using ww_lib;

namespace ww_admin
{
    public class SubInstitutionMasterClass
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

        public ResultClass fn_InsertSubInstitutionMaster()
        {
            DBSubInstitutionMasterClass objSubInstitutionMaster = new DBSubInstitutionMasterClass();
            return objSubInstitutionMaster.fn_InsertSubInstitutionMaster(this);
        }

        public ResultClass fn_UpdateSubInstitutionMaster()
        {
            DBSubInstitutionMasterClass objSubInstitutionMaster = new DBSubInstitutionMasterClass();
            return objSubInstitutionMaster.fn_UpdateSubInstitutionMaster(this);
        }

        public ResultClass fn_GetSubInstitutionMasterList()
        {
            DBSubInstitutionMasterClass objSubInstitutionMaster = new DBSubInstitutionMasterClass();
            return objSubInstitutionMaster.fn_GetSubInstitutionMasterList(this);
        }

        public ResultClass fn_GetActiveSubInstitutionMasterList()
        {
            DBSubInstitutionMasterClass objSubInstitutionMaster = new DBSubInstitutionMasterClass();
            return objSubInstitutionMaster.fn_GetActiveSubInstitutionMasterList(this);
        }

        public ResultClass fn_GetSubInstitutionMasterById()
        {
            DBSubInstitutionMasterClass objSubInstitutionMaster = new DBSubInstitutionMasterClass();
            return objSubInstitutionMaster.fn_GetSubInstitutionMasterById(this);
        }

        public ResultClass fn_DeleteSubInstitutionMaster()
        {
            DBSubInstitutionMasterClass objSubInstitutionMaster = new DBSubInstitutionMasterClass();
            return objSubInstitutionMaster.fn_DeleteSubInstitutionMaster(this);
        }

        #endregion

    }
}
