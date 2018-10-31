using System;

namespace escuela
{
    class Escuela
    {
        public string nombre;
        public string direccion;
        public int anioFundacion;

        public void Timbre()
        {
            Console.Beep(2000, 3000);
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var EscuelaObj = new Escuela();

            EscuelaObj.nombre = "Exodus Academy";
            EscuelaObj.direccion = "Angol, Concepción, Chile";
            EscuelaObj.anioFundacion = 2018;

            Console.WriteLine("Hora del recreoooo! :)");

            EscuelaObj.Timbre();
        }
    }
}
