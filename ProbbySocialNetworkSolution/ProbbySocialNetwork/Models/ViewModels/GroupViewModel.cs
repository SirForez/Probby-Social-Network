using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models.ViewModels
{
	public class GroupViewModel
	{
		public ApplicationUser currentUser;
		public Group currentGroup;
		public List<ApplicationUser> currentGroupMembers;
        public List<ApplicationUser> currentGroupAdmins;
		public List<Status> currentGroupStatusHistory;
		public List<Comment> commentsForStatuses;
		public List<Hobby> currentGroupHobbies;
        public List<Hobby> availableHobbies;
	}
}