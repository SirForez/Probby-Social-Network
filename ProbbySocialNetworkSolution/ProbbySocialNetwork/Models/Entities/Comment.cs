using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Comment
	{
		public int ID { get; set; }
		public System.DateTime DateInserted { get; set; }
		public string Body { get; set; }
	}
}