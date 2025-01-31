namespace ControlEscolar.Core.Interfaces;
public interface IOperation
{
    char CommandKey { get; }
    string Description { get; }
    void Execute();
}

public interface IBusinessLogic
{
    IEnumerable<IOperation> GetAvailableOperations();
}