namespace MyLifeStyle.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Services.Data.Recipes;
    using MyLifeStyle.Web.ViewModels.Recipes;

    public class RecipesController : BaseController
    {
        private readonly IRecipesService recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        public IActionResult Index()
        {
            var recipes = this.recipesService
                  .GetAllRecipes<AllRecipesViewModel>();

            return this.View(recipes);
        }
    }
}
