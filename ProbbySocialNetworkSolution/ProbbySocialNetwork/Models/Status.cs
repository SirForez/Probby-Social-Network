using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Status
	{
<<<<<<< HEAD
		private List<Comment> comments;

=======
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Post { get; set; }
        public string MediaURL { get; set; }
        public ICollection<Hobby> HobbyTags;
        public ICollection<Comment> Comments;
>>>>>>> 8c0f660517be93915e618def700a011036c579ec
	}
}