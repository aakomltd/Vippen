﻿using System;
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
        Task<bool> Disconnect(string name);
    }

    public class VpnConnectorService : IVpnConnectorService
    {
        public VpnConnectorService()
        {
        }

        public async Task<bool> Connect(string vpnName)
        {
            return await Dialer(vpnName);
        }

        public async Task<bool> Disconnect(string vpnName)
        {
            return await Dialer(vpnName, "/DISCONNECT");
        }

        private async Task<bool> Dialer(string vpnName, string arguments = "")
        {
            var proc = new Process
            {
                EnableRaisingEvents = true,
                StartInfo =
                {
                    FileName = "rasdial.exe",
                    Arguments = $"{vpnName} {arguments}",
                    CreateNoWindow = true,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            var task = new Task<bool>(() => proc.Start()); //TODO: Error handling
            task.Start();
            return await task;
        }

    }
}
