using BrowserApp.Models;

using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using Utils.APIUtils;
using Utils.APIUtils.Models;

namespace BrowserApp.Controllers
{
    public class SearchController : Controller
    {
        private static int _typeSearch;
        private static string _search;
        private static APIResponseMultiplePagination<MovieDTO> _responseMovieSearch;
        private static APIResponseMultiplePagination<MovieDTO> _previousResponseMovieSearch;

        public SearchController() { }

        public IActionResult Index()
        {
            return View(new SearchModel<MovieModel>());
        }

        public IActionResult Movies(string title, int? page)
        {
            _typeSearch = Utils.Constant.SEARCH_TYPE_MOVIE_TITLE;
            _search = title;
            _responseMovieSearch = WebAPIManager.FindListMovieByPartialMovieTitleAsync(title, CheckPageNumber(page ?? 1), Int32.Parse(ConfigurationManager.AppSettings["PageSizeMovie"])).Result;
            return CheckResponseStatus();
        }

        public IActionResult Actors(string name, int? page)
        {
            _typeSearch = Utils.Constant.SEARCH_TYPE_MOVIE_ACTOR;
            _search = name;
            _responseMovieSearch = WebAPIManager.FindListMovieByPartialActorNameAsync(name, CheckPageNumber(page ?? 1), Int32.Parse(ConfigurationManager.AppSettings["PageSizeMovie"])).Result;
            return CheckResponseStatus();
        }

        private int CheckPageNumber(int pageNumber)
        {
            if (_previousResponseMovieSearch == null || pageNumber <= 0)
                return 1;
            return pageNumber <= _previousResponseMovieSearch.TotalPages ? pageNumber : _previousResponseMovieSearch.TotalPages;
        }

        private IActionResult CheckResponseStatus()
        {
            if (!_responseMovieSearch.Succeeded)
                return View("Error", new ErrorModel(_responseMovieSearch.StatusCode, _responseMovieSearch.Message));
            else
            {

                // Resolve the problem about the "Errors pages" so now we can show the correct previous page with the movies.
                _previousResponseMovieSearch = _responseMovieSearch;
                SearchModel<MovieModel> searchModels = new SearchModel<MovieModel>(Utils.Utils.MovieDTOsToMovieModels(_previousResponseMovieSearch.Datas.ToList()),
                                                                                                     _previousResponseMovieSearch.TotalRecords,
                                                                                                     _previousResponseMovieSearch.PageNumber <= 0 ? 1 : _previousResponseMovieSearch.PageNumber,
                                                                                                     _previousResponseMovieSearch.TotalPages,
                                                                                                     _previousResponseMovieSearch.PageNumber <= 1 ? false : true,
                                                                                                     _previousResponseMovieSearch.PageNumber == _previousResponseMovieSearch.TotalPages ? false : true,
                                                                                                     _previousResponseMovieSearch.PageNumber <= 1 ? false : true,
                                                                                                     _previousResponseMovieSearch.PageNumber == _previousResponseMovieSearch.TotalPages ? false : true,
                                                                                                     _typeSearch,
                                                                                                     _search);
                return View("Index", searchModels);
            }
        }
    }
}
