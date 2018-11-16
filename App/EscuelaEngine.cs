using System;
using System.Collections.Generic;
using System.Linq;
using escuela.Entidades;
using escuela.Util;

namespace escuela.App
{
    public sealed class EscuelaEngine
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

        #region Métodos para cargar información
        private void CargarEscuela()
        {
            Escuela = new Entidades.Escuela(
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
                int cantidad = rnd.Next(5, 40);
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

        private void CargarEvaluaciones()
        {
            var rnd = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            var evaluacion = new Evaluacion()
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Evaluacion#{i + 1}",
                                Nota = MathF.Round(7 * (float)rnd.NextDouble(), 2),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(evaluacion);
                        }
                    }
                }
            }
        }
        #endregion

        #region Métodos para generar información
        private List<Alumno> GenerarAlumnos(int cantidad)
        {
            string[] nombre1 = { "María", "Gabriel", "Alexis", "Pablo", "René" };
            string[] nombre2 = { "Alicia", "Flores", "Torres", "Alarcón", "Tapia" };
            string[] apellido = { "Cid", "Monsalve", "Torres", "Sepulveda", "Quezada" };

            var ListaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from ap in apellido
                               select new Alumno { Nombre = $"{n1} {n2} {ap}" };

            return ListaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }
        #endregion

        #region Métodos para obtener información
        int dummy = 0;
        public IReadOnlyList<ObjetoEscuelaBase> ObtenerObjEscuela(
            bool Cursos = true,
            bool Asignaturas = true,
            bool Alumnos = true,
            bool Evaluaciones = true
        )
        {
            return ObtenerObjEscuela(out dummy, out dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> ObtenerObjEscuela(
            out int CuentaCursos,
            bool Cursos = true,
            bool Asignaturas = true,
            bool Alumnos = true,
            bool Evaluaciones = true

        )
        {
            return ObtenerObjEscuela(out CuentaCursos, out dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> ObtenerObjEscuela(
            out int CuentaCursos,
            out int CuentaAsignaturas,
            bool Cursos = true,
            bool Asignaturas = true,
            bool Alumnos = true,
            bool Evaluaciones = true

        )
        {
            return ObtenerObjEscuela(out CuentaCursos, out CuentaAsignaturas, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> ObtenerObjEscuela(
            out int CuentaCursos,
            out int CuentaAsignaturas,
            out int CuentaAlumnos,
            bool Cursos = true,
            bool Asignaturas = true,
            bool Alumnos = true,
            bool Evaluaciones = true

        )
        {
            return ObtenerObjEscuela(out CuentaCursos, out CuentaAsignaturas, out CuentaAlumnos, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> ObtenerObjEscuela(
            out int CuentaCursos,
            out int CuentaAsignaturas,
            out int CuentaAlumnos,
            out int CuentaEvaluaciones,
            bool Cursos = true,
            bool Asignaturas = true,
            bool Alumnos = true,
            bool Evaluaciones = true

        )
        {
            CuentaCursos = CuentaAsignaturas = CuentaAlumnos = CuentaEvaluaciones = 0;

            var ObjEscuela = new List<ObjetoEscuelaBase>();

            ObjEscuela.Add(Escuela);

            if (Cursos)
                ObjEscuela.AddRange(Escuela.Cursos);

            CuentaCursos = Escuela.Cursos.Count;

            foreach (var curso in Escuela.Cursos)
            {
                CuentaAsignaturas += curso.Asignaturas.Count;
                CuentaAlumnos += curso.Alumnos.Count;
                if (Asignaturas)
                    ObjEscuela.AddRange(curso.Asignaturas);

                if (Alumnos)
                    ObjEscuela.AddRange(curso.Alumnos);

                if (Evaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        CuentaEvaluaciones += alumno.Evaluaciones.Count;
                        ObjEscuela.AddRange(alumno.Evaluaciones);
                    }
                }
            }

            return ObjEscuela.AsReadOnly();
        }

        public IEnumerable<ILugar> ObtenerObjInterface()
        {
            var ObjInterface = new List<ObjetoEscuelaBase>();

            var LObjInterfaces = from obj in ObjInterface
                                 where obj is ILugar
                                 select (ILugar)obj;

            return LObjInterfaces;
        }

        #endregion

        #region Diccionarios
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> ObtenerDiccionarioEscuela()
        {
            var Diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            Diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            Diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos);

            var LTmpAlumno = new List<Alumno>();
            var LTmpAsinatura = new List<Asignatura>();
            var LTmpEvaluacion = new List<Evaluacion>();

            foreach (var curso in Escuela.Cursos)
            {
                LTmpAlumno.AddRange(curso.Alumnos);
                LTmpAsinatura.AddRange(curso.Asignaturas);

                foreach (var alumno in curso.Alumnos)
                {
                    LTmpEvaluacion.AddRange(alumno.Evaluaciones);
                }

            }
            Diccionario.Add(LlaveDiccionario.Alumno, LTmpAlumno);
            Diccionario.Add(LlaveDiccionario.Asignatura, LTmpAsinatura);
            Diccionario.Add(LlaveDiccionario.Evaluacion, LTmpEvaluacion);

            return Diccionario;
        }
        #endregion

        #region Métodos para imprimir infomación
        public void ImprimirEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Datos de la escuela");
            Console.WriteLine(escuela);
        }
        public void ImprimirCursosEscuela(Escuela escuelaObj)
        {
            Printer.WriteTitle("Cursos registrados");
            if (escuelaObj?.Cursos != null)
            {
                foreach (var Curso in escuelaObj.Cursos)
                {
                    Console.WriteLine($"{Curso.Nombre} , {Curso.Id} , {Curso.Jornada}");
                }
            }
        }

        public void ImprimirAlumnosCurso(Escuela escuelaObj)
        {
            Printer.WriteTitle("Alumnos registrados por curso");
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

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> Diccionario, bool TraeEvaluaciones = false)
        {
            foreach (var diccionario in Diccionario)
            {
                Printer.WriteTitle(diccionario.Key.ToString());

                foreach (var valor in diccionario.Value)
                {
                    switch (diccionario.Key)
                    {
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine(valor);
                            break;

                        case LlaveDiccionario.Curso:
                            var TmpCurso = valor as Curso;

                            if (TmpCurso != null)
                            {
                                var CAlumnos = TmpCurso.Alumnos.Count();
                                Console.WriteLine($"Curso: {valor.Nombre}, Cantidad de alumnos: {CAlumnos}");
                            }

                            break;

                        case LlaveDiccionario.Alumno:
                            Console.WriteLine(valor.Nombre);
                            break;

                        case LlaveDiccionario.Evaluacion:
                            if (TraeEvaluaciones)
                                Console.WriteLine(valor);
                            break;

                        default:
                            Console.WriteLine(valor.Nombre);
                            break;
                    }
                }
            }
        }

        public void ImprimirEvaluacionesxAsignaturas(Reporteador reporteador)
        {
            var LEvaluacionesPorAsignatura = reporteador.DicEvaluacionesPorAsignatura();

            foreach (var evalxasigkey in LEvaluacionesPorAsignatura)
            {
                Printer.WriteTitle($"{evalxasigkey.Key}");
                foreach (var evalxasigvalue in evalxasigkey.Value)
                {
                    Console.WriteLine(evalxasigvalue);
                }
            }
        }

        public void ImprimirPromAlxAsig(Reporteador reporteador)
        {
            var LPromediosAlumnos = reporteador.ObtenerPromedio();

            foreach (var promxalkey in LPromediosAlumnos)
            {
                Printer.WriteTitle($"{promxalkey.Key}");
                foreach (var promxalvalue in promxalkey.Value)
                {
                    Console.WriteLine($"\nNombre: {promxalvalue.AlumnoNombre}\nPromedio: {promxalvalue.Promedio}");
                }
            }
        }
        #endregion
    }
}