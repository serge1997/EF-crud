using CrudSharedModel.Models;

namespace CrudApi.Response;

public record class MusicRequest(string Artist, string Title, string OutYear, int ArtistId, ICollection<GeneroResponse> Generos);
