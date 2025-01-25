// ControlEscolar.EntityClasses.Profesor
using ControlEscolar.Interfaces;

namespace ControlEscolar.EntityClasses
{
    public class Profesor : IMatriculable
    {
        public string Nombre { get; }
        public Matricula Matricula { get; }

        public Profesor(string nombre, IMatriculaStrategy estrategia)
        {
            Nombre = nombre;
            Matricula = new Matricula(estrategia);
        }
    }
}