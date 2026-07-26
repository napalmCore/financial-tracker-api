using Application.Dtos;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using FluentValidation;
using infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Transaction.Queries
{
    public class GetTransactionsGroupedByCategoryQuery : IRequest<List<TransactionDto>>
    {
        public int TypeId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
    public class GetTransactionsGroupedByCategoryHandler : IRequestHandler<GetTransactionsGroupedByCategoryQuery, List<TransactionDto>>
    {
        private readonly ITransactionServcie _transactionServcie;
        private readonly IMapper _mapper;
        private readonly ITransactionTypeService _transactionTypeService;
        private readonly IValidator<GetTransactionsGroupedByCategoryQuery> _validator;

        public GetTransactionsGroupedByCategoryHandler(
            ITransactionServcie transactionService, IMapper mapper, ITransactionTypeService transactionTypeService, 
            IValidator<GetTransactionsGroupedByCategoryQuery> validator)
        {
            _transactionServcie = transactionService;
            _mapper = mapper;
            _transactionTypeService = transactionTypeService;
            _validator = validator;
        }

        public async Task<List<TransactionDto>> Handle(GetTransactionsGroupedByCategoryQuery request, CancellationToken cancellationToken)
        {
            if (!await _transactionTypeService.TransactionTypeExists(request.TypeId))
            {
                throw new NotFoundException("Invalid transaction type ID");
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var list = await _transactionServcie.GetTransactionsGroupByCategory(request);

            return _mapper.Map<List<TransactionDto>>(list);
        }
    }
}
