using Application.Dtos;
using Domaine.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Category.Queries
{
    public record GetCategoriesRequest : IRequest<List<CategoryDto>>;

    public class GetCategoriesQuery : IRequestHandler<GetCategoriesRequest, List<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        public GetCategoriesQuery(ICategoryService categoryService) { 
            _categoryService = categoryService;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var categoryDtos = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return categoryDtos;
        }
    }
}
