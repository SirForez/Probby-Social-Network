using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Hobby
	{
        private List<Group> groups;
        private List<Hobby> subHobbies;
        public string name { get; set; }
        public string description { get; set; }
	}
}