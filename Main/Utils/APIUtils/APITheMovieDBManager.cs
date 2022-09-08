using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Utils.APIUtils
{
    static public class APITheMovieDBManager
    {
        static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://api.themoviedb.org/3/")
        };
        static string _apiKey = "dbfff4081852db97cf7fabcc1cd7bb2c";

        /// <summary>
        /// Will check if the movie exists.
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public static bool IsValidMovie(int idMovie)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("movie/" + idMovie + "?api_key=" + _apiKey).Result;
            return response.IsSuccessStatusCode == true ? true : false;
        }

        /// <summary>
        /// Will return the poster's path.
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public static string GetMoviePoster(int idMovie)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("movie/" + idMovie + "?api_key=" + _apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                dynamic stuff = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                return stuff.poster_path;
            }
            return null;
        }

        /// <summary>
        /// Will return the movie's overview.
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public static string GetMovieOverview(int idMovie)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("movie/" + idMovie + "?api_key=" + _apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                dynamic stuff = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                return stuff.overview;
            }
            return null;
        }

        /// <summary>
        /// Will return all details movie.
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public static string GetMovieDetails(int idMovie)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("movie/" + idMovie + "?api_key=" + _apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            return null;
        }

        /// <summary>
        /// Will return all details movie.
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public static string GetMovieCredits(int idMovie)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("movie/" + idMovie + "/credits?api_key=" + _apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            return null;
        }

        /// <summary>
        /// Will return the image's path (actor)
        /// </summary>
        /// <param name="idActor"></param>
        /// <returns></returns>
        public static string GetActorImage(int idActor)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("person/" + idActor + "/images?api_key=" + _apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                dynamic credit = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                if(credit != null)
                {
                    JArray images = credit.profiles;
                    foreach (JObject jObject in images)
                    {
                        dynamic image = JObject.Parse(jObject.ToString());
                        if (ParserUtils.ParserUtils.ParseDouble((string)image.aspect_ratio) >= 0.667 && Math.Abs(ParserUtils.ParserUtils.ParseInt((string)image.width) - ParserUtils.ParserUtils.ParseInt((string)image.height)) <= 600)
                            return image.file_path;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idActor"></param>
        /// <returns></returns>
        public static string GetActorBio(int idActor)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("person/" + idActor + "?api_key=" + _apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                dynamic person = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                if (person != null)
                {
                    return person.biography;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idActor"></param>
        /// <returns></returns>
        public static DateTime GetActorBirthday(int idActor)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("person/" + idActor + "?api_key=" + _apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                dynamic person = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                if (person != null)
                {
                    if(person.birthday != null)
                        return person.birthday;
                    else
                        return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                }
            }
            return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idActor"></param>
        /// <returns></returns>
        public static DateTime GetActorDeathdate(int idActor)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("person/" + idActor + "?api_key=" + _apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                dynamic person = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                if (person != null)
                {
                    if (person.deathday != null)
                        return person.deathday;
                    else
                        return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                }
            }
            return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }

        /// <summary>
        /// Will return the image's path (movie's backdrop)
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public static string GetMovieImageBackdrop(int idMovie, int minWidth)
        {
            double average = 0;
            string urlBackdrop = string.Empty;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("movie/" + idMovie + "/images?api_key=" + _apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                dynamic images = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                if (images != null)
                {
                    JArray backdrops = images.backdrops;
                    foreach (JObject jObject in backdrops)
                    {
                        dynamic backdrop = JObject.Parse(jObject.ToString());
                        if (ParserUtils.ParserUtils.ParseInt((string)backdrop.width) >= minWidth && ParserUtils.ParserUtils.ParseDouble((string)backdrop.aspect_ratio) >= 1.778 && ParserUtils.ParserUtils.ParseDouble((string)backdrop.vote_average) >= average && DownloadUtils.DownloadUtils.IsValidFileDownload("https://image.tmdb.org/t/p/original" + backdrop.file_path))
                        {
                            average = ParserUtils.ParserUtils.ParseDouble((string)backdrop.vote_average);
                            urlBackdrop = backdrop.file_path;
                        }
                    }
                    return urlBackdrop;
                }
            }
            return null;
        }

        /// <summary>
        /// Will return the image's path (movie's logo)
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public static string GetMovieImageLogo(int idMovie)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("movie/" + idMovie + "/images?api_key=" + _apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                dynamic images = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                if (images != null)
                {
                    JArray logos = images.logos;
                    foreach (JObject jObject in logos)
                    {
                        dynamic logo = JObject.Parse(jObject.ToString());
                        if (logo.iso_639_1 == "" || logo.iso_639_1 == "en")
                            return logo.file_path;
                    }
                }
            }
            return null;
        }
    }
}
