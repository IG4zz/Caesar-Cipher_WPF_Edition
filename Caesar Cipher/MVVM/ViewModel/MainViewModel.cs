using Caesar_Cipher.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public CryptionViewModel CryptionVM { get; set; }
        public HelpViewModel HelpVM { get; set; }
        public RelayCommand CryptionViewCommand { get; set; }
        public RelayCommand HelpViewCommand { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
               _currentView = value;
               OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CryptionVM = new CryptionViewModel();
            HelpVM = new HelpViewModel();

            CurrentView = CryptionVM;

            CryptionViewCommand = new RelayCommand(o =>
            {
                CurrentView = HelpVM;
            });

            HelpViewCommand = new RelayCommand(o =>
            {               
                CurrentView = CryptionVM;
            });
        }

    }
}
