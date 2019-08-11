namespace MyLifeStyle.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(200)]
        public string AuthorName { get; set; }

        [Range(1000, 3000)]
        public int Year { get; set; }

        [Required]
        public string PublicationId { get; set; }

        public virtual Publication Publication { get; set; }
    }
}
