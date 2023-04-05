using Lab01_UserLogin;
using System.Data.Entity;

namespace StudentInfoSystem
{
    public class StudentInfoContext : DbContext
    {
        public StudentInfoContext()
            : base(Properties.Settings.Default.DbConnect)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
