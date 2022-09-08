using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using Utils.APIUtils.Models;
using Utils.ParserUtils;

namespace WebAPI.Swagger.Examples.MovieDTO
{
    public class SwaggerExampleAPIResponseMultiplePaginationMovieDTOFindActorName : IExamplesProvider<APIResponseMultiplePagination<DataTransferObject.MovieDTO>>
    {
        public APIResponseMultiplePagination<DataTransferObject.MovieDTO> GetExamples()
        {
            IList<DataTransferObject.MovieDTO> movieDTOs = new List<DataTransferObject.MovieDTO>();
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 207937,
                Title = "Don Quixote",
                ReleaseDate = new DateTime(2000, 4, 8),
                Overview = "The classic tale of a man's dream, his epic journey, and one true love.",
                RatingTheMovieDB = ParserUtils.ParseFloat("6,4"),
                Rating = 0,
                Runtime = 141,
                Poster = "/fBQHTU6Bv3IZCZ9jBWMTsJctWt7.jpg"
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 468323,
                Title = "Juste Pour Rire 2017 - Gala Juste Stand-Up",
                ReleaseDate = new DateTime(2017, 7, 21),
                Overview = "",
                RatingTheMovieDB = 0,
                Rating = 0,
                Runtime = -1,
                Poster = "/9K2Id63S89ouFOEbqW06xzWaUqB.jpg"
            });
            return new APIResponseMultiplePagination<DataTransferObject.MovieDTO>()
            {
                Succeeded = true,
                StatusCode = 200,
                Message = "",
                Datas = movieDTOs,
                PageNumber = 1,
                PageSize = movieDTOs.Count,
                TotalPages = 1,
                FirstPage = null,
                LastPage = null,
                NextPage = null,
                PreviousPage = null,
                TotalRecords = 2
            };
        }
    }
}
