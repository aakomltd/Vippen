using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Vippen.Services;

namespace Vippen.Model
{
    public class RasEntries : INotifyPropertyChanged
    {
        public RasEntries(IRasParserService rasParser)
        {
            Networks = new ObservableCollection<Network>(
                rasParser.ParsePbk().Select(n => new Network(n)));
        }

        private ObservableCollection<Network> _networks;
        public ObservableCollection<Network> Networks
        {
            get { return _networks; }
            set
            {
                if (_networks != null && _networks.SequenceEqual(value))
                    return;

                _networks = value;
                OnPropertyChanged("Entries");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
