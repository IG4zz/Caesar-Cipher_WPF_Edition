using Caesar_Cipher.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher.MVVM.ViewModel
{
    class HelpViewModel : ObservableObject
    {
        public CryptionViewModel CryptionVM { get; set; }
        public HelpViewModel HelpVM { get; set; }

    }  
}
