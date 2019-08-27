namespace MyLifeStyle.Services.Data.Articles
{
    using MyLifeStyle.Web.ViewModels.Articles;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticlesService
    {
        IEnumerable<TViewModel> GetAllArticlesByCategory<TViewModel>(string categoryId);

        IEnumerable<TViewModel> GetAllArticles<TViewModel>();

        Task<bool> CreateArticle(ArticleServiceModel serviceModel);
    }
}
