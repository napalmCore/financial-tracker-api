using FinancialTrackerApi.db;
using FinancialTrackerApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private FinancialTrackerDbContext _context;

        public CategoriesController(FinancialTrackerDbContext context)
        {
            _context = context;
        }

        [ApiVersion("1.0")]
        [HttpGet]
        public ActionResult<List<Category>> Index()
        {
            return _context.Categories.ToList();
        }
    }
}
