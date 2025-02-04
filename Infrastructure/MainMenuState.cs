using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Infrastructure;

public class MainMenuState : IMenuState
{
    private readonly MenuContext _context;

    public MainMenuState(MenuContext context)
    {
        _context = context;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("=== MENÚ PRINCIPAL ===");
        var operations = _context.BusinessLogic.GetAvailableOperations().ToList();
        
        foreach (var op in operations)
            Console.WriteLine($"{op.CommandKey}. {op.Description}");
        
        Console.WriteLine("Q. Salir");
        Console.WriteLine();
    }

    public void HandleInput(MenuContext context)
    {
        var input = char.ToUpper(Console.ReadKey().KeyChar);
        if (input.ToString().ToUpper() == "Q")
        if (input == 'Q')
        {
            Environment.Exit(0);
        }
        
        var operation = context.BusinessLogic.GetAvailableOperations()
            .FirstOrDefault(op => op.CommandKey == input);
        
        if (operation != null)
            context.PushState(operation);
    }
}