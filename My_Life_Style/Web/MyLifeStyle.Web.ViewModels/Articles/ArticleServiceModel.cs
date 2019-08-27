using MyLifeStyle.Data.Models;
using MyLifeStyle.Services.Mapping;
using MyLifeStyle.Web.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyLifeStyle.Web.ViewModels.Articles
{
    public class ArticleServiceModel : IMapTo<Article> //, IMapFrom<Article>
    {
        [MaxLength(400)]
        public string PublicationTitle { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
