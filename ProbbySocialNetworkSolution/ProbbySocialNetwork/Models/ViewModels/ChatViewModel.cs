using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models.ViewModels
{
    public class ChatViewModel
    {
        public ApplicationUser currentUser;
        public ApplicationUser otherUser;
        public Chat chat;
        public List<Message> messages;
    }
}