using ControlEscolar.Interfaces;

namespace ControlEscolar.EntityClasses
{
    public class Alumno : IMatriculable
    {
        public string Nombre { get; }
        public Matricula Matricula { get; }

        public Alumno(string nombre, IMatriculaStrategy estrategia)
        {
            Nombre = nombre;
            Matricula = new Matricula(estrategia);
        }
    }
}