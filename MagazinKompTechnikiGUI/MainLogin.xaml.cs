using MagazinKompTechniki;
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
using System.Windows.Shapes;

namespace MagazinKompTechnikiGUI
{
    /// <summary>
    /// Логика взаимодействия для MainLogin.xaml
    /// </summary>
    public partial class MainLogin : Window
    {
        public MainLogin()
        {
            InitializeComponent();
            using (var db = new ApplicationContext()) db.Client.Add(new Client());
        }        
    }
}
