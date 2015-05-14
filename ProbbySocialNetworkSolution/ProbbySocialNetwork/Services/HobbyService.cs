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

        public Hobby getDefaultHobby()
		{
			var hobby = (from h in db.Hobbies
						 where h.Name == "Misc"
						 select h).SingleOrDefault();
			return hobby; 
		}

        public List<Hobby> getAllHobbies()
        {
            var hobbies = (from h in db.Hobbies
                         select h).ToList();
            return hobbies;
        }
		
		public Hobby getHobbyByID(int id)
		{
			var hobby = (from h in db.Hobbies
						 where h.ID == id
						 select h).SingleOrDefault();
			return hobby;
		}

		public Hobby getHobbyByName(string name)
		{
			var hobby = (from h in db.Hobbies
						 where h.Name == name
						 select h).SingleOrDefault();
			return hobby;
		}
		
		public List<Hobby> getHobbiesByUser(ApplicationUser a)
        {
			if (a == null)
			{
				return null;
			}
			
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

		public bool addHobbyGroupConnection(Hobby h, Group g)
		{
			HobbyGroupConnection hConnection = new HobbyGroupConnection();
			hConnection.GroupID = g.ID;
			hConnection.HobbyID = h.ID;
			db.HobbyGroupConnections.Add(hConnection);

			return db.SaveChanges() != 1;
		}

        public List<Group> getGroupsByHobby(Hobby h)
        {
            var groups = (from c in db.HobbyGroupConnections
                          where h.ID == c.HobbyID
						  join g in db.Groups on c.GroupID equals g.ID
                          select g).ToList();
            return groups;
        }

		public List<Hobby> getHobbiesByGroup(Group g)
		{
			var hobbies = (from c in db.HobbyGroupConnections
						  where g.ID == c.GroupID
						  join h in db.Hobbies on c.HobbyID equals h.ID
						  select h).ToList();
			return hobbies;
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

        public UserHobbyConnection getUserHobbyConnection(ApplicationUser a, Hobby h)
        {
            var hConnection = (from c in db.UserHobbyConnections
                               where c.HobbyID == h.ID && c.UserID == a.Id
                               select c).SingleOrDefault();
            return hConnection;
        }

        public bool removeHobbyFromuser(ApplicationUser a, Hobby toDel)
        {
            UserHobbyConnection hConnection = getUserHobbyConnection(a, toDel);
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

		public List<Hobby> getHobbiesByStatus(Status s)
		{
			var hobbies = (from c in db.StatusHobbyConnections
						   where c.StatusID == s.ID
						   join h in db.Hobbies on c.HobbyID equals h.ID
						   select h).ToList();
			return hobbies;
		}
    }
}