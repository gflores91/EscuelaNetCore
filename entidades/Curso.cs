using System;
using System.Collections.Generic;
using escuela.Util;

namespace escuela.Entidades
{
    public class Curso: ObjetoEscuelaBase, ILugar
    {
        public TiposJornadas Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }  
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get; set; }

        public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine($"Limpiando curso {Nombre} ...");
            Console.WriteLine($"Curso {Nombre} limpio");
        }
    }
}