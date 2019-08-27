﻿namespace MyLifeStyle.Web.Controllers
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
        public IActionResult Index(string id)
        {
            var articles = this.articlesService
                  .GetAllArticlesByCategory<AllArticlesViewModel>(id);

            return this.View(articles);
           // return this.Json(articles);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var articles = this.articlesService.GetAllArticles<AllArticlesViewModel>();

            return this.View(articles);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var categories = this.categoriesService
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
    }
}
