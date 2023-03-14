using System.Text;

namespace Lab01_UserLogin
{
    public static class Logger
    {
        private static string logFileName = "activity_log.txt";

        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(Activities activity, string additionalText = "")
        {
            string activityDesc = string.Empty;
            switch (activity)
            {
                case Activities.Login:
                    activityDesc = "User logged in";
                    break;
                case Activities.UserRoleChanged:
                    activityDesc = "Changed a user's role";
                    break;
                case Activities.UserActiveToChanged:
                    activityDesc = "Changed a user's ActiveUntil";
                    break;
                case Activities.ListUsers:
                    activityDesc = "Viewed the user list";
                    break;
                case Activities.ShowLog:
                    activityDesc = "Viewed the activity log";
                    break;

            }
            LogActivityString($"{activityDesc};{additionalText}");
        }

        private static void LogActivityString(string text)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(DateTime.Now);
            sb.Append(";");
            sb.Append(LoginValidation.CurrentUserUsername);
            sb.Append(";");
            sb.Append(LoginValidation.CurrentUserRole);
            sb.Append(";");
            sb.Append(text);

            string activityLine = sb.ToString();
            currentSessionActivities.Add(activityLine);

            File.AppendAllText(logFileName, activityLine + "\n");
        }

        public static string ReadLogLines()
        {
            StreamReader sr = new StreamReader(logFileName);
            StringBuilder sb = new StringBuilder();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine() ?? "";
                sb.Append(line);
            }
            
            sr.Close();

            return sb.ToString();
        }
    }
}
