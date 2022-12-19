using MiEjemploDDD.Domain.Common;

namespace MiEjemploDDD.Domain
{
    public class VehiculoTipo : BaseDomainModel
    {

        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;


    }
}
