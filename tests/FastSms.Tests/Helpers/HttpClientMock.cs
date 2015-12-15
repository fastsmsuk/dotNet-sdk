using System.IO;
using System.Net;
using FastSms.Remote;

namespace FastSms.Tests.Helpers
{
    public class HttpClientMock : IHttpClient
    {
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
