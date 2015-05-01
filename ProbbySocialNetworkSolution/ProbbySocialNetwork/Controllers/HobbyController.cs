using ProbbySocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProbbySocialNetwork.Controllers
{
    public class HobbyController : Controller
    {

        public List<Hobby> hobbiesAwaitingApproval;

        public ActionResult addHobby()
        {
            //TODO: implement
            return View();
        }

        public ActionResult removeHobby()
        {
            //TODO: implement
            return View();
        }

        public ActionResult approveHobby()
        {
            //TODO: implement
            return View();
        }

        public ActionResult viewHobby()
        {
            //TODO: implement
            return View();
        }
        // GET: Hobby
        public ActionResult Index()
        {
            //TODO: implement
            return View();
        }
    }
}