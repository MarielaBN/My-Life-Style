namespace MyLifeStyle.Services.Data.Comments
{
    using System.Collections.Generic;

    public interface ICommentsService
    {
        IEnumerable<TViewModel> GetAllComments<TViewModel>(string publicationId);
    }
}
