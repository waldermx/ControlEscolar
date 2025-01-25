namespace ControlEscolar.EntityClasses;
public interface IMatriculaStrategy
{
    int GenerarMatricula();
}

public class ProfesorMatriculaStrategy : IMatriculaStrategy
{
    public int GenerarMatricula()
    {
        // Lógica específica para generar matrícula de profesor
        // Ejemplo: Número aleatorio entre 1000 y 9999
        Random random = new Random();
        return random.Next(1000, 10000);
    }
}

public class AlumnoMatriculaStrategy : IMatriculaStrategy
{
    public int GenerarMatricula()
    {
        // Lógica específica para generar matrícula de alumno
        // Ejemplo: Número aleatorio entre 50000 y 59999
        Random random = new Random();
        return random.Next(50000, 60000);
    }
}

public class Matricula
{
    public int Valor { get; private set; }

    // Constructor que acepta una estrategia
    public Matricula(IMatriculaStrategy estrategia)
    {
        this.Valor = estrategia.GenerarMatricula();
    }
}