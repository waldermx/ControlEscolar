// ControlEscolar.Interfaces.IEntidadFactory
namespace ControlEscolar.Core.Interfaces;

    public interface IEntidadFactory<out T> where T : IMatriculable
    {
        T CrearEntidad(string nombre);
    }
