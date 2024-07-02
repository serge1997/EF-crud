using Crud.Dao;
using Crud.Models;
using Crud.Db;
using Microsoft.AspNetCore.Mvc;
using CrudApi.Endpoint;
using CrudSharedModel.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CrudContext>();
builder.Services.AddTransient<Generics<Artists>>();
builder.Services.AddTransient<Generics<Musics>>();
builder.Services.AddTransient<Generics<Generos>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", policy =>
    {
        policy.WithOrigins("https://localhost:7194")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddEndPointArtistas();
app.AddEndPointMusic();
app.AddEndPointGenero();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseCors("AllowOrigin");
app.UseAuthorization();
app.MapControllers();

app.Run();
