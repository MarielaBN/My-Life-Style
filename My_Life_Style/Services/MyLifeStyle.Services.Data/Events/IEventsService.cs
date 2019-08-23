namespace MyLifeStyle.Services.Data.Events
{
    using System.Collections.Generic;

    public interface IEventsService
    {
        IEnumerable<TViewModel> GetAllEvents<TViewModel>();
    }
}
