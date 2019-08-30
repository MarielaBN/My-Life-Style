namespace MyLifeStyle.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Data.Books;
    using MyLifeStyle.Web.ViewModels.Books;
    using System.Threading.Tasks;

    public class BooksController : BaseController
    {
        private readonly IBooksService booksService;
        private readonly UserManager<ApplicationUser> userManager;

        public BooksController(IBooksService booksService, UserManager<ApplicationUser> userManager)
        {
            this.booksService = booksService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var books = this.booksService
                  .GetAllBooks<AllBooksViewModel>();

            return this.View(books);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var userId = this.userManager.GetUserId(this.User);
            var bookCreateInputModel = new BookCreateInputModel
            {
                PublicationUserId = userId,
            };

            return this.View(bookCreateInputModel);
            //return this.Json(bookCreateInputModel);
        }

        [HttpPost(Name = "Create")]
        [Authorize]
        public async Task<IActionResult> Create(BookCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.userManager.GetUserId(this.User);
            model.PublicationUserId = userId;

            bool isCreted = await this.booksService.CreateBook(model);

            if (!isCreted)
            {
                return this.View(model);
            }

            return this.Redirect("/Books/All");
           // return this.Json(model);
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var currentUserId = this.userManager.GetUserId(this.User);
            //BookDetailsViewModel bookViewModel = await this.booksService.GetBookById(id);
            //bookViewModel.CurrentUserId = currentUserId;

            //return this.View(bookViewModel);
            // return this.Json(bookViewModel);
            return this.Redirect("/Books/All");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var recipeId = id;
            return this.View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var recipeId = id;
            return this.View();
        }
    }
}
