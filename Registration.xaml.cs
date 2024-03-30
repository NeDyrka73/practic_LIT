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

        private void but_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var pass = Password.Text;
            var mail = Mail.Text;
            var CONTEXT = new AppDbContext();

            var user_exists = CONTEXT.Users.FirstOrDefault(x => x.Login == login);
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
