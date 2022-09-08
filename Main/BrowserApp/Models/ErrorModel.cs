using DataTransferObject;
using System.Configuration;
using System;

namespace BrowserApp.Models
{
    public class ErrorModel
    {
        #region MEMBER_VARIABLES
        private int _statusCode;
        private string _message;
        #endregion

        #region PROPERTIES
        public int StatusCode
        {
            get { return _statusCode; }
            set
            {
                if (_statusCode != value)
                {
                    _statusCode = value;
                }
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public ErrorModel()
        {
            StatusCode = 0;
            Message = string.Empty;
        }

        public ErrorModel(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        #endregion
    }
}
