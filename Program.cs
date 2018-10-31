using System;
using escuela.entidades;

namespace escuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var EscuelaObj = new Escuela(
                nombre: "Exodus Academy", 
                direccion: "Angol, Concepción, Chile", 
                anioFundacion: 2018,
                tipoEscuela: TiposEscuelas.Universitaria
                );

            var Curso1 = new Curso()
            {
                Nombre = "A-1",
                Jornada = TiposJornadas.Diurna
            };

            var Curso2 = new Curso()
            {
                Nombre = "B-1",
                Jornada = TiposJornadas.Vespertina
            };

            var Curso3 = new Curso()
            {
                Nombre = "C-3",
                Jornada = TiposJornadas.Diurna
            };

            Console.WriteLine(EscuelaObj);
            Console.WriteLine("===================");
            Console.WriteLine($"{Curso1.Nombre} , {Curso1.Id} , {Curso1.Jornada}");
            Console.WriteLine($"{Curso2.Nombre} , {Curso2.Id} , {Curso2.Jornada}");
            Console.WriteLine($"{Curso3.Nombre} , {Curso3.Id} , {Curso3.Jornada}");
        }
    }
}
