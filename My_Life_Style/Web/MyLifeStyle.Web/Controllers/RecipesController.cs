namespace MyLifeStyle.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Data.Recipes;
    using MyLifeStyle.Web.ViewModels.Recipes;

    public class RecipesController : BaseController
    {
        private readonly IRecipesService recipesService;
        private readonly UserManager<ApplicationUser> userManager;

        public RecipesController(IRecipesService recipesService, UserManager<ApplicationUser> userManager)
        {
            this.recipesService = recipesService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var recipes = this.recipesService
                  .GetAllRecipes<AllRecipesViewModel>();

            return this.View(recipes);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var userId = this.userManager.GetUserId(this.User);
            var recipeCreateInputModel = new RecipeCreateInputModel
            {
                PublicationUserId = userId,
            };

            return this.View(recipeCreateInputModel);
            //return this.Json(recipeCreateInputModel);
        }

        [HttpPost(Name = "Create")]
        [Authorize]
        public async Task<IActionResult> Create(RecipeCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.userManager.GetUserId(this.User);
            model.PublicationUserId = userId;

            bool isCreted = await this.recipesService.CreateRecipe(model);

            if (!isCreted)
            {
                return this.View(model);
            }

            return this.Redirect("/Recipes/All");
            //return this.Json(model);
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUserId = this.userManager.GetUserId(this.User);
            RecipeDetailsViewModel recipeViewModel = await this.recipesService.GetRecipeById(id);
            recipeViewModel.CurrentUserId = currentUserId;

            return this.View(recipeViewModel);
            // return this.Json(articleViewModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var recipeId = id;
            return this.View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var recipeId = id;
            return this.View();
        }
    }
}
