using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Utils.APIUtils
{
    static public class APIGoogleDriveManager
    {
        static string _host = "https://www.googleapis.com/drive/v3/files/";
        static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri(_host)
        };
        static string _apiKey = "AIzaSyDcg_3urDPwFVDpnvy0mCzwmU3XTtTgu8M";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static string GetUrlDownloadFile(string fileId)
        {
            return _host + fileId + "?alt=media&key=" + _apiKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static string GetMD5ChecksumFile(string fileId)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(fileId + "?fields=md5Checksum&key=" + _apiKey).Result;
            if (response.IsSuccessStatusCode)
            {
                dynamic stuff = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                return stuff.md5Checksum; 
            }
            return null;
        }
    }
}
