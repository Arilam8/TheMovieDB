using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using Utils.APIUtils.Models;

namespace WebAPI.Swagger.Examples.CommentDTO
{
    public class SwaggerExampleAPIResponseMultiplePaginationCommentDTO : IExamplesProvider<APIResponseMultiplePagination<DataTransferObject.CommentDTO>>
    {
        public APIResponseMultiplePagination<DataTransferObject.CommentDTO> GetExamples()
        {
            IList<DataTransferObject.CommentDTO> commentDTOs = new List<DataTransferObject.CommentDTO>();
            commentDTOs.Add(new DataTransferObject.CommentDTO()
            {
                Id = 39,
                Date = System.DateTime.Now,
                Rate = 4,
                Content = "Content example",
                Username = "Username example",
                Valid = true
            });
            commentDTOs.Add(new DataTransferObject.CommentDTO()
            {
                Id = 38,
                Date = System.DateTime.Now.AddDays(-1),
                Rate = 4,
                Content = "Content example",
                Username = "Username example",
                Valid = true
            });
            commentDTOs.Add(new DataTransferObject.CommentDTO()
            {
                Id = 37,
                Date = System.DateTime.Now.AddDays(-2),
                Rate = 4,
                Content = "Content example",
                Username = "Username example",
                Valid = true
            });
            commentDTOs.Add(new DataTransferObject.CommentDTO()
            {
                Id = 36,
                Date = System.DateTime.Now.AddDays(-3),
                Rate = 4,
                Content = "Content example",
                Username = "Username example",
                Valid = true
            });
            commentDTOs.Add(new DataTransferObject.CommentDTO()
            {
                Id = 35,
                Date = System.DateTime.Now.AddDays(-4),
                Rate = 4,
                Content = "Content example",
                Username = "Username example",
                Valid = true
            });
            commentDTOs.Add(new DataTransferObject.CommentDTO()
            {
                Id = 34,
                Date = System.DateTime.Now.AddDays(-6),
                Rate = 4,
                Content = "Content example",
                Username = "Username example",
                Valid = true
            });
            commentDTOs.Add(new DataTransferObject.CommentDTO()
            {
                Id = 33,
                Date = System.DateTime.Now.AddDays(-7),
                Rate = 4,
                Content = "Content example",
                Username = "Username example",
                Valid = true
            });
            commentDTOs.Add(new DataTransferObject.CommentDTO()
            {
                Id = 32,
                Date = System.DateTime.Now.AddDays(-8),
                Rate = 4,
                Content = "Content example",
                Username = "Username example",
                Valid = true
            });
            commentDTOs.Add(new DataTransferObject.CommentDTO()
            {
                Id = 31,
                Date = System.DateTime.Now.AddDays(-9),
                Rate = 4,
                Content = "Content example",
                Username = "Username example",
                Valid = true
            });
            commentDTOs.Add(new DataTransferObject.CommentDTO()
            {
                Id = 30,
                Date = System.DateTime.Now.AddDays(-10),
                Rate = 4,
                Content = "Content example",
                Username = "Username example",
                Valid = true
            });
            return new APIResponseMultiplePagination<DataTransferObject.CommentDTO>()
            {
                Succeeded = true,
                StatusCode = 200,
                Message = "",
                Datas = commentDTOs,
                PageNumber = 1,
                PageSize = commentDTOs.Count,
                TotalPages = 3,
                FirstPage = null,
                LastPage = "https://127.0.0.1:5001/v1/Comments/11&pageNumber=3&pageCount=10&invalidComment=False",
                NextPage = "https://127.0.0.1:5001/v1/Comments/11&pageNumber=2&pageCount=10&invalidComment=False",
                PreviousPage = null,
                TotalRecords = 22
            };
        }
    }
}
