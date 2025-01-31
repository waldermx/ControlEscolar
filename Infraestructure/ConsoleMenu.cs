using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Infrastructure;

public class ConsoleMenu : IMenu
{
    private readonly Dictionary<char, IOperation> _operations;

    public ConsoleMenu(IBusinessLogic businessLogic)
    {
        _operations = businessLogic.GetAvailableOperations()
            .ToDictionary(op => op.CommandKey, op => op);
    }

    public void Display()
    {
        foreach (var op in _operations.Values)
        {
            Console.WriteLine($"{op.CommandKey}: {op.Description}");
        }
    }

    public void HandleOption(char input)
    {
        if (_operations.TryGetValue(input, out var operation))
        {
            operation.Execute();
        }
        else
        {
            Console.WriteLine("Opción inválida");
        }
    }
}