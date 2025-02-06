using Microsoft.EntityFrameworkCore;
using ControlEscolar.Core.Usuarios;

namespace ControlEscolar.Data;

public class ControlEscolarContext : DbContext
{
   
    public DbSet<Alumno> Alumno { get; set;}
    public DbSet<Profesor> Profesor { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=127.0.0.1;Port=3307;Database=ControlEscolarDB;User Id=Coordinador;Password=Coordinador123;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Matricula); // Define Matricula como clave primaria
            entity.Property(e => e.Nombre).IsRequired(); 
            
        });

         modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Matricula); // Define Matricula como clave primaria
            entity.Property(e => e.Nombre).IsRequired(); 
            
        });
    }
}


