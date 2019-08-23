namespace MyLifeStyle.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Services.Data.Categories;
    using MyLifeStyle.Web.ViewModels.Categories;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var categories = this.categoriesService
                  .GetAllCategories<AllCategoriesViewModel>();

            return this.View(categories);
        }
    }
}
