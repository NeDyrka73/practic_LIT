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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();

            MainWindow.Show();
            this.Hide();

        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var pass = Password.Text;
            var pass2 = Password2.Text;
            var mail = Mail.Text;
            var CONTEXT = new AppDbContext();


            var user_exists = CONTEXT.Users.FirstOrDefault(x => x.Login == login);

            if (login.Length == 0)
            {
                MessageBox.Show("Укажите логин!");
                return;
            } else if (login.Length < 6)
            {
                MessageBox.Show("Логин должен состоять из 6 символов!");
                return;
            }

            if (mail.Length == 0)
            {
                MessageBox.Show("Укажите почту!");
                return;
            }

            if (pass.Length == 0)
            {
                MessageBox.Show("Укажите пароль!");
                return;
            } else if (pass.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов!");
                return;
            } else if (pass != pass2)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже существует!");
                return;
            }

            var user = new User { Login = login, Password = pass, Mail = mail};
            CONTEXT.Users.Add(user);
            CONTEXT.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрировались!");
        }
    }
}
