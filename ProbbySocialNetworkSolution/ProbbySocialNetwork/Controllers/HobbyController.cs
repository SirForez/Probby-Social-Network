using ProbbySocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProbbySocialNetwork.Models;
using ProbbySocialNetwork.Models.ViewModels;

namespace ProbbySocialNetwork.Controllers
{
    public class HobbyController : Controller
    {
		public ServiceSingleton serviceManager = ServiceSingleton.GetInstance;
		public AccountService accountService = ServiceSingleton.GetAccountService;
		public StatusService statusService = ServiceSingleton.GetStatusService;
		public GroupService groupService = ServiceSingleton.GetGroupService;
		public HobbyService hobbyService = ServiceSingleton.GetHobbyService;
		
		// GET: Hobby
        public ActionResult Index(int id)
        {
            HobbyViewModel model = new HobbyViewModel();

			model.currentUser = accountService.getUserByName(User.Identity.Name);
			model.currentHobby = hobbyService.getHobbyByID(id);
			model.currentHobbyGroups = hobbyService.getGroupsByHobby(model.currentHobby);
			model.currentHobbyStatusHistory = statusService.getStatusesByHobby(model.currentHobby);
			model.currentHobbyUsers = hobbyService.getUsersByHobby(model.currentHobby);

            return View(model);
        }

        public ActionResult CreateHobby(FormCollection collection)
        {
            Hobby h = new Hobby();
			h.Name = collection["hobbyName"];

			ApplicationUser currentUser = accountService.getUserByName(User.Identity.Name);

			hobbyService.addHobby(h);
			hobbyService.addHobbyToUser(currentUser, h);

			string url = this.Request.UrlReferrer.AbsolutePath;
			return Redirect(url);
        }

        public ActionResult RemoveHobby()
        {
            //TODO: Implement
            return View();
        }


        public ActionResult ViewHobby()
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