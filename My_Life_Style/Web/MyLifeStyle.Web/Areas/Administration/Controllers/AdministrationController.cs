namespace MyLifeStyle.Web.Areas.Administration.Controllers
{
    using MyLifeStyle.Common;
    using MyLifeStyle.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
