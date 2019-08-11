namespace MyLifeStyle.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum DietType
    {
        [Display(Name = "Общи")]
        Common = 1,

        [Display(Name = "Вегетариански")]
        Vegetarian = 2,

        [Display(Name = "Веган")]
        Vegan = 3,

        [Display(Name = "Сурови")]
        Raw = 4,
    }
}
