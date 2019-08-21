namespace MyLifeStyle.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MyLifeStyle.Data.Common.Models;

    public class Publication : BaseModel<string>
    {
        public Publication()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new List<Comment>();
            this.Images = new List<Image>();
        }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
