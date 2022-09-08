using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.APIUtils.Models
{
    public class APIResponseSingle<T> : APIResponse
    {
        #region MEMBER_VARIABLES
        private T _data;
        #endregion

        #region PROPERTIES
        public T Data
        {
            get { return _data; }
            set
            {
                if (!EqualityComparer<T>.Default.Equals(_data, value))
                {
                    _data = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public APIResponseSingle()
        {
            Succeeded = false;
            StatusCode = 0;
            Message = string.Empty;
        }

        public APIResponseSingle(T data, int statusCode)
        {
            Succeeded = true;
            StatusCode = statusCode;
            Message = string.Empty;
            Data = data;
        }

        public APIResponseSingle(int statusCode, string message)
        {
            Succeeded = false;
            StatusCode = statusCode;
            Message = message;
        }
        #endregion
    }
}
