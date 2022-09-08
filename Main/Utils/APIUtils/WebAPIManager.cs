using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utils.APIUtils.Models;

namespace Utils.APIUtils
{
    static public class WebAPIManager
    {
        static HttpClientHandler clientHandler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
        };
        static HttpClient client = new HttpClient(clientHandler)
        {
            BaseAddress = new Uri("https://127.0.0.1:5001/v1/")
        };

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static async Task<APIResponseSingle<T>> ResponseToAPIResponseSingleAsync<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return new APIResponseSingle<T>(StatusCodes.Status204NoContent, "NoContent");
                return await response.Content.ReadAsAsync<APIResponseSingle<T>>();
            }
            dynamic dynamic = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            return new APIResponseSingle<T>((int)response.StatusCode, (string)dynamic.title);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiple<T>> ResponseToAPIResponseMultipleAsync<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return new APIResponseMultiple<T>(StatusCodes.Status204NoContent, "NoContent");
                return await response.Content.ReadAsAsync<APIResponseMultiple<T>>();
            }
            dynamic dynamic = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            return new APIResponseMultiple<T>((int)response.StatusCode, (string)dynamic.title);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiplePagination<T>> ResponseToAPIResponseMultiplePaginationAsync<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return new APIResponseMultiplePagination<T>(StatusCodes.Status204NoContent, "NoContent");
                return await response.Content.ReadAsAsync<APIResponseMultiplePagination<T>>();
            }
            dynamic dynamic = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            return new APIResponseMultiplePagination<T>((int)response.StatusCode, (string)dynamic.title);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageCount"></param>
        /// <param name="invalidComment"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiplePagination<CommentDTO>> GetListCommentsByIdMovieAsync(int idMovie, int pageNumber, int pageCount, bool invalidComment)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseMultiplePaginationAsync<CommentDTO>(await client.GetAsync("Comments/" + idMovie + "&pageNumber=" + pageNumber + "&pageCount=" + pageCount + "&invalidComment=" + invalidComment));
            }
            catch
            {
                return new APIResponseMultiplePagination<CommentDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComment"></param>
        /// <returns></returns>
        public static async Task<APIResponseSingle<CommentDTO>> GetCommentByIdCommentAsync(int idComment)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseSingleAsync<CommentDTO>(await client.GetAsync("Comments/" + idComment));
            }
            catch
            {
                return new APIResponseSingle<CommentDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="commentDTO"></param>
        /// <returns></returns>
        public static async Task<APIResponseSingle<CommentDTO>> InsertCommentOnMovieIdAsync(int idMovie, CommentDTO commentDTO)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseSingleAsync<CommentDTO>(await client.PostAsJsonAsync("Comments/" + idMovie, commentDTO));
            }
            catch
            {
                return new APIResponseSingle<CommentDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComment"></param>
        /// <returns></returns>
        public static async Task<APIResponseSingle<CommentDTO>> DeleteCommentByIdCommentAsync(int idComment)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseSingleAsync<CommentDTO>(await client.DeleteAsync("Comments/" + idComment));
            }
            catch
            {
                return new APIResponseSingle<CommentDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComment"></param>
        /// <param name="commentDTO"></param>
        /// <returns></returns>
        public static async Task<APIResponseSingle<CommentDTO>> ModifyCommentByIdCommentAsync(int idComment, CommentDTO commentDTO)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseSingleAsync<CommentDTO>(await client.PutAsJsonAsync("Comments/" + idComment, commentDTO));
            }
            catch
            {
                return new APIResponseSingle<CommentDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComment"></param>
        /// <param name="validate"></param>
        /// <returns></returns>
        public static async Task<APIResponseSingle<CommentDTO>> InvalidateOrValidateCommentByIdCommentAsync(int idComment, bool validate)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            JsonPatchDocument jsonPatchDocument = new JsonPatchDocument();
            try
            {
                return await ResponseToAPIResponseSingleAsync<CommentDTO>(await client.PatchAsync("Comments/" + idComment, new StringContent(JsonConvert.SerializeObject(jsonPatchDocument.Replace("/valid", validate)), Encoding.UTF8, "application/json")));
            }
            catch
            {
                return new APIResponseSingle<CommentDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiplePagination<LightActorDTO>> GetListActorsByIdMovieAsync(int idMovie, int pageNumber, int pageCount)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseMultiplePaginationAsync<LightActorDTO>(await client.GetAsync("Actors/" + idMovie + "&pageNumber=" + pageNumber + "&pageCount=" + pageCount));
            }
            catch
            {
                return new APIResponseMultiplePagination<LightActorDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiplePagination<ActorDTO>> GetFavoriteActorsAsync(int pageNumber, int pageCount)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseMultiplePaginationAsync<ActorDTO>(await client.GetAsync("Actors/" + "FavoriteActors/pageNumber=" + pageNumber + "&pageCount=" + pageCount));
            }
            catch
            {
                return new APIResponseMultiplePagination<ActorDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idActor"></param>
        /// <returns></returns>
        public static async Task<APIResponseSingle<ActorDTO>> GetActorByIdActorAsync(int idActor)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseSingleAsync<ActorDTO>(await client.GetAsync("Actors/" + idActor));
            }
            catch
            {
                return new APIResponseSingle<ActorDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public static async Task<APIResponseSingle<FullMovieDTO>> GetFullMovieDetailsByIdMovieAsync(int idMovie)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseSingleAsync<FullMovieDTO>(await client.GetAsync("Movies/" + idMovie));
            }
            catch
            {
                return new APIResponseSingle<FullMovieDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiplePagination<MovieDTO>> GetListMoviesOrderByReleaseDateAsync(int pageNumber, int pageCount)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseMultiplePaginationAsync<MovieDTO>(await client.GetAsync("Movies/" + "pageNumber=" + pageNumber + "&pageCount=" + pageCount));
            }
            catch
            {
                return new APIResponseMultiplePagination<MovieDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiplePagination<MovieDTO>> FindListMovieByPartialMovieTitleAsync(string title, int pageNumber, int pageCount)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseMultiplePaginationAsync<MovieDTO>(await client.GetAsync("Movies/title=" + title + "&pageNumber=" + pageNumber + "&pageCount=" + pageCount));
            }
            catch
            {
                return new APIResponseMultiplePagination<MovieDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiplePagination<MovieDTO>> FindListMovieByPartialActorNameAsync(string name, int pageNumber, int pageCount)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseMultiplePaginationAsync<MovieDTO>(await client.GetAsync("Movies/name="+ name + "&pageNumber=" + pageNumber + "&pageCount=" + pageCount));
            }
            catch
            {
                return new APIResponseMultiplePagination<MovieDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiplePagination<MovieDTO>> GetListMoviesFromUrlAsync(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseMultiplePaginationAsync<MovieDTO>(await client.GetAsync(url.Replace(client.BaseAddress.ToString(), "")));
            }
            catch
            {
                return new APIResponseMultiplePagination<MovieDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiplePagination<LightActorDTO>> GetListLightActorsFromUrlAsync(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseMultiplePaginationAsync<LightActorDTO>(await client.GetAsync(url.Replace(client.BaseAddress.ToString(), "")));
            }
            catch
            {
                return new APIResponseMultiplePagination<LightActorDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiplePagination<CommentDTO>> GetListCommentsFromUrlAsync(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseMultiplePaginationAsync<CommentDTO>(await client.GetAsync(url.Replace(client.BaseAddress.ToString(), "")));
            }
            catch
            {
                return new APIResponseMultiplePagination<CommentDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        public static async Task<APIResponseMultiple<MovieTypeDTO>> GetListMovieTypesByIdMovieAsync(int idMovie)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                return await ResponseToAPIResponseMultipleAsync<MovieTypeDTO>(await client.GetAsync("MovieTypes/" + idMovie));
            }
            catch
            {
                return new APIResponseMultiple<MovieTypeDTO>(StatusCodes.Status504GatewayTimeout, "Gateway Time-out");
            }
        }
    }
}
