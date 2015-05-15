using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Status
	{
		public int ID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string PostedToID { get; set; }
        public int? GroupID { get; set; }
		public DateTime Date { get; set; }
		public string Post { get; set; }
		public string MediaURL { get; set; }
		public int HobbyID { get; set; }
		public string ProfilePic { get; set; }
		public int Karma { get; set; }
        //public virtual ICollection<Hobby> HobbyTags { get; set; }
	}
}