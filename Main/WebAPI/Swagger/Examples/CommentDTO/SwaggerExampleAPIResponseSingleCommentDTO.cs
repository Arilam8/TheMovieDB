using Swashbuckle.AspNetCore.Filters;
using Utils.APIUtils.Models;

namespace WebAPI.Swagger.Examples.CommentDTO
{
    public class SwaggerExampleAPIResponseSingleCommentDTO : IExamplesProvider<APIResponseSingle<DataTransferObject.CommentDTO>>
    {
        APIResponseSingle<DataTransferObject.CommentDTO> IExamplesProvider<APIResponseSingle<DataTransferObject.CommentDTO>>.GetExamples()
        {
            return new APIResponseSingle<DataTransferObject.CommentDTO>()
            {
                Succeeded = true,
                StatusCode = 200,
                Message = "",
                Data = new DataTransferObject.CommentDTO()
                {
                    Id = 30,
                    Date = System.DateTime.Now.AddDays(-5),
                    Rate = 4,
                    Content = "Content example",
                    Username = "Username example",
                    Valid = true
                }
            };
        }
    }
}
