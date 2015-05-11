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
			Status s = new Status();

			if (collection["imageOrText"] == "image")
			{
				s.MediaURL = collection["statusText"];
				s.Post = null;
			}
			else
			{
				s.Post = collection["statusText"];
				s.MediaURL = null;
			}

			if (groupID != null)
			{
				s.GroupID = groupID;
			}

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

			string url = this.Request.UrlReferrer.AbsolutePath;
			return Redirect(url);
		}

		public ActionResult EditStatus(int? id, FormCollection collection)
		{
			if (id != null)
			{
				Status currentStatus = statusService.getStatusByID(id);
				Status editedStatus = new Status();
				editedStatus.ID = currentStatus.ID;
				editedStatus.Date = DateTime.Now;

				if (currentStatus.Post == null)
				{
					editedStatus.MediaURL = collection["editTextbox"];
					editedStatus.Post = null;
				}
				else
				{
					editedStatus.Post = collection["editTextbox"];
					editedStatus.MediaURL = null;
				}
				statusService.editStatus(editedStatus);

				string url = this.Request.UrlReferrer.AbsolutePath;
				return Redirect(url);
			}
			else
			{
				return View("Error");
			}
			
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

		public ActionResult Search()
		{
			//TODO: Implement
			return View();
		}

		[HttpPost]
		public ActionResult CreateComment(FormCollection collection)
		{
			Comment c = new Comment();
			c.Body = collection["commentText"];
			c.DateInserted = DateTime.Now;
			c.UserID = User.Identity.GetUserId();
            c.UserName = User.Identity.Name;
			c.StatusID = Convert.ToInt32(collection["statusID"]);
			statusService.addComment(c);

			//temp fix until we can find better solution
			string url = this.Request.UrlReferrer.AbsolutePath;
			return Redirect(url);
		}

		public ActionResult EditComment()
		{
			//TODO: Implement
			return View();
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
	}
}