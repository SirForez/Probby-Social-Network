using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class StatusHobbyConnection
    {
        public int ID { get; set; }
        public int StatusID { get; set; }
        public int HobbyID { get; set; }
    }
}