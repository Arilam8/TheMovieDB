using System.Collections.Generic;

namespace BrowserApp.Models
{
    public class PaginationModel<T>
    {
        #region MEMBER_VARIABLES
        private List<T> _datas;
        private int _totalRecords;
        private int _pageNumber;
        private int _totalPages;
        private bool _isFirstPage;
        private bool _isLastPage;
        private bool _isPreviousPage;
        private bool _isNextPage;
        #endregion

        #region PROPERTIES
        public List<T> Datas
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

        public bool IsFirstPage
        {
            get { return _isFirstPage; }
            set
            {
                if (_isFirstPage != value)
                {
                    _isFirstPage = value;
                }
            }
        }

        public bool IsLastPage
        {
            get { return _isLastPage; }
            set
            {
                if (_isLastPage != value)
                {
                    _isLastPage = value;
                }
            }
        }

        public bool IsPreviousPage
        {
            get { return _isPreviousPage; }
            set
            {
                if (_isPreviousPage != value)
                {
                    _isPreviousPage = value;
                }
            }
        }

        public bool IsNextPage
        {
            get { return _isNextPage; }
            set
            {
                if (_isNextPage != value)
                {
                    _isNextPage = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public PaginationModel()
        {
            Datas = new List<T>();
            TotalRecords = 0;
            PageNumber = 1;
            TotalPages = 1;
            IsFirstPage = false;
            IsLastPage = false;
            IsPreviousPage = false;
            IsNextPage = false;
        }

        public PaginationModel(List<T> datas, int totalRecords, int pageNumber, int totalPages, bool isFirstPage, bool isLastPage, bool isPreviousPage, bool isNextPage)
        {
            Datas = datas;
            TotalRecords = totalRecords;
            PageNumber = pageNumber;
            TotalPages = totalPages;
            IsFirstPage = isFirstPage;
            IsLastPage = isLastPage;
            IsPreviousPage = isPreviousPage;
            IsNextPage = isNextPage;
        }
        #endregion
    }
}
