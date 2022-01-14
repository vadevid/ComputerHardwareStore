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
    /// Логика взаимодействия для NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Page
    {
        private Employee _employee;
        public NewOrder(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            FillProduct();
            FillClients();
        }

        public void AddOrder_Button(object sender, RoutedEventArgs e)
        {
            List<Product> products = new List<Product>();
            products.Add(Product.GetProductByName("ASUS H510"));
            products.Add(Product.GetProductByName("ASUS H510M"));
            Client client = Client.GetClientByFullname("Широков", "Дмитрий", "Романович");
            Employee employee = Employee.GetEmployeeByLogin("staff1");
            DateTime orderDate = DateTime.Now;
            string status = "На выдаче";
            AddEmployee(products, client, employee, orderDate, status);
        }
        public void AddEmployee(List<Product> products, Client client, Employee employee, DateTime orderDate, string status)
        {
            var order = new Order()
            {
                Products = products,
                Client = client,
                Employee = employee,
                OrderDate = orderDate,
                Status = status
            };
            Order.Add(order);
        }
        public void FillProduct()
        {
            List<Product> products = new List<Product>(Product.GetAllProducts());
            foreach (Product product in products) ProductList.Items.Add(product.ProductName);
        }
        public void FillClients()
        {
            List<Client> clients = new List<Client>(Client.GetAllClients());
            foreach (Client client in clients) ClientList.Items.Add(client.FullName);
        }

        private List<Product> purchasedProducts = new List<Product>();

        public void SelectProduct(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = Product.GetProductByName(ProductList.SelectedItem.ToString());
            purchasedProducts.Add(selectedProduct);
            SelectedProductList.Items.Add(selectedProduct.ProductName);
        }

        public void UnSelectProduct(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = Product.GetProductByName(SelectedProductList.SelectedItem.ToString());
            purchasedProducts.Remove(selectedProduct);
            SelectedProductList.Items.Remove(selectedProduct.ProductName);
        }
    }
}
