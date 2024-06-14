using Crud.Dao;
using Crud.Models;
using Crud.Db;
using Microsoft.AspNetCore.Mvc;
using CrudApi.Endpoint;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CrudContext>();
builder.Services.AddTransient<Generics<Artists>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddEndPointArtistas();

app.UseSwagger();
app.UseSwaggerUI();
// /swagger/index.html

app.Run();
