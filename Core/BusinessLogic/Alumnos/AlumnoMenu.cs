using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Core.BusinessLogic;

public class AlumnoMenu : IMenu
{
    // Implementación de IMenuItem
    public char CommandKey => 'a';
    public string Description => "Menú Alumnos";
    
    // Sub-items del menú (pueden ser operaciones u otros menús)
    private readonly List<IMenuItem> _subItems = new List<IMenuItem>
    {
        new AgregarAlumnoOperation()
    };

    public void Display()
    {
        Console.WriteLine("Sub-menú Alumnos:");
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