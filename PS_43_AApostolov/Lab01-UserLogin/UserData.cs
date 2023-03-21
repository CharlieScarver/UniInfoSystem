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
            return (from u in TestUsers where username == u.Username && password == u.Password select u).SingleOrDefault();
        }

        public static User? FindUserByUsername(string username)
        {
            foreach (User u in TestUsers)
            {
                if (username == u.Username)
                {
                    return u;
                }
            }

            return null;
        }

        public static void SetUserActiveTo(string username, DateTime activeUntil)
        {
            User? found = FindUserByUsername(username);
            if (found == null)
            {
                return;
            }

            found.ActiveUntil = activeUntil;
            Logger.LogActivity(Activities.UserActiveToChanged, $"(Username: {found.Username}, New ActiveUntil: {found.ActiveUntil})");
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            User? found = FindUserByUsername(username);
            if (found == null)
            {
                return;
            }

            found.Role = role;
            Logger.LogActivity(Activities.UserRoleChanged, $"(Username: {found.Username}, New role: {found.Role})");
        }
    }
}
