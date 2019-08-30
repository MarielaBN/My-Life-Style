namespace MyLifeStyle.Services.Data.Categories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyLifeStyle.Data;
    using MyLifeStyle.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext context;

        public CategoriesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TViewModel>> GetAllCategories<TViewModel>()
        {
            var categories = await this.context.Categories
                  .OrderByDescending(x => x.ArticlesCount)
                  .To<TViewModel>()
                  .ToListAsync();

            return categories;
        }
    }
}
