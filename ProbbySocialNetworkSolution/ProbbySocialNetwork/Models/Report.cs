using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Report
	{
		private string reason;
		private string explanation;
		private User reportedUser;
		private User sender;
		private DateTime date;
	}
}