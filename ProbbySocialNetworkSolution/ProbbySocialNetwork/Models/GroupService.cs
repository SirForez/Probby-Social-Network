using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class GroupService
    {
        ApplicationDbContext db = null;

        public GroupService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public Group getGroupByID(int id)
        {
            var group = (from g in db.Groups
                         where g.ID == id
                         select g).SingleOrDefault();
            return group;
        }

        public bool addGroup(Group g)
        {
            db.Groups.Add(g);
            return db.SaveChanges() != 0;
        }

        public bool editGroup(Group edited)
        {
            var group = getGroupByID(edited.ID);
            if (group != null)
            {
                group.description = edited.description;
                group.hobby = edited.hobby;
                group.name = edited.name;
                group.users = edited.users;
                group.admins = edited.admins;
                return db.SaveChanges() != 0;
            }
            return false;
        }

        public bool removeGroup(Group g)
        {
            db.Groups.Remove(g);
            return db.SaveChanges() != 0;
        }

        public List<Group> groupSearch(String searchString)
        {
            var groups = (from g in db.Groups
                          where g.name.Contains(searchString)
                          select g).ToList();
            return groups;
        }

        public List<Group> tagGroupSearch(String tag)
        {
            var groups = (from g in db.Groups
                          where g.hobby.Name == tag
                          select g).ToList();
            return groups;
        }

        //Cant implement these next two until we implement the database table 
        //properly with ApplicationUser instead of our own User entity class
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