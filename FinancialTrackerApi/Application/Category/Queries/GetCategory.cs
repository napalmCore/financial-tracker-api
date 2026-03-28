using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Category.Queries
{
    public record GetCategoryRequest : IRequest<CategoryDto> { 
        public int Id { get; init; }
    }

    public class GetCategoryQuery : IRequestHandler<GetCategoryRequest, CategoryDto>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public GetCategoryQuery(ICategoryService categoryService, IMapper mapper) { 
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(request.Id);
            
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
