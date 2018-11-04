using System;
using System.Collections.Generic;

namespace escuela.Entidades
{
    public class Asignatura
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public List<Asignatura> Asignaturas { get; set; }

        public Asignatura()
        {
            Id = System.Guid.NewGuid().ToString();
        }
    }
}