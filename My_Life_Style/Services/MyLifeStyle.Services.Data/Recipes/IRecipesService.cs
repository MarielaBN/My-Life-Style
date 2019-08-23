namespace MyLifeStyle.Services.Data.Recipes
{
    using System.Collections.Generic;

    public interface IRecipesService
    {
        IEnumerable<TViewModel> GetAllRecipes<TViewModel>();
    }
}
