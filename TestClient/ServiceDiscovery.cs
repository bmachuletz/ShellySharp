using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tmds.MDns;

namespace TestClient
{
    public class ServiceDiscovery
    {
        
        List<string> shellyList;
        private static object s_gate = new object();

        string serviceType = "_http._tcp";
        ServiceBrowser serviceBrowser;

        public ServiceDiscovery()
        {
            shellyList = new List<string>();

            serviceBrowser = new ServiceBrowser();
            serviceBrowser.ServiceAdded += onServiceAdded;
            serviceBrowser.ServiceRemoved += onServiceRemoved;
            serviceBrowser.ServiceChanged += onServiceChanged;

            Console.WriteLine("Starting-Discovery");

            serviceBrowser.StartBrowse(serviceType);
            
            Console.WriteLine("Stop-Discovery <Press Enter>\r\n");
            Console.ReadLine();
        }

        void onServiceChanged(object sender, ServiceAnnouncementEventArgs e)
        {
            printService('~', e.Announcement);
        }

        void onServiceRemoved(object sender, ServiceAnnouncementEventArgs e)
        {
            printService('-', e.Announcement);
        }

        void onServiceAdded(object sender, ServiceAnnouncementEventArgs e)
        {
            printService('+', e.Announcement);
        }

        void printService(char startChar, ServiceAnnouncement service)
        {
            lock (s_gate)
            {
                if (!shellyList.Contains(service.Instance))
                {
                    if (service.Hostname.StartsWith("shelly"))
                    {
                        Console.WriteLine("{0} '{1}' on {2}", startChar, service.Instance, service.NetworkInterface.Name);

                        Console.WriteLine("\tHost: {0} ({1})", service.Hostname, string.Join(", ", service.Addresses));
                        Console.WriteLine("\tPort: {0}", service.Port);
                        Console.WriteLine("\tTxt : [{0}]", string.Join(", ", service.Txt));

                        dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(ShellySharp.Discover.GetDeviceInformationJson(string.Format("http://{0}/{1}", service.Addresses[0].ToString(), "status")));
                        dynamic resultSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(ShellySharp.Discover.GetDeviceInformationJson(string.Format("http://{0}/{1}", service.Addresses[0].ToString(), "settings")));

                        File.WriteAllText(
                            FindFilename(string.Format("{0}_{1}", resultSettings.device.type, "shelly")),
                                ShellySharp.Discover.GetDeviceInformationJson(string.Format("http://{0}/{1}", service.Addresses[0].ToString(), "shelly")));

                        File.WriteAllText(
                            FindFilename(string.Format("{0}_{1}", resultSettings.device.type, "status")),
                                ShellySharp.Discover.GetDeviceInformationJson(string.Format("http://{0}/{1}", service.Addresses[0].ToString(), "status")));

                        File.WriteAllText(
                            FindFilename(string.Format("{0}_{1}", resultSettings.device.type, "settings")),
                                ShellySharp.Discover.GetDeviceInformationJson(string.Format("http://{0}/{1}", service.Addresses[0].ToString(), "settings")));

                        int metersCount = result.meters.Count != null ? result.meters.Count : 0;
                        string mode = resultSettings.mode != null ? resultSettings.mode : string.Empty;
                        string type = resultSettings.device.type != null ? resultSettings.device.type : string.Empty;

                        switch (mode)
                        {
                            case "relay":
                                int relaysCount = result.relays.Count != null ? result.relays.Count : 0;

                                for (int x = 0; x < relaysCount; x++)
                                {
                                    File.WriteAllText(
                                        FindFilename(string.Format("{0}_{1}_{2}", resultSettings.device.type, "relay", x)),
                                            ShellySharp.Discover.GetDeviceInformationJson(string.Format("http://{0}/relay/{1}", service.Addresses[0].ToString(), x)));
                                }
                                break;
                            case "roller":
                                int rollersCount = resultSettings.device.num_rollers != null ? resultSettings.device.num_rollers : 0;

                                for (int x = 0; x < rollersCount; x++)
                                {
                                    File.WriteAllText(
                                        FindFilename(string.Format("{0}_{1}_{2}", resultSettings.device.type, "roller", x)),
                                            ShellySharp.Discover.GetDeviceInformationJson(string.Format("http://{0}/roller/{1}", service.Addresses[0].ToString(), x)));
                                }
                                break;
                            default:
                                break;
                        }

                        for (int x = 0; x < metersCount; x++)
                        {
                            switch (type)
                            {
                                case "SHDM-2":
                                    Console.WriteLine("Shelly Dimmer");
                                    break;

                                case "SHSW-L":
                                    Console.WriteLine("Shelly Switch 1L");
                                    break;
                                default:
                                    File.WriteAllText(
                                        FindFilename(string.Format("{0}_{1}_{2}", resultSettings.device.type, "meter", x)),
                                            ShellySharp.Discover.GetDeviceInformationJson(string.Format("http://{0}/meter/{1}", service.Addresses[0].ToString(), x)));
                                    break;
                            }

                        }
                    }
                }

                shellyList.Add(service.Instance);
            }
        }

        string FindFilename(string filename)
        {
            int x = 0;

            string completeFilename = string.Empty;

            do
            {
                completeFilename = string.Format("{0}_{1}_result.json", x, filename);
                x++;
            }
            while (File.Exists(completeFilename));

            return completeFilename;
        }
    }
}
