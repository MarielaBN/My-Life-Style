namespace MyLifeStyle.Services.Data.Books
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MyLifeStyle.Data;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;
    using MyLifeStyle.Web.ViewModels.Books;

    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext context;

        public BooksService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TViewModel>> GetAllBooks<TViewModel>()
        {
            var books = await this.context.Books
                 .OrderByDescending(x => x.Publication.CreatedOn)
                 .To<TViewModel>()
                 .ToListAsync();

            return books;
        }

        public async Task<bool> CreateBook(BookCreateInputModel bookModel)
        {
            Publication publication = new Publication
            {
                CreatedOn = DateTime.UtcNow,
                Title = bookModel.PublicationTitle,
                UserId = bookModel.PublicationUserId,
            };

            await this.context.Publications.AddAsync(publication);

            Book book = new Book
            {
                Description = bookModel.Description,
                AuthorName = bookModel.AuthorName,
                Year = bookModel.Year,
                PublicationId = publication.Id,
            };

            await this.context.Books.AddAsync(book);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
