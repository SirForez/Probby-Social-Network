using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class StatusService
    {
        //TODO: Implement buisness logic to all functions if necessary.

        public List<Status> getStatusByUser(ApplicationUser a)
        {
            return repo.getStatusByUser(a);
        }

        public List<Comment> getCommentsByUser(ApplicationUser a)
        {
            return repo.getCommentsByUser(a);
        }

        public List<Comment> getCommentsByStatus(ApplicationUser a)
        {
            return repo.getCommentsByStatus(a);
        }

        public List<Status> getGroupStatusHistory(Group g)
        {
            return repo.getGroupStatusHistory(g);
        }

        public bool addStatus(Status s)
        {
            return repo.addStatus(s);
        }

        public bool editStatus(Status s, Status edited)
        {
            return repo.editStatus(s, edited);
        }

        public bool addCommentToStatus(Status s, Comment toAdd)
        {
            return repo.addCommentToStatus(s, toAdd);
        }

        public bool removeStatus(Status toDel)
        {
            return repo.removeStatus(toDel);
        }

        public bool removeCommentFromStatus(Status s, Comment toDel)
        {
            return repo.removeCommentFromStatus(s, toDel);
        }

        public bool editComment(Comment c, Comment edited)
        {
            return repo.editComment(c, edited);
        }

        public List<Status> searchByTag(String tag)
        {
            return repo.searchByTag(tag);
        }

        private StatusRepository repo;
    }
}