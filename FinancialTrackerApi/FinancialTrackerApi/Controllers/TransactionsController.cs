using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Transaction.Commands;
using Application.Dtos;
using Application.Transaction.Queries;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/{action=Index}/{id:int?}")]
    [Route("api/[controller]/{action=Index}/{id:int?}")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var transactions = await _mediator.Send(new GetTransactionsQuery());
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDto>> Create([FromBody] CreateTransactionCommand transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdTransaction = await _mediator.Send(transaction);

            return createdTransaction;
        }

        [HttpGet]
        public async Task<ActionResult<TransactionDto>> GetById(int id)
        {
            var transaction = await _mediator.Send(new GetTransactionQuery { Id = id });
            if (transaction == null)
            {
                return NotFound();
            }
            return transaction;

        }

        [HttpPatch]
        public async Task<ActionResult<TransactionDto>> Update(int id, [FromBody] UpdateTransactionCommand transaction)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            if (id != transaction.Id)
            {
                return BadRequest("Id in URL does not match Id in body");
            }
            var updatedTransaction = await _mediator.Send(transaction);
            if (updatedTransaction == null)
            {
                return NotFound();
            }
            return updatedTransaction;
        }
    }
}
