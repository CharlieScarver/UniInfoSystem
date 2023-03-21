using System.Collections.Generic;

namespace StudentInfoSystem
{
    public class StudentData
    {
        public List<Student> TestStudents { get; private set;}

        public StudentData()
        {
            TestStudents = new List<Student>
            {
                new Student("Alexander", "R.", "Apostolov", "FKST", "KSI", "Bachelor", StudentStatus.Studying, "121220145", "3", "10", "43"),
                new Student("Deivid", "V.", "Koichev", "FKST", "KSI", "Bachelor", StudentStatus.Studying, "1212201728", "2", "9", "41"),
                new Student("Hristiana", "A.", "Harizanova", "FKST", "KSI", "Master", StudentStatus.Studying, "121220239", "1", "", ""),
                new Student("Vasil", "Petrov", StudentStatus.Studying, "121220465")
            };
        }

        public void AddStudent(Student student)
        {
            TestStudents.Add(student);
        }
    }
}
