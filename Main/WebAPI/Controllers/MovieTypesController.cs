using BusinessLogicLayer.BLLManager;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.APIUtils.Models;
using WebAPI.Swagger.Examples.Error;
using WebAPI.Swagger.Examples.MovieTypeDTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MovieTypesController : Controller
    {
        [HttpGet("{idMovie}")]
        [SwaggerOperation(Summary = "Get a list of movie types")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseMultiple<MovieTypeDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SwaggerExampleAPIResponseMultipleMovieTypeDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while retrieving movie types")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(string), Description = "Movie not found (idMovie)", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SwaggerExampleNotFound))]
        public async Task<ActionResult> GetListMovieTypesByIdMovie(int idMovie)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                if (!bllManager.IsExistMovie(idMovie))
                    return NotFound();
                IList<MovieTypeDTO> movieTypeDTOs = bllManager.GetListMovieTypesByIdMovie(idMovie);
                if (movieTypeDTOs != null)
                    return Ok(new APIResponseMultiple<MovieTypeDTO>(movieTypeDTOs, StatusCodes.Status200OK));
                else
                    return NoContent();
            }
        }
    }
}
