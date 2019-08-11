namespace MyLifeStyle.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Publication
    {
        public Publication()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new List<Comment>();
        }

        public string Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
