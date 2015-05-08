using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models.ViewModels
{
	public class FeedViewModel
	{
		public List<Comment> commentsForStatuses { get; set; }
		public ApplicationUser currentUser {get; set;}
		public List<Status> newestStatuses { get; set; }
	}
}