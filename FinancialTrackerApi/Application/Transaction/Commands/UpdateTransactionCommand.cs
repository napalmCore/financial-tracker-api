using Application.Dtos;
using AutoMapper;
using infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transaction.Commands
{
    public class UpdateTransactionCommand : IRequest<TransactionDto>
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int typeId { get; set; }
    }

    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, TransactionDto>
    {
        private readonly ITransactionServcie _transactionService;
        private readonly IMapper _mapper;

        public UpdateTransactionCommandHandler(ITransactionServcie transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        public async Task<TransactionDto> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionService.UpdateTransactionAsync(request);

            return _mapper.Map<TransactionDto>(transaction);
        }
    }
}
