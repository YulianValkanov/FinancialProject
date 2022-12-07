using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FinancialServices.Areas.Administration.Constants.AdminConstants;

namespace FinancialServices.Areas.Administration.Controllers
{
    
        [Area(AreaName)]
        [Route("Admin/[controller]/[Action]/{id?}")]
        [Authorize(Roles = AdminRolleName)]

        public class BaseController : Controller
        {
        }
    
}
