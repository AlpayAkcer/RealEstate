using Dapper;
using RealEstate_API.Dtos.Category;
using RealEstate_API.Models.DapperContext;

namespace RealEstate_API.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "Insert into Category (Name, Status) values (@Name,@Status)";
            var parmeters = new DynamicParameters();
            parmeters.Add("@Name", categoryDto.Name);
            parmeters.Add("@Status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parmeters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete from Category Where CategoryID = @categoryID";
            var parmeters = new DynamicParameters();
            parmeters.Add("@categoryID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parmeters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * from Category";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryAsync<ResultCategoryDto>(query);
                return value.ToList();
            }
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set Name=@name, Status=@status where CategoryID=@categoryID";
            var parmeters = new DynamicParameters();
            parmeters.Add("@categoryID", categoryDto.CategoryID);
            parmeters.Add("@name", categoryDto.Name);
            parmeters.Add("@status", categoryDto.Status);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parmeters);
            }
        }
    }
}
