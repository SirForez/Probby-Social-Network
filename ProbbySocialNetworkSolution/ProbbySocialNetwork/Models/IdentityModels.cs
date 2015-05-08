using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace ProbbySocialNetwork.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
        public int Karma { get; set; }
        public string ProfilePic { get; set; }
        public int NumberOfFollowers { get; set; }
        public int NumberOfFollowing { get; set; }
        //public virtual ICollection<UserConnection> Followers { get; set; }
        //public virtual ICollection<UserConnection> Followings { get; set; }
        //public virtual ICollection<Hobby> Hobbies { get; set; }
        //public virtual ICollection<Group> Groups { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Comment> Comments {get; set;}
		public DbSet<Group> Groups { get; set; }
		public DbSet<Hobby> Hobbies { get; set; }
		public DbSet<Status> Statuses { get; set; }
        public DbSet<AdminGroupConnection> AdminGroupConnections { get; set; }
        public DbSet<HobbyGroupConnection> HobbyGroupConnections { get; set; }
        public DbSet<StatusHobbyConnection> StatusHobbyConnections { get; set; }
        public DbSet<UserFollowConnection> UserFollowConnections { get; set; }
        public DbSet<UserGroupConnection> UserGroupConnections { get; set; }
        public DbSet<UserHobbyConnection> UserHobbyConnections { get; set; }
		//public DbSet<ApplicationUser> Users { get; set; }
		//public DbSet<UserConnection> UserConnections { get; set; }
		
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}