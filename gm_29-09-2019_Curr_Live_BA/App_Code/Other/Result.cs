using System;

namespace ww_admin
{
    /// <summary>
    /// Handle Trasaction with database.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Result Class for each database transaction
        /// </summary>
        /// <param name="_bStatus">Status (Boolean)</param>
        /// <param name="_strMessage">Message (String)</param>
        /// <param name="_iRecordId">Updates Record Id (Integer)</param>
        /// <param name="_eException">Exception Object</param>

        public Result(bool _bStatus, string _strMessage, int _iRecordId, Exception _eException)
        {
            bStatus = _bStatus;
            strMessage = _strMessage;
            eException = _eException;
            iRecordId = _iRecordId;
        }
        
        /// <summary>
        /// DAL Transaction Message
        /// </summary>
        private string _strMessage = "";
        public string strMessage
        {
            get
            {
                return _strMessage;
            }
            set
            {
                _strMessage = value;
            }
        }
        /// <summary>
        /// DAL Transaction Status
        /// </summary>
        private bool _bStatus = false;
        public bool bStatus
        {
            get
            {
                return _bStatus;
            }
            set
            {
                _bStatus = value;
            }
        }
        /// <summary>
        /// DAL Transaction RecordID
        /// </summary>
        private int _iRecordId = 0;
        public int iRecordId
        {
            get
            {
                return _iRecordId;
            }
            set
            {
                _iRecordId = value;
            }
        }
        /// <summary>
        /// DAL Transaction Exception Object
        /// </summary>
        private Exception _eException = null;
        public Exception eException
        {
            get
            {
                return _eException;
            }
            set
            {
                _eException = value;
            }
        }
    }
}
