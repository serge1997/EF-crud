using CrudApi.Requests;
using System.ComponentModel.DataAnnotations;

namespace CrudApi.Endpoint
{
    public record ArtistsRequestEdit([Required] int Id, [Required] string nome, [Required] string bio) : ArtistRequest(nome, bio);
}
