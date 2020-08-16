using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ww_lib;

namespace ww_admin
{
    public class OrderHeaderClass
    {
        #region "Properties"

        private int _iIOMNo = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iIOMNo
        {
            get
            {
                return _iIOMNo;
            }
            set
            {
                _iIOMNo = value;
            }
        }

        private DateTime _dtIOMDate = DateTime.Now;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public DateTime dtIOMDate
        {
            get
            {
                return _dtIOMDate;
            }
            set
            {
                _dtIOMDate = value;
            }
        }

        private DateTime _dtOrderAuthoDate = DateTime.Now;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public DateTime dtOrderAuthoDate
        {
            get
            {
                return _dtOrderAuthoDate;
            }
            set
            {
                _dtOrderAuthoDate = value;
            }
        }

        private string _strPartyCode = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strPartyCode
        {
            get
            {
                return _strPartyCode;
            }
            set
            {
                _strPartyCode = value;
            }
        }

        private string _strPartyName = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strPartyName
        {
            get
            {
                return _strPartyName;
            }
            set
            {
                _strPartyName = value;
            }
        }

        private string _strDSM_ZSM = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strDSM_ZSM
        {
            get
            {
                return _strDSM_ZSM;
            }
            set
            {
                _strDSM_ZSM = value;
            }
        }

        private string _strDispThrough = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strDispThrough
        {
            get
            {
                return _strDispThrough;
            }
            set
            {
                _strDispThrough = value;
            }
        }

        private string _strInstPONo = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strInstPONo
        {
            get
            {
                return _strInstPONo;
            }
            set
            {
                _strInstPONo = value;
            }
        }

        private DateTime _dtInstPODate = DateTime.Now;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public DateTime dtInstPODate
        {
            get
            {
                return _dtInstPODate;
            }
            set
            {
                _dtInstPODate = value;
            }
        }

        private DateTime _dtReqDelDate = DateTime.Now;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public DateTime dtReqDelDate
        {
            get
            {
                return _dtReqDelDate;
            }
            set
            {
                _dtReqDelDate = value;
            }
        }

        private string _strStaggered_Immediate = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strStaggered_Immediate
        {
            get
            {
                return _strStaggered_Immediate;
            }
            set
            {
                _strStaggered_Immediate = value;
            }
        }

        private string _strStagDueOn = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strStagDueOn
        {
            get
            {
                return _strStagDueOn;
            }
            set
            {
                _strStagDueOn = value;
            }
        }

        private string _strInstitution = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strInstitution
        {
            get
            {
                return _strInstitution;
            }
            set
            {
                _strInstitution = value;
            }
        }

        private string _strSubInstitution = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strSubInstitution
        {
            get
            {
                return _strSubInstitution;
            }
            set
            {
                _strSubInstitution = value;
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

        public ResultClass fn_InsertCustomerMaster()
        {
            DBOrderHeaderClass objOrderHeader = new DBOrderHeaderClass();
            return objOrderHeader.fn_InsertOrderHeader(this);
        }

        public ResultClass fn_UpdateOrderHeader()
        {
            DBOrderHeaderClass objOrderHeader = new DBOrderHeaderClass();
            return objOrderHeader.fn_UpdateOrderHeader(this);
        }

        public ResultClass fn_GetOrderHeaderList()
        {
            DBOrderHeaderClass objOrderHeader = new DBOrderHeaderClass();
            return objOrderHeader.fn_GetOrderHeaderList(this);
        }

        public ResultClass fn_GetOrderHeaderById()
        {
            DBOrderHeaderClass objOrderHeader = new DBOrderHeaderClass();
            return objOrderHeader.fn_GetOrderHeaderById(this);
        }

        #endregion


    }
}
