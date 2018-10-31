namespace escuela.Entidades
{
    class Escuela
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int AnioFundacion { get; set; }

        public Escuela (string nombre, string direccion, int anioFundacion) => 
        (Nombre, Direccion, AnioFundacion) = (nombre, direccion, anioFundacion);
    }
}