using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Group
	{
		public int ID { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public virtual Hobby hobby { get; set; }
		public ICollection<User> admins;
		public ICollection<User> users;
	}
}