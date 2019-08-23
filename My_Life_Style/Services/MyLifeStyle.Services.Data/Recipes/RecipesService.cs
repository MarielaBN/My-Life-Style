namespace MyLifeStyle.Services.Data.Recipes
{
    using System.Collections.Generic;
    using System.Linq;

    using MyLifeStyle.Data;
    using MyLifeStyle.Services.Mapping;

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
    }
}
