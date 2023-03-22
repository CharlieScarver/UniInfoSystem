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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsLoggedIn { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            Title = "Student Info System";
        }

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

    }
}
