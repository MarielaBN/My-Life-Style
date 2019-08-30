namespace MyLifeStyle.Services.Data.Books
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyLifeStyle.Web.ViewModels.Books;

    public interface IBooksService
    {
        Task<IEnumerable<TViewModel>> GetAllBooks<TViewModel>();

        Task<bool> CreateBook(BookCreateInputModel bookModel);
    }
}
