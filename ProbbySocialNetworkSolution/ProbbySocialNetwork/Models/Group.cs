using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Group
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual Hobby Hobby { get; set; }
        //public virtual ICollection<ApplicationUser> admins { get; set; }
        //public virtual ICollection<ApplicationUser> users { get; set; }
	}
}