using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LocalizationController : Controller
    {
        private IStringLocalizer<SharedResource> _localizer;
        public LocalizationController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }


        public IActionResult Index()
        {
            var value = _localizer["Welcome"];
            return View();
        }
    }
}
