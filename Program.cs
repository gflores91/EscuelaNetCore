using System;
using System.Collections.Generic;
using escuela.App;
using escuela.Entidades;
using escuela.Util;
using static System.Console;

namespace escuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += EjecutarEvento;

            var Engine = new EscuelaEngine();
            Engine.Inicializar();

            var Reporteador = new Reporteador(Engine.ObtenerDiccionarioEscuela());

            int opcion = 0;

            while (opcion != 9)
            {
                Printer.WriteTitle("Bienvenido a Escuela Consola .Net Core");
                Console.WriteLine("\nLista de opciones disponibles:\n");

                Console.WriteLine("1. Imprimir datos de la escuela");
                Console.WriteLine("2. Imprimir los cursos registrado");
                Console.WriteLine("3. Imprimir los alumnos registrados por curso");
                Console.WriteLine("4. Imprimir diccionario de datos");
                Console.WriteLine("5. Imprimir evaluaciones por asignatura");
                Console.WriteLine("6. Imprimir promedios de alumnos por asignatura");
                Console.WriteLine("7. Ingresar alumno por consola (en construcción)");
                Console.WriteLine("9. Salir del programa");

                Console.WriteLine("\nFavor ingrese la opción que desea visualizar: \n");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Engine.ImprimirEscuela(Engine.Escuela);
                        Printer.LimpiarConsola();
                        break;
                    case 2:
                        Engine.ImprimirCursosEscuela(Engine.Escuela);
                        Printer.LimpiarConsola();
                        break;
                    case 3:
                        Engine.ImprimirAlumnosCurso(Engine.Escuela);
                        Printer.LimpiarConsola();
                        break;
                    case 4:
                        Engine.ImprimirDiccionario(Engine.ObtenerDiccionarioEscuela(), TraeEvaluaciones: false);
                        Printer.LimpiarConsola();
                        break;
                    case 5:
                        var LEvaluacionesPorAsignatura = Reporteador.DicEvaluacionesPorAsignatura();

                        foreach (var evalxasigkey in LEvaluacionesPorAsignatura)
                        {
                            Printer.WriteTitle($"{evalxasigkey.Key}");
                            foreach (var evalxasigvalue in evalxasigkey.Value)
                            {
                                Console.WriteLine(evalxasigvalue);
                            }
                        }
                        Printer.LimpiarConsola();
                        break;
                    case 6:
                        var LPromediosAlumnos = Reporteador.ObtenerPromedio();

                        foreach (var promxalkey in LPromediosAlumnos)
                        {
                            Printer.WriteTitle($"{promxalkey.Key}");
                            foreach (var promxalvalue in promxalkey.Value)
                            {
                                Console.WriteLine($"\nNombre: {promxalvalue.AlumnoNombre}\nPromedio: {promxalvalue.Promedio}");
                            }
                        }
                        Printer.LimpiarConsola();
                        break;
                    case 7:
                        Printer.WriteTitle("Ingresar datos por consola");
                        string NombreAlumno, NotaString;
                        float Nota;
                        Console.WriteLine("Ingrese Nombre del alumno");
                        NombreAlumno = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(NombreAlumno))
                        {
                            Console.WriteLine("Debe ingresar un nombre válido");
                        }
                        Console.WriteLine("Ingrese nota del alumno");
                        NotaString = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(NotaString))
                        {
                            Console.WriteLine("Debe ingresar una nota válida");
                        }
                        else
                        {
                            try
                            {
                                Nota = float.Parse(NotaString);
                                if (Nota < 0 || Nota > 7)
                                {
                                    throw new ArgumentOutOfRangeException("EL rango de la nota debe ser mayor a 0 y menor a 7");
                                }
                            }
                            catch (ArgumentOutOfRangeException argex)
                            {
                                Console.WriteLine(argex.ParamName);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Debe ingresar una nota válida");
                            }
                            finally
                            {
                                Printer.LimpiarConsola();
                            }
                        }
                        break;

                    default:
                        opcion = 9;
                        break;
                }
            }
        }

        private static void EjecutarEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo del programa");
            Printer.Timbre(1000, repetir: 3);
        }
    }
}
