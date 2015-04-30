using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Status : Post
	{
		private List<Comment> comments;

		public void addComment();
		public void removeComment();
	}
}