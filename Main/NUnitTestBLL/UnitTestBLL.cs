using BusinessLogicLayer.BLLManager;
using DataTransferObject;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTestBLL
{
    public class NUnitTestBLL
    {
        private BLLManager _bllManager;
        [SetUp]
        public void Setup()
        {
            _bllManager = new BLLManager();
        }

        [TestCase(486847)]
        [TestCase(19551)]
        [TestCase(77625)]
        [TestCase(676)]
        [TestCase(46876)]
        [TestCase(142227)]
        [TestCase(144351)]
        public void TestIsExistMovie(int idMovie)
        {
            if (_bllManager.IsExistMovie(idMovie))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TestCase(12)]
        [TestCase(14)]
        [TestCase(16)]
        [TestCase(18)]
        [TestCase(27)]
        [TestCase(28)]
        [TestCase(35)]
        public void TestIsExistType(int idMovieType)
        {
            if (_bllManager.IsExistType(idMovieType))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TestCase(20)]
        [TestCase(21)]
        [TestCase(22)]
        [TestCase(23)]
        public void TestIsExistComment(int idComment)
        {
            if (_bllManager.IsExistComment(idComment))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TestCase(1271125)]
        [TestCase(2)]
        [TestCase(7727)]
        [TestCase(663)]
        [TestCase(104149)]
        [TestCase(3044)]
        [TestCase(15152)]
        public void TestIsExistActor(int idActor)
        {
            if (_bllManager.IsExistActor(idActor))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TestCase(0, 10)]
        [TestCase(1, 10)]
        public void TestGetListMoviesOrderByReleaseDate(int index, int take)
        {
            int movieCount = 0;
            IList<MovieDTO> movieDTOs = _bllManager.GetListMoviesOrderByReleaseDate(index, take, out movieCount);
            if (movieDTOs != null)
            {
                if (movieDTOs.Count > 0)
                {
                    foreach (MovieDTO movieDTO in movieDTOs)
                        Console.WriteLine(movieDTO.ToString() + "\n");
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(486847)]
        [TestCase(19551)]
        [TestCase(77625)]
        [TestCase(676)]
        [TestCase(46876)]
        [TestCase(142227)]
        [TestCase(144351)]
        public void TestGetFullMovieDetailsByIdMovie(int idMovie)
        {
            FullMovieDTO fullMovieDTO = _bllManager.GetFullMovieDetailsByIdMovie(idMovie);
            if (fullMovieDTO != null && fullMovieDTO.Id != -1)
                Assert.Pass(fullMovieDTO.ToString());
            else
                Assert.Fail();
        }

        [TestCase(486847, "TestUpdatePosterMovie")]
        [TestCase(19551, "TestUpdatePosterMovie")]
        [TestCase(77625, "TestUpdatePosterMovie")]
        [TestCase(676, "TestUpdatePosterMovie")]
        [TestCase(46876, "TestUpdatePosterMovie")]
        [TestCase(142227, "TestUpdatePosterMovie")]
        [TestCase(144351, "TestUpdatePosterMovie")]
        public void TestUpdatePosterMovie(int idMovie, string newPoster)
        {
            if (_bllManager.UpdatePosterMovie(idMovie, newPoster))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TestCase(486847)]
        [TestCase(19551)]
        [TestCase(77625)]
        [TestCase(676)]
        [TestCase(75621)]
        public void TestGetListMovieTypesByIdMovie(int idMovie)
        {
            IList<MovieTypeDTO> movieTypeDTOs = _bllManager.GetListMovieTypesByIdMovie(idMovie);
            if (movieTypeDTOs != null)
            {
                if (movieTypeDTOs.Count > 0)
                {
                    foreach (MovieTypeDTO movieTypeDTO in movieTypeDTOs)
                        Console.WriteLine(movieTypeDTO.ToString() + "\n");
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(486847, 1, 10)]
        [TestCase(19551, 1, 10)]
        [TestCase(77625, 1, 10)]
        [TestCase(676, 1, 10)]
        [TestCase(75621, 1, 10)]
        public void TestGetListActorsByIdMovie(int idMovie, int index, int take)
        {
            int actorsCount = 0;
            IList<LightActorDTO> lightActorDTOs = _bllManager.GetListActorsByIdMovie(idMovie, index, take, out actorsCount);
            if (lightActorDTOs != null)
            {
                if (lightActorDTOs.Count > 0)
                {
                    foreach (LightActorDTO lightActorDTO in lightActorDTOs)
                        Console.WriteLine(lightActorDTO.ToString() + "\n");
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(0, 10)]
        [TestCase(1, 10)]
        public void TestGetFavoriteActors(int index, int take)
        {
            int actorsCount = 0;
            IList<ActorDTO> actorDTOs = _bllManager.GetFavoriteActors(index, take, out actorsCount);
            if (actorDTOs != null)
            {
                if(actorDTOs.Count > 0)
                {
                    foreach (ActorDTO actorDTO in actorDTOs)
                        Console.WriteLine(actorDTO.ToString() + "\n");
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(4)]
        [TestCase(5)]
        public void TestGetActorByIdActor(int idActor)
        {
            ActorDTO actorDTO = _bllManager.GetActorByIdActor(idActor);
            if (actorDTO != null)
            {
                Assert.Pass(actorDTO.ToString());
            }
            else
                Assert.Fail();
        }

        [TestCase(11, 1, 10, true)]
        [TestCase(11, 1, 10, false)]
        public void TestGetListCommentsByIdMovie(int idMovie, int index, int take, bool invalidComment)
        {
            int commentsCount = 0;
            IList<CommentDTO> commentDTOs = _bllManager.GetListCommentsByIdMovie(idMovie, index, take, out commentsCount, invalidComment);
            if (commentDTOs != null)
            {
                if (commentDTOs.Count > 0)
                {
                    foreach (CommentDTO commentDTO in commentDTOs)
                        Console.WriteLine(commentDTO.ToString() + "\n");
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(22)]
        [TestCase(23)]
        public void TestGetCommentByIdComment(int idComment)
        {
            CommentDTO comment = _bllManager.GetCommentByIdComment(idComment);
            if (comment != null && comment.Id != -1)
                Assert.Pass(comment.ToString());
            else
                Assert.Fail();
        }

        [TestCase(60858)]
        [TestCase(9063)]
        [TestCase(75621)]
        public void TestInsertCommentOnIdMovie(int idMovie)
        {
            CommentDTO commentDTOInserted = new CommentDTO();
            CommentDTO commentDTO = new CommentDTO(DateTime.Now, 5, "TestInsertCommentOnIdMovie", "TestInsertCommentOnIdMovieUsername");
            if (_bllManager.InsertCommentOnIdMovie(idMovie, commentDTO, out commentDTOInserted))
                Assert.Pass(commentDTOInserted.ToString());
            else
                Assert.Fail();
        }
        
        [TestCase(26, true)]
        [TestCase(27, false)]
        public void TestModifyCommentByIdComment(int idComment, bool valid)
        {
            CommentDTO commentDTO = new CommentDTO(DateTime.Now, 5, "TestModifyCommentByIdComment", "TestModifyCommentByIdCommentUsername", valid);
            if (_bllManager.ModifyCommentByIdComment(idComment, commentDTO))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        public void TestDeleteCommentByIdComment(int IdComment)
        {
            if (_bllManager.DeleteCommentByIdComment(IdComment))
                Assert.Pass();
            else
                Assert.Fail();
        }
        
        [TestCase(27)]
        [TestCase(28)]
        public void TestValidateCommentByIdComment(int IdComment)
        {
            if (_bllManager.ValidateCommentByIdComment(IdComment))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TestCase(27)]
        [TestCase(28)]
        public void TestInalidateCommentByIdComment(int IdComment)
        {
            if (_bllManager.InvalidateCommentByIdComment(IdComment))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TestCase("mrs. doubtfire", 0, 10)]
        [TestCase("the return", 0, 10)]
        [TestCase("revenge", 0, 10)]
        [TestCase("right under my eyes", 0, 10)]
        [TestCase("right", 0, 10)]
        [TestCase("star", 0, 10)]
        [TestCase("star wars", 0, 10)]
        [TestCase("NOT star", 0, 10)]
        [TestCase("NOT star", 1, 10)]
        [TestCase("Star Wars | mrs", 0, 10)]
        public void TestFindListMovieByPartialMovieTitle(string title, int index, int take)
        {
            int moviesCount = 0;
            IList<MovieDTO> movieDTOs = _bllManager.FindListMovieByPartialMovieTitle(title, index, take, out moviesCount);
            if (movieDTOs != null)
            {
                if (movieDTOs.Count > 0)
                {
                    foreach (MovieDTO movieDTO in movieDTOs)
                        Console.WriteLine(movieDTO.ToString() + "\n");
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase("wade thompson", 0, 10)]
        [TestCase("s", 0, 10)]
        [TestCase("salim", 0, 10)]
        [TestCase("hanks", 0, 10)]
        [TestCase("tom", 0, 10)]
        [TestCase("Salim Bedi", 0, 10)]
        [TestCase("ford", 0, 10)]
        [TestCase("Andrew", 0, 10)]
        [TestCase("harrison", 0, 10)]
        [TestCase("Mink", 0, 10)]
        [TestCase("NOT Dominique | Philippe", 0, 10)]
        public void TestFindListMovieByPartialActorName(string name, int index, int take)
        {
            int moviesCount = 0;
            IList<MovieDTO> movieDTOs = _bllManager.FindListMovieByPartialActorName(name, index, take, out moviesCount);
            if (movieDTOs != null)
            {
                if (movieDTOs.Count > 0)
                {
                    foreach (MovieDTO movieDTO in movieDTOs)
                        Console.WriteLine(movieDTO.ToString() + "\n");
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }
    }
}