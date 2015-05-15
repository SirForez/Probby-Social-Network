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
            model.currentGroupAdmins = groupService.getAdminsByGroup(model.currentGroup);
			model.currentGroupMembers = groupService.getUsersByGroup(model.currentGroup);
            model.availableHobbies = hobbyService.getAllHobbies();
			model.currentGroupStatusHistory = statusService.getGroupStatusHistory(model.currentGroup);
			model.currentGroupHobbies = hobbyService.getHobbiesByGroup(model.currentGroup);

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

        [Authorize]
		[HttpPost]
        public ActionResult CreateGroup(FormCollection collection)
        {
			Group g = new Group();
			ApplicationUser currentUser = accountService.getUserByName(User.Identity.Name);
			List<Hobby> currentUserHobbies = hobbyService.getHobbiesByUser(currentUser);

			g.Name = collection["groupName"];
			g.Description = collection["groupDesc"];

			groupService.addGroup(g);

			foreach (Hobby h in currentUserHobbies)
			{
				if (collection[h.Name] == h.Name)
				{
					hobbyService.addHobbyGroupConnection(h, g);
				}
			}

            groupService.addAdminToGroup(g, currentUser);

			string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
        }

        [Authorize]
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

        [Authorize]
        public ActionResult EditGroup(FormCollection collection)
        {
            int groupID = Int32.Parse(collection["groupID"]);
            Group g = groupService.getGroupByID(groupID);

            g.Name = collection["groupName"];
            g.Description = collection["groupDesc"];
            g.Hobby = hobbyService.getHobbyByName(collection["groupHobby"]);

            groupService.editGroup(g);

            string url = this.Request.UrlReferrer.AbsoluteUri;
            return Redirect(url);
        }

        [Authorize]
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

        [Authorize]
        public ActionResult DeleteGroup(int? id)
        {
            if (id.HasValue)
            {
                int realid = id.Value;
                Group g = groupService.getGroupByID(realid);
                groupService.removeGroup(g);

                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                return View("Error");
            }
        }

        [Authorize]
        public ActionResult AssignAdmin(FormCollection collection)
        {
            int groupID = Int32.Parse(collection["groupID"]);
            Group g = groupService.getGroupByID(groupID);
            ApplicationUser a = accountService.getUserByName(collection["userName"]);
            
            groupService.removeUserFromGroup(g, a);
            groupService.addAdminToGroup(g, a);

            string url = this.Request.UrlReferrer.AbsoluteUri;
			return Redirect(url);
        }

        [Authorize]
        public ActionResult RemoveAdmin(FormCollection collection)
        {
            int groupID = Int32.Parse(collection["groupID"]);
            Group g = groupService.getGroupByID(groupID);
            ApplicationUser a = accountService.getUserByName(collection["userName"]);

            groupService.removeAdminFromGroup(g, a);
            groupService.addUserToGroup(g, a);

            string url = this.Request.UrlReferrer.AbsoluteUri;
            return Redirect(url);
        }

        [Authorize]
        public ActionResult RemoveUser(FormCollection collection)
        {
            int groupID = Int32.Parse(collection["groupID"]);
            Group g = groupService.getGroupByID(groupID);
            ApplicationUser a = accountService.getUserByName(collection["userName"]);

            groupService.removeUserFromGroup(g, a);

            string url = this.Request.UrlReferrer.AbsoluteUri;
            return Redirect(url);
        }
    }
}