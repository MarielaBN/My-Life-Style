namespace MyLifeStyle.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Services.Data.Comments;
    using MyLifeStyle.Web.ViewModels.Comments;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public IActionResult Index(string publicationId)
        {
            var comments = this.commentsService
                  .GetAllComments<AllCommentsViewModel>(publicationId);

            return this.View(comments);
        }
    }
}
