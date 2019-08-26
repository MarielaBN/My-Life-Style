namespace MyLifeStyle.Services.Data.Dashboard
{
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using MyLifeStyle.Data;
    using MyLifeStyle.Data.Common.Repositories;
    using MyLifeStyle.Data.Models;

    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext context;

        public DashboardService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int GetModeratorsCount()
        {
            var moderatorRoleId = this.context.Roles.Where(x => x.Name == "Moderator").Select(x => x.Id).FirstOrDefault();
            var moderatorsUsers = this.context.UserRoles.Where(x => x.RoleId == moderatorRoleId).Count();
            return moderatorsUsers;
        }
    }
}
