namespace MyLifeStyle.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Services.Data.Books;
    using MyLifeStyle.Web.ViewModels.Books;

    public class BooksController : BaseController
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        public IActionResult Index()
        {
            var books = this.booksService
                  .GetAllBooks<AllBooksViewModel>();

            return this.View(books);
        }
    }
}
