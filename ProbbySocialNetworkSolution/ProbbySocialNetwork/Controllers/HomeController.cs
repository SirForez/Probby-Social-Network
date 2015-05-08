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
            model.commentsForStatuses = new List<Comment>();

            //Just testing
            Status s1 = new Status();
            s1.ID = 1;
            s1.Post = "Hello, World!";
            s1.Date = DateTime.Now;
            Status s2 = new Status();
            s2.ID = 2;
            s2.Post = "Goodbye, cruel world!";
            s2.Date = DateTime.Now;

            model.currentUserStatusHistory.Add(s1);
            model.currentUserStatusHistory.Add(s2);

            Comment c1 = new Comment();
            c1.ID = 1;
            c1.Body = "Go fuck yourself!";
            c1.DateInserted = DateTime.Now;
            c1.StatusID = s1.ID;
            c1.UserID = model.currentUser.Id;
            statusService.addComment(c1);

            Comment c2 = new Comment();
            c2.ID = 2;
            c2.Body = "Do a 360 noscope dumbass";
            c2.DateInserted = DateTime.Now;
            c2.StatusID = s2.ID;
            c2.UserID = model.currentUser.Id;
            statusService.addComment(c2);

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