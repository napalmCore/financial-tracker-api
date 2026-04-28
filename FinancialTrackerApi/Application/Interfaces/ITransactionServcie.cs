using Application.Transaction.Commands;
using Application.Transaction.Queries;
using Domaine.Entities;

namespace infrastructure.Services
{
    public interface ITransactionServcie
    {
        Task<TransactionEntity> CreateTransactionAsync(CreateTransactionCommand transaction);

        Task<TransactionEntity> GetTransactionByIdAsync(int id);
        Task<List<TransactionEntity>> GetTransactions();
        Task<TransactionEntity> UpdateTransactionAsync(UpdateTransactionCommand transactionCommand);
        Task<int> DeleteTransactionAsync(int id);
        Task<List<TransactionEntity>> GetTransactionsByTypeId(GetTransactionsByTypeQuery request);
    }
}