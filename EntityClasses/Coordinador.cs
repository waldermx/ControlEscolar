using ControlEscolar.Repositories.Interfaces;

namespace ControlEscolar.EntityClasses
{
    public class Coordinador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        public Coordinador(int id, string nombre, IRepository repository)
        {
            Id = id;
            Nombre = nombre;
            _repository = repository;
        }

        public void InscribirAlumno(IRepository repository, string nombre)
        {
            var alumno = new Alumno(nombre);
            repository.Agregar(alumno);
        }
    }
}