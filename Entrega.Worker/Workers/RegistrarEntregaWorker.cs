using EntregaWorker.Application.CasosUso.RegistrarEntrega;
using EntregaWorker.Domain.Service.Events;
using MediatR;
using System.Text.Json;

namespace Entrega.Worker.Workers
{
    public class RegistrarEntregaWorker : BackgroundService
    {
        private readonly IConsumerFactory _consumerFactory;
        private readonly IMediator _mediator;

        public RegistrarEntregaWorker(IConsumerFactory consumerFactory, IMediator mediator)
        {
            _consumerFactory = consumerFactory;
            _mediator = mediator;
        }
        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumer = _consumerFactory.GetConsumer();
            consumer.Subscribe("entregas");

            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(cancellationToken);

                var request = consumeResult.Value;
                var entrega = JsonSerializer.Deserialize<RegistrarEntregaRequest>(request);
                await _mediator.Send(entrega);
            }

            consumer.Close();
            await Task.CompletedTask;
        }
    }
}
