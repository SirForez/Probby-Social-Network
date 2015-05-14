using ProbbySocialNetwork.Connections;
using ProbbySocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Services
{
    public class ChatService
    {
        ApplicationDbContext db = null;

        public ChatService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public List<Chat> GetChatsByUser()
        {
            return new List<Chat>();
        }

        public List<Message> GetMessagesByChat()
        {
            return new List<Message>();
        }

        public UserChatConnection getUserChatConnection()
        {
            return new UserChatConnection();
        }

        public bool AddChat()
        {
            return false;
        }

        public bool RemoveChat()
        {
            return false;
        }
    }
}