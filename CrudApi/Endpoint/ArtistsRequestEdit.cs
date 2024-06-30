using CrudApi.Requests;
using System.ComponentModel.DataAnnotations;

namespace CrudApi.Endpoint
{
    public record ArtistsRequestEdit([Required] int Id, [Required] string Name, [Required] string Bio) : ArtistRequest(Name, Bio);
}
