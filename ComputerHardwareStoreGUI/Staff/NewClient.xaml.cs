using MagazinKompTechniki;
using MagazinKompTechniki.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MagazinKompTechnikiGUI.Staff
{
    /// <summary>
    /// Логика взаимодействия для NewClient.xaml
    /// </summary>
    public partial class NewClient : Page
    {
        public NewClient()
        {
            InitializeComponent();
        }
        public void ShowClients ()
        {
            dataGridClient.ItemsSource = Client.GetClientInfo();
        }

        public void AddClient_Button(object sender, RoutedEventArgs e)
        {
            string secondName = SecondName.Text;
            string firstName = FirstName.Text;
            string middleName = MiddleName.Text;
            string adress = Adress.Text;
            AddClient(secondName, firstName, middleName, adress);
            ShowClients();
        }

        public void AddClient(string secondName, string firstName, string middleName, string adress)
        {
            
            var client = new Client()
            {
                FirstName = firstName,
                SecondName = secondName,
                MiddleName = middleName,
                Adress = adress
            };
            Client.Add(client);
        }
    }
}
