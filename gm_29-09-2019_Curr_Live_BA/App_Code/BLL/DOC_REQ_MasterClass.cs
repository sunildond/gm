using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ww_lib;

namespace ww_admin
{
    public class DOC_REQ_MasterClass
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

        public ResultClass fn_InsertDOC_REQ_Master()
        {
            DBDOC_REQ_MasterClass objDOC_REQ_Master = new DBDOC_REQ_MasterClass();
            return objDOC_REQ_Master.fn_InsertDOC_REQ_Master(this);
        }

        public ResultClass fn_UpdateDOC_REQ_Master()
        {
            DBDOC_REQ_MasterClass objDOC_REQ_Master = new DBDOC_REQ_MasterClass();
            return objDOC_REQ_Master.fn_UpdateDOC_REQ_Master(this);
        }

        public ResultClass fn_GetDOC_REQ_MasterList()
        {
            DBDOC_REQ_MasterClass objDOC_REQ_Master = new DBDOC_REQ_MasterClass();
            return objDOC_REQ_Master.fn_GetDOC_REQ_MasterList(this);
        }

        public ResultClass fn_GetActiveDOC_REQ_MasterList()
        {
            DBDOC_REQ_MasterClass objDOC_REQ_Master = new DBDOC_REQ_MasterClass();
            return objDOC_REQ_Master.fn_GetActiveDOC_REQ_MasterList(this);
        }

        public ResultClass fn_GetDOC_REQ_MasterById()
        {
            DBDOC_REQ_MasterClass objDOC_REQ_Master = new DBDOC_REQ_MasterClass();
            return objDOC_REQ_Master.fn_GetDOC_REQ_MasterById(this);
        }

        public ResultClass fn_DeleteDOC_REQ_Master()
        {
            DBDOC_REQ_MasterClass objDOC_REQ_Master = new DBDOC_REQ_MasterClass();
            return objDOC_REQ_Master.fn_DeleteDOC_REQ_Master(this);
        }

        #endregion

    }
}
