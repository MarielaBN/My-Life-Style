namespace MyLifeStyle.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        public Article()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string PublicationId { get; set; }

        public virtual Publication Publication { get; set; }
    }
}
