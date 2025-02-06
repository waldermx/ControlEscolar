using ControlEscolar.Core.Entities;
using ControlEscolar.Core.Usuarios;
namespace ControlEscolar.Data;

public class CalificacionRepository : IRepository<Calificacion>
{
    private readonly List<Calificacion> _entidades = new();

    public void AgregarUsuario(Calificacion entidad)
    {
        if (entidad == null)
            throw new ArgumentNullException(nameof(entidad), "La calificación no puede ser nula.");

        // Aquí podrías incluir lógica adicional, por ejemplo,
        // evitar duplicados o validar que la calificación se encuentre dentro de un rango permitido

        _entidades.Add(entidad);
    }

    public IEnumerable<Calificacion> ObtenerTodos()
    {
        return _entidades;
    }
    public IEnumerable<Calificacion> ObtenerUsuarios()
    {
        return _entidades;
    }

    public Calificacion? ObtenerUsuarioPorMatricula(string matricula)
    {
        return _entidades.FirstOrDefault(c => c.Alumno.Matricula == matricula);
    }

    public void ActualizarUsuario(Calificacion entidad)
    {
        var index = _entidades.FindIndex(c => c.Alumno.Matricula == entidad.Alumno.Matricula);
        if (index != -1)
            _entidades[index] = entidad;
    }

    public void EliminarUsuario(string matricula)
    {
        _entidades.RemoveAll(c => c.Alumno.Matricula == matricula);
    }

    public Calificacion? ObtenerUsuarioPorId(int id)
    {
        return _entidades.FirstOrDefault(c => c.Id == id);
    }
}
