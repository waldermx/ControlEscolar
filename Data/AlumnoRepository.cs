using Microsoft.EntityFrameworkCore;
using ControlEscolar.Core.Usuarios;
using System.Collections.Generic;
using System.Linq;

namespace ControlEscolar.Data;



public class AlumnoRepository : IRepository<Alumno>
{
    private readonly ControlEscolarContext _context;

    public AlumnoRepository(ControlEscolarContext context)
    {
        _context = context;
    }

    public void AgregarUsuario(Alumno entidad)
    {
        if (entidad == null)
        {
            throw new ArgumentNullException(nameof(entidad), "El usuario no puede ser nulo.");
        }

        if (_context.Alumno.Any(e => e.Matricula == entidad.Matricula))
        {
            throw new InvalidOperationException("Ya existe un usuario con la misma matrícula.");
        }

        _context.Alumno.Add(entidad);
        _context.SaveChanges(); // Guarda los cambios en la base de datos
    }

    public IEnumerable<Alumno> ObtenerUsuarios()
    {
        return _context.Alumno.ToList(); // Retorna todos los alumnos de la base de datos
    }

    public Alumno? ObtenerUsuarioPorMatricula(string matricula)
    {
        return _context.Alumno.FirstOrDefault(e => e.Matricula == matricula); // Busca un alumno por matrícula
    }

    public void ActualizarUsuario(Alumno entidad)
    {
        var existingEntity = _context.Alumno.FirstOrDefault(e => e.Matricula == entidad.Matricula);
        if (existingEntity == null)
        {
            throw new InvalidOperationException("No se encontró el usuario a actualizar.");
        }

        // Actualiza las propiedades del alumno existente
        _context.Entry(existingEntity).CurrentValues.SetValues(entidad);
        _context.SaveChanges(); // Guarda los cambios en la base de datos
    }

    public void EliminarUsuario(string matricula)
    {
        var entidad = _context.Alumno.FirstOrDefault(e => e.Matricula == matricula);
        if (entidad != null)
        {
            _context.Alumno.Remove(entidad);
            _context.SaveChanges(); // Guarda los cambios en la base de datos
        }
    }
}