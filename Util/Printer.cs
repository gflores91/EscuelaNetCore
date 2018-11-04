using System;
using escuela.Entidades;

namespace escuela.Util
{
    public static class Printer
    {
        static void DibujarLinea(int tamlinea = 10)
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

         public static void ImprimirCursosEscuela(Escuela escuelaObj)
        {
            if (escuelaObj?.Cursos != null)
            {
                foreach (var Curso in escuelaObj.Cursos)
                {
                    Console.WriteLine($"{Curso.Nombre} , {Curso.Id} , {Curso.Jornada}");
                }
            }
        }

        public static void ImprimirAlumnosCurso(Escuela escuelaObj)
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
    }
}