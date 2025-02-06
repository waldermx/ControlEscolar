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
    private readonly IRepository<Alumno> _repository;

    public ModificarAlumnoOperation(IRepository<Alumno> repository)
    {
        _repository = repository;
    }

    public char CommandKey => '3';
    public string Description => "Modificar Alumno";

    public void Execute()
    {
        Console.WriteLine("\nModificar Alumno");
        Console.WriteLine("----------------");

        Console.Write("Ingrese la matrícula del alumno: ");
        string matricula = Console.ReadLine() ?? ""; // Read matricula as a string

        if (string.IsNullOrWhiteSpace(matricula))
        {
            Console.WriteLine("Matrícula inválida.");
            return;
        }

        var alumno = _repository.ObtenerUsuarioPorMatricula(matricula);
        if (alumno == null)
        {
            Console.WriteLine("Alumno no encontrado.");
            return;
        }

        Console.Write($"Ingrese el nuevo nombre ({alumno.Nombre}): ");
        string nuevoNombre = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(nuevoNombre))
        {
            alumno.Nombre = nuevoNombre;
            _repository.ActualizarUsuario(alumno);
            Console.WriteLine("Alumno modificado exitosamente.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}

public class EliminarAlumnoOperation : IOperation
{
    private readonly IRepository<Alumno> _repository;

    public EliminarAlumnoOperation(IRepository<Alumno> repository)
    {
        _repository = repository;
    }

    public char CommandKey => '4';
    public string Description => "Eliminar Alumno";

   public void Execute()
{
    Console.WriteLine("\nEliminar Alumno");
    Console.WriteLine("---------------");

    Console.Write("Ingrese la matrícula del alumno: ");
    string matricula = Console.ReadLine() ?? ""; // Read matricula as a string

    if (string.IsNullOrWhiteSpace(matricula))
    {
        Console.WriteLine("Matrícula inválida.");
        return;
    }

    try
    {
        _repository.EliminarUsuario(matricula);
        Console.WriteLine("Alumno eliminado exitosamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}
}

public class BuscarAlumnoOperation : IOperation
{
    private readonly IRepository<Alumno> _repository;

    public BuscarAlumnoOperation(IRepository<Alumno> repository)
    {
        _repository = repository;
    }

    public char CommandKey => '5';
    public string Description => "Buscar Alumno";

    public void Execute()
    {
        Console.WriteLine("\nBuscar Alumno");
        Console.WriteLine("-------------");

        Console.Write("Ingrese la matrícula del alumno: ");
        string matricula = Console.ReadLine() ?? ""; // Read matricula as a string

        if (string.IsNullOrWhiteSpace(matricula))
        {
            Console.WriteLine("Matrícula inválida.");
            return;
        }


        var alumno = _repository.ObtenerUsuarioPorMatricula(matricula);
        if (alumno == null)
        {
            Console.WriteLine("Alumno no encontrado.");
        }
        else
        {
            Console.WriteLine($"ID: {alumno.Matricula} - Nombre: {alumno.Nombre}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
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