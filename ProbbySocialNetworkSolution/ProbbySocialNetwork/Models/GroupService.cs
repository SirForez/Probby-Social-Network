using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class GroupService
    {
        //TODO: Implement buisness logic to all functions if necessary.

        public bool addGroup(Group g)
        {
            return repo.addGroup(g);
        }

        public bool editGroup(Group edited)
        {
            return repo.editGroup(edited);
        }

        public bool removeGroup(Group g)
        {
            return repo.removeGroup(g);
        }

        public List<Group> groupSearch(String searchString)
        {
            return repo.groupSearch(searchString);
        }

        public List<Group> tagGroupSearch(String tag)
        {
            return repo.tagGroupSearch(tag);
        }

        public List<Group> getGroupsByUser(ApplicationUser a)
        {
            return repo.getGroupsByUser(a);
        }

        public List<ApplicationUser> getUsersByGroup(Group g)
        {
            return repo.getUsersByGroup(g);
        }

        private GroupRepository repo;
    }
}