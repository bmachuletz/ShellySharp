using ShellySharp;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> devices = new List<string> { "http://192.168.178.104", "http://192.168.178.104" };
            devices.ForEach(devString =>
            {
                string type = ShellySharp.Discover.GetDeviceInformation(devString).Type;

                switch (type)
                {
                    case "SHSW-25":
                        Shelly25 shelly = new Shelly25("http://192.168.178.104");
                        shelly.Relays[0].SwitchOn();
                        Thread.Sleep(5000);
                        shelly.Relays[0].SwitchOff();
                        Thread.Sleep(5000);
                        shelly.Relays[0].SwitchOn();
                        Thread.Sleep(5000);
                        shelly.Relays[0].SwitchOff();
                        break;
                    case ""
                    default:
                        break;
                }
            });
        }
    }
}
