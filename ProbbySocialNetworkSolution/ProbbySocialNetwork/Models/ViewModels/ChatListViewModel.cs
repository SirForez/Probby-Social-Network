using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models.ViewModels
{
    public class ChatListViewModel
    {
        public ApplicationUser currentUser;
        public List<ApplicationUser> availableChatUsers;
        public List<ApplicationUser> usersChattingWith;
        public List<Chat> userChats;
    }
}