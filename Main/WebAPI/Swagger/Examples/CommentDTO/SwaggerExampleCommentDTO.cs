using Swashbuckle.AspNetCore.Filters;

namespace WebAPI.Swagger.Examples.CommentDTO
{
    public class SwaggerExampleCommentDTO : IExamplesProvider<DataTransferObject.CommentDTO>
    {
        DataTransferObject.CommentDTO IExamplesProvider<DataTransferObject.CommentDTO>.GetExamples()
        {
            return new DataTransferObject.CommentDTO()
            {
                Id = 30,
                Date = System.DateTime.Now.AddDays(-5),
                Rate = 4,
                Content = "Content example",
                Username = "Username example",
                Valid = true
            };
        }
    }
}
