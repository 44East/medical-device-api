using NATS.Client;
using System.IO.Ports;
using System.Text;

namespace MedicalDeviceAPI
{
    internal class NatsComPortReader
    {
        private readonly COMPort _comPort;
        private readonly SerialPort _serialPort;
        private readonly string _natsSubject;
        private readonly IConnection _natsConnection;
        public NatsComPortReader(COMPort comPort, string natsUrl, string natsSubject)
        {
            _comPort = comPort;
            _serialPort = new SerialPort(comPort.Name, comPort.BaudRate, comPort.Parity, comPort.DataBits, comPort.StopBits);

            _natsSubject = natsSubject;

            Options options = ConnectionFactory.GetDefaultOptions();
            options.Url = natsUrl; 

            _natsConnection = new ConnectionFactory().CreateConnection(options);
        }
        public async Task StartReadingAsync()
        {
            using (SerialPort serialPort = _serialPort)
            {
                serialPort.Open();

                Console.WriteLine("Listening for data from COM port...");

                while (true)
                {
                    try
                    {
                        
                        string data = serialPort.ReadLine();

                       
                        byte[] payload = Encoding.UTF8.GetBytes(data);
                        _natsConnection.Publish(_natsSubject, payload); 

                        Console.WriteLine($"Published data to NATS: {data}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading from COM port: {ex.Message}");
                    }
                }
            }
        }
    }
}
