using GalaSoft.MvvmLight;
using Vippen.Model;
using GalaSoft.MvvmLight.Command;
using Vippen.Services;
using System.Collections.ObjectModel;

namespace Vippen.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Network> Networks { get; }
        private RasEntries RasNetworks { get; }
        public RelayCommand<string> OpenVpnConnection { get; private set;}
        IVpnConnectorService _vpnConnector;

        public MainViewModel(IRasParserService rasParserService, IVpnConnectorService vpnConnectorService)
        {
            if (IsInDesignMode)
            {
            }
            else
            {
                _vpnConnector = vpnConnectorService;
                RasNetworks = new RasEntries(rasParserService);
                Networks = RasNetworks.Networks;
                OpenVpnConnection = new RelayCommand<string>(Connect);
            }
        }
        
        public void Connect(string name)
        {
            foreach (Network net in Networks)
                if (net.Name == name)
                {
                    if(net.Connected)
                    {
                        _vpnConnector.Disconnect(name);
                        net.Connected = false;
                        return;
                    }
                    else
                    {
                        _vpnConnector.Connect(name);
                        net.Connected = true;
                        return;
                    }
                }
        }

    }
}