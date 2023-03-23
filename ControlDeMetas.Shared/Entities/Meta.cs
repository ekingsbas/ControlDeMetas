using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeMetas.Shared.Entities
{
    public class Meta: BaseEntity
    {
        public string Nombre { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaCreacion { get; set; }
        public int TareasCompletadas { get; set; }
        public int TotalTareas { get; set; }
        
        public decimal Cumplimiento { get; set; }

        public ICollection<Tarea>? Tareas { get; set; } // Propiedad de navegación
    }
}
