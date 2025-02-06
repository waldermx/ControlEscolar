
using ControlEscolar.Core.Usuarios;
namespace ControlEscolar.Core.Entities;
    public class Calificacion
    {
        // Propiedades de la clase
        public int Id { get; set; } // Identificador único de la calificación
        public required Alumno Alumno { get; set; } // Objeto Alumno asociado a la calificación
        public required Materia Materia { get; set; } // Objeto Materia asociado a la calificación
        public decimal Valor { get; set; } // Valor de la calificación (ejemplo: 9.5)
        public DateTime FechaRegistro { get; set; } // Fecha en que se registró la calificación

        // Constructor por defecto
        public Calificacion()
        {
            // Se recomienda inicializar las propiedades complejas o dejar que se asignen externamente
            FechaRegistro = DateTime.Now; // Por defecto, se asigna la fecha actual
        }

        // Constructor parametrizado
        public Calificacion(int id, Alumno alumno, Materia materia, decimal valor, DateTime fechaRegistro)
        {
            Id = id;
            Alumno = alumno ?? throw new ArgumentNullException(nameof(alumno));
            Materia = materia ?? throw new ArgumentNullException(nameof(materia));
            Valor = valor;
            FechaRegistro = fechaRegistro;
        }

        // Método para validar la calificación
        public bool EsValida()
        {
            // Validar que el valor de la calificación esté en un rango válido (ejemplo: 0 a 10)
            return Valor >= 0 && Valor <= 10;
        }

        // Método para mostrar la información de la calificación
        public override string ToString()
        {
            return $"ID: {Id}, Alumno: {Alumno.Nombre}, Materia: {Materia.Nombre}, Calificación: {Valor}, Fecha: {FechaRegistro.ToShortDateString()}";
        }
    }
