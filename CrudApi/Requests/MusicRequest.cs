using CrudSharedModel.Models;

namespace CrudApi.Requests;

public record class MusicRequest(string Artist, string Title, string OutYear, int ArtistId, ICollection<GeneroRequest> Generos);
