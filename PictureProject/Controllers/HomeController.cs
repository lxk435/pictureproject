using PictureProject.Models;
using PictureProject.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace PictureProject.Controllers
{
    public class HomeController : Controller
    {
        private PictureProjectContext db = new PictureProjectContext();

        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                Title = "Home Page",
                Images = db.InstagramImages.ToList()
            };

            return View(model);
        }
    }
}
