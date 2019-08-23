namespace MyLifeStyle.Web.ViewModels.Articles
{
    using System;

    using AutoMapper;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;

    public class AllArticlesByCategoryViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public string PublicationTitle { get; set; }

        public int CommentsCount { get; set; }

        public DateTime PublicationCreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Article, AllArticlesByCategoryViewModel>()
                .ForMember(
                x => x.CommentsCount,
                opt => opt.MapFrom(x => x.Publication.Comments.Count));
        }
    }
}
