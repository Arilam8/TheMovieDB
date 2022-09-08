using DataAccessLayer.Models;
using DataTransferObject;
using System.Collections.Generic;
using Utils.APIUtils;
using Utils.DownloadUtils;

namespace WebAPI.Utils
{
    static public class Utils
    {
        public static string GenerateUrlFirstPage(string url, int pageNumber, int pageCount, string find = null)
        {
            if (pageNumber == 1)
                return null;
            return Constant.WEBAPI_ADDRESS_IP + url.Replace("{pageNumber}", "1").Replace("{pageCount}", pageCount.ToString()).Replace("{title}", find).Replace("{name}", find);
        }

        public static string GenerateUrlFirstPage(string url, int idMovie, int pageNumber, int pageCount, bool invalidComment = false)
        {
            if (pageNumber == 1)
                return null;
            return Constant.WEBAPI_ADDRESS_IP + url.Replace("{idMovie}", idMovie.ToString()).Replace("{pageNumber}", "1").Replace("{pageCount}", pageCount.ToString()).Replace("{invalidComment}", invalidComment.ToString());
        }

        public static string GenerateUrlLastPage(string url, int pageNumber, int pageCount, int lastPage, string find = null)
        {
            if (lastPage == 1 || pageNumber == lastPage)
                return null;
            return Constant.WEBAPI_ADDRESS_IP + url.Replace("{pageNumber}", lastPage.ToString()).Replace("{pageCount}", pageCount.ToString()).Replace("{title}", find).Replace("{name}", find);
        }

        public static string GenerateUrlLastPage(string url, int idMovie, int pageNumber, int pageCount, int lastPage, bool invalidComment = false)
        {
            if (lastPage == 1 || pageNumber == lastPage)
                return null;
            return Constant.WEBAPI_ADDRESS_IP + url.Replace("{idMovie}", idMovie.ToString()).Replace("{pageNumber}", lastPage.ToString()).Replace("{pageCount}", pageCount.ToString()).Replace("{invalidComment}", invalidComment.ToString());
        }

        public static string GenerateUrlNextPage(string url, int pageNumber, int pageCount, int lastPage, string find = null)
        {
            if (lastPage == 1 || pageNumber == lastPage)
                return null;
            return Constant.WEBAPI_ADDRESS_IP + url.Replace("{pageNumber}", (pageNumber + 1).ToString()).Replace("{pageCount}", pageCount.ToString()).Replace("{title}", find).Replace("{name}", find);
        }

        public static string GenerateUrlNextPage(string url, int idMovie, int pageNumber, int pageCount, int lastPage, bool invalidComment = false)
        {
            if (lastPage == 1 || pageNumber == lastPage)
                return null;
            return Constant.WEBAPI_ADDRESS_IP + url.Replace("{idMovie}", idMovie.ToString()).Replace("{pageNumber}", (pageNumber + 1).ToString()).Replace("{pageCount}", pageCount.ToString()).Replace("{invalidComment}", invalidComment.ToString());
        }

        public static string GenerateUrlPreviousPage(string url, int pageNumber, int pageCount, string find = null)
        {
            if (pageNumber == 1)
                return null;
            return Constant.WEBAPI_ADDRESS_IP + url.Replace("{pageNumber}", (pageNumber - 1).ToString()).Replace("{pageCount}", pageCount.ToString()).Replace("{title}", find).Replace("{name}", find);
        }

        public static string GenerateUrlPreviousPage(string url, int idMovie, int pageNumber, int pageCount, bool invalidComment = false)
        {
            if (pageNumber == 1)
                return null;
            return Constant.WEBAPI_ADDRESS_IP + url.Replace("{idMovie}", idMovie.ToString()).Replace("{pageNumber}", (pageNumber - 1).ToString()).Replace("{pageCount}", pageCount.ToString()).Replace("{invalidComment}", invalidComment.ToString());
        }

        public static bool IsPosterValid(MovieDTO movieDTO, out string newPoster)
        {
            if(!DownloadUtils.IsValidFileDownload(Constant.URL_IMAGE_THEMOVIEDB + movieDTO.Poster))
            {
                newPoster = APITheMovieDBManager.GetMoviePoster(movieDTO.Id);
                return false;
            }
            newPoster = string.Empty;
            return true;
        }

        public static FullMovieDTO SetAdditionalInformationFullMovieDTO(FullMovieDTO fullMovieDTO)
        {
            fullMovieDTO.Overview = APITheMovieDBManager.GetMovieOverview(fullMovieDTO.Id);
            fullMovieDTO.Logo = APITheMovieDBManager.GetMovieImageLogo(fullMovieDTO.Id);
            fullMovieDTO.Backdrop = APITheMovieDBManager.GetMovieImageBackdrop(fullMovieDTO.Id, 3840);
            if (string.IsNullOrWhiteSpace(fullMovieDTO.Backdrop))
                fullMovieDTO.Backdrop = APITheMovieDBManager.GetMovieImageBackdrop(fullMovieDTO.Id, 1920);
            return fullMovieDTO; 
        }

        public static LightActorDTO SetAdditionalInformationLightActorDTO(LightActorDTO lightActorDTO)
        {
            lightActorDTO.Image = APITheMovieDBManager.GetActorImage(lightActorDTO.Id);
            return lightActorDTO;
        }

        public static ActorDTO SetAdditionalInformationActorDTO(ActorDTO actorDTO)
        {
            actorDTO.Image = APITheMovieDBManager.GetActorImage(actorDTO.Id);
            actorDTO.Bio = APITheMovieDBManager.GetActorBio(actorDTO.Id);
            actorDTO.Birthdate = APITheMovieDBManager.GetActorBirthday(actorDTO.Id);
            actorDTO.Deathdate = APITheMovieDBManager.GetActorDeathdate(actorDTO.Id);
            return actorDTO;
        }

        public static List<LightActorDTO> SetAdditionalInformationLightActorDTOs(List<LightActorDTO> lightActorDTOs)
        {
            List<LightActorDTO> lightActorDTOWIs = new List<LightActorDTO>();
            foreach (LightActorDTO lightActorDTO in lightActorDTOs)
            {
                lightActorDTOWIs.Add(SetAdditionalInformationLightActorDTO(lightActorDTO));
            }
            return lightActorDTOWIs;
        }

        public static bool IsModificationComment(CommentDTO commentDTO, CommentDTO newCommentDTO)
        {
            if(commentDTO.Rate == newCommentDTO.Rate && commentDTO.Content == newCommentDTO.Content)
                return true;
            return false;
        }
    }
}
