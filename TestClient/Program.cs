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
                        Shelly25 shelly = new Shelly25(devString);
                        shelly.Relays[0].SwitchOn();
                        Console.WriteLine(string.Format("Relay state is: {0}", shelly.Relays[0].Ison));
                        Thread.Sleep(5000);
                        shelly.Relays[0].SwitchToggle();
                        Console.WriteLine(string.Format("Relay state is: {0}", shelly.Relays[0].Ison));
                        Thread.Sleep(5000);
                        shelly.Relays[0].SwitchToggle();
                        Console.WriteLine(string.Format("Relay state is: {0}", shelly.Relays[0].Ison));
                        Thread.Sleep(5000);
                        shelly.Relays[0].SwitchOff();
                        Console.WriteLine(string.Format("Relay state is: {0}", shelly.Relays[0].Ison));
                        shelly.Relays[0].SwitchOn();
                        Console.WriteLine(string.Format("Relay state is: {0}", shelly.Relays[0].Ison));
                        Thread.Sleep(5000);
                        shelly.Relays[0].SwitchToggle();
                        Console.WriteLine(string.Format("Relay state is: {0}", shelly.Relays[0].Ison));
                        Thread.Sleep(5000);
                        shelly.Relays[0].SwitchToggle();
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
        }
    }
}
