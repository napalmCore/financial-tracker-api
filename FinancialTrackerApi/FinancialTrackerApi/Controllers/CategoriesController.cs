using Application.Category.Queries;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/{action=Index}")]
    [Route("api/[controller]/{action=Index}")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CategoriesController : ControllerBase
    {
        private IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet, MapToApiVersion("1.0")]
        public async Task<ActionResult<List<CategoryDto>>> IndexAsync()
        {
            var categories = await _mediator.Send(new GetCategoriesRequest(null));

            return categories;
        }

        [HttpGet, MapToApiVersion("2.0")]
        public async Task<ActionResult<List<CategoryDto>>> IndexAsync(int? transactionTypeId)
        {
            var categories = await _mediator.Send(new GetCategoriesRequest(transactionTypeId));

            return categories;
        }

        [ApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetByIdAsync(int id)
        {
            var category = await _mediator.Send(new GetCategoryRequest { Id = id });
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }
    }
}
