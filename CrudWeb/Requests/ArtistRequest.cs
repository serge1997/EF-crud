namespace CrudWeb.Requests;

using System.ComponentModel.DataAnnotations;

public record class ArtistRequest([Required] string Name, [Required] string Bio, string? Picture);
