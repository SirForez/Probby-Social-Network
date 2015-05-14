using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProbbySocialNetwork.Models
{
	public class Hobby
	{
		public int ID { get; set; }

		[RegularExpression("^([a-zA-Z0-9]+)$", ErrorMessage = "Invalid Name")]
		public string Name { get; set; }
	}
}