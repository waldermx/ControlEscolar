using System;
using System.Collections.Generic;
using System.Linq; // ¡Necesario para Sum() y Average()!

// Interfaz y estrategias (sin cambios en la definición)
public interface ICalificacionStrategy
{
    double Calcular(List<double> calificaciones);
}

public class CalificacionParametro : ICalificacionStrategy
{
    public double Calcular(List<double> calificaciones)
    {
        return (calificaciones.Sum() / calificaciones.Count) * 0.2;
    }
}

public class CalificacionMateria : ICalificacionStrategy
{
    private List<CalificacionParametro> _parametros;
    private List<double> ObtenerCalificacionParametros(List<CalificacionParametro> Parametros){
        foreach(CalificacionParametro parametro in Parametros ){
            var Calificacion = parametro.GetNumValue();
        }

        return calificaciones
    }
    public double Calcular(List<double> calificaciones)
    {
        return calificaciones.Sum();
    }
}

public class CalificacionCuatrimestre : ICalificacionStrategy // Corrección aquí
{
    public double Calcular(List<double> calificaciones)
    {
        return calificaciones.Sum(); // Usar Sum() en lugar de Average()
    }
}

public class CalificacionFinal : ICalificacionStrategy
{
    public double Calcular(List<double> calificaciones)
    {
        return calificaciones.Sum();
    }
}

public class Calificacion
{
    private readonly ICalificacionStrategy _estrategia;

    public Calificacion(ICalificacionStrategy estrategia)
    {
        _estrategia = estrategia;
    }

    public double CalcularCalificacion(List<double> calificaciones)
    {
        return _estrategia.Calcular(calificaciones);
    }
}

// Ejemplo de uso CORREGIDO
public class Program
{
    public static void Main(string[] args)
    {
        // Supongamos 5 parámetros, cada uno con sus propias calificaciones
        var parametro1 = new Calificacion(new CalificacionParametro()).CalcularCalificacion(new List<double> { 8, 7 });
        var parametro2 = new Calificacion(new CalificacionParametro()).CalcularCalificacion(new List<double> { 9, 8 });
        var parametro3 = new Calificacion(new CalificacionParametro()).CalcularCalificacion(new List<double> { 7, 6 });
        var parametro4 = new Calificacion(new CalificacionParametro()).CalcularCalificacion(new List<double> { 10, 9 });
        var parametro5 = new Calificacion(new CalificacionParametro()).CalcularCalificacion(new List<double> { 8, 7 });

        // Calificación de materia (suma de los 5 parámetros ponderados)
        var calificacionMateria = new Calificacion(new CalificacionMateria()).CalcularCalificacion(
            new List<double> { parametro1, parametro2, parametro3, parametro4, parametro5 });

        // Calificación de cuatrimestre (suma de 4 materias)
        var calificacionCuatrimestre = new Calificacion(new CalificacionCuatrimestre()).CalcularCalificacion(
            new List<double> { 85, 90, 78, 88 }); // Ejemplo con valores de materias

        // Calificación final (suma de todos los módulos/cuatrimestres)
        var calificacionFinal = new Calificacion(new CalificacionFinal()).CalcularCalificacion(
            new List<double> { 340, 360, 380 }); // Ejemplo con módulos

        Console.WriteLine($"Calificación de materia: {calificacionMateria}");
        Console.WriteLine($"Calificación de cuatrimestre: {calificacionCuatrimestre}");
        Console.WriteLine($"Calificación final: {calificacionFinal}");
    }
}

