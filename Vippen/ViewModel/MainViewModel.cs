using GalaSoft.MvvmLight;
using Vippen.Model;
using GalaSoft.MvvmLight.Command;
using Vippen.Services;
using GalaSoft.MvvmLight.Ioc;

namespace Vippen.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RasEntries RasEntries { get; }
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
                RasEntries = new RasEntries(rasParserService);
                OpenVpnConnection = new RelayCommand<string>(Connect);
            }
        }
        
        public void Connect(string vpn)
        {
            _vpnConnector.Connect(vpn);
        }

    }
}