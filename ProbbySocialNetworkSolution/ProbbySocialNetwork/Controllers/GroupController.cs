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

        // GET: Group
		[Authorize]
        public ActionResult Index(int id)
        {	
			GroupViewModel model = new GroupViewModel();
			model.currentUser = accountService.getUserByName(User.Identity.Name);
			model.currentGroup = groupService.getGroupByID(id);
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

        public ActionResult CreateGroup()
        {
            //TODO: Implement
            return View();
        }

        public ActionResult EditGroup()
        {
            //TODO: Implement
            return View();
        }

        public ActionResult RemoveGroup()
        {
            //TODO: Implement
            return View();
        }

        public ActionResult Search()
        {
            //TODO: Implement
            return View();
        }
    }
}