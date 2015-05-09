using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models.ViewModels
{
	public class HobbyViewModel
	{
		public ApplicationUser currentUser;
		public Hobby currentHobby;
		public List<Group> currentHobbyGroups;
		public List<Status> currentHobbyStatusHistory;
		public List<ApplicationUser> currentHobbyUsers;
		public List<Comment> commentsForStatuses;
	}
}