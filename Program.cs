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
            try
            {
                AppDomain.CurrentDomain.ProcessExit += EjecutarEvento;

                var Engine = new EscuelaEngine();
                Engine.Inicializar();

                var Reporteador = new Reporteador(Engine.ObtenerDiccionarioEscuela());

                int opcion = 0;

                if (opcion < 0 || opcion > 9)
                {
                    throw new ArgumentOutOfRangeException("Opción fuera de rango (0-9)");
                }

                do
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
                    Console.WriteLine("0. Salir del programa");

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
                            Engine.ImprimirEvaluacionesxAsignaturas(Reporteador);
                            Printer.LimpiarConsola();
                            break;
                        case 6:
                            Engine.ImprimirPromAlxAsig(Reporteador);
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
                            Console.WriteLine("Saliendo");
                            break;
                    }
                } while (opcion != 0) ;
            }
            catch (ArgumentOutOfRangeException argex)
            {
                Console.WriteLine(argex.ParamName);
            }
            catch (Exception)
            {
                Console.WriteLine("Debe ingresar una opción válida");

            }
            finally
            {
                Printer.LimpiarConsola();
            }
        }

        private static void EjecutarEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo del programa");
            Printer.Timbre(1000, repetir: 3);
        }
    }
}
