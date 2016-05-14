using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Vippen.Services;

namespace Vippen.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                       // SimpleIoc.Default.Register<IRasParserService, DesignRasParserService>();
            }
            else
            {
                SimpleIoc.Default.Register<IRasParserService, RasParserService>();
                SimpleIoc.Default.Register<IVpnConnectorService, VpnConnectorService>();

            }

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
        }
    }
}