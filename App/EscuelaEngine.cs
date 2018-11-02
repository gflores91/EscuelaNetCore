using System;
using System.Collections.Generic;
using System.Linq;
using escuela.Entidades;

namespace escuela.App
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            //this.Escuelas = escuelas;

        }

        public void Inicializar()
        {
            CargarEscuela();
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        private void CargarEscuela()
        {
            Escuela = new Escuela(
               nombre: "Exodus Academy",
               direccion: "Angol, Concepción, Chile",
               anioFundacion: 2018,
               tipoEscuela: TiposEscuelas.Universitaria
            );
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
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

            Random rnd = new Random();

            foreach (var curso in Escuela.Cursos)
            {
                int cantidad = rnd.Next(5,40);
                curso.Alumnos = GenerarAlumnos(cantidad);   
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var ListaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre = "Matematicas"},
                    new Asignatura{Nombre = "Lenguaje"},
                    new Asignatura{Nombre = "Ciencias Naturales"},
                    new Asignatura{Nombre = "Manualidades"},
                    new Asignatura{Nombre = "Tecnología"}
                };
                curso.Asignaturas = ListaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnos(int cantidad)
        {
            string[] nombre1 = {"María","Gabriel","Alexis","Pablo","René"};
            string[] nombre2 = {"Alicia","Flores","Torres","Alarcón","Tapia"};
            string[] apellido = {"Cid","Monsalve","Torres","Sepulveda","Quezada"};

            var ListaAlumnos =  from n1 in nombre1
                                from n2 in nombre2
                                from ap in apellido
                                select new Alumno{Nombre = $"{n1} {n2} {ap}"};

            return ListaAlumnos.OrderBy( (al) => al.Id ).Take(cantidad).ToList();
        }

        private void CargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

    }
}