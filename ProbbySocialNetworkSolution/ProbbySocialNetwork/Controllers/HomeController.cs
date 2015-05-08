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
            FeedViewModel model = new FeedViewModel();
            model.currentUser = accountService.getUserByName(User.Identity.Name);
            return View(model);
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

        [Authorize]
        [HttpGet]
		public ActionResult Profile()
		{
			ViewBag.Message = "Here you should see your profile!";

            ProfileViewModel model = new ProfileViewModel();
            model.currentUser = accountService.getUserByName(User.Identity.Name);
            model.currentUserStatusHistory = statusService.getStatusByUser(model.currentUser);
            model.commentsForStatuses = new List<Comment>();

            //For statuses, we also need to add the hobbies and shit

            model.currentUserStatusHistory = statusService.getStatusByUser(model.currentUser);
            foreach(Status s in model.currentUserStatusHistory) {
                List<Comment> currentCommentList = statusService.getCommentsByStatus(s);
                foreach(Comment c in currentCommentList)
                {
                    model.commentsForStatuses.Add(c);
                }
            }

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