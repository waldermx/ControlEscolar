
public interface AlumnoRepository
{
    void AgregarAlumno(Alumno alumno);
    IEnumerable<Alumno> ObtenerTodosAlumnos();
}