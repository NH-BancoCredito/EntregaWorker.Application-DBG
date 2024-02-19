using EntregaWorker.Domain.Models;

namespace EntregaWorker.Domain.Repositories
{
    public interface IEntregaRepository : IRepository
    {
        Task<bool> Registrar(Entrega entity);
    }
}
