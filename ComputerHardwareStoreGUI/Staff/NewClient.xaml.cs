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
        private NewOrder _newOrder;
        public NewClient(Page newOrder)
        {
            InitializeComponent();
            _newOrder = newOrder as NewOrder;
            ShowClients();
        }
        private void ShowClients ()
        {
            dataGridClient.ItemsSource = Client.GetClientInfo();
        }
        private void AddClient(string secondName, string firstName, string middleName, string street, string house, int flat)
        {
            var client = new Client()
            {
                FirstName = firstName,
                SecondName = secondName,
                MiddleName = middleName,
                Street = street,
                House = house,
                Flat = flat,
            };
            Client.Add(client);
        }
        private void CheckNumber(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }        
        }
        private void AddClient_Button(object sender, RoutedEventArgs e)
        {
            if (SecondName.Text == "" || FirstName.Text == "" || MiddleName.Text == "" || Street.Text == "" || House.Text == "" || Flat.Text == "")
            {
                MessageBox.Show("Не были введены некоторые данные\nпожалуйста проверьте все поля!");
            } else
            {
                string secondName = SecondName.Text;
                string firstName = FirstName.Text;
                string middleName = MiddleName.Text;
                string street = Street.Text;
                string house = House.Text;
                int flat = int.Parse(Flat.Text);
                AddClient(secondName, firstName, middleName, street, house, flat);
                ShowClients();
                _newOrder.FillClients();
            }            
        }        
    }
}
