using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace AgroSolutions.Sensor.Api.Services;

public class RabbitMqPublisher
{
    public void Publish<T>(T message)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();


        channel.QueueDeclare(
            queue: "sensor-data",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(
            exchange: "",
            routingKey: "sensor-data",
            basicProperties: null,
            body: body
        );
    }
}
