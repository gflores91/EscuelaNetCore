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
            var ObjEscuela = Engine.ObtenerObjEscuela();

            Printer.WriteTitle("Datos de la escuela");
            WriteLine((object)Engine.Escuela);
            Printer.WriteTitle("Cursos registrados");
            Printer.ImprimirCursosEscuela(Engine.Escuela);

            Printer.WriteTitle("Eliminar clase C-3");

            Engine.Escuela.Cursos.RemoveAll((curso) => curso.Nombre == "C-3");

            Printer.ImprimirCursosEscuela(Engine.Escuela);

            Printer.WriteTitle("Alumnos registrados por curso");
            Printer.ImprimirAlumnosCurso(Engine.Escuela);

            Printer.WriteTitle("Tocar timbre");
            Printer.Timbre(1000, repetir:3);

            Printer.WriteTitle("Limpiando escuela");
            Engine.Escuela.LimpiarLugar();
        }
    }
}
