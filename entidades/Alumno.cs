namespace escuela.Entidades
{
    public class Alumno
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public Alumno()
        {
            Id = System.Guid.NewGuid().ToString();
        }
    }
}