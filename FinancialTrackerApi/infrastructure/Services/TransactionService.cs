using Application.Exceptions;
using Application.Transaction.Commands;
using Application.Transaction.Queries;
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

        public async Task<int> DeleteTransactionAsync(int id)
        {
            return await _context.Transactions.Where(e => e.Id == id).ExecuteDeleteAsync();
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

        public async Task<TransactionEntity> UpdateTransactionAsync(UpdateTransactionCommand transactionCommand)
        {
            var updated  = await _context.Transactions.Where(e => e.Id == transactionCommand.Id)
                .ExecuteUpdateAsync(
                s => s.SetProperty(e => e.Amount, transactionCommand.Amount)
                .SetProperty(e => e.Description, transactionCommand.Description)
                .SetProperty(e => e.CategoryId, transactionCommand.CategoryId)
                .SetProperty(e => e.TransactionTypeId, transactionCommand.typeId)
            );

            var transaction = await _context.Transactions
                .Include(e => e.Category)
                .Where(e => e.Id == transactionCommand.Id).FirstOrDefaultAsync();

            if (transaction == null)
            {
                throw new NotFoundException("Transaction not found");
            }

            return transaction;
        }

        public async Task<List<TransactionEntity>> GetTransactionsByTypeId(GetTransactionsByTypeQuery request) {
            return await _context.Transactions
                .Include(e => e.Category).Where(
                e => e.TransactionTypeId == request.TypeId
                && e.Date >= request.From && e.Date <= request.To
                ).ToListAsync();
        }
    }
}
