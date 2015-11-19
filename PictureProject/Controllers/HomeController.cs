using log4net;
using PictureProject.Models;
using PictureProject.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace PictureProject.Controllers
{
    public class HomeController : Controller
    {
        private PictureProjectContext db = new PictureProjectContext();
        private static readonly ILog logger = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            logger.Debug("Loading homepage");
            var model = new HomeViewModel
            {
                Title = "Home Page",
                Images = db.InstagramImages.ToList()
            };

            return View(model);
        }
    }
}
