namespace escuela.Entidades
{
    public class Evaluaciones
    {
        public string Id { get; set; }
        public Asignatura Asignatura { get; set; }
        public string Nombre { get; set; }
        public float Nota { get; set; }
        public Alumno Alumno { get; set; }

        public Evaluaciones()
        {
            Id = System.Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}