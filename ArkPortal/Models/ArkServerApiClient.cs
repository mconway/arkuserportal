using System.Net.Http;

namespace ArkPortalWebApi.Models
{
    public class ArkServerApiClient : IWebApiClient
    {
        private string baseUrl = "http://arkservers.net/api/query/74.82.237.253:27015";
        public string BaseUrl { get { return this.baseUrl; } set { this.baseUrl = value; } }

        private HttpClient client;

        public HttpClient Client { get { return this.client; } set { this.client = value; }}

        public ArkServerApiClient()
        {
            this.Client = new HttpClient();
        }

        public string Get()
        {
            return this.Client.GetStringAsync(this.BaseUrl).Result;
        }
    }
}