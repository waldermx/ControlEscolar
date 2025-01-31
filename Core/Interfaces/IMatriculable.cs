// ControlEscolar.Interfaces.IMatriculable
namespace ControlEscolar.Core.Interfaces
{
    //Aplica solo a profesores y alumnos
    //
    public interface IMatriculable 
    {
        string Nombre { get; }
        string Matricula { get; }
    }
}