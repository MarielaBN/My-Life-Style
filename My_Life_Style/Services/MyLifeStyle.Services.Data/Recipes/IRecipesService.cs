namespace MyLifeStyle.Services.Data.Recipes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyLifeStyle.Web.ViewModels.Recipes;

    public interface IRecipesService
    {
        Task<IEnumerable<TViewModel>> GetAllRecipes<TViewModel>();

        Task<bool> CreateRecipe(RecipeCreateInputModel recipeModel);

        Task<RecipeDetailsViewModel> GetRecipeById(string id);
    }
}
