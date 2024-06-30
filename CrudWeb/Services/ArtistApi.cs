using CrudWeb.Response;
using System.Net.Http.Json;
using CrudWeb.Requests;

namespace CrudWeb.Services;

public class ArtistApi
{
    private readonly HttpClient _httpClient;

    public ArtistApi(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<ArtistResponse>?> GetArtistApiAsync()
    {
        return await
            _httpClient.GetFromJsonAsync<ICollection<ArtistResponse>>("artists");
    }

    public async Task CreateArtistAsync(ArtistRequest artistRequest)
    {
        await _httpClient.PostAsJsonAsync("artist", artistRequest);
    }
}
