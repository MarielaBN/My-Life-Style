namespace MyLifeStyle.Web.ViewModels.Recipes
{
    using System.ComponentModel.DataAnnotations;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Data.Models.Enums;
    using MyLifeStyle.Services.Mapping;

    public class RecipeCreateInputModel : IMapTo<Recipe>
    {
        [Display(Name = "Title")]
        [StringLength(400, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Required(ErrorMessage = "Enter \"{0}\".")]
        public string PublicationTitle { get; set; }

        [Display(Name = "Ingredients")]
        [MaxLength(1000, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string Ingredients { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Enter \"{0}\".")]
        public string Description { get; set; }

        [Display(Name = "Dish Type")]
        [Required(ErrorMessage = "Choose \"{0}\".")]
        public DishType DishType { get; set; }

        [Display(Name = "Diet Type")]
        [Required(ErrorMessage = "Choose \"{0}\".")]
        public DietType DietType { get; set; }

        public string PublicationUserId { get; set; }
    }
}
