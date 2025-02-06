using ControlEscolar.Algorithms;
using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Core.Usuarios;
using System.ComponentModel.DataAnnotations;

public class Alumno : IMatriculable
{
    [Key] 
    public string Nombre { get; private set; }
    public string Matricula { get; private set; }


    // Constructor sin parámetros para Entity Framework Core
    private Alumno()
    {
        
        
        // Este constructor es para EF Core, no debe ser usado directamente
    }

    public Alumno(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre no puede estar vacío", nameof(nombre));
            
        Nombre = nombre;
        Matricula = MatriculaGenerator.GenerarMatricula("A");
    }

    public static Alumno Crear(string nombre) => new(nombre);

    public override string ToString() => $"Alumno: {Nombre} - {Matricula}";
}

    public class Profesor : IMatriculable
    {
        public string Nombre { get; }
        public string Matricula { get; }

        public Profesor(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío", nameof(nombre));
                
            Nombre = nombre;
            Matricula = MatriculaGenerator.GenerarMatricula("P");
        }


        private Profesor(){
            
        }
    }
