namespace MyLifeStyle.Services.Data.Events
{
    using MyLifeStyle.Web.ViewModels.Events;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEventsService
    {
        IEnumerable<TViewModel> GetAllEvents<TViewModel>();

        Task<bool> CreateEvent(EventCreateInputModel eventModel);
    }
}
