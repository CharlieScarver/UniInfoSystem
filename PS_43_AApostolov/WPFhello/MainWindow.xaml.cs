using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length < 2)
            {
                MessageBox.Show("The name should be at least two characters long");
                return;
            }

            StringBuilder msg = new StringBuilder();
            msg.AppendLine("Hello! This is your first WPF app!");

            foreach (var item in grdMain.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    msg.AppendLine(textBox.Text);
                }
            }

            MessageBox.Show(msg.ToString());
        }

        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length < 2)
            {
               lblError.Content = "The name should be at least two characters long";
            }
            else
            {
                lblError.Content = "";
            }
        }

        private void txtN_TextChanged(object sender, RoutedEventArgs e)
        {
            int n, y;
            bool validN = int.TryParse(txtN.Text, out n);
            lblResultText.Foreground = Brushes.Black;
            if (txtN.Text.Length > 0 && txtY.Text.Length > 0 && validN && int.TryParse(txtY.Text, out y))
            {
                lblResult.Content = "N^Y = ";
                lblResultText.Content = Math.Pow(n, y);
            }
            else if (txtN.Text.Length > 0 && validN)
            {
                lblResult.Content = "N! = ";
                int factorial = 1;
                for (int i = 2; i <= n; i++)
                {
                    factorial = factorial * i;
                }
                lblResultText.Content = factorial;
            }
            else
            {
                lblResult.Content = "Error:";
                lblResultText.Content = "Invalid input";
                lblResultText.Foreground = Brushes.Red;
            }
        }

        private void winForm_Closing(object sender, CancelEventArgs e)
        {
            string msg = "Are you sure you want to close the app?";
            MessageBoxResult result = MessageBox.Show(
                msg,
                "Data App",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is Windows Presentation Foundation!");
            txtBlock1.Text = DateTime.Now.ToString();
        }
    }
}
