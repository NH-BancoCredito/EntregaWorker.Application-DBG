using EntregaWorker.Application.Common;
using MediatR;

namespace EntregaWorker.Application.CasosUso.RegistrarEntrega
{
    public class RegistrarEntregaRequest : IRequest<IResult>
    {
        public object Id { get; set; }
        public int IdVenta { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public virtual IEnumerable<EntregaDetalleRequest> Detalle { get; set; }
    }

    public class EntregaDetalleRequest
    {
        public int IdEntregaDetalle { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
