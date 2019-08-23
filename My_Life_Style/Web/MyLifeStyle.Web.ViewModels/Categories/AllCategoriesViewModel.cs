namespace MyLifeStyle.Web.ViewModels.Categories
{
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;

    public class AllCategoriesViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public int ArticlesCount { get; set; }
    }
}
