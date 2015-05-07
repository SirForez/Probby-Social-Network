using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class UserConnection
	{
		public int ID { get; set; }
		public User TheUser { get; set; }
		public User OtherUser { get; set; }
	}
}