using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class StatusService
    {
        ApplicationDbContext db = null;

        public StatusService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public List<Status> getStatusByUser(ApplicationUser a)
        {
            var statuses = (from s in db.Statuses
                            where a.Id == s.UserID
                            select s).ToList();
            return statuses;
        }

        public List<Comment> getCommentsByUser(ApplicationUser a)
        {
            var comments = (from c in db.Comments
                            where a.Id == c.UserID
                            select c).ToList();
            return comments;
        }

        public List<Comment> getCommentsByStatus(Status s)
        {
            var comments = (from c in db.Comments
                            where c.StatusID == s.ID
                            select c).ToList();
            return comments;
        }

        public List<Status> getGroupStatusHistory(Group g)
        {
            var statuses = (from s in db.Statuses
                            where s.GroupID == g.ID
                            select s).ToList();
            return statuses;
        }

        public Status getStatusByID(int id)
        {
            var status = (from s in db.Statuses
                          where s.ID == id
                          select s).SingleOrDefault();
            return status;
        }

        public bool addStatus(Status s)
        {
            db.Statuses.Add(s);
            return db.SaveChanges() != 0;
        }

        public bool editStatus(Status edited)
        {
            Status s = getStatusByID(edited.ID);
            if (s != null)
            {
                s.Date = edited.Date;
                //s.HobbyTags = edited.HobbyTags;
                s.Post = edited.Post;
                s.MediaURL = edited.MediaURL;
                return db.SaveChanges() != 0;
            }
            return false;
        }

        public bool addComment(Comment toAdd)
        {
            db.Comments.Add(toAdd);
            return db.SaveChanges() != 0;
        }

        public bool removeStatus(Status toDel)
        {
            db.Statuses.Remove(toDel);
            return db.SaveChanges() != 0;
        }

        public bool removeComment(Comment toDel)
        {
            db.Comments.Remove(toDel);
            return db.SaveChanges() != 0;
        }

        //NOTE: Should this not be in the hobby service? Think about moving it there.
        public Hobby getHobbyFromTag(String tag)
        {
            var hobby = (from h in db.Hobbies
                         where h.Name == tag
                         select h).SingleOrDefault();
            return hobby;
        }

        public List<Status> tagStatusSearch(String tag)
        {
            var hobby = getHobbyFromTag(tag);
           /* var statuses = (from s in db.Statuses
                            where s.HobbyTags.Contains(hobby)
                            select s).ToList();*/
            return new List<Status>();
        }

        public Comment getCommentByID(int id)
        {
            var comment = (from c in db.Comments
                           where c.ID == id
                           select c).SingleOrDefault();
            return comment;
        }

        public bool editComment(Comment edited)
        {
            Comment c = getCommentByID(edited.ID);
            if (c != null)
            {
                c.Body = edited.Body;
                c.DateInserted = edited.DateInserted;
                return db.SaveChanges() != 0;
            }
            return false;
        }
    }
}