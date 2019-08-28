namespace MyLifeStyle.Services.Data.Articles
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyLifeStyle.Web.ViewModels.Articles;

    public interface IArticlesService
    {
        IEnumerable<TViewModel> GetAllArticlesByCategory<TViewModel>(string categoryId);

        IEnumerable<TViewModel> GetAllArticles<TViewModel>();

        Task<bool> CreateArticle(ArticleServiceModel serviceModel);

        Task<ArticleDetailsViewModel> GetArticleById(string id);
    }
}
