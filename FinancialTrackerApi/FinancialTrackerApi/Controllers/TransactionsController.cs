using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Transaction.Commands;
using Application.Dtos;
using Application.Transaction.Queries;

namespace Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Index() {
            var transactions = await _mediator.Send(new GetTransactionsQuery());
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDto>> Create([FromBody] CreateTransactionCommand transaction)
        {
            var createdTransaction = await _mediator.Send(transaction);

            return createdTransaction;
        }
    }
}
