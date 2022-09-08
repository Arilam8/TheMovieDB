using BrowserApp.Models;
using BrowserApp.Models.Actors;
using BrowserApp.Models.Comments;
using DataTransferObject;
using System;
using System.Collections.Generic;

namespace BrowserApp.Utils
{
    static public class Utils
    {
        static public List<MovieModel> MovieDTOsToMovieModels(List<MovieDTO> movieDTOs)
        {
            List<MovieModel> movieModels = new List<MovieModel>();
            foreach (MovieDTO movieDTO in movieDTOs)
            {
                movieModels.Add(new MovieModel(movieDTO));
            }
            return movieModels;
        }

        static public List<LightActorModel> LightActorDTOsToLightActorModels(List<LightActorDTO> lightActorDTOs)
        {
            List<LightActorModel> lightActorModels = new List<LightActorModel>();
            foreach (LightActorDTO lightActorDTO in lightActorDTOs)
            {
                lightActorModels.Add(new LightActorModel(lightActorDTO));
            }
            return lightActorModels;
        }

        static public List<CommentModel> CommentDTOsToCommentModels(List<CommentDTO> commentDTOs)
        {
            List<CommentModel> commentModels = new List<CommentModel>();
            foreach (CommentDTO commentDTO in commentDTOs)
            {
                commentModels.Add(new CommentModel(commentDTO));
            }
            return commentModels;
        }

        static public string RatingToStar(float rating)
        {
            string ratingStar = String.Empty;
            int i = 0;
            while (i < Math.Round(rating))
            {
                ratingStar += "★";
                i++;
            }
            while (i < 5)
            {
                ratingStar += "☆";
                i++;
            }
            return ratingStar;
        }

        static public string GetValue(int typeSearch, string valueMovie, string valueActor)
        {
            string value = String.Empty;
            switch(typeSearch)
            {
                case Constant.SEARCH_TYPE_MOVIE_TITLE:
                    value = valueMovie;
                    break;
                case Constant.SEARCH_TYPE_MOVIE_ACTOR:
                    value = valueActor;
                    break;
                default:
                    break;
            }
            return value;
        }
    }
}
