using System.Collections.Generic;

namespace escuela.Entidades
{
    public class Escuela
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int AnioFundacion { get; set; }
        public TiposEscuelas TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        public Escuela (string nombre, string direccion, int anioFundacion, TiposEscuelas tipoEscuela) => 
        (Nombre, Direccion, AnioFundacion, TipoEscuela) = (nombre, direccion, anioFundacion, tipoEscuela);

        public override string ToString()
        {
            return $"Nombre: {Nombre} \nDirección: {Direccion} \nAño Fundación: {AnioFundacion} \nTipo de escuela: {TipoEscuela}";
        }
    }
}