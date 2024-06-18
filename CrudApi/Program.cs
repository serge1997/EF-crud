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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddEndPointArtistas();
app.AddEndPointMusic();

app.UseSwagger();
app.UseSwaggerUI();
// /swagger/index.html

app.Run();
