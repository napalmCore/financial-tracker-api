using Application.Dtos;
using AutoMapper;
using infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transaction.Commands
{
    public class CreateTransactionCommand : IRequest<TransactionDto>
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? CategoryId { get; set; }
        public int typeId { get; set; }
    }

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionDto>
    {
        private readonly ITransactionServcie _transactionService;
        private readonly IMapper _mapper;
        public CreateTransactionCommandHandler(ITransactionServcie transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }
        public async Task<TransactionDto> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            var transaction = await _transactionService.CreateTransactionAsync(command);
            return _mapper.Map<TransactionDto>(transaction);

        }
    }
}
