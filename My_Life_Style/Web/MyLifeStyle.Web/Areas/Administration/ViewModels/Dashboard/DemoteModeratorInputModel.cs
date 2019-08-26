namespace MyLifeStyle.Web.Areas.Administration.ViewModels.Dashboard
{
    using System.ComponentModel.DataAnnotations;

    public class DemoteModeratorInputModel
    {
        [Required]
        [Display(Name = "Enter Username")]
        public string UserName { get; set; }
    }
}
