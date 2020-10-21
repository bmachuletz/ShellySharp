# ShellySharp
ShellySharp is a object-mapper for shelly.io-devices

Currently these project is in a very early state. Please contact me if you have any suggestions or if you want to me to integrate more devices

## Supported devices
- Shelly 2.5 (read properties, switch on, switch off)

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
            Shelly25 shelly = new Shelly25("devString");
            shelly.Relays[0].SwitchOn();
            Thread.Sleep(5000);
            shelly.Relays[0].SwitchOff();
            Thread.Sleep(5000);
            shelly.Relays[0].SwitchOn();
            Thread.Sleep(5000);
            shelly.Relays[0].SwitchOff();
            break;
        case "ANY_OTHER":
            break;
        default:
            break;
    }
});
```
