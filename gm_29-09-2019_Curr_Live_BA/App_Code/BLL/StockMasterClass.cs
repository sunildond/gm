using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ww_lib;

namespace ww_admin
{
    public class StockMasterClass
    {
        #region "Properties"

        private int _iStockId = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iStockId
        {
            get
            {
                return _iStockId;
            }
            set
            {
                _iStockId = value;
            }
        }

        private string _strPlnt = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strPlnt
        {
            get
            {
                return _strPlnt;
            }
            set
            {
                _strPlnt = value;
            }
        }

        private string _strSLoc = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strSLoc
        {
            get
            {
                return _strSLoc;
            }
            set
            {
                _strSLoc = value;
            }
        }

        private int _iDv = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iDv
        {
            get
            {
                return _iDv;
            }
            set
            {
                _iDv = value;
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

        private string _strBatch = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strBatch
        {
            get
            {
                return _strBatch;
            }
            set
            {
                _strBatch = value;
            }
        }

        private int _iUnrestricted = 0;
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public int iUnrestricted
        {
            get
            {
                return _iUnrestricted;
            }
            set
            {
                _iUnrestricted = value;
            }
        }
                
        private string _strUnrestricted1 = "";
        [Conversion(DataTableConversion = true, AllowDbNull = false)]
        public string strUnrestricted1
        {
            get
            {
                return _strUnrestricted1;
            }
            set
            {
                _strUnrestricted1 = value;
            }
        }

        private DateTime _dtShelfLifeExpDate = DateTime.Now;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public DateTime dtShelfLifeExpDate
        {
            get
            {
                return _dtShelfLifeExpDate;
            }
            set
            {
                _dtShelfLifeExpDate = value;
            }
        }

        private DateTime _dtInspDate = DateTime.Now;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public DateTime dtInspDate
        {
            get
            {
                return _dtInspDate;
            }
            set
            {
                _dtInspDate = value;
            }
        }

        private DateTime _dtProdDate = DateTime.Now;
        [Conversion(DataTableConversion = true, AllowDbNull = true)]
        public DateTime dtProdDate
        {
            get
            {
                return _dtProdDate;
            }
            set
            {
                _dtProdDate = value;
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

        public ResultClass fn_InsertStockMaster()
        {
            DBStockMasterClass objStockMaster = new DBStockMasterClass();
            return objStockMaster.fn_InsertStockMaster(this);
        }

        public ResultClass fn_UpdateStockMaster()
        {
            DBStockMasterClass objStockMaster = new DBStockMasterClass();
            return objStockMaster.fn_UpdateStockMaster(this);
        }

        public ResultClass fn_GetStockMasterList()
        {
            DBStockMasterClass objStockMaster = new DBStockMasterClass();
            return objStockMaster.fn_GetStockMasterList(this);
        }

        public ResultClass fn_GetStockMasterById()
        {
            DBStockMasterClass objStockMaster = new DBStockMasterClass();
            return objStockMaster.fn_GetStockMasterById(this);
        }

        #endregion

    }

}
