using Lab01_UserLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
