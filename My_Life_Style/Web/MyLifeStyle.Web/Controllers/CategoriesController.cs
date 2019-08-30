namespace MyLifeStyle.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Services.Data.Categories;
    using MyLifeStyle.Web.ViewModels.Categories;
    using System.Threading.Tasks;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> All()
        {
            var categories = await this.categoriesService
                  .GetAllCategories<AllCategoriesViewModel>();

            return this.View(categories);
        }
    }
}
