namespace escuela.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id { get; private set; }
        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            Id = System.Guid.NewGuid().ToString();
        }
    }
}