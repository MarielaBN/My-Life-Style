namespace MyLifeStyle.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Services.Data.Events;
    using MyLifeStyle.Web.ViewModels.Events;

    public class EventsController : BaseController
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public IActionResult Index()
        {
            var events = this.eventsService
                  .GetAllEvents<AllEventsViewModel>();

            return this.View(events);
        }
    }
}
