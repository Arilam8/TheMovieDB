using DataTransferObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp
{

    static class APIManager
    {
        static string _host = "http://127.0.0.1:5000/v1";
        static string _hostSSL = "http://127.0.0.1:5000/v1";

        /*public static void InsertComment(int id, string content, int rate, string username)
        {
            string query = "/Comment/" + "?username=" + username + "&content=" + content + "&rate=" + rate + "&idMovie=" + id;

            using (var client = new HttpClient())
            {
                var q = _host + query;
                HttpResponseMessage r = client.PostAsync(q, null).Result;

                if (!r.IsSuccessStatusCode)
                {
                    Console.WriteLine("API Error");
                }
            }
        }

        /// <summary>
        /// Will return only the movie we want.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static FullMovieDTO GetFullMovieWithId(int id)
        {
            string query = "/Movie/id=" + id;
            String rawJson = "";
            using (var client = new WebClient())
            {
                String ourQuery = (_host + query);
                try
                {
                    rawJson = client.DownloadString(ourQuery);
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                    {
                        var resp = (HttpWebResponse)ex.Response;
                        if (resp.StatusCode == HttpStatusCode.NotFound) // HTTP 404
                        {
                            //the page was not found, continue with next in the for loop
                            Console.WriteLine(ex.Status);
                        }
                    }
                }

                FullMovieDTO lf = JsonConvert.DeserializeObject<FullMovieDTO>(rawJson);

                return lf;
            }
        }

        /// <summary>
        /// Will return a list of movies
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IList<MovieDTO> GetFullPageMovieWithId(int index, int count)
        {
            string query = "/Movie/index=" + index + "&nb=" + count;
            String rawJson = "";
            using (var client = new WebClient())
            {
                String ourQuery = (_host + query);
                
                try
                {
                    rawJson = client.DownloadString(ourQuery);
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                    {
                        var resp = (HttpWebResponse)ex.Response;
                        if (resp.StatusCode == HttpStatusCode.NotFound) // HTTP 404
                        {
                            //the page was not found, continue with next in the for loop
                            Console.WriteLine(ex.Status);
                        }
                    }
                }

                IList<MovieDTO> ourListOfMovies = JsonConvert.DeserializeObject<List<MovieDTO>>(rawJson);
                return ourListOfMovies;
            }
        }

        /// <summary>
        /// Will get a list of movies who are matching the title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static List<MovieDTO> GetListMovieWithName(string title)
        {

            string query = "/Movie/title=" + title;
            String rawJson = "";
            using (var client = new WebClient())
            {
                String ourQuery = (_host + query);
                
                try
                {
                    rawJson = client.DownloadString(ourQuery);
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                    {
                        var resp = (HttpWebResponse)ex.Response;
                        if (resp.StatusCode == HttpStatusCode.NotFound) // HTTP 404
                        {
                            //the page was not found, continue with next in the for loop
                            Console.WriteLine(ex.Status);
                        }
                    }
                }

                List<MovieDTO> lf = JsonConvert.DeserializeObject<List<MovieDTO>>(rawJson);
                return lf;
            }
        }

        /// <summary>
        /// Will get all the types for a specific movie.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<MovieTypeDTO> GetMovieTypes(int id)
        {
            string query = "/Movie/types/id=" + id;
            using (var client = new WebClient())
            {
                String ourQuery = (_host + query);
                String rawJson = "";
                try
                {
                    rawJson = client.DownloadString(ourQuery);
                } catch (WebException ex) 
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                    {
                        var resp = (HttpWebResponse)ex.Response;
                        if (resp.StatusCode == HttpStatusCode.NotFound) // HTTP 404
                        {
                            //the page was not found, continue with next in the for loop
                            Console.WriteLine(ex.Status);
                        }
                    }
                }
                List<MovieTypeDTO> ourListOfMoviesTypes = JsonConvert.DeserializeObject<List<MovieTypeDTO>>(rawJson);
                return ourListOfMoviesTypes;
            }
        }*/

        /// <summary>
        /// 
        /// </summary>GetPosterFromTMDB
        /// <param name="posterpath"></param>
        /// <returns></returns>
        public static BitmapImage GetPosterFromTMDB(String posterpath)
        {
            if (posterpath != null)
            {
                using (var client = new HttpClient())
                    return new BitmapImage(new Uri(posterpath));
            }
            else return (new BitmapImage());

        }


        // Icons : https://iconscout.com/icons/music-movie
        public static BitmapImage GetFilmTypeIconFromData(string name)
        {
            //new Uri(@"O:\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\WpfApp\Image\" + name.ToLower() + ".png");
            var outPutDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            var logoimage = Path.Combine(outPutDirectory, @"..\..\..\Image\");

            var a = new Uri(logoimage + name.ToLower() + ".png");
            Console.WriteLine(a.AbsolutePath);
            try
            {
                var image = new BitmapImage(a);
                return (image);
            }
            catch (System.IO.FileNotFoundException)
            {
                return (new BitmapImage());
            }
        }


    }
}
