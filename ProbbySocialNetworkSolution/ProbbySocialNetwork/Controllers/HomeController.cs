using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProbbySocialNetwork.Models;
using ProbbySocialNetwork.Models.ViewModels;
using ProbbySocialNetwork.Services;
using ProbbySocialNetwork.Connections;

namespace ProbbySocialNetwork.Controllers
{
    public class HomeController : Controller
    {
		public ServiceSingleton serviceManager = ServiceSingleton.GetInstance;
		public AccountService accountService = ServiceSingleton.GetAccountService;
		public StatusService statusService = ServiceSingleton.GetStatusService;
		public GroupService groupService = ServiceSingleton.GetGroupService;
		public HobbyService hobbyService = ServiceSingleton.GetHobbyService;
        public ChatService chatService = ServiceSingleton.GetChatService;

        [Authorize]
        public ActionResult Index()
        {
			FeedViewModel model = new FeedViewModel();
			model.currentUser = accountService.getUserByName(User.Identity.Name);
            model.newestStatuses = statusService.getStatusFeedByUser(model.currentUser);
            model.commentsForStatuses = new List<Comment>();
			model.currentUserGroups = groupService.getGroupsByUser(model.currentUser);
            model.currentUserGroups.AddRange(groupService.getGroupsByAdmin(model.currentUser));
            model.currentUserHobbies = hobbyService.getHobbiesByUser(model.currentUser);

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

        [Authorize]
        [HttpGet]
		public ActionResult Profile(string username)
		{
			ViewBag.Message = "Here you should see your profile!";
            ProfileViewModel model = new ProfileViewModel();

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

        [Authorize]
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

        [Authorize]
		public ActionResult EditProfilePic(FormCollection collection)
		{
			ApplicationUser currentUser = accountService.getUserByName(User.Identity.Name);
			
			accountService.editProfilePicture(currentUser, collection["picLink"]);

			List<Status> userStatuses = statusService.getStatusesByUserForEditProfilePic(currentUser);

			foreach (Status s in userStatuses)
			{
				statusService.editStatusProfilePicture(s, currentUser.ProfilePic);
			}

			Status automaticProfileUpdateStatus = new Status();

			automaticProfileUpdateStatus.UserName = currentUser.UserName;
			automaticProfileUpdateStatus.Date = DateTime.Now;
			automaticProfileUpdateStatus.MediaURL = collection["picLink"];
			automaticProfileUpdateStatus.Post = currentUser.UserName + " just got a new profile picture!";
			automaticProfileUpdateStatus.ProfilePic = currentUser.ProfilePic;
			automaticProfileUpdateStatus.UserID = currentUser.Id;
			automaticProfileUpdateStatus.Karma = 0;

			statusService.addStatus(automaticProfileUpdateStatus);

			string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
		}

        [Authorize]
		public ActionResult Saved()
		{
			SavedFeedViewModel model = new SavedFeedViewModel();

			model.currentUser = accountService.getUserByName(User.Identity.Name);
			model.savedStatusHistory = statusService.getSavedFeedByUser(model.currentUser);
            model.commentsForStatuses = new List<Comment>();
			
			foreach (Status s in model.savedStatusHistory)
			{
                List<Comment> currentCommentList = statusService.getCommentsByStatus(s);
                foreach(Comment c in currentCommentList)
                {
					model.commentsForStatuses.Add(c);
                }
            }

			return View(model);
		}

        [Authorize]
		public ActionResult AddStatusToSavedFeed (int id)
		{
			Status s = statusService.getStatusByID(id);
			
			ApplicationUser a = accountService.getUserByName(User.Identity.Name);
			
			statusService.addSavedStatus(s, a);
			
			string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
		}

        [Authorize]
		public ActionResult RemoveStatusFromSavedFeed (int id)
		{
			Status s = statusService.getStatusByID(id);
			
			ApplicationUser a = accountService.getUserByName(User.Identity.Name);
			
			statusService.removeSavedStatus(s, a);

			string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
		}
    }
}