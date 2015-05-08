using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class HobbyService
    {
        ApplicationDbContext db = null;

        public HobbyService(ApplicationDbContext _db)
        {
            db = _db;
        }

        //TODO: Cant implement yet to due not having access to ApplicationUser in db
        public List<Hobby> getHobbiesByUser(ApplicationUser a)
        {
            //TODO: Implement
            return new List<Hobby>();
        }

        //NOTE: Totally BAILED on subhobbies for the time being, to implement would be to add a ParentHobbyID to the Hobby identity class which is nullable
        /*public List<Hobby> getSubHobbiesByHobby(Hobby h)
        {
            //TODO: Implement
            return new List<Hobby>();
        }*/

        //TODO: Cant implement yet to due not having access to ApplicationUser in db
        public List<ApplicationUser> getUsersByHobby(Hobby h)
        {
            //TODO: Implement
            return new List<ApplicationUser>();
        }

        public List<Group> getGroupsByHobby(Hobby h)
        {
            var groups = (from g in db.Groups
                          where g.hobby == h
                          select g).ToList();
            return groups;
        }

        public bool addHobby(Hobby h)
        {
            db.Hobbies.Add(h);
            return db.SaveChanges() != 1;
        }

        public bool removeHobby(Hobby h)
        {
            db.Hobbies.Remove(h);
            return db.SaveChanges() != 1;
        }

        public List<Hobby> hobbySearch(String searchString)
        {
            var hobbies = (from h in db.Hobbies
                           where h.Name.Contains(searchString)
                           select h).ToList();
            return hobbies;
        }

        public List<Hobby> tagHobbySearch(String tag)
        {
            var hobbies = (from h in db.Hobbies
                           where h.Name == tag
                           select h).ToList();
            return hobbies;
        }
    }
}