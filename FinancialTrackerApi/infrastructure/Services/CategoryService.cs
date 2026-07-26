using Application.Category.Queries;
using Application.Interfaces;
using Domaine.Entities;
using infrastructure.db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domaine.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FinancialTrackerDbContext _context;
        public CategoryService(FinancialTrackerDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<CategoryEntity>> GetAllCategoriesAsync(GetCategoriesRequest request)
        {
            if (request.transactionTypeId.HasValue)
            {
                return await _context.Categories
                    .Where(c => c.TransactionTypeId == request.transactionTypeId.Value)
                    .ToListAsync();
            }

            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryEntity> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}
