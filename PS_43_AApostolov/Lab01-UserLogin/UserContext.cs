using Microsoft.EntityFrameworkCore;

namespace Lab01_UserLogin
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base(GetMyDbContext())
        {
        }

        public UserContext(DbContextOptions options)
            : base(options)
        {
        }

        private static string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=StudentInfoDatabase;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=true";

        public static DbContextOptions GetMyDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }

        public DbSet<User> Users { get; set; }
    }
}
