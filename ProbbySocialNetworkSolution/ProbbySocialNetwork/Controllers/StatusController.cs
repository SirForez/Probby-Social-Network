using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ProbbySocialNetwork.Models;
using ProbbySocialNetwork.Models.ViewModels;
//using ProbbySocialNetwork.Services;

namespace ProbbySocialNetwork.Controllers
{
	public class StatusController : Controller
	{
		public ServiceSingleton serviceManager = ServiceSingleton.GetInstance;
		public AccountService accountService = ServiceSingleton.GetAccountService;
		public StatusService statusService = ServiceSingleton.GetStatusService;
		public GroupService groupService = ServiceSingleton.GetGroupService;
		public HobbyService hobbyService = ServiceSingleton.GetHobbyService;
		
		// GET: Status
		public ActionResult Index()
		{

			//TODO: Implement
			return View();
		}

		[HttpPost]
        public ActionResult CreateStatus(FormCollection collection, string id, int? groupID)
		{
			ApplicationUser currentUser = accountService.getUserByName(User.Identity.Name);
			List <Hobby> currentUserHobbies = hobbyService.getHobbiesByUser(currentUser);
			
			Status s = new Status();

			s.Post = collection["statusText"];
			
			if (collection["url"] != null)
			{
				s.MediaURL = collection["url"];
			}

			if (groupID != null)
			{
                int realGroupID = groupID.Value;
                Group g = groupService.getGroupByID(realGroupID);
				s.GroupID = g.ID;
            }

			s.ProfilePic = currentUser.ProfilePic;
			s.Date = DateTime.Now;
			s.UserID = User.Identity.GetUserId();
            s.UserName = User.Identity.Name;
            if (id != null)
            {
                s.PostedToID = id;
            }
            else
            {
                s.PostedToID = collection["PostedToID"];
            }

			//ApplicationUser a = accountService.getUserByName(User.Identity.Name);
			//s.UserID = a.Id;
			statusService.addStatus(s);

			if (groupID == null)
			{
				foreach (Hobby h in currentUserHobbies)
				{
					if (collection[h.Name] == h.Name)
					{
						statusService.addHobbyToStatus(s, h);
					}
				}
			}
			else
			{
				int realGroupID = groupID.Value;
				Group g = groupService.getGroupByID(realGroupID);
				List<Hobby> currentGroupHobbies = hobbyService.getHobbiesByGroup(g);

				foreach (Hobby h in currentGroupHobbies)
				{
					if (collection[h.Name] == h.Name)
					{
						statusService.addHobbyToStatus(s, h);
					}
				}
			}

			string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
		}

		public ActionResult EditStatus(FormCollection collection)
		{
			string url = this.Request.UrlReferrer.AbsoluteUri;
			
			if (collection["cancel"] == "cancel")
			{
				return Redirect(url);
			}
			
			int? id = Convert.ToInt32(collection["StatusId"]);
			Status currentStatus = statusService.getStatusByID(id);
			Status editedStatus = new Status();
			editedStatus.ID = currentStatus.ID;
			editedStatus.Date = currentStatus.Date;
			editedStatus.Post = null;
			editedStatus.MediaURL = null;

			string statusTextboxId = "statusTextbox" + Convert.ToString(id);
			string picTextboxId = "picTextbox" + Convert.ToString(id);

			if (currentStatus.Post != null)
			{
				editedStatus.Post = collection[statusTextboxId];
			}
			if (currentStatus.MediaURL != null)
			{
				editedStatus.MediaURL = collection[picTextboxId];
			}
				
			statusService.editStatus(editedStatus);
			return Redirect(url);
			
		}

		public ActionResult RemoveStatus(int? id)
		{
			if (id != null)
			{
				Status currentStatus = statusService.getStatusByID(id);
				statusService.removeStatus(currentStatus);

				string url = this.Request.UrlReferrer.AbsolutePath;
				return Redirect(url);
			}
			else
			{
				return View("Error");
			}
		}

		[HttpPost]
		public ActionResult CreateComment(FormCollection collection)
		{
            Comment c = new Comment();
            c.Body = collection["commentText"];
            c.DateInserted = DateTime.Now;
            c.UserID = User.Identity.GetUserId();
            c.UserName = User.Identity.Name;
			var i = collection["statusID"];
			c.StatusID = Convert.ToInt32(collection["statusID"]);
			c.CurrentLogedinUser = User.Identity.GetUserId();

			var status = statusService.getStatusByID(c.StatusID);
			c.StatusUserID = status.UserID;
            statusService.addComment(c);
			
            //var currStatus = statusService.getStatusByID(c.StatusID);
            //var currComments = statusService.getCommentsByStatus(currStatus);
			
            //return Json(currComments, JsonRequestBehavior.AllowGet);
			string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
		}

		public ActionResult EditComment(FormCollection collection)
		{
			int? id = Convert.ToInt32(collection["commentId"]);
			Comment currentComment = statusService.getCommentByID(id);
			Comment editComment = new Comment();
			editComment.ID = currentComment.ID;
			editComment.DateInserted = currentComment.DateInserted;
			editComment.Body = null;
			editComment.StatusUserID = currentComment.StatusUserID;
			editComment.CurrentLogedinUser = User.Identity.GetUserId();
			
			string commentTextboxId = "commentTextbox" + Convert.ToString(id);

			if (currentComment.Body != null)
			{
				editComment.Body = collection[commentTextboxId];
			}

			statusService.editComment(editComment);

			string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
		}

		public ActionResult RemoveComment(int? id)
		{
			if (id != null)
			{
				Comment currentComment = statusService.getCommentByID(id);
				statusService.removeComment(currentComment);

				string url = this.Request.UrlReferrer.AbsoluteUri;
				return Redirect(url);
			}
			else
			{
				return View("Error");
			}
		}

		public ActionResult UpvoteStatus(Status s)
		{
			statusService.upvoteStatus(s);
			ApplicationUser currentUser = accountService.getUserByID(s.UserID);
			accountService.userGainsKarma(currentUser);
			
			string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
		}

		public ActionResult DownvoteStatus(Status s)
		{
			statusService.downvoteStatus(s);
			ApplicationUser currentUser = accountService.getUserByID(s.UserID);
			accountService.userLosesKarma(currentUser);

			string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
		}
	}
}