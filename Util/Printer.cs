using System;
using escuela.Entidades;

namespace escuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tamlinea = 10)
        {
            Console.WriteLine("".PadLeft(tamlinea, '='));
        }

        public static void WriteTitle(string titulo)
        {
            var linea = titulo.Length + 4;
            DibujarLinea(linea);
            Console.WriteLine($"| {titulo.ToUpper()} |");
            DibujarLinea(linea);
        }

        public static void Timbre(int hz = 2000, int tiempo = 500, int repetir = 1)
        {
            while (repetir-- > 0)
            {
                //Console.Beep(hz, tiempo);
                Console.Beep(hz, tiempo);
            }

        }
    }
}