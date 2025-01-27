using ControlEscolar.Interfaces;
using ControlEscolar.EntityClasses;

namespace ControlEscolar.Factories
{
    public class AlumnoFactory : IEntidadFactory<Alumno>
    {
        private readonly IMatriculaStrategy _estrategia;

        public AlumnoFactory(IMatriculaStrategy estrategia)
        {
            _estrategia = estrategia;
        }

        public Alumno CrearEntidad(string nombre) => new Alumno(nombre, _estrategia);
    }
}