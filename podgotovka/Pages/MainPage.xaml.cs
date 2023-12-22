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
using System.Xaml.Schema;

namespace podgotovka.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        User user;
        public MainPage(User user)
        {
            this.user = user;   
            
            InitializeComponent();
            listProduct.ItemsSource = DB.data.Products.Where(x=> x.isDeleted == 0).ToList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var result = DB.data.Products.Where(x=> x.Name == searchTextBox.Text).ToList();

            listProduct.ItemsSource = result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listProduct.ItemsSource = DB.data.Products.ToList();
        }

        private void btnKolvo_Click(object sender, RoutedEventArgs e)
        {
            var result = DB.data.Products.OrderByDescending(x => x.Count).ToList();

            listProduct.ItemsSource = result;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var product = (Products)listProduct.SelectedItem;

            if(product == null)
            {
                return;
            }

            product.isDeleted = 1;

            //DB.data.Products.Remove(product);
            DB.data.SaveChanges();

            listProduct.ItemsSource = DB.data.Products.Where(x => x.isDeleted == 0).ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var product = (Products)listProduct.SelectedItem;
            if(product == null)
            {
                MessageBox.Show("Выбери продукт");
            }
            else
            {
                new AddProduct(product).ShowDialog();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new AddProduct(new Products()).ShowDialog();
        }
    }
}
