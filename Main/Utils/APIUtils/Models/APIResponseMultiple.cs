using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.APIUtils.Models
{
    public class APIResponseMultiple<T> : APIResponse
    {
        #region MEMBER_VARIABLES
        private int _totalRecords;
        private IList<T> _datas;
        #endregion

        #region PROPERTIES
        public int TotalRecords
        {
            get { return _totalRecords; }
            set
            {
                if (_totalRecords != value)
                {
                    _totalRecords = value;
                }
            }
        }

        public IList<T> Datas
        {
            get { return _datas; }
            set
            {
                if (_datas != value)
                {
                    _datas = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public APIResponseMultiple()
        {
            Succeeded = false;
            StatusCode = 0;
            Message = string.Empty;
            TotalRecords = 0;
            Datas = new List<T>();
        }

        public APIResponseMultiple(IList<T> datas, int statusCode)
        {
            Succeeded = true;
            StatusCode = statusCode;
            Message = string.Empty;
            TotalRecords = datas.Count;
            Datas = datas;
        }

        public APIResponseMultiple(int statusCode, string message)
        {
            Succeeded = false;
            StatusCode = statusCode;
            Message = message;
            TotalRecords = 0;
            Datas = new List<T>();
        }
        #endregion
    }
}
