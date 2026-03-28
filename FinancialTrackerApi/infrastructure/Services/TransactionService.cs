using Application.Transaction.Commands;
using Domaine.Entities;
using infrastructure.db;
using Microsoft.EntityFrameworkCore;
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

        public async Task<TransactionEntity> GetTransactionByIdAsync(int id)
        {
            var transaction = await _context.Transactions
                .Include(e => e.Category)
                .Where(e => e.Id == id).FirstOrDefaultAsync();

            if(transaction == null) {
                throw new Exception("Transaction not found");
            }

            return transaction;
        }

        public Task<TransactionEntity> GetTransactionByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TransactionEntity>> GetTransactions()
        {
            return await _context.Transactions.Include(e => e.Category).ToListAsync();
        }
    }
}
