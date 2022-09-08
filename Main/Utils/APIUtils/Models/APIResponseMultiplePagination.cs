using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.APIUtils.Models
{
    public class APIResponseMultiplePagination<T> : APIResponseMultiple<T>
    {
        #region MEMBER_VARIABLES
        private int _pageNumber;
        private int _pageSize;
        private int _totalPages;
        private string _firstPage;
        private string _lastPage;
        private string _nextPage;
        private string _previousPage;
        #endregion

        #region PROPERTIES
        public int PageNumber
        {
            get { return _pageNumber; }
            set
            {
                if (_pageNumber != value)
                {
                    _pageNumber = value;
                }
            }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                if (_pageSize != value)
                {
                    _pageSize = value;
                }
            }
        }

        public int TotalPages
        {
            get { return _totalPages; }
            set
            {
                if (_totalPages != value)
                {
                    _totalPages = value;
                }
            }
        }

        public string FirstPage
        {
            get { return _firstPage; }
            set
            {
                if (_firstPage != value)
                {
                    _firstPage = value;
                }
            }
        }

        public string LastPage
        {
            get { return _lastPage; }
            set
            {
                if (_lastPage != value)
                {
                    _lastPage = value;
                }
            }
        }

        public string NextPage
        {
            get { return _nextPage; }
            set
            {
                if (_nextPage != value)
                {
                    _nextPage = value;
                }
            }
        }

        public string PreviousPage
        {
            get { return _previousPage; }
            set
            {
                if (_previousPage != value)
                {
                    _previousPage = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public APIResponseMultiplePagination()
        {
            Succeeded = false;
            StatusCode = 0;
            Message = string.Empty;
            TotalRecords = 0;
            PageNumber = 0;
            PageSize = 0;
            TotalPages = 0;
            FirstPage = string.Empty;
            LastPage = string.Empty;
            NextPage = string.Empty;
            PreviousPage = string.Empty;
            Datas = new List<T>();
        }

        public APIResponseMultiplePagination(int totalRecords, int pageNumber, int totalPages, string firstPage, string lastPage, string nextPage, string previousPage, IList<T> datas, int statusCode)
        {
            Succeeded = true;
            StatusCode = statusCode;
            Message = string.Empty;
            TotalRecords = totalRecords;
            PageNumber = pageNumber;
            PageSize = datas.Count;
            TotalPages = totalPages;
            FirstPage = firstPage;
            LastPage = lastPage;
            NextPage = nextPage;
            PreviousPage = previousPage;
            Datas = datas;
        }

        public APIResponseMultiplePagination(int statusCode, string message)
        {
            Succeeded = false;
            StatusCode = statusCode;
            Message = message;
            TotalRecords = 0;
            PageNumber = 0;
            PageSize = 0;
            TotalPages = 0;
            FirstPage = string.Empty;
            LastPage = string.Empty;
            NextPage = string.Empty;
            PreviousPage = string.Empty;
            Datas = new List<T>();
        }
        #endregion
    }
}
