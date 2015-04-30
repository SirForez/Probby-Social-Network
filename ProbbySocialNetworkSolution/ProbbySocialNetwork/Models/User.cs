using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class User : Account
	{
		private List<Status> statuses;
		private int numberOfFollowers;
		private List<User> followers;
		private List<User> following;
		private List<Group> groups;
		private int karma;
		private string profilePicture;
		private bool banned;
		private List<Hobby> hobbies;

		public void addStatus();
		public void editStatus();
		public void removeStatus();
	}
}