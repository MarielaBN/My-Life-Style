namespace MyLifeStyle.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MyLifeStyle.Data.Common.Models;

    public class Comment : BaseModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string PublicationId { get; set; }

        public virtual Publication Publication { get; set; }
    }
}
