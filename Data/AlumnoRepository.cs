using ControlEscolar.Core.Usuarios;
namespace ControlEscolar.Data;

public class AlumnoRepository : IRepository<Alumno> 
{
    private List<Alumno> _entidades;

    public AlumnoRepository()
    {
        _entidades = new List<Alumno>();
    }

    public void AgregarUsuario(Alumno entidad)
    {
        if (entidad == null)
        {
            throw new ArgumentNullException(nameof(entidad), "El usuario no puede ser nulo.");
        }

        if (_entidades.Any(e => e.Matricula == entidad.Matricula))
        {
            throw new InvalidOperationException("Ya existe un usuario con la misma matrícula.");
        }

        _entidades.Add(entidad);
    }

    public IEnumerable<Alumno> ObtenerUsuarios()
    {
        return _entidades;
    }

    public Alumno? ObtenerUsuarioPorMatricula(string matricula)
    {
        return _entidades.FirstOrDefault(e => e.Matricula == matricula);
    }

    public void ActualizarUsuario(Alumno entidad)
    {
        var existingEntity = _entidades.FirstOrDefault(e => e.Matricula == entidad.Matricula);
        if (existingEntity == null)
        {
            throw new InvalidOperationException("No se encontró el usuario a actualizar.");
        }

        var index = _entidades.IndexOf(existingEntity);
        _entidades[index] = entidad;
    }

    public void EliminarUsuario(string matricula)
    {
        var entidad = _entidades.FirstOrDefault(e => e.Matricula == matricula);
        if (entidad != null)
        {
            _entidades.Remove(entidad);
        }
    }
}

