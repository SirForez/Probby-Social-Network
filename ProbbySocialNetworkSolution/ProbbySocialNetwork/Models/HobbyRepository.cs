using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class HobbyRepository
    {
        public List<Hobby> getHobbiesByUser(ApplicationUser a)
        {
            //TODO: Implement
            return new List<Hobby>();
        }

        public List<Hobby> getSubHobbiesByHobby(Hobby h)
        {
            //TODO: Implement
            return new List<Hobby>();
        }

        public List<ApplicationUser> getUsersByHobby(Hobby h)
        {
            //TODO: Implement
            return new List<ApplicationUser>();
        }

        public List<Group> getGroupsByHobby(Hobby h)
        {
            //TODO: Implement
            return new List<Group>();
        }

        public bool addHobby(Hobby h)
        {
            //TODO: Implement
            return false;
        }

        public bool removeHobby(Hobby h)
        {
            //TODO: Implement
            return false;
        }

        public List<Hobby> prefixHobbySearch(String hobbyPrefix)
        {
            //TODO: Implement
            return new List<Hobby>();
        }

        public List<Hobby> tagHobbySearch(String tag)
        {
            //TODO: Implement
            return new List<Hobby>();
        }
    }
}