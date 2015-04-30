using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Group
	{
		private string name;
		private string description;
		private User founder;
		private List<User> admins;
		private List<User> users;
		private List<Status> statuses;
		private Hobby hobby;

		public void addUser(User u);
		public void makeAdmin(User u);
		public void deleteGroup();
		public void addStatus();
		public void editStatus();
		public void removeStatus();
	}
}