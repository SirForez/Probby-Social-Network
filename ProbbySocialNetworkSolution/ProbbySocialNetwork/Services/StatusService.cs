using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class StatusComparer
    {

    }

    public class StatusService
    {
        ApplicationDbContext db = null;

        public StatusService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public List<Status> getStatusesByUserID(string id)
        {
			if (id == null)
			{
				return null;
			}
			
			var statuses = (from s in db.Statuses
                            where s.UserID == id
                            select s).ToList();
            return statuses;
        }

        public List<Status> getStatusFeedByUser(ApplicationUser a)
        {
			if (a == null)
			{
				return null;
			}
			
			var statuses = getStatusByUser(a);

            List<UserFollowConnection> userFollowingIDs = (from f in db.UserFollowConnections
                                             where f.FollowerID == a.Id
                                             select f).ToList();
            var statusesFromFollowing = new List<Status>();
            foreach (UserFollowConnection c in userFollowingIDs)
            {
                var statusesFromCurrentFollowing = getStatusesByUserID(c.FollowingID);
                foreach (Status s in statusesFromCurrentFollowing)
                {
                    statusesFromFollowing.Add(s);
                }
            }

            statuses.AddRange(statusesFromFollowing);
            statuses.Sort((x, y) => y.Date.CompareTo(x.Date)); //Needs to be in the oposite order
            return statuses;
        }

        public List<Status> getStatusByUser(ApplicationUser a)
        {
			if (a == null)
			{
				return null;
			}
			
			var statuses = (from s in db.Statuses
                            where ((a.Id == s.UserID) || (a.Id == s.PostedToID))
                            orderby s.Date descending
                            select s).ToList();

            //Use postedToID to get all statuses posted to the user, for this as well, somehow

            return statuses;
        }

		public List<Status> getStatusesByHobby(Hobby h)
		{
			var statuses = (from s in db.Statuses
							where h.ID == s.ID
							orderby s.Date descending
							select s).ToList();
			return statuses;
		}

        public List<Comment> getCommentsByUser(ApplicationUser a)
        {
            var comments = (from c in db.Comments
                            where a.Id == c.UserID
                            orderby c.DateInserted ascending
                            select c).ToList();
            return comments;
        }

        public List<Comment> getCommentsByStatus(Status s)
        {
            var comments = (from c in db.Comments
                            where c.StatusID == s.ID
                            orderby c.DateInserted ascending
                            select c).ToList();
            return comments;
        }

        public List<Hobby> getHobbiesByStatus(Status s)
        {
            var hobbies = (from c in db.StatusHobbyConnections
                           where c.StatusID == s.ID
                           join h in db.Hobbies on c.HobbyID equals h.ID
                           select h).ToList();
            return hobbies;
        }

        public bool addHobbyToStatus(Status s, Hobby toAdd)
        {
            StatusHobbyConnection sConnection = new StatusHobbyConnection();
            sConnection.StatusID = s.ID;
            sConnection.HobbyID = toAdd.ID;
            db.StatusHobbyConnections.Add(sConnection);
            return db.SaveChanges() != 1;
        }

        public bool removeHobbyFromStatus(Status s, Hobby toDel)
        {
            StatusHobbyConnection sConnection = new StatusHobbyConnection();
            sConnection.StatusID = s.ID;
            sConnection.HobbyID = toDel.ID;
            db.StatusHobbyConnections.Remove(sConnection);
            return db.SaveChanges() != 1;
        }

        public List<Status> getGroupStatusHistory(Group g)
        {
            var statuses = (from s in db.Statuses
                            where s.GroupID == g.ID
                            orderby s.Date descending
                            select s).ToList();
            return statuses;
        }

        public Status getStatusByID(int? id)
        {
            var status = (from s in db.Statuses
                          where s.ID == id
                          select s).SingleOrDefault();
            return status;
        }

        public bool addStatus(Status s)
        {
            db.Statuses.Add(s);
            return db.SaveChanges() != 1;
        }

        public bool editStatus(Status edited)
        {
            Status s = getStatusByID(edited.ID);
            if (s != null)
            {
                //NOTE: Do hobbies on statuses need ever to be edited?
                //If so: TODO: implement hobby status editing
                s.Date = edited.Date;
                s.Post = edited.Post;
                s.MediaURL = edited.MediaURL;
                return db.SaveChanges() != 1;
            }
            return false;
        }

        public bool addComment(Comment toAdd)
        {
            db.Comments.Add(toAdd);
            return db.SaveChanges() != 1;
        }

        public bool removeStatus(Status toDel)
        {
            db.Statuses.Remove(toDel);
            return db.SaveChanges() != 1;
        }

        public bool removeComment(Comment toDel)
        {
            db.Comments.Remove(toDel);
            return db.SaveChanges() != 1;
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
            var statuses = (from c in db.StatusHobbyConnections
                            where c.HobbyID == hobby.ID
                            join s in db.Statuses on c.StatusID equals s.ID
                            select s).ToList();
            return statuses;
        }

        public Comment getCommentByID(int? id)
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
                return db.SaveChanges() != 1;
            }
            return false;
        }

		public void editStatusProfilePicture(Status s, string link)
		{
			s.ProfilePic = link;

			db.SaveChanges();
		}
    }
}