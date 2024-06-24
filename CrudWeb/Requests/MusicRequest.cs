namespace CrudWeb.Requests;

public record class MusicRequest(string Artist, string Title, string OutYear, int ArtistId, ICollection<GeneroRequest> Generos);
