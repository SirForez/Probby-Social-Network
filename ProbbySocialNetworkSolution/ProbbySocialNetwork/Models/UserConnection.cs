using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class UserConnection
	{
		public int ID { get; set; }
		public virtual User TheUser { get; set; }
		public virtual User OtherUser { get; set; }
	}
}