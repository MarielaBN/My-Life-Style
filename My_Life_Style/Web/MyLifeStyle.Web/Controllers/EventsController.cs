namespace MyLifeStyle.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Data.Categories;
    using MyLifeStyle.Services.Data.Events;
    using MyLifeStyle.Web.ViewModels.Categories;
    using MyLifeStyle.Web.ViewModels.Events;
    using System.Threading.Tasks;

    public class EventsController : BaseController
    {
        private readonly IEventsService eventsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public EventsController(IEventsService eventsService, ICategoriesService categoriesService, UserManager<ApplicationUser> userManager)
        {
            this.eventsService = eventsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            var events = await this.eventsService
                  .GetAllEvents<AllEventsViewModel>();

            return this.View(events);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var categories = await this.categoriesService
                 .GetAllCategories<AllCategoriesViewModel>();
            var userId = this.userManager.GetUserId(this.User);
            var eventCreateInputModel = new EventCreateInputModel
            {
                PublicationUserId = userId,
                AllCategories = categories,
            };

            return this.View(eventCreateInputModel);
            // return this.Json(eventCreateInputModel);
        }

        [HttpPost(Name = "Create")]
        [Authorize]
        public async Task<IActionResult> Create(EventCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.userManager.GetUserId(this.User);
            model.PublicationUserId = userId;

            bool isCreted = await this.eventsService.CreateEvent(model);

            if (!isCreted)
            {
                return this.View(model);
            }

            return this.Redirect("/Events/All");
            //return this.Json(model);
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var currentUserId = this.userManager.GetUserId(this.User);
            //EventDetailsViewModel eventViewModel = await this.eventsService.GetEventById(id);
            //eventViewModel.CurrentUserId = currentUserId;

            //return this.View(eventViewModel);
            // return this.Json(eventViewModel);
            return this.Redirect("/Events/All");
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
