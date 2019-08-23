namespace MyLifeStyle.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Services.Data.Articles;
    using MyLifeStyle.Web.ViewModels.Articles;

    public class ArticlesController : BaseController
    {
        private readonly IArticlesService articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public IActionResult Index(string categoryId)
        {
            var articles = this.articlesService
                  .GetAllArticlesByCategory<AllArticlesByCategoryViewModel>(categoryId);

            return this.View(articles);
        }
    }
}
