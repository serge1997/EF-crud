using Crud.Models;
using Crud.Db;

namespace Crud.Dao;

public class MusicDao
{
    private CrudContext CrudContext { get; }

    public MusicDao()
    {
        CrudContext = new CrudContext();
    }

    public void OnCreate(Musics music)
    {
        CrudContext.Musics.Add(music);
        CrudContext.SaveChanges();
        Console.WriteLine("Music saved succesfully");
    }

    public Musics? OnGet(int id)
    {
        return CrudContext.Musics.FirstOrDefault(m => m.Id.Equals(id));
    }
    public void OnUpdate(Musics music)
    {
        CrudContext.Musics.Update(music);
        CrudContext.SaveChanges();
        Console.WriteLine("Music Updated succesfully");
    }
    public void OnDelete(int id)
    {
        CrudContext.Musics.Remove(OnGet(id)!);
        CrudContext.SaveChanges();
        Console.WriteLine("Music removed succesfully");
    }

    public List<Musics> listArtistMusic(int id)
    {
        return CrudContext.Musics.Where(mu => mu.ArtistsId == id).ToList();
    }
}
