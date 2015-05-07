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
        public int? GroupID { get; set; }
		public DateTime Date { get; set; }
		public string Post { get; set; }
		public string MediaURL { get; set; }
		public ICollection<Hobby> HobbyTags;
	}
}