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
//builder.Services.AddTransient<Generics<GenerosMusics>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(options =>
{
    options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseStaticFiles();

app.AddEndPointArtistas();
app.AddEndPointMusic();
app.AddEndPointGenero();

app.UseSwagger();
app.UseSwaggerUI();


app.Run();
