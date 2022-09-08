using BusinessLogicLayer.BLLManager;
using DataAccessLayer.Models;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.APIUtils.Models;
using WebAPI.Swagger.Examples.ActorDTO;
using WebAPI.Swagger.Examples.Error;
using WebAPI.Swagger.Examples.LightActorDTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ActorsController : Controller
    {
        [HttpGet(Utils.Constant.ROUTE_GETACTORBYIDACTOR)]
        [SwaggerOperation(Summary = "Get an actor")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseSingle<ActorDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SwaggerExampleAPIResponseSingleActorDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while retrieving actor")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails), Description = "Actor not found (idActor)", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SwaggerExampleNotFound))]
        public async Task<ActionResult> GetActorByIdActor(int idActor)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                if (!bllManager.IsExistActor(idActor))
                    return NotFound();
                ActorDTO actorDTO = bllManager.GetActorByIdActor(idActor);
                if(actorDTO != null)
                    return Ok(new APIResponseSingle<ActorDTO>(Utils.Utils.SetAdditionalInformationActorDTO(actorDTO), StatusCodes.Status200OK));
                else
                    return NoContent();
            }
        }

        [HttpGet(Utils.Constant.ROUTE_GETLISTACTORSBYIDMOVIE)]
        [SwaggerOperation(Summary = "Get a list of actors")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseMultiplePagination<LightActorDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SwaggerExampleAPIResponseMultiplePaginationLightActorDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while retrieving actors")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails), Description = "Movie not found (idMovie)", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SwaggerExampleNotFound))]
        public async Task<ActionResult> GetListActorsByIdMovie(int idMovie, int pageNumber, int pageCount)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                if (!bllManager.IsExistMovie(idMovie))
                    return NotFound();
                int actorsCount = 0;
                int lastPage = 1;
                IList<LightActorDTO> lightActorDTOs = bllManager.GetListActorsByIdMovie(idMovie, pageNumber - 1, pageCount, out actorsCount);
                lastPage = ((double.Parse(actorsCount.ToString()) / (double.Parse(pageCount.ToString()))) % 1) == 0.0 ? (actorsCount / pageCount) : (actorsCount / pageCount) + 1;
                if (lightActorDTOs != null)
                    return Ok(new APIResponseMultiplePagination<LightActorDTO>(actorsCount,
                                                                               pageNumber,
                                                                               lastPage,
                                                                               Utils.Utils.GenerateUrlFirstPage("Actors/" + Utils.Constant.ROUTE_GETLISTACTORSBYIDMOVIE, idMovie, pageNumber, pageCount),
                                                                               Utils.Utils.GenerateUrlLastPage("Actors/" + Utils.Constant.ROUTE_GETLISTACTORSBYIDMOVIE, idMovie, pageNumber, pageCount, lastPage),
                                                                               Utils.Utils.GenerateUrlNextPage("Actors/" + Utils.Constant.ROUTE_GETLISTACTORSBYIDMOVIE, idMovie, pageNumber, pageCount, lastPage),
                                                                               Utils.Utils.GenerateUrlPreviousPage("Actors/" + Utils.Constant.ROUTE_GETLISTACTORSBYIDMOVIE, idMovie, pageNumber, pageCount),
                                                                               Utils.Utils.SetAdditionalInformationLightActorDTOs(lightActorDTOs.ToList()),
                                                                               StatusCodes.Status200OK));
                else
                    return NoContent();
            }
        }

        [HttpGet(Utils.Constant.ROUTE_GETFAVORITEACTORS)]
        [SwaggerOperation(Summary = "Get a list of favorite actors")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseMultiplePagination<ActorDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SwaggerExampleAPIResponseMultiplePaginationActorDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while retrieving favorite actors")]
        public async Task<ActionResult> GetFavoriteActors(int pageNumber, int pageCount)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                int actorsCount = 0;
                int lastPage = 1;
                IList<ActorDTO> actorDTOs = bllManager.GetFavoriteActors(pageNumber - 1, pageCount, out actorsCount);
                lastPage = ((double.Parse(actorsCount.ToString()) / (double.Parse(pageCount.ToString()))) % 1) == 0.0 ? (actorsCount / pageCount) : (actorsCount / pageCount) + 1;
                if (actorDTOs != null)
                    return Ok(new APIResponseMultiplePagination<ActorDTO>(actorsCount,
                                                                          pageNumber,
                                                                          lastPage,
                                                                          Utils.Utils.GenerateUrlFirstPage("Actors/" + Utils.Constant.ROUTE_GETFAVORITEACTORS, pageNumber, pageCount),
                                                                          Utils.Utils.GenerateUrlLastPage("Actors/" + Utils.Constant.ROUTE_GETFAVORITEACTORS, pageNumber, pageCount, lastPage),
                                                                          Utils.Utils.GenerateUrlNextPage("Actors/" + Utils.Constant.ROUTE_GETFAVORITEACTORS, pageNumber, pageCount, lastPage),
                                                                          Utils.Utils.GenerateUrlPreviousPage("Actors/" + Utils.Constant.ROUTE_GETFAVORITEACTORS, pageNumber, pageCount),
                                                                          actorDTOs,
                                                                          StatusCodes.Status200OK));
                else
                    return NoContent();
            }
        }
    }
}
