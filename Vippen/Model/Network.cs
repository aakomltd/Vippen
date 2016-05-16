using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vippen.Model
{
    public class Network : INotifyPropertyChanged
    {
        public Network(string name)
        {
            Name = name;
        }

        private bool _connected;

        public string Name { get; }
        public bool Connected
        {
            get { return _connected; }
            set
            {
                _connected = value;
                OnPropertyChanged("Connected");
            }
        }
        public DateTime ConnectedSince { get; }
        public int LastTimeConnected { get; }
        public int Rank { get; set; }
        public bool Pinned { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
