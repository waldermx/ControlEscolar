using ControlEscolar.Core.Entities;
using ControlEscolar.Core.Interfaces;
using System.Collections.Generic;

namespace ControlEscolar.Data
{
    public class MateriaRepository : IRepository<Materia>
    {
        // Lista privada para almacenar las materias
        private readonly List<Materia> _materias = new();

        public void AgregarUsuario(Materia materia)
        {
            if (materia == null)
                throw new ArgumentNullException(nameof(materia));

            // Verificar si ya existe una materia con el mismo código
            if (_materias.Any(m => m.Id == materia.Id))
                throw new InvalidOperationException($"Ya existe una materia con el código {materia.Id}");

            _materias.Add(materia);
        }

        public IEnumerable<Materia> ObtenerUsuarios()
        {
            return _materias.ToList();
        }

        public void ActualizarUsuario(Materia materia)
        {
            if (materia == null)
                throw new ArgumentNullException(nameof(materia));

            var materiaExistente = _materias.FirstOrDefault(m => m.Id == materia.Id);
            if (materiaExistente == null)
                throw new KeyNotFoundException($"No se encontró una materia con el código {materia.Id}");

            var index = _materias.IndexOf(materiaExistente);
            _materias[index] = materia;
        }

        public void EliminarUsuario(int Id)
        {
            var materia = _materias.FirstOrDefault(m => m.Id == Id);
            if (materia == null)
                throw new KeyNotFoundException($"No se encontró una materia con el código {Id}");

            _materias.Remove(materia);
        }

        public Materia ObtenerUsuarioPorId(int id)
        {
            return _materias.FirstOrDefault(m => m.Id == id)
                ?? throw new KeyNotFoundException($"No se encontró una materia con el ID {id}");
        }

        public Materia ObtenerUsuarioPorMatricula(string matricula)
        {
            throw new NotImplementedException($"Las materias no utilizan matrícula como identificador");
        }

        public void EliminarUsuario(string matricula)
        {
            throw new NotImplementedException($"Las materias no utilizan matrícula como identificador");
        }
    }
}