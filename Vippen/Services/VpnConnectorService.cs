using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vippen.Services
{
    public interface IVpnConnectorService
    {
        Task<bool> Connect(string vpnName);
    }

    public class VpnConnectorService : IVpnConnectorService
    {
        public VpnConnectorService()
        {
        }

        public async Task<bool> Connect(string vpnName)
        {
            var rasDialer = new Process
            {
                EnableRaisingEvents = true,
                StartInfo =
                {
                    FileName = "rasdial.exe",
                    Arguments = vpnName,
                    CreateNoWindow = true,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            var task = new Task<bool>(() => rasDialer.Start()); //TODO: Error handling
            task.Start();
            return await task;
        }
    }
}
