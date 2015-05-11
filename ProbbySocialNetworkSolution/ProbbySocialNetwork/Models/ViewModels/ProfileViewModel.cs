using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUser currentUser;
        public ApplicationUser currentUserProfile;
        public List<Status> currentUserStatusHistory;
        public List<Comment> commentsForStatuses;
		public List<Group> currentUserGroups;
        public List<ApplicationUser> currentUserFollowing;
    }
}