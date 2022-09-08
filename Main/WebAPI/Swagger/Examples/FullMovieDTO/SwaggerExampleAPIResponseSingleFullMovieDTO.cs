using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using Utils.APIUtils.Models;

namespace WebAPI.Swagger.Examples.FullMovieDTO
{
    public class SwaggerExampleAPIResponseSingleFullMovieDTO : IExamplesProvider<APIResponseSingle<DataTransferObject.FullMovieDTO>>
    {
        public APIResponseSingle<DataTransferObject.FullMovieDTO> GetExamples()
        {
            IList<DataTransferObject.MovieTypeDTO> movieTypeDTOs = new List<DataTransferObject.MovieTypeDTO>();
            movieTypeDTOs.Add(new DataTransferObject.MovieTypeDTO()
            {
                Id = 18,
                Name = "Drama"
            });
            return new APIResponseSingle<DataTransferObject.FullMovieDTO>()
            {
                Succeeded = true,
                StatusCode = 200,
                Message = "",
                Data = new DataTransferObject.FullMovieDTO()
                {
                    Id = 67918,
                    Title = "Servitude",
                    ReleaseDate = new DateTime(2012, 3, 30),
                    Overview = "A group of frustrated waiters at a kitschy steakhouse take over their restaurant for one final, glorious, revenge-filled night when they discover they are all about to be fired.",
                    RatingTheMovieDB = 4,
                    Rating = 0,
                    Runtime = -1,
                    Poster = "4lM22JmgF2E9gLnKvQCeaUhwpXq.jpg",
                    Logo = null,
                    Backdrop = "/bFK9fQf0r715ZHF24yBy5myg7Xd.jpg",
                    MovieTypes = movieTypeDTOs,
                }
            };
        }
    }
}
