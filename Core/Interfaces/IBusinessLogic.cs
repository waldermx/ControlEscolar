namespace ControlEscolar.Core.Interfaces;
public interface IOperation
{
    char CommandKey { get; }
    string Description { get; }
    void Execute();
}

public interface IBusinessLogic
{
    IEnumerable<IMenuItem> GetAvailableOperations();
}

public interface IMenuItem
{
    char CommandKey { get; }
    string Description { get; }
}