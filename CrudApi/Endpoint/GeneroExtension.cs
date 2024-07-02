namespace CrudApi.Endpoint;

using Crud.Models;
using Crud.Dao;
using Crud.Db;
using Microsoft.AspNetCore.Mvc;
using CrudApi.Requests;
using CrudApi.Response;
using CrudSharedModel.Models;
using System.Linq;

public static class GeneroExtension
{

    public static void AddEndPointGenero(this WebApplication app)
    {
        app.MapGet("/generos", ([FromServices] Generics<Generos> generos) =>
        {
            var listGeneros = ToListEntityToResponse(generos.ListAll());
            if (listGeneros is not null)
            {
                return Results.Ok(listGeneros);
            }
            return Results.NotFound("Nenhum genero encontrado");
        });

        app.MapPost("/genero", ([FromServices] Generics<Generos> Genero, [FromBody] GeneroRequest request) =>
        {
            Generos Gen = new(request.Name, request.Description);
            Genero.OnCreate(Gen);
            return Results.Ok(Gen);
         
        });


    
    }

    private static ICollection<GeneroResponse>? ToListEntityToResponse(IEnumerable<Generos> Generos)
    {
        return Generos.Select(art => EntityResponse(art)).ToList();
    }

    private static GeneroResponse EntityResponse(Generos genero)
    {
        return new GeneroResponse(genero.Id, genero.Name, genero.Description!);
    }
}
