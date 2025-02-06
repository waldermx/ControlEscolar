using ControlEscolar.Core.Interfaces;
using ControlEscolar.Data;
using ControlEscolar.Core.Entities;
using ControlEscolar.Core.Usuarios;
namespace ControlEscolar.Core.BusinessLogic;

public class CalificacionesMenu : IMenu
{
    // Implementación de IMenuItem
    public char CommandKey => 'c';
    public string Description => "Menú Calificaciones";
    
    private readonly IRepository<Calificacion> _calificacionRepository;
    private readonly IRepository<Alumno> _alumnoRepository;
    private readonly IRepository<Materia> _materiaRepository;
    private readonly List<IOperation> _subItems;

    public CalificacionesMenu(
        IRepository<Calificacion> calificacionRepository,
        IRepository<Alumno> alumnoRepository,
        IRepository<Materia> materiaRepository)
    {
        _calificacionRepository = calificacionRepository;
        _alumnoRepository = alumnoRepository;
        _materiaRepository = materiaRepository;
        _subItems = new List<IOperation>
        {
            new VerCalificacionesOperation(_calificacionRepository),
            new RegistrarCalificacionOperation(_calificacionRepository, _alumnoRepository, _materiaRepository), 
            new ModificarCalificacionOperation(_calificacionRepository),
            new RegresarMenuPrincipalOperation()
        };
    }

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