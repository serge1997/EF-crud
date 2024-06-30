using System.ComponentModel.DataAnnotations;

namespace CrudWeb.Requests;

public record ArtistsRequestEdit([Required] int Id, [Required] string Name, [Required] string Bio) : ArtistRequest(Name, Bio);
