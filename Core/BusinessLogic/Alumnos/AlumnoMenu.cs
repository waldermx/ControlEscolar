using ControlEscolar.Core.Interfaces;
using ControlEscolar.Core.Usuarios;
using ControlEscolar.Data;
namespace ControlEscolar.Core.BusinessLogic;

public class AlumnoMenu : IMenu
{
    private readonly IRepository<Alumno> _alumnoRepository;
    private readonly List<IOperation> _subItems;
    
    // Implementación de IMenuItem
    public char CommandKey => 'a';
    public string Description => "Menú Alumnos";
    public AlumnoMenu(IRepository<Alumno> alumnoRepository)
    {
        _alumnoRepository = alumnoRepository;

        // Initialize _subItems in the constructor
        _subItems = new List<IOperation>
        {
            new ListarAlumnosOperation(_alumnoRepository),
            new AgregarAlumnoOperation(_alumnoRepository),
            new ModificarAlumnoOperation(),
            new EliminarAlumnoOperation(),
            new BuscarAlumnoOperation()
            //new RegresarMenuPrincipalOperation()
        };
    }



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