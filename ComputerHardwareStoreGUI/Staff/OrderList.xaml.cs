using ComputerHardwareStoreDLL.Entity;
using ComputerHardwareStoreGUI.Staff;
using MagazinKompTechniki.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MagazinKompTechnikiGUI.Staff
{
    /// <summary>
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrderList : Page
    {
        private Employee _employee;
        public OrderList(Employee employee)
        {
            _employee = employee;
            InitializeComponent();
            ShowClients();
            UpdateData();
            DataSort.SortDirection = ListSortDirection.Descending;
        }
        private void ShowClients()
        {
            foreach (var client in Client.GetAllClients())
            {
                Human human = client;
                SortClient.Items.Add(human.GetFullName());
            }
        }
        private void UpdateData()
        {
            List<Order.OrderInfo> items = new List<Order.OrderInfo>();
            List<Order> orders = Order.GetAllOrder();
            if (SortStatus.SelectedIndex != -1)
            {
                orders = orders.Where(o => o.Status.Equals(SortStatus.Text)).ToList();
            }
            if (SortClient.SelectedIndex != -1)
            {
                orders = orders.Where(o => o.Client.GetFullName() == SortClient.Text).ToList();
            }
            if (SortMaxDate.SelectedDate != null)
            {
                orders = orders.Where(o => o.OrderDate < SortMaxDate.SelectedDate).ToList();
            }
            if (SortMinDate.SelectedDate != null)
            {
                orders = orders.Where(o => o.OrderDate > SortMinDate.SelectedDate).ToList();
            }
            if (SortStaff.IsChecked == true)
            {
                orders = orders.Where(o => o.Employee == _employee).ToList();
            }
            foreach (var order in orders)
            {
                items.Add(Order.GetOrderInfoById(order.ID));
            }
            dataGridOrder.ItemsSource = items;
        }
        private void StatusSort(object sender, MouseEventArgs e)
        {
            UpdateData();
        }
        private void ClientSort(object sender, MouseEventArgs e)
        {
            UpdateData();
        }
        private void MinDateSort(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        private void MaxDateSort(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        private void StaffSort(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }        
        private void SelectOrder(object sender, MouseButtonEventArgs e)
        {
            Order.OrderInfo selectedOrder = (Order.OrderInfo)dataGridOrder.SelectedValue;
            OrderInfo orderInfo = new OrderInfo(selectedOrder.ID, this, _employee);
            orderInfo.Show();
        }
        private void ClearSearch(object sender, RoutedEventArgs e)
        {
            SortStatus.SelectedIndex = -1;
            SortClient.SelectedIndex = -1;
            SortStaff.IsChecked = false;
            SortMinDate.SelectedDate = null;
            SortMaxDate.SelectedDate = null;
            UpdateData();
        }
        public void ShowOrders()
        {
            dataGridOrder.ItemsSource = Order.GetOrderInfo();
            DataSort.SortDirection = ListSortDirection.Descending;
        }
    }
}
