using System.Data.Entity;

namespace Lab01_UserLogin
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base(Properties.Settings.Default.DbConnect)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
