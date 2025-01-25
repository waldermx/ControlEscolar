// ControlEscolar.Services.Coordinador
using ControlEscolar.Interfaces;

namespace ControlEscolar.Services
{
    public class Coordinador
    {
        private readonly IRepository<IMatriculable> _repository;
        private readonly IEntidadFactory<IMatriculable> _factory;

        public Coordinador(
            IRepository<IMatriculable> repository, 
            IEntidadFactory<IMatriculable> factory
        ) {
            _repository = repository;
            _factory = factory;
        }

        public void InscribirEntidad(string nombre)
        {
            var entidad = _factory.CrearEntidad(nombre);
            _repository.Agregar(entidad);
        }
    }
}