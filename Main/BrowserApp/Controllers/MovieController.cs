using BrowserApp.Models;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Configuration;
using System.Linq;
using Utils.APIUtils;
using Utils.APIUtils.Models;

namespace BrowserApp.Controllers
{

    public class MovieController : Controller
    {
        private static APIResponseMultiplePagination<MovieDTO> _responseMovie;
        private static APIResponseMultiplePagination<MovieDTO> _previousResponseMovie;

        public MovieController() { }

        public IActionResult Index(int? page)
        {
            _responseMovie = WebAPIManager.GetListMoviesOrderByReleaseDateAsync(CheckPageNumber(page ?? 1), Int32.Parse(ConfigurationManager.AppSettings["PageSizeMovie"])).Result;
            return CheckResponseStatus();
        }

        private int CheckPageNumber(int pageNumber)
        {
            if(_previousResponseMovie == null || pageNumber <= 0)
                return 1;
            return pageNumber <= _previousResponseMovie.TotalPages ? pageNumber : _previousResponseMovie.TotalPages;
        }

        private IActionResult CheckResponseStatus()
        {
            if (!_responseMovie.Succeeded)
                return View("Error", new ErrorModel(_responseMovie.StatusCode, _responseMovie.Message));
            else
            {
                // Resolve the problem about the "Errors pages" so now we can show the correct previous page with the movies.
                _previousResponseMovie = _responseMovie;
                PaginationModel<MovieModel> paginationModels = new PaginationModel<MovieModel>(Utils.Utils.MovieDTOsToMovieModels(_previousResponseMovie.Datas.ToList()),
                                                                                                     _previousResponseMovie.TotalRecords,
                                                                                                     _previousResponseMovie.PageNumber <= 0 ? 1 : _previousResponseMovie.PageNumber,
                                                                                                     _previousResponseMovie.TotalPages,
                                                                                                     _previousResponseMovie.PageNumber <= 1 ? false : true,
                                                                                                     _previousResponseMovie.PageNumber == _previousResponseMovie.TotalPages ? false : true,
                                                                                                     _previousResponseMovie.PageNumber <= 1 ? false : true,
                                                                                                     _previousResponseMovie.PageNumber == _previousResponseMovie.TotalPages ? false : true);
                return View("Index", paginationModels);
            }
        }
    }
}
