using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class UserHobbyConnection
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int HobbyID { get; set; }
    }
}