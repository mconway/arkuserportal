using System.Net.Http;

namespace ArkPortalWebApi.Models
{
    public interface IWebApiClient
    {
        string BaseUrl { get; set; }

        HttpClient Client { get; set; }

        // This is a bit short-sided, but for testing purposes I needed an interface that could handle JSON passthru from a webservice
        // Will need future consideration, maybe a more generic interface that could handle both an RCON or Web Client (GetPlayers, GetState, etc)
        string Get();
    }
}