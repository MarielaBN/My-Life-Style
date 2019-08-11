namespace MyLifeStyle.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyLifeStyle.Data.Models.Enums;

    public class Recipe
    {
        public Recipe()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [MaxLength(1000)]
        public string Ingredients { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DishType DishType { get; set; }

        [Required]
        public DietType DietType { get; set; }

        [Required]
        public string PublicationId { get; set; }

        public virtual Publication Publication { get; set; }
    }
}
