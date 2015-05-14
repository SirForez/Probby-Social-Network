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

        public Chat getChatByID(int id)
        {
            var chat = (from c in db.Chats
                        where c.ID == id
                        select c).SingleOrDefault();
            return chat;
        }

        public List<Chat> GetChatsByUser(ApplicationUser a)
        {
            var chats = (from c in db.UserChatConnections
                         where a.Id == c.UserID
                         join i in db.Chats on c.ChatID equals i.ID
                         select i).ToList();
            return chats;
        }

        public Chat getChatByUsers(ApplicationUser a, ApplicationUser b)
        {
            var chat = (from c in db.UserChatConnections
                        where a.Id == c.UserID
                        join c2 in db.UserChatConnections on c.ChatID equals c2.ChatID
                        where b.Id == c2.UserID
                        join ch in db.Chats on c.ChatID equals ch.ID
                        select ch).SingleOrDefault();
            return chat;
        }

        public List<Message> GetMessagesByChat(Chat chat)
        {
            var messages = (from c in db.ChatMessageConnections
                            where c.ChatID == chat.ID
                            join m in db.Messages on c.MessageID equals m.ID
                            orderby m.DateInserted descending
                            select m).ToList();
            return messages;
        }

        public UserChatConnection getUserChatConnection(Chat chat, ApplicationUser a)
        {
            var uConnection = (from c in db.UserChatConnections
                               where c.ChatID == chat.ID && c.UserID == a.Id
                               select c).SingleOrDefault();
            return uConnection;
        }

        public ChatMessageConnection getChatMessageConnection(Chat chat, Message m)
        {
            var cConnection = (from c in db.ChatMessageConnections
                               where c.ChatID == chat.ID && c.MessageID == m.ID
                               select c).SingleOrDefault();
            return cConnection;
        }

        public List<ApplicationUser> getUsersChattingWithByUser(ApplicationUser a)
        {
            var users = (from u in db.Users
                         where u.Id == a.Id
                         join c in db.UserChatConnections on u.Id equals c.UserID
                         join c2 in db.UserChatConnections on c.ChatID equals c2.ChatID
                         where c2.UserID != a.Id
                         join u2 in db.Users on c2.UserID equals u2.Id
                         select u2).ToList();
            return users;
        }

        public bool AddUserChatConnection(UserChatConnection uc)
        {
            db.UserChatConnections.Add(uc);
            return db.SaveChanges() != 1;
        }

        public bool AddUserToChat(Chat c, ApplicationUser toAdd)
        {
            UserChatConnection uc = new UserChatConnection();
            uc.ChatID = c.ID;
            uc.UserID = toAdd.Id;
            db.UserChatConnections.Add(uc);
            return db.SaveChanges() != 1;
        }

        public bool AddMessageToChat(Chat c, Message toAdd)
        {
            ChatMessageConnection cm = new ChatMessageConnection();
            cm.ChatID = c.ID;
            cm.MessageID = toAdd.ID;
            db.ChatMessageConnections.Add(cm);
            return db.SaveChanges() != 1;
        }

        public bool AddChat(Chat c)
        {
            db.Chats.Add(c);
            return db.SaveChanges() != 1;
        }

        public bool RemoveChat(Chat c)
        {
            db.Chats.Remove(c);
            return db.SaveChanges() != 1;
        }

        public bool AddMessage(Message m)
        {
            db.Messages.Add(m);
            return db.SaveChanges() != 1;
        }

        public bool RemoveMessage(Message m)
        {
            db.Messages.Remove(m);
            return db.SaveChanges() != 1;
        }
    }
}