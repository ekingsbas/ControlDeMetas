using ControlDeMetas.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeMetas.Shared.Entities
{
    public class Tarea : BaseEntity
    {

        public long IdMeta { get; set; } //Clave foranea
        public bool Importante { get; set; }
        public string Nombre { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaCreacion { get; set; } 
        public EstatusTarea  Estatus { get; set; }

        public virtual Meta? Meta { get; set; } // Propiedad de navegación
    }
}
