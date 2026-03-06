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

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
