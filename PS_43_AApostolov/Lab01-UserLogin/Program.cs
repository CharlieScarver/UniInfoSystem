﻿using System.Text;

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
                                Logger.LogActivity(Activities.Exit);
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
                                Console.WriteLine($"Username\t\tRole\t\tCreated\t\tActiveUntil");
                                Console.WriteLine("---------------------------------------------------------------------");
                                UserContext context = new UserContext();
                                foreach (var user in context.Users)
                                {
                                    Console.WriteLine($"{user.Username}\t\t{user.Role}\t\t{user.Created}\t\t{user.ActiveUntil}\t\t");
                                }
                                Console.WriteLine();
                                Logger.LogActivity(Activities.ListUsers);
                                break;
                            case "4":
                                Console.WriteLine("\n=== ACTIVITY LOG ===");
                                IEnumerable<string> lines = Logger.GetFullLogLines();
                                StringBuilder sb = new StringBuilder();

                                foreach (string line in lines)
                                {
                                    sb.AppendLine(line);
                                }

                                Console.WriteLine(sb.ToString());
                                Logger.LogActivity(Activities.ShowLog);
                                break;
                            case "5":
                                Console.WriteLine("\n=== Current session activities ===");
                                Console.WriteLine(Logger.GetLogActivities());
                                Logger.LogActivity(Activities.ShowCurrentSessionActivities);
                                break;
                        }
                    }
                    else
                    {
                        switch (command)
                        {
                            case "0": // Exit
                                Logger.LogActivity(Activities.Exit);
                                return;
                            case "1":
                                Console.WriteLine("\n=== Current session activities ===");
                                IEnumerable<string> lines = Logger.GetCurrentSessionActivitiesLines();
                                foreach (string line in lines)
                                {
                                    Console.WriteLine(line);
                                }
                                Logger.LogActivity(Activities.ShowCurrentSessionActivities);
                                break;
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
                Console.WriteLine("4: Show the full activity log");
                Console.WriteLine("5: Show current session activities");
            }
            else
            {
                Console.WriteLine("1: Show current session activities");
            }
        }
    }
}
