using Domaine.Entities;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryEntity>> GetAllCategoriesAsync();
    }
}