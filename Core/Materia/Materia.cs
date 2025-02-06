using ControlEscolar.Core.Usuarios; // Asegúrate de que Profesor y Alumno estén en este espacio de nombres

namespace ControlEscolar.Core.Entities
{
    public class Materia
    {
        /// <summary>
        /// Código único que identifica la materia.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre descriptivo de la materia.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Profesor encargado de la materia.
        /// </summary>
        public required Profesor Profesor { get; set; }

        /// <summary>
        /// Lista de alumnos inscritos en la materia.
        /// </summary>
        public List<Alumno> Alumnos { get; set; } = [];

        /// <summary>
        /// Constructor por defecto.
        /// Inicializa la lista de alumnos.
        /// </summary>
        public Materia()
        {
            Id = new int();
            Nombre = string.Empty;
            // Se inicializa la lista para evitar nulos
            Alumnos = [];
        }

        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="Id">Código único de la materia.</param>
        /// <param name="nombre">Nombre de la materia.</param>
        /// <param name="profesor">Profesor encargado de la materia.</param>
        public Materia(string Id, string nombre, Profesor profesor)
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new ArgumentException("El código de la materia no puede ser nulo o vacío.", nameof(Id));

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la materia no puede ser nulo o vacío.", nameof(nombre));

            Profesor = profesor ?? throw new ArgumentNullException(nameof(profesor), "El profesor no puede ser nulo.");

            this.Id = int.Parse(Id);
            Nombre = nombre;
            Alumnos = [];
        }

        /// <summary>
        /// Método para inscribir un alumno a la materia.
        /// </summary>
        /// <param name="alumno">Alumno a inscribir.</param>
        public void InscribirAlumno(Alumno alumno)
        {
            if (alumno == null)
                throw new ArgumentNullException(nameof(alumno), "El alumno no puede ser nulo.");

            // Verificar si el alumno ya está inscrito
            if (!Alumnos.Exists(a => a.Matricula == alumno.Matricula))
            {
                Alumnos.Add(alumno);
            }
            else
            {
                throw new InvalidOperationException("El alumno ya se encuentra inscrito en esta materia.");
            }
        }

        /// <summary>
        /// Método para eliminar la inscripción de un alumno en la materia.
        /// </summary>
        /// <param name="matricula">Matrícula del alumno a eliminar.</param>
        public void EliminarAlumno(string matricula)
        {
            var alumno = Alumnos.Find(a => a.Matricula == matricula);
            if (alumno != null)
            {
                Alumnos.Remove(alumno);
            }
            else
            {
                throw new InvalidOperationException("No se encontró un alumno con la matrícula proporcionada en esta materia.");
            }
        }

        /// <summary>
        /// Sobreescribe el método ToString para mostrar la información de la materia.
        /// </summary>
        /// <returns>Cadena con los detalles de la materia.</returns>
        public override string ToString()
        {
            return $"Código: {Id}, Nombre: {Nombre}, Profesor: {Profesor.Nombre}, Alumnos Inscritos: {Alumnos.Count}";
        }
    }
}
