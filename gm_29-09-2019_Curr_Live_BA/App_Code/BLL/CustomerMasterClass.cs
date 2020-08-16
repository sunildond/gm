using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ww_lib;

namespace ww_admin
{
    public class CustomerMasterClass
    {
        #region "Properties"

        private int _iCustomerId = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iCustomerId
        {
            get
            {
                return _iCustomerId;
            }
            set
            {
                _iCustomerId = value;
            }
        }

        private string _strCustomer = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strCustomer
        {
            get
            {
                return _strCustomer;
            }
            set
            {
                _strCustomer = value;
            }
        }

        private string _strName1 = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strName1
        {
            get
            {
                return _strName1;
            }
            set
            {
                _strName1 = value;
            }
        }

        private string _strCity = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strCity
        {
            get
            {
                return _strCity;
            }
            set
            {
                _strCity = value;
            }
        }

        private int _iRg = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iRg
        {
            get
            {
                return _iRg;
            }
            set
            {
                _iRg = value;
            }
        }

        private string _strStreet = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strStreet
        {
            get
            {
                return _strStreet;
            }
            set
            {
                _strStreet = value;
            }
        }

        private string _strStreet4 = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strStreet4
        {
            get
            {
                return _strStreet4;
            }
            set
            {
                _strStreet4 = value;
            }
        }

        private string _strStreet5 = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strStreet5
        {
            get
            {
                return _strStreet5;
            }
            set
            {
                _strStreet5 = value;
            }
        }

        private string _strStreet3 = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strStreet3
        {
            get
            {
                return _strStreet3;
            }
            set
            {
                _strStreet3 = value;
            }
        }

        private string _strPostalCode = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strPostalCode
        {
            get
            {
                return _strPostalCode;
            }
            set
            {
                _strPostalCode = value;
            }
        }

        private string _strVATregistrationNo = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strVATregistrationNo
        {
            get
            {
                return _strVATregistrationNo;
            }
            set
            {
                _strVATregistrationNo = value;
            }
        }

        private string _strCSTnumber = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strCSTnumber
        {
            get
            {
                return _strCSTnumber;
            }
            set
            {
                _strCSTnumber = value;
            }
        }

        private string _strLSTnumber = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strLSTnumber
        {
            get
            {
                return _strLSTnumber;
            }
            set
            {
                _strLSTnumber = value;
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
            DBCustomerMasterClass objCustomerMaster = new DBCustomerMasterClass();
            return objCustomerMaster.fn_InsertCustomerMaster(this);
        }

        public ResultClass fn_UpdateCustomerMaster()
        {
            DBCustomerMasterClass objCustomerMaster = new DBCustomerMasterClass();
            return objCustomerMaster.fn_UpdateCustomerMaster(this);
        }

        public ResultClass fn_GetCustomerMasterList()
        {
            DBCustomerMasterClass objCustomerMaster = new DBCustomerMasterClass();
            return objCustomerMaster.fn_GetCustomerMasterList(this);
        }

        public ResultClass fn_GetCustomerMasterById()
        {
            DBCustomerMasterClass objCustomerMaster = new DBCustomerMasterClass();
            return objCustomerMaster.fn_GetCustomerMasterById(this);
        }

        #endregion


    }
}
