using DataTransferObject;
using NUnit.Framework;
using System;
using Utils.APIUtils;
using Utils.APIUtils.Models;

namespace NUnitTestWebAPI
{
    public class NUnitTestWebAPI
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(11, 1, 10, true)]
        [TestCase(11, 2, 10, true)]
        [TestCase(11, 1, 10, false)]
        public void TestGetListCommentsByIdMovieAsync(int idMovie, int pageNumber, int pageCount, bool invalidComment)
        {
            APIResponseMultiplePagination<CommentDTO> response = WebAPIManager.GetListCommentsByIdMovieAsync(idMovie, pageNumber, pageCount, invalidComment).Result;
            if (response != null)
            {
                if (response.Succeeded)
                {
                    foreach (CommentDTO commentDTO in response.Datas)
                    {
                        Console.WriteLine(commentDTO.ToString());
                    }
                }
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(10)]
        [TestCase(40)]
        [TestCase(60)]
        public void TestGetCommentByIdCommentAsync(int idComment)
        {
            APIResponseSingle<CommentDTO> response = WebAPIManager.GetCommentByIdCommentAsync(idComment).Result;
            if(response != null)
            {
                if (response.Succeeded)
                    Console.WriteLine(response.Data.ToString());
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(11)]
        [TestCase(12)]
        [TestCase(60858)]
        [TestCase(9063)]
        [TestCase(75621)]
        public void TestInsertCommentOnMovieIdAsync(int idMovie)
        {
            CommentDTO commentDTO = new CommentDTO(DateTime.Now, 4, "Content InsertCommentOnMovieIdAsyncTest", "Username InsertCommentOnMovieIdAsyncTest");
            APIResponseSingle<CommentDTO> response = WebAPIManager.InsertCommentOnMovieIdAsync(idMovie, commentDTO).Result;
            if (response != null)
            {
                if (response.Succeeded)
                    Console.WriteLine(response.Data.ToString());
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(11)]
        [TestCase(41)]
        [TestCase(61)]
        public void TestDeleteCommentByIdCommentAsync(int idComment)
        {
            APIResponseSingle<CommentDTO> response = WebAPIManager.DeleteCommentByIdCommentAsync(idComment).Result;
            if (response != null)
            {
                if (response.Succeeded)
                    Console.WriteLine(response.Data.ToString());
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(10)]
        [TestCase(40)]
        [TestCase(60)]
        public void TestModifyCommentByIdCommentAsync(int idComment)
        {
            CommentDTO commentDTO = new CommentDTO(DateTime.Now, 4, "Content ModifyCommentByIdCommentAsyncTest", "Username ModifyCommentByIdCommentAsyncTest");
            APIResponseSingle<CommentDTO> response = WebAPIManager.ModifyCommentByIdCommentAsync(idComment, commentDTO).Result;
            if (response != null)
            {
                if (response.Succeeded)
                    Console.WriteLine(response.Data.ToString());
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }
        
        [TestCase(10, false)]
        [TestCase(40, true)]
        [TestCase(60, false)]
        public void TestInvalidateOrValidateCommentByIdCommentAsync(int idComment, bool valid)
        {
            APIResponseSingle<CommentDTO> response = WebAPIManager.InvalidateOrValidateCommentByIdCommentAsync(idComment, valid).Result;
            if (response != null)
            {
                if (response.Succeeded)
                    Console.WriteLine(response.Data.ToString());
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }
        
        [TestCase(11, 1, 10)]
        [TestCase(12, 1, 10)]
        [TestCase(60858, 1, 10)]
        [TestCase(9063, 1, 10)]
        [TestCase(75621, 1, 10)]
        public void TestGetListActorsByIdMovieAsync(int idMovie, int pageNumber, int pageCount)
        {
            APIResponseMultiplePagination<LightActorDTO> response = WebAPIManager.GetListActorsByIdMovieAsync(idMovie, pageNumber, pageCount).Result;
            if (response != null)
            {
                if (response.Succeeded)
                {
                    foreach (LightActorDTO lightActorDTO in response.Datas)
                    {
                        Console.WriteLine(lightActorDTO.ToString());
                    }
                }  
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(1, 10)]
        [TestCase(2, 10)]
        [TestCase(5, 10)]
        public void TestGetFavoriteActorsAsync(int pageNumber, int pageCount)
        {
            APIResponseMultiplePagination<ActorDTO> response = WebAPIManager.GetFavoriteActorsAsync(pageNumber, pageCount).Result;
            if (response != null)
            {
                if (response.Succeeded)
                {
                    foreach (LightActorDTO lightActorDTO in response.Datas)
                    {
                        Console.WriteLine(lightActorDTO.ToString());
                    }
                }
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void TestGetActorByIdActorAsync(int idActor)
        {
            APIResponseSingle<ActorDTO> response = WebAPIManager.GetActorByIdActorAsync(idActor).Result;
            if (response != null)
            {
                if (response.Succeeded)
                {
                    Console.WriteLine(response.Data.ToString());
                }
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(11)]
        [TestCase(12)]
        [TestCase(60858)]
        [TestCase(9063)]
        [TestCase(75621)]
        public void TestGetFullMovieDetailsByIdMovieAsync(int idMovie)
        {
            APIResponseSingle<FullMovieDTO> response = WebAPIManager.GetFullMovieDetailsByIdMovieAsync(idMovie).Result;
            if (response != null)
            {
                if (response.Succeeded)
                    Console.WriteLine(response.Data.ToString());
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(1, 10)]
        [TestCase(2, 10)]
        [TestCase(5, 10)]
        public void TestGetListMoviesOrderByReleaseDateAsync(int pageNumber, int pageCount)
        {
            APIResponseMultiplePagination<MovieDTO> response = WebAPIManager.GetListMoviesOrderByReleaseDateAsync(pageNumber, pageCount).Result;
            if (response != null)
            {
                if (response.Succeeded)
                {
                    foreach (MovieDTO movieDTO in response.Datas)
                    {
                        Console.WriteLine(movieDTO.ToString());
                    }
                }
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase("mrs. doubtfire", 1, 10)]
        [TestCase("the return", 1, 10)]
        [TestCase("revenge", 1, 10)]
        [TestCase("right under my eyes", 1, 10)]
        [TestCase("right", 1, 10)]
        [TestCase("star", 1, 10)]
        [TestCase("star wars", 1, 10)]
        [TestCase("NOT star", 1, 10)]
        [TestCase("NOT star", 2, 10)]
        [TestCase("Star Wars | mrs", 1, 10)]
        public void TestFindListMovieByPartialMovieTitleAsync(string title, int pageNumber, int pageCount)
        {
            APIResponseMultiplePagination<MovieDTO> response = WebAPIManager.FindListMovieByPartialMovieTitleAsync(title, pageNumber, pageCount).Result;
            if (response != null)
            {
                if (response.Succeeded)
                {
                    foreach (MovieDTO movieDTO in response.Datas)
                    {
                        Console.WriteLine(movieDTO.ToString());
                    }
                }
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase("wade thompson", 1, 10)]
        [TestCase("s", 1, 10)]
        [TestCase("salim", 1, 10)]
        [TestCase("hanks", 1, 10)]
        [TestCase("tom", 1, 10)]
        [TestCase("Salim Bedi", 1, 10)]
        [TestCase("ford", 1, 10)]
        [TestCase("Andrew", 1, 10)]
        [TestCase("harrison", 1, 10)]
        [TestCase("Mink", 1, 10)]
        [TestCase("NOT Dominique | Philippe", 1, 10)]
        public void TestFindListMovieByPartialActorNameAsync(string name, int pageNumber, int pageCount)
        {
            APIResponseMultiplePagination<MovieDTO> response = WebAPIManager.FindListMovieByPartialActorNameAsync(name, pageNumber, pageCount).Result;
            if (response != null)
            {
                if (response.Succeeded)
                {
                    foreach (MovieDTO movieDTO in response.Datas)
                    {
                        Console.WriteLine(movieDTO.ToString());
                    }
                }
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(11)]
        [TestCase(12)]
        [TestCase(60858)]
        [TestCase(9063)]
        [TestCase(75621)]
        public void TestGetListMovieTypesByIdMovieAsync(int idMovie)
        {
            APIResponseMultiple<MovieTypeDTO> response = WebAPIManager.GetListMovieTypesByIdMovieAsync(idMovie).Result;
            if (response != null)
            {
                if (response.Succeeded)
                {
                    foreach (MovieTypeDTO movieTypeDTO in response.Datas)
                    {
                        Console.WriteLine(movieTypeDTO.ToString());
                    }
                }
                else
                    Console.WriteLine(response.Message + " (" + response.StatusCode + ")");
                Assert.Pass();
            }
            else
                Assert.Fail();
        }
    }
}