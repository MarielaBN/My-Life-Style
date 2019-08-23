namespace MyLifeStyle.Services.Data.Books
{
    using System.Collections.Generic;

    public interface IBooksService
    {
        IEnumerable<TViewModel> GetAllBooks<TViewModel>();
    }
}
