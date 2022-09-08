using DataTransferObject;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace BrowserApp.Models
{
    public class SearchModel<T> : PaginationModel<T>
    {
        #region MEMBER_VARIABLES
        private int _typeSearch;
        private string _search;
        #endregion

        #region PROPERTIES
        public int TypeSearch
        {
            get { return _typeSearch; }
            set
            {
                if (_typeSearch != value)
                {
                    _typeSearch = value;
                }
            }
        }

        public string Search
        {
            get { return _search; }
            set
            {
                if (_search != value)
                {
                    _search = value;
                }
            }
        }
        #endregion

        #region BUILDERS
        public SearchModel() : base()
        {
            TypeSearch = Utils.Constant.SEARCH_TYPE_MOVIE_TITLE;
            Search = string.Empty;
        }

        public SearchModel(List<T> datas, int totalRecords, int pageNumber, int totalPages, bool isFirstPage, bool isLastPage, bool isPreviousPage, bool isNextPage, int typeSearch, string search) : base(datas, totalRecords, pageNumber, totalPages, isFirstPage, isLastPage, isPreviousPage, isNextPage)
        {
            TypeSearch = typeSearch;
            Search = search;
        }
        #endregion
    }
}