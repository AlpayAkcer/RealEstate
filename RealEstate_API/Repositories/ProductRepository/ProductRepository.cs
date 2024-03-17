using Dapper;
using RealEstate.DTO.Category;
using RealEstate.DTO.Products;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * from Product";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryAsync<ResultProductDto>(query);
                return value.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategory()
        {
            string query = "Select ProductID, Title, Price, City, District, Name from Product inner join Category on Product.ProductCategoryID = Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return value.ToList();
            }
        }
    }
}
