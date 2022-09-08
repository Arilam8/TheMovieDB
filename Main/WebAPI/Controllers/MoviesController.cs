using BusinessLogicLayer.BLLManager;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.APIUtils;
using Utils.APIUtils.Models;
using WebAPI.Swagger.Examples.Error;
using WebAPI.Swagger.Examples.FullMovieDTO;
using WebAPI.Swagger.Examples.MovieDTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MoviesController : Controller
    {
        [HttpGet(Utils.Constant.ROUTE_GETFULLMOVIEDETAILSBYIDMOVIE)]
        [SwaggerOperation(Summary = "Get a movie")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseSingle<FullMovieDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SwaggerExampleAPIResponseSingleFullMovieDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while retrieving the movie")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails), Description = "Movie not found (idMovie)", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SwaggerExampleNotFound))]
        public async Task<ActionResult> GetFullMovieDetailsByIdMovie(int idMovie)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                string newPoster = string.Empty;
                if (!bllManager.IsExistMovie(idMovie))
                    return NotFound();
                FullMovieDTO fullMovieDTO = bllManager.GetFullMovieDetailsByIdMovie(idMovie);
                if (fullMovieDTO != null)
                {
                    if (!Utils.Utils.IsPosterValid(fullMovieDTO, out newPoster))
                    {
                        if(!string.IsNullOrEmpty(newPoster) && bllManager.UpdatePosterMovie(fullMovieDTO.Id, newPoster))
                            fullMovieDTO.Poster = newPoster;
                    }
                    return Ok(new APIResponseSingle<FullMovieDTO>(Utils.Utils.SetAdditionalInformationFullMovieDTO(fullMovieDTO), StatusCodes.Status200OK));
                }
                else
                    return NoContent();
            }
        }

        [HttpGet(Utils.Constant.ROUTE_GETLISTFULLMOVIEORDERBYRELEASEDATE)]
        [SwaggerOperation(Summary = "Get a list of movies order by release date")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseMultiplePagination<MovieDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SwaggerExampleAPIResponseMultiplePaginationMovieDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while retrieving movies order by release date")]
        public async Task<ActionResult> GetListMoviesOrderByReleaseDate(int pageNumber, int pageCount)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                int fullMoviesCount = 0;
                int lastPage = 1;
                IList<MovieDTO> movieDTOs = bllManager.GetListMoviesOrderByReleaseDate(pageNumber - 1, pageCount, out fullMoviesCount);
                foreach (MovieDTO movieDTO in movieDTOs)
                {
                    string newPoster = string.Empty;
                    if (!Utils.Utils.IsPosterValid(movieDTO, out newPoster))
                    {
                        if (!string.IsNullOrEmpty(newPoster) && bllManager.UpdatePosterMovie(movieDTO.Id, newPoster))
                            movieDTO.Poster = newPoster;
                    }
                    movieDTO.Overview = APITheMovieDBManager.GetMovieOverview(movieDTO.Id);
                }
                lastPage = ((double.Parse(fullMoviesCount.ToString()) / (double.Parse(pageCount.ToString()))) % 1) == 0.0 ? (fullMoviesCount / pageCount) : (fullMoviesCount / pageCount) + 1;
                if (movieDTOs != null)
                    return Ok(new APIResponseMultiplePagination<MovieDTO>(fullMoviesCount,
                                                                              pageNumber,
                                                                              lastPage,
                                                                              Utils.Utils.GenerateUrlFirstPage("Movies/" + Utils.Constant.ROUTE_GETLISTFULLMOVIEORDERBYRELEASEDATE, pageNumber, pageCount),
                                                                              Utils.Utils.GenerateUrlLastPage("Movies/" + Utils.Constant.ROUTE_GETLISTFULLMOVIEORDERBYRELEASEDATE, pageNumber, pageCount, lastPage),
                                                                              Utils.Utils.GenerateUrlNextPage("Movies/" + Utils.Constant.ROUTE_GETLISTFULLMOVIEORDERBYRELEASEDATE, pageNumber, pageCount, lastPage),
                                                                              Utils.Utils.GenerateUrlPreviousPage("Movies/" + Utils.Constant.ROUTE_GETLISTFULLMOVIEORDERBYRELEASEDATE, pageNumber, pageCount),
                                                                              movieDTOs,
                                                                              StatusCodes.Status200OK));
                else
                    return NoContent();
            }
        }

        [HttpGet(Utils.Constant.ROUTE_FINDLISTMOVIEBYPARTIALMOVIETITLE)]
        [SwaggerOperation(Summary = "Find a movie by a partial title or an entirely title")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseMultiplePagination<MovieDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SwaggerExampleAPIResponseMultiplePaginationMovieDTOFindMovieTitle))]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while finding movies by title")]
        public async Task<ActionResult> FindListMovieByPartialMovieTitle(string title, int pageNumber, int pageCount)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                int moviesCount = 0;
                int lastPage = 1;
                IList<MovieDTO> movieDTOs = bllManager.FindListMovieByPartialMovieTitle(title, pageNumber - 1, pageCount, out moviesCount);
                foreach (MovieDTO movieDTO in movieDTOs)
                {
                    string newPoster = string.Empty;
                    if (!Utils.Utils.IsPosterValid(movieDTO, out newPoster))
                    {
                        if (!string.IsNullOrEmpty(newPoster) && bllManager.UpdatePosterMovie(movieDTO.Id, newPoster))
                            movieDTO.Poster = newPoster;
                    }
                    movieDTO.Overview = APITheMovieDBManager.GetMovieOverview(movieDTO.Id);
                }
                lastPage = ((double.Parse(moviesCount.ToString()) / (double.Parse(pageCount.ToString()))) % 1) == 0.0 ? (moviesCount / pageCount) : (moviesCount / pageCount) + 1;
                if (movieDTOs != null)
                    return Ok(new APIResponseMultiplePagination<MovieDTO>(moviesCount,
                                                                          pageNumber,
                                                                          lastPage,
                                                                          Utils.Utils.GenerateUrlFirstPage("Movies/" + Utils.Constant.ROUTE_FINDLISTMOVIEBYPARTIALMOVIETITLE, pageNumber, pageCount, title),
                                                                          Utils.Utils.GenerateUrlLastPage("Movies/" + Utils.Constant.ROUTE_FINDLISTMOVIEBYPARTIALMOVIETITLE, pageNumber, pageCount, lastPage, title),
                                                                          Utils.Utils.GenerateUrlNextPage("Movies/" + Utils.Constant.ROUTE_FINDLISTMOVIEBYPARTIALMOVIETITLE, pageNumber, pageCount, lastPage, title),
                                                                          Utils.Utils.GenerateUrlPreviousPage("Movies/" + Utils.Constant.ROUTE_FINDLISTMOVIEBYPARTIALMOVIETITLE, pageNumber, pageCount, title),
                                                                          movieDTOs,
                                                                          StatusCodes.Status200OK));
                else
                    return NoContent();
            }
        }

        [HttpGet(Utils.Constant.ROUTE_FINDLISTMOVIEBYPARTIALACTORNAME)]
        [SwaggerOperation(Summary = "Find a movie by a partial actor name or an entirely actor name")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseMultiplePagination<MovieDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SwaggerExampleAPIResponseMultiplePaginationMovieDTOFindActorName))]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while finding movies by actor name")]
        public async Task<ActionResult> FindListMovieByPartialActorName(string name, int pageNumber, int pageCount)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                int moviesCount = 0;
                int lastPage = 1;
                IList<MovieDTO> movieDTOs = bllManager.FindListMovieByPartialActorName(name, pageNumber - 1, pageCount, out moviesCount);
                foreach (MovieDTO movieDTO in movieDTOs)
                {
                    string newPoster = string.Empty;
                    if (!Utils.Utils.IsPosterValid(movieDTO, out newPoster))
                    {
                        if (!string.IsNullOrEmpty(newPoster) && bllManager.UpdatePosterMovie(movieDTO.Id, newPoster))
                            movieDTO.Poster = newPoster;
                    }
                    movieDTO.Overview = APITheMovieDBManager.GetMovieOverview(movieDTO.Id);
                }
                lastPage = ((double.Parse(moviesCount.ToString()) / (double.Parse(pageCount.ToString()))) % 1) == 0.0 ? (moviesCount / pageCount) : (moviesCount / pageCount) + 1;
                if (movieDTOs != null)
                    return Ok(new APIResponseMultiplePagination<MovieDTO>(moviesCount,
                                                                          pageNumber,
                                                                          lastPage,
                                                                          Utils.Utils.GenerateUrlFirstPage("Movies/" + Utils.Constant.ROUTE_FINDLISTMOVIEBYPARTIALACTORNAME, pageNumber, pageCount, name),
                                                                          Utils.Utils.GenerateUrlLastPage("Movies/" + Utils.Constant.ROUTE_FINDLISTMOVIEBYPARTIALACTORNAME, pageNumber, pageCount, lastPage, name),
                                                                          Utils.Utils.GenerateUrlNextPage("Movies/" + Utils.Constant.ROUTE_FINDLISTMOVIEBYPARTIALACTORNAME, pageNumber, pageCount, lastPage, name),
                                                                          Utils.Utils.GenerateUrlPreviousPage("Movies/" + Utils.Constant.ROUTE_FINDLISTMOVIEBYPARTIALACTORNAME, pageNumber, pageCount, name),
                                                                          movieDTOs,
                                                                          StatusCodes.Status200OK));
                else
                    return NoContent();
            }
        }
    }
}
