using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class UserGroupConnection
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int GroupID { get; set; }
    }
}