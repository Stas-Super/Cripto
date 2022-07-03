using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Crypto.Models;
using Crypto.Services;
namespace Crypto.ViewModels
{
    public class CryptoViewModel : INotifyPropertyChanged
    {
        private readonly Services.CoincapService coincapService;
        private readonly Services.HistoryRateService historyRateService;
        private CoincapAssetModel model; 

        public CoincapAssetModel CoincapAsset { get => model; set {
                model = value;    
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CoincapAsset)));
        } }
        public ObservableCollection<HistoryRateModel> HistoryRates { get; set; }
        public ICommand GetHistoryCommand { get; set; }
        public CryptoViewModel()
        {
            this.coincapService = new CoincapService();
            this.historyRateService = new HistoryRateService();
            GetHistoryCommand = new RelayCommand(async x => await GetHistory(this.CoincapAsset.Id));
        }

        public async Task<ObservableCollection<HistoryRateModel>> GetHistory(string id)
        {
            var response = await this.historyRateService.GetHistoryAsync(id);
            
            this.HistoryRates = new ObservableCollection<HistoryRateModel>(response);

            return HistoryRates;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
