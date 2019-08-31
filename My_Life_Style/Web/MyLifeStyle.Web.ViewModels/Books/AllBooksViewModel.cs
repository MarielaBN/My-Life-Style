namespace MyLifeStyle.Web.ViewModels.Books
{
    using System;
    using AutoMapper;
    using MyLifeStyle.Common;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;

    public class AllBooksViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string PublicationTitle { get; set; }

        public string AuthorName { get; set; }

        public ushort Year { get; set; }

        public DateTime PublicationCreatedOn { get; set; }

        public string PublicationId { get; set; }

        public int CommentsCount { get; set; }

        public string Summary { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, AllBooksViewModel>()
                .ForMember(
                x => x.CommentsCount,
                opt => opt.MapFrom(x => x.Publication.Comments.Count));

            configuration.CreateMap<Book, AllBooksViewModel>()
                .ForMember(
                x => x.Summary,
                opt => opt.MapFrom(x => x.Description.Substring(0, GlobalConstants.SummaryLength) + "..."));
        }
    }
}
