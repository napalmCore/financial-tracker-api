using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Transaction.Commands;
using Application.Dtos;

namespace Api.Controllers
{
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDto>> Create([FromBody] CreateTransactionCommand transaction)
        {
            var createdTransaction = await _mediator.Send(transaction);

            return createdTransaction;
        }
    }
}
