using MagazinKompTechniki;
using MagazinKompTechniki.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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

        public void ShowProductTypes()
        {
            List<string> productTypes = Compartment.GetProductTypes();
            for (int i = 0; i < productTypes.Count; i++)
            {
                ProductType.Items.Add(productTypes[i]);
            }
        }
        public void UpdateManufacturer(object sender, System.Windows.Input.MouseEventArgs e)
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
        public void UpdateModel(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShelfID.Text = "";
            ProductModel.Items.Clear();
            List<string> models = Shelf.GetModels(ProductManufacturer.Text, ProductType.Text);
            for (int i = 0; i < models.Count; i++)
            {
                ProductModel.Items.Add(models[i]);
            }
        }
        public void UpdateShelfs(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ShelfID.Text = "";
            int shelf = Shelf.GetShelfs(ProductModel.Text, ProductManufacturer.Text);
            ShelfID.Text = shelf.ToString();
        }
        public void ShowProduct()
        {
            dataGridProduct.ItemsSource = Product.GetProductInfo();
        }

        public void AddProduct_Button(object sender, RoutedEventArgs e)
        {
            string productName = ProductName.Text;
            int productCost = int.Parse(ProductCost.Text);
            string serialNumber = SerialNumber.Text;
            int shelfID = int.Parse(ShelfID.Text);
            AddProd(productName, productCost, serialNumber, shelfID);
            dataGridProduct.ItemsSource = Product.GetProductInfo();
        }

        public void AddProd(string productName, int productCost, string serialNumber, int shelfID)
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

    }
}
