using MagazinKompTechniki;
using MagazinKompTechniki.Entity;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace MagazinKompTechnikiGUI
{
    /// <summary>
    /// Логика взаимодействия для MainLogin.xaml
    /// </summary>
    public partial class MainLogin : Window
    {
        public MainLogin()
        {
            new ApplicationContext(ApplicationContext.GetDB());
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = Employee.SingIn(loginText.Text, GetHash(passText.Password));

            if (employee != null)
            {
                if (loginText.Text == "admin")
                {
                    var adminPanel = new AdminPanel();
                    this.Close();
                    adminPanel.Show();
                }
                else
                {
                    var staffPannel = new StaffPannel(employee);
                    this.Close();
                    staffPannel.Show();
                }
            }
        }
        private static string GetHash(string input)
        {
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
