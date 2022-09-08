using BrowserApp.Models;
using BrowserApp.Models.Actors;
using BrowserApp.Models.Comments;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Utils.APIUtils;
using Utils.APIUtils.Models;

namespace BrowserApp.Controllers
{
    public class FullMovieController : Controller
    {
        private static int _idMovie;
        private static APIResponseSingle<FullMovieDTO> _responseFullMovie;
        private static APIResponseSingle<FullMovieDTO> _previousResponseFullMovie;
        private static APIResponseMultiplePagination<LightActorDTO> _responseLightActors;
        private static APIResponseMultiplePagination<LightActorDTO> _previousResponseLightActors;
        private static APIResponseMultiplePagination<CommentDTO> _responseComments;
        private static APIResponseMultiplePagination<CommentDTO> _previousResponseComments;
        public FullMovieController() { }

        public IActionResult Index(int idMovie, int? pageActor, int? pageComment)
        {
            _idMovie = idMovie;
            _responseFullMovie = WebAPIManager.GetFullMovieDetailsByIdMovieAsync(idMovie).Result;
            if (!_responseFullMovie.Succeeded)
                return View("Error", new ErrorModel(_responseFullMovie.StatusCode, _responseFullMovie.Message));
            _previousResponseFullMovie = _responseFullMovie;
            _responseLightActors = WebAPIManager.GetListActorsByIdMovieAsync(idMovie, CheckPageNumberActors(pageActor ?? 1), Int32.Parse(ConfigurationManager.AppSettings["PageSizeLightActor"])).Result;
            if (!_responseLightActors.Succeeded)
                return View("Error", new ErrorModel(_responseLightActors.StatusCode, _responseLightActors.Message));
            _previousResponseLightActors = _responseLightActors;
            PaginationModel<LightActorModel> paginationModelLightActorModel = new PaginationModel<LightActorModel>(Utils.Utils.LightActorDTOsToLightActorModels(_previousResponseLightActors.Datas.ToList()),
                                                                                                                     _previousResponseLightActors.TotalRecords,
                                                                                                                     _previousResponseLightActors.PageNumber <= 0 ? 1 : _previousResponseLightActors.PageNumber,
                                                                                                                     _previousResponseLightActors.TotalPages,
                                                                                                                     _previousResponseLightActors.PageNumber <= 1 ? false : true,
                                                                                                                     _previousResponseLightActors.PageNumber == _previousResponseLightActors.TotalPages ? false : true,
                                                                                                                     _previousResponseLightActors.PageNumber <= 1 ? false : true,
                                                                                                                     _previousResponseLightActors.PageNumber == _previousResponseLightActors.TotalPages ? false : true);
            _responseComments = WebAPIManager.GetListCommentsByIdMovieAsync(idMovie, CheckPageNumberComments(pageComment ?? 1), Int32.Parse(ConfigurationManager.AppSettings["PageSizeComment"]), false).Result;
            if (!_responseComments.Succeeded)
                return View("Error", new ErrorModel(_responseComments.StatusCode, _responseComments.Message));
            _previousResponseComments = _responseComments;
            PaginationModel<CommentModel> paginationModelCommentModel = new PaginationModel<CommentModel>(Utils.Utils.CommentDTOsToCommentModels(_previousResponseComments.Datas.ToList()),
                                                                                                                     _previousResponseComments.TotalRecords,
                                                                                                                     _previousResponseComments.PageNumber <= 0 ? 1 : _previousResponseComments.PageNumber,
                                                                                                                     _previousResponseComments.TotalPages,
                                                                                                                     _previousResponseComments.PageNumber <= 1 ? false : true,
                                                                                                                     _previousResponseComments.PageNumber == _previousResponseComments.TotalPages ? false : true,
                                                                                                                     _previousResponseComments.PageNumber <= 1 ? false : true,
                                                                                                                     _previousResponseComments.PageNumber == _previousResponseComments.TotalPages ? false : true);
            FullMovieModel fullMovieModel = new FullMovieModel(_previousResponseFullMovie.Data, paginationModelLightActorModel, paginationModelCommentModel);
            return View(fullMovieModel);
        }

        private int CheckPageNumberActors(int pageNumber)
        {
            if (_previousResponseLightActors == null || pageNumber <= 0)
                return 1;
            return pageNumber <= _previousResponseLightActors.TotalPages ? pageNumber : _previousResponseLightActors.TotalPages;
        }

        private int CheckPageNumberComments(int pageNumber)
        {
            if (_previousResponseComments == null || pageNumber <= 0)
                return 1;
            return pageNumber <= _previousResponseComments.TotalPages ? pageNumber : _previousResponseComments.TotalPages;
        }

        [HttpPost]
        public IActionResult AddComment(string username, string content, int rate)
        {
            CommentDTO commentDTO = new CommentDTO(DateTime.Now, rate, content, username);
            APIResponseSingle<CommentDTO> responseComment = WebAPIManager.InsertCommentOnMovieIdAsync(_idMovie, commentDTO).Result;
            return RedirectToAction("Index", new { idmovie = _idMovie, pageActor = _previousResponseLightActors.PageNumber, pageComment = _previousResponseComments.PageNumber});
        }
    }
}
