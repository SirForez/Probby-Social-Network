using ProbbySocialNetwork.Models;
using ProbbySocialNetwork.Models.ViewModels;
using ProbbySocialNetwork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProbbySocialNetwork.Controllers
{
    public class ChatController : Controller
    {
        public ServiceSingleton serviceManager = ServiceSingleton.GetInstance;
        public AccountService accountService = ServiceSingleton.GetAccountService;
        public StatusService statusService = ServiceSingleton.GetStatusService;
        public GroupService groupService = ServiceSingleton.GetGroupService;
        public HobbyService hobbyService = ServiceSingleton.GetHobbyService;
        public ChatService chatService = ServiceSingleton.GetChatService;

        // GET: Chat
        public ActionResult Index(string username)
        {
            ChatViewModel model = new ChatViewModel();
            model.currentUser = accountService.getUserByName(User.Identity.Name);
            model.otherUser = accountService.getUserByName(username);

            model.chat = chatService.getChatByUsers(model.currentUser, model.otherUser);
            model.messages = chatService.GetMessagesByChat(model.chat);

            return View(model);
        }

        [HttpPost]
        public ActionResult PostMessage(FormCollection collection, int chatID)
        {
            Message m = new Message();
            m.UserID = collection["userid"];
            m.UserName = collection["username"];
            m.Text = collection["messageText"];
            m.DateInserted = DateTime.Now;
			
			Chat c = chatService.getChatByID(chatID);

            chatService.AddMessage(m);
            chatService.AddMessageToChat(c, m);

			var currMessages = chatService.GetMessagesByChat(c);

			return Json(currMessages, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateChat(string username)
        {
            Chat c = new Chat();
            chatService.AddChat(c);

            ApplicationUser currentUser = accountService.getUserByName(User.Identity.Name);
            ApplicationUser userChatWIth = accountService.getUserByName(username);
            chatService.AddUserToChat(c, currentUser);
            chatService.AddUserToChat(c, userChatWIth);

            string url = this.Request.UrlReferrer.AbsoluteUri;
            return Redirect(url);
        }
    }
}