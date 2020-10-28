using ShellySharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Default using the discovery
             * writing out informations about all shellys found on your network
             * files will be created in your program folder (be sure that you have the
             * appropriate permissions, otherwise the program will crash)
             */
            // ServiceDiscovery discovery = new ServiceDiscovery();

             Shelly25 dev = new Shelly25("http://192.168.178.104");
            dev.SetMode(ShellySharp.Resources.DeviceMode.relay);
            dev.SetFactoryResetFromSwitchEnabled(false);
            /*
             * Using the library as follows
             * 
             * 
            List<string> devices = new List<string> { "http://192.168.178.104"};
            devices.ForEach(devString =>
            {
                string type = ShellySharp.Discover.GetDeviceInformation(devString).Type;

                switch (type)
                {
                    case "SHSW-25":
                        Shelly25 shelly = new Shelly25(devString);
                        shelly.Relays[0].SwitchOn();
                        Console.WriteLine(string.Format("Relay state is: {0}", shelly.Relays[0].Ison));
                        Thread.Sleep(5000);
                        shelly.Relays[0].SwitchOff();
                        Console.WriteLine(string.Format("Relay state is: {0}", shelly.Relays[0].Ison));
                        break;
                    case "ANY_OTHER":
                    default:
                        break;
                }
            });
            */
        }
    }
}
