using ControlEscolar.Algorithms;
using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Core.Usuarios;


public class Alumno : IMatriculable
{
    public string Nombre { get; set; }
    public string Matricula { get; }

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
    }
