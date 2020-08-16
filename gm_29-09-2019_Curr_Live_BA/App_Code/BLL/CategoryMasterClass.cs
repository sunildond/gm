using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ww_lib;

namespace ww_admin
{
    public class CategoryMasterClass
    {
        #region "Properties"

        private int _iCategoryId = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iCategoryId
        {
            get
            {
                return _iCategoryId;
            }
            set
            {
                _iCategoryId = value;
            }
        }

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

        public ResultClass fn_InsertCategoryMaster()
        {
            DBCategoryMasterClass objCategoryMaster = new DBCategoryMasterClass();
            return objCategoryMaster.fn_InsertCategoryMaster(this);
        }

        public ResultClass fn_UpdateCategoryMaster()
        {
            DBCategoryMasterClass objCategoryMaster = new DBCategoryMasterClass();
            return objCategoryMaster.fn_UpdateCategoryMaster(this);
        }

        public ResultClass fn_GetCategoryMasterList()
        {
            DBCategoryMasterClass objCategoryMaster = new DBCategoryMasterClass();
            return objCategoryMaster.fn_GetCategoryMasterList(this);
        }

        public ResultClass fn_GetCategoryMasterById()
        {
            DBCategoryMasterClass objCategoryMaster = new DBCategoryMasterClass();
            return objCategoryMaster.fn_GetCategoryMasterById(this);
        }

        public ResultClass fn_GetActiveCategoryMasterList()
        {
            DBCategoryMasterClass objCategoryMaster = new DBCategoryMasterClass();
            return objCategoryMaster.fn_GetActiveCategoryMasterList(this);
        }

        public ResultClass fn_DeleteCategory()
        {
            DBCategoryMasterClass objCategoryMaster = new DBCategoryMasterClass();
            return objCategoryMaster.fn_DeleteCategory(this);
        }

        #endregion

    }
}
