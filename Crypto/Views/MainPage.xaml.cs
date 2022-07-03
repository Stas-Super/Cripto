using Crypto.ViewModels;
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

namespace Crypto.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var page = new CryptoPage();
            var id = ((sender as Grid).Children[0] as Label).Content.ToString();
            page.CoincapAsset = (this.DataContext as MainViewModel)
                .Assets.Where(u => u.Id == id).FirstOrDefault();
            

            MainWindow.Container.Navigate(page);
        }
    }
}
