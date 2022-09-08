using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using Utils.APIUtils.Models;
using Utils.ParserUtils;

namespace WebAPI.Swagger.Examples.MovieDTO
{
    public class SwaggerExampleAPIResponseMultiplePaginationMovieDTOFindMovieTitle : IExamplesProvider<APIResponseMultiplePagination<DataTransferObject.MovieDTO>>
    {
        public APIResponseMultiplePagination<DataTransferObject.MovieDTO> GetExamples()
        {
            IList<DataTransferObject.MovieDTO> movieDTOs = new List<DataTransferObject.MovieDTO>();
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 11,
                Title = "Star Wars",
                ReleaseDate = new DateTime(1977, 5, 25),
                Overview = "Princess Leia is captured and held hostage by the evil Imperial forces in their effort to take over the galactic Empire. Venturesome Luke Skywalker and dashing captain Han Solo team together with the loveable robot duo R2-D2 and C-3PO to rescue the beautiful princess and restore peace and justice in the Empire.",
                RatingTheMovieDB = ParserUtils.ParseFloat("8,2"),
                Rating = 0,
                Runtime = 121,
                Poster = "/6FfCtAuVAW8XJjZ7eWeLibRLWTw.jpg"
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 12180,
                Title = "Star Wars: The Clone Wars",
                ReleaseDate = new DateTime(2008, 8, 05),
                Overview = "Set between Episode II and III, The Clone Wars is the first computer animated Star Wars film. Anakin and Obi Wan must find out who kidnapped Jabba the Hutt's son and return him safely. The Seperatists will try anything to stop them and ruin any chance of a diplomatic agreement between the Hutts and the Republic.",
                RatingTheMovieDB = ParserUtils.ParseFloat("6,1"),
                Rating = 0,
                Runtime = 98,
                Poster = "/ywRtBu88SLAkNxD0GFib6qsFkBK.jpg"
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 140607,
                Title = "Star Wars: The Force Awakens",
                ReleaseDate = new DateTime(2015, 12, 15),
                Overview = "Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.",
                RatingTheMovieDB = ParserUtils.ParseFloat("7,3"),
                Rating = 0,
                Runtime = 136,
                Poster = "/wqnLdwVXoBjKibFRR5U3y0aDUhs.jpg"
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 181808,
                Title = "Star Wars: The Last Jedi",
                ReleaseDate = new DateTime(2017, 12, 13),
                Overview = "Rey develops her newly discovered abilities with the guidance of Luke Skywalker, who is unsettled by the strength of her powers. Meanwhile, the Resistance prepares to do battle with the First Order.",
                RatingTheMovieDB = ParserUtils.ParseFloat("6,9"),
                Rating = 0,
                Runtime = 152,
                Poster = "/ySaaKHOLAQU5HoZqWmzDIj1VvZ1.jpg"
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
                TotalRecords = 4
            };
        }
    }
}
