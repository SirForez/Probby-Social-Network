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

        public ApplicationUser getUserByName(String name)
        {
            //TODO: Implement
            return new ApplicationUser();
        }

        public List<ApplicationUser> getFollowersByUser(ApplicationUser a)
        {
            //TODO: Implement
            return new List<ApplicationUser>();
        }

        public bool addFollowerToUser(ApplicationUser a, ApplicationUser toAdd)
        {
            //TODO: Implement
            return false;
        }

        public bool removeFollowerFromUser(ApplicationUser a, ApplicationUser toDel)
        {
            //TODO: Implement
            return false;
        }

        public List<ApplicationUser> getFollowingByUser(ApplicationUser a)
        {
            //TODO: Implement
            return new List<ApplicationUser>();
        }

        public bool addFollowingToUser(ApplicationUser a, ApplicationUser toAdd)
        {
            //TODO: Implement
            return false;
        }

        public bool removeFollowingFromUser(ApplicationUser a, ApplicationUser toDel)
        {
            //TODO: Implement
            return false;
        }

        public List<ApplicationUser> prefixAccountSearch(String namePrefix)
        {
            //TODO: Implement
            return new List<ApplicationUser>();
        }
    }
}