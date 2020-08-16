using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ww_lib;

namespace ww_admin
{
    public class DSM_ZSMClass
    {
        #region "Properties"

        private int _iId = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iId
        {
            get
            {
                return _iId;
            }
            set
            {
                _iId = value;
            }
        }

        private string _strCode = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strCode
        {
            get
            {
                return _strCode;
            }
            set
            {
                _strCode = value;
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

        public ResultClass fn_InsertDSM_ZSM()
        {
            DBDSM_ZSMClass objDSM_ZSM = new DBDSM_ZSMClass();
            return objDSM_ZSM.fn_InsertDSM_ZSM(this);
        }

        public ResultClass fn_UpdateDSM_ZSM()
        {
            DBDSM_ZSMClass objDSM_ZSM = new DBDSM_ZSMClass();
            return objDSM_ZSM.fn_UpdateDSM_ZSM(this);
        }

        public ResultClass fn_GetDSM_ZSMList()
        {
            DBDSM_ZSMClass objDSM_ZSM = new DBDSM_ZSMClass();
            return objDSM_ZSM.fn_GetDSM_ZSMList(this);
        }

        public ResultClass fn_GetDSM_ZSMById()
        {
            DBDSM_ZSMClass objDSM_ZSM = new DBDSM_ZSMClass();
            return objDSM_ZSM.fn_GetDSM_ZSMById(this);
        }

        public ResultClass fn_GetActiveDSM_ZSMList()
        {
            DBDSM_ZSMClass objDSM_ZSM = new DBDSM_ZSMClass();
            return objDSM_ZSM.fn_GetActiveDSM_ZSMList(this);
        }

        public ResultClass fn_DeleteDSM_ZSM()
        {
            DBDSM_ZSMClass objDSM_ZSM = new DBDSM_ZSMClass();
            return objDSM_ZSM.fn_DeleteDSM_ZSM(this);
        }

        #endregion

    }
}
