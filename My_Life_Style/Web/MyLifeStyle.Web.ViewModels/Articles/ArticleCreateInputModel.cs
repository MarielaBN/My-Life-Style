namespace MyLifeStyle.Web.ViewModels.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyLifeStyle.Services.Mapping;
    using MyLifeStyle.Web.ViewModels.Categories;

    public class ArticleCreateInputModel : IMapTo<ArticleServiceModel>
    {
        [Display(Name = "Title")]
        [StringLength(400, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Required(ErrorMessage = "Enter \"{0}\".")]
        public string PublicationTitle { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Enter \"{0}\".")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Choose Category.")]
        public string CategoryId { get; set; }

        public IEnumerable<AllCategoriesViewModel> AllCategories { get; set; }
    }
}
