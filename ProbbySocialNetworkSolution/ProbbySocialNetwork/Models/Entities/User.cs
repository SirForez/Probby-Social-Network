using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class User
    {
		public int ID { get; set; }
		public string Role {get; set;}
		public string UserName {get; set;}
		public string Password {get; set;}
		public string Email {get; set;}
		public int Karma {get; set;}
		public string ProfilePic {get; set;}
		public int NumberOfFollowers {get; set;}
		public int NumberOfFollowing { get; set; }
		private ICollection<UserConnection> Followers;
		private ICollection<UserConnection> Followings;
		private ICollection<Hobby> Hobbies;
		private ICollection<Group> Groups;
    }
}