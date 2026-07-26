using Application.Dtos;
using Application.Exceptions;
using Application.Transaction.Commands;
using Application.Transaction.Queries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/{action=Index}/{id:int?}")]
    [Route("api/v{version:apiVersion}/[controller]/{action=Index}")]
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

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteTransactionCommand { Id = id });
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<TransactionDto>>> GetByType([FromBody] GetTransactionsByTypeQuery query)
        {
            try
            {
                var transactions = await _mediator.Send(query);
                return Ok(transactions);
            }
            catch (NotFoundException ex) { 
                return NotFound();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TransactionDto>>> GetGroupedByCategory(
            DateTime from, DateTime to, int typeId)
        {
            try
            {
                var GetGroupedVategoryQuery = new GetTransactionsGroupedByCategoryQuery()
                {
                    TypeId = typeId,
                    From = from,
                    To = to,
                };
                var transactions = await _mediator.Send(GetGroupedVategoryQuery);
                return Ok(transactions);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }
    }
}
