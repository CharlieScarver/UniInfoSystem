using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public Student(string firstName, string lastName, StudentStatus status, string facNum)
        {
            FirstName = firstName;
            LastName = lastName;
            Status = status;
            FacNum = facNum;
        }

        public Student(string firstName, string middleName, string lastName, string faculty, string specialty, string educationLevel, StudentStatus status, string facNum, string year, string potok, string group)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Faculty = faculty;
            Specialty = specialty;
            EducationLevel = educationLevel;
            Status = status;
            FacNum = facNum;
            Year = year;
            Potok = potok;
            Group = group;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public string EducationLevel { get; set; }
        public StudentStatus Status { get; set; }
        public string FacNum { get; set; }
        public string Year { get; set; }
        public string Potok { get; set; }
        public string Group { get; set; }


    }
}
