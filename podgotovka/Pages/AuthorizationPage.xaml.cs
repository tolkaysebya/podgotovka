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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            var user = DB.data.User.Where(x => x.Login == TBLogin.Text && x.Password == TBPassword.Password).FirstOrDefault();

            if(user != null) {
                MessageBox.Show("Успешно");
                NavigationService.Navigate(new MainPage(user));
            }
            else
            {
                MessageBox.Show("Не правильные данные");
            }
        }
    }
}
