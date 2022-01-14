using MagazinKompTechniki.Entity;
using MagazinKompTechnikiGUI.Staff;
using System.Windows;
using System.Windows.Controls;

namespace MagazinKompTechnikiGUI
{
    /// <summary>
    /// Логика взаимодействия для StaffPannel.xaml
    /// </summary>
    public partial class StaffPannel : Window
    {
        Page newOrder;
        Page orderList;
        Page newClient;

        private Employee _employee;
        public StaffPannel(Employee employee)
        {
            _employee = employee;
            InitializeComponent();
            AddPage();
            View.Navigate(newOrder);
            WindowState = WindowState.Maximized;
        }
        public void AddPage()
        {
            newOrder = new NewOrder(_employee);
            orderList = new OrderList(_employee);
            newClient = new NewClient();
        }

        public void AddOrder_Button(object sender, RoutedEventArgs e)
        {
            View.Navigate(newOrder);
        }
        public void OrderList_Button(object sender, RoutedEventArgs e)
        {
            View.Navigate(orderList);
        }
        public void AddClient_Button(object sender, RoutedEventArgs e)
        {
            View.Navigate(newClient);
        }
    }
}
