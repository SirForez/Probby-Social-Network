using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models.ViewModels
{
    public class SearchViewModel
    {
        public String searchString;
        public List<Hobby> hobbySearchResults;
        public List<Group> groupSearchResults;
        public List<ApplicationUser> userSearchResults;
    }
}