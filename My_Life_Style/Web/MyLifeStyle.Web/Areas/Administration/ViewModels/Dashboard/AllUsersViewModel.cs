using System.ComponentModel.DataAnnotations;

namespace MyLifeStyle.Web.Areas.Administration.ViewModels.Dashboard
{
    public class AllUsersViewModel
    {
        public int AllRegisteredCount { get; set; }

        public int AllModeratorsCount { get; set; }

        public int AllUsersCount { get; set; }

        public int AllAdminsCount { get; set; }
    }
}
