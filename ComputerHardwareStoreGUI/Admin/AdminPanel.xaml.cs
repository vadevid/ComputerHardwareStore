using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MagazinKompTechnikiGUI
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private SolidColorBrush purple = new SolidColorBrush(Color.FromRgb(0x67, 0x3b, 0xb7));
        private Page addStaff;
        private Page addProduct;
        public AdminPanel()
        {
            InitializeComponent();
            AddPage();
            View.Navigate(addStaff);
            AddStaffBtn.Background = Brushes.White;
            AddStaffBtn.Foreground = purple;
            WindowState = WindowState.Maximized;
        }
        private void AddPage()
        {
            addStaff = new AddStaff();
            addProduct = new AddProduct();
        }
        private void AddStaff_Button(object sender, RoutedEventArgs e)
        {
            View.Navigate(addStaff);
            AddStaffBtn.Background = Brushes.White;
            AddStaffBtn.Foreground = purple;
            AddProductBtn.Background = purple;
            AddProductBtn.Foreground = Brushes.White;
        }
        private void AddProduct_Button(object sender, RoutedEventArgs e)
        {
            View.Navigate(addProduct);
            AddProductBtn.Background = Brushes.White;
            AddProductBtn.Foreground = purple;
            AddStaffBtn.Background = purple;
            AddStaffBtn.Foreground = Brushes.White;
        }
        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            MainLogin mainLogin = new MainLogin();
            Close();
            mainLogin.Show();
        }
    }
}
