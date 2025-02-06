using ControlEscolar.Core.Interfaces;
using ControlEscolar.Core.Usuarios;
using ControlEscolar.Data;


public class ListarAlumnosOperation : IOperation
{
    private readonly IRepository<Alumno> _repository;

    public ListarAlumnosOperation(IRepository<Alumno> repository)
    {
        _repository = repository;
    }

    public char CommandKey => '1';
    public string Description => "Listar Alumnos";

    public void Execute()
    {
        Console.WriteLine("\nLista de Alumnos");
        Console.WriteLine("----------------");

        var alumnos = _repository.ObtenerUsuarios();

        if (!alumnos.Any())
        {
            Console.WriteLine("No hay alumnos registrados.");
        }
        else
        {
            foreach (var alumno in alumnos)
            {
                Console.WriteLine($"ID: {alumno.Matricula} - Nombre: {alumno.Nombre}");
            }
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}

public class AgregarAlumnoOperation : IOperation
{
    private readonly IRepository<Alumno> _repository;

    public AgregarAlumnoOperation(IRepository<Alumno> repository)
    {
        _repository = repository;
    }

    public char CommandKey => '2';
    public string Description => "Agregar Alumno";

    public void Execute()
    {
        Console.WriteLine("\nAgregar Nuevo Alumno");
        Console.WriteLine("-------------------");



        Console.Write("Ingrese el nombre completo: ");
        string nombre = Console.ReadLine() ?? "";

        var alumno = new Alumno(nombre);

        try
        {
            _repository.AgregarUsuario(alumno);
            Console.WriteLine("\nAlumno agregado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}

public class ModificarAlumnoOperation : IOperation
{
    public char CommandKey => '3';
    public string Description => "Modificar Alumno";

    public void Execute()
    {
        // Logic to modify a student
    }
}

public class EliminarAlumnoOperation : IOperation
{
    public char CommandKey => '4';
    public string Description => "Eliminar Alumno";

    public void Execute()
    {
        // Logic to delete a student
    }
}

public class BuscarAlumnoOperation : IOperation
{
    public char CommandKey => '5';
    public string Description => "Buscar Alumno";

    public void Execute()
    {
        // Logic to search for a student
    }
}

public class RegresarMenuPrincipalOperation : IOperation
{
    public char CommandKey => '0';
    public string Description => "Regresar al Menú Principal";

    public void Execute()
    {
        // Logic to return to the main menu
    }
}