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
            var Engine = new EscuelaEngine();
            Engine.Inicializar();

            Printer.WriteTitle("Datos de la escuela");
            WriteLine(Engine.Escuela);
            Printer.WriteTitle("Cursos registrados");
            ImprimirCursosEscuela(Engine.Escuela);

            Printer.WriteTitle("Eliminar clase C-3");

            Engine.Escuela.Cursos.RemoveAll((curso) => curso.Nombre == "C-3");

            ImprimirCursosEscuela(Engine.Escuela);

            Printer.WriteTitle("Tocar timbre");
            Printer.Timbre(1000, repetir:3);
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
