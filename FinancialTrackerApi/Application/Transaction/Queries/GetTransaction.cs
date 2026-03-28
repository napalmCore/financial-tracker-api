using Application.Dtos;
using AutoMapper;
using infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transaction.Queries
{
    public record GetTransactionQuery : IRequest<TransactionDto> { 
        public int Id { get; set; }
    }

    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, TransactionDto>
    {
        private readonly ITransactionServcie _transactionsService;
        private readonly IMapper _mapper;
        public GetTransactionQueryHandler(ITransactionServcie transactionServcie, IMapper mapper) {
            _transactionsService = transactionServcie;
            _mapper = mapper;
        }

        public async Task<TransactionDto> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            var transactions  = await _transactionsService.GetTransactionByIdAsync(request.Id);
            return _mapper.Map<TransactionDto>(transactions);
        }
    }
}
