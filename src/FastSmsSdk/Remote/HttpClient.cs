using System.IO;
using System.Net;

namespace FastSms.Remote
{
    internal class HttpClient : IHttpClient
    {
        /// <summary>
        ///    Gets response from API.
        /// </summary>
        /// <param name="url">Request url</param>
        /// <param name="isPost">Is post</param>
        /// <returns>Response from API.</returns>
        public string GetResponse(string url, bool isPost = true)
        {
            var response = string.Empty;

            // Create web request.
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = isPost ? "POST" : "GET";

            // Send request to api.
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(response);
                streamWriter.Flush();
            }

            // Get response from api.
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            return response;
        }
    }
}