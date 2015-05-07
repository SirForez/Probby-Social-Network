using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Status
	{
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Post { get; set; }
        public string MediaURL { get; set; }
        public virtual ICollection<Hobby> HobbyTags;
        public virtual ICollection<Comment> Comments;
	}
}