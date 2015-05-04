using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class User : Account
	{
		private List<Status> statuses;
        private List<User> followers;
        private List<User> following;
        private List<Group> groups;
        private List<Hobby> hobbies;
		public int numberOfFollowers { get; set; }
        public int karma { get; set; }
        public string profilePicture { get; set; }
        public bool banned { get; set; }

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