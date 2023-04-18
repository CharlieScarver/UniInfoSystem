using Lab01_UserLogin;
using Microsoft.EntityFrameworkCore;

namespace StudentInfoSystem
{
    public class StudentInfoContext : DbContext
    {
        public StudentInfoContext()
            : base(GetMyDbContext())
        {
        }

        public StudentInfoContext(DbContextOptions options)
            : base(options)
        {
        }

        private static string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=StudentInfoDatabase;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=true";

        public static DbContextOptions GetMyDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentInfoContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne<User>("User") // Student has one User - navigation property name = "User"
                .WithOne() // User has one Student - no navigational property
                .HasForeignKey<User>("FacNum") // User has a foreign key to Student and it's the "FacNum" prop
                .HasPrincipalKey<Student>("FacNum") // Student is the principal in the relationship and will use the "FacNum" prop to pair with User
                .IsRequired(false); // The relationship is optional, i.e. the foreign key(s) are nullable (the column props are already set as nullable in the classes)

            // Since this will create a foreign key in the Users table
            // every User with a FacNum will be required to have a Student entry
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
