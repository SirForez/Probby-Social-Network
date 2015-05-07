using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class StatusRepository
    {
        public List<Status> getStatusByUser(ApplicationUser a)
        {
            //TODO: Implement
            return new List<Status>();
        }

        public List<Comment> getCommentsByUser(ApplicationUser a)
        {
            //TODO: Implement
            return new List<Comment>();
        }

        public List<Comment> getCommentsByStatus(ApplicationUser a)
        {
            //TODO: Implement
            return new List<Comment>();
        }

        public List<Status> getGroupStatusHistory(Group g)
        {
            //TODO: Implement
            return new List<Status>();
        }

        public bool addStatus(Status s)
        {
            //TODO: Implement
            return false;
        }

        public bool editStatus(Status s, Status edited)
        {
            //TODO: Implement
            return false;
        }

        public bool addCommentToStatus(Status s, Comment toAdd)
        {
            //TODO: Implement
            return false;
        }

        public bool removeStatus(Status toDel)
        {
            //TODO: Implement
            return false;
        }

        public bool removeCommentFromStatus(Status s, Comment toDel)
        {
            //TODO: Implement
            return false;
        }

        public bool editComment(Comment c, Comment edited)
        {
            //TODO: Implement
            return false;
        }

        public List<Status> searchByTag(String tag)
        {
            //TODO: Implement
            return new List<Status>();
        }
    }
}