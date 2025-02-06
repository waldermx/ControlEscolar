using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Infrastructure;
public class ConsoleMenu : IMenu
{

    public char CommandKey => 'M';  // Caracter para acceder al menú desde su padre
    public string Description => "Menú Principal";  // Descripción para mostrar en menús superiores
    private readonly Dictionary<char, IMenuItem> _menuItems;

    public ConsoleMenu(IBusinessLogic businessLogic)
    {
        _menuItems = businessLogic.GetAvailableOperations()
            .ToDictionary(item => item.CommandKey, item => item);
    }

    public void Display()
    {
        foreach (var item in _menuItems.Values)
        {
            Console.WriteLine($"{item.CommandKey}: {item.Description}");
        }
    }

    public void HandleOption(char input)
    {
        if (_menuItems.TryGetValue(input, out var selectedItem))
        {
            if (selectedItem is IOperation operation)
            {
                operation.Execute(); // Ejecutar operación directa
            }
            else if (selectedItem is IMenu subMenu)
            {
                // Manejar sub-menú recursivamente
                Console.WriteLine($"=== {subMenu.Description} ===");
                subMenu.Display();
                var subInput = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Salto de línea después de la entrada
                subMenu.HandleOption(subInput);
            }
        }
        else
        {
            Console.WriteLine("Opción inválida");
        }
    }
}
