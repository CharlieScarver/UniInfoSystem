using Lab01_UserLogin;
using StudentInfoSystem.Interfaces;
using System.Windows;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(ILoginWindow creator)
         : this()
        {
            Creator = creator;
        }

        private ILoginWindow? Creator { get; set; }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Text;

            LoginValidation logVal = new LoginValidation(username, password, ShowError);
            User admin = new User();

            if (logVal.ValidateUserInput(admin))
            {
                Student? student = StudentData.FindStudent(admin.FacNum);

                if (student == null)
                {
                    ShowError($"No student found with faculty number {admin.FacNum}");
                    return;
                }

                if (Creator == null)
                {
                    ShowError($"Parent window referene is empty");
                    return;
                }

                Creator.OnSuccessfulLogin(student);
                //Creator.ShowStudent(student);
            }
            Hide();
        }

        private void ShowError(string errorMsg)
        {
            MessageBox.Show(errorMsg);
        }
    }
}
