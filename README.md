# ShellySharp
ShellySharp is an object-mapper for shelly.io-devices

Currently these project is in a very early state. Please contact me if you have any suggestions or if you want to me to integrate more devices

## Supported devices
- Shelly 2.5 (read properties, switch on, switch off, toggle)
- Shelly Dimmer 2 (switch on, switch off)

## Authentication
- at this time not implemented

## NuGet-Package
- is available at: https://www.nuget.org/packages/ShellySharp/#

## Example Code
```csharp
List<string> devices = new List<string> { "http://192.168.178.104", "http://192.168.178.105" };
devices.ForEach(devString =>
{
    string type = ShellySharp.Discover.GetDeviceInformation(devString).Type;

    switch (type)
    {
        case "SHSW-25":
            Shelly25 shelly = new Shelly25(devString);
            
            // register an eventlistener
            shelly.RelaySwitched += Shelly_DeviceSwitched;
            
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
         case "SHDM-2":
            ShellyDevice shdm2 = new ShellyDimmer2(devString);
            shelly.LightSwitched += Shelly_DeviceSwitched;
            
            shdm2.Lights[0].SwitchOff();
            Console.WriteLine(string.Format("Relay state is: {0}", shdm2.Lights[0].Ison));
            Console.WriteLine("Press any key");
            Console.ReadKey();
            shdm2.Lights[0].SwitchOn();
            Console.WriteLine(string.Format("Relay state is: {0}", shdm2.Lights[0].Ison));
            Console.WriteLine("Press any key");
            Console.ReadKey();
            
            break;
        case "ANY_OTHER":
        default:
            break;
    }
});


private static void Shelly_DeviceSwitched(object sender, DeviceSwitchedEventArgs e)
{
    Console.WriteLine("{0} wurde auf '{1}' gestellt.", e.Device.Hostname ,e.IsOn);
}
    
```
