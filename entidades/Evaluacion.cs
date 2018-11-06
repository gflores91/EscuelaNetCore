namespace escuela.Entidades
{
    public class Evaluacion: ObjetoEscuelaBase
    {
        public Asignatura Asignatura { get; set; }
        public float Nota { get; set; }
        public Alumno Alumno { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Alumno.Nombre}, {Asignatura.Nombre}";
        }
    }
}