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
        public List<ApplicationUser> currentUserProfileFollowing;
		public List<ApplicationUser> currentUserProfileFollowers;
		public int currentUserProfileNumberOfFollowers;
		public int currentUserProfileNumberOfFollowing;
        public List<Status> currentUserStatusHistory;
        public List<Comment> commentsForStatuses;
		public List<Group> currentUserGroups;
		public List<Hobby> currentUserHobbies;
		public List<ApplicationUser> currentUserFollowing;
		public List<ApplicationUser> currentUserFollowers;
		public int currentUserNumberOfFollowers;
		public int currentUserNumberOfFollowing;
    }
}