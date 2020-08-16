using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ww_lib;
using ww_admin;

namespace ww_lib
{
    public class DBSessionUser
    {
        string strLogFileName = "LOG\\LogRecord.txt";
        //public static int _ID = -1;
        private static string _iYearId = "";
        private static int _iUser_Id = -1;
        private static int _iUser_Type = -1;
        private static string _strName = "";
        private static string _strUser_Name = "";
        private static string _strPassword = ""; 
        private static string _strUserLocation = "";
        private static bool _bAddPerm = false;
        private static bool _bEditPerm = false;

        private static bool _bIsAuthorise = false;

        //public static int ID
        //{
        //    get { return _ID; }
        //    set { _ID = value; }
        //}

        public static bool bIsAuthorise
        {
            get { return _bIsAuthorise; }
            set { _bIsAuthorise = value; }
        }

        public static bool bAddPerm
        {
            get { return _bAddPerm; }
            set { _bAddPerm = value; }
        }

        public static bool bEditPerm
        {
            get { return _bEditPerm; }
            set { _bEditPerm = value; }
        }

        public static string iYearId
        {
            get { return _iYearId; }
            set { _iYearId = value; }
        }

        public static int iUser_Id
        {
            get { return _iUser_Id; }
            set { _iUser_Id = value; }
        }
        public static int iUser_Type
        {
            get { return _iUser_Type; }
            set { _iUser_Type = value; }
        }
        public static string strName
        {
            get { return _strName; }
            set { _strName = value; }
        }
        public static string strUser_Name
        {
            get { return _strUser_Name; }
            set { _strUser_Name = value; }
        }
        public static string strPassword
        {
            get { return _strPassword; }
            set { _strPassword = value; }
        }

        public static string strUserLocation
        {
            get { return _strUserLocation; }
            set { _strUserLocation = value; }
        }

    }
}
