using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using Lab01_UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool IsLoggedIn { get; set; }
        public List<string> StudStatusChoices { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            Title = "Student Info System";

            FillStudStatusChoices();
            CopyTestUsersIfEmpty();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void ClearAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }

        private void ShowStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Student student = StudentData.TestStudents[0];
            ShowStudent(student);
        }

        private void DeactivateAllFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
        }

        private void ActivateAllFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsLoggedIn)
            {
                ActivateAllFieldsButton_Click(sender, e);

                Student? s = StudentData.TestStudents.OrderBy(st => long.Parse(st.FacNum)).FirstOrDefault();
                if (s == null)
                {
                    return;
                }

                IsLoggedIn = true;
                ShowStudent(s);
                loginButton.Content = "Logout";
            }
            else
            {
                DeactivateAllFieldsButton_Click(sender, e);
                ClearAllButton_Click(sender, e);
                IsLoggedIn = false;
                loginButton.Content = "Login";
            }
        }

        private void statusText_DropDownOpened(object sender, EventArgs e)
        {
            FillStudStatusChoices();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StudStatusChoices)));
        }

        private void btnCheckStudents_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TestStudentsIfEmpty() ? "True" : "False");
        }

        private void btnCopyStudents_Click(object sender, EventArgs e)
        {
            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
            }
        }


        // ---------------

        private void ShowStudent(Student student)
        {
            firstNameText.Text = student.FirstName;
            middleNameText.Text = student.MiddleName;
            lastNameText.Text = student.LastName;
            facultyText.Text = student.Faculty;
            specialtyText.Text = student.Specialty;
            educationLevelText.Text = student.EducationLevel;
            statusText.Text = student.Status.ToString();
            facNumText.Text = student.FacNum;
            courseText.Text = student.Year;
            potokText.Text = student.Potok;
            groupText.Text = student.Group;
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();

            using IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect);
            string sqlquery = @"SELECT StatusDescr FROM StudStatus";
            IDbCommand command = new SqlCommand
            {
                Connection = (SqlConnection)connection
            };
            connection.Open();
            command.CommandText = sqlquery;
            IDataReader reader = command.ExecuteReader();

            bool notEndOfResult;
            notEndOfResult = reader.Read();
            while (notEndOfResult)
            {
                string s = reader.GetString(0);
                StudStatusChoices.Add(s);
                notEndOfResult = reader.Read();
            }
        }

        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();

            if (countStudents == 0)
            {
                return true;
            }

            return false;
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student student in StudentData.TestStudents)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();
        }
        private void CopyTestUsersIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            if (context.Users.Count() > 0)
            {
                return;
            }

            foreach (User user in UserData.TestUsers)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }

        private List<Student> GetStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            List<Student> students = context.Students.ToList();
            return students;
        }

        private void DeleteStudent(string facNum)
        {
            StudentInfoContext context = new StudentInfoContext();
            Student? student =
                 (from st in context.Students
                  where st.FacNum == facNum
                  select st).FirstOrDefault();

            if (student == null) { return; }

            context.Students.Remove(student);

            context.SaveChanges();
        }
    }
}
