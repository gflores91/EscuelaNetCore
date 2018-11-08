using System;
using System.Collections.Generic;
using escuela.Entidades;

namespace escuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tamlinea = 10)
        {
            Console.WriteLine("".PadLeft(tamlinea, '='));
        }

        public static void WriteTitle(string titulo)
        {
            var linea = titulo.Length + 4;
            DibujarLinea(linea);
            Console.WriteLine($"| {titulo.ToUpper()} |");
            DibujarLinea(linea);            
        }

         public static void ImprimirCursosEscuela(Entidades.Escuela escuelaObj)
        {
            if (escuelaObj?.Cursos != null)
            {
                foreach (var Curso in escuelaObj.Cursos)
                {
                    Console.WriteLine($"{Curso.Nombre} , {Curso.Id} , {Curso.Jornada}");
                }
            }
        }

        public static void ImprimirAlumnosCurso(Entidades.Escuela escuelaObj)
        {
            if (escuelaObj?.Cursos != null)
            {
                foreach (var curso in escuelaObj.Cursos)
                {
                    Console.WriteLine($"\n{curso.Nombre} \n");
                    foreach (var alumno in curso.Alumnos)
                    {
                        Console.WriteLine($"{alumno.Nombre}");   
                    }
                }
            }
        }

        public static void Timbre(int hz = 2000, int tiempo = 500, int repetir = 1)
        {
            while (repetir-- > 0)
            {
                Console.Beep(hz, tiempo);
            }
            
        }

        public static void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> Diccionario, bool TraeEvaluaciones = false)
        {
            foreach (var diccionario in Diccionario)
            {
                WriteTitle(diccionario.Key.ToString());

                foreach (var valor in diccionario.Value)
                {
                    if(valor is Escuela)
                        Console.WriteLine(valor);
                    else if(valor is Curso)
                        Console.WriteLine(valor.Nombre);
                    else if(valor is Alumno)
                        Console.WriteLine(valor.Nombre);
                    else if(valor is Evaluacion)
                    {
                        if(TraeEvaluaciones)
                            Console.WriteLine(valor);
                    }
                    else
                        Console.WriteLine(valor.Nombre);
                }
            }
        }
    }
}