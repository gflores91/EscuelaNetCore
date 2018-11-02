using System.Collections.Generic;
using escuela.entidades;

namespace escuela.app
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
            Escuela = new Escuela(
               nombre: "Exodus Academy",
               direccion: "Angol, Concepción, Chile",
               anioFundacion: 2018,
               tipoEscuela: TiposEscuelas.Universitaria
            );

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
        }
    }
}