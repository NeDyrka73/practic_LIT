﻿using System;
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

namespace WpfApp2
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

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration();

            registration.Show();
            this.Hide();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var pass = Password.Text;
            var mail = Login.Text;

            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x => x.Login == login || x.Mail == mail && x.Password == pass);

            if (user is null)
            {
                MessageBox.Show("Неверный логин или пароль!");
                return;
            }
            
    
            MessageBox.Show("Вы успешно вошли в аккаунт!");

            Account account = new Account();

            account.Show();
            this.Hide();

        }


    }
}
