using Crypto.Models;
using Crypto.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для CryptoPage.xaml
    /// </summary>
    public partial class CryptoPage : Page
    {
        private readonly CryptoViewModel _viewModel;
        public Models.CoincapAssetModel CoincapAsset { get; set; }
        public CryptoPage()
        {
            InitializeComponent();
            _viewModel = new CryptoViewModel();
            this.DataContext = _viewModel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.CoincapAsset = CoincapAsset;
            _viewModel.GetHistory(CoincapAsset.Id).ContinueWith(DrawGraph);
        }

        private void DrawLine(double x1, double y1, double x2,double y2)
        {
            var line = new Line { X1 = x1, Y1 = y1, X2 = x2, Y2 = y2, Stroke = Brushes.Salmon, StrokeThickness = 2};
            graph.Children.Add(line);
        }

        private async Task DrawGraph(Task<ObservableCollection<HistoryRateModel>> rateModel)
        {
            var rates = await rateModel;
            double minPrice = rates[0].Price;
            double maxPrice = rates[0].Price;
            long minTime = rates[0].Time;
            long maxTime = rates[0].Time;

            foreach (var rate in rates)
            {
                if (rate.Price > maxPrice)
                    maxPrice = rate.Price;
                if (rate.Price < minPrice)
                    minPrice = rate.Price;
                
                if (rate.Time > maxTime)
                    maxTime = rate.Time;
                if (rate.Time < minTime)
                    minTime = rate.Time;
            }

            double ky = graph.ActualHeight / (maxPrice - minPrice);
            double kx = graph.ActualWidth / (maxTime - minTime);

            double x1 = 0;
            double y1 = graph.ActualHeight - (rates[0].Price - minPrice) * ky;

            foreach (var rate in rates)
            {
                double x2 = (rate.Time - minTime) * kx;
                double y2 = graph.ActualHeight - (rate.Price - minPrice) * ky;
                Dispatcher.Invoke(() =>
                {
                    DrawLine(x1, y1, x2, y2);
                });
                (x1,y1) = (x2,y2);
            }
        }
    }
}
