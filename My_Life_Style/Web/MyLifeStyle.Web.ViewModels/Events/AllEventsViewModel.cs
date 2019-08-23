namespace MyLifeStyle.Web.ViewModels.Events
{
    using System;

    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;

    public class AllEventsViewModel : IMapFrom<Event>
    {
        public string PublicationTitle { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string CategoryName { get; set; }
    }
}
