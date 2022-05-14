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
using System.Windows.Shapes;

namespace DaDaYaRemastered
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text == "choyrt" && passwordBox.Password == "Dmitriy")
            {
                MainWindow main = new MainWindow();
                main.authName.Content = "Personal";
                main.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неправильно");
                passwordBox.Password = "";
            }
        }

        private void guestButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.AuthPersonal = false;
            main.Show();
            Close();
        }
    }
}
