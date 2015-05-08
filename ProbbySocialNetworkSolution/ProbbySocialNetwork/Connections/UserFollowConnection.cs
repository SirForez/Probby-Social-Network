using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class UserFollowConnection
    {
        public int ID { get; set; }
        public int FollowerID { get; set; }
        public int FollowingID { get; set; }
    }
}