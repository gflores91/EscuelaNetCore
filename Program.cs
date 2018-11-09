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
        }

        private static void EjecutarEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Tocar timbre");
            Printer.Timbre(1000, repetir: 3);
        }
    }
}
