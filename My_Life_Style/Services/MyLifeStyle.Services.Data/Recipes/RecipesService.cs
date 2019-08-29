namespace MyLifeStyle.Services.Data.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyLifeStyle.Data;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;
    using MyLifeStyle.Web.ViewModels.Recipes;

    public class RecipesService : IRecipesService
    {
        private readonly ApplicationDbContext context;

        public RecipesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TViewModel> GetAllRecipes<TViewModel>()
        {
            var recipes = this.context.Recipes
                 .OrderByDescending(x => x.Publication.CreatedOn)
                 .To<TViewModel>()
                 .ToList();

            return recipes;
        }

        public async Task<bool> CreateRecipe(RecipeCreateInputModel recipeModel)
        {
            Publication publication = new Publication
            {
                CreatedOn = DateTime.UtcNow,
                Title = recipeModel.PublicationTitle,
                UserId = recipeModel.PublicationUserId,
            };

            await this.context.Publications.AddAsync(publication);

            Recipe recipe = new Recipe
            {
                Ingredients=recipeModel.Ingredients,
                Description = recipeModel.Description,
                DishType = recipeModel.DishType,
                DietType = recipeModel.DietType,
                PublicationId = publication.Id,
            };

            await this.context.Recipes.AddAsync(recipe);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<RecipeDetailsViewModel> GetRecipeById(string id)
        {
            RecipeDetailsViewModel recipe = await this.context.Recipes.To<RecipeDetailsViewModel>()
                .SingleOrDefaultAsync(a => a.Id == id);

            return recipe;
        }
    }
}
