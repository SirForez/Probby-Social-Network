using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class GroupRepository
    {
        public bool addGroup(Group g)
        {
            //TODO: Implement
            return false;
        }

        public bool editGroup(Group g, Group edited)
        {
            //TODO: Implement
            return false;
        }

        public bool removeGroup(Group g)
        {
            //TODO: Implement
            return false;
        }

        public List<Group> prefixGroupSearch(String groupPrefix)
        {
            //TODO: Implement
            return new List<Group>();
        }

        public List<Group> tagGroupSearch(String tag)
        {
            //TODO: Implement
            return new List<Group>();
        }

        public List<Group> getGroupsByUser(ApplicationUser a)
        {
            //TODO: Implement
            return new List<Group>();
        }

        public List<ApplicationUser> getUsersByGroup(Group g)
        {
            //TODO: Implement
            return new List<ApplicationUser>();
        }
    }
}