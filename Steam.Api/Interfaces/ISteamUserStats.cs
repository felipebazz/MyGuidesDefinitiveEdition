using Refit;
using Steam.Api.Configuration;
using Steam.Api.Responses;

namespace Steam.Api.Interfaces
{
    public interface ISteamUserStats
    {
        [Get("/ISteamUserStats/GetSchemaForGame/v2?key={apiKey}&appId={appId}")]
        Task<SchemaForGameResponse> GetSchemaForGameAsync([Query][AliasAs("apiKey")]string apiKey, [Query][AliasAs("appId")]string appId);
    }
}
