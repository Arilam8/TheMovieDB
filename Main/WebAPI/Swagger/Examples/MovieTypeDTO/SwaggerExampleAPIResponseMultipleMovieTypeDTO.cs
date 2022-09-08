using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using Utils.APIUtils.Models;

namespace WebAPI.Swagger.Examples.MovieTypeDTO
{
    public class SwaggerExampleAPIResponseMultipleMovieTypeDTO : IExamplesProvider<APIResponseMultiple<DataTransferObject.MovieTypeDTO>>
    {
        public APIResponseMultiple<DataTransferObject.MovieTypeDTO> GetExamples()
        {
            IList<DataTransferObject.MovieTypeDTO> movieTypeDTOs = new List<DataTransferObject.MovieTypeDTO>();
            movieTypeDTOs.Add(new DataTransferObject.MovieTypeDTO()
            {
                Id = 12,
                Name = "Adventure"
            });
            movieTypeDTOs.Add(new DataTransferObject.MovieTypeDTO()
            {
                Id = 28,
                Name = "Action"
            });
            movieTypeDTOs.Add(new DataTransferObject.MovieTypeDTO()
            {
                Id = 878,
                Name = "Fiction"
            });
            return new APIResponseMultiple<DataTransferObject.MovieTypeDTO>()
            {
                Succeeded = true,
                StatusCode = 200,
                Message = "",
                Datas = movieTypeDTOs,
                TotalRecords = movieTypeDTOs.Count
            };
        }
    }
}
