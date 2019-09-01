namespace MyLifeStyle.Web.ViewModels.Articles
{
    using System.ComponentModel.DataAnnotations;

    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;

    public class ArticleServiceModel : IMapTo<Article>, IMapFrom<Article>
    {

        [MaxLength(400)]
        public string PublicationTitle { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
