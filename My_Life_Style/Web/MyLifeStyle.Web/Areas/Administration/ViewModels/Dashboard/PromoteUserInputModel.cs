namespace MyLifeStyle.Web.Areas.Administration.ViewModels.Dashboard
{
    using System.ComponentModel.DataAnnotations;

    public class PromoteUserInputModel
    {
        [Required]
        [Display(Name = "Enter Username")]
        public string UserName { get; set; }
    }
}
