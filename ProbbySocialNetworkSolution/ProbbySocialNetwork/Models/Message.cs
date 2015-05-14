using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class Message
    {
        public int ID { get; set; }
        //public int ChatID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public System.DateTime DateInserted { get; set; }
        public string Text { get; set; }
    }
}