using MagazinKompTechniki.Entity;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MagazinKompTechnikiGUI.Staff
{
    /// <summary>
    /// Логика взаимодействия для NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Page
    {
        private double totalCost = 0;
        private double guaranteeCost = 0;
        private Employee _employee;
        private OrderList _orderList;
        private List<Product> purchasedProducts = new List<Product>();
        public NewOrder(Employee employee, Page orderList)
        {
            InitializeComponent();
            _employee = employee;
            _orderList = (OrderList)orderList;
            FillProduct();
            FillClients();
            FillGuarantee();
        }
        private void CheckNumber(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void AddOrder_Button(object sender, RoutedEventArgs e)
        {
            List<Product> products = purchasedProducts;
            if (ClientList.SelectedIndex != -1)
            {
                string[] clientData = ClientList.Text.Split(' ');
                Client client = Client.GetClientByFullname(clientData[0], clientData[1], clientData[2]);
                Employee employee = _employee;
                Delivery delivery = null;
                if (Street.Text != null && House.Text != null && Flat.Text != null && DeliverDate.SelectedDate != null)
                {
                    delivery = new Delivery(DeliverDate.DisplayDate, Street.Text, House.Text, int.Parse(Flat.Text), products.Count * 100, employee, client);
                    Delivery.Add(delivery);
                }
                DateTime orderDate = DateTime.Now;
                string status = "Подготавливается";
                Guarantee guarantee = null;
                if (GuaranteeList.SelectedIndex != -1)
                {
                    guarantee = Guarantee.GetGuaranteeByDuration(GuaranteeList.SelectedItem.ToString());
                }
                SelectedProductList.Items.Clear();
                AddOrder(products, client, employee, orderDate, status, guarantee, delivery); 
                _orderList.ShowOrders();
                TotalCost.Text = "0";
            }
            else MessageBox.Show("Не выбран клиент!");

        }
        private void AddOrder(List<Product> products, Client client, Employee employee, DateTime orderDate, string status, Guarantee guarantee, Delivery delivery)
        {
            var order = new Order()
            {
                Products = products,
                Client = client,
                Employee = employee,
                OrderDate = orderDate,
                Status = status,
                Guarantee = guarantee,
                Delivery = delivery
            };
            foreach (var product in products) Product.ReduceCount(product);
            Order.Add(order);
            purchasedProducts.Clear();
            PaymentForTheOrder paymentForTheOrder = new PaymentForTheOrder(order, totalCost);
            PaymentForTheOrder.Add(paymentForTheOrder);
            totalCost = 0;
            FillProduct();
        }
        private void FillProduct()
        {
            ProductList.Items.Clear();
            List<Product> products = new List<Product>(Product.GetAllProducts());
            foreach (Product product in products) if (product.Count > 0)
                {
                    ProductList.Items.Add(product.ProductName);
                }
        }
        public void FillClients()
        {
            ClientList.Items.Clear();
            List<Client> clients = new List<Client>(Client.GetAllClients());
            foreach (Client client in clients) ClientList.Items.Add(client.GetFullName());
        }
        private void FillGuarantee()
        {
            GuaranteeList.Items.Clear();
            List<Guarantee> guarantees = new List<Guarantee>(Guarantee.GetAllGuarantees());
            foreach (Guarantee guarantee in guarantees) GuaranteeList.Items.Add(guarantee.DurationOfTheGuarantee);
        }
        private void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            Street.Visibility = Visibility.Visible;
            House.Visibility = Visibility.Visible;
            Flat.Visibility = Visibility.Visible;
        }
        private void CheckBoxUnChecked(object sender, RoutedEventArgs e)
        {
            Street.Visibility = Visibility.Hidden;
            House.Visibility = Visibility.Hidden;
            Flat.Visibility = Visibility.Hidden;
        }
        private void SelectProduct(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = Product.GetProductByName(ProductList.SelectedItem.ToString());
            if (purchasedProducts.Contains(selectedProduct))
            {
                MessageBox.Show("Товар уже присутствует в списке!");
            }
            else
            {
                purchasedProducts.Add(selectedProduct);
                SelectedProductList.Items.Add(selectedProduct.ProductName);
                totalCost += (selectedProduct.ProductCost + 100);
                TotalCost.Text = totalCost.ToString() + " ₽";
            }
        }
        private void UnSelectProduct(object sender, RoutedEventArgs e)
        {
            if (SelectedProductList.SelectedItem != null)
            {
                Product selectedProduct = Product.GetProductByName(SelectedProductList.SelectedItem.ToString());
                purchasedProducts.Remove(selectedProduct);
                SelectedProductList.Items.Remove(selectedProduct.ProductName);
                totalCost -= (selectedProduct.ProductCost + 100);
                TotalCost.Text = totalCost.ToString() + " ₽";
            }
        }
        private void GuaranteeChange(object sender, RoutedEventArgs e)
        {

            if (GuaranteeList.SelectedItem != null)
            {
                if (guaranteeCost != 0)
                {
                    totalCost -= guaranteeCost;
                }
                guaranteeCost = Guarantee.GetGuaranteeByDuration(GuaranteeList.SelectedItem.ToString()).GuaranteeCost;
                totalCost += guaranteeCost;
            }
            TotalCost.Text = totalCost.ToString() + " ₽";
        }
    }
}
