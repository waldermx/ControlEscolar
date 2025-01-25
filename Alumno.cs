namespace ControlEscolar.EntityClasses;
public class Alumno{
    Matricula matricula;
    public Alumno(){
        IMatriculaStrategy AlumnoMatricula = new AlumnoMatriculaStrategy();
        Matricula matricula = new Matricula(AlumnoMatricula);
    }
}