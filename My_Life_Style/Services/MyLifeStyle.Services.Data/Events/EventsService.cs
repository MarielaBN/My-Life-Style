namespace MyLifeStyle.Services.Data.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MyLifeStyle.Data;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;
    using MyLifeStyle.Web.ViewModels.Events;

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

        public async Task<bool> CreateEvent(EventCreateInputModel eventModel)
        {
            Publication publication = new Publication
            {
                CreatedOn = DateTime.UtcNow,
                Title = eventModel.PublicationTitle,
                UserId = eventModel.PublicationUserId,
            };

            await this.context.Publications.AddAsync(publication);

            Event newEvent = new Event
            {
                Description = eventModel.Description,
                Address = eventModel.Address,
                StartTime = eventModel.StartTime,
                EndTime = eventModel.EndTime,
                CategoryId = eventModel.CategoryId,
                PublicationId = publication.Id,
            };

            await this.context.Events.AddAsync(newEvent);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
