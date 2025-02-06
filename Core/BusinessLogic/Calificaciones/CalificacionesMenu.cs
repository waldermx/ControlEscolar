using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Core.BusinessLogic;

public class CalificacionesMenu : IMenuItem
{
    // Implementación de IMenuItem
    public char CommandKey => 'C';
    public string Description => "Menú Calificaciones";
    
    // Sub-items del menú (operaciones relacionadas con calificaciones)
    private readonly List<IMenuItem> _subItems = new List<IMenuItem>
    {
        new VerCalificacionesOperation(),
        new RegistrarCalificacionOperation(),
        new ModificarCalificacionOperation(),
        new RegresarMenuPrincipalOperation()
    };

    public void Display()
    {
        Console.WriteLine("Sub-menú Calificaciones:");
        foreach (var item in _subItems)
        {
            Console.WriteLine($"{item.CommandKey}. {item.Description}");
        }
    }

    public void HandleOption(char option)
    {
        var selectedItem = _subItems.FirstOrDefault(i => i.CommandKey == option);
        
        if (selectedItem is IOperation operacion)
        {
            operacion.Execute(); // Ejecutar operación
        }
        else if (selectedItem is IMenu subMenu)
        {
            subMenu.Display();     // Mostrar sub-menú
            var input = Console.ReadKey().KeyChar;
            subMenu.HandleOption(input);
        }
    }
}