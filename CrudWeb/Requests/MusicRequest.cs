namespace CrudWeb.Requests;

using CrudWeb.Response;
public record class MusicRequest(string Artist, string Title, string OutYear, int ArtistId, ICollection<GeneroResponse> Generos);
