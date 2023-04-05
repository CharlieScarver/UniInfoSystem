using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace StudentInfoSystem
{
    public static class StudentData
    {
        private static List<Student> testStudents = new List<Student>
        {
            new Student("Ivan", "M.", "Teodorov", "FKST", "ITI", "Bachelor", StudentStatus.Remote, "1212201351", "3", "9", "47"),
            new Student("Alexander", "R.", "Apostolov", "FKST", "KSI", "Bachelor", StudentStatus.Studying, "121220145", "3", "10", "43"),
            new Student("Deivid", "V.", "Koichev", "FKST", "KSI", "Bachelor", StudentStatus.Studying, "1212201728", "2", "9", "41"),
            new Student("Hristiana", "A.", "Harizanova", "FKST", "KSI", "Master", StudentStatus.Studying, "121220239", "1", "", ""),
            new Student("Vasil", "Petrov", StudentStatus.Studying, "121220465")
        };

        public static List<Student> TestStudents
        {
            get { return testStudents; }
        }

        public static void AddStudent(Student student)
        {
            TestStudents.Add(student);
        }

        public static Student? IsThereStudent(string facNum)
        {
            StudentInfoContext context = new StudentInfoContext();
            Student? result =
                (from st in context.Students
                 where st.FacNum == facNum
                 select st).FirstOrDefault();
            return result;
        }
    }
}
