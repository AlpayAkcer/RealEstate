using RealEstate.DTO.Category;

namespace RealEstate_API.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
        void UpdateCategory(UpdateCategoryDto categoryDto);
        void DeleteCategory(int id);
        Task<GetByIDCategoryDto> GetCategory(int id);

    }
}
