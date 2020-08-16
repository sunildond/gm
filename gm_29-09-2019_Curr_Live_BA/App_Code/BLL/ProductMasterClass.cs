using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ww_lib;

namespace ww_admin
{
    public class ProductMasterClass
    {
        #region "Properties"

        private int _iProductId = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iProductId
        {
            get
            {
                return _iProductId;
            }
            set
            {
                _iProductId = value;
            }
        }

        private string _strMaterial = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strMaterial
        {
            get
            {
                return _strMaterial;
            }
            set
            {
                _strMaterial = value;
            }
        }

        private string _strDescription = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strDescription
        {
            get
            {
                return _strDescription;
            }
            set
            {
                _strDescription = value;
            }
        }

        private int _iAliscode = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iAliscode
        {
            get
            {
                return _iAliscode;
            }
            set
            {
                _iAliscode = value;
            }
        }

        private int _iUnit = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iUnit
        {
            get
            {
                return _iUnit;
            }
            set
            {
                _iUnit = value;
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

        public ResultClass fn_InsertProductMaster()
        {
            DBProductMasterClass objProductMaster = new DBProductMasterClass();
            return objProductMaster.fn_InsertProductMaster(this);
        }

        public ResultClass fn_UpdateProductMaster()
        {
            DBProductMasterClass objProductMaster = new DBProductMasterClass();
            return objProductMaster.fn_UpdateProductMaster(this);
        }

        public ResultClass fn_GetProductMasterList()
        {
            DBProductMasterClass objProductMaster = new DBProductMasterClass();
            return objProductMaster.fn_GetProductMasterList(this);
        }

        public ResultClass fn_GetProductMasterById()
        {
            DBProductMasterClass objProductMaster = new DBProductMasterClass();
            return objProductMaster.fn_GetProductMasterById(this);
        }

        #endregion

    }
}
