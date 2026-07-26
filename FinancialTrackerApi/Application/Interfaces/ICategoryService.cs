using Application.Category.Queries;
using Domaine.Entities;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryEntity>> GetAllCategoriesAsync(GetCategoriesRequest request);
        Task<CategoryEntity> GetCategoryByIdAsync(int id);
    }
}