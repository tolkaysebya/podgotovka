using podgotovka.DataBase;
using podgotovka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace podgotovka.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void btnZaebis_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            
            user.Name = txtName.Text;
            user.Login = txtLogin.Text;
            user.Password = txtPass.Text;

            if (user.Password != null && user.Name != null && user.Password != null) {
                DB.data.User.Add(user);
                DB.data.SaveChanges();

                NavigationService.Navigate(new MainPage(user));
            }
            else
            {
                MessageBox.Show("TI LOX");
            }
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
