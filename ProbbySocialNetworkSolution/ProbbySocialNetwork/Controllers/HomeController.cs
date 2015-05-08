using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProbbySocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        // This is the feed
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Some information about Probby!";

            return View();
        }

		public ActionResult Messages()
		{
			ViewBag.Message = "Here you should see your messages!";

			return View();
		}

		public ActionResult Profile()
		{
			ViewBag.Message = "Here you should see your profile!";

			return View();
		}

		public ActionResult Notifications()
		{
			ViewBag.Message = "Here you should see your notifications!";

			return View();
		}

		public ActionResult Search()
		{
			ViewBag.Message = "Here you should see your search results";
			return View();
		}

        public ActionResult AddFollower()
        {
            //TODO: Implement
            return View();
        }

        public ActionResult AddFollowing()
        {
            //TODO: Implement
            return View();
        }

        public ActionResult RemoveFollower()
        {
            //TODO: Implement
            return View();
        }

        public ActionResult RemoveFollowing()
        {
            //TODO: Implement
            return View();
        }
    }
}