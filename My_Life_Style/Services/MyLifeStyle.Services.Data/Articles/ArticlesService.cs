namespace MyLifeStyle.Services.Data.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyLifeStyle.Data;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;
    using MyLifeStyle.Web.ViewModels.Articles;

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
                .Where(x => x.CategoryId == categoryId)
                 .OrderByDescending(x => x.Publication.CreatedOn)
                 .To<TViewModel>()
                 .ToList();

            return articles;
        }

        public IEnumerable<TViewModel> GetAllArticles<TViewModel>()
        {
            var articles = this.context.Articles
                 .OrderByDescending(x => x.Publication.CreatedOn)
                 .To<TViewModel>()
                 .ToList();

            return articles;
        }

        public async Task<bool> CreateArticle(ArticleServiceModel serviceModel)
        {
            Publication publication = new Publication
            {
                CreatedOn = DateTime.UtcNow,
                Title = serviceModel.PublicationTitle,
                UserId = serviceModel.UserId,
            };

            await this.context.Publications.AddAsync(publication);

            Article article = new Article
            {
                Description = serviceModel.Description,
                CategoryId = serviceModel.CategoryId,
                PublicationId = publication.Id,
            };

            await this.context.Articles.AddAsync(article);
            int result = await this.context.SaveChangesAsync();

            if (result > 0)
            {
                Category categoryFromDB = await this.context.Categories.SingleOrDefaultAsync(a => a.Id == serviceModel.CategoryId);

                categoryFromDB.ArticlesCount++;
                this.context.Categories.Update(categoryFromDB);
                await this.context.SaveChangesAsync();
            }

            return result > 0;
        }

        public async Task<ArticleDetailsViewModel> GetArticleById(string id)
        {
            ArticleDetailsViewModel article = await this.context.Articles.To<ArticleDetailsViewModel>()
                .SingleOrDefaultAsync(a => a.Id == id);

            return article;
        }
    }
}
