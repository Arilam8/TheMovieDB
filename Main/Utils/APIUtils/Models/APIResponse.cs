using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.APIUtils.Models
{
    public class APIResponse
    {
        #region MEMBER_VARIABLES
        private bool _succeeded;
        private int _statusCode;
        private string _message;
        #endregion

        #region PROPERTIES
        public bool Succeeded
        {
            get { return _succeeded; }
            set
            {
                if (_succeeded != value)
                {
                    _succeeded = value;
                }
            }
        }

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
        public APIResponse()
        {
            Succeeded = false;
            StatusCode = 0;
            Message = string.Empty;
        }

        public APIResponse(bool succeeded, int statusCode, string message)
        {
            Succeeded = succeeded;
            StatusCode = statusCode;
            Message = message;
        }
        #endregion
    }
}
