using ControlEscolar.Core.Interfaces;
using ControlEscolar.EntityClasses;
using ControlEscolar.Data;

namespace ControlEscolar.Core.BusinessLogic;

public class ApplicationOptions : IBusinessLogic
{
    public IEnumerable<IMenu> GetAvailableOperations()
    {
        return new List<IMenu>
        {
            new AlumnoMenu()
        };
    }
}

public class AlumnosOperation : IOperation
{
    public char CommandKey => '1';
    public string Description => "Gestionar Alumnos";
    
    public void Execute()
    {
        Console.WriteLine("\n=== Gestión de Alumnos ===");
        Console.WriteLine("1. Ver lista de alumnos");
        Console.WriteLine("2. Agregar alumno");
        Console.WriteLine("3. Buscar alumno por matrícula");
        // TODO: Implementar lógica específica de alumnos
    }
}

public class CalificacionesOperation : IOperation
{
    public char CommandKey => '2';
    public string Description => "Gestionar Calificaciones";
    
    public void Execute()
    {
        Console.WriteLine("\n=== Gestión de Calificaciones ===");
        Console.WriteLine("1. Ver calificaciones por alumno");
        Console.WriteLine("2. Registrar calificación");
        Console.WriteLine("3. Modificar calificación");
        // TODO: Implementar lógica específica de calificaciones
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