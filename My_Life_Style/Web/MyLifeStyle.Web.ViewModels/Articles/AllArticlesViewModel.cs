namespace MyLifeStyle.Web.ViewModels.Articles
{
    using System;

    using AutoMapper;
    using MyLifeStyle.Common;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;

    public class AllArticlesViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string PublicationTitle { get; set; }

        public int CommentsCount { get; set; }

        public DateTime PublicationCreatedOn { get; set; }

        public string Summary { get; set; }

        public string CategoryName { get; set; }

        public string CategoryId { get; set; }

        public string PublicationId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Article, AllArticlesViewModel>()
                .ForMember(
                x => x.CommentsCount,
                opt => opt.MapFrom(x => x.Publication.Comments.Count));

            configuration.CreateMap<Article, AllArticlesViewModel>()
                .ForMember(
                x => x.Summary,
                opt => opt.MapFrom(x => x.Description.Substring(0, GlobalConstants.SummaryLength) + "..."));
        }
    }
}
