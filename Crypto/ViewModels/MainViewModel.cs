using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Crypto.Services.CoincapService cryptoService = new Services.CoincapService();
        public ObservableCollection<Models.CoincapAssetModel> Assets { get; set; }

        public MainViewModel()
        {
            Assets = new ObservableCollection<Models.CoincapAssetModel>(cryptoService.Assets);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
