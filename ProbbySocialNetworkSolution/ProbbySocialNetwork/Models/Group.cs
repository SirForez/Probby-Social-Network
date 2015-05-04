using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Group
	{
        public string name { get; set; }
        public string description { get; set; }
        public User founder { get; set; }
        public Hobby hobby { get; set; }
		private List<User> admins;
		private List<User> users;
		private List<Status> statuses;


        public void addUser(User u)
        {

        }
        public void makeAdmin(User u)
        {

        }
        public void deleteGroup()
        {

        }
        public void addStatus()
        {

        }
        public void editStatus()
        {

        }
        public void removeStatus()
        {

        }
	}
}