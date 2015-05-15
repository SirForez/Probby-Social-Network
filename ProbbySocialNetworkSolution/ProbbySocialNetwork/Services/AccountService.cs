using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class AccountService
    {
        ApplicationDbContext db = null;

        public AccountService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public ApplicationUser getUserByID(string ID)
        {
            var user = (from u in db.Users
                        where u.Id == ID
                        select u).SingleOrDefault();
            return user;
        }

        public ApplicationUser getUserByName(String name)
        {	
			if (name == null)
			{ 
				return null;
			}
			
			var user = (from u in db.Users
                        where u.UserName == name
                        select u).SingleOrDefault();
            return user;
        }

        public bool changeEmail(string userID, string oldEmail, string newEmail)
        {
            ApplicationUser a = getUserByID(userID);
            if (a != null)
            {
                a.Email = newEmail;
                return db.SaveChanges() != 0;
            }
            return false;
        }

        public List<ApplicationUser> getFollowersByUser(ApplicationUser a)
        {
            var followers = (from c in db.UserFollowConnections
                             where c.FollowingID == a.Id
                             join u in db.Users on c.FollowerID equals u.Id
                             select u).ToList();
            return followers;
        }

		public List<ApplicationUser> getFollowingByUser(ApplicationUser a)
		{
			var following = (from c in db.UserFollowConnections
							 where c.FollowerID == a.Id
							 join u in db.Users on c.FollowingID equals u.Id
							 select u).ToList();
			return following;
		}

        public bool addFollowerToUser(ApplicationUser a, ApplicationUser toAdd)
        {
            UserFollowConnection uConnection = new UserFollowConnection();
            a.NumberOfFollowers++;
            uConnection.FollowingID = a.Id;
            uConnection.FollowerID = toAdd.Id;
            db.UserFollowConnections.Add(uConnection);
            return db.SaveChanges() != 0;
        }

        public bool removeFollowerFromUser(ApplicationUser a, ApplicationUser toDel)
        {
            UserFollowConnection uConnection = new UserFollowConnection();
            uConnection.FollowingID = a.Id;
            a.NumberOfFollowers--;
            uConnection.FollowerID = toDel.Id;
            db.UserFollowConnections.Remove(uConnection);
            return db.SaveChanges() != 0;
        }

        public bool addFollowingToUser(ApplicationUser a, ApplicationUser toAdd)
        {
            UserFollowConnection uConnection = new UserFollowConnection();
            uConnection.FollowerID = a.Id;
            a.NumberOfFollowing++;
            uConnection.FollowingID = toAdd.Id;
            db.UserFollowConnections.Add(uConnection);
            return db.SaveChanges() != 0;
        }

        public UserFollowConnection getUserFollowConnectionByUsers(ApplicationUser follower, ApplicationUser following)
        {
            var connection = (from uConnection in db.UserFollowConnections
                               where (uConnection.FollowerID == follower.Id) && (uConnection.FollowingID == following.Id)
                               select uConnection).SingleOrDefault();
            return connection;
        }

        public bool removeFollowingFromUser(ApplicationUser a, ApplicationUser toDel)
        {
            UserFollowConnection uConnection = getUserFollowConnectionByUsers(a, toDel);
            a.NumberOfFollowing--;
            db.UserFollowConnections.Remove(uConnection);
            return db.SaveChanges() != 0;
        }

        public List<ApplicationUser> userSearch(String searchString)
        {
            var users = (from u in db.Users
                         where u.UserName.Contains(searchString)
                         select u).ToList();
            return users;
        }

		public bool editProfilePicture(ApplicationUser a, string link)
		{
			a.ProfilePic = link;
			
			return db.SaveChanges() != 0;
		}

		public bool userGainsKarma(ApplicationUser a)
		{
			a.Karma++;

			return db.SaveChanges() != 1;
		}

		public bool userLosesKarma(ApplicationUser a)
		{
			a.Karma--;

			return db.SaveChanges() != 1;
		}
    }
}