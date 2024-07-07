using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.Models;
using CrudSharedModel.Models;

namespace CrudSharedModel.Models;

public class GenerosMusics
{
    public Musics? _Music { get; set; }
    public Generos? _Generos { get; set; }
    public int? Music { get; set; }
    public int? Genero { get; set; }

    public GenerosMusics()
    {

    }

}
