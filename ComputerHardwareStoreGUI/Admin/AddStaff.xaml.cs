using MagazinKompTechniki.Entity;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MagazinKompTechnikiGUI
{
    /// <summary>
    /// Логика взаимодействия для AddStaff.xaml
    /// </summary>
    public partial class AddStaff : Page
    {
        public AddStaff()
        {
            InitializeComponent();
            ShowEmployee();
        }
        private void ShowEmployee()
        {
            dataGridEmployee.ItemsSource = Employee.GetEmployeeInfo();
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
        private void AddEmployee(string login, string password, string secondName, string firstName, string middleName)
        {
            var employee = new Employee()
            {
                FirstName = firstName,
                SecondName = secondName,
                MiddleName = middleName,
                Login = login,
                Password = password
            };
            Employee.Add(employee);
        }
        private void AddEmploye_Button(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Password.Text == "" || SecondName.Text == "" || FirstName.Text == "" || MiddleName.Text == "")
            {
                MessageBox.Show("Не были введены некоторые данные,\nпожалуйста проверьте все поля");
            } else
            {
                string login = Login.Text;
                string password = Password.Text;
                string secondName = SecondName.Text;
                string firstName = FirstName.Text;
                string middleName = MiddleName.Text;
                AddEmployee(login, GetHash(password), secondName, firstName, middleName);
                ShowEmployee();
            }                     
        }   
    }
}
