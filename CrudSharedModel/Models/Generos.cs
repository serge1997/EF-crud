using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSharedModel.Models;

public class Generos
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<Musics> Musics { get; set; }
    public Generos(string name, string description)
    {
        this.Name = name;
        this.Description = description;
    }
}
