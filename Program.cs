using System;
using escuela.entidades;
using static System.Console;

namespace escuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var EscuelaObj = new Escuela(
                nombre: "Exodus Academy", 
                direccion: "Angol, Concepción, Chile", 
                anioFundacion: 2018,
                tipoEscuela: TiposEscuelas.Universitaria
                );

            EscuelaObj.Cursos = new Curso[]{
                new Curso
                {
                    Nombre = "A-1",
                    Jornada = TiposJornadas.Diurna
                },
                new Curso
                {
                    Nombre = "B-1",
                    Jornada = TiposJornadas.Vespertina
                },
                new Curso
                {
                    Nombre = "C-3",
                    Jornada = TiposJornadas.Diurna
                }
            };

            WriteLine("===================");
            WriteLine("Datos de la Escuela");
            WriteLine("===================");
            WriteLine(EscuelaObj);
            WriteLine("===================");
            WriteLine("Cursos registrados");
            WriteLine("===================");
            ImprimirCursosEscuela(EscuelaObj);
        }

        private static void ImprimirCursosEscuela(Escuela escuelaObj)
        {
            if (escuelaObj?.Cursos != null)
            {
                foreach (var Curso in escuelaObj.Cursos)
                {
                    WriteLine($"{Curso.Nombre} , {Curso.Id} , {Curso.Jornada}");
                }
            }
        }
    }
}
