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
using System.Windows.Shapes;

namespace podgotovka.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        Products product;
        public AddProduct(Products product)
        {
            this.product = product;
            InitializeComponent();
            DataContext= this.product;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.product.Id == 0) {
                DB.data.Products.Add(product);
            }
            DB.data.SaveChanges();
            this.Close();
        }
    }
}
