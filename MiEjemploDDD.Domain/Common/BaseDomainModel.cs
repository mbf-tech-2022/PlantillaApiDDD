namespace MiEjemploDDD.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaUltimaModificacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; } = string.Empty;

    }
}

