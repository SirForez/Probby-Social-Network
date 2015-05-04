using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Report
	{
        public string reason { get; set; }
        public string explanation { get; set; }
        public User reportedUser { get; set; }
        public User sender { get; set; }
        public DateTime date { get; set; }
	}
}