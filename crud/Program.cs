using Crud.Dao;
using Crud.Db;
using Crud.Models;

try
{
    var context = new CrudContext();
    var dal = new Generics<Artists>(context);
    var music = new Generics<Musics>(context);
    Artists artist = new("Lourena", "Artista brasileira", "picture", "1991");
    //music.OnCreate(new Musics("Lourena", "Amor", "2022", 1));
    var musicDao = new MusicDao();
    //var find = dal.GetBy(art => art.Id == 2);
    //var findMusic = music.GetBy(mus => mus.Artist == "Dj arafat");

    //Console.WriteLine(find);

    //Artists newArtist = new("Aya Nakamura", "Artist pop", "picture");
   // var artistDao = new ArtistsDao();
    //var artistList = artistDao.ListAll();
    //var find = artistDao.Get(6);
    //find.Bio = "Meilleur artist";
    //artistDao.OnUpdate(find);
    //artistDao.OnCreate(newArtist);
    //Console.WriteLine(find?.Name);
    //artistDao.OnDelete(find!);

    foreach (var art in musicDao.listArtistMusic(1))
    {
        Console.WriteLine(art.Title);
    }
}catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.InnerException?.Message);
}