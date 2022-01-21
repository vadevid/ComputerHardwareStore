using MagazinKompTechniki.Entity;
using MagazinKompTechnikiGUI;
using System.Windows;

namespace ComputerHardwareStoreGUI.Admin
{
    /// <summary>
    /// Логика взаимодействия для ProductInfo.xaml
    /// </summary>
    public partial class ProductInfo : Window
    {
        private Product _product;
        private AddProduct _addProduct;
        public ProductInfo(int id, AddProduct addProduct)
        {
            InitializeComponent();
            _product = Product.GetProductById(id);
            _addProduct = addProduct;
            ShowProductInfo();
        }
        private void ShowProductInfo()
        {
            ProductTitle.Text = _product.ProductName;
            ProductCost.Text = _product.ProductCost.ToString();
            ProductCount.Text = _product.Count.ToString();
            ProductType.Text = Product.GetProductType(_product.ID);
        }
        private void ChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            double changeCost = 0;
            int changeCount = 0;
            if (ChangeCost.Text == null)
                changeCost = double.Parse(ProductCost.Text);
            else changeCost = double.Parse(ChangeCost.Text);
            if (ChangeProductCount.Text == null)
                changeCount = int.Parse(ProductCount.Text);
            else changeCount = int.Parse(ChangeProductCount.Text);

            Product.Change(_product, changeCost, changeCount);
            _addProduct.ShowProduct();
            Close();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
