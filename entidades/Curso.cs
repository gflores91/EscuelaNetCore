using System.Collections.Generic;

namespace escuela.Entidades
{
    public class Curso
    {
        public string Id { get; private set; }
        public string Nombre { get; set; }
        public TiposJornadas Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }  
        public List<Alumno> Alumnos { get; set; }
        
        public Curso()
        {
            Id = System.Guid.NewGuid().ToString();
        }
    }
}