// ControlEscolar.EntityClasses.Coordinador
namespace ControlEscolar.EntityClasses
{
    public class Coordinador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        public Coordinador(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}