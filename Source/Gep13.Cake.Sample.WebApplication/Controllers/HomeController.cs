namespace Gep13.Cake.Sample.WebApplication.Controllers
{
    using System.Web.Mvc;
    using Gep13.Cake.Sample.Common;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = DescriptionService.GetWebApplicationDescription();

            return View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = ContactService.GetWebApplicationContactInformation();

            return this.View();
        }
    }
}