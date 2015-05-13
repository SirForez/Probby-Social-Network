using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUser currentUser;
        public ApplicationUser profileOwner;
        public List<ApplicationUser> profileOwnerFollowing;
		public List<ApplicationUser> profileOwnerFollowers;
		public List<Status> profileOwnerStatusHistory;
        public List<Comment> commentsForStatuses;
		public List<Group> profileOwnerGroups;
		public List<Hobby> profileOwnerHobbies;
    }
}