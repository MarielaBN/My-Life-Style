namespace MyLifeStyle.Services.Data.Books
{
    using System.Collections.Generic;
    using System.Linq;

    using MyLifeStyle.Data;
    using MyLifeStyle.Services.Mapping;

    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext context;

        public BooksService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TViewModel> GetAllBooks<TViewModel>()
        {
            var books = this.context.Books
                 .OrderByDescending(x => x.Publication.CreatedOn)
                 .To<TViewModel>()
                 .ToList();

            return books;
        }
    }
}
