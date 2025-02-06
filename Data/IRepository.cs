using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Data
{
    /// <summary>
    /// Interfaz para repositorios de Imatriculables
    /// </summary>
    /// <typeparam name="T">Debe implementar IMatriculable.</typeparam>
    public interface IRepository<T>
    {

        /// <param name="entidad">Tipo IMatriculable.</param>
        void AgregarUsuario(T entidad);


        /// <returns>Una colección de todas las entidades.</returns>
        IEnumerable<T> ObtenerUsuarios();

        /// <summary>
        /// Obtiene una entidad por su número de matrícula
        /// </summary>
        /// <param name="matricula">Número de matrícula a buscar</param>
        /// <returns>La entidad encontrada o null si no existe</returns>
        T ObtenerUsuarioPorMatricula(string matricula);
        /// <summary>
        /// Obtiene una entidad por su ID
        /// </summary>
        /// <param name="id">ID a buscar</param>
        /// <returns>La entidad encontrada o null si no existe</returns>
        T? ObtenerUsuarioPorId(int id);
        /// <summary>
        /// Actualiza una entidad existente en el repositorio.
        /// </summary>
        /// <param name="entidad">La entidad actualizada.</param>
        void ActualizarUsuario(T entidad);

        /// <summary>
        /// Elimina una entidad específica del repositorio.
        /// </summary>
        /// <param name="id">El identificador de la entidad a eliminar.</param>
        void EliminarUsuario(string matricula);
    }
}
