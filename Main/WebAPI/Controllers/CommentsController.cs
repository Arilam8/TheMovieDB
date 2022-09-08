using BusinessLogicLayer.BLLManager;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.APIUtils;
using Utils.APIUtils.Models;
using WebAPI.Swagger.Examples.CommentDTO;
using WebAPI.Swagger.Examples.Error;
using WebAPI.Swagger.Examples.LightActorDTO;
using WebAPI.Swagger.Examples.Operation;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CommentsController : Controller
    {
        [HttpGet(Utils.Constant.ROUTE_GETLISTCOMMENTSBYIDMOVIE)]
        [SwaggerOperation(Summary = "Get a list of comments")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseMultiplePagination<CommentDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SwaggerExampleAPIResponseMultiplePaginationCommentDTO))]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while retrieving comments")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails), Description = "Movie not found (idMovie)", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SwaggerExampleNotFound))]
        public async Task<ActionResult> GetListCommentsByIdMovie(int idMovie, int pageNumber, int pageCount, bool invalidComment)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                if (!bllManager.IsExistMovie(idMovie))
                    return NotFound();
                int commentsCount = 0;
                int lastPage = 1;
                IList<CommentDTO> commentDTOs = bllManager.GetListCommentsByIdMovie(idMovie, pageNumber - 1, pageCount, out commentsCount, invalidComment);
                lastPage = ((double.Parse(commentsCount.ToString()) / (double.Parse(pageCount.ToString()))) % 1) == 0.0 ? (commentsCount / pageCount) : (commentsCount / pageCount) + 1;
                if (commentDTOs != null)
                    return Ok(new APIResponseMultiplePagination<CommentDTO>(commentsCount,
                                                                            pageNumber,
                                                                            lastPage,
                                                                            Utils.Utils.GenerateUrlFirstPage("Comments/" + Utils.Constant.ROUTE_GETLISTCOMMENTSBYIDMOVIE, idMovie, pageNumber, pageCount, invalidComment),
                                                                            Utils.Utils.GenerateUrlLastPage("Comments/" + Utils.Constant.ROUTE_GETLISTCOMMENTSBYIDMOVIE, idMovie, pageNumber, pageCount, lastPage, invalidComment),
                                                                            Utils.Utils.GenerateUrlNextPage("Comments/" + Utils.Constant.ROUTE_GETLISTCOMMENTSBYIDMOVIE, idMovie, pageNumber, pageCount, lastPage, invalidComment),
                                                                            Utils.Utils.GenerateUrlPreviousPage("Comments/" + Utils.Constant.ROUTE_GETLISTCOMMENTSBYIDMOVIE, idMovie, pageNumber, pageCount, invalidComment),
                                                                            commentDTOs,
                                                                            StatusCodes.Status200OK));
                else
                    return NoContent();
            }
        }

        [HttpGet(Utils.Constant.ROUTE_GETCOMMENTBYIDCOMMENT)]
        [SwaggerOperation(Summary = "Get a comment")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseSingle<CommentDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while retrieving comment")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails), Description = "Comment not found (idComment)", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SwaggerExampleNotFound))]
        public async Task<ActionResult> GetCommentByIdComment(int idComment)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                if (!bllManager.IsExistComment(idComment))
                    return NotFound();
                CommentDTO commentDTO = bllManager.GetCommentByIdComment(idComment);
                if (commentDTO != null)
                {
                    return Ok(new APIResponseSingle<CommentDTO>(commentDTO, StatusCodes.Status200OK));
                }
                else
                    return NoContent();
            }
        }

        [HttpPost(Utils.Constant.ROUTE_INSERTCOMMENTONMOVIEID)]
        [SwaggerOperation(Summary = "Insert a new comment")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(APIResponseSingle<CommentDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails), Description = "Wrong data", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(SwaggerExampleBadRequest))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails), Description = "Movie not found (idMovie)", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SwaggerExampleNotFound))]
        [SwaggerResponse(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails), Description = "Error while creating comment", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status409Conflict, typeof(SwaggerExampleConflict))]
        public async Task<ActionResult> InsertCommentOnMovieId(int idMovie, [FromBody] CommentDTO commentDTO)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                if (!bllManager.IsExistMovie(idMovie))
                    return NotFound();
                if (commentDTO == null)
                    return BadRequest();
                CommentDTO commentDTOInserted = new CommentDTO();
                if (bllManager.InsertCommentOnIdMovie(idMovie, commentDTO, out commentDTOInserted))
                    return Created(new Uri("/Comments/" + commentDTOInserted.Id, UriKind.Relative), new APIResponseSingle<CommentDTO>(commentDTOInserted, StatusCodes.Status201Created));
                else
                    return Conflict();
            }
        }

        [HttpDelete(Utils.Constant.ROUTE_DELETECOMMENTBYIDCOMMENT)]
        [SwaggerOperation(Summary = "Delete an existing comment")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseSingle<CommentDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while deleting comment")]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails), Description = "Comment not found (idComment)", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SwaggerExampleNotFound))]
        public async Task<ActionResult> DeleteCommentByIdComment(int idComment)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                if (!bllManager.IsExistComment(idComment))
                    return NotFound();
                CommentDTO commentDTO = bllManager.GetCommentByIdComment(idComment);
                if (commentDTO == null)
                    return NotFound();
                if (bllManager.DeleteCommentByIdComment(idComment))
                    return Ok(new APIResponseSingle<CommentDTO>(commentDTO, StatusCodes.Status200OK));
                else
                    return NoContent();
            }
        }

        [HttpPut(Utils.Constant.ROUTE_MODIFYCOMMENTBYIDCOMMENT)]
        [SwaggerOperation(Summary = "Update an existing comment")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseSingle<CommentDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while updating comment")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails), Description = "Wrong data", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(SwaggerExampleBadRequest))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails), Description = "Comment not found (idComment)", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SwaggerExampleNotFound))]
        public async Task<ActionResult> ModifyCommentByIdComment(int idComment, [FromBody] CommentDTO commentDTO)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                if (!bllManager.IsExistComment(idComment))
                    return NotFound();
                if (commentDTO == null)
                    return BadRequest();
                CommentDTO commentDTOExist = bllManager.GetCommentByIdComment(idComment);
                if (commentDTOExist == null)
                    return NotFound();
                if(Utils.Utils.IsModificationComment(commentDTOExist, commentDTO))
                {
                    return Ok(new APIResponseSingle<CommentDTO>(commentDTOExist, StatusCodes.Status200OK));
                }
                commentDTO.Id = idComment;
                if (bllManager.ModifyCommentByIdComment(idComment, commentDTO))
                {
                    commentDTOExist = bllManager.GetCommentByIdComment(idComment);
                    if (commentDTOExist == null)
                    {
                        commentDTO.Date = DateTime.Now;
                        return Ok(new APIResponseSingle<CommentDTO>(commentDTO, StatusCodes.Status200OK));
                    }
                    else
                        return Ok(new APIResponseSingle<CommentDTO>(commentDTOExist, StatusCodes.Status200OK));
                }   
                else
                    return NoContent();
            }
        }

        [HttpPatch(Utils.Constant.ROUTE_INVALIDATEORVALIDATECOMMENTBYIDCOMMENT)]
        [SwaggerOperation(Summary = "Validate or invalidate an existing comment")]
        [SwaggerRequestExample(typeof(Operation), typeof(SwaggerExampleOperation))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(APIResponseSingle<CommentDTO>), Description = "Successful", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponse(StatusCodes.Status204NoContent, Description = "Error while invalidating or validating comment")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails), Description = "Wrong data", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(SwaggerExampleBadRequest))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails), Description = "Comment not found (idComment)", ContentTypes = new string[] { "application/json" })]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SwaggerExampleNotFound))]
        public async Task<ActionResult> InvalidateOrValidateCommentByIdComment(int idComment, [FromBody] JsonPatchDocument jsonPatchDocument)
        {
            using (BLLManager bllManager = new BLLManager())
            {
                if (jsonPatchDocument == null || !jsonPatchDocument.Operations.Any(o => o.op.Equals("replace")))
                    return BadRequest();
                if (!bllManager.IsExistComment(idComment))
                    return NotFound();
                CommentDTO commentDTO = bllManager.GetCommentByIdComment(idComment);
                if(commentDTO == null)
                    return NotFound();
                jsonPatchDocument.ApplyTo(commentDTO);
                if (commentDTO.Valid)
                {
                    if(bllManager.ValidateCommentByIdComment(idComment))
                        return Ok(new APIResponseSingle<CommentDTO>(bllManager.GetCommentByIdComment(idComment), StatusCodes.Status200OK));
                    else
                        return NoContent();
                }
                else
                {
                    if (bllManager.InvalidateCommentByIdComment(idComment))
                        return Ok(new APIResponseSingle<CommentDTO>(bllManager.GetCommentByIdComment(idComment), StatusCodes.Status200OK));
                    else
                        return NoContent();
                }
            }
        }
    }
}