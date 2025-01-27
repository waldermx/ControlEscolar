// ControlEscolar.Services.InscripcionService
using ControlEscolar.Interfaces;
using ControlEscolar.EntityClasses;

namespace ControlEscolar.Services
{
    public class InscripcionService
    {
        private readonly IRepository<Alumno> _alumnoRepository;
        private readonly IMatriculaStrategy _matriculaStrategy;

        public InscripcionService(
            IRepository<Alumno> alumnoRepository,
            IMatriculaStrategy matriculaStrategy)
        {
            _alumnoRepository = alumnoRepository;
            _matriculaStrategy = matriculaStrategy;
        }

        public void InscribirAlumno(string nombreAlumno, Coordinador coordinador)
        {
            // Validar permisos del coordinador si es necesario
            var alumno = new Alumno(nombreAlumno, _matriculaStrategy);
            _alumnoRepository.Agregar(alumno);
            
            Console.WriteLine($"[{coordinador.Nombre}] inscripción exitosa: {alumno.Nombre}");
        }
    }
}