using System;
using System.Collections.Generic;
using System.Linq;
using escuela.Entidades;

namespace escuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _Diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> Diccionario)
        {
            if (Diccionario == null)
                throw new ArgumentNullException();

            _Diccionario = Diccionario;
        }

        public IEnumerable<Evaluacion> ObtenerEvaluaciones()
        {
            if (_Diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> ListaEvaluacion))
            {
                return ListaEvaluacion.Cast<Evaluacion>();
            }
            else
            {
                return new List<Evaluacion>();
            }
        }

        public IEnumerable<string> ObtenerAsignaturas(out IEnumerable<Evaluacion> LEvaluaciones)
        {
            LEvaluaciones = ObtenerEvaluaciones();

            return (from ev in LEvaluaciones
                    select ev.Asignatura.Nombre
                    ).Distinct();
        }

        public IEnumerable<string> ObtenerAsignaturas()
        {
            return ObtenerAsignaturas(out var dummy);
        }

        public Dictionary<string, IEnumerable<Evaluacion>> DicEvaluacionesPorAsignatura()
        {
            var Diccionario = new Dictionary<string, IEnumerable<Evaluacion>>();
            var Asignaturas = ObtenerAsignaturas(out var ListaEvaluacion);

            foreach (var asignaturas in Asignaturas)
            {
                var EvaluacionesPorAsignatura = from eval in ListaEvaluacion
                                                where eval.Asignatura.Nombre == asignaturas
                                                select eval;
                Diccionario.Add(asignaturas, EvaluacionesPorAsignatura);
            }

            return Diccionario;
        }

        public Dictionary<string, IEnumerable<Object>> ObtenerPromedio()
        {
            var Promedio = new Dictionary<string, IEnumerable<Object>>();
            var EvaluacionesPorAsignatura = DicEvaluacionesPorAsignatura();

            foreach (var evaluaciones in EvaluacionesPorAsignatura)
            {
                var promedioalumno = from eval in evaluaciones.Value
                            group eval by new{
                                eval.Alumno.Id,
                                eval.Alumno.Nombre
                            } 
                            into GrupoAlumnos
                            select new PromedioAlumno
                            {
                                AlumnoId = GrupoAlumnos.Key.Id,
                                AlumnoNombre = GrupoAlumnos.Key.Nombre,
                                Promedio = GrupoAlumnos.Average(evaluacion => evaluacion.Nota)
                            };
                Promedio.Add(evaluaciones.Key, promedioalumno);
            }

            return Promedio;
        }
    }

}