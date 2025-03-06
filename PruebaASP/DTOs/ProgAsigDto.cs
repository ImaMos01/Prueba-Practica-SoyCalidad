namespace PruebaASP.DTOs
{
    public class ProgAsigDto
    {
        //DTO para la tabla ProgramasAsignaturas
        public string Asignatura { get; set; }
        public string Programa { get; set; }
        public bool EsOpcional { get; set; }
        public bool TieneDocencia { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
