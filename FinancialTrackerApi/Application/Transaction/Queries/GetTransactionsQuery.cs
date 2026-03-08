using Application.Dtos;
using AutoMapper;
using infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transaction.Queries
{
    public record GetTransactionsQuery : IRequest<List<TransactionDto>>;

    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, List<TransactionDto>>
    {
        private readonly ITransactionServcie _transactionsService;
        private readonly IMapper _mapper;
        public GetTransactionsQueryHandler(ITransactionServcie transactionServcie, IMapper mapper) {
            _transactionsService = transactionServcie;
            _mapper = mapper;
        }

        public async Task<List<TransactionDto>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions  = await _transactionsService.GetTransactions();
            return _mapper.Map<List<TransactionDto>>(transactions);
        }
    }
}
