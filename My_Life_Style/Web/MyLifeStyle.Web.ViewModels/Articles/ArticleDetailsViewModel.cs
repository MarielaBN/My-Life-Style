namespace MyLifeStyle.Web.ViewModels.Articles
{
    using System;

    using AutoMapper;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;

    public class ArticleDetailsViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string PublicationTitle { get; set; }

        public string Description { get; set; }

        public string CategoryId { get; set; }

        public string PublicationUserId { get; set; }

        public string CurrentUserId { get; set; }

        public DateTime PublicationCreatedOn { get; set; }

        public string PublicationUserFullName { get; set; }

        public string CategoryName { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Article, ArticleDetailsViewModel>()
                .ForMember(
                x => x.CommentsCount,
                opt => opt.MapFrom(x => x.Publication.Comments.Count));
        }
    }
}
