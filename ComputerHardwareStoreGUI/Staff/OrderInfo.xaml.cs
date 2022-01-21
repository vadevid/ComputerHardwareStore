using ComputerHardwareStoreDLL.Entity;
using MagazinKompTechniki.Entity;
using MagazinKompTechnikiGUI.Staff;
using System.Collections.Generic;
using System.Windows;

namespace ComputerHardwareStoreGUI.Staff
{
    /// <summary>
    /// Логика взаимодействия для OrderInfo.xaml
    /// </summary>
    public partial class OrderInfo : Window
    {
        private Order _order;
        private OrderList _orderList;
        private Employee _employee;
        public OrderInfo(int id, OrderList orderList, Employee employee)
        {
            InitializeComponent();
            _order = Order.GetOrderById(id);
            _orderList = orderList;
            _employee = employee;
            if (_employee != Employee.GetEmployeeById(_order.Employee.ID))
            {
                ChangeOrder.Visibility = Visibility.Hidden;
            }
            ShowOrderedProducts(id);
            ShowOrderInfo();
        }
        /// <summary>
        /// Отображает информацию о заказе в необходимых полях
        /// </summary>
        private void ShowOrderInfo()
        {
            Human client = Client.GetClientById(_order.Client.ID);
            Human employee = Employee.GetEmployeeById(_order.Employee.ID);
            ClientName.Text = "Клиент: " + client.GetFullName();
            EmployeeName.Text = "Сотрудник: " + employee.GetFullName();
            if (_order.Guarantee != null)
            {
                GuaranteeDuration.Text = Guarantee.GetGuaranteeById(_order.Guarantee.ID).DurationOfTheGuarantee;
                GuaranteeDuration.Visibility = Visibility.Visible;
            }
            if (_order.Delivery != null)
            {
                Delivery delivery = Delivery.GetDeliveryById(_order.Delivery.ID);
                DeliveryAdress.Text = Delivery.GetDeliveryAdress(delivery);
                DeliveryAdress.Visibility = Visibility.Visible;
                DeliveryDate.Text = delivery.DeliveryDate.ToString();
                DeliveryDate.Visibility = Visibility.Visible;
                OrderStatus.Items.RemoveAt(1);
                OrderStatus.Items.RemoveAt(1);                
                if (_order.Status == "Доставляется")
                {
                    OrderStatus.Items.RemoveAt(0);
                    Delivered.IsSelected = true;
                }
                if (_order.Status == "Завершён")
                {
                    OrderStatus.Visibility = Visibility.Hidden;
                    Finished.Visibility = Visibility.Visible;
                }
            } else
            {
                OrderStatus.Items.RemoveAt(3);
                if (_order.Status == "Подготавливается к выдаче")
                {
                    OrderStatus.Items.RemoveAt(0);
                    Prepare.IsSelected = true;  
                }
                if (_order.Status == "На выдаче")
                {
                    OrderStatus.Items.RemoveAt(0);
                    OrderStatus.Items.RemoveAt(0);
                    OnExtradition.IsSelected = true;
                }
                if (_order.Status == "Завершён")
                {
                    OrderStatus.Visibility = Visibility.Hidden;
                    Finished.Visibility = Visibility.Visible;
                }
            }                    
        }
        /// <summary>
        /// Отображает заказанные товары
        /// </summary>
        private void ShowOrderedProducts(int orderID)
        {
            List<Product> products = new List<Product>();
            products = Order.GetOrderedProducts(orderID);
            foreach (var product in products)
                OrderedProducts.Items.Add(product.ProductName);
        }
        /// <summary>
        /// Кнопка изменения заказа
        /// </summary>
        private void ChangeOrder_Click(object sender, RoutedEventArgs e)
        {
            Order.Change(_order, OrderStatus.Text);
            _orderList.ShowOrders();
            Close();
        }
        /// <summary>
        /// Закрытие окна
        /// </summary>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
