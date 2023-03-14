namespace Lab01_UserLogin
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter password: ");
            string password = Console.ReadLine() ?? string.Empty;

            LoginValidation logVal = new LoginValidation(username, password, DisplayError);
            User admin = new User();

            if (logVal.ValidateUserInput(admin))
            {
                Console.WriteLine($"Credentials: {admin.Username}/{admin.Password}\nFaculty Num: {admin.FacNum}\nRole: {admin.Role}");
                
                switch (LoginValidation.CurrentUserRole)
                {
                    case UserRoles.Anonymous:
                        Console.WriteLine("Anonymous");
                        break;
                    case UserRoles.Admin:
                        Console.WriteLine("Admin");
                        break;
                    case UserRoles.Student:
                        Console.WriteLine("Student");
                        break;
                    case UserRoles.Professor:
                        Console.WriteLine("Professor");
                        break;
                    case UserRoles.Inspector:
                        Console.WriteLine("Inspector");
                        break;

                }
                //Console.WriteLine(LoginValidation.CurrentUserRole);

                string command;
                string uname;
                do
                {
                    PrintCommands();
                    command = InputString("Choose a command from the menu (number): ");

                    if (LoginValidation.CurrentUserRole == UserRoles.Admin)
                    {
                        switch (command)
                        {
                            case "0": // Exit
                                return;
                            case "1":
                                uname = InputString("Enter username: ");
                                string role = InputString("Enter new role: ");
                                UserData.AssignUserRole(uname, (UserRoles)Enum.Parse(typeof(UserRoles), role));
                                break;
                            case "2":
                                uname = InputString("Enter username: ");
                                string activeUntil = InputString("Enter the new active until date and time (dd/mm/yyyy hh:mm:ss): ");
                                UserData.SetUserActiveTo(uname, Convert.ToDateTime(activeUntil));
                                break;
                            case "3":
                                Console.WriteLine($"Username\t\tCreated\t\tActiveUntil");
                                Console.WriteLine("---------------------------------------------------------------------");
                                foreach (var user in UserData.TestUsers)
                                {
                                    Console.WriteLine($"{user.Username}\t\t{user.Created}\t\t{user.ActiveUntil}\t\t");
                                }
                                Console.WriteLine();
                                break;
                            case "4":
                                Console.WriteLine("\n=== ACTIVITY LOG ===");
                                Console.WriteLine(Logger.ReadLogLines());
                                break;
                        }
                    }
                    else
                    {
                        switch (command)
                        {
                            case "0": // Exit
                                return;
                        }
                    }
                }
                while (true);
            }

        }

        public static void DisplayError(string errorMsg)
        {
            Console.WriteLine($"=== Error: {errorMsg}");
        }

        public static string InputString(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }

        public static void PrintCommands()
        {
            Console.WriteLine();
            Console.WriteLine("0: Exit ");

            if (LoginValidation.CurrentUserRole == UserRoles.Admin)
            {
                Console.WriteLine("1: Change the role of a user");
                Console.WriteLine("2: Change until when a user is active");
                Console.WriteLine("3: List all users");
                Console.WriteLine("4: Show activity log");
                Console.WriteLine("5: Show current session activities");
            }
            else
            {
                // pass
            }
        }
    }
}
