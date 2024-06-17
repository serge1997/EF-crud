using Crud.Models;
using CrudSharedModel.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Crud.Db;

public class CrudContext : DbContext
{
    public DbSet<Artists> Artists { get; set; }
    public DbSet<Musics> Musics { get; set; }
    public DbSet<Generos> Generos { get; set; }

    private readonly string _ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=soundsNew;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Musics>().HasKey(mus => new
        {
            mus.Id,
        }) ;

        modelBuilder.Entity<Artists>().HasKey(art => new
        { 
            art.Id
        });

        modelBuilder.Entity<Musics>()
            .HasMany(c => c.Generos)
            .WithMany(c => c.Musics);

        base.OnModelCreating(modelBuilder);

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_ConnectionString);
    }
  
}
