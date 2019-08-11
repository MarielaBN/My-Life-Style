namespace MyLifeStyle.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum DishType
    {
        [Display(Name = "Основни")]
        Common = 1,

        [Display(Name = "Супи")]
        Soups = 2,

        [Display(Name = "Салати")]
        Salads = 3,

        [Display(Name = "Десерти")]
        Desserts = 4,

        [Display(Name = "Сосове")]
        Scauces = 5,

        [Display(Name = "Смути")]
        Smoothie = 6,

        [Display(Name = "Напитки")]
        Drinks = 7,
    }
}
