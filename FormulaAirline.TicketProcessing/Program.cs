using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using static System.Console;


Console.WriteLine("Welcome to the ticketing service");


var factory = new ConnectionFactory(){
    HostName= "localhost",
    UserName= "mehedi",
    Password= "mehedi007",
    VirtualHost= "booking"
};

var conn = factory.CreateConnection();

using var channel = conn.CreateModel();
channel.QueueDeclare("bookings", durable: true, exclusive: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) => {
    var body = eventArgs.Body.ToArray();
    var message= Encoding.UTF8.GetString(body);
    WriteLine($"New ticket processing is initiated - {message}");
};

channel.BasicConsume("bookings", true,  consumer);

Console.ReadKey();