namespace MyLifeStyle.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int ArticlesCount { get; set; }
    }
}
