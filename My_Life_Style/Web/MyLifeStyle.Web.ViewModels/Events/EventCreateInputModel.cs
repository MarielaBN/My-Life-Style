namespace MyLifeStyle.Web.ViewModels.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;
    using MyLifeStyle.Web.ViewModels.Categories;

    public class EventCreateInputModel : IMapTo<Event>
    {
        [Display(Name = "Title")]
        [StringLength(400, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Required(ErrorMessage = "Enter \"{0}\".")]
        public string PublicationTitle { get; set; }

        [Display(Name = "Description")]
        [MaxLength(1000, ErrorMessage = "The {0} must be at max {1} characters long.")]
        [Required(ErrorMessage = "Enter \"{0}\".")]
        public string Description { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter \"{0}\".")]
        public string Address { get; set; }

        [Display(Name = "Start Time")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Enter \"{0}\".")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Enter \"{0}\".")]
        public DateTime EndTime { get; set; }

        public string PublicationUserId { get; set; }

        [Required(ErrorMessage = "Choose Category.")]
        public string CategoryId { get; set; }

        public IEnumerable<AllCategoriesViewModel> AllCategories { get; set; }
    }
}
