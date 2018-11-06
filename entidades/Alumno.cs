using System.Collections.Generic;

namespace escuela.Entidades
{
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluacion> Evaluaciones { get; set; }= new List<Evaluacion>();
    }
}