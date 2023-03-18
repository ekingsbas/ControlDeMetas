using ControlDeMetas.Shared.Enums;

namespace ControlDeMetas.Shared.Entities
{
    public class Tarea : BaseEntity
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; } 
        public EstatusTarea  Estatus { get; set; }
    }
}
