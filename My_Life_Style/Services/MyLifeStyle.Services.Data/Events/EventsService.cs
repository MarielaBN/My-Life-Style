namespace MyLifeStyle.Services.Data.Events
{
    using System.Collections.Generic;
    using System.Linq;

    using MyLifeStyle.Data;
    using MyLifeStyle.Services.Mapping;

    public class EventsService : IEventsService
    {
        private readonly ApplicationDbContext context;

        public EventsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TViewModel> GetAllEvents<TViewModel>()
        {
            var events = this.context.Events
                 .OrderBy(x => x.StartTime).ThenBy(y => y.EndTime)
                 .To<TViewModel>()
                 .ToList();

            return events;
        }
    }
}
