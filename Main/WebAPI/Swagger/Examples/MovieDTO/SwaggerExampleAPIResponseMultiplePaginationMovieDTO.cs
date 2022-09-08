using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using Utils.APIUtils.Models;
using Utils.ParserUtils;

namespace WebAPI.Swagger.Examples.MovieDTO
{
    public class SwaggerExampleAPIResponseMultiplePaginationMovieDTO : IExamplesProvider<APIResponseMultiplePagination<DataTransferObject.MovieDTO>>
    {
        public APIResponseMultiplePagination<DataTransferObject.MovieDTO> GetExamples()
        {
            IList<DataTransferObject.MovieDTO> movieDTOs = new List<DataTransferObject.MovieDTO>();
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 294152,
                Title = "12 de Junho de 93 - O Dia da Paixão Palmeirense",
                ReleaseDate = new DateTime(2014, 9, 25),
                Overview = "",
                RatingTheMovieDB = 10,
                Rating = 0,
                Runtime = -1,
                Poster = "/trAkxyzXtTKWAYC7nmOZ8wfM7ZR.jpg"
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 132076,
                Title = "2 samurai per 100 geishe",
                ReleaseDate = new DateTime(1962, 9, 2),
                Overview = "Two Sicilian cousins ​​are forced to go to Japan to collect an inheritance. Once they arrive they realize they will have to adapt to the local customs. The tour will turn into a long series of troubles: the Sicilian cousins, to obtain the inheritance, will have to turn into real samurai.",
                RatingTheMovieDB = ParserUtils.ParseFloat("5,1"),
                Rating = 0,
                Runtime = 98,
                Poster = "/lHKn9Jp6prWqy6PJk5MDqlNm58L.jpg"
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 378695,
                Title = "24 Weeks",
                ReleaseDate = new DateTime(2016, 9, 22),
                Overview = "Astrid is a comedian who makes people laugh for a living; her husband Markus is her manager and the two of them work well together. They have a nine-year-old daughter and are expecting their second child. When they learn that their child will not be born healthy, they are at first optimistic that they will be able to meet this challenge – although they have no idea what awaits them. But the closer it gets to the due date, the more Astrid begins to worry about the future of her unborn child as well as that of her family and her career. After many discussions and arguments Astrid realises that the decision that will affect all their lives must be made by her alone. What complicates matters further is the fact that, as a successful entertainer, she is in the eye of the public and the media.",
                RatingTheMovieDB = ParserUtils.ParseFloat("6,6"),
                Rating = 0,
                Runtime = 103,
                Poster = "/nKzmeKmZWIoSPbwxocStemcTgwL.jpg"
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 414931,
                Title = "30 Years of Monty Python, a Revelation",
                ReleaseDate = new DateTime(1999, 10, 08),
                Overview = "Jonathan Ross interviews the (living) members of Monty Python on its 30th anniversary. Deleted scenes from Life of Brian are shown.",
                RatingTheMovieDB = 0,
                Rating = 0,
                Runtime = 24,
                Poster = null
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 403709,
                Title = "45 second",
                ReleaseDate = new DateTime(2013, 3, 24),
                Overview = "The melodramatic life story of the modern urban intelligentsia. 45 seconds is exactly that short time during which the life of the heroes of the picture has changed. The main character, Tatyana Chernigova, is a successful business woman, a former fearless climber, and she is experiencing a difficult family drama: unsuccessful attempts to have a baby.  The trouble does not come alone, and against the background of the heroine’s psychological experiences, a criminal detective tragedy is played out, according to witnesses and participants, she becomes the culprit ...",
                RatingTheMovieDB = 4,
                Rating = 0,
                Runtime = 94,
                Poster = null
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 462529,
                Title = "6X-Day",
                ReleaseDate = new DateTime(2003, 1, 1),
                Overview = "Exactly like an Hour of Slack X-Day radio show, except that you can see it. Shot mostly in DV by Rev. Ivan Stang, Dr. Philo Drummond, Rev. Steve Chekey & Princess Wei \"R.\" Doe at Brushwood; edited mercilessly by Stang. Heavy use of identifying subtitles and nudity, with Rev. Susie the Floozy, Jesus and Magdalen, Rev. Nickie Deathchick, Sister Decadence, Rev. Carter LeBlanc, Rev. Ivan Stang, Rev. Alex, Rev. Pee Kitty, Dr. Philo Drummond, Dr. G. Gordon Gordon, Sifu and Legume's butts, Rabbi's chest, the Hell Bonfire, the Alien Ball, the horror of 7 a.m., Insane Clown Bat Pussy, teabagging, and Lonesome Cowboy Dave. THE AMINO ACIDS in concert plus musical tracks by Cozmodiar, Gary G'broagfran, The Great Groovy Neptune.",
                RatingTheMovieDB = 0,
                Rating = 0,
                Runtime = 62,
                Poster = "/yiLrcBH52LaAM1tU6sdpVTz4IGT.jpg"
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 379007,
                Title = "77 Chances: A Story About Letting Go",
                ReleaseDate = new DateTime(2015, 9, 29),
                Overview = "Jason Shaw has always dreamed of being a professional photographer, but since the death of his mother, his dream has been put on hold and he’s struggling to find meaning in his life.  One fateful night he meets the girl of his dreams. But when their enchanted evening ends tragically, Jason awakens only to find that it's the morning of the same day. He lives that day over and over again until he discovers the secret to break this cycle.",
                RatingTheMovieDB = 0,
                Rating = 0,
                Runtime = 90,
                Poster = "/ws40IG85kX1l3S5ZqtYzxcvYzE.jpg"
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 101010,
                Title = "A Brief History of Errol Morris",
                ReleaseDate = new DateTime(1999, 9, 01),
                Overview = "This film tells the fascinating story of one of the most critically acclaimed careers in independent documentary film making in recent cinema history. This comprehensive overview of Morris' career includes clips of all his important films as well as interviews with collaborators such as Werner Herzog and Phillip Glass.",
                RatingTheMovieDB = 6,
                Rating = 0,
                Runtime = 48,
                Poster = null
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 374317,
                Title = "A Christmas Eve Conversation With Quentin Tarantino & Paul Thomas Anderson",
                ReleaseDate = new DateTime(2015, 12, 24),
                Overview = "Two great filmmakers discuss the evolution of film, 70mm and Tarantino's \"The Hateful Eight\".",
                RatingTheMovieDB = 10,
                Rating = 0,
                Runtime = 41,
                Poster = null
            });
            movieDTOs.Add(new DataTransferObject.MovieDTO()
            {
                Id = 463776,
                Title = "A Diary of Letters to God",
                ReleaseDate = new DateTime(2017, 6, 25),
                Overview = "Two orphan siblings, Anton and Angel, were forced to work as street beggars. An accident lead them separation for fifteen years. Angel's life now is filled with happiness, but the past still haunts her and she decided to find Anton.",
                RatingTheMovieDB = ParserUtils.ParseFloat("6,9"),
                Rating = 0,
                Runtime = 127,
                Poster = "/rPnhOGVxRAdYZQ2We6fKdfu5pvD.jpg"
            });
            return new APIResponseMultiplePagination<DataTransferObject.MovieDTO>()
            {
                Succeeded = true,
                StatusCode = 200,
                Message = "",
                Datas = movieDTOs,
                PageNumber = 1,
                PageSize = movieDTOs.Count,
                TotalPages = 69,
                FirstPage = null,
                LastPage = "https://127.0.0.1:5001/v1/Movies/Titles/pageNumber=69&pageCount=10",
                NextPage = "https://127.0.0.1:5001/v1/Movies/Titles/pageNumber=2&pageCount=10",
                PreviousPage = null,
                TotalRecords = 688
            };
        }
    }
}
