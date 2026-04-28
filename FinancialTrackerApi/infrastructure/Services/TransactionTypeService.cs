using Application.Interfaces;
using infrastructure.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.Services
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly FinancialTrackerDbContext _context;

        public TransactionTypeService(FinancialTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> TransactionTypeExists(int typeId)
        {
            return await _context.TransactionTypes.FindAsync(typeId) != null;
        }
    }
}
