using Application.Transaction.Commands;
using Domaine.Entities;
using infrastructure.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.Services
{
    public class TransactionService : ITransactionServcie
    {
        private readonly FinancialTrackerDbContext _context;

        public TransactionService(FinancialTrackerDbContext context) {
            _context = context;
        }

        public async Task<TransactionEntity> CreateTransactionAsync(CreateTransactionCommand transaction)
        {
            var transactionEntity = new TransactionEntity
            {
                Amount = transaction.Amount,
                Description = transaction.Description,
                Date = transaction.Date,
                CategoryId = transaction.CategoryId,
                TransactionTypeId = transaction.typeId
            };

            await _context.AddAsync(transactionEntity);
            await _context.SaveChangesAsync();

            return transactionEntity;

        }
    }
}
