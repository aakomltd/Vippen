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
            Entries = new ObservableCollection<string>(rasParser.ParsePbk());
        }

        private ObservableCollection<string> _entries;
        public ObservableCollection<string> Entries
        {
            get { return _entries; }
            set
            {
                if (_entries != null && _entries.SequenceEqual(value))
                    return;

                _entries = value;
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
