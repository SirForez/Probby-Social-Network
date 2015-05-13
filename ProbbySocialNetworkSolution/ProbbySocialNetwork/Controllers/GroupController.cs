using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProbbySocialNetwork.Models;
using ProbbySocialNetwork.Models.ViewModels;

namespace ProbbySocialNetwork.Controllers
{
    public class GroupController : Controller
    {
		public ServiceSingleton serviceManager = ServiceSingleton.GetInstance;
		public AccountService accountService = ServiceSingleton.GetAccountService;
		public StatusService statusService = ServiceSingleton.GetStatusService;
		public GroupService groupService = ServiceSingleton.GetGroupService;
        public HobbyService hobbyService = ServiceSingleton.GetHobbyService;

        // GET: Group
		[Authorize]
        public ActionResult Index(string id)
        {
			int ID = Int32.Parse(id);

            GroupViewModel model = new GroupViewModel();
            model.commentsForStatuses = new List<Comment>();
			model.currentUser = accountService.getUserByName(User.Identity.Name);
			model.currentGroup = groupService.getGroupByID(ID);
			model.currentGroupMembers = groupService.getUsersByGroup(model.currentGroup);
			model.currentGroupStatusHistory = statusService.getGroupStatusHistory(model.currentGroup);

			foreach (Status s in model.currentGroupStatusHistory)
			{
				List<Comment> currentCommentList = statusService.getCommentsByStatus(s);
				foreach (Comment c in currentCommentList)
				{
					model.commentsForStatuses.Add(c);
				}
			}

            return View(model);
        }

		[HttpPost]
        public ActionResult CreateGroup(FormCollection collection)
        {
			Group g = new Group();

			g.name = collection["groupName"];
			g.description = collection["groupDesc"];
            g.hobby = hobbyService.getHobbyByName(collection["groupHobby"]);

			groupService.addGroup(g);

			ApplicationUser currentUser = accountService.getUserByName(User.Identity.Name);

			groupService.addUserToGroup(g, currentUser);

			string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
        }

		public ActionResult JoinGroup(int? id)
		{
            if (id.HasValue)
            {
                int realid = id.Value;
                ApplicationUser currentUser = accountService.getUserByName(User.Identity.Name);
                Group g = groupService.getGroupByID(realid);
                groupService.addUserToGroup(g, currentUser);

				string url = this.Request.UrlReferrer.AbsoluteUri;
				return Redirect(url);
            }
            else
            {
                return View("Error");
            }
		}

        public ActionResult EditGroup()
        {
            //TODO: Implement
            return View();
        }

        public ActionResult LeaveGroup(int? id)
        {
            if (id.HasValue)
            {
                int realid = id.Value;
                ApplicationUser currentUser = accountService.getUserByName(User.Identity.Name);
                Group g = groupService.getGroupByID(realid);
                groupService.removeUserFromGroup(g, currentUser);

				string url = this.Request.UrlReferrer.AbsoluteUri;
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
    }
}