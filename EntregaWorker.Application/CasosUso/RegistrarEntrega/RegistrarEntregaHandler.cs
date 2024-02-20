using AutoMapper;
using EntregaWorker.Application.Common;
using EntregaWorker.Domain.Models;
using EntregaWorker.Domain.Repositories;
using MediatR;

namespace EntregaWorker.Application.CasosUso.RegistrarEntrega
{
    public class RegistrarEntregaHandler : IRequestHandler<RegistrarEntregaRequest, IResult>
    {
        private readonly IEntregaRepository _entregaRepository;
        private readonly IMapper _mapper;

        public RegistrarEntregaHandler(IEntregaRepository entregaRepository, IMapper mapper)
        {
            _entregaRepository = entregaRepository;
            _mapper = mapper;
        }
        public async Task<IResult> Handle(RegistrarEntregaRequest request, CancellationToken cancellationToken)
        {
            IResult response = null;
            bool result = false;
            try
            {
                var entrega = _mapper.Map<Entrega>(request);
                result = await _entregaRepository.Registrar(entrega);
                if (result)
                {
                    return new SuccessResult();
                }
                else
                {
                    return new FailureResult();
                }
            }
            catch (Exception ex)
            {
                response = new FailureResult();
                return response;
            }
        }
    }
}
