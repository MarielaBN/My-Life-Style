namespace MyLifeStyle.Web.ViewModels.Books
{
    using System.ComponentModel.DataAnnotations;

    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;

    public class BookCreateInputModel : IMapTo<Book>
    {
        [Display(Name = "Title")]
        [StringLength(400, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Required(ErrorMessage = "Enter \"{0}\".")]
        public string PublicationTitle { get; set; }

        [Display(Name = "Description")]
        [MaxLength(1000, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string Description { get; set; }

        [Display(Name = "Author Name")]
        [Required]
        [MaxLength(200, ErrorMessage = "The {0} must be at max {1} characters long.")]
        public string AuthorName { get; set; }

        [Display(Name = "Year")]
        [Range(1000, 3000)]
        public ushort Year { get; set; }

        public string PublicationUserId { get; set; }
    }
}
