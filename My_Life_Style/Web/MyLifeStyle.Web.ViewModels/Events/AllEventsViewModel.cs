namespace MyLifeStyle.Web.ViewModels.Events
{
    using System;
    using AutoMapper;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;

    public class AllEventsViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string PublicationTitle { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Address { get; set; }

        public int CommentsCount { get; set; }

        public DateTime PublicationCreatedOn { get; set; }

        public string Summary { get; set; }

        public string CategoryName { get; set; }

        public string CategoryId { get; set; }

        public string PublicationId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Event, AllEventsViewModel>()
                .ForMember(
                x => x.CommentsCount,
                opt => opt.MapFrom(x => x.Publication.Comments.Count));

            configuration.CreateMap<Event, AllEventsViewModel>()
                .ForMember(
                x => x.Summary,
                opt => opt.MapFrom(x => x.Description.Substring(0, 200) + "..."));
        }
    }
}
