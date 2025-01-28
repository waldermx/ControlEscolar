using ControlEscolar.Interfaces;

namespace ControlEscolar.Data
{
    public class InMemoryMatriculableRepository : IRepository<IMatriculable>
    {
        private readonly List<IMatriculable> _entidades = new List<IMatriculable>();

        public void Agregar(IMatriculable entidad) => _entidades.Add(entidad);
        public IEnumerable<IMatriculable> ObtenerTodos() => _entidades.AsReadOnly();
    }
}