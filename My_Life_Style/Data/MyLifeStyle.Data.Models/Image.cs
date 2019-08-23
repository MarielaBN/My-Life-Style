namespace MyLifeStyle.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

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
