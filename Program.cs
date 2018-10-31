using System;
using escuela.Entidades;

namespace escuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var EscuelaObj = new Escuela(
                nombre: "Exodus Academy", 
                direccion: "Angol, Concepción, Chile", 
                anioFundacion: 2018
                );

            Console.WriteLine(EscuelaObj.Nombre);
        }
    }
}
