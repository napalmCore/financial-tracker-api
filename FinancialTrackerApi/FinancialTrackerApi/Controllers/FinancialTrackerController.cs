using FinancialTrackerApi.db;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialTrackerController : ControllerBase
    {
        private FinancialTrackerDbContext _context;

        public FinancialTrackerController(FinancialTrackerDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetCategories")]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToArray();
        }
    }
}
