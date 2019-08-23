namespace MyLifeStyle.Web.ViewModels.Books
{
    using System;

    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Mapping;

    public class AllBooksViewModel : IMapFrom<Book>
    {
        public string PublicationTitle { get; set; }

        public string AuthorName { get; set; }

        public ushort Year { get; set; }

        public DateTime PublicationCreatedOn { get; set; }
    }
}
