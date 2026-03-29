using infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transaction.Commands
{
    public record DeleteTransactionCommand : IRequest<int>
    {
        public int Id { get; set; } 
    }

    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, int>
    {
        private readonly ITransactionServcie _transactionService;
        public DeleteTransactionCommandHandler(ITransactionServcie transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<int> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _transactionService.DeleteTransactionAsync(request.Id);
        }
    }
}
