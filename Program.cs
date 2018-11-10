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

            Printer.WriteTitle("Datos de la escuela");
            WriteLine(Engine.Escuela);
            Printer.WriteTitle("Cursos registrados");
            Engine.ImprimirCursosEscuela(Engine.Escuela);

            Printer.WriteTitle("Eliminar clase C-3");

            Engine.Escuela.Cursos.RemoveAll((curso) => curso.Nombre == "C-3");

            Engine.ImprimirCursosEscuela(Engine.Escuela);

            Printer.WriteTitle("Alumnos registrados por curso");
            Engine.ImprimirAlumnosCurso(Engine.Escuela);

            Printer.WriteTitle("Limpiando escuela");
            Engine.Escuela.LimpiarLugar();

            var Diccionario = Engine.ObtenerDiccionarioEscuela();
            Engine.ImprimirDiccionario(Diccionario, TraeEvaluaciones: true);

            var Reporteador = new Reporteador(Diccionario);

            var LEvaluaciones = Reporteador.ObtenerEvaluaciones();
            var LEvaluacionesPorAsignatura = Reporteador.DicEvaluacionesPorAsignatura();
            var LPromediosAlumnos = Reporteador.ObtenerPromedio();

            var evaluacion = new Evaluacion();

            Printer.WriteTitle("Ingresar datos por consola");
            string NombreAlumno, NotaString;
            float Nota;

            Console.WriteLine("Ingrese Nombre del alumno");
            NombreAlumno = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(NombreAlumno))
            {
                Console.WriteLine("Debe ingresar un nombre válido");
            }

            evaluacion.Alumno.Nombre = NombreAlumno;

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

                    Console.WriteLine(argex);
                }
                catch(Exception)
                {
                    Console.WriteLine("Debe ingresar una nota válida");
                }
            }



        }

        private static void EjecutarEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Tocar timbre");
            Printer.Timbre(1000, repetir: 3);
        }
    }
}
