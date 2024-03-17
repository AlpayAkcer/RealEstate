using RealEstate.DTO.Products;

namespace RealEstate_API.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductWithCategory();
    }
}
