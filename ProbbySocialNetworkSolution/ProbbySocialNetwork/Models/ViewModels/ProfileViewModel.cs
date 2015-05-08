using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUser currentUser;
        public List<Status> currentUserStatusHistory;
        public List<Comment> commentsForStatuses;
    }
}