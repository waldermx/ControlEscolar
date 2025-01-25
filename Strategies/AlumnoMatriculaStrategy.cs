// ControlEscolar.Strategies.AlumnoMatriculaStrategy
using ControlEscolar.Interfaces;

namespace ControlEscolar.Strategies
{
    public class AlumnoMatriculaStrategy : IMatriculaStrategy
    {
        public int GenerarMatricula()
        {
            // Ejemplo: Matrícula entre 50000 y 59999
            Random random = new Random();
            return random.Next(50000, 60000);
        }
    }
}