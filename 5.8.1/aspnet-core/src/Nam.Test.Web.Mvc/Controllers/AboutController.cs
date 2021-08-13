using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Nam.Test.Controllers;

namespace Nam.Test.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : TestControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
