using Crypto.ViewModels;
using Crypto.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Crypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame Container { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Container = container;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            container.Navigate(new MainPage());
        }
    }
}
