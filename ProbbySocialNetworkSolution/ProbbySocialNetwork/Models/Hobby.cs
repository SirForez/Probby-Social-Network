using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class Hobby
	{
		private string name;
		private string description;
		private List<Group> groups;
		private List<Hobby> subHobbies;

		public void addGroup(Group g);
		public void rempoveGroup(Group g);
		public void addSubHobby(Hobby h);
		public void removeSubHobby(Hobby h);
	}
}