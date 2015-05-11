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
			var user = (from u in db.Users
                        where u.UserName == name
                        select u).SingleOrDefault();
            return user;
        }

        public List<ApplicationUser> getFollowersByUser(ApplicationUser a)
        {
            var followers = (from c in db.UserFollowConnections
                             where c.FollowingID == a.Id
                             join u in db.Users on c.FollowerID equals u.Id
                             select u).ToList();
            return followers;
        }

        public bool addFollowerToUser(ApplicationUser a, ApplicationUser toAdd)
        {
            UserFollowConnection uConnection = new UserFollowConnection();
            uConnection.FollowingID = a.Id;
            uConnection.FollowerID = toAdd.Id;
            db.UserFollowConnections.Add(uConnection);
            return db.SaveChanges() != 1;
        }

        public bool removeFollowerFromUser(ApplicationUser a, ApplicationUser toDel)
        {
            UserFollowConnection uConnection = new UserFollowConnection();
            uConnection.FollowingID = a.Id;
            uConnection.FollowerID = toDel.Id;
            db.UserFollowConnections.Remove(uConnection);
            return db.SaveChanges() != 1;
        }

        public List<ApplicationUser> getFollowingByUser(ApplicationUser a)
        {
            var following = (from c in db.UserFollowConnections
                             where c.FollowerID == a.Id
                             join u in db.Users on c.FollowingID equals u.Id
                             select u).ToList();
            return following;
        }

        public bool addFollowingToUser(ApplicationUser a, ApplicationUser toAdd)
        {
            UserFollowConnection uConnection = new UserFollowConnection();
            uConnection.FollowerID = a.Id;
            uConnection.FollowingID = toAdd.Id;
            db.UserFollowConnections.Add(uConnection);
            return db.SaveChanges() != 1;
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
            db.UserFollowConnections.Remove(uConnection);
            return db.SaveChanges() != 1;
        }

        public List<ApplicationUser> userSearch(String searchString)
        {
            var users = (from u in db.Users
                         where u.UserName.Contains(searchString)
                         select u).ToList();
            return users;
        }

		public void editProfilePicture(ApplicationUser a, string link)
		{
			a.ProfilePic = link;
			
			db.SaveChanges();
		}
    }
}