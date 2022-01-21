using ComputerHardwareStoreGUI.Admin;
using MagazinKompTechniki.Entity;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MagazinKompTechnikiGUI
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        public AddProduct()
        {
            InitializeComponent();
            ShowProduct();
            ShowProductTypes();
        }
        public void ShowProduct()
        {
            dataGridProduct.ItemsSource = Product.GetProductInfo();
        }
        private void ShowProductTypes()
        {
            List<string> productTypes = Compartment.GetProductTypes();
            for (int i = 0; i < productTypes.Count; i++)
            {
                ProductType.Items.Add(productTypes[i]);
            }
        }
        private void UpdateManufacturer(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ProductModel.Items.Clear();
            ShelfID.Text = "";
            ProductManufacturer.Items.Clear();
            List<string> manufacturers = Rack.GetManufacturers(ProductType.Text);
            for (int i = 0; i < manufacturers.Count; i++)
            {
                ProductManufacturer.Items.Add(manufacturers[i]);
            }
        }
        private void UpdateModel(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShelfID.Text = "";
            ProductModel.Items.Clear();
            List<string> models = Shelf.GetModels(ProductManufacturer.Text, ProductType.Text);
            for (int i = 0; i < models.Count; i++)
            {
                ProductModel.Items.Add(models[i]);
            }
        }
        private void UpdateShelfs(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShelfID.Text = "";
            int shelf = Shelf.GetShelf(ProductModel.Text, ProductManufacturer.Text);
            ShelfID.Text = shelf.ToString();
        }
        private void AddProduct_Button(object sender, RoutedEventArgs e)
        {
            if (ProductName.Text == "" || ProductCost.Text == "" || SerialNumber.Text == "" || ShelfID.Text == "")
            {
                MessageBox.Show("Не были введены некоторые данные,\nпожалуйста проверьте все поля!");
            }
            else {
                string productName = ProductName.Text;
                int productCost = int.Parse(ProductCost.Text);
                string serialNumber = SerialNumber.Text;
                int shelfID = int.Parse(ShelfID.Text);
                AddProd(productName, productCost, serialNumber, shelfID);
                dataGridProduct.ItemsSource = Product.GetProductInfo();
            }            
        }        
        private void CheckNumber(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        private void AddProd(string productName, int productCost, string serialNumber, int shelfID)
        {
            var product = new Product()
            {
                ProductName = productName,
                ProductCost = productCost,
                SerialNumber = serialNumber,
                Shelf = Shelf.GetShelfByID(shelfID)
            };
            if (Product.GetProductByName(product.ProductName) != null) Product.UpdateCount(Product.GetProductByName(product.ProductName));
            else
            {
                Product.Add(product);
            }
        }
        private void SelectProduct(object sender, MouseButtonEventArgs e)
        {
            Product.ProductInfo selecredProduct = (Product.ProductInfo)dataGridProduct.SelectedValue;
            ProductInfo productInfo = new ProductInfo(selecredProduct.ID, this);
            productInfo.Show();
        }
    }
}
