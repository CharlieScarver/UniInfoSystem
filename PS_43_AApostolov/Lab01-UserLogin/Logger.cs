namespace Lab01_UserLogin
{
    public static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.CurrentUserUsername + ";"
                + LoginValidation.CurrentUserRole + ";"
                + activity;
            currentSessionActivities.Add(activityLine);
        }
    }
}
