using CrudSharedModel.Models;
using System.ComponentModel.DataAnnotations;

namespace Crud.Models;

public class Musics
{

    public string Artist { get; set; }
    public string Title{ get; set; }

    public string? OutYear { get; set; }

    public int Id { get; }

    public int ArtistsId { get; set; }
    public ICollection<Generos> Generos { get; set; }

    public Musics(string artist, string title, string outYear, int ArtistsId)
    {
        this.Artist = artist;
        this.Title = title;
        this.OutYear = outYear;
        this.ArtistsId = ArtistsId;
    }


    public override string ToString()
    {
        return $@"
                Name: {Artist}
                Title: {Title}
                Year: {OutYear}";
    }
}
