// ControlEscolar.Interfaces.IRepository
namespace ControlEscolar.Interfaces
{
    public interface IRepository<T> where T : IMatriculable
    {
        void Agregar(T entidad);
        IEnumerable<T> ObtenerTodos();
    }
}