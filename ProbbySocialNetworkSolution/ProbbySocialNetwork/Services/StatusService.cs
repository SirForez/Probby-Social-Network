﻿using ProbbySocialNetwork.Connections;
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

        public List<Status> getStatusesByUserID(string id)
        {
			if (id == null)
			{
				return null;
			}
			
			var statuses = (from s in db.Statuses
                            where s.UserID == id && s.GroupID == null
                            select s).ToList();
            return statuses;
        }

        public List<Status> getStatusFeedByUser(ApplicationUser a)
        {
			if (a == null)
			{
				return null;
			}
			
			var statuses = getStatusesByUser(a);

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
            statuses.Sort((x, y) => y.Date.CompareTo(x.Date));
			List<Status> statusesWithoutDuplicates = statuses.Distinct().ToList();
            return statusesWithoutDuplicates;
        }

        public List<Status> getStatusesByUser(ApplicationUser a)
        {
			if (a == null)
			{
				return null;
			}
			
			var statuses = (from s in db.Statuses
                            where (((a.Id == s.UserID) && (s.GroupID == null)) || (a.Id == s.PostedToID))
                            orderby s.Date descending
                            select s).ToList();

            return statuses;
        }

		public List<Status> getStatusesByUserForEditProfilePic(ApplicationUser a)
		{
			if (a == null)
			{
				return null;
			}

			var statuses = (from s in db.Statuses
							where ((a.Id == s.UserID) && (s.GroupID == null))
							orderby s.Date descending
							select s).ToList();

			return statuses;
		}

		public List<Status> getStatusesByHobby(Hobby h)
		{
			var statuses = (from c in db.StatusHobbyConnections
						   where c.HobbyID == h.ID
						   join s in db.Statuses on c.StatusID equals s.ID
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
            return db.SaveChanges() != 0;
        }

        public bool removeHobbyFromStatus(Status s, Hobby toDel)
        {
            StatusHobbyConnection sConnection = new StatusHobbyConnection();
            sConnection.StatusID = s.ID;
            sConnection.HobbyID = toDel.ID;
            db.StatusHobbyConnections.Remove(sConnection);
            return db.SaveChanges() != 0;
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
            return db.SaveChanges() != 0;
        }

        public bool editStatus(Status edited)
        {
            Status s = getStatusByID(edited.ID);
            if (s != null)
            {
                s.Date = edited.Date;
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
                return db.SaveChanges() != 0;
            }
            return false;
        }

		public bool editStatusProfilePicture(Status s, string link)
		{
			s.ProfilePic = link;

			return db.SaveChanges() != 0;
		}

		public bool upvoteStatus(Status s)
		{
			s.Karma++;

			return db.SaveChanges() != 0;
		}

		public bool downvoteStatus(Status s)
		{
			s.Karma--;

			return db.SaveChanges() != 0;
		}

		public List<Status> getSavedFeedByUser(ApplicationUser a)
		{
			var statuses = (from c in db.UserSavedStatusConnections
							where c.UserID == a.Id
							join s in db.Statuses on c.StatusID equals s.ID
							orderby s.Date descending
							select s).ToList();
			return statuses;
		}

		public bool savedConnectionExists(UserSavedStatusConnection testCase)
		{
			var connection = (from c in db.UserSavedStatusConnections
							  where (c.UserID == testCase.UserID && c.StatusID == testCase.StatusID)
							  select c).SingleOrDefault();
			if (connection == null)
			{
				return false;
			}

			return true;
		}

		public void addSavedStatus(Status s, ApplicationUser a)
		{
			UserSavedStatusConnection connection = new UserSavedStatusConnection();

			connection.StatusID = s.ID;
			connection.UserID = a.Id;

			if (savedConnectionExists(connection))
			{
				return;
			}
			
			db.UserSavedStatusConnections.Add(connection);
			db.SaveChanges();
		}

		public UserSavedStatusConnection getUserSavedConnectionByStatusAndUser(Status s, ApplicationUser a)
		{
			var connection = (from c in db.UserSavedStatusConnections
							 where (c.StatusID == s.ID) && (c.UserID == a.Id)
							 select c).SingleOrDefault();
			return connection;
		}

		public void removeSavedStatus(Status s, ApplicationUser a)
		{
			UserSavedStatusConnection connection = getUserSavedConnectionByStatusAndUser(s, a);

			db.UserSavedStatusConnections.Remove(connection);
			db.SaveChanges();
		}
	}
}