using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Core.BusinessLogic;

public class AlumnoMenu : IMenu
{
    private readonly Dictionary<char, IOperation> _operations;

    public AlumnoMenu()
    {
        _operations = new Dictionary<char, IOperation>
        {
            { '1', new Operation('1', "Agregar Alumno", AgregarAlumno) },
            { '2', new Operation('2', "Modificar Alumno", ModificarAlumno) },
            { '3', new Operation('3', "Eliminar Alumno", EliminarAlumno) },
            { '4', new Operation('4', "Listar Alumnos", ListarAlumnos) },
            { '5', new Operation('5', "Buscar Alumno", BuscarAlumno) },
            { '0', new Operation('0', "Regresar al Menú Principal", () => { }) }
        };
    }

    public void Display()
    {
        Console.WriteLine("\n=== Menú de Alumnos ===");
        foreach (var op in _operations.Values)
        {
            Console.WriteLine($"{op.CommandKey}: {op.Description}");
        }
        Console.WriteLine("=====================");
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

    private void AgregarAlumno()
    {
        // Implementar lógica para agregar alumno
        Console.WriteLine("Función Agregar Alumno");
    }

    private void ModificarAlumno()
    {
        // Implementar lógica para modificar alumno
        Console.WriteLine("Función Modificar Alumno");
    }

    private void EliminarAlumno()
    {
        // Implementar lógica para eliminar alumno
        Console.WriteLine("Función Eliminar Alumno");
    }

    private void ListarAlumnos()
    {
        // Implementar lógica para listar alumnos
        Console.WriteLine("Función Listar Alumnos");
    }

    private void BuscarAlumno()
    {
        // Implementar lógica para buscar alumno
        Console.WriteLine("Función Buscar Alumno");
    }
}