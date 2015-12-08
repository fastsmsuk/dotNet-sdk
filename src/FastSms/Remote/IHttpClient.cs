namespace FastSms.Remote
{
    internal interface IHttpClient
    {
        string GetResponse(string url, bool isPost = true);
    }
}
