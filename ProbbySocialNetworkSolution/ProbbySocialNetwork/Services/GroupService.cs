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

                //We do not know if this works, must test:
                var users = getUsersByGroup(group);
                users = getUsersByGroup(edited);
                var admins = getAdminsByGroup(group);
                users = getAdminsByGroup(edited);

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

        public bool addUserToGroup(Group g, ApplicationUser toAdd)
        {
            UserGroupConnection gConnection = new UserGroupConnection();
            gConnection.GroupID = g.ID;
            gConnection.UserID = toAdd.Id;
            db.UserGroupConnections.Add(gConnection);
            return db.SaveChanges() != 1;
        }

        public UserGroupConnection getUserGroupConnection(Group g, ApplicationUser u)
        {
            var uConnection = (from c in db.UserGroupConnections
                               where c.GroupID == g.ID && c.UserID == u.Id
                               select c).SingleOrDefault();
            return uConnection;
        }

        public bool removeUserFromGroup(Group g, ApplicationUser toDel)
        {
            UserGroupConnection gConnection = getUserGroupConnection(g, toDel);
            db.UserGroupConnections.Remove(gConnection);
            return db.SaveChanges() != 1;
        }

        public bool addAdminToGroup(Group g, ApplicationUser toAdd)
        {
            AdminGroupConnection gConnection = new AdminGroupConnection();
            gConnection.GroupID = g.ID;
            gConnection.UserID = toAdd.Id;
            db.AdminGroupConnections.Add(gConnection);
            return db.SaveChanges() != 1;
        }

        public AdminGroupConnection getAdminGroupConnection(Group g, ApplicationUser u)
        {
            var aConnection = (from c in db.AdminGroupConnections
                               where c.GroupID == g.ID && c.UserID == u.Id
                               select c).SingleOrDefault();
            return aConnection;
        }

        public bool removeAdminFromGroup(Group g, ApplicationUser toDel)
        {
            AdminGroupConnection gConnection = getAdminGroupConnection(g, toDel);
            db.AdminGroupConnections.Remove(gConnection);
            return db.SaveChanges() != 1;
        }

        public List<Group> tagGroupSearch(String tag)
        {
            var groups = (from g in db.Groups
                          where g.hobby.Name == tag
                          select g).ToList();
            return groups;
        }

        public List<Group> getGroupsByUser(ApplicationUser a)
        {
			if (a == null)
			{
				return null;
			}
			
			var groups = (from c in db.UserGroupConnections
                         where c.UserID == a.Id
                         join g in db.Groups on c.GroupID equals g.ID
                         select g).ToList();
            return groups;
        }

        public List<ApplicationUser> getUsersByGroup(Group g)
        {
            var users = (from c in db.UserGroupConnections
                         where c.GroupID == g.ID
                         join u in db.Users on c.UserID equals u.Id
                         select u).ToList();
            return users;
        }

        public List<ApplicationUser> getAdminsByGroup(Group g)
        {
            var users = (from c in db.AdminGroupConnections
                         where c.GroupID == g.ID
                         join u in db.Users on c.UserID equals u.Id
                         select u).ToList();
            return users;
        }
    }
}