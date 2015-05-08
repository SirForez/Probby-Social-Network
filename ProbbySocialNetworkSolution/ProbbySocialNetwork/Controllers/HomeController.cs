using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProbbySocialNetwork.Models;
using ProbbySocialNetwork.Models.ViewModels;

namespace ProbbySocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        //FUTURE NOTE: To get current foloower, var UserID = User.Identity.getUserID()
        public ServiceSingleton serviceManager = ServiceSingleton.GetInstance;
        public AccountService accountService = ServiceSingleton.GetAccountService;
        public StatusService statusService = ServiceSingleton.GetStatusService;

        // This is the feed
        [Authorize]
        public ActionResult Index()
        {
			ViewBag.Message = "Some information about home page";
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

        [HttpGet]
		public ActionResult Profile()
		{
			ViewBag.Message = "Here you should see your profile!";

            ProfileViewModel model = new ProfileViewModel();
            model.currentUser = accountService.getUserByName(User.Identity.Name);
            model.currentUserStatusHistory = statusService.getStatusByUser(model.currentUser);

            //Just testing
            Status s1 = new Status();
            s1.Post = "Hello, World!";
            s1.Date = DateTime.Now;
            Status s2 = new Status();
            s2.Post = "Goodbye, cruel world!";
            s2.Date = DateTime.Now;

            model.currentUserStatusHistory.Add(s1);
            model.currentUserStatusHistory.Add(s2);

            return View(model);
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