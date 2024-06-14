namespace Crud.Dao;

using Crud.Db;
using Crud.Models;

//with Generic dont need this class
public class ArtistsDao : Generics<Artists>
{
    
    public ArtistsDao(CrudContext Context) : base(Context) {}
}
