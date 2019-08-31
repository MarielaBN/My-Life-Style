namespace MyLifeStyle.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Data.Articles;
    using MyLifeStyle.Services.Data.Categories;
    using MyLifeStyle.Web.ViewModels.Articles;
    using MyLifeStyle.Web.ViewModels.Categories;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using MyLifeStyle.Services.Mapping;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MyLifeStyle.Common;
    using Microsoft.AspNetCore.Http;

    public class ArticlesController : BaseController, IMapTo<ArticleServiceModel>
    {
        private readonly IArticlesService articlesService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ArticlesController(IArticlesService articlesService, ICategoriesService categoriesService, UserManager<ApplicationUser> userManager)
        {
            this.articlesService = articlesService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        [HttpGet("[controller]/[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Index(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await this.articlesService
                  .GetAllArticlesByCategory<AllArticlesViewModel>(id);

            return this.View(articles);
            // return this.Json(articles);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var articles = await this.articlesService.GetAllArticles<AllArticlesViewModel>();

            return this.View(articles);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var categories = await this.categoriesService
                  .GetAllCategories<AllCategoriesViewModel>();
            var articleCreateInputModel = new ArticleCreateInputModel
            {
                AllCategories = categories,
            };

            return this.View(articleCreateInputModel);
        }

        [HttpPost(Name = "Create")]
        [Authorize]
        public async Task<IActionResult> Create(ArticleCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.userManager.GetUserId(this.User);
            var serviceModel = new ArticleServiceModel
            {
                PublicationTitle = model.PublicationTitle,
                Description = model.Description,
                CategoryId = model.CategoryId,
                UserId = userId,
            };

            bool isCreted = await this.articlesService.CreateArticle(serviceModel);

            if (!isCreted)
            {
                return this.View(model);
            }

            return this.Redirect("/Articles/All");
            // return this.Json(model);
        }

        [HttpGet(Name = "Details")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUserId = this.userManager.GetUserId(this.User);
            ArticleDetailsViewModel articleViewModel = await this.articlesService.GetArticleById(id);
            if (articleViewModel == null)
            {
                return NotFound();
            }

            articleViewModel.CurrentUserId = currentUserId;

            return this.View(articleViewModel);
            // return this.Json(articleViewModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var articleId = id;
            return this.View();
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articleId = id;
            var articleUserId = await this.articlesService.GetUserIdByArticleId(articleId);
            var currentUserId = this.userManager.GetUserId(this.User);
            if (this.User.IsInRole(GlobalConstants.AdministratorRoleName)
                || this.User.IsInRole(GlobalConstants.ModeratorRoleName)
                || currentUserId == articleUserId)
            {
                await this.articlesService.Delete(id);
            }

            return this.Redirect("/Articles/All");
        }
    }
}
