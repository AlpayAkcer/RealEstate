using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Models.DapperContext;
using RealEstate_API.Repositories.CategoryRepository;

namespace RealEstate_UI.ViewComponents.CategoryComponent
{
    public class _CategoryCount : ViewComponent
    {
        private readonly CategoryRepository _categoryRepository;
        public IViewComponentResult Invoke()
        {
            ViewBag.CategoryCount = _categoryRepository.GetAllCategoryAsync();
            return View();
        }
    }
}
