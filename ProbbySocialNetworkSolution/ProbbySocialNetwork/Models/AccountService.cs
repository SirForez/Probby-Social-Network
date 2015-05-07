using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class AccountService
    {
        //TODO: Implement buisness logic to all functions if necessary.

        public ApplicationUser getUserByName(String name)
        {
            return repo.getUserByName(name);
        }

        public List<ApplicationUser> getFollowersByUser(ApplicationUser a)
        {
            return repo.getFollowersByUser(a);
        }

        public bool addFollowerToUser(ApplicationUser a, ApplicationUser toAdd)
        {
            return repo.addFollowerToUser(a, toAdd);
        }

        public bool removeFollowerFromUser(ApplicationUser a, ApplicationUser toDel)
        {
            return repo.removeFollowerFromUser(a, toDel);
        }

        public List<ApplicationUser> getFollowingByUser(ApplicationUser a)
        {
            return repo.getFollowingByUser(a);
        }

        public bool addFollowingToUser(ApplicationUser a, ApplicationUser toAdd)
        {
            return repo.addFollowingToUser(a, toAdd);
        }

        public bool removeFollowingFromUser(ApplicationUser a, ApplicationUser toDel)
        {
            return repo.removeFollowingFromUser(a, toDel);
        }

        public List<ApplicationUser> prefixAccountSearch(String namePrefix)
        {
            return repo.prefixAccountSearch(namePrefix);
        }

        private AccountRepository repo;
    }
}