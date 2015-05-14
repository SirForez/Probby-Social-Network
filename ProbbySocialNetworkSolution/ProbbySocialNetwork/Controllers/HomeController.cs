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
        //FUTURE NOTE: To get current foloower, var UserID = User.Identity.getUserID()
		public ServiceSingleton serviceManager = ServiceSingleton.GetInstance;
		public AccountService accountService = ServiceSingleton.GetAccountService;
		public StatusService statusService = ServiceSingleton.GetStatusService;
		public GroupService groupService = ServiceSingleton.GetGroupService;
		public HobbyService hobbyService = ServiceSingleton.GetHobbyService;
        public ChatService chatService = ServiceSingleton.GetChatService;

        // This is the feed
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

        public ActionResult Chats()
        {
            ChatListViewModel model = new ChatListViewModel();
            model.currentUser = accountService.getUserByName(User.Identity.Name);
            model.userChats = chatService.GetChatsByUser(model.currentUser);

            //testing 
            /*Chat c = new Chat();
            UserChatConnection cConnection = new UserChatConnection();
            cConnection.UserID = model.currentUser.Id;
            cConnection.ChatID = c.ID;
            chatService.AddUserChatConnection(cConnection);
            UserChatConnection cC2 = new UserChatConnection();
            cC2.UserID = "b124f7ff-b8f5-4fe9-a83f-d65f14f4745d";
            cC2.ChatID = c.ID;
            chatService.AddUserChatConnection(cC2);*/

            //user can initiate a chat with those he is following
            model.availableChatUsers = accountService.getFollowingByUser(model.currentUser);
            model.usersChattingWith = chatService.getUsersChattingWithByUser(model.currentUser);

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