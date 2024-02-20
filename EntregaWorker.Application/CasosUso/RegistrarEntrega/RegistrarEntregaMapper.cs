using AutoMapper;
using EntregaWorker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregaWorker.Application.CasosUso.RegistrarEntrega
{
    public class RegistrarEntregaMapper : Profile
    {
        public RegistrarEntregaMapper()
        {
            CreateMap<RegistrarEntregaRequest, Entrega>()
                .ForMember(dest => dest.EntregaDetalle, map => map.MapFrom(src => src.Detalle));

            CreateMap<EntregaDetalleRequest, EntregaDetalle>();
        }
    }
}
