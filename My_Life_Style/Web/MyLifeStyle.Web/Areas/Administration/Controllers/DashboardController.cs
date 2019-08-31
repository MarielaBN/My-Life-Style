namespace MyLifeStyle.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyLifeStyle.Common;
    using MyLifeStyle.Data.Models;
    using MyLifeStyle.Services.Data;
    using MyLifeStyle.Services.Data.Dashboard;
    using MyLifeStyle.Web.Areas.Administration.ViewModels.Dashboard;

    public class DashboardController : AdministrationController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDashboardService dashboardService;

        public DashboardController(UserManager<ApplicationUser> userManager, IDashboardService dashboardService)
        {
            this.userManager = userManager;
            this.dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            int getAllRegisteredCount = this.userManager.Users.Select(x => x).Count();
            int getAllModeratorsCount = this.dashboardService.GetModeratorsCount();
            int getAllAdmins = GlobalConstants.AdminsCount;
            int getAllUsersCount = getAllRegisteredCount - getAllModeratorsCount - getAllAdmins;
            var viewModel = new AllUsersViewModel { AllRegisteredCount = getAllRegisteredCount, AllModeratorsCount = getAllModeratorsCount, AllUsersCount = getAllUsersCount, AllAdminsCount = getAllAdmins };
            return this.View(viewModel);
        }

        public async Task<IActionResult> Promote()
        {

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Promote(PromoteUserInputModel promoteUserInput)
        {

            var getUser = this.userManager.Users.Where(x => x.UserName == promoteUserInput.UserName).Select(x => x).FirstOrDefault();
            var result1 = await this.userManager.RemoveFromRoleAsync(getUser, GlobalConstants.UserRoleName);

            if (result1.Succeeded)
            {
                var result2 = await this.userManager.AddToRoleAsync(getUser, GlobalConstants.ModeratorRoleName);

                if (result2.Succeeded)
                {
                    return this.Redirect("/Administration/Dashboard/Index");
                }
            }

            foreach (var error in result1.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }

            return this.Redirect("/Administration/Dashboard/Index");
        }

        public async Task<IActionResult> Demote()
        {

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Demote(DemoteModeratorInputModel demoteModeratorInput)
        {
            var getUser = this.userManager.Users.Where(x => x.UserName == demoteModeratorInput.UserName).Select(x => x).FirstOrDefault();
            var result1 = await this.userManager.RemoveFromRoleAsync(getUser, GlobalConstants.ModeratorRoleName);

            if (result1.Succeeded)
            {
                var result2 = await this.userManager.AddToRoleAsync(getUser, GlobalConstants.UserRoleName);

                if (result2.Succeeded)
                {
                    return this.Redirect("/Administration/Dashboard/Index");
                }
            }

            foreach (var error in result1.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }

            return this.Redirect("/Administration/Dashboard/Index");
        }

        //public IActionResult Index()
        //{
        //    var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
        //    return this.View(viewModel);
        //}
    }
}
