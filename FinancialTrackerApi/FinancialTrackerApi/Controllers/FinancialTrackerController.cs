using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialTrackerController : ControllerBase
    {
        private static readonly string[] Categories =
        [
            "want", "need"
        ];

        [HttpGet(Name = "GetCategories")]
        public IEnumerable<Category> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Category
            {
                Name = Categories[Random.Shared.Next(Categories.Length)]
            })
            .ToArray();
        }
    }
}
