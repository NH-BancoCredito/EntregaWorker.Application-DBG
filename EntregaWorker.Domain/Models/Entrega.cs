using MongoDB.Bson;

namespace EntregaWorker.Domain.Models
{
    public class Entrega
    {
        public ObjectId Id { get; set; }
        public int IdVenta { get; set; }
        public DateTime Fecha
        {
            get
            {
                return DateTime.Now;
            }
            private set { }
        }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public virtual IEnumerable<EntregaDetalle> EntregaDetalle { get; set; }
    }
}
