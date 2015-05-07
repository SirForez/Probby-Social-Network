using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class HobbyService
    {
        //TODO: Implement buisness logic to all functions if necessary.

        public List<Hobby> getHobbiesByUser(ApplicationUser a)
        {
            return repo.getHobbiesByUser(a);
        }

        public List<Hobby> getSubHobbiesByHobby(Hobby h)
        {
            return repo.getSubHobbiesByHobby(h);
        }

        public List<ApplicationUser> getUsersByHobby(Hobby h)
        {
            return repo.getUsersByHobby(h);
        }

        public List<Group> getGroupsByHobby(Hobby h)
        {
            return repo.getGroupsByHobby(h);
        }

        public bool addHobby(Hobby h)
        {
            return repo.addHobby(h);
        }

        public bool removeHobby(Hobby h)
        {
            return repo.removeHobby(h);
        }

        public List<Hobby> prefixHobbySearch(String hobbyPrefix)
        {
            return repo.prefixHobbySearch(hobbyPrefix);
        }

        public List<Hobby> tagHobbySearch(String tag)
        {
            return repo.tagHobbySearch(tag);
        }

        private HobbyRepository repo;
    }
}