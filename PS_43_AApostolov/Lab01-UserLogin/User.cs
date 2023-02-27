using System;
using System.Data;

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

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? FacNum { get; set; }

        public UserRoles Role { get; set; }

        public DateTime Created { get; set; }

        public DateTime ActiveUntil { get; set; }

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
