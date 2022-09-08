using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = DataAccessLayer.Models.Type;

namespace NUnitTestDAL
{
    public class NUnitTestDAL
    {
        private MovieManager _movieManager;
        [SetUp]
        public void Setup()
        {
            _movieManager = new MovieManager();
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
            if (_movieManager.IsExistMovie(idMovie))
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
        public void TestIsExistType(int idType)
        {
            if (_movieManager.IsExistType(idType))
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
            if (_movieManager.IsExistComment(idComment))
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
            if (_movieManager.IsExistActor(idActor))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void TestInsertMovie()
        {
            Movie movie = new Movie(0, "TestInsertMovie", DateTime.Now, 10, 100, null);
            if (_movieManager.InsertMovie(movie))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void TestInsertType()
        {
            Type type = new Type(0, "TestInsertType");
            if (_movieManager.InsertType(type))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void TestInsertActor()
        {
            Actor actor = new Actor(0, "TestInsertTypeSurname", "TestInsertTypeName");
            if (_movieManager.InsertActor(actor))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TestCase(486847)]
        [TestCase(19551)]
        public void TestUpdateMovie(int idMovie)
        {
            Movie movie = new Movie(idMovie, "TestUpdateMovie", DateTime.Now, 10, 100, null);
            if (_movieManager.UpdateMovie(movie))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TestCase(486847)]
        [TestCase(19551)]
        public void TestUpdateComment(int idMovie)
        {
            Movie movie = _movieManager.GetMovieByIdMovie(idMovie);
            Comment comment = new Comment(movie, DateTime.Now, 5, "TestUpdateComment", "TestUpdateCommentUsername");
            if (_movieManager.UpdateComment(comment))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [TestCase(486847)]
        [TestCase(19551)]
        public void TestUpdateCommentWithCommentCreated(int idMovie)
        {
            Movie movie = _movieManager.GetMovieByIdMovie(idMovie);
            Comment commentCreated = new Comment();
            Comment comment = new Comment(movie, DateTime.Now, 5, "TestUpdateCommentWithCommentCreated", "TestUpdateCommentWithCommentCreatedUsername");
            if (_movieManager.UpdateComment(comment, out commentCreated))
                Assert.Pass(commentCreated.ToString());
            else
                Assert.Fail();
        }

        [TestCase(26)]
        [TestCase(27)]
        public void TestDeleteComment(int idComment)
        {
            Comment comment = _movieManager.GetCommentByIdComment(idComment);
            if (_movieManager.DeleteComment(comment))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void TestGetMoviesOrderByTitle()
        {
            List<Movie> movies = _movieManager.GetMoviesOrderByTitle().ToList();
            if (movies != null)
            {
                if(movies.Count > 0)
                {
                    foreach(Movie movie in movies)
                        Console.WriteLine(movie.ToString());
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(0, 10)]
        [TestCase(1, 10)]
        public void TestGetFullMoviesOrderByReleaseDate(int index, int take)
        {
            int fullMovieCount = 0;
            List<Movie> movies = _movieManager.GetMoviesOrderByReleaseDate(index, take, out fullMovieCount).ToList();
            if (movies != null)
            {
                if (movies.Count > 0)
                {
                    foreach (Movie movie in movies)
                        Console.WriteLine(movie.ToString());
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(486847, 19551)]
        public void TestGetMoviesByIdMovies(int firstIdMovie, int secondIdMovie)
        {
            List<int> idMovies = new List<int>();
            idMovies.Add(firstIdMovie);
            idMovies.Add(secondIdMovie);
            List<Movie> movies = _movieManager.GetMoviesByIdMovies(idMovies).ToList();
            if (movies != null)
            {
                if (movies.Count > 0)
                {
                    foreach (Movie movie in movies)
                        Console.WriteLine(movie.ToString());
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(486847)]
        [TestCase(19551)]
        public void TestGetMovieByIdMovie(int idMovie)
        {
            Movie movie = _movieManager.GetMovieByIdMovie(idMovie);
            if (movie != null && movie.Id != -1)
                Assert.Pass(movie.ToString());
            else
                Assert.Fail();
        }

        [TestCase(486847)]
        [TestCase(19551)]
        public void TestGetFullMovieByIdMovie(int idMovie)
        {
            Movie movie = _movieManager.GetFullMovieByIdMovie(idMovie);
            if (movie != null && movie.Id != -1)
                Assert.Pass(movie.ToString());
            else
                Assert.Fail();
        }

        [TestCase(486847)]
        [TestCase(19551)]
        public void TestGetTypesByIdMovie(int idMovie)
        {
            List<Type> types = _movieManager.GetTypesByIdMovie(idMovie).ToList();
            if (types != null)
            {
                if (types.Count > 0)
                {
                    foreach (Type type in types)
                        Console.WriteLine(type.ToString());
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(11, true, 0, 10)]
        [TestCase(11, false, 1, 10)]
        public void TestGetListCommentsByIdMovie(int idMovie, bool invalidComment, int index, int take)
        {
            int commentsCount = 0;
            List<Comment> comments = _movieManager.GetListCommentsByIdMovie(idMovie, invalidComment, index, take, out commentsCount).ToList();
            if (comments != null)
            {
                if (comments.Count > 0)
                {
                    foreach (Comment comment in comments)
                        Console.WriteLine(comment.ToString());
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
            Comment comment = _movieManager.GetCommentByIdComment(idComment);
            if (comment != null && comment.Id != -1)
                Assert.Pass(comment.ToString());
            else
                Assert.Fail();
        }

        [TestCase("mrs doubtfire")]
        [TestCase("the return")]
        [TestCase("revenge")]
        [TestCase("right under my eyes")]
        [TestCase("right")]
        [TestCase("star")]
        [TestCase("star wars")]
        public void TestGetMoviesByPartialOrEntirelyTitle(string title)
        {
            List<Movie> movies = _movieManager.GetMoviesByPartialOrEntirelyTitle(title).ToList();
            if (movies != null)
            {
                if (movies.Count > 0)
                {
                    foreach (Movie movie in movies)
                        Console.WriteLine(movie.ToString());
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase("Hanks")]
        [TestCase("Harrison")]
        [TestCase("Tom")]
        [TestCase("Robin")]
        [TestCase("williams")]
        public void TestGetActorsByPartialOrEntirelyName(string name)
        {
            List<Actor> actors = _movieManager.GetActorsByPartialOrEntirelyName(name).ToList();
            if (actors != null)
            {
                if (actors.Count > 0)
                {
                    foreach (Actor actor in actors)
                        Console.WriteLine(actor.ToString());
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
            List<Actor> actors = _movieManager.GetFavoriteActors(index, take, out actorsCount).ToList();
            if (actors != null)
            {
                if (actors.Count > 0)
                {
                    foreach (Actor actor in actors)
                        Console.WriteLine(actor.ToString() + " Count (Movie(s)) : " + actor.Movies.Count());
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(11, 1, 10)]
        [TestCase(140607, 1, 10)]
        public void TestGetActorsByIdMovie(int idMovie, int index, int take)
        {
            int actorsCount = 0;
            List<Actor> actors = _movieManager.GetActorsByIdMovie(idMovie, index, take, out actorsCount).ToList();
            if (actors != null)
            {
                if (actors.Count > 0)
                {
                    foreach (Actor actor in actors)
                        Console.WriteLine(actor.ToString());
                }
                Assert.Pass();
            }
            else
                Assert.Fail();
        }

        [TestCase(2)]
        [TestCase(3)]
        public void TestGetActorByIdActor(int idActor)
        {
            Actor actor = _movieManager.GetActorByIdActor(idActor);
            if (actor != null)
            {
                Assert.Pass(actor.ToString());
            }
            else
                Assert.Fail();
        }
    }
}