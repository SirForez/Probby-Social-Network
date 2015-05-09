﻿using System;
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
           /* FeedViewModel model = new FeedViewModel();
            model.currentUser = accountService.getUserByName(User.Identity.Name);
            return View(model);
		    */

			FeedViewModel model = new FeedViewModel();
			model.currentUser = accountService.getUserByName(User.Identity.Name);
            model.newestStatuses = statusService.getStatusByUser(model.currentUser);
            model.commentsForStatuses = new List<Comment>();

			//For statuses, we also need to add the hobbies and shit

		    foreach (Status s in model.newestStatuses)
			{
				List<Comment> currentCommentList = statusService.getCommentsByStatus(s);
				foreach (Comment c in currentCommentList)
				{
					model.commentsForStatuses.Add(c);
				}
			}
			
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
		public ActionResult Profile(string id)
		{
			ViewBag.Message = "Here you should see your profile!";
            ProfileViewModel model = new ProfileViewModel();

            //NOTE: This works, but if a parameter is given in the url, and profile button is pressed again, it will go to that profile.
            //So, if you go to your own profile by pressing the default profile button, then to quangs profile, then click the profile button
            //again to go back to your profile, it will go to quangs profile until the url has changed. Needs fixing.

            if (id != null)
            {
                model.currentUser = accountService.getUserByName(id);
            }
            else
            {
                model.currentUser = accountService.getUserByName(User.Identity.Name);
            }

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