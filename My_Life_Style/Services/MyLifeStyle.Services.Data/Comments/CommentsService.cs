namespace MyLifeStyle.Services.Data.Comments
{
    using System.Collections.Generic;
    using System.Linq;

    using MyLifeStyle.Data;
    using MyLifeStyle.Services.Mapping;

    public class CommentsService : ICommentsService
    {
        private readonly ApplicationDbContext context;

        public CommentsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TViewModel> GetAllComments<TViewModel>(string publicationId)
        {
            var comments = this.context.Comments
                .Where(x => x.PublicationId == publicationId)
                .OrderBy(x => x.CreatedOn)
                .To<TViewModel>()
                .ToList();

            return comments;
        }
    }
}
