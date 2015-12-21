namespace FastSmsSdk.Remote
{
    public interface IHttpClient
    {
        string GetResponse(string url, bool isPost = true);
    }
}
