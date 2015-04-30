using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Comment : Post
	{
		private List<Comment> replies;

		public void addReply();
		public void removeReply();
	}
}