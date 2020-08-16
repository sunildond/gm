using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ww_lib;

namespace ww_admin
{
    public class LocationMasterClass
    {
        #region "Properties"

        private int _iLocationId = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iLocationId
        {
            get
            {
                return _iLocationId;
            }
            set
            {
                _iLocationId = value;
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

        private int _iStateCode = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iStateCode
        {
            get
            {
                return _iStateCode;
            }
            set
            {
                _iStateCode = value;
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

        public ResultClass fn_InsertLocationMaster()
        {
            DBLocationMasterClass objLocationMaster = new DBLocationMasterClass();
            return objLocationMaster.fn_InsertLocationMaster(this);
        }

        public ResultClass fn_UpdateLocationMaster()
        {
            DBLocationMasterClass objLocationMaster = new DBLocationMasterClass();
            return objLocationMaster.fn_UpdateLocationMaster(this);
        }

        public ResultClass fn_GetLocationMasterList()
        {
            DBLocationMasterClass objLocationMaster = new DBLocationMasterClass();
            return objLocationMaster.fn_GetLocationMasterList(this);
        }

        public ResultClass fn_GetActiveLocationMasterList()
        {
            DBLocationMasterClass objLocationMaster = new DBLocationMasterClass();
            return objLocationMaster.fn_GetActiveLocationMasterList(this);
        }

        public ResultClass fn_GetLocationMasterById()
        {
            DBLocationMasterClass objLocationMaster = new DBLocationMasterClass();
            return objLocationMaster.fn_GetLocationMasterById(this);
        }

        public ResultClass fn_DeleteLocationMaster()
        {
            DBLocationMasterClass objLocationMaster = new DBLocationMasterClass();
            return objLocationMaster.fn_DeleteLocationMaster(this);
        }

        #endregion

    }
}