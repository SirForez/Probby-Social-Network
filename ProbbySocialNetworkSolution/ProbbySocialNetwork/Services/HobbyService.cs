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

        public Hobby getHobbyByID(int id)
		{
			var hobby = (from h in db.Hobbies
						 where h.ID == id
						 select h).SingleOrDefault();
			return hobby;
		}
		
		public List<Hobby> getHobbiesByUser(ApplicationUser a)
        {
			var hobbies = (from c in db.UserHobbyConnections
                           where c.UserID == a.Id
                           join h in db.Hobbies on c.HobbyID equals h.ID
                           select h).ToList();
            return hobbies;
        }

        public List<ApplicationUser> getUsersByHobby(Hobby h)
        {
            var users = (from c in db.UserHobbyConnections
                         where c.HobbyID == h.ID
                         join u in db.Users on c.UserID equals u.Id
                         select u).ToList();
            return users;
        }

        public List<Group> getGroupsByHobby(Hobby h)
        {
            var groups = (from g in db.Groups
                          where g.hobby.ID == h.ID
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

        public bool addHobbyToUser(ApplicationUser a, Hobby toAdd)
        {
            UserHobbyConnection hConnection = new UserHobbyConnection();
            hConnection.UserID = a.Id;
            hConnection.HobbyID = toAdd.ID;
            db.UserHobbyConnections.Add(hConnection);
            return db.SaveChanges() != 1;
        }

        public bool removeHobbyFromuser(ApplicationUser a, Hobby toDel)
        {
            UserHobbyConnection hConnection = new UserHobbyConnection();
            hConnection.UserID = a.Id;
            hConnection.HobbyID = toDel.ID;
            db.UserHobbyConnections.Remove(hConnection);
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