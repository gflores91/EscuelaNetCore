namespace escuela.entidades
{
    public class Curso
    {
        public string Id { get; private set; }
        public string Nombre { get; set; }
        public TiposJornadas Jornada { get; set; }

        public Curso()
        {
            Id = System.Guid.NewGuid().ToString();
        }
    }
}