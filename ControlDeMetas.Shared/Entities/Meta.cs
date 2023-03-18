namespace ControlDeMetas.Shared.Entities
{
    public class Meta: BaseEntity
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int TotalTareas { get; set; }
        public decimal Cumplimiento { get; set; }

        public ICollection<Tarea> Tareas { get; set; } // Propiedad de navegación
    }
}
