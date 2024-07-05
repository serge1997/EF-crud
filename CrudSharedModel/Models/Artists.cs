using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models;

public class Artists
{
    public string Name { get; set; }
    public string Bio { get; set; }
    public string? Picture { get; set; }
    public string? Birth { get; set; }
    public bool IsActive { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public ICollection<Musics> Music { get; set; } = new List<Musics>();

    public Artists(string name, string bio, string? birth = null, bool isActive = true)
    {
        this.Name = name;
        this.Bio = bio;
        Birth = birth;
        IsActive = isActive;
    }

    public override string ToString()
    {
        return $@"
            Id: {Id}
            Name: {Name}
            Bio: {Bio}";
    }

}
