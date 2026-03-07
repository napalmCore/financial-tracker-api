using Application.Category.Queries;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> IndexAsync()
        {
            var categories = await _mediator.Send(new GetCategoriesRequest());

            return categories;
        }
    }
}
