using System.Windows;
using System.Windows.Controls;

namespace MagazinKompTechnikiGUI
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        Page addStaff;
        Page addProduct;
        public AdminPanel()
        {
            InitializeComponent();
            AddPage();
            View.Navigate(addStaff);
            WindowState = WindowState.Maximized;
        }
        public void AddPage()
        {
            addStaff = new AddStaff();
            addProduct = new AddProduct();
        }

        public void AddStaff_Button(object sender, RoutedEventArgs e)
        {
            View.Navigate(addStaff);
        }
        public void AddProduct_Button(object sender, RoutedEventArgs e)
        {
            View.Navigate(addProduct);
        }
    }
}
