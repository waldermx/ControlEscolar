using Microsoft.EntityFrameworkCore;
using ControlEscolar.Core.Usuarios;
using System.Collections.Generic;
using System.Linq;

namespace ControlEscolar.Data
{
    public class ProfesorRepository : IRepository<Profesor>
    {
        private readonly ControlEscolarContext _context;

        public ProfesorRepository(ControlEscolarContext context)
        {
            _context = context;
        }

        public void AgregarUsuario(Profesor entidad)
        {
            if (entidad == null)
            {
                throw new ArgumentNullException(nameof(entidad), "El usuario no puede ser nulo.");
            }

            if (_context.Profesor.Any(e => e.Matricula == entidad.Matricula))
            {
                throw new InvalidOperationException("Ya existe un usuario con la misma matrícula.");
            }

            _context.Profesor.Add(entidad);
            _context.SaveChanges(); // Guarda los cambios en la base de datos
        }

        public IEnumerable<Profesor> ObtenerUsuarios()
        {
            return _context.Profesor.ToList(); // Retorna todos los profesores de la base de datos
        }

        public Profesor? ObtenerUsuarioPorMatricula(string matricula)
        {
            return _context.Profesor.FirstOrDefault(e => e.Matricula == matricula); // Busca un profesor por matrícula
        }

        public void ActualizarUsuario(Profesor entidad)
        {
            var existingEntity = _context.Profesor.FirstOrDefault(e => e.Matricula == entidad.Matricula);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("No se encontró el usuario a actualizar.");
            }

            // Actualiza las propiedades del profesor existente
            _context.Entry(existingEntity).CurrentValues.SetValues(entidad);
            _context.SaveChanges(); // Guarda los cambios en la base de datos
        }

        public void EliminarUsuario(string matricula)
        {
            var entidad = _context.Profesor.FirstOrDefault(e => e.Matricula == matricula);
            if (entidad != null)
            {
                _context.Profesor.Remove(entidad);
                _context.SaveChanges(); // Guarda los cambios en la base de datos
            }
        }
    }
}