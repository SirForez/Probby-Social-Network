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

        public ActionResult AddHobby(int? id)
        {
            if (id.HasValue)
            {
                int realid = id.Value;
                Hobby toAdd = hobbyService.getHobbyByID(realid);
                ApplicationUser currentUser = accountService.getUserByName(User.Identity.Name);

                hobbyService.addHobbyToUser(currentUser, toAdd);

                string url = this.Request.UrlReferrer.AbsolutePath;
                return Redirect(url);
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult RemoveHobby(int? id)
        {
            if (id.HasValue)
            {
                int realid = id.Value;
                Hobby toDel = hobbyService.getHobbyByID(realid);
                ApplicationUser currentUser = accountService.getUserByName(User.Identity.Name);

                hobbyService.removeHobbyFromuser(currentUser, toDel);

                string url = this.Request.UrlReferrer.AbsolutePath;
                return Redirect(url);
            }
            else
            {
                return View("Error");
            }
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