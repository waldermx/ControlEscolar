/*namespace ControlEscolar.Strategies;
public interface IMatriculaStrategy
{
    int GenerarMatricula();
}

    public class Matricula
    {
        private readonly string _valor;

        public Matricula(IMatriculaStrategy strategy)
        {
            _valor = strategy.GenerarMatricula();
        }

        public override string ToString() => _valor;

        public static implicit operator string(Matricula matricula) => matricula._valor;
    }

public class ProfesorMatriculaStrategy : IMatriculaStrategy
{
    public int GenerarMatricula()
    {
        // Lógica específica para generar matrícula de profesor
        Random random = new Random();
        return random.Next(1000, 10000);
    }
}

public class AlumnoMatriculaStrategy : IMatriculaStrategy
{
    public int GenerarMatricula()
    {
        // Ejemplo: Número aleatorio entre 50000 y 59999
        Random random = new Random();
        return random.Next(50000, 60000);
    }
}

*/