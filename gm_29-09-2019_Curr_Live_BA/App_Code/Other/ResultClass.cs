using System;

namespace ww_admin
{
    /// <summary>
    /// Handle Trasaction with database.
    /// </summary>
        public class ResultClass
        {
            /// <summary>
            /// Result Class for each database transaction
            /// </summary>
            /// <param name="_bStatus">Status (Boolean)</param>
            /// <param name="_strMessage">Message (String)</param>
            /// <param name="_objData">Data (Object)</param>
            /// <param name="_iRecordId">Updates Record Id (Integer)</param>
            /// <param name="_eException">Exception Object</param>
            
            public ResultClass(bool _bStatus, string _strMessage, object _objData, int _iRecordId, Exception _eException)
            {
                bStatus = _bStatus;
                strMessage = _strMessage;
                eException = _eException;
                iRecordId = _iRecordId;
                objData = _objData;
            }

            /// <summary>
            /// DAL Transaction Object
            /// </summary>
            private object _objData = null;
            public object objData
            {
                get
                {
                    return _objData;
                }
                set
                {
                    _objData = value;
                }
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
