namespace MyLifeStyle.Services.Data.Articles
{
    using System.Collections.Generic;

    public interface IArticlesService
    {
        IEnumerable<TViewModel> GetAllArticlesByCategory<TViewModel>(string categoryId);
    }
}
