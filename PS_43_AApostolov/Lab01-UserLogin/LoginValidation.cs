using System;

namespace Lab01_UserLogin
{
    public class LoginValidation
    {
        // Static
        public static UserRoles CurrentUserRole { get; private set; }
        public static string CurrentUserUsername { get; private set; }

        // Private
        private string Username { get; set; }
        private string Password { get; set; }

        private string ErrorMsg { get; set; }

        private ActionOnError OnError { get; set; }

        private void HandleError()
        {
            OnError(ErrorMsg);
            CurrentUserRole = UserRoles.Anonymous;
            CurrentUserUsername = string.Empty;
        }

        // Public
        public LoginValidation(string username, string password, ActionOnError onError)
        {
            Username = username;
            Password = password;
            ErrorMsg = "";
            OnError = onError;
        }

        public delegate void ActionOnError(string error);

        public bool ValidateUserInput(User user)
        {
            // Validate username and password
            if (Username == string.Empty)
            {
                ErrorMsg = "Empty username";
                HandleError();
                return false;
            } else if (Username.Length < 5)
            {
                ErrorMsg = "Username is less than 5 characters";
                HandleError();
                return false;
            }
            
            if (Password == string.Empty)
            {
                ErrorMsg = "Empty password";
                HandleError();
                return false;
            }
            else if (Password.Length < 5)
            {
                ErrorMsg = "Password is less than 5 characters";
                HandleError();
                return false;
            }

            // Check if a user with these credentials exists
            User? found = UserData.IsUserPassCorrect(Username, Password);
            if (found == null)
            {
                ErrorMsg = "User not found";
                HandleError();
                return false;
            }

            user.CopyUser(found);

            Logger.LogActivity("Login");
            CurrentUserRole = found.Role;
            CurrentUserUsername = found.Username ?? string.Empty;
            return true;
        }
    }
}
