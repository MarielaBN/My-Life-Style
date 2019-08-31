using MyLifeStyle.Data.Models;
using MyLifeStyle.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLifeStyle.Web.ViewModels.Articles
{
  public class ArticleDeleteBindingModel : IMapFrom<Article>
    {
        public string Id { get; set; }

        public string PublicationUserId { get; set; }

        public string PublicationId { get; set; }
    }
}
