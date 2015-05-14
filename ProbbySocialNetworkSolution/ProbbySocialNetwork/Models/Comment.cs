using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Comment
	{
		public int ID { get; set; }
		public int StatusID { get; set; }
		public string UserID { get; set; }
		public string UserName { get; set; }
		public System.DateTime DateInserted { get; set; }
		public string Body { get; set; }
		public string StatusUserID { get; set; }

		[NotMapped]
		public string DisplayDate { get { return DateInserted.ToString("dd.MM.yyyy HH:mm:ss"); } }

	}
}