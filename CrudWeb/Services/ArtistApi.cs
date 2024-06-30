using CrudWeb.Response;
using System.Net.Http.Json;
using CrudWeb.Requests;
using CrudWeb.Pages;

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

    public async Task DeleteArtistAsync(int id)
    {
        await _httpClient.DeleteAsync($"artist/{id}");
    }

    public async Task<ArtistResponse?> GetArtistByNameAsync(string name)
    {
        return await _httpClient.GetFromJsonAsync<ArtistResponse>($"artist/{name}");
    }

    public async Task UpdateArtistAsync(ArtistsRequestEdit request)
    {
        await _httpClient.PutAsJsonAsync("artist", request);
    }
}
