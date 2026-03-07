using Domaine.Entities;
using Application.Transaction.Commands;

namespace infrastructure.Services
{
    public interface ITransactionServcie
    {
        Task<TransactionEntity> CreateTransactionAsync(CreateTransactionCommand transaction);

    }
}