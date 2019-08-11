namespace MyLifeStyle.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        // TODO: to change Content to Description
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; } 

        public DateTime? CreatedOn { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string PublicationId { get; set; }

        public virtual Publication Publication { get; set; }
    }
}
