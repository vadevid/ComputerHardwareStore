using MagazinKompTechniki.Entity;
using MagazinKompTechnikiGUI.Staff;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MagazinKompTechnikiGUI
{
    /// <summary>
    /// Логика взаимодействия для StaffPannel.xaml
    /// </summary>
    public partial class StaffPannel : Window
    {
        private Page newOrder;
        private Page orderList;
        private Page newClient;
        private SolidColorBrush purple = new SolidColorBrush(Color.FromRgb(0x67, 0x3b, 0xb7));
        private Employee _employee;
        public StaffPannel(Employee employee)
        {
            _employee = employee;
            InitializeComponent();
            NewOrderBtn.Background = Brushes.White;
            NewOrderBtn.Foreground = purple;
            AddPage();
            View.Navigate(newOrder);

            WindowState = WindowState.Maximized;
        }
        private void AddPage()
        {
            orderList = new OrderList(_employee);
            newOrder = new NewOrder(_employee, orderList);
            newClient = new NewClient(newOrder);
        }

        private void AddOrder_Button(object sender, RoutedEventArgs e)
        {
            View.Navigate(newOrder);
            NewOrderBtn.Background = Brushes.White;
            NewOrderBtn.Foreground = purple;
            NewClientBtn.Background = purple;
            NewClientBtn.Foreground = Brushes.White;
            OrderListBtn.Background = purple;
            OrderListBtn.Foreground = Brushes.White;
        }
        private void OrderList_Button(object sender, RoutedEventArgs e)
        {
            View.Navigate(orderList);
            NewOrderBtn.Background = purple;
            NewOrderBtn.Foreground = Brushes.White;
            NewClientBtn.Background = purple;
            NewClientBtn.Foreground = Brushes.White;
            OrderListBtn.Background = Brushes.White;
            OrderListBtn.Foreground = purple;
        }
        private void AddClient_Button(object sender, RoutedEventArgs e)
        {
            View.Navigate(newClient);
            NewOrderBtn.Background = purple;
            NewOrderBtn.Foreground = Brushes.White;
            NewClientBtn.Background = Brushes.White;
            NewClientBtn.Foreground = purple;
            OrderListBtn.Background = purple;
            OrderListBtn.Foreground = Brushes.White;
        }
        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            MainLogin mainLogin = new MainLogin();
            Close();
            mainLogin.Show();
        }
    }
}
