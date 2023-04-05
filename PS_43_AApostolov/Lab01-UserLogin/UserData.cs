namespace Lab01_UserLogin
{
    public static class UserData
    {
        static private List<User> _testUsers;

        private static void ResetTesUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>
                {
                    new User("aapos", "12345", "121220120", UserRoles.Admin),
                    new User("petrov", "12345", "121220114", UserRoles.Student),
                    new User("iliev", "12345", "121220153", UserRoles.Student)
                };
            }
        }

        public static List<User> TestUsers
        {
            get
            {
                ResetTesUserData();
                return _testUsers;
            }
        }

        public static User? IsUserPassCorrect(string username, string password)
        {
            UserContext context = new UserContext();
            User? result =
                (from u in context.Users
                 where u.Username == username && u.Password == password
                 select u).FirstOrDefault();
            return result;
        }

        public static User? FindUserByUsername(string username)
        {
            UserContext context = new UserContext();

            User? result =
                (from u in context.Users
                 where u.Username == username
                 select u).FirstOrDefault();

            return result;
        }

        public static void SetUserActiveTo(string username, DateTime activeUntil)
        {
            UserContext context = new UserContext();
            User? found = FindUserByUsername(username);
            if (found == null)
            {
                return;
            }

            found.ActiveUntil = activeUntil;

            context.SaveChanges();
            Logger.LogActivity(Activities.UserActiveToChanged, $"(Username: {found.Username}, New ActiveUntil: {found.ActiveUntil})");
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            UserContext context = new UserContext();
            User? found = FindUserByUsername(username);
            if (found == null)
            {
                return;
            }

            found.Role = role;

            context.SaveChanges();
            Logger.LogActivity(Activities.UserRoleChanged, $"(Username: {found.Username}, New role: {found.Role})");
        }
    }
}
