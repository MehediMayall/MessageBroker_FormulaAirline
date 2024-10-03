using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace FormulaAirline.API.Services;

public class MessageProducer : IMessageProducer
{
    public void SendMessage<T>(T Message)
    {        
        var factory = new ConnectionFactory() {
            HostName = "localhost",
            UserName = "mehedi",
            Password = "mehedi007",
            VirtualHost = "booking"
        };

        var conn = factory.CreateConnection();
        using var channel = conn.CreateModel();
        channel.QueueDeclare("bookings", durable: true, exclusive: false, autoDelete: true, null);

        var jsonString = JsonSerializer.Serialize(Message);
        var body = Encoding.UTF8.GetBytes(jsonString);
        
        channel.BasicPublish("","bookings", body: body);

    }
}