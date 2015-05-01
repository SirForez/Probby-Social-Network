using ProbbySocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProbbySocialNetwork.Controllers
{
    public class PostController : Controller
    {
        public List<Post> reportedPosts;
        public List<Account> reportedAccounts;

        public ActionResult viewStatus()
        {
            //TODO: implement
            return View();
        }

        public ActionResult getPostsByAccount(Account a)
        {
            //TODO: implement
            return View();
        }

        // GET: Post
        public ActionResult Index()
        {
            //TODO: implement
            return View();
        }
    }
}