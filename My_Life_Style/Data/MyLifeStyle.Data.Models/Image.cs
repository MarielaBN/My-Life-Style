using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyLifeStyle.Data.Models
{
  public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Url { get; set; }

        public int SizeInBytes { get; set; }

        public string PublicationId { get; set; }

        public virtual Publication Publication { get; set; }
    }
}
