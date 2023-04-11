using Lab01_UserLogin;
using System.Linq;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student? GetStudentDataByUser(User user)
        {
            if (user.FacNum == null || user.FacNum == "")
            {
                return null;
            }

            return StudentData.TestStudents.Where(s => s.FacNum == user.FacNum).FirstOrDefault();
        }
    }
}
