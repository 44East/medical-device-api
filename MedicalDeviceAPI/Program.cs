using MedicalDeviceAPI;
using System.IO.Ports;

internal class Program
{
    static async Task Main(string[] args)
    {
        var comPort = new COMPort()
        {
            Name = "COM9",
            BaudRate = 9600,
            Parity = Parity.None,
            DataBits = 8,
            StopBits = StopBits.One
        };

        var nats = new NatsComPortReader(comPort, "nats://localhost:4222", "mediсal_device");
        await nats.StartReadingAsync();

    }
}