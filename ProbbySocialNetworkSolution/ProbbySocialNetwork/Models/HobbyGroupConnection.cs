using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class HobbyGroupConnection
    {
        public int ID { get; set; }
        public int HobbyID { get; set; }
        public int GroupID { get; set; }
    }
}