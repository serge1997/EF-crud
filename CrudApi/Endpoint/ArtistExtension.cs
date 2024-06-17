namespace CrudApi.Endpoint;
using Crud.Dao;
using Crud.Db;

using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using CrudApi.Requests;
using CrudApi.Response;
using System.Runtime.CompilerServices;

public static class ArtistExtension
{

    public static void AddEndPointArtistas(this WebApplication app)
    {
        app.MapGet("/", ([FromServices] Generics<Artists> artist) =>
        {
            var listOfARtist = EntityListToResponse(artist.ListAll());
            return Results.Ok(listOfARtist);
        });

        app.MapGet("/artista/{nome}", (string nome) =>
        {
            var dalName = new Generics<Artists>(new CrudContext());
            var artist = dalName.GetBy(art => art.Name.Equals(nome))!;

            if (artist is not null)
            {
                return Results.Ok(artist);
            };
            return Results.NotFound($"Artist {nome} doesn't exist");
        });

        app.MapPost("/artist", ([FromServices] Generics<Artists> ArtistDal ,[FromBody] ArtistRequest artistRequest) =>
        {

            var ArtistNew = new Artists(artistRequest.nome, artistRequest.bio);
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
                artistToUpdate.Bio = artistsRequestEdit.bio;
                artistToUpdate.Name = artistsRequestEdit.nome;
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
