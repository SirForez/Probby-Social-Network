using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models.ViewModels
{
	public class SavedFeedViewModel
	{
		public List<Comment> commentsForStatuses;
		public ApplicationUser currentUser;
		public List<Status> savedStatusHistory;
	}
}