namespace MyLifeStyle.Services.Data.Articles
{
    using System.Collections.Generic;
    using System.Linq;

    using MyLifeStyle.Data;
    using MyLifeStyle.Services.Mapping;

    public class ArticlesService : IArticlesService
    {
        private readonly ApplicationDbContext context;

        public ArticlesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TViewModel> GetAllArticlesByCategory<TViewModel>(string categoryId)
        {
            var articles = this.context.Articles
                 .OrderByDescending(x => x.Publication.CreatedOn)
                 .To<TViewModel>()
                 .ToList();

            return articles;
        }
    }
}
