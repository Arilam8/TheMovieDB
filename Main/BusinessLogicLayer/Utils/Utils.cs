using DataAccessLayer.Models;
using DataTransferObject;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Utils
{
    static class Utils
    {
        static public MovieTypeDTO TypeToMovieTypeDTO(Type type)
        {
            return new MovieTypeDTO(type.Id, type.Name);
        }

        static public IList<MovieTypeDTO> TypesToMovieTypeDTOs(IList<Type> types)
        {
            List<MovieTypeDTO> movieTypeDTOs = new List<MovieTypeDTO>();
            foreach (Type type in types)
                movieTypeDTOs.Add(TypeToMovieTypeDTO(type));
            return movieTypeDTOs;
        }

        static public RoleDTO RoleToRoleDTO(Role role)
        {
            return new RoleDTO(role.Id, role.Character);
        }

        static public IList<RoleDTO> RolesToRoleDTOs(IList<Role> roles)
        {
            List<RoleDTO> roleDTOs = new List<RoleDTO>();
            foreach(Role role in roles)
                roleDTOs.Add(RoleToRoleDTO(role));
            return roleDTOs;
        }

        static public LightActorDTO ActorToLightActorDTO(Actor actor)
        {
            return new LightActorDTO(actor.Id, actor.Surname, actor.Name, RolesToRoleDTOs(actor.Roles.ToList()));
        }

        static public IList<LightActorDTO> ActorsToLightActorDTOs(IList<Actor> actors)
        {
            List<LightActorDTO> lightActorDTOs = new List<LightActorDTO>();
            foreach(Actor actor in actors)
                lightActorDTOs.Add(ActorToLightActorDTO(actor));
            return lightActorDTOs;
        }

        static public ActorDTO ActorToActorDTO(Actor actor)
        {
            return new ActorDTO(actor.Id, actor.Surname, actor.Name, RolesToRoleDTOs(actor.Roles.ToList()), actor.Movies.Count());
        }

        static public IList<ActorDTO> ActorsToActorDTOs(IList<Actor> actors)
        {
            List<ActorDTO> actorDTOs = new List<ActorDTO>();
            foreach (Actor actor in actors)
                actorDTOs.Add(ActorToActorDTO(actor));
            return actorDTOs;
        }

        static public CommentDTO CommentToCommentDTO(Comment comment)
        {
            return new CommentDTO(comment.Id, comment.Date, comment.Rate, comment.Content, comment.Username, comment.Valid);
        }

        static public IList<CommentDTO> CommentsToCommentDTOs(IList<Comment> comments)
        {
            List<CommentDTO> commentDTOs = new List<CommentDTO>();
            foreach(Comment comment in comments)
                commentDTOs.Add(CommentToCommentDTO(comment));
            return commentDTOs;
        }

        static public FullMovieDTO MovieToFullMovieDTO(Movie movie)
        {
            return new FullMovieDTO(movie.Id, movie.Title, movie.ReleaseDate, movie.Rating, movie.Runtime, movie.Poster, CommentsToCommentDTOs(movie.Comments.ToList()), TypesToMovieTypeDTOs(movie.Types.ToList()));
        }

        static public IList<FullMovieDTO> MoviesToFullMovieDTOs(IList<Movie> movies)
        {
            List<FullMovieDTO> fullMovieDTOs = new List<FullMovieDTO>();
            foreach (Movie movie in movies)
                fullMovieDTOs.Add(MovieToFullMovieDTO(movie));
            return fullMovieDTOs;
        }

        static public MovieDTO MovieToMovieDTO(Movie movie)
        {
            return new MovieDTO(movie.Id, movie.Title, movie.ReleaseDate, movie.Rating, movie.Runtime, movie.Poster, CommentsToCommentDTOs(movie.Comments.ToList()));
        }

        static public IList<MovieDTO> MoviesToMovieDTOs(IList<Movie> movies)
        {
            List<MovieDTO> movieDTOs = new List<MovieDTO>();
            foreach(Movie movie in movies)
                movieDTOs.Add(MovieToMovieDTO(movie));
            return movieDTOs;
        }

        static public IList<MovieDTO> SortMovieDTOs(IList<MovieDTO> movieDTOs, List<int> idMovies)
        {
            List<MovieDTO> sortMovieDTOs = new List<MovieDTO>();
            foreach(int idMovie in idMovies)
            {
                if(movieDTOs.Any(m => m.Id == idMovie))
                    sortMovieDTOs.Add(movieDTOs.Where(m => m.Id == idMovie).FirstOrDefault());
            }
            return sortMovieDTOs;
        }

        static public IList<int> GetIdMoviesActor(List<Actor> actors, IList<int> idMovies)
        {
            if (actors != null && actors.Count > 0)
            {
                foreach (Actor actor in actors)
                {
                    foreach (Movie movie in actor.Movies)
                    {
                        if (!idMovies.Contains(movie.Id))
                            idMovies.Add(movie.Id);
                    }
                }
            }
            return idMovies;
        }

        static public IList<int> GetIdMoviesMovie(IList<Movie> movies, IList<int> idMovies)
        {
            if (movies != null && movies.Count > 0)
            {
                foreach (Movie movie in movies)
                {
                    if (!idMovies.Contains(movie.Id))
                        idMovies.Add(movie.Id);
                }
            }
            return idMovies;
        }

        static public IList<KeyValuePair<int, int>> GetPertinenceMovies(IList<int> idMovies, IList<KeyValuePair<int, int>> pertinenceMovies)
        {
            foreach (int idMovie in idMovies)
            {
                KeyValuePair<int, int> pertinanceMovie;
                if (!pertinenceMovies.Any(m => m.Key == idMovie))
                {
                    pertinanceMovie = new KeyValuePair<int, int>(idMovie, 1);
                }
                else
                {
                    pertinanceMovie = pertinenceMovies.Where(m => m.Key == idMovie).FirstOrDefault();
                    pertinenceMovies.Remove(pertinanceMovie);
                    pertinanceMovie = new KeyValuePair<int, int>(pertinanceMovie.Key, pertinanceMovie.Value + 1);
                }
                pertinenceMovies.Add(pertinanceMovie);
            }
            return pertinenceMovies;
        }

        static public IList<KeyValuePair<int, int>> GetPertinenceMoviesWithNOT(IList<int> idMovies, IList<int> idMoviesNOT, IList<KeyValuePair<int, int>> pertinenceMovies)
        {
            foreach (int idMovie in idMovies)
            {
                KeyValuePair<int, int> pertinanceMovie;
                if (idMoviesNOT.Contains(idMovie))
                {
                    if (pertinenceMovies.Any(m => m.Key == idMovie))
                    {
                        pertinanceMovie = pertinenceMovies.Where(m => m.Key == idMovie).FirstOrDefault();
                        pertinenceMovies.Remove(pertinanceMovie);
                        pertinanceMovie = new KeyValuePair<int, int>(pertinanceMovie.Key, pertinanceMovie.Value - 1);
                        pertinenceMovies.Add(pertinanceMovie);
                    }
                }
                else
                {
                    if (!pertinenceMovies.Any(m => m.Key == idMovie))
                    {
                        pertinanceMovie = new KeyValuePair<int, int>(idMovie, 1);
                    }
                    else
                    {
                        pertinanceMovie = pertinenceMovies.Where(m => m.Key == idMovie).FirstOrDefault();
                        pertinenceMovies.Remove(pertinanceMovie);
                        pertinanceMovie = new KeyValuePair<int, int>(pertinanceMovie.Key, pertinanceMovie.Value + 1);
                    }
                    pertinenceMovies.Add(pertinanceMovie);
                }
            }
            return pertinenceMovies;
        }
    }
}
