using System.Windows;

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
                main.AuthPersonal = true;
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
