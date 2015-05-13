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
		public GroupService groupService = ServiceSingleton.GetGroupService;
		public HobbyService hobbyService = ServiceSingleton.GetHobbyService;

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
            model.newestStatuses = statusService.getStatusFeedByUser(model.currentUser);
            model.commentsForStatuses = new List<Comment>();
			model.currentUserGroups = groupService.getGroupsByUser(model.currentUser);
            model.currentUserGroups.AddRange(groupService.getGroupsByAdmin(model.currentUser));
            model.currentUserHobbies = hobbyService.getHobbiesByUser(model.currentUser);

			//For statuses, we also need to add the hobbies and shit

			if (model.newestStatuses != null)
			{
				foreach (Status s in model.newestStatuses)
				{
					List<Comment> currentCommentList = statusService.getCommentsByStatus(s);
					foreach (Comment c in currentCommentList)
					{
						model.commentsForStatuses.Add(c);
					}
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
		public ActionResult Profile(string username)
		{
			ViewBag.Message = "Here you should see your profile!";
            ProfileViewModel model = new ProfileViewModel();

            //NOTE: This works, but if a parameter is given in the url, and profile button is pressed again, it will go to that profile.
            //So, if you go to your own profile by pressing the default profile button, then to quangs profile, then click the profile button
            //again to go back to your profile, it will go to quangs profile until the url has changed. Needs fixing.

           //Think it always gives a parameter now, needs testing though! - Bjartur
            model.currentUser = accountService.getUserByName(User.Identity.Name);
		    if (username != null)
            {
                model.profileOwner = accountService.getUserByName(username);
            }
            else
            {
                model.profileOwner = model.currentUser;
            }

			model.profileOwnerFollowing = accountService.getFollowingByUser(model.profileOwner);
			model.profileOwnerFollowers = accountService.getFollowersByUser(model.profileOwner);
			model.profileOwnerStatusHistory = statusService.getStatusesByUser(model.profileOwner);
			model.profileOwnerFollowing = accountService.getFollowingByUser(model.profileOwner);
			model.profileOwnerFollowers = accountService.getFollowersByUser(model.profileOwner);
            model.commentsForStatuses = new List<Comment>();
			model.profileOwnerHobbies = hobbyService.getHobbiesByUser(model.profileOwner);

			model.profileOwnerStatusHistory = statusService.getStatusesByUser(model.profileOwner);
			foreach (Status s in model.profileOwnerStatusHistory)
			{
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

		public ActionResult Search(FormCollection collection)
		{
            String searchString = collection["searchBar"];
            SearchViewModel model = new SearchViewModel();

            model.searchString = searchString;
            model.groupSearchResults = groupService.groupSearch(searchString);
            model.hobbySearchResults = hobbyService.hobbySearch(searchString);
            model.userSearchResults = accountService.userSearch(searchString);

			return View(model);
		}

		public ActionResult EditProfilePic(FormCollection collection)
		{
			ApplicationUser currentUser = accountService.getUserByName(User.Identity.Name);
			
			accountService.editProfilePicture(currentUser, collection["picLink"]);


			List<Status> userStatuses = statusService.getStatusesByUser(currentUser);

			foreach (Status s in userStatuses)
			{
				statusService.editStatusProfilePicture(s, currentUser.ProfilePic);
			}

			string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
		}
    }
}