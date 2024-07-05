namespace CrudApi.Endpoint;
using Crud.Dao;
using Crud.Db;

using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using CrudApi.Requests;
using CrudApi.Response;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

public static class ArtistExtension
{

    public static void AddEndPointArtistas(this WebApplication app)
    {
        app.MapGet("/artists", ([FromServices] Generics<Artists> artist) =>
        {
            var listOfARtist = EntityListToResponse(artist.ListAll());
            return Results.Ok(listOfARtist);
        });

        app.MapGet("/artist/{name}", (string name) =>
        {
            var dalName = new Generics<Artists>(new CrudContext());
            var artist = dalName.GetBy(art => art.Name.Equals(name))!;

            if (artist is not null)
            {
                return Results.Ok(new ArtistResponse(artist.Id, artist.Name, artist.Bio, artist.Picture!));
            };
            return Results.NotFound($"Artist {name} doesn't exist");
        });

        app.MapPost("/artist", async ([FromServices] IHostEnvironment env, [FromServices] Generics<Artists> ArtistDal, [FromBody] ArtistRequest artistRequest) =>
        {

            var name = artistRequest.Name.Trim();
            var pictureName = DateTime.Now.ToString("ddMMyyyyhhss") + "." + name + ".jpeg";
            var path = Path.Combine(env.ContentRootPath, "wwwroot", "PictureArtist", pictureName);

            using MemoryStream stream = new MemoryStream(Convert.FromBase64String(artistRequest.Picture!));
            using FileStream fs = new(path, FileMode.Create);
            await stream.CopyToAsync(fs);

            var ArtistNew = new Artists(artistRequest.Name, artistRequest.Bio)
            {
                Picture = $"/PictureArtist/{pictureName}"
            };
            ArtistDal.OnCreate(ArtistNew);
            return Results.Ok(ArtistDal);

        });

        app.MapDelete("/artist/{id}", ([FromServices] Generics<Artists> artist, int id) =>
        {
            var artistToDelete = artist.GetBy(art => art.Id == id);
            if (artistToDelete is not null)
            {
                artist.OnDelete(artistToDelete!);
                return Results.Ok($"o artista {artistToDelete?.Name} foi deletado com successo");
            }
            return Results.NotFound($"artist with id: {id} doesnt exist !");

        });

        app.MapPut("/artist", ([FromServices] Generics<Artists> artist, ArtistsRequestEdit artistsRequestEdit) =>
        {
            var artistToUpdate = artist.GetBy(artist => artist.Id == artistsRequestEdit.Id);
            if (artistToUpdate is not null)
            {
                artistToUpdate.Bio = artistsRequestEdit.Bio;
                artistToUpdate.Name = artistsRequestEdit.Name;
                artist.OnUpdate(artistToUpdate);
                return Results.Ok($"{artistToUpdate.Name} foi atualizado com successo");
            }
            return Results.NotFound($"O registro {artistsRequestEdit.Id} não existe ");
        });

    }

    private static ICollection<ArtistResponse> EntityListToResponse(IEnumerable<Artists> listArtist)
    {
        return listArtist.Select(art => EntityToResponse(art)).ToList();
    }

    private static ArtistResponse EntityToResponse(Artists artist)
    {
        return new ArtistResponse(artist.Id, artist.Name, artist.Bio, artist.Picture!);
    }
}
