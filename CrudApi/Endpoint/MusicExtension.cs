using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Crud.Dao;
using CrudApi.Requests;
using CrudApi.Response;
using CrudSharedModel.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrudApi.Endpoint;

public static class MusicExtension
{

    public static void AddEndPointMusic(this WebApplication app)
    {

        app.MapPost("/musics", ([FromServices] Generics<Musics> Music, [FromServices] Generics<Generos> Genero, [FromBody] MusicRequest Request) =>
        {
            var NewMusic = new Musics(Request.Artist, Request.Title, Request.OutYear, Request.ArtistId)
            {
                Generos = ToGeneroEntiry(Request.Generos),
            };
            Music.OnCreate(NewMusic);
            
            Results.Ok(NewMusic);
        });

        app.MapGet("/musics", ([FromServices] Generics<Musics> Music) =>
        {
            return Results.Ok(EntityMusicsResponse(Music.ListAll()));
        });
    }

    private static MusicResponse ToEntityMusic(Musics Music)
    {
        return new MusicResponse(Music.Id, Music.Artist, Music.Title, Music.OutYear!);
    }

    private static ICollection<MusicResponse> EntityMusicsResponse(IEnumerable<Musics> MusicsList)
    {
        return MusicsList.Select(Music => ToEntityMusic(Music)).ToList();
    }

    private static ICollection<Generos> ConvertToGenero(ICollection<GeneroRequest> Request)
    {
        return Request.Select(req => new Generos(req.Name, req.Description)).ToList();
    }

    public static ICollection<Generos> ToGeneroEntiry(ICollection<GeneroResponse> genero)
    {
        return genero.Select(s => new Generos(s.Name, s.Description)).ToList();
    }

    public static GeneroResponse ToGenero(Generos genero)
    {
        return new GeneroResponse(genero.Id, genero.Name, genero.Description);
    }
    
}
