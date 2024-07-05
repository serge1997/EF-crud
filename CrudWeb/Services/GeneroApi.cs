namespace CrudWeb.Services;

using CrudWeb.Response;
using System.Net.Http.Json;
using CrudWeb.Requests;
public class GeneroApi
{
    private readonly HttpClient _httpClient;

    public GeneroApi(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<GeneroResponse>> GetGenerosAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<GeneroResponse>?>("generos");
    }
}
