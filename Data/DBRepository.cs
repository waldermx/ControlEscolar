using Microsoft.EntityFrameworkCore;
using ControlEscolar.Core.Usuarios;

namespace ControlEscolar.Data;

public class ControlEscolarContext : DbContext
{
    public DbSet<Alumno> Alumnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=127.0.0.1;Port=3307;Database=ControlEscolarDB;User Id=Coordinador;Password=Coordinador123;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}


