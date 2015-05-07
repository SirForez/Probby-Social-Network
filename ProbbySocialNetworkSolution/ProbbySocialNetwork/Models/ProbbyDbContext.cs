using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
	public class ProbbyDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Comment> comments { get; set; }

	}
}