using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Admin : Account
	{
		private List<Report> reports;
		private List<User> bannedUsers;

		public void banUser();
	}
}