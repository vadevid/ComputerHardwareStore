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
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrderList : Page
    {
        private Employee _employee;
        public OrderList(Employee employee)
        {
            _employee = employee;
            InitializeComponent();
            ShowOrders();
        }
        public void ShowOrders()
        {
            dataGridProduct.ItemsSource = Order.GetOrderInfo();
        }
    }
}
