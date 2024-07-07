using CrudWeb.Requests;
using System.Net.Http.Json;

namespace CrudWeb.Services;

public class MusicApi
{
    private HttpClient _httpClient;

    public MusicApi(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("API");
    }

    public async Task CreateMusicAsync(MusicRequest Request)
    {
        await _httpClient.PostAsJsonAsync("music", Request);
    }
}
