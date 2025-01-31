using ControlEscolar.Data;

namespace ControlEscolar.Core.Usuarios;
    public class Coordinador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        public Coordinador(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public void InscribirAlumno(IRepository<Alumno> repository, string nombre)
        {
            var alumno = new Alumno(nombre);
            repository.AgregarUsuario(alumno);
        }
    }
