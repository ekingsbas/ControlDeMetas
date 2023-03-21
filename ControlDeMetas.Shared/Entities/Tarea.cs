using ControlDeMetas.Shared.Enums;

namespace ControlDeMetas.Shared.Entities
{
    public class Tarea : BaseEntity
    {

        public long IdMeta { get; set; } //Clave foranea
        public bool Importante { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; } 
        public EstatusTarea  Estatus { get; set; }

        public Meta Meta { get; set; } // Propiedad de navegación
    }
}
