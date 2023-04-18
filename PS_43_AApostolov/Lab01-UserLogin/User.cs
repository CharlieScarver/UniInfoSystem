using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab01_UserLogin
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string password, string facNum, UserRoles role)
        {
            Username = username;
            Password = password;
            FacNum = facNum;
            Role = role;
            Created = DateTime.Now;
            ActiveUntil = DateTime.MaxValue;
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        [ForeignKey("fk_User_Student_FacNum")]
        public string? FacNum { get; set; }

        public UserRoles Role { get; set; }

        public DateTime Created { get; set; }

        public DateTime? ActiveUntil { get; set; }

        public void CopyUser(User user)
        {
            Username = user.Username;
            Password = user.Password;
            FacNum = user.FacNum;
            Role = user.Role;
            Created = user.Created;
            ActiveUntil = user.ActiveUntil;
        }
    }
}
