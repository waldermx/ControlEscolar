namespace ControlEscolar.Core.Interfaces;

public interface IBusinessLogic
{
    IEnumerable<IOperation> GetAvailableOperations();
}