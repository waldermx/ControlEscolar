using ControlEscolar.Core.Interfaces;
using ControlEscolar.EntityClasses;
using ControlEscolar.Data;

namespace ControlEscolar.Core.BusinessLogic;

public class ApplicationOptions : IBusinessLogic
{
    public IEnumerable<IMenuItem> GetAvailableOperations()
    {
        var alumnoRepository = new AlumnoRepository();
        return new List<IMenuItem>
        {
            new AlumnoMenu(alumnoRepository),
            new CalificacionesMenu(),
        };
    }
}


public class HorariosOperation : IOperation
{
    public char CommandKey => '3';
    public string Description => "Gestionar Horarios";
    
    public void Execute()
    {
        Console.WriteLine("\n=== Gestión de Horarios ===");
        Console.WriteLine("1. Ver horarios");
        Console.WriteLine("2. Asignar horario");
        Console.WriteLine("3. Modificar horario");
        // TODO: Implementar lógica específica de horarios
    }
}

public class ProfesoresOperation : IOperation
{
    public char CommandKey => '4';
    public string Description => "Gestionar Profesores";
    
    public void Execute()
    {
        Console.WriteLine("\n=== Gestión de Profesores ===");
        Console.WriteLine("1. Ver lista de profesores");
        Console.WriteLine("2. Agregar profesor");
        Console.WriteLine("3. Buscar profesor por matrícula");
        // TODO: Implementar lógica específica de profesores
    }
}