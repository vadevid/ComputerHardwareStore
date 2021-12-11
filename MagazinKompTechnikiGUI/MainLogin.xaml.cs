using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MagazinKompTechnikiGUI
{
    /// <summary>
    /// Логика взаимодействия для MainLogin.xaml
    /// </summary>
    public partial class MainLogin : Window
    {
        Page register;
        Page login;
        public MainLogin()
        {
            InitializeComponent();
            AddPage();
        }

        public void AddPage()
        {
            register = new Register();
            login = new Login();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            this.LoginView.NavigationService.Navigate(register);
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            this.LoginView.NavigationService.Navigate(login);
        }
    }
}
