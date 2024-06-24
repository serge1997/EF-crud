namespace CrudWeb.Requests;

using System.ComponentModel.DataAnnotations;

public record class ArtistRequest([Required] string nome, [Required] string bio);
